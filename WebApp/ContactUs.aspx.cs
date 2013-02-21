using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Load_NavigateConten(Request.QueryString["id"]);
                    Load_MenuList();//加载菜单内容
                }
                catch (Exception exp)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        #region 加载导航内容

        private void Load_NavigateConten(string strType)
        {
            titleName.Text = Get_NavigateName(strType);
            zlzw.BLL.NavigateInfoListBLL navigateInfoListBLL = new zlzw.BLL.NavigateInfoListBLL();
            System.Data.DataTable dt = navigateInfoListBLL.GetList("NavigateGUID='" + strType + "'").Tables[0];
            labContent.Text = dt.Rows[0]["NavigateInfoContent"].ToString();
        }

        #endregion

        #region 加载菜单内容

        private void Load_MenuList()
        {
            zlzw.BLL.NavigateListBLL navigateListBLL = new zlzw.BLL.NavigateListBLL();
            System.Data.DataTable dt = navigateListBLL.GetList("IsEnable=1 and IsShow=1 order by OrderNumber asc").Tables[0];

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        #endregion

        #region 根据GUID获取导航名称

        private string Get_NavigateName(string strGUID)
        {
            zlzw.BLL.NavigateListBLL navigateListBLL = new zlzw.BLL.NavigateListBLL();
            System.Data.DataTable dt = navigateListBLL.GetList("NavigateGUID='" + strGUID + "'").Tables[0];

            return dt.Rows[0]["NavigateName"].ToString();
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
                if (drv["NavigateGUID"].ToString() == Request.QueryString["id"])
                {
                    labMenuItem.Text = "<td style='width:100%;background-color:#FA9A08;'><a href='#' style='text-decoration:none;color:#fff; font-weight:bold;'>" + drv["NavigateName"].ToString() + "</a></td>";
                }
                else
                {
                    labMenuItem.Text = "<td style='width:100%;'><a href='ContactUs.aspx?id=" + drv["NavigateGUID"].ToString() + "' style='text-decoration:none;color:#fff;color:#093C7E;'>" + drv["NavigateName"].ToString() + "</a></td>";
                }

            }
        }

        #endregion
    }
}