<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="gameShop.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="list-product">
    <div class="header-listproduct">
        <h3>Cart</h3>
    </div>
    <div class="content-listproduct">
        <div style=" margin-left: 15px; margin-right: 15px; margin-bottom: 15px;">
        <asp:DataGrid ID="grdCart" runat="server" AllowPaging="false" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" Width="100%"
             OnItemCommand="grdCart_ItemCommand" >
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <Columns>
                <asp:TemplateColumn HeaderText="" Visible="true">
                    <ItemTemplate>
                        <asp:Label ID="grdLblId" runat="server" Text='<%#(Eval("ID").ToString())%>' Visible="false"></asp:Label>
                        <asp:Image ImageUrl='<%#get_picture(Eval("ID").ToString()) %>' Width="160px" Height="120px" runat="server" />
                        </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Product Name">
                    <ItemTemplate>
                        
                        <asp:Label ID="grdLblName" runat="server" Text='<%#(Eval("Name").ToString())%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="grdLblQuantity" Width="50px" runat="server" Text='<%#(Eval("Quantity").ToString())%>' />
                            <asp:RequiredFieldValidator ID="rqvalidatorQuantity" runat="server" Text="*" Display="Dynamic" EnableViewState="True" ControlToValidate="grdLblQuantity" ToolTip="input quantity!"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cmpvalidatorQuantity" runat="server" Type="Integer" ControlToValidate="grdLblQuantity" Display="Dynamic" Text="*" Operator="GreaterThan" ValueToCompare="0" ToolTip="input quantity must > 0!"></asp:CompareValidator>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="grdLblPrice" runat="server" Text='<%#Format_Price(Eval("Price").ToString())%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Total Price">
                    <ItemTemplate>
                        <asp:Label ID="grdLblTotalPrice" runat="server" Text='<%#Format_Price(Total_Price(Eval("ID").ToString()))%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                
                <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        Command</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                            CommandName="Edit" CssClass="edit" ToolTip="Update">Update</asp:LinkButton> | 
                        <asp:LinkButton
                                ID="lbt2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                                CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Are you sure to delete it?&quot;)"
                                ToolTip="Delete">Delete</asp:LinkButton></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:TemplateColumn>
            </Columns>
            <EditItemStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <ItemStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="#F3F8FE" ForeColor="Blue" HorizontalAlign="Center" Mode="NumericPages" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataGrid>
        <div id="message" runat="server" style="text-align:center;"></div>
        </div>
    </div>
</div>
<div id="LoginToCheckout" runat="server" visible="false" style="color:Red" >Login to checkout!</div>
        <asp:Button ID="Checkout" Text="Check out" runat="server" OnClick="btncheckout_Click" Visible="false" />
</asp:Content>
