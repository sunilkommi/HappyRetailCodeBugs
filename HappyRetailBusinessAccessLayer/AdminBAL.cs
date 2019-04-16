using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailEntity;
using HappyRetailDataAccessLayer;
using System.Text.RegularExpressions;

namespace HappyRetailBusinessAccessLayer
{
    public class AdminBAL
    {
        AdminDAL dal = new AdminDAL();

        public bool DeleteUser(string username)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                throw new Exception("Name cannot be null or empty");
            else
                return dal.DeleteUser(username);


        }
        public bool AddProduct(ProductEntity pe)
        {
            if (string.IsNullOrEmpty(pe.ProductName) || string.IsNullOrWhiteSpace(pe.ProductName))
                throw new Exception("ProductName cannot be Blank or empty");
            if (string.IsNullOrEmpty(pe.Description) || string.IsNullOrWhiteSpace(pe.Description))
                throw new Exception("Description cannot be Blank or empty");

            if (pe.Price <= 0)
                throw new Exception("Price Cannot be zero or negative");
            if (pe.Discount < 0)
                throw new Exception("Discount cannot be negative");

            if (string.IsNullOrEmpty(pe.Image) || string.IsNullOrWhiteSpace(pe.Image))
                throw new Exception("Image Path cannot be blank");
            Regex filepath = new Regex(@"^(?:[\w]\:|\\)(\\[a-z_\-\s0-9\.]+)+\.(jpeg|gif|png)$");
            if (filepath.IsMatch(pe.Image))
            {

            }
            else
            {
                throw new Exception("Valid FilePath should be given and extension should be .jpeg,gif or png");
            }


            return dal.AddProduct(pe);

        }
        public bool ModifyProduct(string pname, string pdesc)
        {
            if (string.IsNullOrEmpty(pname) || string.IsNullOrWhiteSpace(pname))
                throw new Exception("ProductName cannot be Blank or empty");
            if (string.IsNullOrEmpty(pdesc) || string.IsNullOrWhiteSpace(pdesc))
                throw new Exception("Description cannot be Blank or empty");
            return dal.ModifyProduct(pname, pdesc);
        }
        public bool DeleteProduct(string pname)
        {
            if (string.IsNullOrEmpty(pname) || string.IsNullOrWhiteSpace(pname))
                throw new Exception("ProductName cannot be Blank or empty");
            return dal.DeleteProduct(pname);
        }
        public List<ProductEntity> SearchProductByCategory(string catname)
        {
            if (string.IsNullOrEmpty(catname) || string.IsNullOrWhiteSpace(catname))
                throw new Exception("Category Name cannot be Blank or empty");
            return dal.SearchProductByCategory(catname);
        }
        public List<UserCommentsEntity> ViewComments(string username)
        {
            return dal.ViewComments(username);
        }
        public bool AddCategory(CategoryEntity ce)
        {
            if (string.IsNullOrEmpty(ce.CategoryName) || string.IsNullOrWhiteSpace(ce.CategoryName))
                throw new Exception("CategoryName cannot be Blank or empty");
            return dal.AddCategory(ce);
        }
        public bool DeleteCategory(string ce)
        {
            if (string.IsNullOrEmpty(ce) || string.IsNullOrWhiteSpace(ce))
                throw new Exception("CategoryName cannot be Blank or empty");
            return dal.DeleteCategory(ce);
        }
        public bool AddSubCategory(SubCategoryEntity sce)
        {
            if (string.IsNullOrEmpty(sce.SubCategoryName) || string.IsNullOrWhiteSpace(sce.SubCategoryName))
                throw new Exception("SubCategoryName cannot be Blank or empty");
            if (sce.CatID <= 0)
                throw new Exception("Please Enter the CategoryID Displaying Above. ID cannot be zero or NULL");
            return dal.AddSubCategory(sce);
        }

        public List<SubCategoryEntity> ViewSubCategories()
        {
            return dal.ViewSubCategories();
        }
        public bool DeleteSubCategory(string scatname)
        {
            if (string.IsNullOrEmpty(scatname) || string.IsNullOrWhiteSpace(scatname))
                throw new Exception("SubCategoryName cannot be Blank or empty");
            return dal.DeleteSubCategory(scatname);
        }
        public Dictionary<int, string> GetCategories()
        {
            return dal.GetCategories();
        }
        public List<ProductEntity> GetProducts()
        {
            return dal.GetProducts();
        }
        public string GetProdDescription(string pname)
        {
            if (string.IsNullOrEmpty(pname) || string.IsNullOrWhiteSpace(pname))
                throw new Exception("ProductName cannot be Blank or empty");
            return dal.GetProdDescription(pname);
        }
    }
}
