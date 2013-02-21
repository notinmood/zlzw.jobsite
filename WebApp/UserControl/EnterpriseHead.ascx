<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseHead.ascx.cs" Inherits="WebApp.UserControl.EnterpriseHead" %>
<div class="top">
    <div id="navigation">
        <ul>
            <li><a href="../default.aspx">首页</a></li>
            <li><a id="linkBtnEnterpriseInfo" runat="server" href="EditEnterpriseInfo.aspx">公司信息</a></li>
            <li><a id="linkBtnEnterpriseJobPosting" runat="server" href="JobPosting.aspx">职位发布</a></li>
            <li><a id="linkBtnResumeSearchList" runat="server" href="ResumeSearchList.aspx">简历搜索</a></li>
            <li><a id="linkBtnServiceItem" runat="server" href="EnterpriseServiceList.aspx">服务项目</a></li>
            <li><a id="linkBtnExchangeCornerList" runat="server" href="ExchangeCornerList.aspx">交流园地</a></li>
            <li><a href="ContactUs.aspx?id=41c7853f-2998-4c70-ad17-76a4b4056315">联系我们</a></li>
        </ul>
    </div>
    <div class="logo">
        <a href="../default.aspx"><img src="image/logo.png" alt="" style="border:0px;"></a>
    </div>
</div>