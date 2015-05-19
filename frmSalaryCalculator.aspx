<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSalaryCalculator.aspx.cs" Inherits="frmSalaryCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/CIS407A_iLab_ACITLogo.jpg" PostBackUrl="~/frmMain.aspx" />
        <br />
        <br />
    
        <asp:Label ID="Label1" runat="server" Text="Annual Hours"></asp:Label>
        <asp:TextBox ID="txtAnnualHours" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Pay Rate"></asp:Label>
        <asp:TextBox ID="txtPayRate" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="txtCalculateSalary" runat="server" Text="Calculate Salary" OnClick="txtCalculateSalary_Click" />
        <br />
        <asp:Label ID="lblAnnualSalary" runat="server" Text="$"></asp:Label>
        <br />    
    </div>
    </form>
</body>
</html>
