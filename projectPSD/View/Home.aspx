<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjectPSD.View.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblName" runat="server"></asp:Label>
        <br />
        <div>
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
            <br / />
            <asp:Button ID="btnViewProduct" runat="server" OnClick="btnViewProduct_Click" Text="View Product" />
            <br />
            <asp:Button ID="btnViewProfile" runat="server" OnClick="btnViewProfile_Click" Text="View Profile" />
            <br />
            <asp:Button ID="btnViewUser" runat="server" OnClick="btnViewUser_Click" Text="View User" />
            <br />
            <asp:Button ID="btnInsertProduct" runat="server" OnClick="btnInsertProduct_Click" Text="Insert Product" />
            <br />
            <asp:Button ID="btnViewProductType" runat="server" OnClick="btnViewProductType_Click" Text="View Product Type" />
            <br />
            <asp:Button ID="btnInsertProductType" runat="server" OnClick="btnInsertProductType_Click" Text="Insert Product Type" />
            <br />
            <asp:Button ID="btnLogout" runat="server" OnClick="BtnLogout_Click" Text="Logout" />
        </div>
    
    </div>
    </form>
</body>
</html>
