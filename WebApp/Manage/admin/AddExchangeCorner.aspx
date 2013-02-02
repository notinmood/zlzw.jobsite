<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddExchangeCorner.aspx.cs" Inherits="WebApp.Manage.admin.AddExchangeCorner" %>

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
                    <x:ToolbarText ID="ToolbarText2" Text="添加一个新的交流园地类型　" runat="server">
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
                            <x:TextBox ID="txbExchangeCornerTitle" runat="server" Label="标题不能为空" EmptyText="交流园地标题" Required="true"
                                RequiredMessage="交流园地标题不能为空">
                            </x:TextBox>
                            <x:DropDownList ID="drpExchangeCornerTypeKey" runat="server" Label="所属分类" AutoPostBack="true" OnSelectedIndexChanged="drpExchangeCornerTypeKey_SelectedIndexChanged"></x:DropDownList>
                            <x:FileUpload ID="fileExchangeCornerFilePath" runat="server" Label="文件上传"></x:FileUpload>
                            <x:HtmlEditor ID="txbContent" runat="server" Label="交流园地内容" Hidden="true"></x:HtmlEditor>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
