<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTransactionDetail.aspx.cs" Inherits="ProjectPSD.View.ViewTransactionDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Transaction Detail</h1>
        <asp:label runat="server" ID="trIdLabel" Text="Transaction ID: "></asp:label> <br />
        <asp:label runat="server" ID="trDateLabel" Text="Transaction Date: "></asp:label> <br />
        <asp:label runat="server" ID="trPaymentLabel" Text="Payment Type: "></asp:label> <br />

        <asp:GridView ID="TransactionDetailGridView" runat="server">
        </asp:GridView>

        <asp:Button ID="btnBack" runat="server" OnClick="BtnBack_Click" Text="Back to Transaction History" />
        
    </div>
    </form>
</body>
</html>
