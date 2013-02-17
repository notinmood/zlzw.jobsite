<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeSearchInfo.aspx.cs" Inherits="WebApp.TemplatePage.ResumeSearchInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="http://lib.sinaapp.com/js/jquery/1.9.0/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/WebForms/jquery.artDialog.js"></script>
    <script type="text/javascript" src="../Scripts/WebForms/iframeTools.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellspacing="8" style="font-size:14px;">
            <tr>
                <td align="center">姓　　名:</td>
                <td align="left"><asp:Label ID="labUserName" runat="server"></asp:Label></td>
                <td align="center">性　　别:</td>
                <td align="left"><asp:Label ID="labUserSex" runat="server"></asp:Label></td>
                <td align="center">学　　历:</td>
                <td align="left"><asp:Label ID="labEducational" runat="server"></asp:Label></td>
                <td align="center">年　　龄:</td>
                <td align="left"><asp:Label ID="labUserAge" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">电　　话:</td>
                <td align="left"><asp:Label ID="lanUserPhone" runat="server"></asp:Label></td>
                <td align="center">原　　籍:</td>
                <td align="left"><asp:Label ID="labOrigin" runat="server"></asp:Label></td>
                <td align="center">婚　　姻:</td>
                <td align="left"><asp:Label ID="labUserMarriage" runat="server"   ></asp:Label></td>
                <td align="center">当前状态:</td>
                <td align="left"><asp:Label ID="labJobCurrentWorkStatus" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">期望食宿:</td>
                <td align="left"><asp:Label ID="labHopeRoomAndBoard" runat="server"></asp:Label></td>
                <td align="center">期望薪资:</td>
                <td align="left"><asp:Label ID="labJobSalary" runat="server"></asp:Label></td>
                <td align="center">身　　高:</td>
                <td align="left"><asp:Label ID="labUserHeight" runat="server"></asp:Label></td>
                <td align="center">体　　重:</td>
                <td align="left"><asp:Label ID="labUserWeight" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">求职性质:</td>
                <td align="left"><asp:Label ID="labJobWorkType" runat="server"></asp:Label></td>
                <td align="center">当前薪资:</td>
                <td align="left"><asp:Label ID="labCurrentSalary" runat="server"></asp:Label></td>
                
                <td></td>
                <td></td>
                <td style="width:60px;"></td>
                <td></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">个人技能:</td>
                <td align="left" colspan="3"><asp:Label ID="labPersonalSkills" runat="server"></asp:Label></td>
                <td align="center">技能证书:</td>
                <td align="left" colspan="3"><asp:Label ID="labSkillsCertificate" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">现居住地:</td>
                <td align="left" colspan="3"><asp:Label ID="labCurrentResidence" runat="server"></asp:Label></td>
                <td align="center">电子信箱:</td>
                <td align="left" colspan="3"><asp:Label ID="labUserMail" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">期望职位:</td>
                <td align="left" colspan="3"><asp:Label ID="labJobPositionKinds" runat="server"></asp:Label></td>
                <td align="center">期望行业:</td>
                <td align="left" colspan="3"><asp:Label ID="labJobFeildKinds" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">意向职位</td>
                <td align="left" colspan="7"><asp:Label ID="labHopeJob" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">期望地址:</td>
                <td align="left" colspan="7"><asp:Label ID="labJobWorkPlaceNames" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">工作经历:</td>
                <td align="left" colspan="7"><asp:Label ID="labWorkExperience" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td align="center">教育经历:</td>
                <td align="left" colspan="7"><asp:Label ID="labEducationExperience" runat="server"></asp:Label></td>
            </tr>
        </table>
    </form>
</body>
</html>
