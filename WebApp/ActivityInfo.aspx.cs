using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ActivityInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Load_ActivityInfo(Request.QueryString["ID"]);
                }
                catch (Exception exp)
                {
                    Response.Redirect("ActivityList.aspx");
                }
            }
        }

        #region 加载招聘会内容

        private void Load_ActivityInfo(string strActivityID)
        {
            zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
            DataTable dt = generalActivityBLL.GetList("ActivityGuid='"+ strActivityID +"'").Tables[0];
            string strTitle = dt.Rows[0]["ActivityTitle"].ToString();//招聘会标题;
            labNavigate.Text = strTitle;//招聘会标题
            labTitle.Text = strTitle;//招聘会标题
            titleName.Text = strTitle;//招聘会标题
            labPublishName.Text = dt.Rows[0]["CreateUserName"].ToString();//发布人
            labDateTime.Text = Set_DateFormat(dt.Rows[0]["PublishDate"].ToString());//发布日期
            labContent.Text = dt.Rows[0]["ActivityDesc"].ToString();//内容
        }

        #endregion

        #region 日期格式转换

        private string Set_DateFormat(string strDate)
        {
            DateTime dateTime = DateTime.Parse(strDate);

            return dateTime.ToString("yyyy年MM月dd日");
        }

        #endregion
    }
}