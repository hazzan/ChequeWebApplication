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
    public class MenuItemConsumer
    {

        readonly string customerServiceUri = "http://localhost:59525/RESTChequeService.svc";
        public List<MenuItemDto> LoadMenuItem() 
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

        public string InsertChequeInformation(List<BillingInformationDto> listBillingDto)  
        {
            List<BillingInformation> listBilling = new List<BillingInformation>();
            try
            {
                foreach (var item in listBillingDto)
                {
                    BillingInformation billInfo = new BillingInformation()
                    {
                        Id = item.Id,
                        MenuID = item.MenuID,
                        Category = item.Category,
                        Price = item.Price
                    };

                    listBilling.Add(billInfo);
                }

                using (WebClient wc = new WebClient())
                {

                    MemoryStream ms = new MemoryStream();
                    DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(List<BillingInformation>));
                    serializerToUplaod.WriteObject(ms, listBilling);
                    wc.Headers["Content-type"] = "application/json";
                    wc.UploadData(customerServiceUri + "SaveMenuItem", "POST", ms.ToArray());
                }
            
            }
            catch (Exception)
            {
                
                throw;
            }
            return string.Empty;
        }
    }
}
