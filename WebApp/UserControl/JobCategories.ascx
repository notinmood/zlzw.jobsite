<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobCategories.ascx.cs" Inherits="WebApp.UserControl.JobCategories" %>
<table width="995" height="100" cellpadding="0" cellspacing="0">
    <tr>
        <td height="15">
            <span id="span2" style="color: #325C93; font-weight:bold; font-size:14px;">　非管理：</span>
                <span style="color: #6e6e6e;">
                    <asp:Label ID="labNonManageType" runat="server" style="font-size:14px;"></asp:Label>
                </span>
            <br />
        </td>
    </tr>
    <tr>
        <td height="15">
            <span style="color: #6e6e6e; padding-left:81px;">
                <asp:Label ID="labNonManageTypeOther" runat="server" style="font-size:14px;"></asp:Label>
            </span></td>
    </tr>
    <tr>
        <td height="15">
            <span id="span3" style="color: #325C93; font-weight: bold;font-size:14px;">　管理类：</span>
                <span style="color: #6e6e6e;">
                    <asp:Label ID="labManageType" runat="server" style="font-size:14px;"></asp:Label>
                </span>
        </td>
    </tr>
</table>
