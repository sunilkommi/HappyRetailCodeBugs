using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using HappyRetailEntity;
namespace CardValidationWebService
{
    /// <summary>
    /// Summary description for PaymentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PaymentService : System.Web.Services.WebService
    {
        List<CardDetails> cardlist = new List<CardDetails>();
        

     public PaymentService()
        {
            cardlist.Add(new CardDetails { CardNO = 5641820000000005, CVVNo = 123, Month = 1, Year = 2017, Balance = 2000 });
            cardlist.Add(new CardDetails { CardNO = 6331101999990016, CVVNo = 456, Month = 2, Year = 2018, Balance = 12000 });
            cardlist.Add(new CardDetails { CardNO = 6759649826438453, CVVNo = 789, Month = 3, Year = 2019, Balance = 22000 });
            cardlist.Add(new CardDetails { CardNO = 4012888888881881, CVVNo = 101, Month = 4, Year = 2017, Balance = 24000 });
            cardlist.Add(new CardDetails { CardNO = 4462000000000003, CVVNo = 312, Month = 5, Year = 2020, Balance = 28000 });
            cardlist.Add(new CardDetails { CardNO = 4917300000000008, CVVNo = 415, Month = 6, Year = 2021, Balance = 122000 });
            cardlist.Add(new CardDetails { CardNO = 4917300800000000, CVVNo = 617, Month = 6, Year = 2022, Balance = 242000 });
            cardlist.Add(new CardDetails { CardNO = 4484070000001212, CVVNo = 819, Month = 5, Year = 2023, Balance = 502000 });
            cardlist.Add(new CardDetails { CardNO = 4485680502719433, CVVNo = 221, Month = 4, Year = 2024, Balance = 62000 });
            cardlist.Add(new CardDetails { CardNO = 5454545454545454, CVVNo = 331, Month = 3, Year = 2025, Balance = 172000 });
        }
        [WebMethod]
        public bool ValidateCard(long cardno, int cvv, int month, int year, decimal payamt)
        {
            var res = cardlist.Find(x => x.CardNO == cardno && x.CVVNo == cvv);
            if (res == null)
            {
                throw new Exception("Card Details are Invalid");

            }
            else
            {
                if (res.Year < DateTime.Now.Year)
                    throw new Exception("Your Card is expired . Cannot process");
               else  if ((res.Month < DateTime.Now.Month && res.Year == DateTime.Now.Year))
                    throw new Exception("Your Card is expired.Cannot Process");
                if (res.Balance < payamt)
                    throw new Exception("Insufficient Balance to process your order");

            }
            return true;
               

            }
        }
    }

