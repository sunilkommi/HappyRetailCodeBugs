using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyRetailEntity
{
    public class UserCommentsEntity
    {
        public int CommentID
        {
            get;
            set;
        }
        public DateTime CommentDate
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
        public int ProdID
        {
            get;
            set;
        }
        public string CommentDescription
        {
            get;
            set;
        }

    }
}
