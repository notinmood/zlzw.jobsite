<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobSearchList.aspx.cs" Inherits="WebApp.JobSearchList" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register src="UserControl/PageHead.ascx" tagname="PageHead" tagprefix="uc1" %>
<%@ Register src="UserControl/PageFooter.ascx" tagname="PageFooter" tagprefix="uc2" %>
<%@ Register Src="UserControl/JobCategories.ascx" TagName="JobCategories" TagPrefix="uc1" %>
<%@ Register Src="UserControl/IndustrySector.ascx" TagName="IndustrySector" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <title>青岛北站人才市场网-职位搜索</title>
    <link href="css/sousuo.css" type="text/css" rel="stylesheet">
    <link href="EasyUI/css/bootstrap/easyui.css" rel="stylesheet" />
    <script type="text/javascript" src="http://lib.sinaapp.com/js/jquery/1.9.0/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.9.0.js"></script>
    <script type="text/javascript" src="EasyUI/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="Scripts/jquery.innerfade.js"></script>
    <script type="text/javascript" src="Scripts/MSClass.js"></script>
    <script type="text/javascript" src="Scripts/WebForms/jquery.watermark.min.js"></script>
</head>

<body style="margin:0 auto;padding:0;">
    <form id="form01" runat="server">
        <div style="border:1px solid #fff;">
            <uc1:PageHead ID="PageHead1" runat="server" />
            <div class="top2right">
                <div style="background-image:url('image/img8.png');background-repeat:repeat-x;">
                    <table style="width: 700px; height: 75px; border: 0px;" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td>
                                　<input type="text" runat="server" id="txbJobPositionKinds" class="easyui-validatebox" data-options="required:true" missingMessage="请选择岗位类别" style="width: 133px; height: 22px;" readonly="readonly" />
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
                                <input id="txbWorkAreas" runat="server" type="text" class="easyui-validatebox" data-options="required:true" missingMessage="请选择工作地区" style="width: 193px; height: 22px;" readonly="readonly" />
                            </td>
                            <td rowspan="2">
                                <asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="image/SearchWork.png" OnClick="imgBtnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    　<input runat="server" type="text" id="txbJobFeildKinds" class="easyui-validatebox" data-options="required:true" missingMessage="请选择行业类别" style="width: 133px; height: 22px;" readonly="readonly" />
                            </td>
                            <td>
                                <asp:DropDownList ID="drpShiSu" runat="server" Width="139" Height="23">
                                    <asp:ListItem Text="请选择食宿要求" Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="不限" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="提供食宿" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <input runat="server" type="text" id="txbSearchKey" style="width: 193px; height: 22px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="top2rightbottom">
                    <table width="995" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-image: url('image/img3.png'); background-repeat: repeat-x" height="32px;" width="752px;"><span id="span" style="color: #fff; font-weight: bold; font-size: 14px;">岗 位 类 别</span></td>
                        </tr>
                        <tr>
                            <td>
                                <div style="border: 1px solid #FF8000;">
                                    <uc1:JobCategories ID="JobCategories1" runat="server" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="top2rightbottom">
                    <table width="995" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-image: url('image/img3.png'); background-repeat: repeat-x;" height="32px;" width="752px;"><span id="span3" style="color: #fff; font-weight: bold; padding-left: 15px; font-size: 14px;">行 业 类 别</span></td>
                        </tr>
                        <tr>
                            <td>
                                <div style="border: 1px solid #FF8000;">
                                    <uc2:IndustrySector ID="IndustrySector1" runat="server" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="zhiwei">
                    <table width="995" style="text-align: center; font-size: 14px; margin-top:50px;" border="0" cellspacing="0" cellpadding="0">
                        <thead>
                            <tr>
                                <td>职位名称</td>
                                <td>公司名称</td>
                                <td>工作地点</td>
                                <td>发布日期</td>
                            </tr>
                        </thead>
                        <tr>
                            <td colspan="4" style="height:15px;"></td>
                        </tr>
                        <tr>
                            <td width="100%;" height="1px" colspan="4" style="background-color: #999999; background-repeat: repeat-x;"></td>
                        </tr>
                        <tr>
                            <td style="height:10px;"></td>
                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr style="font-size:14px;">
                                    <td align="left">　<asp:Label ID="labJobName" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="labEnterpriseName" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="labAddress" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="labPublishDate" runat="server"></asp:Label></td>
                                </tr>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <tr><td style="height:30px;"></td></tr>
                            </SeparatorTemplate>
                        </asp:Repeater>
                        
                        <tr>
                            <td style="height:50px;"></td>
                        </tr>
                        <tr>
                            <td colspan="4" align='center'>
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="10" 
                                onpagechanged="AspNetPager1_PageChanged" CssClass="paginator" CurrentPageButtonClass="cpb" FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" >
                            </webdiyer:AspNetPager>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label Visible="true" runat="server" ID="labDataIsNull" style="color:#093C7E; font-size:30px; font-weight:bold;" Text="暂无相关职位"></asp:Label>
                            </td>
                        </tr>
                    </table>

                </div>
                <uc2:PageFooter ID="PageFooter1" runat="server" />
            </div>
        </div>
        <script type="text/javascript" src="Scripts/WebForms/jquery.artDialog.js"></script>
        <link type="text/css" href="skins/blue.css" rel="stylesheet" />
        <script type="text/javascript" src="Scripts/WebForms/iframeTools.js"></script>
        <script type="text/javascript" src="Scripts/JobSearch.js"></script>
    </form>
</body>
</html>
