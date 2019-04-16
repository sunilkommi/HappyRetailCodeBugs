using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailEntity;
namespace HappyRetailDataAccessLayer
{
    public interface IUserDAL
    {
        List<ProductEntity> SearchProductByCategory(string CatName);
        List<ProductEntity> SearchProductBySubCategory(string SubCat);
        bool AddCart(CartTableEntity cte);
        bool AddCommentByProduct(UserCommentsEntity uc);
    }
}
