using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyRetailEntity
{
   public  class ProductEntity
    {
        public int ProdId
        {
            get;
            set;
        }
        public string ProductName
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public decimal Discount
        {
            get;
            set;
        }
        public int SubCatID
        {
            get;
            set;
        }
        public string SubCatName
        {
            get;
            set;
        }
        public string CatName
        {
            get;
            set;
        }
        public string Image
        {
            get;
            set;
        }
    }
}
