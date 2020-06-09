<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="ProjectPSD.View.ViewCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="TEST1" runat="server" Text=""></asp:Label>
        <asp:GridView ID="cartProduct" runat="server">
            <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="DeleteCart" CommandName="DeleteCart" OnClick="onDelete_Click" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>

             <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="UpdateCart" CommandName="UpdateCart" OnClick="onUpdate_Click" Text="Update" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
        <div class="card mb-3">                 
            <div class="card-body">                         
                <h3>                            
                     <strong>                                 
                         Grandtotal:&nbsp;
                     </strong>                        
        <asp:Label ID="GrandTotal" runat="server" Text=""></asp:Label>                        
                </h3>                    
            </div>                 
        </div> 

        <asp:RadioButtonList ID="paymentTypeID" runat="server" Height="16px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>Credit</asp:ListItem>
            <asp:ListItem>Gopay</asp:ListItem>
            <asp:ListItem>Ovo</asp:ListItem>
         </asp:RadioButtonList>

        <br />
         <asp:Button CssClass="btn btn-primary w-100 mb-3" 
             ID="btnCheckout" Text="Checkout" OnClick="btnCheckout_Click" runat="server" />
        <br />
            <br />
            <asp:Button ID = "btnHome" runat = "server" OnClick = "BtnHome_Click" Text = "Back to Home"/>
        <br />
        <asp:Label ID="errMsg" runat="server" Text=""></asp:Label>
        <br />
        </form>
</body>
</html>
