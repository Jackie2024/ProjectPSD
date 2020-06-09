<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="ProjectPSD.View.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Email
        <br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        Name
        <br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        Gender
        <asp:RadioButtonList ID="radGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btnUpdateProfile" runat="server" OnClick="btnUpdateProfile_Click" Text="Update Profile" />
        <br />
        <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to View Profile" />
        < br />
            < br />
            < asp:Button ID = "btnHome" runat = "server" OnClick = "BtnHome_Click" Text = "Back to Home" />
    </div>
    </form>
</body>
</html>
