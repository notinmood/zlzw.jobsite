<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CareerGuidanceInfo.aspx.cs" Inherits="WebApp.CareerGuidanceInfo" %>
<%@ Register src="UserControl/PageHead.ascx" tagname="PageHead" tagprefix="uc1" %>
<%@ Register src="UserControl/PageFooter.ascx" tagname="PageFooter" tagprefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="keywords" content="青岛人才市场,青岛代缴保险,青岛劳务派遣,青岛人事代理,青岛人才网,城阳人才网,城阳人才市场,青岛北站人才市场,青岛招聘会" />
    <meta name="description" content="青岛人才市场(汽车北站)，由中劳网与青岛校企英才公司承办，位于汽车北站二楼大厅内，是覆盖青岛五市七区高中低多层次求职者的大型人力资源集散基地。市场业务范围：青岛人才市场招聘会,青岛人才市场网络招聘,青岛代缴保险,青岛劳务派遣,青岛人事代理,短工供应,就业安置等" />
    <title id="labNavigateTitle" runat="server"></title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:PageHead ID="PageHead1" runat="server" />
            <div style="-margin-left:200px;">
                <table style="width:1003px;">
                    <tr>
                        <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height:1px;">
                                
                        </td>
                    </tr>
                </table>
                <table style="width:100%; line-height:30px;-margin-left:70px">
                    <tr>
                        <td>
                            　<a href="default.aspx" style="color:#093C7E; text-decoration:none;">首页</a> > <a href="CareerGuidanceList.aspx" style="color:#093C7E; text-decoration:none;">就业指导</a> > <asp:Label ID="labNavTitle" runat="server" style="color:#093C7E;"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="labTitle" runat="server" style="font-size:18px;font-weight:bold;"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="labPublishDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="labContent" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table> 
                <uc2:PageFooter ID="PageFooter1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
