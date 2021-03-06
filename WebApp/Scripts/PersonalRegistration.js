﻿$().ready(function () {
    $("#txbJobPositionKinds").watermark("请选择岗位类别");
    $("#txbJobFeildKinds").watermark("请选择行业类别");
    $('#txbJobPositionKinds').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 550, height: 299 });
    });
    $('#txbJobFeildKinds').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/JobFeildKinds.aspx', { title: '请选择行业类别', width: 850, height: 235 });
    });
    $('#drpJobPositionKindsType').bind('change', function () {
        $.ajax({
            type: 'POST',
            url: 'Services/GetGeneralBasicSetting.asmx/Get_JobPositionKindsList',
            contentType: 'application/json',
            data: '{"strJobPositionKindsType":"' + $('#drpJobPositionKindsType').val() + '"}',
            success: function (data) {
                if (data.d != "-1") {
                    $('#drpJobPositionKinds').empty();
                    $('#drpJobPositionKinds').append(data.d);
                    return;
                }
            }
        });
    });

    $('#drpJobPositionKinds').bind('change', function () {
        $('#Hidden1').val(this.value);
    });

    $('#drpJobFeildKinds').bind('change', function () {
        $('#Hidden2').val(this.value);
    });

    $('#drpJobFeildKindsType').bind('change', function () {
            $.ajax({
                type: 'POST',
                url: 'Services/GetGeneralBasicSetting.asmx/Get_JobPositionKindsList',
                contentType: 'application/json',
                data: '{"strJobPositionKindsType":"' + $('#drpJobFeildKindsType').val() + '"}',
                success: function (data) {
                    if (data.d != "-1") {
                        $('#drpJobFeildKinds').empty();
                        $('#drpJobFeildKinds').append(data.d);
                        return;
                    }
                }
            });
        });

    /* 验证两个值是否相同 */
    $.extend($.fn.validatebox.defaults.rules, {
        equalTo: {
            validator: function (value, param) {
                return $(param[0]).val() == value;
            },
            message: '两次密码输入不匹配'
        }

    });
    /* 日期格式 */
    $.extend($.fn.validatebox.defaults.rules, {
        DateFormatTo: {
            validator : function(value) { 
                //格式yyyy-MM-dd或yyyy-M-d
                return /^(?:(?!0000)[0-9]{4}([-]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-]?)0?2\2(?:29))$/i.test(value); 
            },
            message : '日期格式不正确'
        }
    });
    /* 手机格式 */
    $.extend($.fn.validatebox.defaults.rules, {
        MobilTo: {
            validator : function(value) { 
                return /^(13|15|18)\d{9}$/i.test(value); 
            }, 
            message : '手机号码格式不正确' 
        }
    });

    /* 整数或小数验证 */
    $.extend($.fn.validatebox.defaults.rules, {
        intOrFloat: {// 验证整数或小数 
            validator: function (value) {
                return /^\d+(\.\d+)?$/i.test(value);
            },
            message: '身高格式不正确'
        }
    });

    /* 用户名是否被重复注册 */
    $.extend($.fn.validatebox.defaults.rules, {
        RepeatRegisterName: { 
            validator: function (value) {
                var returnValue;
                $.ajax({
                    url: '../Services/ValidatorRegisterUser.asmx/ValidatorUserName',
                    contentType: 'application/json',
                    data: '{"strUserName":"' + value + '"}',
                    async: false,
                    cache: false,
                    type: "post",
                    success: function (data) {
                        returnValue = data.d;
                    }
                });
                return returnValue;
            },
            message: "该用户名已被占用"
        }
    });
});

function validata_Submit()
{
    if(!$('#form01').form('validate'))
    {
        return false;
    }
    else
    {
        return true;
    }
}