using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChequeConsumer;
using ChequeClient.Models;
using ChequeConsumer.Dtos;

namespace ChequeClient.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ChequeDetails cheque = new ChequeDetails();
            List<SelectListItem> menuSelectList = new List<SelectListItem>();
            var listMenuItem = MenuItemConsumer.loadMenuItem();
            foreach (MenuItemDto item in listMenuItem)
            {
                SelectListItem menuItem = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.MenuName,
                    Selected = false
                };
                menuSelectList.Add(menuItem);
            }
           // string status = MenuItemConsumer.InsertChequeInformation(6);

            cheque.ListOfMenu = menuSelectList ?? new List<SelectListItem>();
            cheque.SelectedMenuItem = new List<SelectListItem>();
                        
            return View(cheque);
        }

        public ActionResult SaveBillingInformation(List<BillingDetails> listBillingDetails)
        {
            List<BillingInformationDto> listBillingInfo = new List<BillingInformationDto>();

            foreach (BillingDetails item in listBillingDetails)
            {
                BillingInformationDto billingInfo = new BillingInformationDto()
                {
                    Id = item.Id,
                    MenuID = item.MenuID,
                    Price = item.Price,
                    Category = item.Category
                };

                listBillingInfo.Add(billingInfo);
            }


          //  string status = MenuItemConsumer.InsertChequeInformation(listBillingInfo);
            return View();
        }

       

    }
}
