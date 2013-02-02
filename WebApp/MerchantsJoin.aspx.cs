using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class MerchantsJoin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Load_NavigateConten();
                    Load_MenuList();//加载菜单内容
                }
                catch (Exception exp)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        #region 加载导航内容

        private void Load_NavigateConten()
        {
            titleName.Text = "招商加盟";
            zlzw.BLL.MerchantsJoinListBLL merchantsJoinListBLL = new zlzw.BLL.MerchantsJoinListBLL();
            System.Data.DataTable dt = merchantsJoinListBLL.GetList("IsEnable=1").Tables[0];
            labContent.Text = dt.Rows[0]["MerchantsJoinConetnt"].ToString();
        }

        #endregion

        #region 加载菜单内容

        private void Load_MenuList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='MerchantsJoin' and CanUsable=1").Tables[0];

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        #endregion

        #region 菜单行绑定事件

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labMenuItem = (Label)e.Item.FindControl("labMenuItem");
                labMenuItem.Text = "<td style='width:100%;background-color:#FA9A08;'><a href='#' style='text-decoration:none;color:#fff; font-weight:bold;'>" + drv["SettingValue"].ToString() + "</a></td>";
            }
        }

        #endregion
    }
}