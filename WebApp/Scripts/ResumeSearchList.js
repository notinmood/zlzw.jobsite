$().ready(function () {
    $("#txbJobPositionKinds").watermark("请选择岗位类别");
    $("#txbJobFeildKinds").watermark("请选择行业类别");
    $("#txbSearchKey").watermark("职位关键字/词");
    $('#txbWorkAreas').watermark("请选择工作地区");
    //art.dialog.open('TemplatePage/JobPositionKinds.aspx');
    $('#txbJobPositionKinds').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 550, height: 299 });
    });
    $('#txbJobFeildKinds').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/JobFeildKinds.aspx', { title: '请选择行业类别', width: 850, height: 235 });
    });
    $('#txbWorkAreas').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/WorkAreas.aspx', { title: '请选择工作地区', width: 755, height: 330 });
    });
});

function setContent(str) {
    str = str.replace(/<\/?[^>]*>/g, ''); //去除HTML tag
    str.value = str.replace(/[ | ]*\n/g, '\n'); //去除行尾空白
    //str = str.replace(/\n[\s| | ]*\r/g,'\n'); //去除多余空行
    return str;
}

function validatorForm() {

    if (!$('#form01').form('validate')) {
        return false;
    }
    else {
        return true;
    }
}