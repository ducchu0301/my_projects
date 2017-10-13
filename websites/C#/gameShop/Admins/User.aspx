<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Administrator.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="gameShop.Admins.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title" runat="server">User Management</div>
    <div id="command" class="title" runat="server" ></div>
    <asp:Panel ID="pnShow" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="Add" 
                        onclick="btnThem_Click" />&nbsp;
                    <asp:TextBox ID="txtSearch" runat="server"  />
                   <asp:Button ID="btnSearch" Text="Search"
                            runat="server" onclick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <asp:DataGrid ID="grdUser" runat="server" AllowPaging="true"
            AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" Width="100%" 
            PageSize="10" onitemcommand="grdUser_ItemCommand" 
            onpageindexchanged="grdUser_PageIndexChanged" >
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader" />
            <Columns>
                <asp:TemplateColumn HeaderText="Username">
                    <ItemTemplate>
                        <asp:Label ID="grdLblUsername" runat="server" Text='<%#(Eval("Username").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="grdLblName" runat="server" Text='<%#(Eval("Name").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Rule">
                    <ItemTemplate>
                        <asp:Label ID="grdLblRule" runat="server" Text='<%#get_Rule(Eval("Rule").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="grdLblStatus" runat="server" Text='<%#get_Status(Eval("Status").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>Command</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lbt1" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id") %>' CommandName="Edit" CssClass="edit" ToolTip="Edit" /> |
                        <asp:LinkButton runat="server" ID="lbt2" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id") %>' CommandName="Delete" CssClass="delete" ToolTip="Delete" OnClientClick="return confirm(&quot;Are u you sure to delete it?&quot;)" />
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <EditItemStyle BackColor="#2461BF" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="#F3F8FE" ForeColor="Blue" HorizontalAlign="Center" Mode="NumericPages" />
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" /> 
        </asp:DataGrid>
    </asp:Panel>
    <asp:Panel ID="pnUpdate" runat="server">
        <table id="table2" style="border-collapse:collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="150" class="name_fild_row">
                    <asp:Label Text="Username" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" /><asp:TextBox ID="txtId" runat="server" Visible="false" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    <asp:Label ID="Label1" Text="Password" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" />
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
                <td width="150" class="name_fild_row">
                    <asp:Label ID="Label2" Text="Rule" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlRule" runat="server">
                        <asp:ListItem Value="1">Admin</asp:ListItem>
                        <asp:ListItem Value="2">User</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    <asp:Label ID="Label3" Text="Status" runat=server />
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">Block</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td class="name_fild_row" width="150">
            </td>
            <td>
                <asp:LinkButton ID="lbtUpdate" runat="server" CssClass="update" 
                    onclick="lbtUpdate_Click">Update</asp:LinkButton>
                <asp:LinkButton ID="lbtBack" runat="server" CssClass="back" 
                    onclick="lbtBack_Click">Back</asp:LinkButton>
            </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
