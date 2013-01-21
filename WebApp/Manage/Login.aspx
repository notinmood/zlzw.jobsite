﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Manage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台登陆</title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" Theme="Gray" />
        <x:Window ID="Window1" runat="server" Title="用户登录" IsModal="false" EnableClose="false"
            WindowPosition="GoldenSection" Width="350px">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" BodyPadding="10px"
                    LabelWidth="60px" EnableBackgroundColor="true" ShowHeader="false">
                    <Items>
                        <x:TextBox ID="tbxUserName" Label="用户名" Required="true" runat="server">
                        </x:TextBox>
                        <x:TextBox ID="tbxPassword" Label="密码" TextMode="Password" Required="true" runat="server">
                        </x:TextBox>
                        <x:TextBox ID="tbxCaptcha" Label="验证码" Required="true" runat="server">
                        </x:TextBox>
                        <x:Panel ID="Panel1" CssStyle="padding-left:65px;" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            runat="server">
                            <Items>
                                <x:Image ID="imgCaptcha" CssStyle="float:left;width:160px;" runat="server" ShowEmptyLabel="true">
                                </x:Image>
                                <x:LinkButton CssStyle="float:left;padding-top:8px;" ID="btnRefresh" Text="看不清？"
                                    runat="server" OnClick="btnRefresh_Click">
                                </x:LinkButton>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
            </Items>
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server" Position="Footer">
                    <Items>
                        <x:Button ID="btnLogin" Text="登录" Type="Submit" ValidateForms="SimpleForm1" ValidateTarget="Top"
                            runat="server" OnClick="btnLogin_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
        </x:Window>
    </form>
</body>
</html>
