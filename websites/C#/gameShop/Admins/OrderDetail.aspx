<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Administrator.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="gameShop.Admins.OrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Order Detail Management</div>
    <div id="command" class="title" runat="server" ></div>
    <asp:Panel ID="pnShow" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td class="name_fild_row">
                    <asp:DropDownList ID="ddlSearchOrderId" runat="server" Width="200px" Visible="false">
                        
                    </asp:DropDownList>
                    <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" Visible="false">
                    </asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="Add" OnClick="btnThem_Click"  Visible="false"/>
                    
                        
                    
                </td>
            </tr>
        </table>
        <asp:DataGrid ID="grdOrderDetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grdOrderDetail_PageIndexChanged"
            PageSize="10" OnItemCommand="grdOrderDetail_ItemCommand" >
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <Columns>
                
                <asp:TemplateColumn HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="grdLblId" runat="server" Text='<%#(Eval("Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Order Id">
                    <ItemTemplate>
                        <asp:Label ID="grdLblCustomer_Id" runat="server" Text='<%#(Eval("Order_Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Product Name">
                    <ItemTemplate>
                        <asp:Label ID="grdLblProduct_Id" runat="server" Text='<%#get_Product(Eval("Product_Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Product Price">
                    <ItemTemplate>
                        <asp:Label ID="grdLblProduct_Price" runat="server" Text='<%#Format_Price(get_ProductPrice(Eval("Product_Id").ToString()))%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="grdLblQuantity" runat="server" Text='<%#(Eval("Quantity").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                
                
               
            </Columns>
            <EditItemStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <ItemStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="#F3F8FE" ForeColor="Blue" HorizontalAlign="Center" Mode="NumericPages" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataGrid></asp:Panel>
    <asp:Panel ID="pnUpdate" runat="server" Visible="False" Width="100%">
        <table id="Table2" style="border-collapse: collapse" cellpadding="0" width="100%"
            border="0">
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblCustomer_Id_Update" runat="server">Order Id</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlOrder_Id_Update" runat="server" Width="200px">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtId" runat="server" Visible="false" Width="200px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblTotalMoney" runat="server">Product</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProduct_Id_Update" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
            </tr>
            
            
           
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblQuantity" runat="server">Quantity</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td>
                    &nbsp;<asp:LinkButton ID="lbtUpdate" CssClass="update" runat="server" OnClick="lblUpdate_Click">Update</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                        ID="lblBack" runat="server" CssClass="back" OnClick="lblBack_Click">Back</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
