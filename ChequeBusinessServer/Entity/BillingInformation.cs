using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChequeBusinessData.Entity
{
    public class BillingInformation
    {
        public long Id { get; set; }
        public long MenuID { get; set; }
        public decimal Price { get; set; } 
        public string Category { get; set; }
    }
}
