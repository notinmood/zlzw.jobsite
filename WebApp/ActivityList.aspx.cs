using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ActivityList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_ActivityList();//加载招聘会列表
            }
            AspNetPager1.RecordCount = Get_ActivityListRecordCount();//获取招聘会总页数
        }

        private int Get_ActivityListRecordCount()
        {
            zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
            DataTable dt = generalActivityBLL.GetList("CanUsable=1").Tables[0];

            return dt.Rows.Count;
        }

        #region 加载招聘会列表

        private void Load_ActivityList()
        {
            int nPageIndex = AspNetPager1.CurrentPageIndex;
            int nPageSize = AspNetPager1.PageSize = 15;
            zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
            DataTable dt = generalActivityBLL.GetList(nPageSize, nPageIndex, "*", "PublishDate", 0, "desc", "CanUsable=1").Tables[0];

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        #endregion

        #region 分页事件

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Load_ActivityList();
        }

        #endregion

        #region 招聘会行绑定事件
        
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labActivityTitle = (Label)e.Item.FindControl("labActivityTitle");

                labActivityTitle.Text = "<span style='color:#FA7A00;'> ★ </span><a href='ActivityInfo.aspx?id=" + drv["ActivityGuid"].ToString() + "' style='color:#6e6e6e;text-decoration:none;'>" + drv["ActivityTitle"].ToString() + "</a><div style='float:right; padding-right:20px;-margin-top:-25px;*margin-top:-28px;'>" + Set_DateFormat(drv["PublishDate"].ToString()) + "</div>";
            }
        }

        #endregion

        #region 日期格式转换

        private string Set_DateFormat(string strDate)
        {
            DateTime dateTime = DateTime.Parse(strDate);
            return dateTime.ToString("yyyy年MM月dd日");
        }

        #endregion
    }
}