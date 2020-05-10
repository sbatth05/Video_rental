using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_rental_01
{
    public partial class Form1 : Form
    {
        //object of the video entries class
        Models.VideoEntries instance_Video = new Models.VideoEntries();

        //object of the Customer entries class
        Models.CustomerEntries instance_Customer = new Models.CustomerEntries();

        //object of the Rental entries class
        Models.RentalEntries instance_Rental = new Models.RentalEntries();

        int R_ID = 0;
        int customer = 0, movie = 0, rent = 0,copies=0;

        public Form1()
        {
            InitializeComponent();
        }

        private void video_year_TextChanged(object sender, EventArgs e)
        {
            //we have use the concept of the Textchanged event to generate the charges of the cost 
            try
            {

                //dislay the cost of the price of the video after adding the year of the video
                DateTime dateNow = DateTime.Now;

                int Currentyear = dateNow.Year;

                int diffYear = Currentyear - Convert.ToInt32(video_year.Text.ToString());
                // MessageBox.Show(diff.ToString());
                if (diffYear >= 5)
                {
                    video_cost.Text = "2";
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    video_cost.Text = "5";
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void video_add_Click(object sender, EventArgs e)
        {
            //calling  the method of the file 
            if (video_title.Text.ToString().Equals("") && video_ratting.Text.ToString().Equals("") && video_year.Text.ToString().Equals("") && video_cost.Text.ToString().Equals("") && video_copies.Text.ToString().Equals("") && video_plot.Text.ToString().Equals("") && video_genre.Text.ToString().Equals("")) {
                MessageBox.Show(" please fill al the entries to store ");
            }
            else { 
                String query = "insert into Table_Video (V_Title,V_Ratting,V_Year,V_Cost,V_Copies,V_Plot,V_Genre) values ('"+video_title.Text+"','"+video_ratting.Text+"','"+video_year.Text+"',"+Convert.ToInt32(video_cost.Text)+","+ Convert.ToInt32(video_copies.Text) + ",'"+video_plot.Text+"','"+video_genre.Text+"')";
                instance_Video.Insert(query);
                MessageBox.Show("Video is stored in the store ");
                clrAll();
            }

        }

        private void video_delete_Click(object sender, EventArgs e)
        {
            //this code is used to delete the video entry from the file 
            if (pkmovie.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select the movie to delete ");
            }
            else {
                if (instance_Rental.checkRentalMovie(Convert.ToInt32(pkmovie.Text)) == 0)
                {
                    instance_Video.Delete(Convert.ToInt32(pkmovie.Text));
                    MessageBox.Show("Video record is removed ");
                    clrAll();
                }
                else {
                    MessageBox.Show("Video is already issued on rent so can't delete  ");
                }
                
            }
        }

        private void video_update_Click(object sender, EventArgs e)
        {
            if (pkmovie.Text.ToString().Equals("") && video_title.Text.ToString().Equals("") && video_ratting.Text.ToString().Equals("") && video_year.Text.ToString().Equals("") && video_cost.Text.ToString().Equals("") && video_copies.Text.ToString().Equals("") && video_plot.Text.ToString().Equals("") && video_genre.Text.ToString().Equals("")) {

                MessageBox.Show("fill all the entries and select the video to update the record ");
            }
            else{
                String query = "update Table_Video set V_Title='"+video_title.Text+"' , V_Ratting='"+video_ratting.Text+"',V_Year='"+video_year.Text+"', V_Cost="+Convert.ToInt32(video_cost.Text.ToString())+", V_Copies="+ Convert.ToInt32(video_copies.Text.ToString()) + " ,V_Plot='"+video_plot.Text+"',V_Gnre='"+video_genre.Text+"' where V_ID="+ Convert.ToInt32(pkmovie.Text) + "";
                instance_Video.Update(query);
                MessageBox.Show("Video is Updated  in the store ");
                clrAll();
            }


        }

        private void customer_add_Click(object sender, EventArgs e)
        {
            if (customer_name.Text.ToString().Equals("") && customer_contact.Text.ToString().Equals("") && customer_address.Text.ToString().Equals(""))
            {
                MessageBox.Show("Fill all the Cutomer Details ");
            }
            else {
                String query = "insert into Table_Customer(C_Name,C_Contact,C_Address) values ('"+customer_name.Text+"','"+customer_contact.Text+"','"+customer_address.Text+"')";
                instance_Customer.Insert(query);
                MessageBox.Show("Customer Record is saved");
                clrAll();
            }
        }

        private void customer_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_delete_Click(object sender, EventArgs e)
        {
            if (pkcustomer.Text.ToString().Equals(""))
            {
                MessageBox.Show("select the customer to delete ");
            }
            else {
                //this code is used to check the customer has how much video on rent if he return all then we cn deelte 
                if (instance_Rental.checkCustomerMovie(Convert.ToInt32(pkcustomer.Text.ToString())) == 0)
                {
                    instance_Customer.Delete(Convert.ToInt32(pkcustomer.Text.ToString()));
                    MessageBox.Show(" customer record is  deleted ");
                    clrAll();
                }
                else {
                    MessageBox.Show("customer has only one video on rent ");
                }
            }
        }

        private void customer_update_Click(object sender, EventArgs e)
        {
            if (pkcustomer.Text.ToString().Equals("") && customer_name.Text.ToString().Equals("") && customer_contact.Text.ToString().Equals("") && customer_address.Text.ToString().Equals(""))
            {
                MessageBox.Show("select all fill all the details to update ");
            }
            else {
                String query="update Table_Customer set C_Name='"+customer_name.Text+"',C_Contact='"+customer_contact.Text +"', C_Address='"+customer_address.Text+"' where C_ID="+Convert.ToInt32(pkcustomer.Text)+"";
                instance_Customer.Update(query);
                MessageBox.Show("record is updated ");
                clrAll();
            }
        }

        private void rental_issue_Click(object sender, EventArgs e)
        {
            //this code is used to pass the value to the rental and issue the video on rent 
            if (pkcustomer.Text.ToString().Equals("") && pkmovie.Text.ToString().Equals(""))
            {
                MessageBox.Show("select the video and customer to issue ");
            }
            else {
                //check the customer how much video he has on rent 
                if (instance_Rental.checkCustomerMovie(Convert.ToInt32(pkcustomer.Text.ToString())) == 2)
                {
                    MessageBox.Show("You already has 2 video on rent so can get more ");
                }else{
                    if (instance_Rental.checkRentalMovie(Convert.ToInt32(pkmovie.Text.ToString())) < copies)
                    {
                        //insert the record in the table 
                        String query = "insert into table_Rental(C_ID,V_ID,Issue_Date,Return_Date) values (" + Convert.ToInt32(pkcustomer.Text.ToString()) + "," + Convert.ToInt32(pkmovie.Text.ToString()) + ",'" + dtpIssue.Text + "','issue')";
                        instance_Rental.Insert(query);
                        MessageBox.Show("video is issued on rent ");
                        clrAll();
                    }
                    else {
                        MessageBox.Show("ALl video is on rent already ");
                    }
                }
            }
        }

        private void rental_delete_Click(object sender, EventArgs e)
        {
            if (R_ID>0) {

                instance_Rental.Delete(R_ID);
                MessageBox.Show("Video is delete ");
                clrAll();
            }
            else {
                MessageBox.Show("select the video rental movie to delete it ");
            }
        }

        private void rental_record_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();

            tbl = instance_Rental.Rental_Record();
            dataGridView1.DataSource = tbl;
            rent = 1;
            customer = 0;
            movie = 0;


        }

        //method to reset the form again 
        public void clrAll() {
            video_title.Text = "";
            video_ratting.Text = "";
            video_year.Text = "";
            video_cost.Text = "";
            video_copies.Text = "";
            video_plot.Text = "";
            video_genre.Text = "";

            customer_name.Text = "";
            customer_address.Text = "";
            customer_contact.Text = "";

            pkcustomer.Text = "";
            pkmovie.Text = "";

            R_ID = 0;
            customer = 0;
            rent = 0;
            movie = 0;


        }
        private void video_record_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();

            tbl = instance_Video.Video_Record();
            dataGridView1.DataSource = tbl;
            movie= 1;
            customer = 0;
            rent = 0;

        }

        private void rattingCustomer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Top Customer Name is ==" + instance_Customer.TopCustomer());

        }

        private void rattingMovie_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Top Ratting Video Movie Title is ==" + instance_Video.TopMovie());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customer==1) {
                pkcustomer.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString(); 
                customer_name.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                customer_contact.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                customer_address.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                
            }

            if (rent==1) {

                R_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                pkcustomer.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                pkmovie.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                dtpIssue.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }


            if (movie==1) {
                pkmovie.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                video_title.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                video_ratting.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                video_year.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
                video_cost.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
                video_copies.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
                copies = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                video_plot.Text= dataGridView1.CurrentRow.Cells[6].Value.ToString();
                video_genre.Text= dataGridView1.CurrentRow.Cells[7].Value.ToString();

            }

            customer = 0;
            movie = 0;
            rent = 0;

        }

        private void return_issue_Click(object sender, EventArgs e)
        {
            if (R_ID == 0 && pkcustomer.Text.ToString().Equals("") && pkmovie.Text.ToString().Equals(""))
            {
                MessageBox.Show("Select The movie to return to store ");
            }
            else {

                String query = "update Table_Rental set C_ID="+Convert.ToString(pkcustomer.Text.ToString())+", V_ID="+Convert.ToInt32(pkmovie.Text.ToString())+", Issue_Date='"+dtpIssue.Text+"',Return_Date='"+dtpReturn.Text+"' where R_ID="+R_ID+"";
                instance_Rental.Update(query);
                int charges = instance_Video.getCost(Convert.ToInt32(pkmovie.Text.ToString()),R_ID);
                MessageBox.Show("Rental Movie is Returned and charges to pay ="+charges);
                clrAll();
            }


        }

        private void customer_record_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();

            tbl = instance_Customer.Customer_Record();
            dataGridView1.DataSource = tbl;
            customer = 1;

            rent = 0;
            movie = 0;

        }
    }
}
