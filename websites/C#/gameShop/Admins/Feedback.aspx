<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/Administrator.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="gameShop.Admins.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        Feedback Management</div>
    <div id="command" class="title" runat="server" ></div>
    <asp:Panel ID="pnShow" runat="server" Width="100%">
        <table id="Table1" style="border-collapse: collapse; background-color: #D0DEF0;"
            cellpadding="0" width="100%" border="0">
            
            
        </table>
        <asp:DataGrid ID="grdFeedback" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" Width="100%" OnPageIndexChanged="grdFeedback_PageIndexChanged"
            PageSize="10" OnItemCommand="grdFeedback_ItemCommand" >
            <AlternatingItemStyle BackColor="White" />
            <HeaderStyle CssClass="trHeader"></HeaderStyle>
            <Columns>
                
                <asp:TemplateColumn HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="grdLblId" runat="server" Text='<%#(Eval("Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Customer Name">
                    <ItemTemplate>
                        <asp:Label ID="grdLblCustomer_Name" runat="server" Text='<%#get_Customer(Eval("Customer_Id").ToString())%>'></asp:Label></ItemTemplate>
                </asp:TemplateColumn>
                
                <asp:TemplateColumn HeaderText="Content">
                    <ItemTemplate>
                        <asp:TextBox TextMode="MultiLine" ReadOnly="true" Width="100%" Height="100px" ID="grdLblContent" runat="server" Text='<%#(Eval("Content").ToString())%>'></asp:TextBox></ItemTemplate>
                </asp:TemplateColumn>
                
                <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        Command</HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                            CommandName="Send" ToolTip="Send Feedback email">Send</asp:LinkButton> </ItemTemplate>
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
    <asp:Panel ID="pnSend" runat="server" Visible="False" Width="100%">
        <table id="Table2" style="border-collapse: collapse" cellpadding="0" width="100%"
            border="0">
            
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblCustomer" runat="server">Customer Mail</asp:Label>
                </td>
                <td>
                    
                    <asp:TextBox ID="txtCustomer" ReadOnly="true" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            
            
           
            <tr>
                <td width="150" class="name_fild_row">
                    &nbsp;<asp:Label ID="lblContent" runat="server">Content</asp:Label>
                </td>
                <td>
                    <asp:TextBox TextMode="MultiLine" Width="500px" Height="100px" ID="txtContent" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td width="150">
                    &nbsp;
                </td>
                <td>
                    &nbsp;<asp:LinkButton ID="lbtSend" CssClass="confirm" runat="server" OnClick="lblSend_Click">Send</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton
                        ID="lblBack" runat="server" CssClass="back" OnClick="lblBack_Click">Back</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
