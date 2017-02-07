using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeBusinessData.Entity;
using ChequeBusinessData.Connection;
using System.Data.SqlClient;
using System.Data;

namespace ChequeBusinessData
{
    public static class ChequeInformation
    {
        public static IList<MenuItem> loadMenuItem()
        {
            using (SqlConnection connt = new SqlConnection(ConnectionStirng.Connection()))
            {
                connt.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.tblMENU", connt))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IList<MenuItem> lstMenuItem = new List<MenuItem>();
                    while (reader.Read())
                    {
                        MenuItem menuItem = new MenuItem();
                        menuItem.Id = reader.GetInt64(0);
                        menuItem.MenuName = reader.GetString(1);
                        menuItem.MenuDescription = reader.GetString(2);
                        menuItem.Category = reader.GetString(3);
                        lstMenuItem.Add(menuItem);
                    }

                    return lstMenuItem;
                }
            }
        }

        public static string saveBillingItem(BillingInformation billingInformation) 
        {
            using (SqlConnection connt = new SqlConnection(ConnectionStirng.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "insertNewUser";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connt;

                    cmd.Parameters.AddWithValue("@MenuID", billingInformation.MenuID);
                    cmd.Parameters.AddWithValue("@Price", billingInformation.Price);
                    cmd.Parameters.AddWithValue("@Category", billingInformation.Category);
                    connt.Open();
                    cmd.ExecuteNonQuery();
                } connt.Close();
            }
            return "success";
        }
    }
}
