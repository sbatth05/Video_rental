using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_rental_01.Models
{
    public class VideoEntries
    {
        Database instance = new Database();
     
        //user define method that is used to pass the values to database table 
        public void Insert(String qury) {
            //passing the value to table by calling the method from the database class
            instance.SqlQuery(qury);
        }

        //user define method that is used to pass the values to database table 
        public void Delete(int ID)
        {
            //this method is used to delete the video entry from the database 

            //passing the value to table by calling the method from the database class
            instance.SqlQuery("Delete from Table_Video where V_ID=" + ID+"");

        }


        
        //user define method that is used to pass the values to database table 
        public void Update(String qury)
        {
            //concept to update the record of the file 
            //passing the value to table by calling the method from the database class
            instance.SqlQuery(qury);
        }

        //get the all record from the VideoTable to display the details 
        public DataTable Video_Record() {
            DataTable obj = new DataTable();
            // passing the query to the table 
            obj = instance.srchRecord("select * from Table_Video");
            return obj;
        }


        public int getCost(int Vid,int Rid) {

            DateTime new_date = DateTime.Now;


            string query = "select * from Table_Rental where R_ID=" + Rid + "";
            DataTable tbl = new DataTable();
            tbl = instance.srchRecord(query);
            String VideoIssued =tbl.Rows[0]["Issue_Date"].ToString();


            //convert the old date from string to Date fromat
            DateTime prev_date = Convert.ToDateTime(VideoIssued);


            //get the difference in the days fromat
            String Daysdiff = (new_date - prev_date).TotalDays.ToString();


            // calculate the round off value 
            Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));


            string query1 = "select * from Table_Video where V_ID=" + Vid + "";
            DataTable tbl1 = new DataTable();
            tbl1 = instance.srchRecord(query1);
            int cost= Convert.ToInt32(tbl1.Rows[0]["V_Cost"]);




            int Price = Convert.ToInt32(DaysInterval) * cost;



            return Price;

        }

        public String TopMovie() {

            DataTable tblData = new DataTable();
            tblData = instance.srchRecord("select * from Table_Video ");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = instance.srchRecord("select * from Table_Rental where V_ID=" + Convert.ToInt32(tblData.Rows[x]["V_ID"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["V_Title"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }
            

            return Title;
        }

    }
}
