<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddGeneralFriendlyLink.aspx.cs" Inherits="WebApp.Manage.admin.AddGeneralFriendlyLink" %>

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
                    <x:ToolbarText ID="ToolbarText2" Text="添加一个新的友情链接　" runat="server">
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
                            <x:TextBox ID="txbLinkTitle" runat="server" Label="友情链接标题" EmptyText="友情链接标题" Required="true"
                                RequiredMessage="友情链接标题不能为空">
                            </x:TextBox>
                           <x:DropDownList ID="drpLinkType" runat="server" Label="友情链接类型" AutoPostBack="true" OnSelectedIndexChanged="drpLinkType_SelectedIndexChanged">
                               <x:ListItem Text="文字链接" Value="0" Selected="true" />
                               <x:ListItem Text="图片链接" Value="1" />
                           </x:DropDownList>
                           <x:TextBox ID="txbLinkTargetUrl" runat="server" Label="跳转地址"></x:TextBox>
                           <x:TextBox ID="txbOrderNumber" runat="server" Label="排序" Required="true" RequiredMessage="排序字段不能为空" RegexPattern="NUMBER" RegexMessage="排序字段格式输入"></x:TextBox>
                           <x:FileUpload ID="fileUploadImage" runat="server" Label="图片上传" EmptyText="友情链接图片上传"></x:FileUpload>
                           <x:TextArea ID="txbLinkDesc" runat="server" Label="友情链接描述"></x:TextArea>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
