using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.TemplatePage
{
    public partial class JobFeildKinds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_IndustrySectorList();//加载行业类别
            }
        }

        #region 加载行业类别列表

        private void Load_IndustrySectorList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='制造行业' and CanUsable=1 order by OrderNumber asc").Tables[0];

            DataList1.DataSource = dt;
            DataList1.DataBind();

            dt = generalBasicSettingBLL.GetList("DisplayName='第三产业' and CanUsable=1 order by OrderNumber asc").Tables[0];
            DataList2.DataSource = dt;
            DataList2.DataBind();

            dt = generalBasicSettingBLL.GetList("DisplayName='第一产业' and CanUsable=1 order by OrderNumber asc").Tables[0];
            DataList3.DataSource = dt;
            DataList3.DataBind();
        }

        #endregion

        #region 制造行业行绑定事件

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labManufacturingIndustry = (Label)e.Item.FindControl("labManufacturingIndustry");

                labManufacturingIndustry.Text = "<input id='" + drv["SettingKey"].ToString() + "' type='checkbox' name='checkbox' value='" + drv["SettingValue"].ToString() + "' onclick='selectOne(this)' />" + drv["SettingValue"].ToString();
            }
        }

        #endregion

        #region 第三产业行绑定事件

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labTertiaryIndustry = (Label)e.Item.FindControl("labTertiaryIndustry");

                labTertiaryIndustry.Text = "<input id='" + drv["SettingKey"].ToString() + "' type='checkbox' name='checkbox' value='" + drv["SettingValue"].ToString() + "' onclick='selectOne(this)' />" + drv["SettingValue"].ToString();
            }
        }

        #endregion

        #region 第一产业行绑定事件

        protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labPrimaryIndustry = (Label)e.Item.FindControl("labPrimaryIndustry");

                labPrimaryIndustry.Text = "<input id='" + drv["SettingKey"].ToString() + "' type='checkbox' name='checkbox' value='" + drv["SettingValue"].ToString() + "' onclick='selectOne(this)' />" + drv["SettingValue"].ToString();
            }
        }

        #endregion
    }
}