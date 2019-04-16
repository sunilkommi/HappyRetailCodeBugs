using System;
using System.Collections.Generic;
using HappyRetailBusinessAccessLayer;
using HappyRetailEntity;
namespace HappyRetailConsoleUI.LoginModule
{
    public class LoginMenu
    {
        LoginBAL bal = new LoginBAL();
        string username = string.Empty;
        string password = string.Empty;

        public void PrintStars()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write("*");

        }
        public void Login()
        {
            int ch = 0;
          
            PrintStars();
            string title = "Online Retail";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title);
            PrintStars();
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Add New User");
            Console.WriteLine("3.Exit");
            PrintStars();
            Console.WriteLine("Enter Choice");
            ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1: Authenticate();
                    break;
                case 2: SignUp();
                    break;
                case 3: Environment.Exit(0);
                    break;
            }
        }
    
    private void Authenticate()
    { 
            Console.WriteLine("Login");
            PrintStars();
            try
            {
                Console.WriteLine("Enter Username");
                username = Console.ReadLine();
                Console.WriteLine("Enter Password");
                password = Console.ReadLine();
            
                var result =bal.Authenticate(username, password);
               
                  
                if (result == "Admin")
                {
                    AdminModule.AdminMenu am = new AdminModule.AdminMenu();
                    am.MenuAdmin();
                }
                if(result=="User")
                {
                    UserModule.UserMenu um = new UserModule.UserMenu();
                    um.MenuUser();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SignUp()
        {
            try
            {
                UserInfoEntity uie = new UserInfoEntity();
                Console.WriteLine("Enter Name");
                uie.Name = Console.ReadLine();
                Console.WriteLine("Enter Address");
                uie.Address = Console.ReadLine();
                Console.WriteLine("Enter Mobile Number");
                uie.MobNo = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter Email");
                uie.EmailID = Console.ReadLine();
                Console.WriteLine("Enter Password");
                uie.Password = Console.ReadLine();
                Console.WriteLine("Enter RoleID");
                Dictionary<int, string> res = bal.GetRoles();
                foreach (KeyValuePair<int, string> kvp in res)
                {
                    Console.Write(kvp.Key + "." + kvp.Value);
                    Console.Write("\t");
                }
                uie.RoleID = int.Parse(Console.ReadLine());
                var success = bal.AddNewUser(uie);
                if (success)
                {
                   
                    PrintStars();
                    Console.WriteLine("New User Created Successfully");
                    PrintStars();
                    Console.Clear();
                    Login();
                   
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
