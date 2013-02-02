using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.TemplatePage
{
    public partial class JobPositionKinds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_JobPositionKindsList();
            }
        }

        #region 加载岗位类别列表

        private void Load_JobPositionKindsList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobCategories' and DisplayName='非管理'").Tables[0];

            DataList1.DataSource = dt;
            DataList1.DataBind();

            dt = generalBasicSettingBLL.GetList("SettingCategory='JobCategories' and DisplayName='管理'").Tables[0];
            DataList2.DataSource = dt;
            DataList2.DataBind();
        }

        #endregion

        #region 岗位类别行绑定事件(左侧)

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labJobPositionKinds = (Label)e.Item.FindControl("labJobPositionKinds");

                labJobPositionKinds.Text = "<input id='" + drv["SettingKey"].ToString() + "' type='checkbox' name='checkbox' value='" + drv["SettingValue"].ToString() + "' onclick='selectOne(this)' />" + drv["SettingValue"].ToString();
            }
        }

        #endregion

        #region 岗位类别行绑定事件(右侧)

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labJobPositionKinds01 = (Label)e.Item.FindControl("labJobPositionKinds01");

                labJobPositionKinds01.Text = "<input id='" + drv["SettingKey"].ToString() + "' type='checkbox' name='checkbox' value='" + drv["SettingValue"].ToString() + "' onclick='selectOne(this)' />" + drv["SettingValue"].ToString();
            }
        }

        #endregion
        
    }
}