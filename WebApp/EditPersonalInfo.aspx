<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EditPersonalInfo.aspx.cs" Inherits="WebApp.EditPersonalInfo" %>
<%@ Register src="UserControl/PageHead.ascx" tagname="PageHead" tagprefix="uc1" %>
<%@ Register src="UserControl/PageFooter.ascx" tagname="PageFooter" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="青岛人才市场,青岛代缴保险,青岛劳务派遣,青岛人事代理,青岛人才网,城阳人才网,城阳人才市场,青岛北站人才市场,青岛招聘会" />
    <meta name="description" content="青岛人才市场(汽车北站)，由中劳网与青岛校企英才公司承办，位于汽车北站二楼大厅内，是覆盖青岛五市七区高中低多层次求职者的大型人力资源集散基地。市场业务范围：青岛人才市场招聘会,青岛人才市场网络招聘,青岛代缴保险,青岛劳务派遣,青岛人事代理,短工供应,就业安置等" />
    <title>个人用户信息修改</title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
    <link href="EasyUI/css/bootstrap/easyui.css" rel="stylesheet" />
    <link href="EasyUI/css/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.9.0.js"></script>
    <script type="text/javascript" src="EasyUI/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="Scripts/WebForms/jquery.watermark.min.js"></script>
    <script type="text/javascript" src="Scripts/EditPersonalRegistrationInfo.js"></script>
