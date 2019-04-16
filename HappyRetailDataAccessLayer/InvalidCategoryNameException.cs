using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyRetailDataAccessLayer
{
   public  class InvalidCategoryNameException:ApplicationException
    {
        string msg;
        public InvalidCategoryNameException()
        {
            msg = "Invalid Category Name.It Does not exist";
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
