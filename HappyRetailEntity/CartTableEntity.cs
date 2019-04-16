using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyRetailEntity
{
 public  class CartTableEntity
    {
        public int SlNo
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        public DateTime OrderDate
        {
            get;
            set;
        }
        public int ProdID
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public decimal TotalAmount
        {
            get;
            set;
        }
    }
}
