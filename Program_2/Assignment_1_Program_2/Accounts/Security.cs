using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 


public class Security
{
   public Security()
   {

    string server = ConfigurationManager.AppSettings["Server"];
    string database = ConfigurationManager.AppSettings["Database"];
    string userID = ConfigurationManager.AppSettings["User Id"];
    string password = ConfigurationManager.AppSettings["Password"];
   }
}



