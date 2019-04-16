using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardValidationWebService
{
    public class CardDetails
    {
        public long CardNO
        {
            get;
            set;
        }
        public int CVVNo
        {
            get;
            set;
        }
        public int Month
        {
            get;
            set;
        }
        public int Year
        {
            get;
            set;

        }
        public decimal Balance
        {
            get;
            set;
        }

    }
}