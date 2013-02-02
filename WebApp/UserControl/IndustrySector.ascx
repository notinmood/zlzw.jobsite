<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndustrySector.ascx.cs" Inherits="WebApp.UserControl.IndustrySector" %>
<table width="995" height="100px;" cellpadding="0" cellspacing="0" style="margin:8px 0 8px 0;">
    <tr>
        <td height="15">
            <span style="color: #325C93; font-weight:bold; font-size:14px;">　制造行业：</span>
            <span style="color:#6e6e6e;">
                <asp:Label ID="labzzyType" runat="server" style="font-size:14px;"></asp:Label>
            </span>
        </td>
    </tr>
    <tr>
        <td height="15">
             <br />
            <span style="color: #325C93; font-weight:bold; font-size:14px;">　第三产业：</span>
            <span style="color:#6e6e6e;">
                <asp:label ID="landscy" runat="server" style="font-size:14px;"></asp:label>
            </span>
       </td>
    </tr>
    <%--<tr>
        <td height="20">
            　
            <span style="color:#6e6e6e; padding-left:86px;">
                <asp:Label ID="lablandscyOther" runat="server" style="font-size:14px;"></asp:Label>
            </span>
        </td>
    </tr>--%>
    <tr>
        <td height="15">
            <span style="color: #325C93; font-weight:bold; font-size:14px;">　第一产业：</span>
            <span style="color:#6e6e6e;">
                <asp:Label ID="labddcyType" runat="server" style="font-size:14px;"></asp:Label>
            </span>
       </td>
    </tr>
</table>