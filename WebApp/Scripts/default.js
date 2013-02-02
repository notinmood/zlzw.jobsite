﻿$().ready(function () {
    $.ajax({
        type: 'POST',
        url: 'Services/ManageADImage.asmx/Get_ADImageList',
        contentType: 'application/json',
        data: '', 
        success: function(data) {
            if(data.d != "")
            {
                $('#portfolio').append(data.d);
                $('ul#portfolio').innerfade({
                    speed: 1000,
                    timeout: 5000,
                    type: 'sequence',
                    containerheight: '165px'
                });
            }
        }
    });
    var strUserType = 2;
    $('[type*=radio]').bind('click', function () {
        strUserType = this.value;
    });

    $('#linkBtnCancel').bind('click', function () {
        $.ajax({
            type: 'POST',
            url: 'Services/ValidateLogin.asmx/Logout',
            contentType: 'application/json',
            data: '{}',
            success: function (data) {
                if (data.d == "-1") {
                    alert("注销失败，请稍后重试");
                    return;
                }
                else if (data.d == "1") {
                    window.location.href = 'default.aspx';
                }
                else {
                }
            }
        });
    });

    $('#btnSubmit').bind('click', function () {
        if (!$('#form01').form('validate')) {
            return false;
        }
        $.ajax({
            type: 'POST',
            url: 'Services/ValidateLogin.asmx/ValidateUser',
            contentType: 'application/json',
            data: '{"strUserType":"' + strUserType + '","strUserName":"' + setContent($('#txbUsername').val()) + '","strUserPass":"' + setContent($('#txbPassword').val()) + '"}',
            success: function (data) {
                if (data.d == "-1") {
                    alert("登录失败，用户类型错误");
                    return;
                }
                else if (data.d == "0") {
                    alert("登录失败，账号或密码错误");
                    return;
                }
                else
                {
                    window.location.href = 'EditEnterpriseInfo.aspx?id='+data.d;
                }
            }
        });
    });

    $('#txbUsername').watermark("登陆账号");
    $("#txbJobPositionKinds").watermark("请选择岗位类别");
    $("#txbJobFeildKinds").watermark("请选择行业类别");
    $("#txbSearchKey").watermark("公司名或职位关键字");
    $('#txbWorkAreas').watermark("请选择工作地区");
    //art.dialog.open('TemplatePage/JobPositionKinds.aspx');
    $('#txbJobPositionKinds').bind('click', function () {
       var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 755, height: 299 });
    });
    $('#txbJobFeildKinds').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/JobFeildKinds.aspx', { title: '请选择行业类别', width: 1048, height: 230 });
    });
    $('#txbWorkAreas').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/WorkAreas.aspx', { title: '请选择工作地区', width: 755, height: 330 });
    });
});

function Load_JobPositionKinds() {
    var val = document.getElementById('txbJobPositionKinds').value;
}
function setContent(str) {
    str = str.replace(/<\/?[^>]*>/g, ''); //去除HTML tag
    str.value = str.replace(/[ | ]*\n/g, '\n'); //去除行尾空白
    //str = str.replace(/\n[\s| | ]*\r/g,'\n'); //去除多余空行
    return str;
}
