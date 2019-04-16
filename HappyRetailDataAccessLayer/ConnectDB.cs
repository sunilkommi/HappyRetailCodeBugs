using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Configuration;
namespace HappyRetailDataAccessLayer
{
   public abstract class ConnectDB
    {
       
            protected IDbConnection GetConnection()
            {
                string providerName = ConfigurationManager.ConnectionStrings["HappyRetailConnectionString"].ProviderName;
                string connString = ConfigurationManager.ConnectionStrings["HappyRetailConnectionString"].ConnectionString;
                IDbConnection conn = DbProviderFactories.GetFactory(providerName).CreateConnection();
                conn.ConnectionString = connString;
                return conn;
            }
        }
    }

