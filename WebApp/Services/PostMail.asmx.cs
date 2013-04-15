using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.Net.Mail; 

namespace WebApp.Services
{
    /// <summary>
    /// PostMail 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class PostMail : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string Send_UserMail(string strUserName, string strUserMail,string strNum)
        {
            System.Web.HttpCookie VerifyCode = System.Web.HttpContext.Current.Request.Cookies["VerifyCode"];
            if (VerifyCode == null)
            {
                return "VerificationCode_Error";//验证码错误
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserName='"+ strUserName +"' and UserStatus=1").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string strUserType = dt.Rows[0]["UserType"].ToString();
                    if (strUserType == "1")
                    {
                        return Post_UserPasword(dt.Rows[0]["UserEmail"].ToString(), dt.Rows[0]["Password"].ToString(),strUserName);//当前个人账号存在
                    }
                    else if (strUserType == "2")
                    {
                        string strUserGUID = dt.Rows[0]["UserGuid"].ToString();

                        zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
                        System.Data.DataTable dt01 = generalEnterpriseBLL.GetList("UserGuid='" + strUserGUID + "' and CanUsable=1").Tables[0];
                        return Post_UserPasword(dt01.Rows[0]["Email"].ToString(), dt.Rows[0]["Password"].ToString(), dt01.Rows[0]["CompanyName"].ToString());
                    }
                }
                else
                {
                    return "NotExist";//用户名不存在
                }

                return "-1";
            }
        }

        #region 邮件发送

        private string Post_UserPasword(string strUserMail,string strUserPassword,string strUserName)
        {
            //设置发件人信箱,及显示名字 
            MailAddress from = new MailAddress("service@qdrcsc.net", "职行天下官方网站");
            //设置收件人信箱,及显示名字 
            MailAddress to = new MailAddress(strUserMail, strUserName);
            //创建一个MailMessage对象 
            MailMessage oMail = new MailMessage(from, to);

            oMail.Subject = "职行天下官方网站-密码找回"; //邮件标题 
            oMail.Body = "您的登陆密码为："+strUserPassword; //邮件内容 

            oMail.IsBodyHtml = true; //指定邮件格式,支持HTML格式 
            oMail.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");//邮件采用的编码 
            oMail.Priority = MailPriority.High;//设置邮件的优先级为高 

            //发送邮件服务器 
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.exmail.qq.com"; //指定邮件服务器 
            client.Credentials = new NetworkCredential("service@qdrcsc.net", "qingdao987");//指定服务器邮件,及密码 

            //发送 
            try
            {
                client.Send(oMail); //发送邮件 
                return "PostSucces";//邮件发送成功
            }
            catch
            {
                return "PostException";//邮件发送失败
            }
            finally
            {
                oMail.Dispose(); //释放资源 
            }
        }

        #endregion

    }
}
