<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uploader.ascx.cs" Inherits="POI.Modules.uploader" %>
<asp:TextBox TextMode="Multiline" Width="500px" Columns="5" ID="txtImages" runat="server" ReadOnly="true"></asp:TextBox>
<asp:Image ID="ImgImages" width="100px" height="100px" alt="" runat="server"/>
<br />
<asp:FileUpload ID="FileUploadHinhAnh" runat="server" />&nbsp;&nbsp;
<asp:Button ID="btlTaiLen" runat="server"
    Text="Upload" onclick="btlTaiLen_Click" />