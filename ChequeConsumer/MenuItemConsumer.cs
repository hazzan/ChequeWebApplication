using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using ChequeConsumer.Dtos;
using ChequeBusinessData.Entity;
using System.Web.Script.Serialization;

namespace ChequeConsumer
{
    public static class MenuItemConsumer
    {
        public static List<MenuItemDto> loadMenuItem()
        {
            WebClient RESTProxy = new WebClient();
            string jsonData = RESTProxy.DownloadString(new Uri("http://localhost:59525/RESTChequeService.svc/REST/MenuItem"));
            jsonData = jsonData.Replace(@"\", "");
            jsonData = jsonData.Substring(0, jsonData.Length - 2);
            if (jsonData.Length > 19 )
            {
                jsonData = jsonData.Substring(19, jsonData.Length - 19);    
            }
            List<MenuItemDto> deserializedMenuItem = new List<MenuItemDto>();
            var serializer = new JavaScriptSerializer();
            var objMenuItem = serializer.Deserialize<List<MenuItemDto>>(jsonData);
            return objMenuItem; 
        }

        public static string InsertChequeInformation(int listBilling) 
        {

            ChequeRESTService.RESTChequeServiceClient objRestChequeService = new ChequeRESTService.RESTChequeServiceClient("WSHttpBinding_Service");
            //List<BillingInformation> listBillingInfo = new List<BillingInformation>();

            //foreach (BillingInformationDto item in listBilling)
            //{
            //    BillingInformation billingInfo = new BillingInformation()
            //    {
            //        Id = item.Id,
            //        MenuID = item.MenuID,
            //        Price = item.Price,
            //        Category = item.Category
            //    };

            //    listBillingInfo.Add(billingInfo);
            //}
            objRestChequeService.SaveMenuItem(1);
            return string.Empty;
        }
    }
}
