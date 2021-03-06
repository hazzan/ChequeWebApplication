﻿using System;
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
            return View();
        }

        //
        // GET: /Home/

        public ActionResult RESTBilling() 
        {
            ChequeDetails cheque = new ChequeDetails();
            MenuItemConsumer menuItemConsomer = new MenuItemConsumer();
            List<MenuItems> menuSelectList = new List<MenuItems>();
            var listMenuItem = menuItemConsomer.LoadMenuItem();
            foreach (MenuItemDto item in listMenuItem)
            {
                MenuItems menuItem = new MenuItems()
                {
                    Id = item.Id,
                    MenuName = item.MenuName,
                    MenuDescription = item.MenuDescription,
                    Category = item.Category,
                    Price = item.Price
                };
                menuSelectList.Add(menuItem);
            }
            cheque.ListOfMenu = menuSelectList ?? new List<MenuItems>();
            cheque.InvoiceDate = DateTime.Now.ToString();
            cheque.Invoicenumber = "23-23-2222-22";
            cheque.SelectedMenuItem = new List<MenuItems>();

            return View("Billing", cheque);
        }


        public ActionResult SOAPBilling() 
        {
            ChequeDetails cheque = new ChequeDetails();
            List<MenuItems> menuSelectList = new List<MenuItems>();
            var listMenuItem = SOAPServiceMenuItemConsumer.LoadMenuItemUsingSoapService();
            foreach (MenuItemDto item in listMenuItem)
            {
                MenuItems menuItem = new MenuItems()
                {
                    Id = item.Id,
                    MenuName = item.MenuName,
                    MenuDescription = item.MenuDescription,
                    Category = item.Category,
                    Price = item.Price
                };
                menuSelectList.Add(menuItem);
            }
            cheque.ListOfMenu = menuSelectList ?? new List<MenuItems>();
            cheque.SelectedMenuItem = new List<MenuItems>();

            return View("Billing", cheque);
        }

        public ActionResult SaveBillingInformation(List<BillingDetails> listBillingDetails)
        {
            List<BillingInformationDto> listBillingInfo = new List<BillingInformationDto>();
            MenuItemConsumer menuConsum = new MenuItemConsumer();
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
            menuConsum.InsertChequeInformation(listBillingInfo);

            return View();
        }


       

    }
}
