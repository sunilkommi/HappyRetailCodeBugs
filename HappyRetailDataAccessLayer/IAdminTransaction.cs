using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailEntity;
namespace HappyRetailDataAccessLayer
{
    public interface IAdminDAL
    {
        bool DeleteUser(string username);
        bool AddProduct(ProductEntity pe);
        bool ModifyProduct(string pname, string pdesc);
        bool DeleteProduct(string pname);
       List<ProductEntity> SearchProductByCategory(string catname);
        List<UserCommentsEntity> ViewComments(string username);
        bool AddCategory(CategoryEntity ce);
        bool DeleteCategory(string  cname);
        bool AddSubCategory(SubCategoryEntity sce);
        List<SubCategoryEntity> ViewSubCategories();
        bool DeleteSubCategory(string scatname);
        Dictionary<int, string> GetCategories();
       List<ProductEntity> GetProducts();
        string GetProdDescription(string pname);
    }
}
