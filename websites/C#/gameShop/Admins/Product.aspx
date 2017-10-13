<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Administrator.Master" AutoEventWireup="true"
    CodeBehind="Product.aspx.cs" Inherits="gameShop.Admins.Product" %>

<%@ Register Src="../Module/uploader.ascx" TagName="uploader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Product Management</div>
    <div id="command" class="title" runat="server" ></div>
    <asp:Panel ID="pnShow" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            <tr>
                <td class="name_fild_row">
                    By Category:&nbsp;<asp:DropDownList ID="ddlCategory_Id" runat="server" Width="200px">
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
        <asp:DataGrid ID="grdProduct" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grdProduct_PageIndexChanged"
            PageSize="10" OnItemCommand="grdProduct_ItemCommand" >
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <Columns>
                
                <asp:TemplateColumn HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="grdLblId" runat="server" Text='<%#(Eval("Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Product Name">
                    <ItemTemplate>
                        <asp:Label ID="grdLblName" runat="server" Text='<%#(Eval("Name").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Detail">
                    <ItemTemplate>
                        <asp:Label ID="grdLblDetails" runat="server" Text='<%#(Eval("Detail").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="grdLblPrice" runat="server" Text='<%#Format_Price(Eval("Price").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="grdImgImage" src='<%#(Eval("Image").ToString())%>' width="100" height="100" alt="" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Price Sale">
                    <ItemTemplate>
                        <asp:Label ID="grdLblPriceNew" runat="server" Text='<%#(Eval("PriceSale").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="grdLblDate" runat="server" Text='<%#(Eval("Date").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                
                <asp:TemplateColumn HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="grdLblStatus" runat="server" Text='<%#get_Status(Eval("Status").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Category">
                    <ItemTemplate>
                        <asp:Label ID="grdLblCategory_Id" runat="server" Text='<%#get_Category(Eval("Category_Id").ToString())%>'></asp:Label></ItemTemplate>
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
                    &nbsp;<asp:Label ID="lblName" runat="server">Product Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                    <asp:TextBox ID="txtId" runat="server" Visible="false" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblDetails" runat="server">Detail</asp:Label>
                </td>
                <td>
                    <asp:TextBox TextMode="Multiline" Width="500px" Height="250px" Columns="5" ID="txtDetails" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblPrice" runat="server">Price</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblImage" runat="server">Image</asp:Label>
                </td>
                <td>
                    <uc1:uploader ID="uploader1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblPriceNew" runat="server">Price Sale</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceNew" runat="server" Width="200px"></asp:TextBox>
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
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblCategory_Id" runat="server">Category</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategory_Id_Update" runat="server" Width="200px">
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
