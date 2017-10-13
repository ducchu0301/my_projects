<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="gameShop.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="list-product">
    <div class="header-listproduct">
        <h3>Checkout</h3>
    </div>
    <div class="content-listproduct">
        <div id="CheckoutCustomer" style=" margin-left: 15px; margin-right: 15px; margin-bottom: 15px;" runat="server">
        <table id="Table2" style="border-collapse: collapse" cellpadding="5" width="100%" cellspacing="5"
            border="0">
            <tr>
                <td width="100%" colspan="2">Fill the info</br><hr /></td>
            </tr>
            <tr>
                <td class="name_fild_row">
                    &nbsp;<asp:Label ID="lblName" runat="server">Customer Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" >
                    </asp:TextBox>
                    <asp:TextBox ID="txtId" runat="server" Visible="false" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td class="name_fild_row">
                    &nbsp;<asp:Label ID="lblBirthDay" runat="server">BirthDay</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDay" runat="server" Width="25px" ></asp:TextBox>/
                    <asp:TextBox ID="txtMonth" runat="server" Width="25px" ></asp:TextBox>/
                    <asp:TextBox ID="txtYear" runat="server" Width="50px" ></asp:TextBox>
                </td>
            </tr>
            
            
           
            <tr>
                <td  class="name_fild_row">
                    &nbsp;<asp:Label ID="lblAddress" runat="server">Address</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" TextMode="Multiline" Width="300px" Height="40px" Columns="5" runat="server">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  class="name_fild_row">
                    &nbsp;<asp:Label ID="lblTel" runat="server">Tel</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr><td colspan="2"><br /><hr /><br />We'll use this email to feedback your order. Make sure this is your email.</td></tr>
            <tr>
                <td  class="name_fild_row">
                    &nbsp;<asp:Label ID="lblMail" runat="server">Mail</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td >
                    &nbsp;
                </td>
                <td>
                    &nbsp;<br /><asp:Button ID="btnConfirm" CssClass="update" runat="server" OnClick="btnConfirm_Click" Text="Confirm"></asp:Button>
                </td>
            </tr>
        </table>
        </div>
    
    <div id="OrderEnd" runat="server" style="margin-left: 15px; margin-right: 15px; margin-bottom: 15px;" visible="false">
        <div id="OrderHeader">Order Complete!</div>
        <div id="OrderId" runat="server"></div>
        <asp:DataGrid ID="grdOrderDetail" runat="server" AllowPaging="false" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" 
              >
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <Columns>
                <asp:TemplateColumn HeaderText="Product Name">
                    <ItemTemplate>
                        <asp:Label ID="grdLblName" runat="server" Text='<%#getNameProduct(Eval("Product_Id").ToString())%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="grdLblQuantity" Width="50px" runat="server" Text='<%#(Eval("Quantity").ToString())%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="grdLblPrice" runat="server" Text='<%#Format_Price(getPriceProduct(Eval("Product_Id").ToString()))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
               
            </Columns>
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataGrid>
        <div id="OrderTotalMoney" runat="server" style="margin-left:10px"></div>
        <div id="OrderCustomer" runat="server"></div>
        <div id="OrderFeedback" runat="server"></div>
        <hr />
        Feedback<br />
        <asp:TextBox ID="txtFeedback" TextMode="MultiLine" Width="500px" Height="100px" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="SendFeedback" Text="Send" runat="server" OnClick="btnSend_Click" />
    </div>
    </div>
    </div>
</asp:Content>
