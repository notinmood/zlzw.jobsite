using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.UserControl
{
    public partial class EnterpriseHead : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strParam = Request.QueryString["id"];
                    linkBtnEnterpriseInfo.HRef = "../EditEnterpriseInfo.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value;
                    linkBtnEnterpriseJobPosting.HRef = "../JobPosting.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value;
                    linkBtnResumeSearchList.HRef = "../ResumeSearchList.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value;
                    Get_NavigateItemGUID();
                    Set_ExchangeCornerList();//设置交流园地链接地址
                }
                catch (Exception exp)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        #region 设置交流园地链接地址

        private void Set_ExchangeCornerList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("CanUsable=1 and SettingCategory='ExchangeCornerType' order by OrderNumber asc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                linkBtnExchangeCornerList.HRef = "../ExchangeCornerList.aspx?id="+dt.Rows[0]["DisplayName"].ToString();
            }
        }

        #endregion

        #region 获取第一个显示的菜单项GUID

        private void Get_NavigateItemGUID()
        {
            zlzw.BLL.NavigateListBLL navigateListBLL = new zlzw.BLL.NavigateListBLL();
            System.Data.DataTable dt = navigateListBLL.GetList("IsEnable=1 and IsShow=1 order by OrderNumber asc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                linkBtnServiceItem.HRef = "../EnterpriseServiceList.aspx?id=" + dt.Rows[0]["NavigateGUID"].ToString();
            }
        }

        #endregion
    }
}