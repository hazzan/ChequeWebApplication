using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChequeClient.Models
{
    public class ChequeDetails
    {
        public IList<SelectListItem> ListOfMenu { get; set; }
        public List<SelectListItem> SelectedMenuItem { get; set; } 
        public string SelectedItem { get; set; }
        public string Status { get; set; }
    }
}