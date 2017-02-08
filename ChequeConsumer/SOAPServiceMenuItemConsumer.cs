using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using ChequeConsumer.Dtos;
using System.Xml.Serialization;

namespace ChequeConsumer
{
    public static class SOAPServiceMenuItemConsumer
    {
        public static List<MenuItemDto> LoadMenuItemUsingSoapService()
        {
            SoapWebService.ChequeSOAPServiceSoapClient SoapService = new SoapWebService.ChequeSOAPServiceSoapClient();
            string menuItemXML = SoapService.GetAllMenuItems();
            XmlReader reader = XmlReader.Create(new StringReader(menuItemXML));
            XmlSerializer serializer = new XmlSerializer(typeof(List<MenuItemDto>));
            List<MenuItemDto> menuList = (List<MenuItemDto>)serializer.Deserialize(reader);
            return menuList;
        }

    }
}
