﻿<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EditEnterpriseInfo.aspx.cs" Inherits="WebApp.EditEnterpriseRegisterInfo" %>

<%@ Register src="UserControl/EnterpriseHead.ascx" tagname="EnterpriseHead" tagprefix="uc1" %>
<%@ Register Src="UserControl/PageFooter.ascx" TagName="PageFooter" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="青岛人才市场,青岛代缴保险,青岛劳务派遣,青岛人事代理,青岛人才网,城阳人才网,城阳人才市场,青岛北站人才市场,青岛招聘会" />
    <meta name="description" content="青岛人才市场(汽车北站)，由中劳网与青岛校企英才公司承办，位于汽车北站二楼大厅内，是覆盖青岛五市七区高中低多层次求职者的大型人力资源集散基地。市场业务范围：青岛人才市场招聘会,青岛人才市场网络招聘,青岛代缴保险,青岛劳务派遣,青岛人事代理,短工供应,就业安置等" />
    <title>企业用户信息修改</title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
    <link href="EasyUI/css/bootstrap/easyui.css" rel="stylesheet" />
    <link href="EasyUI/css/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="http://lib.sinaapp.com/js/jquery/1.9.0/jquery.min.js"></script>
    <script type="text/javascript" src="http://lib.sinaapp.com/js/jquery-ui/1.9.0/jquery-ui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="Scripts/WebForms/jquery.watermark.min.js"></script>
    <script type="text/javascript" src="Scripts/EditEnterpriseRegisterInfo.js"></script>
