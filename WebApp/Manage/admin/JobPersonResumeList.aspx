<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobPersonResumeList.aspx.cs" Inherits="WebApp.Manage.admin.JobPersonResumeList" %>

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
                    <x:Button ID="btnAdd" runat="server" Text="查看求职者简历" Icon="Add">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server"></x:ToolbarSeparator>
                    <x:Button ID="btnDel" runat="server" Text="删除求职者简历" Icon="BulletCross" OnClick="btnDel_Click"></x:Button>
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Grid ID="grid1" PageSize="10" ShowBorder="true" ShowHeader="false"
                AutoHeight="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                Width="800px" DataKeyNames="ResumeGuid" OnPageIndexChange="Grid1_PageIndexChange"
                EnableRowNumber="True" IsDatabasePaging="true" 
                OnRowDataBound="Grid1_RowDataBound" ForceFitAllTime="true" EnableAjaxLoading="true">
                <Columns>
                    <x:BoundField Width="70px" DataField="OwnerUserName" HeaderText="求职者姓名" TextAlign="Center" />
                    <x:BoundField Width="120px" DataField="JobFeildKinds" HeaderText="期望行业" TextAlign="Center" DataToolTipField="JobFeildKinds"/>
                    <x:BoundField Width="100px" DataField="JobCurrentWorkStatus" HeaderText="当前工作状态" TextAlign="center" />
                    <x:BoundField Width="100PX" DataField="JobWorkType" HeaderText="工作性质" TextAlign="Center" DataToolTipField="JobWorkType"/>
                    <x:BoundField Width="120px" DataField="UserLastDateTime" HeaderText="最后一次登录时间" TextAlign="Center" DataFormatString="{0:yyyy年MM月dd日}"/>
                    <x:BoundField Width="120px" DataField="UserLastIP" HeaderText="最后一次登录IP" TextAlign="Center" />
                    <x:BoundField Width="150px" DataField="UserRegisterDate" HeaderText="注册日期" TextAlign="Center" DataFormatString="{0:yyyy年MM月dd日}"/>
                    <x:TemplateField HeaderText="编辑操作" TextAlign="Center">
                        <ItemTemplate>
                            <a style="text-decoration:none;" href="<%# GetEditUrl(DataBinder.Eval(Container.DataItem, "[ResumeGuid]")) %>">编辑</a>
                        </ItemTemplate>
                    </x:TemplateField>
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" Title="Edit" Popup="false" EnableIFrame="true" runat="server"
        IFrameUrl="about:blank" Target="Self" IsModal="True" Width="750px" Height="450px">
    </x:Window>
    </form>
</body>
</html>
