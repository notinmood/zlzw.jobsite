using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class JobSearchList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DefaultSearchWhere"] != null)
            {
                Get_RecordCount();
                Load_SearchResultList();
            }
        }

        #region 分页事件

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Get_RecordCount();
            Load_SearchResultList();
        }

        #endregion

        #region 获取查询结果总页数

        private void Get_RecordCount()
        {
            string strGangWei = Request.Params["txbJobPositionKinds"];//岗位类别
            string strHangYe = Request.Params["txbJobFeildKinds"];//行业类别
            string strWorkAreas = Request.Params["txbWorkAreas"];//工作地区
            string strSearchKey = Request.Params["txbSearchKey"];//关键字
            string strSex = drpSex.SelectedValue;//性别
            string strShiSu = drpShiSu.SelectedValue;//食宿
            if (Session["DefaultSearchWhere"] != null)
            {
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList(Session["DefaultSearchWhere"].ToString()).Tables[0];
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
            else
            {
                System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
                strBuilder.Append("CanUsable=1");
                if (strGangWei != "")
                {
                    strBuilder.Append(" and JobPositionKind like '%" + strGangWei + "%'");
                }
                if (strHangYe != "")
                {
                    strBuilder.Append(" and JobFeildKinds like '%" + strHangYe + "%'");
                }
                if (strWorkAreas != "")
                {
                    strBuilder.Append(" and JobWorkPlaceNames like '%" + strWorkAreas + "%'");
                }
                if (strSex != "-1")
                {
                    strBuilder.Append(" and NeedSex like '%" + strSex + "%'");
                }
                if (strSearchKey != "")
                {
                    strBuilder.Append(" or (JobPositionDesc like '%" + strSearchKey + "%' or EnterpriseName like '%" + strSearchKey + "%' or JobPositionName like '%" + strSearchKey + "%')");
                }

                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                //System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("CanUsable=1 and JobPositionKind like '%" + strGangWei + "%' and JobFeildKinds like '%" + strHangYe + "%' and JobWorkPlaceNames like '%" + strWorkAreas + "%' and NeedSex like '%" + strSex + "%' or (JobPositionDesc like '%" + strSearchKey + "%' or EnterpriseName like '%" + strSearchKey + "%' or JobPositionName like '%" + strSearchKey + "%')").Tables[0];
                System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList(strBuilder.ToString()).Tables[0];
                AspNetPager1.RecordCount = dt.Rows.Count;
            }
        }

        #endregion

        #region 获取查询结果列表

        private void Load_SearchResultList()
        {
            string strGangWei = Request.Params["txbJobPositionKinds"];//岗位类别
            string strHangYe = Request.Params["txbJobFeildKinds"];//行业类别
            string strWorkAreas = Request.Params["txbWorkAreas"];//工作地区
            string strSearchKey = Request.Params["txbSearchKey"];//关键字
            string strSex = drpSex.SelectedValue;//性别
            string strShiSu = drpShiSu.SelectedValue;//食宿
            int nPageIndex = AspNetPager1.CurrentPageIndex;
            int nPageSize = AspNetPager1.PageSize = 15;
            if (Session["DefaultSearchWhere"] != null)
            {
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList(nPageSize, nPageIndex, "*", "UpdateDate", 0, "desc", Session["DefaultSearchWhere"].ToString()).Tables[0];

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
            else
            {
                System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
                strBuilder.Append("CanUsable=1");
                if (strGangWei != "")
                {
                    strBuilder.Append(" and JobPositionKind like '%" + strGangWei + "%'");
                }
                if (strHangYe != "")
                {
                    strBuilder.Append(" and JobFeildKinds like '%" + strHangYe + "%'");
                }
                if (strWorkAreas != "")
                {
                    strBuilder.Append(" and JobWorkPlaceNames like '%" + strWorkAreas + "%'");
                }
                if (strSex != "-1")
                {
                    strBuilder.Append(" and NeedSex like '%" + strSex + "%'");
                }

                if (strSearchKey != "")
                {
                    strBuilder.Append(" or (JobPositionDesc like '%" + strSearchKey + "%' or EnterpriseName like '%" + strSearchKey + "%' or JobPositionName like '%" + strSearchKey + "%')");
                }

                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                //System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList(nPageSize, nPageIndex, "*", "UpdateDate", 0, "desc", "CanUsable=1 and JobPositionKind like '%" + strGangWei + "%' and JobFeildKinds like '%" + strHangYe + "%' and JobWorkPlaceNames like '%" + strWorkAreas + "%' and NeedSex like '%" + strSex + "%' or (JobPositionDesc like '%" + strSearchKey + "%' or EnterpriseName like '%" + strSearchKey + "%' or JobPositionName like '%" + strSearchKey + "%')").Tables[0];
                System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList(nPageSize, nPageIndex, "*", "UpdateDate", 0, "desc", strBuilder.ToString()).Tables[0];

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
            Get_RecordCount();//总数
            Load_SearchResultList();//查询
        }

        #endregion
    }
}