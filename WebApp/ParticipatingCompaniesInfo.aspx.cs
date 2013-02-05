using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ParticipatingCompaniesInfo : System.Web.UI.Page
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
                    Response.Redirect("ParticipatingCompaniesList.aspx");
                }
            }
        }
        #region 加载招聘会内容

        private void Load_ActivityInfo(string strActivityID)
        {
            zlzw.BLL.ParticipatingCompaniesListBLL participatingCompaniesListBLL = new zlzw.BLL.ParticipatingCompaniesListBLL();
            System.Data.DataTable dt = participatingCompaniesListBLL.GetList("ParticipatingCompaniesGUID='" + strActivityID + "'").Tables[0];
            string strTitle = Get_EnterpriseName(dt.Rows[0]["EnterpriseGuid"].ToString());//企业名称;
            labNavigate.Text = "招聘会参加企业-"+strTitle;//企业名称
            labTitle.Text = strTitle;//招聘会标题
            titleName.Text = strTitle;//招聘会标题
            labDateTime.Text = Set_DateFormat(dt.Rows[0]["PublishDate"].ToString());//发布日期
            labContent.Text = dt.Rows[0]["ParticipatingCompaniesContent"].ToString();//内容
        }

        #endregion

        #region 获取企业名称

        private string Get_EnterpriseName(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("CanUsable=1 and EnterpriseGuid='" + strEnterpriseGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["CompanyName"].ToString();
            }
            else
            {
                return "未知";
            }
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