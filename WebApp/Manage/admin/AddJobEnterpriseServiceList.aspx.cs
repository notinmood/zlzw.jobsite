using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Manage.admin
{
    public partial class AddJobEnterpriseServiceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                Load_EnterpriseList();
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 加载企业名称列表

        private void Load_EnterpriseList()
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("CanUsable=1 order by CreateDate desc ").Tables[0];

            drpEnterpriseKey.DataTextField = "CompanyName";
            drpEnterpriseKey.DataValueField = "EnterpriseGuid";

            drpEnterpriseKey.DataSource = dt;
            drpEnterpriseKey.DataBind();
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.JobEnterpriseServiceBLL jobEnterpriseServiceBLL = new zlzw.BLL.JobEnterpriseServiceBLL();
                zlzw.Model.JobEnterpriseServiceModel jobEnterpriseServiceModel = jobEnterpriseServiceBLL.GetModel(int.Parse(Get_ID(jobEnterpriseServiceBLL, strID)));
                drpEnterpriseKey.SelectedValue = jobEnterpriseServiceModel.EnterpriseKey;//所属企业GUID
                txbJobPositionPublishAllowCount.Text = jobEnterpriseServiceModel.JobPositionPublishAllowCount.ToString();//允许企业发布的职位个数
                txbJobPositionPublishUsedCount.Text = jobEnterpriseServiceModel.JobPositionPublishUsedCount.ToString();//企业已经发布的职位个数
                txbEnterpriseServiceCurrentContractStartDate.SelectedDate = jobEnterpriseServiceModel.EnterpriseServiceCurrentContractStartDate;//允许企业发布职位的开始日期
                txbEnterpriseServiceCurrentContractEndDate.SelectedDate = jobEnterpriseServiceModel.EnterpriseServiceCurrentContractEndDate;//禁止企业发布职位的开始日期
                txbResumeDownAllowCount.Text = jobEnterpriseServiceModel.ResumeDownAllowCount.ToString();//允许查看简历数
                txbResumeDownUsedCount.Text = jobEnterpriseServiceModel.ResumeDownUsedCount.ToString();//已查看简历数
                

                ViewState["PublishDate"] = jobEnterpriseServiceModel.PublishDate.ToString();
                ViewState["EnterpriseServiceGuid"] = jobEnterpriseServiceModel.EnterpriseServiceGuid.ToString();
                ToolbarText2.Text = "编辑一个招聘业务基本信息";
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
                zlzw.Model.JobEnterpriseServiceModel jobEnterpriseServiceModel = new zlzw.Model.JobEnterpriseServiceModel();
                jobEnterpriseServiceModel.EnterpriseKey = drpEnterpriseKey.SelectedValue;//所属企业GUID
                jobEnterpriseServiceModel.EnterpriseName = Get_EnterpriseName(drpEnterpriseKey.SelectedValue);
                jobEnterpriseServiceModel.JobPositionPublishAllowCount = int.Parse(txbJobPositionPublishAllowCount.Text);//允许企业发布的职位个数
                jobEnterpriseServiceModel.JobPositionPublishUsedCount = int.Parse(txbJobPositionPublishUsedCount.Text);//企业已经发布的职位个数
                jobEnterpriseServiceModel.EnterpriseServiceCurrentContractStartDate = DateTime.Parse(txbEnterpriseServiceCurrentContractStartDate.Text);//允许企业发布职位的开始日期
                jobEnterpriseServiceModel.EnterpriseServiceCurrentContractEndDate = DateTime.Parse(txbEnterpriseServiceCurrentContractEndDate.Text);//禁止企业发布职位的开始日期
                jobEnterpriseServiceModel.ResumeDownAllowCount = int.Parse(txbResumeDownAllowCount.Text);//允许查看简历数
                jobEnterpriseServiceModel.ResumeDownUsedCount = int.Parse(txbResumeDownUsedCount.Text);//已查看简历数
                jobEnterpriseServiceModel.CanUsable = 1;
                jobEnterpriseServiceModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                jobEnterpriseServiceModel.EnterpriseServiceGuid = new Guid(ViewState["EnterpriseServiceGuid"].ToString());
                zlzw.BLL.JobEnterpriseServiceBLL jobEnterpriseServiceBLL = new zlzw.BLL.JobEnterpriseServiceBLL();
                jobEnterpriseServiceModel.EnterpriseServiceID = int.Parse(Get_ID(jobEnterpriseServiceBLL, Request.QueryString["value"]));

                jobEnterpriseServiceBLL.Update(jobEnterpriseServiceModel);
            }
            else
            {
                //添加保存

                zlzw.Model.JobEnterpriseServiceModel jobEnterpriseServiceModel = new zlzw.Model.JobEnterpriseServiceModel();
                jobEnterpriseServiceModel.EnterpriseKey = drpEnterpriseKey.SelectedValue;//所属企业GUID
                jobEnterpriseServiceModel.EnterpriseName = Get_EnterpriseName(drpEnterpriseKey.SelectedValue);
                jobEnterpriseServiceModel.JobPositionPublishAllowCount = int.Parse(txbJobPositionPublishAllowCount.Text);//允许企业发布的职位个数
                jobEnterpriseServiceModel.JobPositionPublishUsedCount = int.Parse(txbJobPositionPublishUsedCount.Text);//企业已经发布的职位个数
                jobEnterpriseServiceModel.EnterpriseServiceCurrentContractStartDate = DateTime.Parse(txbEnterpriseServiceCurrentContractStartDate.Text);//允许企业发布职位的开始日期
                jobEnterpriseServiceModel.EnterpriseServiceCurrentContractEndDate = DateTime.Parse(txbEnterpriseServiceCurrentContractEndDate.Text);//禁止企业发布职位的开始日期
                jobEnterpriseServiceModel.ResumeDownAllowCount = int.Parse(txbResumeDownAllowCount.Text);//允许查看简历数
                jobEnterpriseServiceModel.ResumeDownUsedCount = int.Parse(txbResumeDownUsedCount.Text);//已查看简历数
                jobEnterpriseServiceModel.CanUsable = 1;
                jobEnterpriseServiceModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.JobEnterpriseServiceBLL jobEnterpriseServiceBLL = new zlzw.BLL.JobEnterpriseServiceBLL();
                jobEnterpriseServiceBLL.Add(jobEnterpriseServiceModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.JobEnterpriseServiceBLL jobEnterpriseServiceBLL, string strGUID)
        {
            System.Data.DataTable dt = jobEnterpriseServiceBLL.GetList("EnterpriseServiceGuid='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["EnterpriseServiceID"].ToString();
        }

        #endregion

        #region 根据企业GUID获取企业名称

        private string Get_EnterpriseName(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strEnterpriseGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["CompanyName"].ToString();
            }
            else
            {
                return "未知企业";
            }
        }

        #endregion
    }
}