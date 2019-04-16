using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailEntity;
using System.Data;
using System.Data.Common;
namespace HappyRetailDataAccessLayer
{
    public class UserDAL : ConnectDB, IUserDAL
    {
        IDbConnection con = null;
        IDbCommand com , com1= null;
        IDataReader r,r1 = null;

        public UserDAL()
        {
            con = GetConnection();
        }
        public bool AddCart(CartTableEntity cte)
        {
            bool result = false;
            decimal price = 0.0M;
            decimal discount = 0.0M;
            try
            {
                cte.UserId = LoginDAL.UID;
                if (con.State != ConnectionState.Open)
                    con.Open();
                string q = "select price,discount from ProductTable where prodid=@pid";
               
                string query = "insert into ShoppingCartTable values(@uid,@pid,@qty,@odate,@totamt)";
                com1 = con.CreateCommand();
                com1.CommandText = q;
                
                IDataParameter pid = com1.CreateParameter();
                pid.ParameterName = "@pid";
                pid.Value = cte.ProdID;
                com1.Parameters.Add(pid);
                r = com1.ExecuteReader();
                if(r.Read())
                {
                    price = Convert.ToDecimal(r[0]);
                    discount = Convert.ToDecimal(r[1]);
                }
                r.Close();
                com = con.CreateCommand();
                com.CommandText = query;
                IDataParameter uid = com.CreateParameter();
                uid.ParameterName = "@uid";
                uid.Value = cte.UserId;
                com.Parameters.Add(uid);
                IDataParameter prid = com.CreateParameter();
                prid.ParameterName = "@pid";
                prid.Value = cte.ProdID;
                com.Parameters.Add(prid);
                IDataParameter qty = com.CreateParameter();
                qty.ParameterName = "@qty";
                qty.Value = cte.Quantity;
                com.Parameters.Add(qty);
                cte.OrderDate = DateTime.Now;
                IDataParameter odate = com.CreateParameter();
                odate.ParameterName = "@odate";
                odate.Value = cte.OrderDate;
                com.Parameters.Add(odate);
                cte.TotalAmount = ((Convert.ToDecimal(cte.Quantity) * price) - (discount*cte.Quantity));
                IDataParameter tot = com.CreateParameter();
                tot.ParameterName = "@totamt";
                tot.Value = cte.TotalAmount;
                com.Parameters.Add(tot);
                var res = com.ExecuteNonQuery();
                if (res > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public bool AddCommentByProduct(UserCommentsEntity uc)
        {
            bool result = false;

            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "insert into UserCommentTable values(@cdate,@uid,@pid,@cdesc)";
                com.CommandText = query;
                IDataParameter cdate = com.CreateParameter();
                cdate.ParameterName = "@cdate";
                cdate.Value = DateTime.Now;
                com.Parameters.Add(cdate);
                IDataParameter uid = com.CreateParameter();
                uid.ParameterName = "@uid";
                uid.Value = LoginDAL.UID;
                com.Parameters.Add(uid);
                IDataParameter pid = com.CreateParameter();
                pid.ParameterName = "@pid";
               pid.Value = uc.ProdID;
                com.Parameters.Add(pid);
                IDataParameter cdesc = com.CreateParameter();
                cdesc.ParameterName = "@cdesc";
                cdesc.Value = uc.CommentDescription;
                com.Parameters.Add(cdesc);
                var res = com.ExecuteNonQuery();
                if (res > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                con.Close();
            }
            return result;
        }

      

       

        public List<ProductEntity> SearchProductByCategory(string CatName)
        {
           try
            {
                AdminDAL dal = new AdminDAL();
                return dal.SearchProductByCategory(CatName);
            }
            catch(InvalidCategoryNameException ex)
            {
                throw ex;
            }
        }
        public decimal GetPaymentAmount()
        {
            decimal amount = 0.0M;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "select totalamount from shoppingcartTable where OrderDate=(select Max(OrderDate) from ShoppingCartTable where UserID=@uid)";
                com.CommandText = query;
                IDataParameter uid = com.CreateParameter();
                uid.ParameterName = "@uid";
                uid.Value = LoginDAL.UID;
                com.Parameters.Add(uid);
                r = com.ExecuteReader();
                if(r.Read())
                {
                    amount = Convert.ToDecimal(r[0]);
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return amount;
        }
        public List<ProductEntity> SearchProductBySubCategory(string SubCat)
        {
            List<ProductEntity> plist = new List<ProductEntity>();
            try
            {
                string query = "select p.prodid,p.prodname,p.proddescription,p.price,p.discount,c.CategoryName,s.SubCatName,p.Image from ProductTable p join SubCategoryTable s on p.SubCatID = s.SubCatID join CategoryTable c on c.CategoryID = s.CatID where s.SubCatName = @scatname";
                com = con.CreateCommand();
                com.CommandText = query;
                IDataParameter scat = com.CreateParameter();
                scat.ParameterName = "@scatname";
                scat.Value = SubCat;
                com.Parameters.Add(scat);
                if (con.State != ConnectionState.Open)
                    con.Open();
                r = com.ExecuteReader();
                while(r.Read())
                {
                    ProductEntity p = new ProductEntity();
                    p.ProdId = Convert.ToInt32(r[0]);
                    p.ProductName = r[1].ToString();
                    p.Description = r[2].ToString();
                    p.Price = Convert.ToDecimal(r[3]);
                    p.Discount = Convert.ToDecimal(r[4]);
                    p.CatName = r[5].ToString();
                    p.SubCatName = r[6].ToString();
                    p.Image = r[7].ToString();
                    plist.Add(p);
                }
            }
            catch(InvalidSubCategoryNameException ex)
            {

            }
            finally
            {
                con.Close();
            }
            return plist;
        }
    }
}
