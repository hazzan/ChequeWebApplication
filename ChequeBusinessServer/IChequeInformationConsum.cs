using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeBusinessData.Entity;

namespace ChequeBusinessData 
{
    public interface IChequeInformationConsum
    {
        IList<MenuItem> SoapPopulateMenuItem();
        string SoapSaveBilling(List<MenuItem> menuitem);
        IList<MenuItem> RestPopulateMenuItem();
        string RestSaveBilling(List<BillingInformation> menuitem); 
    }
}
