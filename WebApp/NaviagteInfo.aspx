<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NaviagteInfo.aspx.cs" Inherits="WebApp.NaviagteInfo" %>
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
                                            <tr>
                                                <td style="width:100%;"><a style="text-decoration:none;color:#fff;color:#093C7E;" href="default.aspx">网站首页</a></td>
                                            </tr>
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
                <uc2:DefaultFooter ID="DefaultFooter1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
