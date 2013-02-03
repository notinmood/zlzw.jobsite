using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class SearchList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strSearchKey = Request.QueryString["id"];
                    Get_RecordCount(strSearchKey);
                }
                catch (Exception exp)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        #region 分页事件

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Load_SearchResultList(Request.QueryString["id"]);
        }

        #endregion

        #region 获取查询结果总页数

        private void Get_RecordCount(string strSearchKey)
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("CanUsable=1 and JobPositionKind like '%" + strSearchKey + "%'").Tables[0];
            AspNetPager1.RecordCount = dt.Rows.Count;
            if (dt.Rows.Count == 0)
            {
                labDataIsNull.Visible = true;
            }
            else if (dt.Rows.Count > 0)
            {
                labDataIsNull.Visible = false;
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        #endregion

        #region 获取查询结果列表

        private void Load_SearchResultList(string strSearchKey)
        {
            int nPageIndex = AspNetPager1.CurrentPageIndex;
            int nPageSize = AspNetPager1.PageSize = 2;
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList(nPageSize, nPageIndex, "*", "UpdateDate", 0, "desc", "CanUsable=1 and JobPositionKind like '%" + strSearchKey + "%'").Tables[0];

            if (dt.Rows.Count == 0)
            {
                labDataIsNull.Visible = true;
            }
            else if (dt.Rows.Count > 0)
            {
                labDataIsNull.Visible = false;
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        #endregion

        #region 行绑定事件

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labJobName = (Label)e.Item.FindControl("labJobName");
                Label labEnterpriseName = (Label)e.Item.FindControl("labEnterpriseName");
                Label labAddress = (Label)e.Item.FindControl("labAddress");
                Label labPublishDate = (Label)e.Item.FindControl("labPublishDate");

                labJobName.Text = drv["JobPositionName"].ToString();//企业发布的岗位名称
                labEnterpriseName.Text = drv["EnterpriseName"].ToString();//企业名称
                labAddress.Text = drv["JobWorkPlaceNames"].ToString();//工作地址
                labPublishDate.Text = DateTime.Parse(drv["CreateDate"].ToString()).ToString("yyyy年MM月dd");
            }
        }

        #endregion

        #region 查询按钮事件

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Load_SearchResultList(Request.QueryString["id"]);//查询
        }

        #endregion
    }
}