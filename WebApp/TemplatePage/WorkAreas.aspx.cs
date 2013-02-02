using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.TemplatePage
{
    public partial class WorkAreas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_WorkAreasList();//加载工作区域列表
            }
        }

        #region 加载工作区域列表

        private void Load_WorkAreasList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='WorkAreas' and CanUsable=1 order by OrderNumber asc").Tables[0];

            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        #endregion

        #region 工作区域行绑定事件

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
    }
}