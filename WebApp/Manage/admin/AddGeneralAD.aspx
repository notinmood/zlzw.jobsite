<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGeneralAD.aspx.cs" Inherits="WebApp.Manage.admin.AddGeneralAD" %>

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
                    <x:ToolbarText ID="ToolbarText2" Text="添加一个新的广告　" runat="server">
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
                            <x:Label ID="labCreateUserName" runat="server" Label="创建人"></x:Label>
                            <x:DropDownList ID="drpEnterpriseType" runat="server" Label="所属企业"></x:DropDownList>
                            <x:TextBox ID="txbADName" runat="server" Label="广告名称" EmptyText="广告名称" Required="true"
                                RequiredMessage="广告名称不能为空">
                            </x:TextBox>
                            <x:DropDownList ID="drpADType" runat="server" Label="广告类型" AutoPostBack="true" OnSelectedIndexChanged="drpADType_SelectedIndexChanged"></x:DropDownList>
                            <x:TextArea ID="txbADScript" runat="server" Label="广告代码" Hidden="true" EmptyText="广告脚本代码"></x:TextArea>
                            <x:TextBox ID="txbADTargetUrl" runat="server" Label="跳转地址" EmptyText="广告点击后的跳转地址"></x:TextBox>
                            <x:CheckBox ID="ckbADStatus" runat="server" Label="是否显示"></x:CheckBox>
                            <x:TextBox ID="txbOrderNumber" runat="server" Label="排序" EmptyText="排序字段，只能为正整数" Required="true" RequiredMessage="排序字段不能为空" RegexPattern="NUMBER" RegexMessage="排序类型错误"></x:TextBox>
                            <x:TextArea ID="txbADDesc" runat="server" Label="广告简介" EmptyText="广告简介"></x:TextArea>
                            <x:FileUpload ID="fileUploadImage" runat="server" Label="广告图片" EmptyText="图片尺寸为222*84px" Required="true" RequiredMessage="请上传一张广告图片"></x:FileUpload>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
