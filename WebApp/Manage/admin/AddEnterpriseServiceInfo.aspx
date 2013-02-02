﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddEnterpriseServiceInfo.aspx.cs" Inherits="WebApp.Manage.admin.AddEnterpriseServiceInfo" %>
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
                    <x:ToolbarText ID="ToolbarText2" Text="添加一个新的服务内容　" runat="server">
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
                            <x:Label ID="labPublisID" runat="server" Label="发布人"></x:Label>
                            <x:DropDownList ID="drpEnterpriseServiceTypeGUID" runat="server" Label="服务类型"></x:DropDownList>
                            <x:TextBox ID="txbEnterpriseServiceInfoTitle" runat="server" Label="服务名称" EmptyText="企业服务名称">
                            </x:TextBox>
                            <x:TextArea ID="txbEnterpriseServiceInfointroduction" runat="server" Label="内容简介"></x:TextArea>
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
