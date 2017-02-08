using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChequeClient.Models
{
    public class ChequeDetails
    {
        public IList<MenuItems> ListOfMenu { get; set; }
        public List<MenuItems> SelectedMenuItem { get; set; } 
        public string LeftselectedItem { get; set; }
        public string RightselectedItem { get; set; }
        public string Status { get; set; }
    }
}