</head>
<body>
    <form id="form01" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" Theme="Blue" />
        <div>
            <uc1:PageHead ID="PageHead1" runat="server" />
            <div class="top2right">
                    <table style="width:100%;">
                        <tr>
                            <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height:3px;">
                                
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" style="width:100%; margin-left:15%;">
                        <tr>
                            <td style="height:25px;"></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span style="color:#355f95; font-weight:bold; font-size:16px;">账号修改</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e; width:100px;">账号：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbUserName" runat="server" Height="22" Width="400" CssClass="easyui-validatebox" data-options="required:true,validType:['length[6,10]','RepeatRegisterName[txbUserName]']" missingMessage="账号不能为空" ></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;">*</span> 账号为6-10位英文字母或数字
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">密码：</td>
                            <td align="left" style="width:410px;">
                                <asp:TextBox ID="txbPassword" TextMode="Password" Height="22" runat="server" Width="400" CssClass="easyui-validatebox" data-options="required:true" missingMessage="密码不能为空" validType="length[6,10]"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;">*</span> 密码为6-10位英文字母或数字
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">确认密码：</td>
                            <td align="left" style="width:410px;">
                                <asp:TextBox ID="txbPassword01" TextMode="Password" Height="22" runat="server" Width="400" CssClass="easyui-validatebox" data-options="required:true" missingMessage="确认密码不能为空" validType="equalTo['#txbPassword']" invalidMessage="两次输入密码不匹配"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;">*</span> 请确保与密码输入一致
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span style="color:#355f95; font-weight:bold; font-size:16px;">基本资料</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">姓名：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbUserNameCN" runat="server" Height="22" Width="400" CssClass="easyui-validatebox" data-options="required:true" missingMessage="姓名不能为空"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">性别：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:DropDownList ID="drpUserSex" CssClass="easyui-combobox" Height="26" Width="405" runat="server">
                                    <asp:ListItem Text="女" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">学历：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:DropDownList ID="drpUserEducationalBackground" CssClass="easyui-combobox" Height="26" Width="405" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">出生日期：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbUserBirthDay" Width="405" Height="26" runat="server" CssClass="easyui-datebox" data-options="required:true" missingMessage="出生日期不能为空" validType="DateFormatTo['#txbUserBirthDay']" invalidMessage="日期格式错误"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">联系电话：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbUserMobileNO" Width="400" Height="22" runat="server" CssClass="easyui-validatebox" data-options="required:true" missingMessage="联系电话不能为空" validType="MobilTo['#txbWorkTelphone']" invalidMessage="电话格式错误"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">户口原籍：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbUserCountry" Width="400" Height="22" runat="server" CssClass="easyui-validatebox" data-options="required:true" missingMessage="户口原籍不能为空" ></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">现居住地：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbCurrentResidence" Width="400" Height="22" runat="server" CssClass="easyui-validatebox" data-options="required:true" missingMessage="现居住地不能为空" ></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">电子信箱：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbUserEmail" Width="400" Height="22" runat="server" CssClass="easyui-validatebox" data-options="required:true,validType:'email'" missingMessage="电子信箱不能为空" invalidMessage="电子信箱格式错误"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span style="color:#355f95; font-weight:bold; font-size:16px;">求职意向</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">职位类别：</td>
                            <td align="left" style="width:410px;">
                                <table>
                                    <tr>
                                        <%--<td>
                                            <asp:DropDownList ID="drpJobPositionKindsType" runat="server" Height="26" Width="100">
                                                <asp:ListItem Text="非管理" Value="非管理" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="管理" Value="管理"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpJobPositionKinds" Height="26" runat="server" Width="300"></asp:DropDownList>
                                        </td>--%>
                                        <td colspan="2">
                                            <input type="text" runat="server" id="txbJobPositionKinds" class="easyui-validatebox" data-options="required:true" missingMessage="请选择岗位类别" style="width: 400px; height: 22px;" readonly="readonly" />
                                        </td>
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
                            <td style="font-size:14px; color:#6e6e6e;">期望行业：</td>
                            <td align="left" style="width:410px;">
                                <table>
                                    <tr>
                                        <%--<td>
                                            <asp:DropDownList ID="drpJobFeildKindsType" Height="26" Width="100" runat="server">
                                                <asp:ListItem Text="制造行业" Value="制造行业" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="第三产业" Value="第三产业"></asp:ListItem>
                                                <asp:ListItem Text="第一产业" Value="第一产业"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpJobFeildKinds" Height="26" runat="server" Width="300"></asp:DropDownList>
                                        </td>--%>
                                        <td colspan="2">
                                            <input runat="server" type="text" id="txbJobFeildKinds" class="easyui-validatebox" data-options="required:true" missingMessage="请选择行业类别" style="width: 400px; height: 22px;" readonly="readonly" />
                                        </td>
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
                            <td style="font-size:14px; color:#6e6e6e;">意向职位名称：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbHopeJob" Width="400" Height="22" runat="server" CssClass="easyui-validatebox"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">期望地址：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbJobWorkPlaceNames" Width="400" Height="22" runat="server" CssClass="easyui-validatebox"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">期望食宿：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:DropDownList ID="drpHopeRoomAndBoard" CssClass="easyui-combobox" Height="26" runat="server" Width="405">
                                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">期望薪资：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:DropDownList ID="drpJobSalary" CssClass="easyui-combobox" Height="26" runat="server" Width="405">
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">个人技能：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbPersonalSkills" Height="22" TextMode="MultiLine" Width="400" runat="server" CssClass="easyui-validatebox"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">技能证书：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbSkillsCertificate" Height="22" TextMode="MultiLine" Width="400" runat="server" CssClass="easyui-validatebox"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">当前状态：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:DropDownList ID="drpJobCurrentWorkStatus" Height="26" CssClass="easyui-combobox" runat="server" Width="405">
                                    <asp:ListItem Text="离职" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="在职" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">当前薪资：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:DropDownList ID="drpCurrentSalary" CssClass="easyui-combobox" Height="26" runat="server" Width="405">
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">求职性质：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:DropDownList ID="drpJobWorkType" CssClass="easyui-combobox" Height="26" runat="server" Width="405">
                                </asp:DropDownList>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span style="color:#355f95; font-weight:bold; font-size:16px;">详细信息</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;" valign="top">工作经历：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbWorkExperience" Height="100" runat="server" TextMode="MultiLine" Width="400" CssClass="easyui-validatebox"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;" valign="top">教育经历：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbEducationExperience" Height="100" runat="server" TextMode="MultiLine" Width="400" CssClass="easyui-validatebox"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">婚姻状况：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:DropDownList ID="drpMaritalStatus" CssClass="easyui-combobox" Height="26" runat="server" Width="405"></asp:DropDownList>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:14px;">
                                <span style="font-weight:bold; color:#f00;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">身高：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbUserHeight" runat="server" Height="22" Width="400" CssClass="easyui-validatebox" validType="intOrFloat['#txbUserHeight']"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:16px;">
                                <span style="font-weight:bold; color:#6e6e6e;">cm</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">体重：</td>
                            <td align="left" style="width:410px;"> 
                                <asp:TextBox ID="txbUserWeight" runat="server" Height="22" Width="400" CssClass="easyui-validatebox" validType="intOrFloat['#txbUserWeight']" missingMessage="体重格式不正确"></asp:TextBox>
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:16px;">
                                <span style="font-weight:bold; color:#6e6e6e;">kg</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;">照片：</td>
                            <td align="left" style="width:410px;" class="uploader orange">
                                <asp:FileUpload ID="uploadUserPhoto" Width="400" runat="server" />
                            </td>
                            <td align="left" style="color:#6e6e6e;font-size:16px;">
                                <span style="font-weight:bold; color:#6e6e6e;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:30px;"></td>
                        </tr>
                        <tr>
                            <td style="font-size:14px; color:#6e6e6e;"></td>
                            <td align="left" style="width:410px;" class="uploader orange">
                                <table style="width:100%;">
                                    <tr>
                                        <td align="center">
                                           <%-- <asp:Button ID="btnPreview" runat="server" Text="简历预览" />--%>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btnSubmit" runat="server" Text="简历提交" OnClientClick="return validata_Submit();" Width="150" Height="30" OnClick="btnSubmit_Click" />
                                        </td>
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
        <link type="text/css" href="skins/blue.css" rel="stylesheet" />
        <script type="text/javascript" src="Scripts/WebForms/iframeTools.js"></script>
    </form>                 
</body>
</html>
