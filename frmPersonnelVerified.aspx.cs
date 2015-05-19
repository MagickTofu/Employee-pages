using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPersonnelVerified : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //All information is pulled from Session into text box.
        txtVerifiedInfo.Text = Session["txtFirstName"] + 
    "\n" + Session["txtLastName"] + 
    "\n" + Session["txtPayRate"] + 
    "\n" + Session["txtStartDate"].ToString() + 
    "\n" + Session["txtEndDate"].ToString();

        // Saves the data to the database if the connection is available to the specified database
        if (clsDataLayer.SavePersonnel(Server.MapPath("PayrollSystem_DB.accdb"),
        Session["txtFirstName"].ToString(),
        Session["txtLastName"].ToString(),
        Session["txtPayRate"].ToString(),
        Session["txtStartDate"].ToString(),
        Session["txtEndDate"].ToString()))
        {
            txtVerifiedInfo.Text = txtVerifiedInfo.Text +
            "\nThe information was successfully saved!";
        }
        else
        {
            txtVerifiedInfo.Text = txtVerifiedInfo.Text +
            "\nThe information was NOT saved.";
        }
    }
    protected void txtVerifiedInfo_TextChanged(object sender, EventArgs e)
    {

    }
}