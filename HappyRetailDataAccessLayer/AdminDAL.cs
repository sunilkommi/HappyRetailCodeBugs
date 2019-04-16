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
    public class AdminDAL : ConnectDB, IAdminDAL
    {
        IDbConnection con = null;
        IDbCommand com = null;
        IDataReader r = null;
        
        public AdminDAL()
        {
            con = GetConnection();
        }
        public bool AddCategory(CategoryEntity ce)
        {
            bool result = false;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "insert into CategoryTable values(@catname)";
                com.CommandText = query;
                IDbDataParameter catname = com.CreateParameter();
                catname.ParameterName = "@catname";
                catname.Value = ce.CategoryName;
                com.Parameters.Add(catname);
                var res = com.ExecuteNonQuery();
                if (res > 0)
                    result = true;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public bool AddProduct(ProductEntity pe)
        {
            bool result = false;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = "insert into ProductTable values(@pname,@pdesc,@price,@dis,@scatid,@img)";
                com = con.CreateCommand();
                com.CommandText = query;
                IDataParameter pname = com.CreateParameter();
                pname.ParameterName = "@pname";
                pname.Value = pe.ProductName;
                com.Parameters.Add(pname);
                IDataParameter pdesc = com.CreateParameter();
                pdesc.ParameterName = "@pdesc";
                pdesc.Value = pe.Description;
                com.Parameters.Add(pdesc);
                IDataParameter price = com.CreateParameter();
                price.ParameterName = "@price";
                price.Value = pe.Price;
                com.Parameters.Add(price);
                IDataParameter dis = com.CreateParameter();
                dis.ParameterName = "@dis";
                dis.Value = pe.Discount;
               com.Parameters.Add(dis);
                IDataParameter scat = com.CreateParameter();
               scat.ParameterName = "@scatid";
               scat.Value = pe.SubCatID;
                com.Parameters.Add(scat);
                IDataParameter img = com.CreateParameter();
               img.ParameterName = "@img";
                img.Value = pe.Image;
                com.Parameters.Add(img);
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

        public bool AddSubCategory(SubCategoryEntity sce)
        {
            bool result = false;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "insert into SubCategoryTable values(@scatname,@catid)";
                com.CommandText = query;
                IDataParameter scatname = com.CreateParameter();
                scatname.ParameterName = "@scatname";
                scatname.Value = sce.SubCategoryName;
                com.Parameters.Add(scatname);
                IDataParameter catid = com.CreateParameter();
                catid.ParameterName = "@catid";
                catid.Value = sce.CatID;
                com.Parameters.Add(catid);
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

        public bool DeleteCategory(string  cname)
        {
            bool result = false;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "delete from CategoryTable where CategoryName='" + cname + "'";
                com.CommandText = query;
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
        
        public bool DeleteProduct(string pname)
        {
            bool result = false;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "delete from ProductTable where ProdName='" + pname + "'";
                com.CommandText = query;
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

        public bool DeleteSubCategory(string scatname)
        {
            bool result = false;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "delete SubCategoryTable where SubCatName='" + scatname+"'";
                com.CommandText = query;
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

        public bool DeleteUser(string username)
        {
            bool result = false;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "delete UserInfoTable where Name='" + username + "'";
                com.CommandText = query;
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

        public bool ModifyProduct(string pname,string pdesc)
        {
            bool result = false;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "update ProductTable set ProdDescription=@pdesc where ProdName=@pname";
                com.CommandText = query;
                IDataParameter pdes = com.CreateParameter();
                pdes.ParameterName = "@pdesc";
                pdes.Value = pdesc;
                com.Parameters.Add(pdes);
                IDataParameter pnm = com.CreateParameter();
                pnm.ParameterName = "@pname";
                pnm.Value = pname;
                com.Parameters.Add(pnm);
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

        public List<ProductEntity> SearchProductByCategory(string catname)
        {
            List<ProductEntity> plist = new List<ProductEntity>();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "select p.prodid,p.prodname,p.proddescription,p.price,p.discount,c.CategoryName,p.Image from ProductTable p join SubCategoryTable s on p.SubCatID=s.SubCatID join CategoryTable c on c.CategoryID=s.CatID where c.CategoryName=@cname";
                com.CommandText = query;
                IDataParameter cname = com.CreateParameter();
                cname.ParameterName = "@cname";
                cname.Value = catname;
                com.Parameters.Add(cname);
                r = com.ExecuteReader();
                while(r.Read())
                {
                    ProductEntity p = new ProductEntity();
                    p.ProdId = Convert.ToInt32(r[0]);
                    p.ProductName = r[1].ToString();
                    p.Description = r[2].ToString();
                    p.Price = Convert.ToDecimal(r[3]);
                  
                    
                    p.CatName = r[5].ToString();
                   
                    plist.Add(p);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return plist;
        }
        
      public int GetUserID(string uname)
        {
            int id = 0;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "select id from UserInfoTable where Name=@uname";
                com.CommandText = query;
                IDataParameter uid = com.CreateParameter();
                uid.ParameterName = "@uname";
                uid.Value = uname;
                com.Parameters.Add(uid);
                var res= Convert.ToInt32(com.ExecuteScalar());
                id= Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return id;
        }

        public List<UserCommentsEntity> ViewComments(string username)
        {
            List<UserCommentsEntity> uc = new List<UserCommentsEntity>();
            try
            {
                int usrid = GetUserID(username);
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "select * from UserCommentTable where UserID=@uid";
                com.CommandText = query;
                IDataParameter uid = com.CreateParameter();
                uid.ParameterName = "@uid";
                uid.Value = usrid;
                com.Parameters.Add(uid);
              
                r = com.ExecuteReader();
                while(r.Read())
                {
                    UserCommentsEntity ue = new UserCommentsEntity();
                    ue.CommentID = Convert.ToInt32(r[0]);
                    ue.CommentDate = Convert.ToDateTime(r[1]);
                    ue.UserID = Convert.ToInt32(r[2]);
                    ue.ProdID = Convert.ToInt32(r[3]);
                    ue.CommentDescription = r[4].ToString();
                    uc.Add(ue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return uc;
        }
        
        public List<SubCategoryEntity> ViewSubCategories()
        {
            List<SubCategoryEntity> se = new List<SubCategoryEntity>();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "select s.SubCatID,s.SubCatName,c.CategoryName from SubCategoryTable s join CategoryTable c on s.CatID=c.CategoryID";
                com.CommandText = query;
                r = com.ExecuteReader();
                while(r.Read())
                {
                    SubCategoryEntity sce = new SubCategoryEntity();
                    sce.SubCatID = Convert.ToInt32(r[0]);
                    sce.SubCategoryName = r[1].ToString();
                    sce.CatName = r[2].ToString();
                    se.Add(sce);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return se;
        }
       

       

        public Dictionary<int, string> GetCategories()
        {
            Dictionary<int, string> cname = new Dictionary<int, string>();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = "select * from CategoryTable";
                com = con.CreateCommand();
                com.CommandText = query;
                r = com.ExecuteReader();
                while(r.Read())
                {
                    cname.Add(Convert.ToInt32(r[0]), Convert.ToString(r[1]));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return cname;
        }

        public List<ProductEntity> GetProducts()
        {
            List<ProductEntity> pname = new List<ProductEntity>();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = "select p.prodid,p.prodname,p.proddescription,p.price,p.discount,c.CategoryName,p.Image from ProductTable p join SubCategoryTable s on p.SubCatID=s.SubCatID join CategoryTable c on c.CategoryID=s.CatID ";
                com = con.CreateCommand();
                com.CommandText = query;
                r = com.ExecuteReader();
                while (r.Read())
                {
                    ProductEntity pe = new ProductEntity();
                    pe.ProdId = Convert.ToInt32(r[0]);
                    pe.ProductName = r[1].ToString();
                    pe.Description = r[2].ToString();
                    pe.Price = Convert.ToDecimal(r[3]);
                    pe.Discount = Convert.ToDecimal(r[4]);
                    pe.CatName = r[5].ToString();
                    pe.Image = r[6].ToString();
                    pname.Add(pe);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return pname;
        }
        public string GetProdDescription(string pname)
        {
            string pdesc = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                com = con.CreateCommand();
                string query = "select ProdDescription from ProductTable where ProdName='" + pname + "'";
                com.CommandText = query;
                pdesc = com.ExecuteScalar().ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return pdesc;
        }
    }
}

