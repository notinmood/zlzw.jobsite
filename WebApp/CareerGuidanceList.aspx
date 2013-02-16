<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CareerGuidanceList.aspx.cs" Inherits="WebApp.CareerGuidanceList" %>
<%@ Register src="UserControl/PageHead.ascx" tagname="PageHead" tagprefix="uc1" %>
<%@ Register src="UserControl/PageFooter.ascx" tagname="PageFooter" tagprefix="uc2" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>就业指导</title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:PageHead ID="PageHead1" runat="server" />
            <div>
                <table style="width:100%;">
                    <tr>
                        <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height:1px;">
                                
                        </td>
                    </tr>
                </table>
                <table style="width:100%; line-height:30px;">
                    <tr>
                        <td>
                            　<a href="default.aspx" style="color:#093C7E; text-decoration:none;">首页</a> > <span style="color:#093C7E;">就业指导</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:20px;"></td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td style="padding-left:20px;">
                                    <asp:Label ID="CareerGuidanceTitle" style="font-size:14px;" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td style="padding-left:40%;">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="15" 
                                onpagechanged="AspNetPager1_PageChanged" CssClass="paginator" CurrentPageButtonClass="cpb" FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" >
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                </table> 
                <uc2:PageFooter ID="PageFooter1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
