using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddEmergencyRecruitment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = jobEnterpriseJobPositionBLL.GetModel(int.Parse(Get_ID(jobEnterpriseJobPositionBLL, strID)));
                labEnterpriseName.Text = jobEnterpriseJobPositionModel.EnterpriseName;//企业名称
                labJobPositionName.Text = jobEnterpriseJobPositionModel.JobPositionName;//职位名称
                labJobPositionDesc.Text = jobEnterpriseJobPositionModel.JobPositionDesc;//职位介绍
                dateStartTime.Text = jobEnterpriseJobPositionModel.DisplayStartDate.ToString();//开始日期
                dateEndTime.Text = jobEnterpriseJobPositionModel.DisplayEndDate.ToString();//结束日期
                if (jobEnterpriseJobPositionModel.IsEnableEmergencyRecruitment == 1)
                {
                    ckbIsEnableEmergencyRecruitment.Checked = true;
                }
                else
                {
                    ckbIsEnableEmergencyRecruitment.Checked = false;
                }
                ViewState["CreateDate"] = jobEnterpriseJobPositionModel.CreateDate.ToString();
                ViewState["JobPositionGuid"] = jobEnterpriseJobPositionModel.JobPositionGuid.ToString();
                ToolbarText2.Text = "编辑一个紧急招聘";
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
        }

        #endregion

        #region 保存按钮事件

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Type"] == "1")
            {
                //编辑保存
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = jobEnterpriseJobPositionBLL.GetModel(int.Parse(Get_ID(jobEnterpriseJobPositionBLL, Request.QueryString["value"])));
                if (ckbIsEnableEmergencyRecruitment.Checked)
                {
                    jobEnterpriseJobPositionModel.IsEnableEmergencyRecruitment = 1;
                }
                else
                {
                    jobEnterpriseJobPositionModel.IsEnableEmergencyRecruitment = 0;
                }
                jobEnterpriseJobPositionModel.DisplayStartDate = DateTime.Parse(dateStartTime.Text);//开始日期
                jobEnterpriseJobPositionModel.DisplayEndDate = DateTime.Parse(dateEndTime.Text);//结束日期
                jobEnterpriseJobPositionBLL.Update(jobEnterpriseJobPositionModel);
            }
            else
            {
                ////添加保存
                //zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                //zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = jobEnterpriseJobPositionBLL.GetModel(int.Parse(Get_ID(jobEnterpriseJobPositionBLL, Request.QueryString["value"])));
                //if (ckbIsEnableEmergencyRecruitment.Checked)
                //{
                //    jobEnterpriseJobPositionModel.IsEnableEmergencyRecruitment = 1;
                //}
                //else
                //{
                //    jobEnterpriseJobPositionModel.IsEnableEmergencyRecruitment = 0;
                //}
                //jobEnterpriseJobPositionBLL.Add(jobEnterpriseJobPositionModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL, string strGUID)
        {
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("JobPositionGuid='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["JobPositionID"].ToString();
        }

        #endregion
    }
}