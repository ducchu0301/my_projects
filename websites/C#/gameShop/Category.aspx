<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="gameShop.Category" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="list-product">
    <div class="header-listproduct">
       <h3><asp:Label ID="lblTitle" runat="server" /></h3>
    </div>
    <div class="content-listproduct">
        <asp:DataList ID="listproduct" runat="server" RepeatColumns="3" Width="100%" 
           RepeatDirection="Horizontal" onitemcommand="listproduct_ItemCommand">
            <ItemTemplate>
                <div class="product">
                    <div class="imgproduct">
                        <a href='<%#Eval("ID","/ProductDetail/"+ Eval("Category_ID") +"/{0}/") %>'><asp:Image ID="Image1" class="img" ImageUrl='<%#Eval("Image") %>' Width="165px" Height="120px" runat="server"/>
                        </a>
                    </div>
                        <asp:HyperLink ID="HyperLink1" CssClass="nameproduct" runat="server" NavigateUrl='<%#Eval("ID","/ProductDetail/"+ Eval("Category_ID") +"/{0}/" + UrlRewrite.GenShortName(Eval("Name").ToString())) %>' Text='<%#Eval("Name") %>' />
                        <asp:Label ID="Label1" CssClass="priceproduct" Text='<%#Format_Price(Eval("Price").ToString()) %>' runat="server" />
                    <div class="btnproduct">
                        <asp:ImageButton ID="orderproduct" CssClass="orderproduct" CommandName="Order" CommandArgument='<%#Eval("ID") %>' Width="100px" ImageUrl='/Images/addtocart.jpg' runat="server" />
                    </div>    
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
</asp:Content>
