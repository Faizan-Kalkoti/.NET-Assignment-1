using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                // Retrieve the user's name from the session and display it
                string userName = Session["Username"].ToString();
                lblUserName.Text = userName + "!";
            }

        }

        protected void btnGoToLogin(object sender, EventArgs e)
        {
            Response.Redirect("~/Accounts/Login.aspx");
        }
    }
}