using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailEntity;
using HappyRetailDataAccessLayer;
namespace HappyRetailBusinessAccessLayer
{
    public class LoginBAL
    {
        LoginDAL dal = new LoginDAL();
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        } //this function is to Encode Password and send to DB Table
      
        public bool AddNewUser(UserInfoEntity uie)
        {
            if (string.IsNullOrEmpty(uie.Name) || string.IsNullOrWhiteSpace(uie.Name))
                throw new Exception("Name cannot be blank or empty");
            if (string.IsNullOrWhiteSpace(uie.Address) || string.IsNullOrWhiteSpace(uie.Address))
                throw new Exception("Address cannot be blank or empty");
            if (uie.MobNo <= 0)
                throw new Exception("Mobile Number cannot be zero or negative");
            if (uie.MobNo.ToString().Length < 10)
                throw new Exception("Mobile Number has to be 10 digits");
            if (string.IsNullOrWhiteSpace(uie.EmailID) || string.IsNullOrWhiteSpace(uie.EmailID))
                throw new Exception("EmailID cannot be blank or empty");
            if (string.IsNullOrWhiteSpace(uie.Password) || string.IsNullOrWhiteSpace(uie.Password))
                throw new Exception("Password cannot be blank or empty");
            if (uie.Password.Length >= 4 && uie.Password.Length <= 10)
                uie.Password=EncodePasswordToBase64(uie.Password);
            else
                throw new Exception("Password length has to be between 5 to 10 characters");
            return dal.AddNewUser(uie);

        }
        public string Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(username))
                throw new Exception("UserName cannot be blank or empty");
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Password cannot be blank or empty");
            else
                password = EncodePasswordToBase64(password);
               return dal.Authenticate(username, password);
        }
        public Dictionary<int,string> GetRoles()
        {
            return dal.GetRoles();
        }
    }
}
