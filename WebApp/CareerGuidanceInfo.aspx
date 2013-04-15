<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CareerGuidanceInfo.aspx.cs" Inherits="WebApp.CareerGuidanceInfo" %>
<%@ Register src="UserControl/PageHead.ascx" tagname="PageHead" tagprefix="uc1" %>
<%@ Register src="UserControl/PageFooter.ascx" tagname="PageFooter" tagprefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
