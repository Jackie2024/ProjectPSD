<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTransactionHistory.aspx.cs" Inherits="ProjectPSD.View.ViewTransactionHistory" enableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transaction History</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Transaction History</h1>

            <asp:GridView ID="TransactionGridView" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="ViewTransactionDetailBtn" CommandName="ViewTransactionDetail" OnClick="onClickViewTransactionDetailBtn" Text="View Transaction Detail" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Button runat="server" ID="viewTransactionReportBtn" OnClick="onClickViewTransactionReportBtn" Text="View Transaction Report"></asp:Button>

            <asp:Button ID="btnBack" runat="server" OnClick="BtnBack_Click" Text="Back to Home" />
        </div>
    </form>
</body>
</html>
