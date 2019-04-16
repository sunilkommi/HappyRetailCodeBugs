using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyRetailEntity
{
    public class SubCategoryEntity
    {
        public int SubCatID
        {
            get;
            set;
        }
        public string SubCategoryName
        {
            get;
            set;
        }
        public int CatID
        {
            get;
            set;
        }
        public string CatName
        {
            get;
            set;
        }
    }
}
