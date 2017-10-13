<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="gameShop.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="list-product">
    <div class="header-listproduct">
        <h3>Register</h3>
    </div>
    <div class="content-listproduct">
        <table id="table2" style="border-collapse:collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="150" class="name_fild_row">
                    <asp:Label ID="Label1" Text="Username" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" /><asp:TextBox ID="txtId" runat="server" Visible="false" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    <asp:Label ID="Label2" Text="Password" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    <asp:Label ID="Label4" Text="Name" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" />
                </td>
            </tr>
            <tr>
            <td class="name_fild_row" width="150">
            </td>
            <td>
                <asp:LinkButton ID="lbtRegister" runat="server" CssClass="update" 
                    onclick="lbtRegister_Click">Register</asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="lbtBack" runat="server" CssClass="back" 
                    onclick="lbtBack_Click">Back</asp:LinkButton>
            </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    <asp:Label ID="Label3" Text="Rule" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlRule" runat="server" Visible="false">
                        <asp:ListItem Value="1">Admin</asp:ListItem>
                        <asp:ListItem Value="2" Selected="True">User</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    <asp:Label ID="Label5" Text="Status" runat="server" Visible="false" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" Visible="false">
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">Deactive</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            
        </table>
    </div>
    </div>
</asp:Content>
