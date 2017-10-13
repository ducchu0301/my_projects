<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="gameShop.Module.Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="header-module">
    <div class="left-module"></div>
    <div class="center-module">Search</div>      
    <div class="right-module"></div>    
</div>
<div class="content-module">
    <div style="border:1px solid #c5c5c5; width:180px; margin:16px 11px 23px 11px; height:23px; position:relative;">
        <form id="formSearch">
            <asp:TextBox ID="txtSearch" CssClass="txtSearch" width="157px" height="23px" runat="server" BorderStyle="None" />
            <asp:ImageButton ID="btnSearch" CssClass="btnSearch" 
                ImageUrl="/Images/icon-search.jpg" Width="23px" Height="23px"
                runat="server" onclick="btnSearch_Click" CausesValidation="False" />
        </form>
    </div>
    
</div>

