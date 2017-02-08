using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeBusinessData.Entity;

namespace ChequeBusinessData
{
    public class ChequeInformationConsum : IChequeInformationConsum
    {
        public IList<MenuItem> SoapPopulateMenuItem()
        {
            IList<MenuItem> listMenuItem = new List<MenuItem>();
            listMenuItem = ChequeInformation.loadMenuItem();
            return listMenuItem;
        }

        public string SoapSaveBilling(List<MenuItem> menuitem)
        {
            throw new NotImplementedException();
        }

        public IList<MenuItem> RestPopulateMenuItem()
        {
            IList<MenuItem> listMenuItem = new List<MenuItem>();
            listMenuItem = ChequeInformation.loadMenuItem();
            return listMenuItem;
        }

        public string RestSaveBilling(List<BillingInformation> menuitem)
        {
            throw new NotImplementedException();
        }
    }
}
