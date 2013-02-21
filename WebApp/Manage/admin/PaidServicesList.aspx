<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaidServicesList.aspx.cs" Inherits="WebApp.Manage.admin.PaidServicesList" %>

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
                    <x:Button ID="btnAdd" runat="server" Text="添加基本数据" Icon="Add">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server"></x:ToolbarSeparator>
                    <x:Button ID="btnDel" runat="server" Text="删除基本数据" Icon="BulletCross" OnClick="btnDel_Click"></x:Button>
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Grid ID="grid1" PageSize="10" ShowBorder="true" ShowHeader="false"
                AutoHeight="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                Width="800px" DataKeyNames="PaidServicesGUID" OnPageIndexChange="Grid1_PageIndexChange"
                EnableRowNumber="True" IsDatabasePaging="true" 
                OnRowDataBound="Grid1_RowDataBound" ForceFitAllTime="true" EnableAjaxLoading="true">
                <Columns>
                    <x:BoundField Width="50px" DataField="PublishID" HeaderText="发布人" TextAlign="Center" />
                    <x:BoundField Width="70px" DataField="PublishJobCount" HeaderText="职位发布数" TextAlign="Center" />
                    <x:BoundField Width="70px" DataField="PublishJobPrice" HeaderText="职位发布价格" TextAlign="Center"/>
                    <x:BoundField Width="70px" DataField="MainResumeCount" HeaderText="查看主投简历数" TextAlign="Center" />
                    <x:BoundField Width="70px" DataField="MainResumePrice" HeaderText="查看主投简历价格" TextAlign="Center" />
                    <x:BoundField Width="70px" DataField="SearchStrangeResumeCount" HeaderText="搜索陌生简历数" TextAlign="Center" />
                    <x:BoundField Width="70px" DataField="SearchStrangeResumePrice" HeaderText="搜索陌生简历价格" TextAlign="Center" />
                    <x:BoundField Width="70px" DataField="DownloadStrangeResumeCount" HeaderText="下载陌生简历数" TextAlign="Center" />
                    <x:BoundField Width="70px" DataField="DownloadStrangeResumePrice" HeaderText="下载陌生简历价格" TextAlign="Center" />
                    <x:BoundField Width="70px" DataField="JobAdLargePrice" HeaderText="名企招聘价格(大)" TextAlign="Center"/>
                    <x:BoundField Width="70px" DataField="JobAdSmallPrice" HeaderText="名企招聘价格(小)" TextAlign="Center"/>
                    <x:BoundField Width="70px" DataField="EmergencyRecruitmentPrice" HeaderText="紧急招聘价格" TextAlign="Center"/>
                    <%--<x:BoundField Width="70px" DataField="PublishDate" HeaderText="发布日期" TextAlign="Center" DataFormatString="{0:yyyy年MM月dd日}"/>--%>
                    <x:TemplateField HeaderText="编辑操作" TextAlign="Center">
                        <ItemTemplate>
                            <a style="text-decoration:none;" href="<%# GetEditUrl(DataBinder.Eval(Container.DataItem, "[PaidServicesGUID]")) %>">编辑</a>
                        </ItemTemplate>
                    </x:TemplateField>
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" Title="Edit" Popup="false" EnableIFrame="true" runat="server"
        IFrameUrl="about:blank" Target="Self" IsModal="True" Width="750px" Height="480px">
    </x:Window>
    </form>
</body>
</html>
