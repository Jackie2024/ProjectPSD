<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectPSD.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email <br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox> <br />
            Password <br />
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox> <br />
            <asp:CheckBox ID="cheRemember" runat="server" Text="Remember Me" value ="1" OnCheckedChanged ="btnRememberMe"/> 
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /> <br />
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register Now" />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to Home" />
        </div>
    </form>
</body>
</html>
