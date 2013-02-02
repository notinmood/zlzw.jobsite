using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.UserControl
{
    public partial class JobCategories : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_NonManageTypeList();//加载非管理类职位
                Load_ManageTypeList();//加载管理类职位
            }
        }

        #region 加载非管理类职位

        private void Load_NonManageTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='非管理' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                if (nCount > 19)
                {
                    if (nCount == 19)
                    {
                        labNonManageTypeOther.Text += dt.Rows[nCount]["SettingValue"].ToString();
                    }
                    else
                    {
                        labNonManageTypeOther.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
                    }
                }
                else
                {
                    labNonManageType.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
                }
            }
        }

        #endregion

        #region 加载管理类职位

        private void Load_ManageTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='管理' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                labManageType.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
            }
        }

        #endregion
    }
}