﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="WebApp.ContactUs" %>
<%@ Register src="UserControl/EnterpriseHead.ascx" tagname="EnterpriseHead" tagprefix="uc1" %>
<%@ Register Src="UserControl/PageFooter.ascx" TagName="PageFooter" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title runat="server" id="titleName">联系我们</title>
    <link href="css/zong.css" type="text/css" rel="stylesheet" />
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:EnterpriseHead ID="EnterpriseHead1" runat="server" />
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
                                <%--<td style="width:100%;background-color:#FA9A08;"><a href="#" style="text-decoration:none;color:#fff; font-weight:bold;">校企英才</a></td>
                                <tr>
                                    <td style="width:100%;"><a href="#" style="text-decoration:none;color:#fff;color:#093C7E;">人才市场</a></td>
                                </tr>--%>
                           </div>
                            <div style="float:left;border:1px solid; border-color:#e9e1e1;margin-left:20px;width:74%;">
                                <table style="width:100%;" border="0">
                                    <%--<tr><tr>
                                        <td>
                                            &nbsp;<a href="default.aspx" style="text-decoration:none;color:#093C7E;">首页</a> > <asp:Label ID="laNavigate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                        <td colspan="2" align="center">
                                            <h2 style="color:#093C7E; font-weight:bold;"><asp:Label ID="labTitle" runat="server"></asp:Label></h2>
                                        </td>
                                    </tr>--%>
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
                <uc2:PageFooter ID="PageFooter1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
