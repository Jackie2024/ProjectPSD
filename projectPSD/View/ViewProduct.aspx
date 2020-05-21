<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="ProjectPSD.View.ViewProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gridProduct" runat="server"></asp:GridView>
        <asp:Label ID="labPro" runat="server" Text="">Product ID:</asp:Label>
        <asp:TextBox ID="txtProductId" runat="server"></asp:TextBox>
        <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnInsertProduct" runat="server" OnClick="btnInsertProduct_Click" Text="Insert Product" />
        <asp:Button ID="btnUpdateProduct" runat="server" OnClick="btnUpdateProduct_Click" Text="Update Product" />
        <asp:Button ID="btnDeleteProduct" runat="server" OnClick="btnDeleteProduct_Click" Text="Delete Product" />
        <br />
        <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to Home" />
    </div>
    </form>
</body>
</html>
