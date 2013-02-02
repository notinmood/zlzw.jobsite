using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.UserControl
{
    public partial class PageHead : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.Cookies["CurrentUserGUID"] != null)
                    {
                        string strParam = Request.Cookies["CurrentUserGUID"].Value;
                        linkBtnResumeCenter.HRef = "../EditPersonalInfo.aspx?id=" + strParam;
                        linkBtnActivityList.HRef = "../ActivityList.aspx?id=" + strParam;
                        linkBtnJobSearchList.HRef = "../JobSearchList.aspx?id=" + strParam;
                        Set_ExchangeCornerList();//设置交流园地链接地址
                        Set_MerchantsJoin();//招商加盟
                    }
                }
                catch (Exception exp)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }
        #region 设置招商加盟

        private void Set_MerchantsJoin()
        {
            linkBtnMerchantsJoin.HRef = "../MerchantsJoin.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value;
        }

        #endregion

        #region 设置交流园地链接地址

        private void Set_ExchangeCornerList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("CanUsable=1 and SettingCategory='ExchangeCornerType' order by OrderNumber asc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                linkBtnExchangeCorner.HRef = "../ExchangeCorner.aspx?id=" + dt.Rows[0]["DisplayName"].ToString();
            }
        }

        #endregion
    }
}