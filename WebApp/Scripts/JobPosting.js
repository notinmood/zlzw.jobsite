$().ready(function () {
    $("#txbJobPositionKinds").watermark("请选择岗位类别");
    $('#txbJobPositionKinds').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/JobPositionKinds.aspx', { title: '请选择岗位类别', width: 550, height: 299 });
    });
    /* 日期格式 */
    $.extend($.fn.validatebox.defaults.rules, {
        DateFormatTo: {
            validator: function (value) {
                //格式yyyy-MM-dd或yyyy-M-d
                if (value == "无"){
                    return true;
                }
                if (value == "") {
                    return true;
                }
                return /^(?:(?!0000)[0-9]{4}([-]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-]?)0?2\2(?:29))$/i.test(value);
            },
            message: '日期格式不正确'
        }
    });
    /* 手机格式 */
    $.extend($.fn.validatebox.defaults.rules, {
        MobilTo: {
            validator: function (value) {
                return /^(13|15|18)\d{9}$/i.test(value);
            },
            message: '手机号码格式不正确'
        }
    });
    /* 电话格式 */
    $.extend($.fn.validatebox.defaults.rules, {
        phone: {// 验证电话号码 
            validator: function (value) {
                if (/^(13|15|18)\d{9}$/i.test(value)) {
                    return true;
                }
                if (/^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value)) {
                    return true;
                }
                return false;
            },
            message: '格式不正确,请使用下面格式:0532-88888888'
        }
    });
});

function validata_Submit() {
    if (!$('#form01').form('validate')) {
        return false;
    }
    else {
        return true;
    }
}