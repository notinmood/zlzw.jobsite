<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddJobEnterpriseServiceList.aspx.cs" Inherits="WebApp.Manage.admin.AddJobEnterpriseServiceList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" Theme="Blue" />
        <x:Panel ID="Panel1" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true" AutoHeight="true">
        <Toolbars>
            <x:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="BulletCross">
                    </x:Button>
                    <x:Button ID="btnSaveRefresh" Text="保存" ValidateForms="SimpleForm1" runat="server"
                        Icon="Accept" OnClick="btnSaveRefresh_Click">
                    </x:Button>
                    <x:ToolbarFill ID="ToolbarFill1" runat="server">
                    </x:ToolbarFill>
                    <x:ToolbarText ID="ToolbarText2" Text="添加一个新的招聘业务基本信息　" runat="server">
                    </x:ToolbarText>
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="Panel2" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false" Height="450px">
                <Items>
                    <x:SimpleForm ID="SimpleForm1" ShowBorder="true" ShowHeader="false" EnableLightBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:DropDownList ID="drpEnterpriseKey" runat="server" Label="所属企业"></x:DropDownList>
                            <x:TextBox ID="txbJobPositionPublishAllowCount" runat="server" Label="允许发布数" EmptyText="允许企业发布的职位个数" Required="true"
                                RequiredMessage="允许企业发布的职位个数不能为空" RegexPattern="NUMBER" RegexMessage="允许企业发布的职位个数只能一个正整数">
                            </x:TextBox>
                            <x:TextBox ID="txbJobPositionPublishUsedCount" runat="server" Label="已经发布数" EmptyText="企业已经发布的职位个数" Required="true"
                                RequiredMessage="企业已经发布的职位个数不能为空" RegexPattern="NUMBER" RegexMessage="企业已经发布的职位个数只能一个正整数"></x:TextBox>
                            <x:DatePicker ID="txbEnterpriseServiceCurrentContractStartDate" runat="server" Label="开始日期" EmptyText="允许企业发布职位的开始日期" Required="true" RequiredMessage="允许企业发布职位的开始日期不能为空"></x:DatePicker>
                            <x:DatePicker ID="txbEnterpriseServiceCurrentContractEndDate" runat="server" Label="结束日期" EmptyText="禁止企业发布职位的开始日期" Required="true" RequiredMessage="禁止企业发布职位的开始日期不能为空"></x:DatePicker>
                            <x:TextBox ID="txbResumeDownAllowCount" runat="server" Label="允许查看简历数" EmptyText="允许企业查看非投递简历的个数" Required="true" RegexMessage="允许企业查看非投递简历的个数不能为空"></x:TextBox>
                            <x:TextBox ID="txbResumeDownUsedCount" runat="server" Label="已查看简历数" EmptyText="企业已查看非投递简历的个数" Required="true" RegexMessage="企业已查看非投递简历的个数不能为空"></x:TextBox>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
