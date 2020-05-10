using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_rental_01.Models
{
    public class CustomerEntries
    {

        Database instance = new Database();

        //user define method that is used to pass the values to database table 
        public void Insert(String qury)
        {
            //passing the value to table by calling the method from the database class
            instance.SqlQuery(qury);
        }

        //user define method that is used to pass the values to database table 
        public void Delete(int ID)
        {
            //this method is used to delete the customer entry from the database 

            //passing the value to table by calling the method from the database class
            instance.SqlQuery("Delete from Table_Customer where C_ID=" + ID + "");

        }



        //user define method that is used to pass the values to database table 
        public void Update(String qury)
        {
            //concept to update the record of the file 
            //passing the value to table by calling the method from the database class
            instance.SqlQuery(qury);
        }

        //get the all record from the VideoTable to display the details 
        public DataTable Customer_Record()
        {
            DataTable obj = new DataTable();
            // passing the query to the table 
            obj = instance.srchRecord("select * from Table_Customer");
            return obj;
        }


        public String TopCustomer() {

            DataTable tblData = new DataTable();
            tblData = instance.srchRecord("select * from Table_Customer");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = instance.srchRecord("select * from Table_Rental where C_ID=" + Convert.ToInt32(tblData.Rows[x]["C_ID"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["C_Name"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }

            

            return Title;
        }


    }
}
