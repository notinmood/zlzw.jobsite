<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddJobPersonResume.aspx.cs" Inherits="WebApp.Manage.admin.AddJobPersonResume" %>

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
                    <x:Button ID="btnSaveRefresh" Text="保存" Hidden="true" ValidateForms="SimpleForm1" runat="server"
                        Icon="Accept" OnClick="btnSaveRefresh_Click">
                    </x:Button>
                    <x:ToolbarFill ID="ToolbarFill1" runat="server">
                    </x:ToolbarFill>
                    <x:ToolbarText ID="ToolbarText2" Text="查看简历　" runat="server">
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
                            <x:DropDownList ID="drpResumeStatus" runat="server" Label="允许企业查看">
                                <x:ListItem Text="允许" Value="1" />
                                <x:ListItem Text="不允许" Value="0" />
                            </x:DropDownList>
                            <x:TextBox ID="txbOwnerUserName" runat="server" Label="求职者姓名" EmptyText="求职者姓名" Required="true"
                                RequiredMessage="求职者姓名不能为空">
                            </x:TextBox>
                            <x:DropDownList ID="drpUserSex" runat="server" Label="性别">
                                <x:ListItem Text="女" Value="0" />
                                <x:ListItem Text="男" Value="1" />
                            </x:DropDownList>
                            <x:DropDownList ID="drpUserEducationalBackground" runat="server" Label="学历"></x:DropDownList>
                            <x:TextBox ID="txbUserBirthDay" runat="server" Label="出生日期" EmptyText="求职者出生日期"></x:TextBox>
                            <x:TextBox ID="txbUserMobileNO" runat="server" Label="联系电话" EmptyText="求职者联系电话"></x:TextBox>
                            <x:TextBox ID="txbUserCountry" runat="server" Label="户口原籍" EmptyText="求职者户口原籍"></x:TextBox>
                            <x:TextBox ID="txbCurrentResidence" runat="server" Label="现居住地" EmptyText="求职者现居住地"></x:TextBox>
                            <x:TextBox ID="txbCompanyMail" runat="server" Label="电子信箱" EmptyText="求职者电子信箱"></x:TextBox>
                            <x:TextBox ID="txbJobPositionKinds" runat="server" Label="职位类别" EmptyText="求职者职位类别"></x:TextBox>
                            <x:TextBox ID="labJobPositionKinds01" runat="server" Label="期望行业" EmptyText="求职者期望行业"></x:TextBox>
                            <x:TextBox ID="labHopeJob" runat="server" Label="意向职位" EmptyText="求职者意向职位名称"></x:TextBox>
                            <x:TextBox ID="txbJobWorkPlaceNames" runat="server" Label="期望地址" EmptyText="求职者期望工作地址"></x:TextBox>
                            <x:DropDownList ID="drpHopeRoomAndBoard" runat="server" Label="期望食宿">
                                <x:ListItem Text="否" Value="0"/>
                                <x:ListItem Text="是" Value="1" />
                            </x:DropDownList>
                            <x:DropDownList ID="drpJobSalary" runat="server" Label="期望薪资"></x:DropDownList>
                            <x:TextBox ID="txbPersonalSkills" runat="server" Label="个人技能" EmptyText="求职者个人技能"></x:TextBox>
                            <x:TextBox ID="txbSkillsCertificate" runat="server" Label="技能证书" EmptyText="求职者技能证书"></x:TextBox>
                            <x:DropDownList ID="drpJobWorkType" runat="server" Label="求职性质"></x:DropDownList>
                            <x:TextArea ID="txbWorkExperience" runat="server" Label="工作经历"></x:TextArea>
                            <x:TextArea ID="txbEducationExperience" runat="server" Label="教育经历"></x:TextArea>
                            <x:TextBox ID="txbUserHeight" runat="server" Label="身高" EmptyText="求职者身高"></x:TextBox>
                            <x:TextBox ID="txbUserWeight" runat="server" Label="体重" EmptyText="求职者体重"></x:TextBox>
                            <x:Image ID="imgUserPhoto" runat="server" Label="用户照片"></x:Image>
                            <x:Label ID="labCreateDate" runat="server" Label="简历创建时间"></x:Label>
                            <x:Label ID="labUpdateDate" runat="server" Label="简历更新时间"></x:Label>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