</head>
<body>
    <form id="form01" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" Theme="Blue" />
        <div>
            <uc1:EnterpriseHead ID="EnterpriseHead1" runat="server" />
            <div class="top2right">
                <table style="width: 100%;">
                    <tr>
                        <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height: 3px;"></td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" style="width: 86%; margin-left: 7%;">
                    <tr>
                        <td style="height: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="background-image:url('image/img3_long.png'); background-repeat:repeat-x;height:80px;" align="center">
                            <span style="font-size:14px;color:#fff;font-weight:bold;">　您已收到</span> <span style="font-size:20px;color:#093C7E;font-weight:bold;" id="labReceive" runat="server"></span><span style="font-size:14px;color:#fff;font-weight:bold;">份简历</span>
                            <br /><br />
                            <asp:Label ID="labView02" runat="server"></asp:Label>
                        </td>
                        <td style="width:15px;">

                        </td>
                        <td style="background-image:url('image/img3_long.png'); background-repeat:repeat-x;height:80px;" align="center">
                            <span style="font-size:14px;color:#fff;font-weight:bold;">　您已经下载</span> <span style="font-size:20px;color:#093C7E;font-weight:bold;" id="labAlreadyDownload" runat="server"></span><span style="font-size:14px;color:#fff;font-weight:bold;">份简历</span>
                            <br /><br />
                            <asp:Label ID="labView01" runat="server"></asp:Label>
                        </td>
                        <td style="width:15px;">

                        </td>
                        <td style="background-image:url('image/img3_long.png'); background-repeat:repeat-x;height:80px;">
                            <span style="font-size:14px;color:#fff;font-weight:bold;">　您已经发布了</span> <span style="font-size:20px;color:#093C7E;font-weight:bold;" id="labJobPublish" runat="server"></span><span style="font-size:14px;color:#fff;font-weight:bold;">个职位</span>
                        </td>
                        <td style="width:15px;">

                        </td>
                        <td style="background-image:url('image/img3_long.png'); background-repeat:repeat-x;height:80px;">
                            <span style="font-size:14px;color:#fff;font-weight:bold;">　您还可以下载</span> <span style="font-size:20px;color:#093C7E;font-weight:bold;" id="labDownloadCount" runat="server"></span><span style="font-size:14px;color:#fff;font-weight:bold;">份简历</span>
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; margin-left: 15%;">
                    <tr>
                        <td style="height: 25px;"></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span style="color: #355f95; font-weight: bold; font-size: 16px;">公司信息修改</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e; width: 100px;">账号：</td>
                        <td align="left" style="width: 410px;">
                            <asp:TextBox ID="txbUserName" runat="server" Height="22" Width="400" CssClass="easyui-validatebox" data-options="required:true,validType:['length[6,10]','RepeatRegisterName[txbUserName]']" missingMessage="账号不能为空"></asp:TextBox>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;">*</span> 账号为6-10位英文字母或数字
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">密码：</td>
                        <td align="left" style="width: 410px;">
                            <asp:TextBox ID="txbPassword" TextMode="Password" Height="22" runat="server" Width="400" CssClass="easyui-validatebox" data-options="required:true" missingMessage="密码不能为空" validType="length[6,10]"></asp:TextBox>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;">*</span> 密码为6-10位英文字母或数字
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">确认密码：</td>
                        <td align="left" style="width: 410px;">
                            <asp:TextBox ID="txbPassword01" TextMode="Password" Height="22" runat="server" Width="400" CssClass="easyui-validatebox" data-options="required:true" missingMessage="确认密码不能为空" validType="equalTo['#txbPassword']" invalidMessage="两次输入密码不匹配"></asp:TextBox>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;">*</span> 请确保与密码输入一致
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e; width: 100px;">公司名称：</td>
                        <td align="left" style="width: 410px;">
                            <asp:label ID="txbEnterpriseName" runat="server" Height="22" Width="400" style="font-size:14px;color:#355F95; font-weight:bold;"></asp:label>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">公司行业：</td>
                        <td align="left" style="width: 410px;">
                            <table>
                                <tr>
                                    <%--<td align="left">
                                        <asp:DropDownList ID="drpJobFeildKindsType" Height="26" Width="100" runat="server">
                                            <asp:ListItem Text="制造行业" Value="制造行业" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="第三产业" Value="第三产业"></asp:ListItem>
                                            <asp:ListItem Text="第一产业" Value="第一产业"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpItems" runat="server" Height="26" Width="297"></asp:DropDownList>
                                    </td>--%>
                                    <td colspan="2">
                                        <input runat="server" type="text" id="txbJobFeildKinds" class="easyui-validatebox" data-options="required:true" missingMessage="请选择行业类别" style="width: 400px; height: 22px;" readonly="readonly" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">公司地址：</td>
                        <td align="left" style="width: 410px;">
                            <table>
                                    <tr>
                                        <td><asp:DropDownList ID="drpShengList" Width="80" Height="24" runat="server"></asp:DropDownList></td>
                                        <td><asp:DropDownList ID="drpShiList" Width="81" Height="24" runat="server"></asp:DropDownList></td>
                                        <td><asp:DropDownList ID="drpQuList" Width="80" Height="24" runat="server"></asp:DropDownList></td>
                                        <td><asp:TextBox ID="txbPrincipleAddress" Width="150" Height="22" runat="server" data-options="required:true" missingMessage="公司地址不能为空" CssClass="easyui-validatebox"></asp:TextBox></td>
                                    </tr>
                                </table> 
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">联系电话：</td>
                        <td align="left" style="width: 410px;">
                            <asp:TextBox ID="txbTelephone" Width="400" Height="22" runat="server" CssClass="easyui-validatebox"></asp:TextBox>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">联系人：</td>
                        <td align="left" style="width: 410px;">
                            <asp:TextBox ID="txbContactPerson" Width="400" Height="22" runat="server" CssClass="easyui-validatebox"></asp:TextBox>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">手机号码：</td>
                        <td align="left" style="width: 410px;">
                            <asp:TextBox ID="txbUserMobileNO" Width="400" Height="22" runat="server" CssClass="easyui-validatebox"></asp:TextBox>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">电子邮箱：</td>
                        <td align="left" style="width: 410px;">
                            <asp:TextBox ID="txbEmail" Height="22" Width="400" runat="server" data-options="required:true" missingMessage="电子邮箱不能为空" validType="email" CssClass="easyui-validatebox"></asp:TextBox>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">公司网站：</td>
                        <td align="left" style="width: 410px;">
                            <asp:TextBox ID="txbEnterpriseWWW" Height="22" Width="400" runat="server" data-options="validType:'url'" CssClass="easyui-validatebox"></asp:TextBox>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">乘车路线：</td>
                        <td align="left" style="width: 410px;">
                            <asp:TextBox ID="txbBusRoute" Height="22" Width="400" runat="server" CssClass="easyui-validatebox"></asp:TextBox>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 14px;">
                            <span style="font-weight: bold; color: #f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                            <td style="font-size:14px; color:#6e6e6e;">企业简介：</td>
                            <td align="left" style="width:410px;" class="uploader orange">
                                <asp:TextBox ID="txbEnterpriseDescription" TextMode="MultiLine" Height="100" Width="400" runat="server"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:16px;">
                                <span style="font-weight:bold; color:#6e6e6e;"></span>
                            </td>
                        </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;">营业执照：</td>
                        <td align="left" style="width: 410px;" class="uploader orange">
                            <asp:FileUpload ID="uploadBusinessLicense" Width="400" runat="server" />
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 16px;">
                            <span style="font-weight: bold; color: #6e6e6e;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size: 14px; color: #6e6e6e;"></td>
                        <td align="left" style="width: 410px;" class="uploader orange">
                            <table style="width: 100%;">
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnSubmit" runat="server" Text="提 交" OnClientClick="return validata_Submit();" Width="150" Height="30" OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" style="color: #6e6e6e; font-size: 16px;">
                            <span style="font-weight: bold; color: #6e6e6e;"></span>
                        </td>
                    </tr>
                </table>
                <uc2:PageFooter ID="PageFooter1" runat="server" />
            </div>
        </div>
        <script type="text/javascript" src="Scripts/WebForms/jquery.artDialog.js"></script>
        <link type="text/css" href="skins/blue.css" rel="stylesheet" />
        <script type="text/javascript" src="Scripts/WebForms/iframeTools.js"></script>
    </form>
</body>
</html>
