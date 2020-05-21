<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="ProjectPSD.View.ViewUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridUser" runat="server"></asp:GridView>
            User ID:
            <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnToggleRole" runat="server" OnClick="btnToggleRole_Click" Text="Toggle Role" />
            <asp:Button ID="btnToggleStatus" runat="server" OnClick="btnToggleStatus_Click" Text="Toggle Status" />
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to Home" />
        </div>
    </form>
</body>
</html>
