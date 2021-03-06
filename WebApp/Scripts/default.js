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
                    containerheight: '365px',
                    browerType:Get_IsIE6()
                });
            }
        }
    });
    var strUserType = 1;
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
                    var val = $('input:radio[name="userType"]:checked').val();
                    if (val == "1") {
                        window.location.href = 'JobSearchList.aspx?id=' + data.d;
                        return;
                    } else if (val == "2") {
                        window.location.href = 'JobPosting.aspx?id=' + data.d;
                        return;
                    }
                }
            }
        });
    });

    $('#txbUsername').watermark("登陆账号");
    $("#txbJobPositionKinds").watermark("请选择岗位类别");
    $("#txbJobFeildKinds").watermark("请选择行业类别");
    $("#txbSearchKey").watermark("公司或职位 关键字/词");
    $('#txbWorkAreas').watermark("请选择工作地区");
    //art.dialog.open('TemplatePage/JobPositionKinds.aspx');
    $('#txbJobPositionKinds').bind('click', function () {
        IeType();
    });
    $('#txbJobFeildKinds').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/JobFeildKinds.aspx', { title: '请选择行业类别', width: 855, height: 330 });
    });
    $('#txbWorkAreas').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/WorkAreas.aspx', { title: '请选择工作地区', width: 855, height: 340 });
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

function Get_IsIE6() {
    var browser=navigator.appName
    var b_version=navigator.appVersion
    var version=b_version.split(";");
    if (browser == "Microsoft Internet Explorer") {
        var trim_Version = version[1].replace(/[ ]/g, "");
        if (trim_Version == "MSIE6.0") {
            return "IE6.0";
        }
        else {
            return "";
        }
    }
}

function IeType() {
    var browser=navigator.appName
    var b_version=navigator.appVersion
    var version=b_version.split(";");
    if (browser == "Microsoft Internet Explorer") {
        var trim_Version = version[1].replace(/[ ]/g, "");
        if (trim_Version == "MSIE6.0") {
            var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 960, height: 310 });
            return;
        }
        else if (trim_Version == "MSIE7.0") {
            var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 550, height: 299 });
            return;
        }
        else if (trim_Version == "MSIE8.0") {
            var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 550, height: 299 });
            return;
        }
        else if (trim_Version == "MSIE9.0") {
            var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 550, height: 299 });
            return;
        }
        else if (trim_Version == "MSIE10.0") {
            var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 550, height: 299 });
            return;
        }
    }
    else {
        var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 600, height: 299 });
    } 
}