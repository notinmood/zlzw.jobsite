using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ViewPublishJobInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    labReceive.InnerText = Get_ReceiveCount(Request.Cookies["CurrentUserGUID"].Value) + " ";
                    
                    labJobPublish.InnerText = " " + Get_EnterpriseJobPublishCount(Request.Cookies["CurrentUserGUID"].Value) + " ";//发布职位数量
                    labDownloadCount.InnerText = " " + Get_DownLoadCount(Request.Cookies["CurrentUserGUID"].Value) + " ";
                    labAlreadyDownload.InnerText = " " + Get_AlreadyDownLoadCount(Request.Cookies["CurrentUserGUID"].Value) + " ";//已下载的简历数
                    Load_JobInfo();
                }
                catch (Exception exp)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        #region 获取收到的简历数量

        private string Get_ReceiveCount(string strEnterpriseGUID)
        {
            zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();
            DataTable dt = resumeCollectionListBLL.GetList("ResumeCollectionType=1 and EnterpriseGuid='" + strEnterpriseGUID + "' and EnterpriseIsDel=1 and IsEnable=1 order by PublishDate desc").Tables[0];

            return dt.Rows.Count.ToString();
        }

        #endregion

        #region 企业发布职位数量

        private string Get_EnterpriseJobPublishCount(string strEnterpriseGUID)
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("EnterpriseKey='" + strEnterpriseGUID + "' and JobPositionStatus=1 and CanUsable=1").Tables[0];

            return dt.Rows.Count.ToString();
        }

        #endregion

        #region 获取当前企业已下载简历数量

        private string Get_AlreadyDownLoadCount(string strEnterpriseGUID)
        {
            zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();
            DataTable dt = resumeCollectionListBLL.GetList("ResumeCollectionType=0 and EnterpriseGuid='" + strEnterpriseGUID + "' and EnterpriseIsDel=1 and IsEnable=1 order by PublishDate desc").Tables[0];


            return dt.Rows.Count.ToString();
        }

        #endregion

        #region 获取当前企业剩余下载简历数

        private string Get_DownLoadCount(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strEnterpriseGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["DownloadResume"].ToString();
            }
            else
            {
                return "0";
            }
        }

        #endregion

        #region 加载职位类别

        private void Load_JobPositionKindsTypeList()
        {
            //zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            //DataTable dt = generalBasicSettingBLL.GetList("DisplayName='" + drpJobPositionKindsType.SelectedValue + "'").Tables[0];

            //drpJobPositionKinds.DataTextField = "SettingValue";
            //drpJobPositionKinds.DataValueField = "SettingValue";

            //drpJobPositionKinds.DataSource = dt;
            //drpJobPositionKinds.DataBind();
        }

        #endregion

        #region 加载职位信息

        private void Load_JobInfo()
        {
            try
            {
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = jobEnterpriseJobPositionBLL.GetModel(int.Parse(Request.QueryString["id"]));
                txbJobPositionName.Text = jobEnterpriseJobPositionModel.JobPositionName;//岗位名称
                txbJobPositionKinds.Text = jobEnterpriseJobPositionModel.JobPositionKind;//岗位类别
                txbJobWorkPlaceNames.Text = jobEnterpriseJobPositionModel.JobWorkPlaceNames;//工作地点
                txbComprehensivePayroll.Text = jobEnterpriseJobPositionModel.ComprehensivePayroll;//综合薪资
                if (jobEnterpriseJobPositionModel.HopeRoomAndBoard.ToString() == "1")
                {
                    drpHopeRoomAndBoard.Text = "是";
                }
                else
                {
                    drpHopeRoomAndBoard.Text = "否";
                }
                if (jobEnterpriseJobPositionModel.NeedSex.ToString() == "1")
                {
                    txbNeedAge.Text = "男";
                }
                else if (jobEnterpriseJobPositionModel.NeedSex.ToString() == "0")
                {
                    txbNeedAge.Text = "女";
                }
                else
                {
                    txbNeedAge.Text = "不限";
                }
                drpUserEducationalBackground.Text = Get_EducationName(jobEnterpriseJobPositionModel.NeedEducation.ToString());//学历要求
                txbContactTelephone.Text = jobEnterpriseJobPositionModel.ContactTelephone;//联系人电话
                txbContactPerson.Text = jobEnterpriseJobPositionModel.ContactPerson;//联系人
                txbContactMail.Text = jobEnterpriseJobPositionModel.ContactMail;//联系人邮箱
                txbJobPositionDesc.Text = jobEnterpriseJobPositionModel.JobPositionDesc;//职位描述
                txbInterviewTime.Text = jobEnterpriseJobPositionModel.InterviewTime;//面试时间
                txbInterviewAddress.Text = jobEnterpriseJobPositionModel.InterviewAddress;//面试地点
                drpJobWorkType.Text = Get_JobWorkTypename(jobEnterpriseJobPositionModel.JobWorkType.ToString());//工作性质
                labView02.Text = "<a style='font-size:14px;color:#fff;font-weight:bold;text-decoration:none;' target='_blank' href='AlreadyDownLoadResumeList.aspx?id=" + jobEnterpriseJobPositionModel.EnterpriseKey + "&type=1'>查看简历</a>";
                labView01.Text = " " + "<a style='font-size:14px;color:#fff;font-weight:bold;text-decoration:none;' target='_blank' href='AlreadyDownLoadResumeList.aspx?id=" + jobEnterpriseJobPositionModel.EnterpriseKey + "&type=0'>查看简历</a>";
                labView03.Text = " " + "<a style='font-size:14px;color:#fff;font-weight:bold;text-decoration:none;' target='_blank' href='ViewPublishJobList.aspx?id=" + jobEnterpriseJobPositionModel.EnterpriseKey + "&type=1'>查看职位</a>";
            }
            catch (Exception exp)
            {
                Response.Redirect("default.aspx");
            }
        }

        #endregion

        #region 职位删除按钮事件

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = jobEnterpriseJobPositionBLL.GetModel(int.Parse(Request.QueryString["id"]));
                if (jobEnterpriseJobPositionModel != null)
                {
                    jobEnterpriseJobPositionModel.CanUsable = 0;
                    jobEnterpriseJobPositionBLL.Update(jobEnterpriseJobPositionModel);
                    Response.Redirect("ViewPublishJobList.aspx?id=" + jobEnterpriseJobPositionModel.EnterpriseKey + "&type=1");
                }
            }
            catch (Exception exp)
            {
                //Response.Redirect("default.aspx");
            }
        }

        #endregion

        #region 获取工作性质名称

        private string Get_JobWorkTypename(string strJobWorkTypeID)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobWorkType' and CanUsable=1 and SettingKey='" + strJobWorkTypeID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SettingValue"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion

        #region 获取学历名称

        private string Get_EducationName(string strEducationID)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='NeedEducation' and CanUsable=1 and SettingKey='"+ strEducationID +"'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SettingValue"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion
    }
}