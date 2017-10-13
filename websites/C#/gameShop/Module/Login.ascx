<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="gameShop.Module.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="header-module">
    <div class="left-module"></div>
    <div class="center-module">Login</div>      
    <div class="right-module"></div>    
</div>
<div class="content-module">
        <div id="loginForm" runat="server">
        <table width="100%" border="0" cellspacing="3" cellpadding="3">
                        <tr>
                            <td width="35%" class="logname" align="center">
                                &nbsp;&nbsp;&nbsp;Username:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUsername" runat="server" Width="100px" ></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="logname" align="center">
                                &nbsp;&nbsp;&nbsp;Password:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100px"></asp:TextBox>
                                
                            </td>
                        </tr>
                        
                        <tr>
                            <td height="47" colspan="2" align="center">
                                <asp:Button ID="btnLogon" runat="server" Text="Log In" OnClick="btnLogon_Click" />&nbsp;&nbsp;
                                <asp:Button
                                    ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                                    </td>
                        </tr>
                        
                    </table>
    </div>
    <div id="loginPanel" runat="server">
        <div id="HelloUsername" runat="server" style="display:inline; font-size:large"></div>
        
        
        <asp:Button
                                    ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    </div>
</div>