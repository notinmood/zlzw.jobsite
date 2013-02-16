using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class CareerGuidanceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_CareerGuidanceList();//加载就业指导列表
            }
            AspNetPager1.RecordCount = Get_CareerGuidanceListRecordCount();//获取就业指导总页数
        }

        private int Get_CareerGuidanceListRecordCount()
        {
            zlzw.BLL.CareerGuidanceListBLL careerGuidanceListBLL = new zlzw.BLL.CareerGuidanceListBLL();
            System.Data.DataTable dt = careerGuidanceListBLL.GetList("IsEnable=1").Tables[0];

            return dt.Rows.Count;
        }

        #region 加载就业指导列表

        private void Load_CareerGuidanceList()
        {
            int nPageIndex = AspNetPager1.CurrentPageIndex;
            int nPageSize = AspNetPager1.PageSize = 15;
            zlzw.BLL.CareerGuidanceListBLL careerGuidanceListBLL = new zlzw.BLL.CareerGuidanceListBLL();
            System.Data.DataTable dt = careerGuidanceListBLL.GetList(nPageSize, nPageIndex, "*", "PublishDate", 0, "desc", "IsEnable=1").Tables[0];

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        #endregion

        #region 分页事件

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Load_CareerGuidanceList();
        }

        #endregion

        #region 招聘会行绑定事件

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label CareerGuidanceTitle = (Label)e.Item.FindControl("CareerGuidanceTitle");

                CareerGuidanceTitle.Text = "<span style='color:#FA7A00;'> ★ </span><a target='_blank' href='CareerGuidanceInfo.aspx?id=" + drv["CareerGuidanceGUID"].ToString() + "' style='color:#6e6e6e;text-decoration:none;'>" + drv["CareerGuidanceTitle"].ToString() + "</a><div style='float:right; padding-right:20px;'>" + Set_DateFormat(drv["PublishDate"].ToString()) + "</div>";
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