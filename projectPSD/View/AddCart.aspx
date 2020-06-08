<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCart.aspx.cs" Inherits="ProjectPSD.View.AddCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h3>Product Name: <asp:Label ID="ProductName" runat="server" Text="x"></asp:Label> </h3>
        <h3>Product Stock: <asp:Label ID="ProductStock" runat="server" Text="x"></asp:Label> </h3>
        <h3>Product Price: <asp:Label ID="ProductPrice" runat="server" Text="x"></asp:Label> </h3> 
        <h3>Product Type: <asp:Label ID="ProductType" runat="server" Text="x"></asp:Label> </h3>
 
 
    
    </div>
        <h5>Input Quantity: <asp:TextBox ID="BoxStock" runat="server"></asp:TextBox></h5>
        <h5>
            <asp:Button ID="addToCart" runat="server" Text="Add to Cart" OnClick="addToCart_Click" />
        </h5>

        <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
