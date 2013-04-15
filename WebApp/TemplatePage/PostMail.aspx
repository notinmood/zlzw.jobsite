<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostMail.aspx.cs" Inherits="WebApp.TemplatePage.PostMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../EasyUI/css/bootstrap/easyui.css" rel="stylesheet" />
    <script type="text/javascript" src="http://lib.sinaapp.com/js/jquery/1.9.0/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.9.0.js"></script>
    <script type="text/javascript" src="../EasyUI/Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../EasyUI/Script/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../Scripts/WebForms/jquery.artDialog.js"></script>
    <script type="text/javascript" src="../Scripts/WebForms/iframeTools.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table style="font-family:'Microsoft YaHei';font-size:12px;">
            <tr>
                <td style="width:70px;*width:140px;">登陆账号：</td>
                <td><input type="text" id="txbUserName" class="easyui-validatebox" data-options="required:true,validType:'length[6,10]'" missingMessage="账号不能为空" /></td>
            </tr>
            <tr>
                <td style="height:5px;"></td>
            </tr>
            <tr>
                <td>注册邮箱：</td>
                <td><input type="text" id="txbMail" Class="easyui-validatebox" data-options="required:true,validType:'email'" invalidMessage="邮箱格式错误"/></td>
            </tr>
            <tr>
                <td style="height:5px;"></td>
            </tr>
            <tr>
                <td>
                    验 证 码：
                </td>
                <td>
                    <input id="txbNum" type="text"  class="easyui-validatebox" data-options="required:true" missingMessage="验证码不能为空"/>
                    <div style="margin-left:160px;*margin-left:210px;margin-top:-25px;">
                        <a title="刷新验证码" href="#" onclick="javascript:document.getElementById('valiCode').src='../VerifyCode.aspx?id='+Math.random();return false;">
                    <img style="border:0px;" src="../VerifyCode.aspx" id="valiCode" alt="验证码" /></a>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="height:15px;"></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <input id="btnPostMail" type="button" value="->密码找回" />
                </td>
             </tr>
        </table>
        <script src="../Scripts/PostMail.js"></script>
    </form>
</body>
</html>
