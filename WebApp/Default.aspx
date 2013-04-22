<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApp._default" %>

<%@ Register src="UserControl/DefaultHead.ascx" tagname="DefaultHead" tagprefix="uc1" %>

<%@ Register src="UserControl/DefaultFooter.ascx" tagname="DefaultFooter" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="青岛人才市场,青岛代缴保险,青岛劳务派遣,青岛人事代理,青岛人才网,城阳人才网,城阳人才市场,青岛北站人才市场,青岛招聘会" />
    <meta name="description" content="青岛人才市场(汽车北站)，由中劳网与青岛校企英才公司承办，位于汽车北站二楼大厅内，是覆盖青岛五市七区高中低多层次求职者的大型人力资源集散基地。市场业务范围：青岛人才市场招聘会,青岛人才市场网络招聘,青岛代缴保险,青岛劳务派遣,青岛人事代理,短工供应,就业安置等" />
    <title>青岛人才市场网(北站)-官方网站</title>
    <link href="css/zong.css" type="text/css" rel="stylesheet" />
    <link href="EasyUI/css/bootstrap/easyui.css" rel="stylesheet" />
    <script type="text/javascript" src="http://lib.sinaapp.com/js/jquery/1.9.0/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.9.0.js"></script>
    <script type="text/javascript" src="EasyUI/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="EasyUI/Script/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="Scripts/jquery.innerfade.js"></script>
    <script type="text/javascript" src="Scripts/MSClass.js"></script>
    <script type="text/javascript" src="Scripts/WebForms/jquery.watermark.min.js"></script>
    <script type="text/javascript" src="Scripts/ValidateRule.js"></script>
</head>

