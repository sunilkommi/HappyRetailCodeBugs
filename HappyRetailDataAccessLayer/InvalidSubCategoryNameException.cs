using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyRetailDataAccessLayer
{
    public class InvalidSubCategoryNameException:ApplicationException
    {
        string msg;
        public InvalidSubCategoryNameException()
        {
            msg = "Invalid Sub Category Name. It does not Exist";
        }
        public override string Message
        {
            get
            {
                return msg;
            }
        }
    }
}
