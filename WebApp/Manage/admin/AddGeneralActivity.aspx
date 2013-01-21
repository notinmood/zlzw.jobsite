<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddGeneralActivity.aspx.cs" Inherits="WebApp.Manage.admin.AddGeneralActivity" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

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
                    <x:ToolbarText ID="ToolbarText2" Text="添加一个新的招聘会　" runat="server">
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
                            <x:TextBox ID="txbActivityTitle" runat="server" Label="招聘会名称" EmptyText="招聘会名称" Required="true"
                                RequiredMessage="招聘会名称不能为空">
                            </x:TextBox>
                            <x:TextBox ID="txbActivityAddress" runat="server" Label="招聘会地点" Required="true" RegexMessage="招聘会地点不能为空"></x:TextBox>
                            <%--<x:TextArea ID="txbActivityDesc" runat="server" Label="招聘会描述" Required="true" RegexMessage="招聘会描述不能为空" ></x:TextArea>--%>
                            <x:CheckBox ID="ckbIsDefaultShow" runat="server" Label="显示在首页" Checked="false"></x:CheckBox>
                             <x:ContentPanel ID="ContentPanel1" runat="server" EnableBackgroundColor="false"
                            ShowBorder="false" ShowHeader="false" Height="500px">
                             <FCKeditorV2:FCKeditor ID="FCKeditor1" BasePath="../fckeditor/" Height="350px" runat="server">
                             </FCKeditorV2:FCKeditor>
                            </x:ContentPanel>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
