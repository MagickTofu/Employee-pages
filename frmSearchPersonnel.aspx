<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmSearchPersonnel.aspx.cs" Inherits="frmSearchPersonnel" %>

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
        <asp:Panel ID="Panel2" runat="server">
            <br />
            &nbsp;<asp:Label ID="Label1" runat="server" Text="Search for employee by last name:"></asp:Label>
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" PostBackUrl="~/frmViewPersonnel.aspx" Text="Search" />
        </asp:Panel>
        <br />
    
    </div>
    </form>
</body>
</html>
