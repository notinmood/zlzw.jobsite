<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantsJoin.aspx.cs" Inherits="WebApp.MerchantsJoin" %>

<%@ Register Src="UserControl/PageHead.ascx" TagName="PageHead" TagPrefix="uc1" %>
<%@ Register Src="UserControl/PageFooter.ascx" TagName="PageFooter" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="青岛人才市场,青岛代缴保险,青岛劳务派遣,青岛人事代理,青岛人才网,城阳人才网,城阳人才市场,青岛北站人才市场,青岛招聘会" />
    <meta name="description" content="青岛人才市场(汽车北站)，由中劳网与青岛校企英才公司承办，位于汽车北站二楼大厅内，是覆盖青岛五市七区高中低多层次求职者的大型人力资源集散基地。市场业务范围：青岛人才市场招聘会,青岛人才市场网络招聘,青岛代缴保险,青岛劳务派遣,青岛人事代理,短工供应,就业安置等" />
    <title id="titleName" runat="server"></title>
    <link href="css/zong.css" type="text/css" rel="stylesheet" />
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:PageHead ID="PageHead1" runat="server" />
            <div style="-margin-left:220px;">
                <table style="width:1003px;">
                    <tr>
                        <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height: 3px;"></td>
                    </tr>
                </table>
                <table style="width: 100%; line-height: 30px;" border="0">
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                    <tr>
                        <td>
                            <div style="float: left; border: 1px solid; border-color: #e9e1e1; height: 100%; width: 19%; margin-left: 15px; text-align: center;">
                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                    <HeaderTemplate>
                                        <table style="width: 100%; font-size: 14px;">
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
                            </div>
                            <div style="float: left; border: 1px solid; border-color: #e9e1e1; margin-left: 20px; width: 74%;">
                                <table style="width: 100%;" border="0">
                                    <tr>
                                        <td colspan="2" style="padding: 10px 30px 10px 30px;">
                                            <asp:Label ID="labContent" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <uc2:PageFooter ID="PageFooter1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
