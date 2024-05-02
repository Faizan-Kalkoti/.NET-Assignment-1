using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string city = txtCity.SelectedValue; ;
            if (txtCity.SelectedValue == "")
            {
                Messagelabel.Text = "Enter City!";
                return;
            }          
            decimal temperature = 0;
            DateTime currentDate = DateTime.Today;

            if(txtTemperature.Text != "")
            {
            if (!string.IsNullOrWhiteSpace(txtTemperature.Text))
            {
                decimal temp = 0;
                if (!decimal.TryParse(txtTemperature.Text, out temp))
                {
                    // Handle invalid temperature input
                    Messagelabel.Text = "Wrong Temperature format";
                    return;
                }
                temperature = temp;
            }
            }
            else
            {
                Messagelabel.Text = "No input given!";
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtDate.Text))
            {
                DateTime date;
                if (!DateTime.TryParse(txtDate.Text, out date))
                {
                    // Handle invalid date input
                    Messagelabel.Text = "Wrong Date format";
                    return;
                }
                currentDate = date;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("PRC_InsertTemperature", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@city1", city);
                    command.Parameters.AddWithValue("@temperature1", temperature);
                    if (txtDate.Text != "")
                    {
                    command.Parameters.AddWithValue("@currentdate1", currentDate);
                    }
                   

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    Messagelabel.Text =" Data successfully added!" ;

                }
            }
            catch (Exception ex)
            {
                Messagelabel.Text = "An error occurred: " + ex.Message;
            }
        }

    }
}