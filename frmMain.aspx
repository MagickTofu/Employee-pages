<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMain.aspx.cs" Inherits="frmMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 439px;
            height: 125px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="" class="auto-style1" src="images/CIS407A_iLab_ACITLogo.jpg" /><br />
        <asp:Panel ID="Panel1" runat="server">
            <asp:ImageButton ID="imgbtnCalculator" runat="server" Height="238px" ImageUrl="~/images/calculator.jpg" PostBackUrl="~/frmSalaryCalculator.aspx" Width="231px" />
            <asp:HyperLink ID="linkbtnCalculator" runat="server" NavigateUrl="~/frmSalaryCalculator.aspx">Annual Salary Calculator</asp:HyperLink>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnNewEmployee" runat="server" Height="196px" ImageUrl="~/images/hired.jpg" PostBackUrl="~/frmPersonnel.aspx" Width="248px" />
            <asp:HyperLink ID="linkbtnNewEmployee" runat="server" NavigateUrl="~/frmPersonnel.aspx">Add New Employee</asp:HyperLink>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnViewUserActivity" runat="server" Height="188px" ImageUrl="~/images/userActivity.jpg" PostBackUrl="~/frmUserActivity.aspx" Width="247px" />
            <asp:HyperLink ID="linkbtnViewUserActivity" runat="server" NavigateUrl="~/frmUserActivity.aspx">User Activity</asp:HyperLink>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnViewPersonnel" runat="server" Height="208px" ImageUrl="~/images/personnel list.jpg" PostBackUrl="~/frmViewPersonnel.aspx" Width="233px" />
            <asp:HyperLink ID="linkbtnViewPersonnel" runat="server" NavigateUrl="~/frmViewPersonnel.aspx">View Personnel</asp:HyperLink>
            <br />
            <br />
            <asp:ImageButton ID="imgbtnSearch" runat="server" Height="208px" ImageUrl="~/images/search.jpg" PostBackUrl="~/frmSearchPersonnel.aspx" Width="233px" />
            <asp:HyperLink ID="linkbtnSearch" runat="server" NavigateUrl="~/frmSearchPersonnel.aspx">Search Personnel</asp:HyperLink>
            <br />
            <asp:ImageButton ID="imgbtnEditEmployees" runat="server" Height="193px" ImageUrl="~/images/Edit.jpg" PostBackUrl="~/frmEditPersonnel.aspx" Width="233px" />
            <asp:LinkButton ID="linkbtnEditEmployees" runat="server" PostBackUrl="~/frmEditPersonnel.aspx">Edit Employees</asp:LinkButton>
            <br />
            <asp:ImageButton ID="imgbtnManageUsers" runat="server" Height="193px" ImageUrl="~/images/Manage.jpg" PostBackUrl="~/frmManageUsers.aspx" Width="233px" />
            <asp:LinkButton ID="linkbtnManageUsers" runat="server" PostBackUrl="~/frmManageUsers.aspx">Manage Users</asp:LinkButton>
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>
        <br />
    
    </div>
    </form>
</body>
</html>
