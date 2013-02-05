﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseJobList.aspx.cs" Inherits="WebApp.EnterpriseInfo.EnterpriseJobList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="txbTitle" runat="server"></title>
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="1024">
            <tr>
                <td>
                    <p>
                        <asp:Label ID="labBanner" runat="server" style="color:#052C65;font-size:30px; font-weight:bold;"></asp:Label>
                    </p>
                </td>
            </tr>
            <tr>
                <td style="background-image:url('images/index_03.jpg');background-color:#FFFFFF;height:70px;" height="20" valign="top">
                    
                </td>
            </tr>
            <tr>
                <td style="background-image:url('images/index_04.jpg'); background-color:#FFFFFF;" height="20">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
                        <tr>
                            <td>
                                <asp:Label ID="labEnterpriseContent" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="background-color:#FFFFFF; background-image:url('images/index_06.jpg');height:70px;" height="20" valign="top">
                    <img src="images/index_06.jpg" height="84" width="1024">
                </td>
            </tr>
            <!---->
            <tr>
                <td style="background-image:url('images/index_07.jpg'); background-color:#FFFFFF;" height="20">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
                        <tbody>
                            <tr>
                                <td>
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" OnItemDataBound="DataList1_ItemDataBound" Width="893px">
                                                        <HeaderTemplate>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td height="26" width="33.3%" align="left"  style="padding-left:15px;">
                                                                            <li>
                                                                                <asp:Label ID="labJobTitle" runat="server"></asp:Label>
                                                                            </li>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                    </asp:DataList>
                                                    <table class="9t" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--<hr>--%>
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <strong>职位联系方式</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tbody>
                                                            <tr>
                                                                <td align="right" nowrap="nowrap" valign="top"><span style='color:#052C65;'>公司地址：</span>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="labEnterpriseAdd" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" nowrap="nowrap" valign="top"><span style='color:#052C65;'>联系电话：</span>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="labPhone" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" nowrap="nowrap" valign="top"><span style='color:#052C65;'>邮箱地址：</span>
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    <asp:Label ID="labEmail" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" nowrap="nowrap" valign="top"><span style='color:#052C65;'>联系人员：</span>
                                                                </td>
                                                                <td align="left" valign="top"><asp:Label ID="labLxr" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>--%>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td background="images/index_09.jpg" bgcolor="#FFFFFF" height="70">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="90%">
                        <tbody>
                            <tr>
                                <td>
                                    <div align="center">
                                        未经 校企英才 同意，不得转载本网站之所有招聘信息及作品；校企英才版权所有&#169;1999-
                                    <%--<script>document.write((new Date()).getYear()+(navigator.userAgent.indexOf("Firefox")==-1?0:1900))</script>--%>
                                    2013 &nbsp;
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>