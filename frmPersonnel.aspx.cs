using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPersonnel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecurityLevel"] != "A")
        {
            Response.Redirect("frmLogin.aspx");
        }
        // if the security level variable is A, they can see the buttons allowed
        if (Session["SecurityLevel"] == "A")
        {
            btnSubmit.Visible = true;
            //Add your comments here
        }
        else
        {
            btnSubmit.Visible = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Need to set session variables for all text boxes
            Session["txtFirstName"] = txtFirstName.Text;
            Session["txtLastName"] = txtLastName.Text;
            Session["txtPayRate"] = txtPayRate.Text;
            Session["txtStartDate"] = txtStartDate.Text;
            Session["txtEndDate"] = txtEndDate.Text;

            //declares variables
            String msg = null;
        //if statement checks for blank lines and makes the box color yellow if invalid, white if correct
           
                if (Session["txtFirstName"].ToString().Trim() == "")
                {
                    msg = msg + "The first name is incorrect";
                    txtFirstName.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    txtFirstName.BackColor = System.Drawing.Color.White;
                }

                if (Session["txtLastName"].ToString().Trim() == "")
                {
                    msg = msg + "<br>" + "The last name is incorrect";
                    txtLastName.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    txtLastName.BackColor = System.Drawing.Color.White;
                }
                if (Session["txtPayRate"].ToString().Trim() == "")
                {
                    msg = msg + "<br>" + "The pay rate is incorrect";
                    txtPayRate.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    txtPayRate.BackColor = System.Drawing.Color.White;
                }
                if (Session["txtStartDate"].ToString().Trim() == "")
                {
                    msg = msg + "<br>" + "The start date is incorrect";
                    txtStartDate.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    txtStartDate.BackColor = System.Drawing.Color.White;
                }
                if (Session["txtEndDate"].ToString().Trim() == "")
                {
                    msg = msg + "<br>" + "The end date is incorrect";
                    txtEndDate.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    txtEndDate.BackColor = System.Drawing.Color.White;
                }

                //declares datetime variables for star and end date
                DateTime startDate = DateTime.Parse(Request["txtStartDate"]);
                DateTime endDate = DateTime.Parse(Request["txtEndDate"]);
                //compares the two variables for a later date
                if (DateTime.Compare(startDate, endDate) > 0)
                {
                    
                    msg = msg + "<br>" + "The end date must be a later date than the start date."; 
                    txtStartDate.BackColor = System.Drawing.Color.Yellow;
                    txtEndDate.BackColor = System.Drawing.Color.Yellow;   
                }
                else
                {
                    txtStartDate.BackColor = System.Drawing.Color.White;
                    txtEndDate.BackColor = System.Drawing.Color.White;
                   }
                
                
        //if there are no errors, page will redirect, else it will display errors.
            if (msg == null)
            {
                Response.Redirect("frmPersonnelVerified.aspx");
            }
            else
            {
                //The Msg text will be displayed in lblError.Text after all the error messages are concatenated
                lblError.Text = msg;
            }
        //If after testing each validation rule, the validatedState value is true, then submit to frmPersonnelVerified.aspx, if not, then display error message
            
    }
        
        
}