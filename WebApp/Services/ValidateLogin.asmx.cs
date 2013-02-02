using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApp.Services
{
    /// <summary>
    /// ValidateLogin 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class ValidateLogin : System.Web.Services.WebService
    {
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="strUserType"></param>
        /// <param name="strUserName"></param>
        /// <param name="strUserPass"></param>
        /// <returns></returns>
        [WebMethod]
        public string ValidateUser(string strUserType, string strUserName, string strUserPass)
        {
            if (int.Parse(strUserType) > 2)
            {
                return "-1";//用户类型错误
            }
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserName='" + strUserName + "' and Password='" + strUserPass + "' and UserType='" + strUserType + "' and UserStatus=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                HttpCookie userGUID = new HttpCookie("CurrentUserGUID", dt.Rows[0]["UserGuid"].ToString());
                HttpCookie uerName = new HttpCookie("CurrentUserName", dt.Rows[0]["UserName"].ToString());
                userGUID.Expires = DateTime.Now.AddDays(1);
                uerName.Expires = DateTime.Now.AddDays(1);

                System.Web.HttpContext.Current.Response.Cookies.Add(userGUID);
                System.Web.HttpContext.Current.Response.Cookies.Add(uerName);

                return dt.Rows[0]["UserGuid"].ToString();//用户登录成功
            }
            else
            {
                return "0";//当前用户不存在
            }
        }

        [WebMethod]
        public int Logout()
        {
            try
            {
                System.Web.HttpCookie UserGUID = System.Web.HttpContext.Current.Request.Cookies["CurrentUserGUID"];
                System.Web.HttpCookie UserName = System.Web.HttpContext.Current.Request.Cookies["CurrentUserName"];

                UserGUID.Expires = DateTime.Now.AddDays(-1);
                UserName.Expires = DateTime.Now.AddDays(-1);

                System.Web.HttpContext.Current.Response.Cookies.Add(UserGUID);
                System.Web.HttpContext.Current.Response.Cookies.Add(UserName);

                return 1;
            }
            catch (Exception exp)
            {
                return -1;
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
