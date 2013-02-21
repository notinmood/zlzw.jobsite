<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeSearchInfo.aspx.cs" Inherits="WebApp.ResumeSearchInfo" %>

<%@ Register Src="UserControl/EnterpriseHead.ascx" TagName="EnterpriseHead" TagPrefix="uc1" %>
<%@ Register Src="UserControl/PageFooter.ascx" TagName="PageFooter" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>简历查看</title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
    <link href="EasyUI/css/bootstrap/easyui.css" rel="stylesheet" />
    <link href="EasyUI/css/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.9.0.js"></script>
    <script type="text/javascript" src="EasyUI/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="Scripts/ResumeSearchList.js"></script>
    <script type="text/javascript" src="Scripts/jquery.watermark.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" Theme="Blue" AutoSizePanelID="Panel1" runat="server">
        </x:PageManager>
        <div>
            <uc1:EnterpriseHead ID="EnterpriseHead1" runat="server" />
            <table style="width: 100%;">
                <tr>
                    <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height: 3px;"></td>
                </tr>
            </table>
            <p></p>
            <table border="0" style="width:98%;padding-left:5%;">
                <tr>
                    <td colspan="8" style="background-image:url('image/img3.png'); background-repeat:repeat-x;height:35px;">
                        　<span style="color:#fff;font-size:16px; font-weight:bold;">基本信息</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="center">姓名:</td>
                    <td align="left">
                        <asp:Label ID="labUserName" runat="server"></asp:Label></td>
                    <td align="center">性别:</td>
                    <td align="left">
                        <asp:Label ID="labUserSex" runat="server"></asp:Label></td>
                    <td align="center">学历:</td>
                    <td align="left">
                        <asp:Label ID="labEducational" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="center">年龄:</td>
                    <td align="left">
                        <asp:Label ID="labUserAge" runat="server"></asp:Label></td>
                    <td align="center">电话:</td>
                    <td align="left">
                        <asp:Label ID="lanUserPhone" runat="server"></asp:Label></td>
                    <td align="center">原籍:</td>
                    <td align="left">
                        <asp:Label ID="labOrigin" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                     <td align="center">婚姻:</td>
                    <td align="left">
                        <asp:Label ID="labUserMarriage" runat="server"></asp:Label></td>
                    <td align="center">身高:</td>
                    <td align="left">
                        <asp:Label ID="labUserHeight" runat="server"></asp:Label></td>
                    <td align="center">体重:</td>
                    <td align="left">
                        <asp:Label ID="labUserWeight" runat="server"></asp:Label></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="center">状态:</td>
                    <td align="left">
                        <asp:Label ID="labJobCurrentWorkStatus" runat="server"></asp:Label></td>
                    <td align="center">现居住地:</td>
                    <td align="left">
                        <asp:Label ID="labCurrentResidence" runat="server"></asp:Label></td>
                     <td align="center">邮箱:</td>
                    <td align="left" colspan="2">
                        <asp:Label ID="labUserMail" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height:35px;"></td>
                </tr>
                <tr>
                    <td colspan="8" style="background-image:url('image/img3.png'); background-repeat:repeat-x;height:35px;">
                        　<span style="color:#fff;font-size:16px; font-weight:bold;">求职意向</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="center">期望职位:</td>
                    <td align="left">
                        <asp:Label ID="labJobPositionKinds" runat="server"></asp:Label></td>
                    <td align="center">期望行业:</td>
                    <td align="left">
                        <asp:Label ID="labJobFeildKinds" runat="server"></asp:Label></td>
                    <td align="center">期望食宿:</td>
                    <td align="left">
                        <asp:Label ID="labHopeRoomAndBoard" runat="server"></asp:Label></td>
                    <td align="center"></td>
                    <td align="left">
                         
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="center">期望薪资:</td>
                    <td align="left">
                        <asp:Label ID="labJobSalary" runat="server"></asp:Label></td>
                    <td align="center">当前薪资:</td>
                    <td align="left">
                        <asp:Label ID="labCurrentSalary" runat="server"></asp:Label></td>
                    <td align="center">求职性质:</td>
                    <td align="left">
                        <asp:Label ID="labJobWorkType" runat="server"></asp:Label> 
                    </td>
                    <td style="width: 60px;"></td>
                    <td></td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="center">期望地址:</td>
                    <td align="left">
                        <asp:Label ID="labJobWorkPlaceNames" runat="server"></asp:Label></td>
                    <td align="center">意向职位:</td>
                    <td align="left" colspan="7">
                        <asp:Label ID="labHopeJob" runat="server"></asp:Label></td>
                </tr>
                <tr style="font-size:14px;">
                    
                </tr>
                <tr>
                    <td style="height: 35px;"></td>
                </tr>
                <tr>
                    <td colspan="8" style="background-image:url('image/img3.png'); background-repeat:repeat-x;height:35px;">
                        　<span style="color:#fff;font-size:16px; font-weight:bold;">相关技能</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="center">个人技能:</td>
                    <td align="left" colspan="8">
                        <asp:Label ID="labPersonalSkills" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="center">技能证书:</td>
                    <td align="left" colspan="8">
                        <asp:Label ID="labSkillsCertificate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 35px;"></td>
                </tr>
                <tr>
                    <td colspan="8" style="background-image:url('image/img3.png'); background-repeat:repeat-x;height:35px;">
                        　<span style="color:#fff;font-size:16px; font-weight:bold;">工作经历</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="left" colspan="8">
                      　　<asp:Label ID="labWorkExperience" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 35px;"></td>
                </tr>
                <tr>
                    <td colspan="8" style="background-image:url('image/img3.png'); background-repeat:repeat-x;height:35px;">
                        　<span style="color:#fff;font-size:16px; font-weight:bold;">教育经历</span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px;"></td>
                </tr>
                <tr style="font-size:14px;">
                    <td align="left" colspan="8">
                       　　<asp:Label ID="labEducationExperience" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 35px;"></td>
                </tr>
                <tr>
                    <td colspan="8" align="center">
                        <asp:ImageButton ImageUrl="~/image/downloadJianLi.gif" ID="imgBtnDownload" runat="server" OnClick="imgBtnDownload_Click" Visible="false" />
                        <asp:ImageButton ImageUrl="~/image/fanhui.gif" ID="imgBtnReturn" runat="server" Visible="true" OnClick="imgBtnReturn_Click" />
                    </td>
                </tr>                
            </table>
            <uc2:PageFooter ID="PageFooter1" runat="server" />
        </div>
    </form>
</body>
</html>
