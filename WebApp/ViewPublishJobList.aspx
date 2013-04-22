<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPublishJobList.aspx.cs" Inherits="WebApp.ViewPublishJobList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register Src="UserControl/EnterpriseHead.ascx" TagName="EnterpriseHead" TagPrefix="uc1" %>
<%@ Register Src="UserControl/PageFooter.ascx" TagName="PageFooter" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="青岛人才市场,青岛代缴保险,青岛劳务派遣,青岛人事代理,青岛人才网,城阳人才网,城阳人才市场,青岛北站人才市场,青岛招聘会" />
    <meta name="description" content="青岛人才市场(汽车北站)，由中劳网与青岛校企英才公司承办，位于汽车北站二楼大厅内，是覆盖青岛五市七区高中低多层次求职者的大型人力资源集散基地。市场业务范围：青岛人才市场招聘会,青岛人才市场网络招聘,青岛代缴保险,青岛劳务派遣,青岛人事代理,短工供应,就业安置等" />
    <title id="titleName" runat="server">已发布职位</title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
    <link href="EasyUI/css/bootstrap/easyui.css" rel="stylesheet" />
    <link href="EasyUI/css/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.9.0.js"></script>
    <script type="text/javascript" src="EasyUI/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="Scripts/ResumeSearchList.js"></script>
</head>
<body style="margin:auto;padding:0;">
    <form id="form01" runat="server">
        <div style="border:1px solid #fff;">
            <uc1:EnterpriseHead ID="EnterpriseHead1" runat="server" />
            <div class="top2right">
                <table style="width: 100%;">
                    <tr>
                        <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height: 3px;"></td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;">
                    <tr>
                        <td style="height: 25px;">
                            
                        </td>
                    </tr>
                   
                </table>
                <table style="width:100%; font-size:14px;" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="6" style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td align="center" id="tdqiuzhi" runat="server">所属企业</td>
                        <td align="center">岗位名称</td>
                        <td align="center">岗位类别</td>
                        <td align="center">联系电话</td>
                        <td align="center" id="tdPublishDate" runat="server">发布日期</td>
                        <td align="center">操作</td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height:15px;"></td>
                    </tr>
                    <tr>
                        <td width="100%;" height="1px" colspan="6" style="background-color: #999999; background-repeat: repeat-x;"></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="height:15px;"></td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><asp:Label ID="labEnterpriseName" runat="server"></asp:Label></span></td>
                                <td align="center"><asp:Label ID="labJobName" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labJobType" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labLinkTel" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labPublishDate" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labDel" runat="server"></asp:Label> 　<asp:LinkButton ID="libkBtnDel" runat="server" OnClick="libkBtnDel_Click" style="text-decoration:none;color:#FA7D00;font-weight:bold;">删除</asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                        <SeparatorTemplate>
                                <tr><td colspan="6" style="height:30px;"></td></tr>
                        </SeparatorTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="6" style="height:50px;" align="center">
                            <asp:Label Visible="true" runat="server" ID="labDataIsNull" style="color:#093C7E; font-size:30px; font-weight:bold;" Text="暂无下载简历"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="1" 
                                onpagechanged="AspNetPager1_PageChanged" CssClass="paginator" CurrentPageButtonClass="cpb" FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" >
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                </table>
                <uc2:PageFooter ID="PageFooter1" runat="server" />
            </div>
        </div>
        <input id="Hidden1" type="hidden" runat="server" />
        <input id="Hidden2" type="hidden" runat="server" />
        <script type="text/javascript" src="Scripts/WebForms/jquery.artDialog.js"></script>
        <link type="text/css" href="skins/blue.css" rel="stylesheet" />
        <script type="text/javascript" src="Scripts/WebForms/iframeTools.js"></script>
        <script type="text/javascript" src="Scripts/WebForms/jquery.watermark.min.js"></script>
    </form>
</body>
</html>
