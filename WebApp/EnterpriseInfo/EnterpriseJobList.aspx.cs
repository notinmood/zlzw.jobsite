using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.EnterpriseInfo
{
    public partial class EnterpriseJobList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strEnterpriseID = Request.QueryString["id"];
                    Get_EnterpriseJobList(strEnterpriseID);//加载企业信息
                }
                catch (Exception exp)
                {
                    //Response.Redirect("../default.aspx");
                }
            }
        }

        #region 加载企业职位列表

        private void Get_EnterpriseJobList(string strEnterpriseID)
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("EnterpriseKey='"+ Request.QueryString["id"] +"' and CanUsable=1 order by CreateDate desc").Tables[0];
            labBanner.Text = dt.Rows[0]["EnterpriseName"].ToString();
            labEnterpriseContent.Text = Get_EnterpriseDesc(strEnterpriseID);
            txbTitle.Text = dt.Rows[0]["EnterpriseName"].ToString() + "-" + dt.Rows[0]["JobPositionName"].ToString();
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        #endregion

        #region 获取企业简介

        private string Get_EnterpriseDesc(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strEnterpriseGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["EnterpriseDescription"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion

        #region 职位列表行绑定事件加载

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labJobTitle = (Label)e.Item.FindControl("labJobTitle");

                //labJobTitle.Text = "<a class='jobList' href='#' onclick=\"javascript:art.dialog.open('JobList.html?id=" + drv["PartnersJobID"].ToString() + "', {width: 577, height: 371})\"; style='text-decoration:none;'>" + drv["PostInfo"].ToString() + "</a>";
                labJobTitle.Text = "<a href='EnterpriseInfo.aspx?type=" + drv["EnterpriseKey"].ToString() + "&id=" + drv["JobPositionGuid"].ToString() + "' style='color:#093C7E;text-decoration:none;'>" + drv["JobPositionName"].ToString() + "</a>";
            }
        }

        #endregion
    }
}