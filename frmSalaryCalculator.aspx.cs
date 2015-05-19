using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSalaryCalculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtCalculateSalary_Click(object sender, EventArgs e)
    {
        double hours = 0, rate = 0, answer = 0;  //declares the variables
        hours = Double.Parse(txtAnnualHours.Text);  //stores text from text box
        rate = Double.Parse(txtPayRate.Text);  //stores text from text box
        answer = hours * rate;  //calculates the salary
        lblAnnualSalary.Text = answer.ToString("c"); //displays the salary as a number
    }
}