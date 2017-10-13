<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Administrator.Master" AutoEventWireup="true"CodeBehind="Category.aspx.cs" Inherits="MyWeb.Admins.Category" %>
<%@ Register src="../Module/uploader.ascx" tagname="uploader" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">Category Management</div>
    <div id="command" class="title" runat="server" ></div>
    <asp:Panel ID="pnShow" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <asp:Button ID="btnThem" runat="server" CssClass="btnthem" Text="Add" 
                        onclick="btnThem_Click" />
                    <asp:Button
                        ID="btnXoa" runat="server" CssClass="btnXoa" Text="Delete" OnClick="btnXoa_Click"
                        OnClientClick="return confirm(&quot;Are u you sure to delete it?&quot;)" />
                </td>
            </tr>
        </table>
        <asp:DataGrid ID="grdCategory" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grdCategory_PageIndexChanged"
            PageSize="10" OnItemCommand="grdCategory_ItemCommand" OnItemDataBound="grdCategory_ItemDataBound">
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <Columns>
                <asp:TemplateColumn ItemStyle-CssClass="tdCenter">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox></HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" ></asp:CheckBox></ItemTemplate>
                    <ItemStyle CssClass="tdCenter"></ItemStyle>
                </asp:TemplateColumn>
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
                        <asp:Label ID="grdLblContents" runat="server" Text='<%#(Eval("Contents").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Images">
                    <ItemTemplate>
                      <asp:Image ID="grdImgImages" src='<%#(Eval("Images").ToString())%>' width="100" height="100" alt="" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="grdLblStatus" runat="server" Text='<%#(Eval("Status").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Parent_Id">
                    <ItemTemplate>
                        <asp:Label ID="grdLblParent_Id" runat="server" Text='<%#(Eval("Parent_Id").ToString())%>'></asp:Label></ItemTemplate>
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
        <table id="Table2" style="border-collapse:collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblName" runat="server">Category Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="200px" />
                    <asp:TextBox ID="txtId" runat="server" Width="200px" Visible="false" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblContents" runat="server">Content</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblImages" runat="server">Images</asp:Label>
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
                        <asp:ListItem Value="2">Hot</asp:ListItem>
                        <asp:ListItem Value="1">Show</asp:ListItem>
                        <asp:ListItem Value="0">Hide</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblParent_Id" runat="server">Parent_Id</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtParent_Id" runat="server" Width="200px"></asp:TextBox>
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
