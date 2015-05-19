using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        // Creates the object of dsUser class
        dsUser dsUserLogin;
        // declares variable to store the sql command to set the security level
        string SecurityLevel;
        //Compares the login credentials with that on the table
        dsUserLogin = clsDataLayer.VerifyUser(Server.MapPath("PayrollSystem_DB.accdb"),
        Login1.UserName, Login1.Password);
        // if statement says if the user has not logged in before, authentication is false.
        if (dsUserLogin.tblUserLogin.Count < 1)
        {
            e.Authenticated = false;
            // Add your comments here
            // Add your comments here
            if (clsBusinessLayer.SendEmail("arigato.20@hotmail.com",
            "forced2make1@gmail.com", "", "", "Login Incorrect",
            "The login failed for UserName: " + Login1.UserName +
            " Password: " + Login1.Password))
            {
            Login1.FailureText = Login1.FailureText +
            " Your incorrect login information was sent to your forced2make1@gmail.com";
            }

            return;
        }
        // stores the security level based on if the credentials were 
        // correct and what level of security they are allowed.

        SecurityLevel = dsUserLogin.tblUserLogin[0].SecurityLevel.ToString();
        // Add your comments here
        switch (SecurityLevel)
        {
            case "A":
                // Security level is set to A
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                e.Authenticated = true;
                Session["SecurityLevel"] = "A";
                break;
            case "U":
                // Security level is set to U
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                e.Authenticated = true;
                Session["SecurityLevel"] = "U";
                break;
            default:
                e.Authenticated = false;
                break;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
}