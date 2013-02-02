﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseService.aspx.cs" Inherits="WebApp.EnterpriseService" %>
<%@ Register src="UserControl/DefaultHead.ascx" tagname="DefaultHead" tagprefix="uc1" %>
<%@ Register src="UserControl/DefaultFooter.ascx" tagname="DefaultFooter" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title runat="server" id="titleName"></title>
    <link href="css/zong.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:DefaultHead ID="DefaultHead1" runat="server" />
            <div>
                <table style="width:100%;">
                    <tr>
                        <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height:3px;">
                                
                        </td>
                    </tr>
                </table>
                <table style="width:100%; line-height:30px;" border="0">
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td>
                            <div style="float:left;border:1px solid; border-color:#e9e1e1;height:100%;width:19%;margin-left:15px;text-align:center;">
                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                    <HeaderTemplate>
                                        <table style="width:100%;font-size:14px;">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                            <tr>
                                                <asp:Label ID="labMenuItem" runat="server"></asp:Label>
                                            </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                           </div>
                            <div style="float:left;border:1px solid; border-color:#e9e1e1;margin-left:20px;width:74%;">
                                <table style="width:100%;" border="0">
                                    <tr>
                                        <td colspan="2" style="padding:10px 30px 10px 30px;">
                                            <asp:Label ID="labContent" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table> 
                <uc2:DefaultFooter ID="DefaultFooter1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
