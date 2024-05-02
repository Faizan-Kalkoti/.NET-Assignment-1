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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LoggedIn"] = false;
        }




        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username1 = username.Value.Trim();
            string password1 = password.Value.Trim();

            try
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand command = new SqlCommand("usp_RetrieveAndVerifyPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        // Add parameters
                        command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username1;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password1;

                        SqlParameter retvalParam = new SqlParameter("@RETVAL", SqlDbType.VarChar, 15);
                        retvalParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(retvalParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        string retval = command.Parameters["@RETVAL"].Value.ToString();
                        ErrorMessagelabel.Text = retval;

                        if (retval == "Matched!")
                        {
                            Session["LoggedIn"] = true;
                            Session["Username"] = username1.ToString().Trim();
                            ErrorMessagelabel.Text = retval;
                            Response.Redirect("~/Default.aspx");
                        }
                        else
                        {
                            ErrorMessagelabel.Text = "Invalid username or password. Please try again.";
                        }

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessagelabel.Text = ex.Message.ToString();
            }
        }//End of the method


    }
}