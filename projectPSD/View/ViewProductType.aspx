<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProductType.aspx.cs" Inherits="ProjectPSD.View.ViewProductType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridProduct" runat="server"></asp:GridView>
            <asp:Label ID="labProTy" runat="server" Text="">Product Type ID:</asp:Label>
            <asp:TextBox ID="txtProductTypeId" runat="server"></asp:TextBox>
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnInsertProductType" runat="server" OnClick="btnInsertProductType_Click" Text="Insert Product Type" />
            <asp:Button ID="btnUpdateProductType" runat="server" OnClick="btnUpdateProductType_Click" Text="Update Product Type" />
            <asp:Button ID="btnDeleteProductType" runat="server" OnClick="btnDeleteProductType_Click" Text="Delete Product Type" />
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to Home" />
        </div>
    </form>
</body>
</html>
