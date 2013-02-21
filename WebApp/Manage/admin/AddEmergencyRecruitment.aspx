<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmergencyRecruitment.aspx.cs" Inherits="WebApp.Manage.admin.AddEmergencyRecruitment" %>

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
                    <x:ToolbarText ID="ToolbarText2" Text="审核紧急招聘　" runat="server">
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
                            <x:Label ID="labEnterpriseName" runat="server" Label="企业名称"></x:Label>
                            <x:Label ID="labJobPositionName" runat="server" Label="职位名称"></x:Label>
                            <x:Label ID="labJobPositionDesc" runat="server" Label="职位介绍"></x:Label>
                            <x:DatePicker ID="dateStartTime" runat="server" Required="true" Label="开始日期" EmptyText="开始日期"></x:DatePicker>
                            <x:DatePicker ID="dateEndTime" runat="server" Required="true" CompareControl="dateStartTime" CompareOperator="GreaterThanEqual" CompareMessage="结束日期应该大于开始日期" Label="结束日期" EmptyText="结束日期"></x:DatePicker>
                            <x:CheckBox ID="ckbIsEnableEmergencyRecruitment" runat="server" Label="是否允许显示"></x:CheckBox>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
