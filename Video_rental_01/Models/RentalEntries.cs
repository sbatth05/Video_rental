using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_rental_01.Models
{
   public class RentalEntries
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
            instance.SqlQuery("Delete from Table_Rental where R_ID=" + ID + "");

        }



        //user define method that is used to pass the values to database table 
        public void Update(String qury)
        {
            //concept to update the record of the file 
            //passing the value to table by calling the method from the database class
            instance.SqlQuery(qury);
        }

        //get the all record from the VideoTable to display the details 
        public DataTable Rental_Record()
        {
            DataTable obj = new DataTable();
            // passing the query to the table 
            obj = instance.srchRecord("select * from Table_Rental");
            return obj;
        }

        //this method is used when we want to delete the video then check is first is it not on issue or not 
        public int checkRentalMovie(int id) {
            string query = "select * from Table_Rental where V_ID="+id+ " and Return_Date='issue'";
            DataTable tbl = new DataTable();
            tbl=instance.srchRecord(query);
            return tbl.Rows.Count;

         }

        //this method is used when we want to delete the cusomer then check is customer has any video on rent 
        public int checkCustomerMovie(int id)
        {
            string query = "select * from Table_Rental where C_ID=" + id + " and Return_Date='issue'";
            DataTable tbl = new DataTable();
            tbl = instance.srchRecord(query);
            return tbl.Rows.Count;

        }



    }
}
