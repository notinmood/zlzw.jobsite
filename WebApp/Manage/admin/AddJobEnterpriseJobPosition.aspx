<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AddJobEnterpriseJobPosition.aspx.cs" Inherits="WebApp.Manage.admin.AddJobEnterpriseJobPosition" %>

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
                    <x:ToolbarText ID="ToolbarText2" Text="添加一个新的岗位　" runat="server">
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
                            <x:DropDownList ID="drpJobPositionStatus" runat="server" Label="简历状态"></x:DropDownList>
                            <x:DropDownList ID="drpEnterpriseKey" runat="server" Label="所属企业"></x:DropDownList>
                            <x:TextBox ID="txbJobPositionName" runat="server" Label="岗位名称" EmptyText="岗位名称可以是中文或其它语言" Required="true"
                                RequiredMessage="岗位名称不能为空">
                            </x:TextBox>
                            <x:TextBox ID="txbDepartmentName" runat="server" Label="招聘部门" EmptyText="所要招聘的部门名称"></x:TextBox>
                            <x:TextBox ID="txbJobPositionKind" runat="server" EmptyText="岗位名称中文" Label="岗位名称"></x:TextBox>
                            <x:DropDownList ID="drpJobWorkType" runat="server" Label="工作性质"></x:DropDownList>
                            <x:TextBox ID="txbJobWorkPlaceNames" runat="server" Label="工作地点" EmptyText="如有多个工作地点请用'|'分隔" Required="true" RequiredMessage="工作地点不能为空"></x:TextBox>
                            <x:DropDownList ID="drpJobFeildKinds" runat="server" Label="行业分类" AutoPostBack="true" OnSelectedIndexChanged="drpJobFeildKinds_SelectedIndexChanged"></x:DropDownList>
                            <x:DropDownList ID="drpJobFeildKinds01" runat="server" Label="所属行业"></x:DropDownList>
                            <x:TextBox ID="txbJobPositionKinds" runat="server" Label="从事职业" EmptyText="从事职业类别"></x:TextBox>
                            <x:DropDownList ID="drpJobSalary" runat="server" Label="月薪"></x:DropDownList>
                            <x:TextBox ID="txbNeedPersonCount" runat="server" Label="招聘人数" EmptyText="企业所要招聘的员工数量。请输入一个正整数" RegexPattern="NUMBER" RegexMessage="招聘人数格式错误，请输入一个正整数" Required="true" RequiredMessage="招聘人数不能为空"></x:TextBox>
                            <x:DropDownList ID="drpNeedEducation" runat="server" Label="学历要求"></x:DropDownList>
                            <x:TextBox ID="txbNeedAge" runat="server" Label="年龄要求" EmptyText="岗位所需要的年龄要求，可以填写'不限制'"></x:TextBox>
                            <x:DropDownList ID="drpNeedSex" runat="server" Label="性别要求">
                                <x:ListItem Text="女" Value="0" />
                                <x:ListItem Text="男" Value="1" Selected="true" />
                                <x:ListItem Text="无限制" Value="2" />
                            </x:DropDownList>
                            <x:DropDownList ID="drpNeedWorkExperience" runat="server" Label="工作经验"></x:DropDownList>
                            <x:DropDownList ID="drpNeedMangeExperience" runat="server" Label="管理经验">
                                <x:ListItem Text="不需要" Value="0" />
                                <x:ListItem Text="需要" Value="1" />
                            </x:DropDownList>
                            <x:HtmlEditor ID="txbJobPositionDesc" runat="server" Label="职位描述"></x:HtmlEditor>
                            <x:TextBox ID="txbContactPerson" runat="server" Label="联系人" EmptyText="联系人姓名" Required="true" RequiredMessage="联系人不能为空"></x:TextBox>
                            <x:TextBox ID="txbContactTelephone" runat="server" Label="联系人电话" EmptyText="联系人的电话" Required="true" RequiredMessage="联系人电话不能为空"></x:TextBox>
                            <x:TextBox ID="txbContactMail" runat="server" Label="邮箱地址" EmptyText="联系人邮箱地址" ></x:TextBox>
                            <x:DatePicker ID="txbJobPositionStartDate" runat="server" Label="开始日期" EmptyText="招聘的开始日期"></x:DatePicker>
                            <x:DatePicker ID="txbJobPositionEndDate" runat="server" EmptyText="招聘的结束日期" Label="结束日期"></x:DatePicker>
                            <x:DatePicker ID="txbInterviewTime" runat="server" Label="面试时间" EmptyText="招聘面试时间"></x:DatePicker>
                            <x:TextBox ID="txbInterviewAddress" runat="server" Label="面试地址" EmptyText="面试地点"></x:TextBox>
                            <x:DropDownList ID="drpSpecialType" runat="server" Label="首页显示"></x:DropDownList>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
