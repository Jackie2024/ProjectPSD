<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="ProjectPSD.View.ViewCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="ProjectPSD.View.ViewCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <asp:GridView ID="cartProduct" runat="server" Height="249px" Width="286px">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton OnClick="onUpdate_Click" ID="Update" CommandArgument='<%# Eval("Id")%>' runat="server">Update</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton OnClick="onDelete_Click" ID="Delete" CommandArgument='<%# Eval("Id")%>' runat="server">Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="card mb-3">                 
            <div class="card-body">                         
                <h3>                            
                     <strong>                                 
                         Grandtotal:  
                     </strong>                        
                </h3>                    
            </div>                 
        </div> 
         <asp:Button CssClass="btn btn-primary w-100 mb-3" 
             ID="btnCheckout" Text="Checkout" OnClick="btnCheckout_Click" runat="server" />
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label></form>
</body>
</html>

    </div>
    </form>
</body>
</html>
