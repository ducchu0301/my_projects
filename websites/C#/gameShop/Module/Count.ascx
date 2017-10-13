<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Count.ascx.cs" Inherits="gameShop.Module.Count" %>
<div class="header-module">
    <div class="left-module"></div>
    <div class="center-module">Statistics</div>      
    <div class="right-module"></div>    
</div>
<div class="content-module">
    <table width="100%" border="0" cellspacing="3" cellpadding="3">
                        <tr>
                            <td width="35%" class="logname" align="center">
                                Visited:
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCounter" runat="server" Text="Label" ForeColor="DarkBlue"></asp:Label>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="logname" align="center">
                                Online:
                            </td>
                            <td align="left">
                                <asp:Label ID="lblOnline" runat="server" Text="Label" ForeColor="DarkBlue"></asp:Label>
                                
                            </td>
                        </tr>
                 </table>
</div>