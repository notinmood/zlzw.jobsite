$().ready(function () {
    $('#linkBtnPassword').bind('click', function () {
        var dialog = art.dialog.open('TemplatePage/PostMail.aspx', { title: '密码找回', width: 440, height: 199 });
    });

    $('#btnPostMail').bind('click', function () {
        $.ajax({
            type: 'POST',
            url: '../Services/PostMail.asmx/Send_UserMail',
            contentType: 'application/json',
            data: '{"strUserName":"' + $('#txbUserName').val() + '","strUserMail":"' + $('#txbMail').val() + '","strNum":"' + $('#txbNum').val() + '"}',
            success: function (data) {
                if (data.d == "VerificationCode_Error") {
                    alert("验证码错误");
                }
                else if (data.d == "NotExist") {
                    alert("用户不存在");
                }
                else if (data.d == "PostSucces") {
                    alert("密码已经发送到您的邮箱");
                }
                else if (data.d == "PostException") {
                    alert("密码发送失败，请稍后重试或联系客服人员");
                }

            }
        });
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