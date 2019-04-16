using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyRetailEntity;

namespace HappyRetailDataAccessLayer
{
    public interface ILoginTransaction
    {
        string Authenticate(string username, string password);
        bool AddNewUser(UserInfoEntity uie);
    }
}
