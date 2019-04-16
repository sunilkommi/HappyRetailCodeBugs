using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailEntity;
using HappyRetailBusinessAccessLayer;
namespace HappyRetailConsoleUI.AdminModule
{
   public  class AdminMenu
    {
        AdminBAL bal = new AdminBAL();
        public  void PrintStars()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write("*");

        }
        public  void MenuAdmin()
        {
            int ch;
            Console.WriteLine("Main Menu");
            PrintStars();
            Console.WriteLine("1.Product");
            Console.WriteLine("2.Category");
            Console.WriteLine("3.Sub Category");
            Console.WriteLine("4.View User Comments Product Wise");
            Console.WriteLine("5.Delete Registered User");
            Console.WriteLine("6.Back");
            PrintStars();
            Console.WriteLine("Enter Choice of Admin Operation");
            ch = int.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1: ProductMenu();
                    break;
                case 2: CategoryMenu();
                    break;
                case 3: SubCategoryMenu();
                    break;
                case 4: CommentsMenu();
                    break;
                case 5: DeleteUser();
                    break;
                case 6:
                    Console.Clear();
                    LoginModule.LoginMenu lm=new LoginModule.LoginMenu();
                    lm.Login();
                    break;
                default:PrintStars();
                    Console.WriteLine("Invalid Choice");
                    PrintStars();
                    break;
            }

        }
        private void ProductMenu()
        {
            char ans = 'y';
            while (ans == 'Y' || ans == 'y')
            {
                Console.WriteLine("1.Product");
                Console.WriteLine("\t1.Add Product");
                Console.WriteLine("\t2.View Product");
                Console.WriteLine("\t3.View Product based on Category Name");
                Console.WriteLine("\t4.Modify Product Description Details");
                Console.WriteLine("\t5.Delete Product");
                Console.WriteLine("\t6.Back");
                Console.WriteLine("Enter the Choice for Product Operation");
                int ch = int.Parse(Console.ReadLine());
                switch(ch)
                {
                    case 1: AddProduct();
                        break;
                    case 2: ViewProduct();
                        break;
                    case 3: ViewProductByCategory();
                        break;
                    case 4: ModifyProduct();
                        break;
                    case 5: DeleteProduct();
                        break;
                    case 6:
                        Console.Clear();
                        Back();
                        break;
                }
                Console.WriteLine("Do You Want to Continue(Y/N)?");
                ans = char.Parse(Console.ReadLine());
            }


        }
        private void CategoryMenu()
        {
            char ans = 'y';
            while (ans == 'Y' || ans == 'y')
            {
                Console.WriteLine("2.Category");
            Console.WriteLine("\t1.Add Category");
            Console.WriteLine("\t2.View Category");
            Console.WriteLine("\t3.Delete Category");
            Console.WriteLine("\t4.Back");
                Console.WriteLine("Enter the Choice for Category Operation");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddCategory();
                        break;
                    case 2:
                        ViewCategory();
                        break;
                    case 3:
                        DeleteCategory();
                        break;
                    case 4:
                        Console.Clear();
                        Back();
                        break;
                }
                Console.WriteLine("Do You Want to Continue(Y/N)?");
                ans = char.Parse(Console.ReadLine());
            }

        }
        private void SubCategoryMenu()
        {
            char ans = 'y';
            while (ans == 'Y' || ans == 'y')
            {
                Console.WriteLine("3.Sub Category");
                Console.WriteLine("\t1.Add Sub Category");
                Console.WriteLine("\t2.View Sub Category");
                Console.WriteLine("\t3.Delete Sub Category");
                Console.WriteLine("\t4.Back");
                Console.WriteLine("Enter the Choice for SubCategory Operations");
                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        AddSubCategory();
                        break;
                    case 2:
                        ViewSubCategory();
                        break;
                    case 3:
                        DeleteSubCategory();
                        break;
                    case 4:
                        Console.Clear();
                        Back();
                        break;
                }
                Console.WriteLine("Do You Want to Continue(Y/N)?");
                ans = char.Parse(Console.ReadLine());

            }
        }

       private void  AddCategory()
        {
            try
            {
                CategoryEntity ce = new CategoryEntity();
                Console.WriteLine("Enter Category Name");
                ce.CategoryName = Console.ReadLine();
                var r = bal.AddCategory(ce);
                if (r)
                {
                    Console.WriteLine("Category Added Successfully");
                    var res = bal.GetCategories();
                    Console.WriteLine("{0,10}{1,20}", "ID", "Category Name");
                    foreach (KeyValuePair<int, string> kvp in res)
                        Console.WriteLine("{0,10}{1,20}", kvp.Key, kvp.Value);
                        }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
       
      private void ViewCategory()
        {
            try
            {
                var res = bal.GetCategories();
                Console.WriteLine("{0,10}{1,20}", "ID", "Category Name");
                foreach (KeyValuePair<int, string> kvp in res)
                    Console.WriteLine("{0,10}{1,20}", kvp.Key, kvp.Value);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
                        
     private void DeleteCategory()
        {
            try
            {
                var res = bal.GetCategories();
                Console.WriteLine("ID \t  Category Name");
                foreach (KeyValuePair<int, string> kvp in res)
                    Console.WriteLine(kvp.Key + "\t" + kvp.Value);
                Console.WriteLine("Enter Category Name");
                string catname = Console.ReadLine();
                var del = bal.DeleteCategory(catname);
                if(del)
                {
                    Console.WriteLine("Category Deleted Successfully");
                    res = bal.GetCategories();
                    Console.WriteLine("{0,10}{1,20}", "ID","Category Name");
                    foreach (KeyValuePair<int, string> kvp in res)
                        Console.WriteLine("{0,10}{1,20}",kvp.Key , kvp.Value);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void CommentsMenu()
        {

            try
            {
                Console.WriteLine("Enter Username");
                string uname = Console.ReadLine();
                var res = bal.ViewComments(uname);
                Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,35}", "ID","Comment Date", "UserID", "ProductID", "CommentDescription");
                foreach(var r in res)
                {

                    Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,35}", r.CommentID,r.CommentDate, r.UserID, r.ProdID, r.CommentDescription);
                }
                Console.WriteLine("Do you want to Continue(Y/N)?");
                char ans = Char.Parse(Console.ReadLine());
                if (ans == 'Y' || ans == 'y')
                {
                    Console.Clear();
                    MenuAdmin();
                }
                else
                {
                    Console.Clear();
                    LoginModule.LoginMenu lm = new LoginModule.LoginMenu();
                    lm.Login();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void DeleteUser()
        {
            try
            {
                Console.WriteLine("Enter UserName");
                string uname = Console.ReadLine();
                var res = bal.DeleteUser(uname);
                if(res)
                {
                    Console.WriteLine("User Deleted Successfully");
                }
                Console.WriteLine("Do you want to Continue(Y/N)?");
                char ans = Char.Parse(Console.ReadLine());
                if (ans == 'Y' || ans == 'y')
                {
                    Console.Clear();
                    MenuAdmin();
                }
                else
                {
                    Console.Clear();
                    LoginModule.LoginMenu lm = new LoginModule.LoginMenu();
                    lm.Login();
                        }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void Back()
        {
            Console.Clear();
            MenuAdmin();
        }

        private void AddProduct()
        {
            try
            { 
            ProductEntity pe = new ProductEntity();
            Console.WriteLine("Enter Product Name");
            pe.ProductName = Console.ReadLine();
            Console.WriteLine("Enter Product Description");
            pe.Description = Console.ReadLine();
            Console.WriteLine("Enter Price");
            pe.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Discount");
            pe.Discount = decimal.Parse(Console.ReadLine());
            var res = bal.ViewSubCategories();
            foreach (var r in res)
                Console.WriteLine(r.SubCatID + "\t" + r.SubCategoryName + "\t" + r.CatName);
            Console.WriteLine("Enter the SubCategory ID to which new product belongs");
            pe.SubCatID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Image Path for the Product");
            pe.Image = Console.ReadLine();
            var rs = bal.AddProduct(pe);
            if (rs)
            {
                Console.WriteLine("New Product Added Successfully");
                    GetProducts();
            }
        }
         catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

}
        private void ViewProduct() {
            var r = bal.GetProducts();
            string op = string.Format("{0,10}{1,15}{2,25}{3,15}{4,15}{5,20}", "ID", "Name", "Description", "Price", "Discount", "Image");

            Console.WriteLine(op);

            foreach (var o in r)
            {
                Console.WriteLine("{0,10}{1,15}{2,25}{3,15}{4,15}{5,20}",o.ProdId ,  o.ProductName,o.Description, o.Price ,o.Discount , o.Image);
            }
        }
        
        private void ViewProductByCategory()
        {
            try { 
            Console.WriteLine("Categories in which products are available");
            var data = bal.GetCategories();
            foreach (KeyValuePair<int, string> d in data)
                Console.WriteLine(d.Key + ".\t" + d.Value);
                Console.WriteLine("Enter Category Name");
                string cname = Console.ReadLine();
                var r = bal.SearchProductByCategory(cname);
                string op = string.Format("{0,10}{1,20}{2,40}{3,15}{4,30}", "ID", "Name", "Description", "Price", "Category Name");

                Console.WriteLine(op);


                foreach (var o in r)
                {
                    Console.WriteLine("{0,10}{1,20}{2,40}{3,15}{4,30}",
                        o.ProdId, o.ProductName, o.Description, o.Price, o.CatName);
                }
            }
         catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
}
        private void ModifyProduct()
        {
            try
            {
                Console.WriteLine("Enter Product Name");
                string pname = Console.ReadLine();
                Console.WriteLine("Product Description:"+bal.GetProdDescription(pname));
                Console.WriteLine("Enter New Description");
                string pdesc = Console.ReadLine();
                var res = bal.ModifyProduct(pname, pdesc);
                if (res)
                {
                    Console.WriteLine("Product details Modified");
                    GetProducts();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }


        private void DeleteProduct() {
            try
            { 
            Console.WriteLine("Enter ProductName");
            string pname = Console.ReadLine();
                Console.WriteLine("Product Description:" + bal.GetProdDescription(pname));
                Console.WriteLine("Do You Want to Delete Product Y/N");
                char ans = char.Parse(Console.ReadLine());
                if (ans == 'Y'||ans=='y')
                {
                    var res = bal.DeleteProduct(pname);

                    if (res)
                    {
                        Console.WriteLine("Product Details Deleted");
                        GetProducts();
                    }

                }

                }
                 catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       private void  AddSubCategory()
        {
            try
            {
                SubCategoryEntity sbe = new SubCategoryEntity();
                Console.WriteLine("Enter Sub Category Name");
                sbe.SubCategoryName = Console.ReadLine();
                var res = bal.GetCategories();
                foreach (KeyValuePair<int, string> kvp in res)
                    Console.WriteLine(kvp.Key + ".\t" + kvp.Value);
                Console.WriteLine("Enter Category ID ");
                sbe.CatID = int.Parse(Console.ReadLine());
                var add = bal.AddSubCategory(sbe);
                if(add)
                {
                    Console.WriteLine("Sub Category Added Successfully");
                    var scat = bal.ViewSubCategories();
                    Console.WriteLine("{0,10}{1,20}{2,20}","ID","SubCategory Name","CategoryName");
                    foreach (var s in scat)
                        Console.WriteLine("{0,10}{1,20}{2,20}",s.SubCatID , s.SubCategoryName , s.CatName);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
            private void ViewSubCategory()
        {
            var scat = bal.ViewSubCategories();
            Console.WriteLine("{0,10}{1,20}{2,20}", "ID", "SubCategory Name", "CategoryName");
            foreach (var s in scat)
                Console.WriteLine("{0,10}{1,20}{2,20}", s.SubCatID, s.SubCategoryName, s.CatName);
        }
            private void DeleteSubCategory()
        {
            try
            {
                Console.WriteLine("Enter Sub Category Name");
               string scname = Console.ReadLine();
                var res = bal.DeleteSubCategory(scname);
                if(res)
                {
                    Console.WriteLine("Sub Category Deleted Successfully");
                    var scat = bal.ViewSubCategories();
                    Console.WriteLine("{0,10}{1,20}{2,20}", "ID", "SubCategory Name", "CategoryName");
                    foreach (var s in scat)
                        Console.WriteLine("{0,10}{1,20}{2,20}", s.SubCatID, s.SubCategoryName, s.CatName);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void GetProducts()
        {
            var r = bal.GetProducts();
            string op = string.Format("{0,10}{1,15}{2,25}{3,15}{4,15}{5,20}{6,15}", "ID", "Name", "Description", "Price", "Discount", "Category Name", "Image");

            Console.WriteLine(op);


            foreach (var o in r)
            {
                Console.WriteLine("{0,10}{1,15}{2,25}{3,15}{4,15}{5,12}{6,25}",
                    o.ProdId, o.ProductName, o.Description, o.Price, o.Discount, o.CatName, o.Image);
            }
        }
    }
}

