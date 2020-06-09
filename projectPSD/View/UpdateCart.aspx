<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCart.aspx.cs" Inherits="ProjectPSD.View.UpdateCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:GridView ID="productGdv" runat="server">
        </asp:GridView>
        <br />
        Quantity<br />
        <asp:TextBox ID="NewQuantityBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="UpdateCartBtn" runat="server" OnClick="UpdateCartBtn_Click" Text="Update Cart" />
        <br />
        <asp:Label ID="ErrorMsg" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BackViewCartBtn" runat="server" OnClick="BackViewCartBtn_Click" Text="Back to View Cart" />
        <br />
    </div>
    </form>
</body>
</html>
