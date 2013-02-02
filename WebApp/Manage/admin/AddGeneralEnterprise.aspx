<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddGeneralEnterprise.aspx.cs" Inherits="WebApp.Manage.admin.AddGeneralEnterprise" %>

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
                    <x:ToolbarText ID="ToolbarText2" Text="添加一个新的企业信息　" runat="server">
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
                            <x:TextBox ID="txbCompanyName" runat="server" Label="企业名称" EmptyText="请确保与公司营业执照一致" Required="true"
                                RequiredMessage="企业名称不能为空" ShowRedStar="true">
                            </x:TextBox>
                            <x:DropDownList ID="drpIndustryKey" runat="server" Label="所属行业"></x:DropDownList>
                            <x:DropDownList ID="ddlSheng" Label="省份" ShowRedStar="true" CompareType="String"
                                CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择省份！" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlSheng_SelectedIndexChanged">
                            </x:DropDownList>
                            <x:DropDownList ID="ddlShi" Label="地区市" ShowRedStar="true" CompareType="String"
                                CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择地区市！" runat="server"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlShi_SelectedIndexChanged">
                            </x:DropDownList>
                            <x:DropDownList ID="ddlXian" ShowRedStar="true" CompareType="String" CompareValue="-1"
                                CompareOperator="NotEqual" CompareMessage="请选择县区市！" Label="县区市" runat="server">
                            </x:DropDownList>
                            <x:TextBox ID="txbPrincipleAddress" runat="server" Label="所在地址" Required="true" RequiredMessage="所在地址不能为空" ShowRedStar="true"></x:TextBox>
                            <x:TextBox ID="txbTelephone" runat="server" Label="联系电话" EmptyText="区号/固话/分机" ></x:TextBox>
                            <x:TextBox ID="txbTelephoneOther" runat="server" Label="其他电话" EmptyText="如:手机号"></x:TextBox>
                            <x:TextBox ID="txbFax" runat="server" Label="传 真" EmptyText="传真号" ></x:TextBox>
                            <x:TextBox ID="txbEmail" runat="server" Label="电子邮件" EmptyText="企业电子邮件" Required="true" RequiredMessage="电子邮件不能为空" ShowRedStar="true"></x:TextBox>
                            <x:TextBox ID="txbContactPerson" runat="server" Label="联系人" EmptyText="联系人姓名"></x:TextBox>
                            <x:FileUpload runat="server" ID="fileBusinessLicense" EmptyText="请选择上传营业执照副本" Label="上传营业执照" Required="true" ShowRedStar="true">
                            </x:FileUpload>
                            <x:TextBox ID="txbEnterpriseWWW" runat="server" Label="企业网址" EmptyText="企业网址以http://开头"></x:TextBox>
                            <x:TextBox ID="txbBusRoute" runat="server" Label="乘车路线" EmptyText="到达企业的乘车路线"></x:TextBox>
                            <x:CheckBox ID="ckbIsEmergencyRecruitment" runat="server" Label="紧急发布"></x:CheckBox>
                            <x:HtmlEditor ID="txbEnterpriseDescription" runat="server" Label="企业简介"></x:HtmlEditor>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
