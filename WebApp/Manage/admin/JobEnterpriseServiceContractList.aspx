<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobEnterpriseServiceContractList.aspx.cs" Inherits="WebApp.Manage.admin.JobEnterpriseServiceContractList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <%--<x:PageManager ID="PageManager1" Theme="Blue" AutoSizePanelID="Panel1" runat="server">
    </x:PageManager>
    <x:Panel ID="Panel1" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <x:Button ID="btnAdd" runat="server" Text="添加管理员" Icon="Add">
                    </x:Button>
                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server"></x:ToolbarSeparator>
                    <x:Button ID="btnDel" runat="server" Text="删除管理员" Icon="BulletCross" OnClick="btnDel_Click"></x:Button>
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Grid ID="grid1" PageSize="10" ShowBorder="true" ShowHeader="false"
                AutoHeight="true" AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                Width="800px" DataKeyNames="ServiceContractGuid" OnPageIndexChange="Grid1_PageIndexChange"
                EnableRowNumber="True" IsDatabasePaging="true" 
                OnRowDataBound="Grid1_RowDataBound" ForceFitAllTime="true" EnableAjaxLoading="true">
                <Columns>
                    <x:BoundField Width="100px" DataField="CreateUserName" HeaderText="合同创建人" TextAlign="Center" />
                    <x:BoundField Width="70px" DataField="EnterpriseName" HeaderText="企业名称" TextAlign="Center" />
                    <x:BoundField Width="100px" DataField="ServiceFee" HeaderText="缴费数额" TextAlign="Center" />
                    <x:BoundField Width="100px" DataField="ServiceContractStartDate" HeaderText="缴费开始日期" TextAlign="Center" DataFormatString="{0:yyyy年MM月dd日}"/>
                    <x:BoundField Width="100px" DataField="ServiceContractEndDate" HeaderText="下次缴费日期" TextAlign="Center" DataFormatString="{0:yyyy年MM月dd日}" />
                    <x:CheckBoxField DataField="ServiceFeeIsPaid" HeaderText="缴费是否成功" TextAlign="Center"></x:CheckBoxField>
                    <x:BoundField Width="100px" DataField="ServiceFeeManageUserName" HeaderText="收款人" TextAlign="Center" />
                    <x:BoundField Width="100px" DataField="CreateDate" HeaderText="创建日期" TextAlign="Center" />
                    <x:TemplateField HeaderText="编辑操作" TextAlign="Center">
                        <ItemTemplate>
                            <a style="text-decoration:none;" href="<%# GetEditUrl(DataBinder.Eval(Container.DataItem, "[ServiceContractGuid]")) %>">编辑</a>
                        </ItemTemplate>
                    </x:TemplateField>
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:Window ID="Window1" Title="Edit" Popup="false" EnableIFrame="true" runat="server"
        IFrameUrl="about:blank" Target="Self" IsModal="True" Width="750px" Height="450px">
    </x:Window>--%>
    </form>
</body>
</html>
