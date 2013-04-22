<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParticipatingCompaniesInfo.aspx.cs" Inherits="WebApp.ParticipatingCompaniesInfo" %>
<%@ Register src="UserControl/DefaultHead.ascx" tagname="DefaultHead" tagprefix="uc1" %>
<%@ Register src="UserControl/DefaultFooter.ascx" tagname="DefaultFooter" tagprefix="uc2" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="keywords" content="青岛人才市场,青岛代缴保险,青岛劳务派遣,青岛人事代理,青岛人才网,城阳人才网,城阳人才市场,青岛北站人才市场,青岛招聘会" />
    <meta name="description" content="青岛人才市场(汽车北站)，由中劳网与青岛校企英才公司承办，位于汽车北站二楼大厅内，是覆盖青岛五市七区高中低多层次求职者的大型人力资源集散基地。市场业务范围：青岛人才市场招聘会,青岛人才市场网络招聘,青岛代缴保险,青岛劳务派遣,青岛人事代理,短工供应,就业安置等" />
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
                <table style="width:100%; line-height:30px;">
                    <tr>
                        <td>
                            　<a href="default.aspx" style="color:#093C7E; text-decoration:none;">首页</a> > <a href="ParticipatingCompaniesList.aspx" style="color:#093C7E;text-decoration:none;">招聘会参加企业</a> > <asp:Label ID="labNavigate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="border:1px solid; border-color:#e9e1e1;">
                                <table style="width:100%;" border="0">
                                <tr>
                                    <td colspan="2" align="center">
                                        <h2 style="color:#093C7E; font-weight:bold;"><asp:Label ID="labTitle" runat="server"></asp:Label></h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width:50%;color:#093C7E;">
                                        <%--发布人：<asp:Label ID="labPublishName" runat="server"></asp:Label>--%>　
                                    </td>
                                    <td style="color:#093C7E;">
                                        　发布日期：<asp:Label ID="labDateTime" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding:20px 80px 10px 80px;">
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
