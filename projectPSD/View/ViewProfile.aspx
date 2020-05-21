<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="ProjectPSD.View.ViewProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Email: 
        <asp:Label ID="labEmail" runat="server"></asp:Label>
        <br />
        Name: 
        <asp:Label ID="labName" runat="server"></asp:Label>
        <br />
        Gender: 
        <asp:Label ID="labGender" runat="server"></asp:Label>
        <br />
        <asp:Button ID="btnUpdateProfile" runat="server" OnClick="btnUpdateProfile_Click" Text="Update Profile" />
        <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" Text="Change Password" />
        <br />
        <br />
        <asp:Button ID="btnBack" runat="server" OnClick="BtnBack_Click" Text="Back to Home" />
    </div>
    </form>
</body>
</html>
