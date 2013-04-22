<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADImageList.aspx.cs" Inherits="WebApp.Manage.admin.ADImageList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="青岛人才市场,青岛代缴保险,青岛劳务派遣,青岛人事代理,青岛人才网,城阳人才网,城阳人才市场,青岛北站人才市场,青岛招聘会" />
    <meta name="description" content="青岛人才市场(汽车北站)，由中劳网与青岛校企英才公司承办，位于汽车北站二楼大厅内，是覆盖青岛五市七区高中低多层次求职者的大型人力资源集散基地。市场业务范围：青岛人才市场招聘会,青岛人才市场网络招聘,青岛代缴保险,青岛劳务派遣,青岛人事代理,短工供应,就业安置等" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" Theme="Blue" AutoSizePanelID="Panel1" runat="server"></x:PageManager>
        <x:Panel ID="Panel1" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
            BodyPadding="5px" EnableBackgroundColor="true">
            <Toolbars>
                <x:Toolbar ID="Toolbar2" runat="server">
                    <Items>
                        <x:Button ID="btnAdd" runat="server" Text="添加图片" Icon="Add">
                        </x:Button>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server"></x:ToolbarSeparator>
                        <x:Button ID="btnDel" runat="server" Text="删除图片" Icon="BulletCross" OnClick="btnDel_Click"></x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Grid ID="grid1" PageSize="10" ShowBorder="true" ShowHeader="false"
                    AutoHeight="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                    Width="800px" DataKeyNames="ADImageGUID" OnPageIndexChange="Grid1_PageIndexChange"
                    EnableRowNumber="True" IsDatabasePaging="true"
                    OnRowDataBound="Grid1_RowDataBound" ForceFitAllTime="true" EnableAjaxLoading="true">
                    <Columns>
                        <x:BoundField Width="100px" DataField="AdImageTitle" HeaderText="图片标题" TextAlign="Center" />
                        <x:BoundField Width="150px" DataField="ADLink" HeaderText="链接地址" TextAlign="Center" />
                        <x:BoundField Width="100px" DataField="PublishDate" HeaderText="发布日期" TextAlign="Center" DataFormatString="{0:yyyy年MM月dd日}" />
                        <x:TemplateField HeaderText="编辑操作" TextAlign="Center">
                            <ItemTemplate>
                                <a style="text-decoration: none;" href="<%# GetEditUrl(DataBinder.Eval(Container.DataItem, "[ADImageGUID]")) %>">编辑</a>
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