<body style="margin:0 auto;padding:0px;">
    <form id="form01" runat="server">
        <div id="wapper">
            <uc1:DefaultHead ID="DefaultHead1" runat="server" />
            <div class="top1">
                <div class="top1left">
                    <table width="223" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="3">
                                <div style="border: 1px solid #ff8000;">
                                <table id="loginForm" width="222" border="0" cellpadding="0" cellspacing="0" style="height: 165px" runat="server">
                                    <tr>
                                        <td style="background-image:url('image/img3.png'); background-repeat:repeat-x;height:32px">
                                            <span style="font-size:15px; color:#fff; font-weight:bold;">&nbsp;&nbsp;登陆窗口</span>
                                        </td>
                                    </tr>
                                    <tr id="rows1">
                                        <td><span style="color: #FA7A00; font-size: 13px; font-weight: bold;">　请首先选择</span>
                                            <input type="radio" id="radioPersonal" name="userType" checked="checked" value="1" /><span style="color: #FA7A00; font-size: 13px; font-weight: bold;">个人</span>
                                            <input type="radio" id="radioEnterprise" name="userType" value="2" /><span style="color: #FA7A00; font-size: 13px; font-weight: bold;">企业</span>
                                        </td>
                                    </tr>
                                    <tr id="rows2">
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>　账号:
                                                        <input id="txbUsername" type="text" name="txbUsername" style="width: 102px" class="easyui-validatebox" data-options="required:true,validType:'length[6,10]'" missingMessage="账号不能为空" />
                                                    </td>
                                                    <td rowspan="3">
                                                        <%--<input id="Button1" type="button" value="登陆" style="height: 65px;" />--%>
                                                        <img id="btnSubmit" style="border:0px;" src="image/go.gif" alt="用户登录" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px;"></td>
                                                </tr>
                                                <tr>
                                                    <td>　密码:
                                                        <input type="password" id="txbPassword" name="txbPassword" style="width: 102px" class="easyui-validatebox" data-options="required:true,validType:'length[6,10]'" missingMessage="密码不能为空">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="rows3">
                                        <td align="center">
                                            <a href="PersonalRegistration.aspx" style="text-decoration: none; color: #093C7E;">个人注册</a>　<a href="EnterpriseRegister.aspx" style="text-decoration: none; color: #093C7E;">企业注册</a>　<a id="linkBtnPassword" href="#" style="color:#093c7e;text-decoration:none;">忘记密码?</a>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="labSuccessLogin" runat="server"></asp:Label>
                            </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="top1right">
                    <ul id="portfolio" style="list-style: none;margin-left:0.5px; padding-left: 0.5px; margin-top: -0.5px;z-index:-9999;">
                    </ul>
                </div>
                <div class="top1middle">
                    <table width="505" border="0" cellpadding="0" cellspacing="0" style="margin-left: 8px;">
                        <tr>
                            <td style="background: url(image/img3.png) repeat-x;" height="32px"><span id="span">招 聘 会</span>
                                <div style="float:right;margin-right:5px;*margin-top:-20px;"><a href="ActivityList.aspx" target="_blank" style="color:#fff;font-weight:bolder;text-decoration:none;">更多>></a></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="border: 1px solid #ff8000;">
                                    <table width="507" height="133" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="133" rowspan="5">
                                                <div class="img4">
                                                    <img src="image/img4.png" width="130" height="113" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td style="line-height:25px;">
                                                                <asp:Label ID="labNewsTitle" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </div>

                            </td>
                        </tr>
                    </table>
                </div>

            </div>
            <div class="top2" style="z-index:99999;">
                <div class="top2left">
                    <table width="223" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="image/img6.png" width="225" height="32" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="border: 1px solid #ff8000; padding-left: 13px; color: #093c7e;">

                                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemDataBound="DataList1_ItemDataBound">
                                        <HeaderTemplate>
                                            <table width="208" height="195px;" border="0" cellpadding="0" cellspacing="0">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <img src="image/img7.png" width="11" height="12" alt="" /><asp:Label ID="labEnterpriseService" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:DataList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="top2right">
                    <div class="top2righttop">
                        <table width="757" height="70" border="0" cellspacing="0" cellpadding="0">
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
                                <asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="image/SearchWork.png" OnClick="imgBtnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    　<input runat="server" type="text" id="txbJobFeildKinds" class="easyui-validatebox" style="width: 133px; height: 18px;" readonly="readonly" />
                            </td>
                            <td>
                                <asp:DropDownList ID="drpShiSu" runat="server" Width="139" Height="23">
                                    <asp:ListItem Text="请选择食宿要求" Value="-1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="不限" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="提供食宿" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <input runat="server" type="text" id="txbSearchKey" style="width: 193px; height: 18px;" />
                            </td>
                        </tr>
                        </table>
                    </div>
                    <div class="top2rightbottom">
                        <table width="757" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="background-image: url(image/img3.png); background-repeat: repeat-x;" height="30px;" width="757px;"><span id="span1" style="color: #fff; font-weight: bold; padding-left: 15px; font-size: 14px;">岗 位 类 别</span></td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="border: 1px solid #FF8000; font-size: 14px;">
                                        <table width="757px" height="100;" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="15"><span id="span2" style="color: #325C93; font-weight: bold;">　非管理：</span><span style="color: #6e6e6e;"><asp:Label ID="labNonManageType" runat="server"></asp:Label></span>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="15"><span style="color: #6e6e6e; padding-left: 72px;*padding-left: 76px;-padding-left: 75px;">
                                                    <asp:Label ID="labNonManageTypeOther" runat="server"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td height="15"><span id="span3" style="color: #325C93; font-weight: bold;">　管理类：</span><span style="color: #6e6e6e;"><asp:Label ID="labManageType" runat="server"></asp:Label></span></td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="top3">
                <div class="top3left">
                    <table width="223" border="0" cellspacing="0" cellpadding="0">
                        <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="top3image">
                                            <asp:Label ID="labGeneralAD" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div class="top3right">
                    <div class="top3righttop">
                        <table width="752" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="background-image: url(image/img3.png); background-repeat: repeat-x;" height="32px;" width="752px;"><span id="span4" style="color: #fff; font-weight: bold; padding-left: 15px; font-size: 14px;">行 业 类 别</span></td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="border: 1px solid #FF8000; font-size: 14px;">
                                        <table width="757px" height="170px;" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="15"><span id="span5"><span style="color: #325C93; font-weight: bold;">　制造行业：</span><span style="color: #6e6e6e;"><asp:Label ID="labzzyType" runat="server"></asp:Label></span></span></td>
                                            </tr>
                                            <tr>
                                                <td height="15"><span style="color: #6e6e6e; padding-left: 86px;*padding-left: 89px;-padding-left: 91px;">
                                                    <asp:Label ID="Label1" runat="server"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td height="15"><span id="span6"><span style="color: #325C93; font-weight: bold;">　第三产业：</span><span style="color: #6e6e6e;"><asp:Label ID="landscy" runat="server"></asp:Label></span></span></td>
                                            </tr>
                                            <tr>
                                                <td height="15"><span style="color: #6e6e6e; padding-left: 86px;*padding-left: 90px;-padding-left: 90px;">
                                                    <asp:Label ID="lablandscyOther" runat="server"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td height="15"><span id="span7"><span style="color: #325C93; font-weight: bold;">　第一产业：</span><span style="color: #6e6e6e;"><asp:Label ID="labddcyType" runat="server"></asp:Label></span></span></td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="top3rightmiddle">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="margin-top:92px;">
                            <tr>
                                <td style="background-image: url('image/img3.png'); background-repeat: repeat-x;" height="32px;" width="752px;">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <span style="color:#fff; font-weight:bold; font-size:14px;">　紧急招聘</span>
                                            </td>
                                            <td align="right" style="color:#fff; font-weight:bold; font-size:14px;">
                                                <a href="EmergencyRecruitmentList.aspx" target="_blank" style="color:#fff;text-decoration:none;">更多>></a>　
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="participatingCompaniesList01" style="border: 1px solid #ff8000;width:757px;height:300px; overflow:hidden;">
                                        <%--<asp:Repeater ID="Repeater4" runat="server" OnItemDataBound="Repeater4_ItemDataBound">
                                            <HeaderTemplate>
                                                <table width="757px" height="320" cellpadding="0" cellspacing="0" border="0" style="font-size: 14px;table-layout:fixed;">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                    <tr>
                                                        <td width="230" align="left"><span id="span9">　<asp:Label ID="labJobTitle" runat="server"></asp:Label></span></td>
                                                        <%--这一句不取消<td width="157" align="center"><asp:Label ID="labAdd" runat="server"></asp:Label></td>--%>
                                                        <%--<td width="396" align="left" style="word-break:keep-all;white-space:nowrap;overflow:hidden;"><asp:Label ID="labXueLi" runat="server"></asp:Label></td>
                                                        <td width="130" align="center"><asp:Label ID="labTel" runat="server"></asp:Label></td>
                                                    </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>--%>
                                        <asp:Label ID="labjjzp" Visible="true" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="top3rightbottom">
                        <table width="752" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="background-image: url('image/img3.png'); background-repeat: repeat-x;" height="32px;" width="752px;" valign="middle">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <span style="color:#fff; font-weight:bold; font-size:14px;">　部分最近参会企业信息</span>
                                            </td>
                                            <td align="right" style="color:#fff; font-weight:bold; font-size:14px;">
                                                <a href="ParticipatingCompaniesList.aspx" target="_blank" style="color:#fff;text-decoration:none;">更多>></a>　
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="border: 1px solid #FF8000; height:320px;">
                                        <%--<asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound">
                                            <HeaderTemplate>--%>
                                                <div id="participatingCompaniesList" style="height:200px;">
                                                    <ul id="participatingCompanies" style="padding: 2px 15px 5px 15px;*margin-left:-12px;-margin-left:-12px; font-size: 14px;width: 100%;overflow:hidden;">
                                            <%--</HeaderTemplate>
                                            <ItemTemplate>--%>
                                                        <li style='padding: 0px 40px 0px 15px;list-style:none;color:#6e6e6e;'>
                                                            <asp:Label ID="labParticipatingCompaniesList" runat="server"></asp:Label>
                                                        </li>
                                            <%--</ItemTemplate>
                                            <FooterTemplate>--%>
                                                    </ul>
                                                </div>
                                            <%--</FooterTemplate>
                                        </asp:Repeater>--%>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="link">
                <table width="100%" height="134px;" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="32px">
                            <img src="image/img10.png" width="32" height="134"/></td>
                        <td>
                            <table width="100%" height="134px;" border="0" cellspacing="0" cellpadding="0" style="text-align: left; font-size: 14px; line-height: 25px;">
                                <tr>
                                    <td>
                                        　<asp:Label ID="labLink" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        　<asp:Label ID="labLink01" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        　<asp:Label ID="labLink02" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        　<asp:Label ID="labLink03" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        　<asp:Label ID="labLink04" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <uc2:DefaultFooter ID="DefaultFooter1" runat="server" />
        </div>
    </form>
    <script type="text/javascript" src="Scripts/WebForms/jquery.artDialog.js"></script>
    <link type="text/css" href="skins/blue.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/WebForms/iframeTools.js"></script>
    <script type="text/javascript" src="Scripts/default.js"></script>
    <script type="text/javascript" language="javascript">
        new Marquee(["participatingCompaniesList", ""], 0, 1, 757, 300, 20, 0, 0);
        //new Marquee(["participatingCompaniesList01", ""], 0, 1, 757, 300, 20, 0, 0);紧急招聘滚动
    </script>
    <script type="text/javascript" src="Scripts/PostMail.js"></script>
</body>
</html>
