<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HotProduct.ascx.cs" Inherits="gameShop.Module.HotProduct" %>
<div class="list-product">
    <div class="header-listproduct">
    <h3>Hot Products</h3>
    </div>
    <div class="content-listproduct">
        <asp:DataList ID="listproduct" runat="server" RepeatColumns="3" Width="100%" 
           RepeatDirection="Horizontal" onitemcommand="listproduct_ItemCommand">
            <ItemTemplate>
                <div class="product">
                    <div class="imgproduct">
                        <a href='<%#Eval("ID","/ProductDetail/"+ Eval("Category_ID") +"/{0}/") %>'><asp:Image class="img" ImageUrl='<%#Eval("Image") %>' Width="165px" Height="120px" runat="server"/>
                        </a>
                    </div>
                        <asp:HyperLink CssClass="nameproduct" runat="server" NavigateUrl='<%#Eval("ID","/ProductDetail/"+ Eval("Category_ID") +"/{0}/" + UrlRewrite.GenShortName(Eval("Name").ToString())) %>' Text='<%#Eval("Name") %>' />
                        <asp:Label CssClass="priceproduct" Text='<%#Format_Price(Eval("Price").ToString()) %>' runat="server" />
                    <div class="btnproduct">
                        <asp:ImageButton CssClass="orderproduct" CommandName="Order" CommandArgument='<%#Eval("ID") %>' Width="100px" ImageUrl='/Images/addtocart.jpg' runat="server" />
                    </div>    
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>