<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Administrator.Master" AutoEventWireup="true"CodeBehind="Category.aspx.cs" Inherits="gameShop.Admins.Category" %>
<%@ Register src="../Module/uploader.ascx" tagname="uploader" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Category Management</div>
    <div id="command" class="title" runat="server" ></div>
    <asp:Panel ID="pnShow" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
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
        <asp:DataGrid ID="grdCategory" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grdCategory_PageIndexChanged"
            PageSize="10" OnItemCommand="grdCategory_ItemCommand">
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <Columns>
                
                <asp:TemplateColumn HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="grdLblId" runat="server" Text='<%#(Eval("Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Category Name">
                    <ItemTemplate>
                        <asp:Label ID="grdLblName" runat="server" Text='<%#(Eval("Name").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Content">
                    <ItemTemplate>
                        <asp:Label ID="grdLblContents" runat="server" Text='<%#(Eval("Content").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Image">
                    <ItemTemplate>
                      <asp:Image ID="grdImgImages" src='<%#(Eval("Images").ToString())%>' width="100" height="100" alt="" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateColumn>
                
                <asp:TemplateColumn HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="grdLblStatus" runat="server" Text='<%#get_Status(Eval("Status").ToString())%>'></asp:Label></ItemTemplate>
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
    <asp:Panel ID="pnUpdate" runat="server" Visible="false" Width="100%">
        <table id="Table2" style="border-collapse: collapse" cellpadding="0" width="100%"
            border="0">
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblName" runat="server">Category Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                    <asp:TextBox ID="txtId" runat="server" Width="200px" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblContents" runat="server">Content</asp:Label>
                </td>
                <td>
                    <asp:TextBox TextMode="Multiline" Width="500px" Height="250px" Columns="5" ID="txtContents" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblImages" runat="server">Image</asp:Label>
                </td>
                <td>
                    <uc1:uploader ID="uploader1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblStatus" runat="server">Status</asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="1">Show</asp:ListItem>
                        <asp:ListItem Value="0">Hide</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td width="150">
                    <asp:TextBox ID="txtParent_Id" runat="server" Visible="false">0</asp:TextBox>
                </td>
                <td>
                    &nbsp;<asp:LinkButton ID="lbtUpdate" CssClass="update" runat="server" OnClick="lblUpdate_Click">Update</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                        ID="lblBack" runat="server" CssClass="back" OnClick="lblBack_Click">Back</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
