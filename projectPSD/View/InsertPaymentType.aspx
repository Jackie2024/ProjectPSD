<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPaymentType.aspx.cs" Inherits="ProjectPSD.View.InsertPaymentType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Payment Type
            <br />
            <asp:TextBox ID="txtPaymentType" runat="server"></asp:TextBox>   
            <br />
            <asp:Button ID="btnInsertPaymentType" runat="server" OnClick="btnInsertPaymentType_Click" Text="Insert Payment Type" />
            <br />
            <asp:Label ID="labErr" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back to View Payment Type" />
        </div>
    </form>
</body>
</html>
