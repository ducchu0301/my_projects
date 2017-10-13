<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Administrator.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="gameShop.Admins.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Customer Management</div>
    <div id="command" class="title" runat="server" ></div>
    <asp:Panel ID="pnShow" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td class="name_fild_row">
                    By User:&nbsp;<asp:DropDownList ID="ddlSearchUser" runat="server" Width="200px">
                        
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
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="Add" OnClick="btnThem_Click" />
                    
                        &nbsp;
                    <asp:TextBox ID="txtSearch" runat="server"  />
                    <asp:Button ID="btnSearch" Text="Search"
                            runat="server" onclick="btnSearch_Click" />
                        
                    
                </td>
            </tr>
        </table>
        <asp:DataGrid ID="grdCustomer" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grdCustomer_PageIndexChanged"
            PageSize="10" OnItemCommand="grdCustomer_ItemCommand" >
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <Columns>
                
                <asp:TemplateColumn HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="grdLblId" runat="server" Text='<%#(Eval("Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="grdLblName" runat="server" Text='<%#(Eval("Name").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="BirthDay">
                    <ItemTemplate>
                        <asp:Label ID="grdLblBirthDay" runat="server" Text='<%#get_time(Eval("BirthDay").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="grdLblAddress" runat="server" Text='<%#(Eval("Address").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                
                <asp:TemplateColumn HeaderText="Tel">
                    <ItemTemplate>
                        <asp:Label ID="grdLblTel" runat="server" Text='<%#(Eval("Tel").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Mail">
                    <ItemTemplate>
                        <asp:Label ID="grdLblMail" runat="server" Text='<%#(Eval("Mail").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Account - Username">
                    <ItemTemplate>
                        <asp:Label ID="grdLblUser_Id" runat="server" Text='<%#get_User(Eval("User_Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        Command</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                            CommandName="Edit" CssClass="edit" ToolTip="Edit">&nbsp;</asp:LinkButton>|<asp:LinkButton
                                ID="lbt2" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                                CommandName="Delete" CssClass="delete" OnClientClick="return confirm(&quot;Are you sure to delete it?&quot;)"
                                ToolTip="Delete">&nbsp;</asp:LinkButton></ItemTemplate>
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
                    &nbsp;<asp:Label ID="lblName" runat="server">Customer Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="200px">
                    </asp:TextBox>
                    <asp:TextBox ID="txtId" runat="server" Visible="false" Width="200px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblBirthDay" runat="server">BirthDay</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBirthDay" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
            
           
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblAddress" runat="server">Address</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" TextMode="Multiline" Width="500px" Height="20px" Columns="5" runat="server">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblTel" runat="server">Tel</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblMail" runat="server">Mail</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblUser_Id" runat="server">Account - Username</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlUser_Id_Update" runat="server" Width="200px">
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
