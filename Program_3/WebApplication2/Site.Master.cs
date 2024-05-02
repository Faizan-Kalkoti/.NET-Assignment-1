using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

            if (!currentPage.Equals("Default", StringComparison.OrdinalIgnoreCase) && !currentPage.Equals("Register", StringComparison.OrdinalIgnoreCase))
            {
                if (Session["LoggedIn"] == null)
                {
                    Response.Redirect("~/Accounts/Login.aspx");
                }
            }
            

            

            // Check if it's the Home page
            if (currentPage.Equals("Login", StringComparison.OrdinalIgnoreCase))
            {
                if (!(bool)Session["LoggedIn"])
                {
                    Session["LoggedIn"] = null;
                }
            }

            
        }
    }
}