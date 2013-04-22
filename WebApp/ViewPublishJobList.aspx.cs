using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ViewPublishJobList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["CurrentUserGUID"] == null)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    try
                    {
                        string strEnterpriseGUID = Request.QueryString["id"];
                        ViewState["EnterpriseGUID"] = strEnterpriseGUID;
                        AspNetPager1.RecordCount = Load_RecordCount(strEnterpriseGUID);//获取总页数
                        Load_DataList(strEnterpriseGUID);//获取数据列表
                    }
                    catch (Exception exp)
                    {
                        Response.Redirect("default.aspx");
                    }
                }

            }
        }
        
        #region 获取总页数

        private int Load_RecordCount(string strEnterpriseGUID)
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("EnterpriseKey='" + strEnterpriseGUID + "' and CanUsable=1").Tables[0];


            if (dt.Rows.Count == 0)
            {
                labDataIsNull.Visible = true;
            }
            else
            {
                labDataIsNull.Visible = false;
            }

            return dt.Rows.Count;
        }

        #endregion

        #region 数据绑定

        private void Load_DataList(string strEnterpriseGUID)
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            int nPageIndex = AspNetPager1.CurrentPageIndex;
            int nPageSize = AspNetPager1.PageSize = 15;
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList(nPageSize, nPageIndex, "*", "CreateDate", 0, "desc", "EnterpriseKey='" + strEnterpriseGUID + "' and CanUsable=1").Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        #endregion

        #region 行绑定事件

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labEnterpriseName = (Label)e.Item.FindControl("labEnterpriseName");//所属企业
                Label labJobName = (Label)e.Item.FindControl("labJobName");//职位名称
                Label labJobType = (Label)e.Item.FindControl("labJobType");//职位类型
                Label labLinkTel = (Label)e.Item.FindControl("labLinkTel");//联系电话
                Label labPublishDate = (Label)e.Item.FindControl("labPublishDate");//发布日期
                Label labDel = (Label)e.Item.FindControl("labDel");
                LinkButton libkBtnDel = (LinkButton)e.Item.FindControl("libkBtnDel");//
                labEnterpriseName.Text = drv["EnterpriseName"].ToString();//企业名称
                labJobName.Text = drv["JobPositionName"].ToString();//职位名称
                labJobType.Text = drv["JobPositionKind"].ToString();//职位类型
                if (drv["ContactTelephone"].ToString() == "")
                {
                    labLinkTel.Text = "无";//联系电话
                }
                else
                {
                    labLinkTel.Text = drv["ContactTelephone"].ToString();//联系电话
                }

                labPublishDate.Text = Get_DateTime(drv["CreateDate"].ToString());//发布日期
                labDel.Text = "<a class='linkResumeID' target='_blank' href='ViewPublishJobInfo.aspx?id=" + drv["JobPositionID"].ToString() + "' style='font-size:14px;font-weight:bold;color:#F97D00; text-decoration:none;'>查看</a>";
                libkBtnDel.CommandName = drv["JobPositionID"].ToString();//职位ID
            }
        }

        #endregion

        #region 日期格式转换

        private string Get_DateTime(string strDate)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(strDate);

                return dateTime.ToString("yyyy-MM-dd");
            }
            catch (Exception exp)
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        #endregion

        #region 删除按钮事件

        protected void libkBtnDel_Click(object sender, EventArgs e)
        {
            LinkButton linkBtnDel = sender as LinkButton;
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = jobEnterpriseJobPositionBLL.GetModel(int.Parse(linkBtnDel.CommandName));
            jobEnterpriseJobPositionModel.CanUsable = 0;
            jobEnterpriseJobPositionBLL.Update(jobEnterpriseJobPositionModel);
            if (ViewState["EnterpriseGUID"] != null)
            {
                Load_DataList(ViewState["EnterpriseGUID"].ToString());
            }
            else
            {
                Load_DataList(Request.QueryString["id"]);
            }

        }

        #endregion

        #region 分页事件

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (ViewState["EnterpriseGUID"] != null)
            {
                Load_DataList(ViewState["EnterpriseGUID"].ToString());
            }
            else
            {
                Load_DataList(Request.QueryString["id"]);
            }
        }

        #endregion
    }
}