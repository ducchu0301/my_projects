<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="gameShop.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="list-product">
    <div class="header-listproduct">
        <h3><asp:Label ID="lblTitle" runat="server" /></h3>
    </div>

    <div class="content-listproduct">
    <div style=" margin-left: 15px; margin-right: 15px; margin-bottom: 15px;">
    <asp:Label ID="lblProductname" runat="server" />
    <asp:Repeater ID="rptProduct" runat="server" onitemcommand="rptProduct_ItemCommand">
        <ItemTemplate>
            <div>
                <div style="width:260px; height:260px; border:1px solid #e2e2e2; padding:3px; float:left">
                    <asp:Image ImageUrl='<%#Eval("Image") %>' Width="260px" Height="260px" runat="server" />
                </div>
                <div style="width:290px; float:left;">
                    <table width="100%" border="0" cellpadding="4" cellspacing="4">
                        <tr>
                            <td width="15px"></td>
                            <td align="left" width="100px">Product Name:</td>
                            <td align="center"><asp:Label Text='<%#Eval("Name") %>' runat="server" />
                            </td>
                        </tr>
                         <tr>
                            <td width="15px"></td>
                            <td align="left">Price:</td>
                            <td align="center"><asp:Label Text='<%#Format_Price(Eval("Price").ToString()) %>' runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td width="15px"></td>
                            <td align="left">Quantity:</td>
                            <td align="center"><asp:TextBox ID="txtQuantity" Text="1" Width="50px" runat="server" />
                                <asp:RequiredFieldValidator ID="rqvalidatorSoLuong" runat="server" ErrorMessage="*" SetFocusOnError="True" Display="Dynamic" EnableViewState="True" ControlToValidate="txtQuantity" ToolTip="input quantity!"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cmpvalidatorSoLuong" runat="server" Type="Integer" ControlToValidate="txtQuantity" Display="Dynamic" SetFocusOnError="True" ErrorMessage="*" Operator="GreaterThan" ValueToCompare="0" ToolTip="input quantity must >0!"></asp:CompareValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            
                            <td colspan="3" align="center"><br /><asp:ImageButton CssClass="orderproduct" ImageUrl='/Images/addtocart.jpg' Width="200px" CommandName="Order" runat="server" CommandArgument='<%#Eval("ID") %>' />
                            </td>
                        </tr>
                        
                        <tr>
                            
                            <td colspan="3" align="center"><br /><asp:Button Text="Back"  Width="100px" CommandName="Back" runat="server" CommandArgument='<%#Eval("ID") %>' />
                            </td>
                        </tr>
                    </table>                                    
                </div>
                <br />
                <br />
                <br />
                <br />
                
            </div>
            
        </ItemTemplate>
    </asp:Repeater>
    <div id="DIVdetail" runat="server" style="width:100%; display:block"></div>
    </div>
    </div>
</div>
</asp:Content>
