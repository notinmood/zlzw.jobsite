<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobEnterpriseJobPositionList.aspx.cs" Inherits="WebApp.Manage.admin.JobEnterpriseJobPositionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" Theme="Blue" AutoSizePanelID="Panel1" runat="server">
    </x:PageManager>
    <x:Panel ID="Panel1" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <x:Button ID="btnAdd" runat="server" Text="添加岗位" Icon="Add">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server"></x:ToolbarSeparator>
                    <x:Button ID="btnDel" runat="server" Text="删除岗位" Icon="BulletCross" OnClick="btnDel_Click"></x:Button>
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Grid ID="grid1" PageSize="10" ShowBorder="true" ShowHeader="false"
                AutoHeight="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                Width="800px" DataKeyNames="JobPositionGuid" OnPageIndexChange="Grid1_PageIndexChange"
                EnableRowNumber="True" IsDatabasePaging="true" 
                OnRowDataBound="Grid1_RowDataBound" ForceFitAllTime="true" EnableAjaxLoading="true">
                <Columns>
                    <x:BoundField Width="100px" DataField="EnterpriseKey" TextAlign="Center" HeaderText="所属企业" />
                    <x:BoundField Width="80px" DataField="JobPositionName" HeaderText="岗位名称" TextAlign="Center" DataToolTipField="JobPositionName" />
                   <%-- <x:BoundField Width="80px" DataField="DepartmentName" HeaderText="招聘部门" TextAlign="Center" DataToolTipField="DepartmentName" />--%>
                    <x:BoundField Width="50px" DataField="JobWorkType" HeaderText="工作性质" TextAlign="Center" />
                    <x:BoundField Width="100px" DataField="JobPositionKind" HeaderText="行业类别" TextAlign="Center"/>
                    <x:BoundField Width="80px" DataField="JobSalary" HeaderText="月薪" TextAlign="Center"/>
                    <x:BoundField Width="50px" DataField="ContactPerson" HeaderText="联系人" DataToolTipField="ContactPerson" TextAlign="Center"/>
                    <x:BoundField Width="100px" DataField="ContactTelephone" HeaderText="联系人电话" DataToolTipField="ContactTelephone" TextAlign="Center"/>
                    <%--<x:BoundField Width="100px" DataField="JobPositionStatus" HeaderText="岗位状态" DataToolTipField="JobPositionStatus" TextAlign="Center"/>--%>
                    <x:BoundField Width="80px" DataField="CreateDate" HeaderText="创建日期" DataToolTipField="CreateDate" TextAlign="Center" DataFormatString="{0:yyyy年MM月dd日}"/>
                    <x:BoundField Width="120px" DataField="UpdateDate" HeaderText="修改日期" TextAlign="Center" DataFormatString="{0:yyyy年MM月dd日}"/>
                    <x:TemplateField HeaderText="编辑操作" TextAlign="Center">
                        <ItemTemplate>
                            <a style="text-decoration:none;" href="<%# GetEditUrl(DataBinder.Eval(Container.DataItem, "[JobPositionGuid]")) %>">编辑</a>
                        </ItemTemplate>
                    </x:TemplateField>
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" Title="Edit" Popup="false" EnableIFrame="true" runat="server"
        IFrameUrl="about:blank" Target="Self" IsModal="True" Width="750px" Height="550px">
    </x:Window>
    </form>
</body>
</html>
