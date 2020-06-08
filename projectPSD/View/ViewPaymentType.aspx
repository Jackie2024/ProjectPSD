<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPaymentType.aspx.cs" Inherits="ProjectPSD.View.ViewPaymentType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridPayment" runat="server"></asp:GridView>
            <asp:Label ID="labPayTy" runat="server" Text="">Payment Type ID:</asp:Label>
            <asp:TextBox ID="txtPaymentTypeId" runat="server"></asp:TextBox>
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="btnInsertPaymentType" runat="server" OnClick="btnInsertPaymentType_Click" Text="Insert Payment Type" />
            <asp:Button ID="btnUpdatePaymentType" runat="server" OnClick="btnUpdatePaymentType_Click" Text="Update Payment Type" />
            <asp:Button ID="btnDeletePaymentType" runat="server" OnClick="btnDeletePaymentType_Click" Text="Delete Payment Type" />
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to Home" />
        </div>
    </form>
</body>
</html>
