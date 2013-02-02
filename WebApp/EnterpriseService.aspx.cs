using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class EnterpriseService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Load_EnterpriseServiceConten(Request.QueryString["id"]);
                    Load_MenuList();//加载菜单内容
                }
                catch (Exception exp)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        #region 加载导航内容

        private void Load_EnterpriseServiceConten(string strType)
        {
            titleName.Text = Get_EnterpriseServiceName(strType);
            zlzw.BLL.EnterpriseServiceInfoListBLL enterpriseServiceInfoListBLL = new zlzw.BLL.EnterpriseServiceInfoListBLL();
            System.Data.DataTable dt = enterpriseServiceInfoListBLL.GetList("EnterpriseServiceTypeGUID='" + strType + "'").Tables[0];
            labContent.Text = dt.Rows[0]["EnterpriseServiceInfoContent"].ToString();
        }

        #endregion

        #region 加载菜单内容

        private void Load_MenuList()
        {
            zlzw.BLL.EnterpriseServiceTypeListBLL enterpriseServiceTypeListBLL = new zlzw.BLL.EnterpriseServiceTypeListBLL();
            System.Data.DataTable dt = enterpriseServiceTypeListBLL.GetList("IsEnable=1 order by OrderNumber asc").Tables[0];

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
                if (drv["EnterpriseServiceTypeGUID"].ToString() == Request.QueryString["id"])
                {
                    labMenuItem.Text = "<td style='width:100%;background-color:#FA9A08;'><a href='#' style='text-decoration:none;color:#fff; font-weight:bold;'>" + drv["EnterpriseServiceTypeName"].ToString() + "</a></td>";
                }
                else
                {
                    labMenuItem.Text = "<td style='width:100%;'><a href='EnterpriseService.aspx?id=" + drv["EnterpriseServiceTypeGUID"].ToString() + "' style='text-decoration:none;color:#fff;color:#093C7E;'>" + drv["EnterpriseServiceTypeName"].ToString() + "</a></td>";
                }

            }
        }

        #endregion

        #region 根据GUID获取导航名称

        private string Get_EnterpriseServiceName(string strGUID)
        {
            zlzw.BLL.EnterpriseServiceTypeListBLL enterpriseServiceTypeListBLL = new zlzw.BLL.EnterpriseServiceTypeListBLL();
            System.Data.DataTable dt = enterpriseServiceTypeListBLL.GetList("EnterpriseServiceTypeGUID='" + strGUID + "'").Tables[0];

            return dt.Rows[0]["EnterpriseServiceTypeName"].ToString();
        }

        #endregion
    }
}