<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ProjectPSD.View.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Old Password
            <br />
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            New Password
            <br />
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            Confirm Password
            <br />
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnChangePassword" runat="server" OnClick="btnChangePassword_Click" Text="Change Password"></asp:Button>
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="BtnBack_Click" Text="Back to View Profile" />
            <br />
            <br />
            <asp:Button ID="btnHome" runat="server" OnClick="BtnHome_Click" Text="Back to Home" />
        </div>
    </form>
</body>
</html>
