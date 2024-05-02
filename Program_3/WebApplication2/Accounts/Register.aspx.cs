using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2.Accounts
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username1 = username.Value.Trim();
            string password1 = password.Value.Trim();
            string confirmPassword1 = confirmPassword.Value.Trim();

            if (password1 != confirmPassword1)
            {
                // Passwords do not match
                // Display error message
                lblError.Text = "Passwords do not match.";
                lblError.Visible = true;
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("usp_HashAndStorePassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.Add("@Username", SqlDbType.NVarChar, 100).Value = username1;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password1;

                        SqlParameter retvalParam = new SqlParameter("@RETVAL", SqlDbType.VarChar, 15);
                        retvalParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(retvalParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        string retval = command.Parameters["@RETVAL"].Value.ToString();
                        lblError.Text = retval;

                        connection.Close();
                    }
                }
                Response.Redirect("~/Accounts/Login.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
                Console.WriteLine(ex.Message.ToString());
            }
        } //end of the method




    }
}