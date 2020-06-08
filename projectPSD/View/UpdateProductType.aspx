<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProductType.aspx.cs" Inherits="ProjectPSD.View.UpdateProductType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Product Type: <asp:Label ID="labType" runat="server" Text=""></asp:Label>
            <br />
            Description: <asp:Label ID="labDesc" runat="server" Text=""></asp:Label>
            <br />
            <br />
            Product Type
            <br />
            <asp:TextBox ID="txtProductType" runat="server"></asp:TextBox>
            <br />
            Description
            <br />
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnUpdateProductType" runat="server" OnClick="btnUpdateProductType_Click" Text="Update Product Type" />
            <br />
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to View Product Type" />
        </div>
    </form>
</body>
</html>
