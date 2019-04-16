using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailEntity;
using System.Data.Common;
using System.Data;
namespace HappyRetailDataAccessLayer
{
    public class LoginDAL : ConnectDB, ILoginTransaction
    {
        public static int UID = 0;
        IDbConnection con = null;
        IDbCommand com = null;
        IDataReader r = null;
        public LoginDAL()
        {
            con = GetConnection();
        }
        public bool AddNewUser(UserInfoEntity uie)
        {
            bool result = false;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = "insert into UserInfoTable values(@name,@address,@mno,@email,@pwd,@rid)";
                com = con.CreateCommand();
                com.CommandText = query;
                IDataParameter nmparam = com.CreateParameter();
                nmparam.ParameterName = "@name";
                nmparam.Value = uie.Name;
                com.Parameters.Add(nmparam);
                IDataParameter addparam = com.CreateParameter();
               addparam.ParameterName = "@address";
               addparam.Value = uie.Address;
                com.Parameters.Add(addparam);
                IDataParameter mnoparam = com.CreateParameter();
                mnoparam.ParameterName = "@mno";
               mnoparam.Value = uie.MobNo;
                com.Parameters.Add(mnoparam);
                IDataParameter emparam = com.CreateParameter();
                emparam.ParameterName = "@email";
                emparam.Value = uie.EmailID;
                com.Parameters.Add(emparam);
                IDataParameter passparam = com.CreateParameter();
               passparam.ParameterName = "@pwd";
                passparam.Value = uie.Password;
                com.Parameters.Add(passparam);
                IDataParameter ridparam = com.CreateParameter();
                ridparam.ParameterName = "@rid";
                ridparam.Value = uie.RoleID;
                com.Parameters.Add(ridparam);
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
       

        public string Authenticate(string username, string password)
        {
            string roleType = string.Empty;
            int userid = 0;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string query = "select id,roleid from userinfotable where name=@uname and password=@pass";
                com = con.CreateCommand();
                com.CommandText = query;
                IDataParameter usrparam = com.CreateParameter();
                usrparam.ParameterName = "@uname";
                usrparam.Value = username;
                com.Parameters.Add(usrparam);
                IDataParameter pwdparam = com.CreateParameter();
                pwdparam.ParameterName = "@pass";
                pwdparam.Value = password;
                com.Parameters.Add(pwdparam);
                r = com.ExecuteReader();
                if(r.Read())
                {
                    userid = Convert.ToInt32(r[0]);
                    UID = userid;
                    int roleid = Convert.ToInt32(r[1]);
                    com = con.CreateCommand();
                    com.CommandText = "select rolename from RoleTable where roleid=@rid";
                    IDataParameter rid = com.CreateParameter();
                    rid.ParameterName = "@rid";
                    rid.Value = roleid;
                    com.Parameters.Add(rid);
                    var res = com.ExecuteScalar();
                    roleType = res.ToString();
                }
                else

                {
                    throw new Exception("Invalid UserName/Password");
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
            return roleType;
            
        }
        public Dictionary<int,string> GetRoles()
        {
            Dictionary<int, string> roles = new Dictionary<int, string>();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                IDbCommand com = con.CreateCommand();
                string query = "select * from RoleTable";
                com.CommandText = query;
                r = com.ExecuteReader();
                while(r.Read())
                {
                    roles.Add(Convert.ToInt32(r[0]), Convert.ToString(r[1]));
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
            return roles;
        }

    }
}
