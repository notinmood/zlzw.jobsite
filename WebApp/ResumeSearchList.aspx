<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumeSearchList.aspx.cs" Inherits="WebApp.ResumeSearchList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register Src="UserControl/EnterpriseHead.ascx" TagName="EnterpriseHead" TagPrefix="uc1" %>
<%@ Register Src="UserControl/PageFooter.ascx" TagName="PageFooter" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>简历搜索</title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet" />
    <link href="EasyUI/css/bootstrap/easyui.css" rel="stylesheet" />
    <link href="EasyUI/css/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.9.0.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.9.0.js"></script>
    <script type="text/javascript" src="EasyUI/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="Scripts/ResumeSearchList.js"></script>
</head>
<body>
    <form id="form01" runat="server">
        <div>
            <uc1:EnterpriseHead ID="EnterpriseHead1" runat="server" />
            <div class="top2right">
                <table style="width: 100%;">
                    <tr>
                        <td style="background-image: url('image/img3.png'); background-repeat: repeat-x; height: 3px;"></td>
                    </tr>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;">
                    <tr>
                        <td style="height: 25px;"></td>
                    </tr>
                    <tr>
                        <td>
                            <div class="top2righttop">
                                <table style="padding-left: 80px;" width="757" height="70" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <input type="text" runat="server" id="txbJobPositionKinds" class="easyui-validatebox" style="width: 133px; height: 18px;" readonly="readonly" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpSex" runat="server" Width="139" Height="23">
                                                <asp:ListItem Text="请选择性别" Value="-1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="不限" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="男" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="女" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <input id="txbWorkAreas" runat="server" type="text" class="easyui-validatebox" style="width: 193px; height: 18px;" readonly="readonly" />
                                        </td>
                                        <td rowspan="2">
                                            <asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="image/SearchJIanLi.png" OnClientClick="return validatorForm();" OnClick="imgBtnSearch_Click" style="height: 34px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input runat="server" type="text" id="txbJobFeildKinds" class="easyui-validatebox" style="width: 133px; height: 18px;" readonly="readonly" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpShiSu" runat="server" style="width:139px;height:22px;">
                                                <asp:ListItem Value="-1" Selected="True">请选择食宿要求</asp:ListItem>
                                                <asp:ListItem Value="0">不限</asp:ListItem>
                                                <asp:ListItem Value="1">提供食宿</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <input runat="server" type="text" id="txbSearchKey" style="width: 193px; height: 18px;" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table style="width:100%; font-size:14px;" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="8" style="height:20px;"></td>
                    </tr>
                    <tr>
                        <td align="center">求职者</td>
                        <td align="center">期望食宿</td>
                        <td align="center">期望行业</td>
                        <td align="center">期望岗位</td>
                        <td align="center">性别</td>
                        <td align="center">年龄</td>
                        <td align="center">更新日期</td>
                        <td align="center">操作</td>
                    </tr>
                    <tr>
                        <td colspan="8" style="height:15px;"></td>
                    </tr>
                    <tr>
                        <td width="100%;" height="1px" colspan="8" style="background-color: #999999; background-repeat: repeat-x;"></td>
                    </tr>
                    <tr>
                        <td colspan="8" style="height:15px;"></td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td align="center"><asp:Label ID="labJobName" runat="server"></asp:Label></span></td>
                                <td align="center"><asp:Label ID="labShiSu" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labHangye" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labGangwei" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labSex" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labAge" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labPublishDate" runat="server"></asp:Label></td>
                                <td align="center"><asp:Label ID="labView" runat="server"></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        <SeparatorTemplate>
                                <tr><td colspan="8" style="height:30px;"></td></tr>
                        </SeparatorTemplate>
                    </asp:Repeater>
                    <tr>
                        <td colspan="8" style="height:50px;" align="center">
                            <asp:Label Visible="true" runat="server" ID="labDataIsNull" style="color:#093C7E; font-size:30px; font-weight:bold;" Text="暂无相关简历"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center">
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
