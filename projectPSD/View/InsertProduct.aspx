<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertProduct.aspx.cs" Inherits="ProjectPSD.View.InsertProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
            <asp:Button ID="btnInsertProduct" runat="server" OnClick="btnInsertProduct_Click" Text="Insert Product" />
            <br />
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to View Product" />
            <br />
            <br />
            <asp:Button ID="btnHome" runat="server" OnClick="BtnHome_Click" Text="Back to Home" />
        </div>
    </form>
</body>
</html>
