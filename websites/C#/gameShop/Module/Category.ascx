<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="gameShop.Module.Category" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="header-module">
    <div class="left-module"></div>
    <div class="center-module">Category</div>
    <div class="right-module"></div>
</div>
<div class="content-module">
    <ul id="category">
    <asp:Repeater ID="rptCategory" runat="server">
        <ItemTemplate>
        <div class="category_product">
            <li><asp:HyperLink runat="server" NavigateUrl='<%#Eval("ID","/Category/{0}/") %>' Text='<%#Eval("Name")%>' /></li>     
        </div>
        </ItemTemplate>
    </asp:Repeater>
    </ul>
</div>