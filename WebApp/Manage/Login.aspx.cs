using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Manage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitCaptchaCode();
            }
        }
        
        /// <summary>
        /// 初始化验证码
        /// </summary>
        private void InitCaptchaCode()
        {
            // 创建一个 6 位的随机数并保存在 Session 对象中
            Session["CaptchaImageText"] = GenerateRandomCode();
            imgCaptcha.ImageUrl = "captcha/captcha.ashx?w=150&h=30&t=" + DateTime.Now.Ticks;
        }

        /// <summary>
        /// 创建一个 6 位的随机数
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomCode()
        {
            string s = String.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                s += random.Next(10).ToString();
            }
            return s;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            InitCaptchaCode();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxCaptcha.Text != Session["CaptchaImageText"].ToString())
            {
                Alert.ShowInTop("验证码错误！");
                InitCaptchaCode();
                return;
            }
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();

            System.Data.DataTable dt = coreUserBLL.GetList("UserName='" + tbxUserName.Text + "' and Password='"+ tbxPassword.Text +"'").Tables[0]; 
            if (dt.Rows.Count > 0)
            {
                HttpCookie cookie = new HttpCookie("UserID", dt.Rows[0]["UserGuid"].ToString());
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                //HttpCookie cookie01 = new HttpCookie("UserName", HttpUtility.UrlEncode(dt.Rows[0]["UserName"].ToString(), System.Text.Encoding.GetEncoding("GB2312")));
                //cookie.Expires = DateTime.Now.AddDays(1);
                //Response.Cookies.Add(cookie01);
                Update_UserInfo(coreUserBLL, dt.Rows[0]["UserGuid"].ToString());
                Response.Redirect("default.aspx",true);
                //Server.Transfer("default.aspx");
            }
            else
            {
                Alert.ShowInTop("用户名或密码错误！", MessageBoxIcon.Error);
                InitCaptchaCode();
                return;
            }
        }

        #region 更新用户信息

        private void Update_UserInfo(zlzw.BLL.CoreUserBLL coreUserBLL,string strUserGUID)
        {
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
            zlzw.Model.CoreUserModel coreUserModel = coreUserBLL.GetModel(int.Parse(dt.Rows[0]["UserID"].ToString()));;
            coreUserModel.UserLastDateTime = DateTime.Now;
            coreUserBLL.Update(coreUserModel);
        }

        #endregion
    }
}