<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Administrator.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="gameShop.Admins.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Order Management</div>
    <div id="command" class="title" runat="server" ></div>
    <asp:Panel ID="pnShow" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td class="name_fild_row">
                    By Status:&nbsp;<asp:DropDownList ID="ddlSearchStatus" runat="server" Width="200px">
                        <asp:ListItem Value="1">All</asp:ListItem>
                        <asp:ListItem Value="2">New</asp:ListItem>
                        <asp:ListItem Value="3">Shipped</asp:ListItem>
                        <asp:ListItem Value="4">Completed</asp:ListItem>
                        <asp:ListItem Value="0">Cancelled</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click">
                    </asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="Add" OnClick="btnThem_Click" Visible="false" />
                    
                        
                    
                </td>
            </tr>
        </table>
        <asp:DataGrid ID="grdOrder" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grdOrder_PageIndexChanged"
            PageSize="10" OnItemCommand="grdOrder_ItemCommand">
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <Columns>
                
                <asp:TemplateColumn HeaderText="Order Id" Visible="true">
                    <ItemTemplate>
                        <asp:HyperLink ID="grdHLId" runat="server" NavigateUrl='<%#Eval("ID","OrderDetail/{0}/") %>' Text='<%#(Eval("Id").ToString())%>' />
                        </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Customer Name">
                    <ItemTemplate>
                        <asp:Label ID="grdLblCustomer_Id" runat="server" Text='<%#get_Customer(Eval("Customer_Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Total Money">
                    <ItemTemplate>
                        <asp:Label ID="grdLblTotalMoney" runat="server" Text='<%#Format_Price(Eval("TotalMoney").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="grdLblDate" runat="server" Text='<%#(Eval("Date").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                
                <asp:TemplateColumn HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="grdLblStatus" runat="server" Text='<%#get_Status(Eval("Status").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        Command</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbt3" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                            CommandName="Confirm" CssClass="confirm" ToolTip="Confirm">&nbsp;</asp:LinkButton>|
                        <asp:LinkButton ID="lbt1" Visible="false" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                            CommandName="Edit" CssClass="edit" ToolTip="Edit">&nbsp;</asp:LinkButton><asp:LinkButton
                                ID="lbt2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                                CommandName="Cancel" CssClass="delete" OnClientClick="return confirm(&quot;Are you sure to cancel this order?&quot;)"
                                ToolTip="Cancel">&nbsp;</asp:LinkButton></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
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
                    &nbsp;<asp:Label ID="lblCustomer_Id_Update" runat="server">Customer Name</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCustomer_Id_Update" runat="server" Width="200px">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtId" runat="server" Visible="false" Width="200px"></asp:TextBox>
                </td>
            </tr>
            
            
            
            
           
            <tr>
                <td width="150" class="name_fild_row">
                <asp:TextBox ID="txtTotalMoney" runat="server" Visible="false" >0</asp:TextBox>
                    &nbsp;<asp:Label ID="lblStatus" runat="server">Status</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="2">New</asp:ListItem>
                        <asp:ListItem Value="3">Shipped</asp:ListItem>
                        <asp:ListItem Value="4">Completed</asp:ListItem>
                        <asp:ListItem Value="0">Cancelled</asp:ListItem>
                    </asp:DropDownList>
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
