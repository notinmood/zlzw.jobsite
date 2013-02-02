<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkAreas.aspx.cs" Inherits="WebApp.TemplatePage.WorkAreas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="http://lib.sinaapp.com/js/jquery/1.9.0/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/WebForms/jquery.artDialog.js"></script>
    <script type="text/javascript" src="../Scripts/WebForms/iframeTools.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table style="font-size:12px;">
            <tr>
                <td>
                    <table>
                        <thead>
                            <tr>
                                <td>
                                    <span style="color:#093C7E; font-size:14px; font-weight:bold;">&nbsp;&nbsp;工作区域</span>
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" OnItemDataBound="DataList1_ItemDataBound">
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="labJobPositionKinds" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="width:10px;"></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </form>
    <script type="text/javascript">
        function selectOne(obj) {
            var objCheckBox = document.getElementsByName("checkbox");
            for (var i = 0; i < objCheckBox.length; i++) {
                //判断复选框集合中的i元素是否为obj，若为否则便是未被选中 
                if (objCheckBox[i] != obj) {
                    objCheckBox[i].checked = false;
                } else {
                    //若是，原先为被勾选的变成勾选，反之则变成未勾选 
                    //objCheckBox[i].checked = obj.checked; 

                    //或者使用下句，亦可达到同样效果 
                    objCheckBox[i].checked = true;
                }
            }
        }
        $().ready(function () {
            $("input[type*='checkbox']").bind('change', function () {
                var origin = artDialog.open.origin;
                var aValue = this.value;
                var input = origin.document.getElementById('txbWorkAreas');
                input.value = aValue;
                input.select();
                art.dialog.close();

            });
        });
    </script>
</body>
</html>
