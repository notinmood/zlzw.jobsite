<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeBehind="JobPosting.aspx.cs" Inherits="WebApp.JobPosting" %>
<%@ Register src="UserControl/EnterpriseHead.ascx" tagname="EnterpriseHead" tagprefix="uc1" %>
<%@ Register src="UserControl/PageFooter.ascx" tagname="PageFooter" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>企业职位发布</title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
    <link href="EasyUI/css/bootstrap/easyui.css" rel="stylesheet" />
    <link href="EasyUI/css/icon.css" rel="stylesheet" />
    <link type="text/css" href="skins/blue.css" rel="stylesheet" />
    <script type="text/javascript" src="http://lib.sinaapp.com/js/jquery/1.9.0/jquery.min.js"></script>
    <script type="text/javascript" src="http://lib.sinaapp.com/js/jquery-ui/1.9.0/jquery-ui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="Scripts/WebForms/jquery.watermark.min.js"></script>
    
</head>
<body>
    <form id="form01" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" Theme="Blue" />
        <div>
            <uc1:EnterpriseHead ID="EnterpriseHead1" runat="server" />
            <div class="top2right">
                <table style="width:100%;">
                    <tr>
                        <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height:3px;">
                                
                        </td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" style="width: 86%; margin-left: 8%;">
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
                <table border="0" cellspacing="0" cellpadding="0" style="width:100%; margin-left:22%;">
                    <tr>
                        <td style="height:25px;"></td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span style="color:#355f95; font-weight:bold; font-size:16px;">职位发布</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">岗位名称：<asp:TextBox ID="txbJobPositionName" data-options="required:true" missingMessage="岗位名称不能为空" Width="405" Height="22" runat="server" CssClass="easyui-validatebox"></asp:TextBox><span style="font-weight:bold; color:#f00;"> *</span>
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
                                        <%--<asp:DropDownList ID="drpJobPositionKindsType" runat="server" Height="26" Width="100">
                                            <asp:ListItem Text="非管理" Value="非管理" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="管理" Value="管理"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="drpJobPositionKinds" Height="26" runat="server" Width="300"></asp:DropDownList>--%>
                                        <input runat="server" type="text" id="txbJobPositionKinds" class="easyui-validatebox" data-options="required:true" missingMessage="请选择行业类别" style="width: 400px; height: 22px;" readonly="readonly" /><span style="font-weight:bold; color:#f00;"> *</span>
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
                    <%--<tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">岗位类别：<asp:DropDownList ID="drpJobFeildKindsType" Height="26" Width="100" runat="server">
                                            <asp:ListItem Text="制造行业" Value="制造行业" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="第三产业" Value="第三产业"></asp:ListItem>
                                            <asp:ListItem Text="第一产业" Value="第一产业"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="drpJobFeildKinds" Height="26" runat="server" Width="300"></asp:DropDownList>
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
                    </tr>--%>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td style="font-size:14px; color:#6e6e6e;">工作地点：<asp:TextBox ID="txbJobWorkPlaceNames" data-options="required:true" missingMessage="工作地点不能为空" Width="405" Height="22" runat="server" CssClass="easyui-validatebox"></asp:TextBox><span style="font-weight:bold; color:#f00;"> *</span>
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
                        <td style="font-size:14px; color:#6e6e6e;">综合薪资：<asp:TextBox ID="txbComprehensivePayroll" runat="server" Width="405" Height="26" CssClass="easyui-validatebox"></asp:TextBox>
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
                        <td style="font-size:14px; color:#6e6e6e;">食宿福利：<asp:DropDownList ID="drpHopeRoomAndBoard" Height="26" runat="server" Width="405">
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                                <asp:ListItem Text="否" Value="0"></asp:ListItem>
                            </asp:DropDownList>
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
                        <td style="font-size:14px; color:#6e6e6e;">性别要求：<asp:DropDownList ID="drpNeedSex" CssClass="easyui-validatebox" Height="26" runat="server" Width="405">
                                <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="女" Value="0"></asp:ListItem>
                                <asp:ListItem Text="不限" Value="2"></asp:ListItem>
                            </asp:DropDownList>
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
                        <td style="font-size:14px; color:#6e6e6e;">年龄要求：<asp:TextBox ID="txbNeedAge" CssClass="easyui-validatebox" Height="26" runat="server" Width="405">
                            </asp:TextBox>
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
                        <td style="font-size:14px; color:#6e6e6e;">学历要求：<asp:DropDownList ID="drpUserEducationalBackground" Height="26" Width="405" runat="server">
                            </asp:DropDownList>
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
                        <td style="font-size:14px; color:#6e6e6e;">联系电话：<asp:TextBox ID="txbContactTelephone" Height="22" Width="405" runat="server" CssClass="easyui-validatebox" validType="phone['#txbContactTelephone']"></asp:TextBox>
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
                        <td style="font-size:14px; color:#6e6e6e;">联 系 人：<asp:TextBox ID="txbContactPerson" Height="26" CssClass="easyui-validatebox" runat="server" Width="405"></asp:TextBox>
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
                        <td style="font-size:14px; color:#6e6e6e;">电子邮箱：<asp:TextBox ID="txbContactMail" CssClass="easyui-validatebox" validType="email" invalidMessage="电子邮箱格式错误" Height="26" runat="server" Width="405">
                            </asp:TextBox>
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
                        <td style="font-size:14px; color:#6e6e6e;"><div style="float:left; padding-top:70px;">职位描述：</div><asp:Textbox ID="txbJobPositionDesc" TextMode="MultiLine" data-options="required:true" missingMessage="职位描述不能为空" CssClass="easyui-validatebox" Height="150" runat="server" Width="400">
                            </asp:Textbox><div style="font-weight:bold; color:#f00; float:right; padding-right:15%;padding-top:70px;"> *</div>
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
                        <td style="font-size:14px; color:#6e6e6e;">面试时间：<asp:TextBox ID="txbInterviewTime" Height="26" runat="server" Text="每周二四六上午" Width="405" CssClass="easyui-datebox"></asp:TextBox>
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
                        <td style="font-size:14px; color:#6e6e6e;">面试地点：<asp:TextBox ID="txbInterviewAddress" Text="汽车北站人才市场" Height="22" runat="server" Width="405" CssClass="easyui-validatebox"></asp:TextBox>
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
                        <td style="font-size:14px; color:#6e6e6e;">工作性质：<asp:DropDownList ID="drpJobWorkType" Height="26" runat="server" Width="405"></asp:DropDownList>
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
                            <asp:Button ID="btnSubmit" runat="server" Text="发布职位" OnClientClick="return validata_Submit();" Width="150" Height="30" OnClick="btnSubmit_Click" />
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
        <script type="text/javascript" src="Scripts/WebForms/jquery.artDialog.js"></script>
        
        <script type="text/javascript" src="Scripts/WebForms/iframeTools.js"></script>
        <script type="text/javascript" src="Scripts/JobPosting.js"></script>
    </form>
</body>
</html>
