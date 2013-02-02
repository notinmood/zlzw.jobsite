<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageHead.ascx.cs" Inherits="WebApp.UserControl.PageHead" %>
<div class="top">
    <div id="navigation">
        <ul>
            <li id="h"></li>
            <li><a href="../default.aspx">首页</a></li>
            <li><a id="linkBtnJobSearchList" runat="server" href="JobSearchList.aspx">职位搜索</a></li>
            <li><a id="linkBtnResumeCenter" runat="server" href="EditPersonalInfo.aspx">简历中心</a></li>
            <li><a id="linkBtnActivityList" runat="server" href="ActivityList.aspx">招聘会</a></li>
            <li><a id="linkBtnExchangeCorner" runat="server" href="ExchangeCorner.aspx">交流园地</a></li>
            <li><a id="linkBtnMerchantsJoin" runat="server" href="MerchantsJoin.aspx">招商加盟</a></li>
        </ul>
    </div>
    <div class="logo">
        <a href="../default.aspx"><img src="image/logo.png" alt="" style="border:0px;"></a>
    </div>
</div>
