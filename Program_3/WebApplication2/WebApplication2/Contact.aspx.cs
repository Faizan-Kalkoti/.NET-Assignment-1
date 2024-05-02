using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            string query = "SELECT Id, City, Temperature, CurrentDate FROM WeatherData";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

            string txtsval = txtsearch.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            string query = "SELECT Id, City, Temperature, CurrentDate FROM WeatherData where City like @textvalue";
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@textvalue", txtsval + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
            }
        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //Get row index
            int rowIndex = e.RowIndex;
            // Get the GridViewRow corresponding to the index
            GridViewRow row = GridView1.Rows[rowIndex];
            string columnValue = row.Cells[0].Text;

            int delete_id = 0;
            if (!int.TryParse(columnValue, out delete_id))
            {
                // Handle invalid temperature input
                MessageLabel.Text = "Wrong format! - "+ columnValue.ToString();
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"DELETE FROM WeatherData WHERE Id = @ValueToDelete";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ValueToDelete", delete_id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected>0)
                    {
                        MessageLabel.Text = "Number of Rows affected are: "+rowsAffected.ToString();
                    }
                }
            }
            BindGridView();
        }



        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                string columnValue = row.Cells[0].Text;

                int id = 0;
                if (!int.TryParse(columnValue, out id))
                {
                    // Handle invalid temperature input
                    MessageLabel.Text = "Wrong format! - " + columnValue.ToString();
                    return;
                }

                // Retrieve data from the BoundFields using their respective column index
                string city = ((TextBox)row.Cells[1].Controls[0]).Text; // Assuming City is the first column
                string temperature = ((TextBox)row.Cells[2].Controls[0]).Text; // Assuming Temperature is the second column
                string date = ((TextBox)row.Cells[3].Controls[0]).Text;

                DateTime dt = DateTime.Today;
                decimal temp = 0;

                if (temperature != "")
                {
                    if (!string.IsNullOrWhiteSpace(temperature))
                    {
                        temp = 0;
                        if (!decimal.TryParse(temperature, out temp))
                        {
                            // Handle invalid temperature input
                            MessageLabel.Text = "Wrong Temperature format";
                            return;
                        }
                    }
                }
                else
                {
                    MessageLabel.Text = "No input given!";
                    return;
                }

                if (!string.IsNullOrWhiteSpace(date))
                {
                    if (!DateTime.TryParse(date, out dt))
                    {
                        // Handle invalid date input
                        MessageLabel.Text = "Wrong Date format";
                        return;
                    }
                }

                string query = "Update WeatherData set City=@city1, Temperature=@temp1, CurrentDate=@currdate1 where id=@ID1";
                string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@temp1", temp);
                        command.Parameters.AddWithValue("@currdate1", dt);
                        command.Parameters.AddWithValue("@city1", city);
                        command.Parameters.AddWithValue("@ID1", id);
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageLabel.Text = "Selected Record Updated!";

                    }
                }

                GridView1.EditIndex = -1;
                BindGridView();

            }
            catch(Exception ex)
            {
                MessageLabel.Text = ex.ToString();
            }
        } //update function ended




        protected void GridView1_RowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }
    }
}