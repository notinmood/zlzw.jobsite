<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPublishJobInfo.aspx.cs" Inherits="WebApp.ViewPublishJobInfo" %>
<%@ Register Src="UserControl/EnterpriseHead.ascx" TagName="EnterpriseHead" TagPrefix="uc1" %>
<%@ Register Src="UserControl/PageFooter.ascx" TagName="PageFooter" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="青岛人才市场,青岛代缴保险,青岛劳务派遣,青岛人事代理,青岛人才网,城阳人才网,城阳人才市场,青岛北站人才市场,青岛招聘会" />
    <meta name="description" content="青岛人才市场(汽车北站)，由中劳网与青岛校企英才公司承办，位于汽车北站二楼大厅内，是覆盖青岛五市七区高中低多层次求职者的大型人力资源集散基地。市场业务范围：青岛人才市场招聘会,青岛人才市场网络招聘,青岛代缴保险,青岛劳务派遣,青岛人事代理,短工供应,就业安置等" />
    <title>职位查看</title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
    <link type="text/css" href="skins/blue.css" rel="stylesheet" />
</head>
<body style="margin:auto;padding:0;">
    <form id="form01" runat="server">
        <div style="border:1px solid #fff;">
            <uc1:EnterpriseHead ID="EnterpriseHead1" runat="server" />
            <div class="top2right">
                <div style="background-image: url('image/img3.png'); background-repeat: repeat-x; height:3px;"></div>
                <table border="0" cellspacing="0" cellpadding="0" style="width: 1003px;">
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
                        <td style="background-image:url('image/img3_long.png'); background-repeat:repeat-x;height:80px;" align="center">
                            <span style="font-size:14px;color:#fff;font-weight:bold;">　您已经发布了</span> <span style="font-size:20px;color:#093C7E;font-weight:bold;" id="labJobPublish" runat="server"></span><span style="font-size:14px;color:#fff;font-weight:bold;">个职位</span>
                            <br /><br />
                            <asp:Label ID="labView03" runat="server"></asp:Label>
                        </td>
                        <td style="width:15px;">

                        </td>
                        <td style="background-image:url('image/img3_long.png'); background-repeat:repeat-x;height:80px;" align="center">
                            <span style="font-size:14px;color:#fff;font-weight:bold;">　您还可以下载</span> <span style="font-size:20px;color:#093C7E;font-weight:bold;" id="labDownloadCount" runat="server"></span><span style="font-size:14px;color:#fff;font-weight:bold;">份简历</span>
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" style="width:100%; margin-left:22%;">
                    <tr>
                        <td style="height:25px;"></td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span style="color:#355f95; font-weight:bold; font-size:16px;">职位信息查看</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">岗位名称：<asp:Label ID="txbJobPositionName" Width="405" Height="22" runat="server"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">岗位类别:
                            <asp:Label id="txbJobPositionKinds" runat="server"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;">
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table> 
                                
                                
                        </td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">工作地点：<asp:Label ID="txbJobWorkPlaceNames" Width="405" Height="22" runat="server"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">综合薪资：<asp:Label ID="txbComprehensivePayroll" runat="server" Width="405" Height="26" CssClass="easyui-validatebox"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">食宿福利：<asp:Label ID="drpHopeRoomAndBoard" runat="server"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">性别要求：<asp:Label ID="drpNeedSex" runat="server"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">年龄要求：<asp:Label ID="txbNeedAge" CssClass="easyui-validatebox" Height="26" runat="server" Width="405">
                            </asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">学历要求：<asp:Label ID="drpUserEducationalBackground" runat="server">
                            </asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">联系电话：<asp:Label ID="txbContactTelephone" Height="22" Width="405" runat="server" CssClass="easyui-validatebox" validType="phone['#txbContactTelephone']"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">联 系 人：<asp:Label ID="txbContactPerson" Height="26" CssClass="easyui-validatebox" runat="server" Width="405"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">电子邮箱：<asp:Label ID="txbContactMail" CssClass="easyui-validatebox" validType="email" invalidMessage="电子邮箱格式错误" Height="26" runat="server" Width="405">
                            </asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">职位描述：<asp:Label ID="txbJobPositionDesc" runat="server"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">面试时间：<asp:Label ID="txbInterviewTime" runat="server" ></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">面试地点：<asp:Label ID="txbInterviewAddress" Text="汽车北站人才市场" Height="22" runat="server"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">工作性质：<asp:Label ID="drpJobWorkType" runat="server"></asp:Label>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr style="display:none;">
                        <td style="font-size:14px; color:#6e6e6e;">发布类型：<asp:DropDownList ID="drpSpecialType" Enabled="false" Height="26" runat="server" Width="405"></asp:DropDownList>
                        </td>
                        <td align="left" style="width:410px;"> 
                            &nbsp;</td>
                        <td align="left" style="color:#6e6e6e;font-size:14px;">
                            <span style="font-weight:bold; color:#f00;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:30px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e; text-align:center;">
                            <asp:Button ID="btnSubmit" runat="server" Text="职位删除" OnClientClick="return validata_Submit();" Width="150" Height="30" OnClick="btnSubmit_Click" />
                        </td>
                        <td align="left" style="width:410px;" class="uploader orange">
                            <table style="width:100%;">
                                <tr>
                                    <td align="center">
                                           
                                    </td>
                                    <td align="center">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" style="color:#6e6e6e;font-size:16px;">
                            <span style="font-weight:bold; color:#6e6e6e;"></span>
                        </td>
                    </tr>
                </table>
                <uc2:PageFooter ID="PageFooter1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
