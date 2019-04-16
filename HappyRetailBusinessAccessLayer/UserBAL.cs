using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailEntity;
using HappyRetailDataAccessLayer;
namespace HappyRetailBusinessAccessLayer
{
    public class UserBAL
    {
        UserDAL dal = new UserDAL();
        public List<ProductEntity> SearchProductByCategory(string CatName)
        {
            try
            {
                if (string.IsNullOrEmpty(CatName) || string.IsNullOrWhiteSpace(CatName))
                    throw new ApplicationException("Category Name cannot be blank");
                return dal.SearchProductByCategory(CatName);
            }
            catch(ApplicationException ex)
            {
                throw ex;
            }
        }
        public List<ProductEntity> SearchProductBySubCategory(string SubCat)
        {

            try
            {
                if (string.IsNullOrEmpty(SubCat) || string.IsNullOrWhiteSpace(SubCat))
                    throw new ApplicationException("Sub Category Name cannot be blank");
                return dal.SearchProductBySubCategory(SubCat);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
       public bool AddCart(CartTableEntity cte) {
            try
            {
                if (cte.ProdID <= 0)
                    throw new Exception("Product ID cannot be zero or negative");
                if (cte.Quantity <= 0)
                    throw new Exception("Cannot order zero or negative quantity");
                return dal.AddCart(cte);

            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        public bool AddCommentByProduct(UserCommentsEntity uc) {
            try
            {
               if(uc.ProdID<=0)
                    throw new Exception("Product ID cannot be zero or negative");
                if (string.IsNullOrEmpty(uc.CommentDescription) || string.IsNullOrWhiteSpace(uc.CommentDescription))
                    throw new Exception("Comment Description cannot be blank");
                return dal.AddCommentByProduct(uc);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        public bool MakePayment(long cardno,int cvv,int month,int year)
        {
            decimal payamt = dal.GetPaymentAmount();
            
            try
            {
                localhost.PaymentService ps = new localhost.PaymentService();
               return  ps.ValidateCard(cardno,cvv,month,year,payamt);

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
