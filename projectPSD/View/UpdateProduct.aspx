<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="ProjectPSD.View.UpdateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Product ID:
            <asp:Label ID="labProductId" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Name
            <br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            Stock
            <br />
            <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
            <br />
            Price
            <br />
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnUpdateProduct" runat="server" OnClick="btnUpdateProduct_Click" Text="Update Product" />
            <br />
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to View Product" />
        </div>
    </form>
</body>
</html>
