<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParticipatingCompaniesList.aspx.cs" Inherits="WebApp.ParticipatingCompaniesList" %>
<%@ Register src="UserControl/DefaultHead.ascx" tagname="DefaultHead" tagprefix="uc1" %>
<%@ Register src="UserControl/DefaultFooter.ascx" tagname="DefaultFooter" tagprefix="uc2" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>招聘会参加企业</title>
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
                <table style="width:90%; line-height:30px;">
                    <tr>
                        <td>
                            　<a href="default.aspx" style="color:#093C7E; text-decoration:none;">首页</a> > <span style="color:#093C7E;">招聘会参加企业</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <%--<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr style="padding:0px 0px 0px 30px;">
                                <td style="padding-left:20px;">
                                    <asp:Label ID="labTitle" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="labPubnlishDate" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="2" style="padding:0px 0px 0px 30px;">
                                    <asp:Label ID="labContent" runat="server"></asp:Label>
                                </td>
                            </tr>
                        <%--</ItemTemplate>
                        <SeparatorTemplate>--%>
                            <tr><td style="height:30px;"></td></tr>
                        <%--</SeparatorTemplate>
                    </asp:Repeater>--%>
                    <tr>
                        <td style="padding-left:40%;">
                           <%-- <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="15" 
                                onpagechanged="AspNetPager1_PageChanged" CssClass="paginator" CurrentPageButtonClass="cpb" FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" >
                            </webdiyer:AspNetPager>--%>
                        </td>
                    </tr>
                </table> 
                <uc2:DefaultFooter ID="DefaultFooter1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
