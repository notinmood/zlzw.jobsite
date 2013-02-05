using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.UserControl
{
    public partial class IndustrySector : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_zzyList();//加载制造业职位
                Load_dscyList();//加载第三产业职位
                Load_ddcyTypeList();//家在第一产业职位
            }
        }

        #region 加载第三产业职位

        private void Load_dscyList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='第三产业' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                landscy.Text += "<a href='SearchList.aspx?Type=2&id=" + HttpUtility.UrlEncode(dt.Rows[nCount]["SettingValue"].ToString()) + "' style='text-decoration:none;color:#325C93;'>" + dt.Rows[nCount]["SettingValue"].ToString() + "</a>　";
            }
        }

        #endregion

        #region 加载第一产业职位

        private void Load_ddcyTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='第一产业' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                labddcyType.Text += "<a href='SearchList.aspx?Type=2&id=" + HttpUtility.UrlEncode(dt.Rows[nCount]["SettingValue"].ToString()) + "' style='text-decoration:none;color:#325C93;'>" + dt.Rows[nCount]["SettingValue"].ToString() + "</a>　";
            }
        }

        #endregion

        #region 加载制造业职位

        private void Load_zzyList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='制造行业' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                labzzyType.Text += "<a href='SearchList.aspx?Type=2&id=" + HttpUtility.UrlEncode(dt.Rows[nCount]["SettingValue"].ToString()) + "' style='text-decoration:none;color:#325C93;'>" + dt.Rows[nCount]["SettingValue"].ToString() + "</a>　";
            }
        }

        #endregion
    }
}