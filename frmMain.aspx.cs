using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecurityLevel"] == "A")
        {
            // 
            imgbtnNewEmployee.Visible = true;
            linkbtnNewEmployee.Visible = true;

            // 
            imgbtnEditEmployees.Visible = true;
            linkbtnEditEmployees.Visible = true;

            // 
            imgbtnViewUserActivity.Visible = true;
            linkbtnViewUserActivity.Visible = true;

            // 
            imgbtnManageUsers.Visible = true;
            linkbtnManageUsers.Visible = true;
        }
        else
        {
            // 
            imgbtnNewEmployee.Visible = false;
            linkbtnNewEmployee.Visible = false;

            // 
            imgbtnEditEmployees.Visible = false;
            linkbtnEditEmployees.Visible = false;

            // 
            imgbtnViewUserActivity.Visible = false;
            linkbtnViewUserActivity.Visible = false;

            // 
            imgbtnManageUsers.Visible = false;
            linkbtnManageUsers.Visible = false;
        }
        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.accdb"), "frmPersonnel");
    }
}