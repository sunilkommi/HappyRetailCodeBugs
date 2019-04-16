using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailConsoleUI.LoginModule;
using HappyRetailEntity;
using HappyRetailBusinessAccessLayer;
namespace HappyRetailConsoleUI.UserModule
{
   public class UserMenu
    {
        LoginMenu lm = new LoginMenu();
        UserBAL ubal = new UserBAL();
        AdminBAL abal = new AdminBAL();
        public void MenuUser()
        {
            
                int ch = 0;
                lm.PrintStars();
                Console.WriteLine("User Menu");
                lm.PrintStars();
                Console.WriteLine("1.Search Product");
                Console.WriteLine("2.Add Product to Shopping Cart");
                Console.WriteLine("3.Make Payment");
                Console.WriteLine("4.Provide Comments for Product");
                Console.WriteLine("5.Back");
                lm.PrintStars();
                Console.WriteLine("Enter Choice for User Operation");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        SearchProduct();
                        break;
                    case 2:
                        AddCart();
                        break;
                    case 3:
                        MakePayment();
                        break;
                    case 4:
                        ProvideComments();
                        break;
                    case 5:
                        Console.Clear();
                        lm.Login();
                        break;
                    default:
                        lm.PrintStars();
                        Console.WriteLine("Invalid Choice");
                        lm.PrintStars();
                        break;
                }
               
                 
        }
        private void SearchProduct()
        {
            char ans = 'Y';
            while (ans == 'Y' || ans == 'y')
            {
                int ch;
                Console.WriteLine("1.Search Product");
                Console.WriteLine("\t1.Search Product based on Sub Categories");
                Console.WriteLine("\t2.Search Product based on Categories");
                Console.WriteLine("\t3.Back");
                Console.WriteLine("Enter Choice for User Search Operation");
                ch = int.Parse(Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        SearchSubCategory();
                        break;
                    case 2:
                        SearchCategory();
                        break;
                    case 3:Console.Clear();
                        MenuUser();
                        break;
                }
                Console.WriteLine("Do You Want to Continue(Y/N)?");
                ans = char.Parse(Console.ReadLine());
            }


        }
        private void AddCart()
        {
            CartTableEntity ce = new CartTableEntity();
            try
            {
                var lst=abal.GetProducts();
                Console.WriteLine("{0,10}{1,20}{2,20}{3,20}", "ID", "Product Name", "Price", "Discount");
                foreach(var l in lst)
                 Console.WriteLine("{0,10}{1,20}{2,20}{3,20}", l.ProdId, l.ProductName, l.Price, l.Discount);
                Console.WriteLine("Enter ProductID");
                ce.ProdID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Quantity");
                ce.Quantity = int.Parse(Console.ReadLine());
                var res = ubal.AddCart(ce);
                if (res)
                    Console.WriteLine("Product Added to Cart Successfully");
                Console.WriteLine("Do You Want to Continue(Y/N)?");
                char ans = char.Parse(Console.ReadLine());
                if((ans=='Y')||(ans=='y'))
                {
                    MenuUser();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void MakePayment()
        {
            try
            {
              
                Console.WriteLine("Enter CardNumber");
                long cardno = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter CVV No");
                int cvv= int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Month");
               int mon= int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Year");
               int yr = int.Parse(Console.ReadLine());
                var res = ubal.MakePayment(cardno,cvv,mon,yr);
                if (res)
                    Console.WriteLine("Payment Successful");
                Console.WriteLine("Do You Want to Continue(Y/N)?");
                char ans = char.Parse(Console.ReadLine());
                if ((ans == 'Y') || (ans == 'y'))
                {
                    MenuUser();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void ProvideComments()
        {
            UserCommentsEntity uce = new UserCommentsEntity();

                try
                {
                    var lst = abal.GetProducts();
                    Console.WriteLine("{0,10}{1,20}{2,20}{3,20}", "ID", "Product Name", "Price", "Discount");
                    foreach (var l in lst)
                        Console.WriteLine("{0,10}{1,20}{2,20}{3,20}", l.ProdId, l.ProductName, l.Price, l.Discount);
                Console.WriteLine("Enter Product ID");
                uce.ProdID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Comment on Product");
                uce.CommentDescription = Console.ReadLine();
                var res = ubal.AddCommentByProduct(uce);
                if (res)
                    Console.WriteLine("User Comment on Product is Added Successfully");
                Console.WriteLine("Do You Want to Continue(Y/N)?");
                char ans = char.Parse(Console.ReadLine());
                if ((ans == 'Y') || (ans == 'y'))
                {
                    MenuUser();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //BUG - US-ORMS-4
        // Search Product based on category
        //Product Details are not getting displayed.
        private void SearchCategory()
        {
            var res = abal.GetCategories();
            Console.WriteLine(string.Format("{0,10}{1,20}", "ID", "Category Name"));
            foreach(var o in res)
            {
                Console.WriteLine(string.Format("{0,10}{1,20}", o.Key, o.Value));
                
            }
            Console.WriteLine("Enter Category Name");
            string cname = Console.ReadLine();
            var op = ubal.SearchProductByCategory(cname);
           
        }
        private void SearchSubCategory()
        {
            var res = abal.ViewSubCategories();
            Console.WriteLine(string.Format("{0,10}{1,20}{2,20}", "ID", "Sub Category Name","Category Name"));
            foreach (var o in res)
            {
                Console.WriteLine(string.Format("{0,10}{1,20}{2,20}", o.SubCatID,o.SubCategoryName,o.CatName));

            }
            Console.WriteLine("Enter Sub Category Name");
            string scname = Console.ReadLine();
            var op = ubal.SearchProductBySubCategory(scname);
            
            string str = string.Format("{0,10}{1,15}{2,25}{3,15}{4,15}{5,20}{6,20}{7,20}", "ID", "Name", "Description", "Price", "Discount", "Category Name","Sub Category Name","Image");

            Console.WriteLine(str);


            foreach (var o in op)
            {
                Console.WriteLine("{0,10}{1,15}{2,25}{3,15}{4,15}{5,12}{6,25}{7,20}",
                    o.ProdId, o.ProductName, o.Description, o.Price, o.Discount, o.CatName,o.SubCatName, o.Image);
            }
        }

    }
}
