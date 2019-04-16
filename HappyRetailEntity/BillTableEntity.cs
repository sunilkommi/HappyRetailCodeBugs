using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyRetailEntity
{
   public class BillTableEntity
    {
        public int BillNo
        {
            get;
            set;
        }
        public DateTime BillDate
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        public decimal GrandTotal
        {
            get;
            set;
        }
        public string PaymentMode
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }

    }
}
