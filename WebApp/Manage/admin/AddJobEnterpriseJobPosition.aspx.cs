using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;

namespace WebApp.Manage.admin
{
    public partial class AddJobEnterpriseJobPosition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                
                #region 下拉列表绑定

                Load_JobPositionStatusList();
                Load_EnterpriseKeyList();
                Load_SpecialTypeList();
                Load_JobFeildKinds();
                Load_JobWorkTypeList();
                Load_JobSalaryList();
                Load_NeedEducation();
                Load_NeedWorkExperience();
                labCreateUserName.Text = Get_UserName();
                Load_JobPositionStatusList();
                #endregion
                
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 下拉列表绑定

        /// <summary>
        /// 简历状态
        /// </summary>
        private void Load_JobPositionStatusList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobPositionStatus'").Tables[0];

            drpJobPositionStatus.DataTextField = "SettingValue";
            drpJobPositionStatus.DataValueField = "SettingKey";

            drpJobPositionStatus.DataSource = dt;
            drpJobPositionStatus.DataBind();
        }

        /// <summary>
        /// 绑定企业列表
        /// </summary>
        private void Load_EnterpriseKeyList()
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("CanUsable=1").Tables[0];

            drpEnterpriseKey.DataTextField = "CompanyName";
            drpEnterpriseKey.DataValueField = "EnterpriseGuid";

            drpEnterpriseKey.DataSource = dt;
            drpEnterpriseKey.DataBind();
        }

        /// <summary>
        /// 是否在首页显示
        /// </summary>
        private void Load_SpecialTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobSpecialType'").Tables[0];

            drpSpecialType.DataTextField = "SettingValue";
            drpSpecialType.DataValueField = "SettingKey";

            drpSpecialType.DataSource = dt;
            drpSpecialType.DataBind();
        }

        /// <summary>
        /// 绑定行业类别（大类）
        /// </summary>
        private void Load_JobFeildKinds()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='IndustrySector'").Tables[0];
            System.Collections.ArrayList arrList = new System.Collections.ArrayList();
            string strTemp="";
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                strTemp = dt.Rows[nCount]["DisPlayName"].ToString();
                if (!arrList.Contains(strTemp))
                {
                    arrList.Add(strTemp);
                }
            }

            drpJobFeildKinds.DataTextField = "DisPlayName";
            drpJobFeildKinds.DataValueField = "SettingID";

            drpJobFeildKinds.DataSource = arrList;
            drpJobFeildKinds.DataBind();

            Load_JobFeildKinds01(drpJobFeildKinds.SelectedValue);
        }
        //根据大类别绑定小类别
        private void Load_JobFeildKinds01(string strDisPlayName)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisPlayName='" + strDisPlayName + "'").Tables[0];
            drpJobFeildKinds01.DataTextField = "SettingValue";
            drpJobFeildKinds01.DataValueField = "SettingKey";
            drpJobFeildKinds01.DataSource = dt;
            drpJobFeildKinds01.DataBind();

        }

        /// <summary>
        /// 绑定工作性质
        /// </summary>
        private void Load_JobWorkTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobWorkType'").Tables[0];

            drpJobWorkType.DataTextField = "SettingValue";
            drpJobWorkType.DataValueField = "SettingKey";

            drpJobWorkType.DataSource = dt;
            drpJobWorkType.DataBind();
        }

        /// <summary>
        /// 绑定月薪列表
        /// </summary>
        private void Load_JobSalaryList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobSalary' order by OrderNumber asc").Tables[0];

            drpJobSalary.DataTextField = "SettingValue";
            drpJobSalary.DataValueField = "SettingKey";

            drpJobSalary.DataSource = dt;
            drpJobSalary.DataBind();
        }

        /// <summary>
        /// 绑定最低学历
        /// </summary>
        private void Load_NeedEducation()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='NeedEducation' order by OrderNumber asc").Tables[0];

            drpNeedEducation.DataTextField = "SettingValue";
            drpNeedEducation.DataValueField = "SettingKey";

            drpNeedEducation.DataSource = dt;
            drpNeedEducation.DataBind();
        }

        /// <summary>
        /// 绑定工作经验
        /// </summary>
        private void Load_NeedWorkExperience()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='NeedWorkExperience' order by OrderNumber asc").Tables[0];

            drpNeedWorkExperience.DataTextField = "SettingValue";
            drpNeedWorkExperience.DataValueField = "SettingKey";

            drpNeedWorkExperience.DataSource = dt;
            drpNeedWorkExperience.DataBind();
        }

        #endregion

        #region 行业类别选择事件

        protected void drpJobFeildKinds_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpJobFeildKinds01.Items.Clear();
            Load_JobFeildKinds01(drpJobFeildKinds.SelectedValue);
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = jobEnterpriseJobPositionBLL.GetModel(int.Parse(Get_ID(jobEnterpriseJobPositionBLL, strID)));
                string[] strJobFeildKindsList = jobEnterpriseJobPositionModel.JobFeildKinds.Split('|');
                drpEnterpriseKey.SelectedValue = jobEnterpriseJobPositionModel.EnterpriseKey;//所属企业
                txbDepartmentName.Text = jobEnterpriseJobPositionModel.DepartmentName;//所要招聘的部门
                drpJobFeildKinds.SelectedValue = strJobFeildKindsList[0];//行业分类
                drpJobFeildKinds01.SelectedValue = strJobFeildKindsList[1];//所属行业
                drpJobPositionStatus.SelectedValue = jobEnterpriseJobPositionModel.JobPositionStatus.ToString();//简历状态
                drpEnterpriseKey.SelectedValue = jobEnterpriseJobPositionModel.EnterpriseKey;//所属企业
                txbJobPositionName.Text = jobEnterpriseJobPositionModel.JobPositionName;//岗位名称
                txbJobPositionKind.Text = jobEnterpriseJobPositionModel.JobPositionKind;//岗位名称（中文）
                drpJobWorkType.Text = jobEnterpriseJobPositionModel.JobWorkType.ToString();//工作性质
                txbJobWorkPlaceNames.Text = jobEnterpriseJobPositionModel.JobWorkPlaceNames;//工作地点
                txbJobPositionKinds.Text = jobEnterpriseJobPositionModel.JobPositionKinds;//从事职业类别
                drpJobSalary.SelectedValue = jobEnterpriseJobPositionModel.JobSalary.ToString();//月薪
                txbNeedPersonCount.Text = jobEnterpriseJobPositionModel.NeedPersonCount.ToString();//招聘人数
                drpNeedEducation.SelectedValue = jobEnterpriseJobPositionModel.NeedEducation.ToString();//学历要求
                txbNeedAge.Text = jobEnterpriseJobPositionModel.NeedAge;//年龄要求
                drpNeedSex.SelectedValue = jobEnterpriseJobPositionModel.NeedSex.ToString();//性别要求
                drpNeedWorkExperience.SelectedValue = jobEnterpriseJobPositionModel.NeedWorkExperience.ToString();//工作经验
                drpNeedMangeExperience.SelectedValue = jobEnterpriseJobPositionModel.NeedMangeExperience.ToString();//是否需要管理经验
                txbJobPositionDesc.Text = jobEnterpriseJobPositionModel.JobPositionDesc;//职位描述
                txbContactPerson.Text = jobEnterpriseJobPositionModel.ContactPerson;//联系人
                txbContactTelephone.Text = jobEnterpriseJobPositionModel.ContactTelephone;//联系人电话
                txbContactMail.Text = jobEnterpriseJobPositionModel.ContactMail;//联系人邮件
                txbJobPositionStartDate.SelectedDate = jobEnterpriseJobPositionModel.JobPositionStartDate;//开始日期
                txbJobPositionEndDate.SelectedDate = jobEnterpriseJobPositionModel.JobPositionEndDate;//结束日期
                txbInterviewTime.Text = jobEnterpriseJobPositionModel.InterviewTime;//面试时间
                txbInterviewAddress.Text = jobEnterpriseJobPositionModel.InterviewAddress;//面试地点
                drpSpecialType.SelectedValue = jobEnterpriseJobPositionModel.SpecialType.ToString();//是否显示在首页

                ViewState["CreateDate"] = jobEnterpriseJobPositionModel.CreateDate.ToString();
                ViewState["JobPositionGuid"] = jobEnterpriseJobPositionModel.JobPositionGuid.ToString();
                ToolbarText2.Text = "编辑一个管理员账号";
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
                zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = new zlzw.Model.JobEnterpriseJobPositionModel();
                jobEnterpriseJobPositionModel.JobFeildKinds = drpJobFeildKinds01.SelectedText + "|" + drpJobFeildKinds.SelectedText;//行业类别
                jobEnterpriseJobPositionModel.EnterpriseKey = drpEnterpriseKey.SelectedValue;//所属企业GUID
                jobEnterpriseJobPositionModel.DepartmentName = txbDepartmentName.Text;//所要招聘的部门
                jobEnterpriseJobPositionModel.JobPositionStatus = int.Parse(drpJobPositionStatus.SelectedValue);//简历状态
                jobEnterpriseJobPositionModel.EnterpriseName = Get_EnterpriseName(drpEnterpriseKey.SelectedValue);//企业名称
                jobEnterpriseJobPositionModel.JobPositionName = txbJobPositionName.Text;//岗位名称
                jobEnterpriseJobPositionModel.JobPositionKind = txbJobPositionKind.Text;//岗位名称中文
                jobEnterpriseJobPositionModel.JobWorkType = int.Parse(drpJobWorkType.SelectedValue);//岗位性质
                jobEnterpriseJobPositionModel.JobWorkPlaceNames = txbJobWorkPlaceNames.Text;//工作地点
                jobEnterpriseJobPositionModel.JobPositionKinds = txbJobPositionKinds.Text;//从事的职业类别
                jobEnterpriseJobPositionModel.JobSalary = int.Parse(drpJobSalary.SelectedValue);//月薪
                jobEnterpriseJobPositionModel.NeedPersonCount = int.Parse(txbNeedPersonCount.Text);//招聘人数
                jobEnterpriseJobPositionModel.NeedEducation = int.Parse(drpNeedEducation.SelectedValue);//学历要求
                jobEnterpriseJobPositionModel.NeedAge = txbNeedAge.Text;//年龄要求
                jobEnterpriseJobPositionModel.NeedSex = int.Parse(drpNeedSex.SelectedValue);//性别要求
                jobEnterpriseJobPositionModel.NeedWorkExperience = int.Parse(drpNeedWorkExperience.SelectedValue);//工作经验要求
                jobEnterpriseJobPositionModel.NeedMangeExperience = int.Parse(drpNeedMangeExperience.SelectedValue);//是否有管理经验
                jobEnterpriseJobPositionModel.JobPositionDesc = txbJobPositionDesc.Text;//职位描述
                jobEnterpriseJobPositionModel.ContactPerson = txbContactPerson.Text;//联系人
                jobEnterpriseJobPositionModel.ContactTelephone = txbContactTelephone.Text;//联系人电话
                jobEnterpriseJobPositionModel.ContactMail = txbContactMail.Text;//联系人邮件
                jobEnterpriseJobPositionModel.JobPositionStartDate = DateTime.Parse(txbJobPositionStartDate.Text);//开始日期
                jobEnterpriseJobPositionModel.JobPositionEndDate = DateTime.Parse(txbJobPositionEndDate.Text);//结束日期
                jobEnterpriseJobPositionModel.InterviewTime = txbInterviewTime.Text;//面试时间
                jobEnterpriseJobPositionModel.InterviewAddress = txbInterviewAddress.Text;//面试地点
                jobEnterpriseJobPositionModel.SpecialType = int.Parse(drpSpecialType.SelectedValue);//是否显示在首页
                jobEnterpriseJobPositionModel.UpdateDate = DateTime.Now;//更新日期
                //在数据库中添加JobPositionStatus简历状态
                jobEnterpriseJobPositionModel.CanUsable = 1;
                jobEnterpriseJobPositionModel.CreateDate = DateTime.Parse(ViewState["CreateDate"].ToString());
                jobEnterpriseJobPositionModel.JobPositionGuid = new Guid(ViewState["JobPositionGuid"].ToString());
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                jobEnterpriseJobPositionModel.JobPositionID = int.Parse(Get_ID(jobEnterpriseJobPositionBLL, Request.QueryString["value"]));

                jobEnterpriseJobPositionBLL.Update(jobEnterpriseJobPositionModel);
            }
            else
            {
                //添加保存

                zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = new zlzw.Model.JobEnterpriseJobPositionModel();
                jobEnterpriseJobPositionModel.JobFeildKinds = drpJobFeildKinds01.SelectedText + "|" + drpJobFeildKinds.SelectedText;//行业类别
                jobEnterpriseJobPositionModel.EnterpriseKey = drpEnterpriseKey.SelectedValue;//所属企业GUID
                jobEnterpriseJobPositionModel.DepartmentName = txbDepartmentName.Text;//所要招聘的部门
                jobEnterpriseJobPositionModel.JobPositionStatus = int.Parse(drpJobPositionStatus.SelectedValue);//简历状态
                jobEnterpriseJobPositionModel.EnterpriseName = Get_EnterpriseName(drpEnterpriseKey.SelectedValue);//企业名称
                jobEnterpriseJobPositionModel.JobPositionName = txbJobPositionName.Text;//岗位名称
                jobEnterpriseJobPositionModel.JobPositionKind = txbJobPositionKind.Text;//岗位名称中文
                jobEnterpriseJobPositionModel.JobWorkType = int.Parse(drpJobWorkType.SelectedValue);//岗位性质
                jobEnterpriseJobPositionModel.JobWorkPlaceNames = txbJobWorkPlaceNames.Text;//工作地点
                jobEnterpriseJobPositionModel.JobPositionKinds = txbJobPositionKinds.Text;//从事的职业类别
                jobEnterpriseJobPositionModel.JobSalary = int.Parse(drpJobSalary.SelectedValue);//月薪
                jobEnterpriseJobPositionModel.NeedPersonCount = int.Parse(txbNeedPersonCount.Text);//招聘人数
                jobEnterpriseJobPositionModel.NeedEducation = int.Parse(drpNeedEducation.SelectedValue);//学历要求
                jobEnterpriseJobPositionModel.NeedAge = txbNeedAge.Text;//年龄要求
                jobEnterpriseJobPositionModel.NeedSex = int.Parse(drpNeedSex.SelectedValue);//性别要求
                jobEnterpriseJobPositionModel.NeedWorkExperience = int.Parse(drpNeedWorkExperience.SelectedValue);//工作经验要求
                jobEnterpriseJobPositionModel.NeedMangeExperience = int.Parse(drpNeedMangeExperience.SelectedValue);//是否有管理经验
                jobEnterpriseJobPositionModel.JobPositionDesc = txbJobPositionDesc.Text;//职位描述
                jobEnterpriseJobPositionModel.ContactPerson = txbContactPerson.Text;//联系人
                jobEnterpriseJobPositionModel.ContactTelephone = txbContactTelephone.Text;//联系人电话
                jobEnterpriseJobPositionModel.ContactMail = txbContactMail.Text;//联系人邮件
                jobEnterpriseJobPositionModel.JobPositionStartDate = DateTime.Parse(txbJobPositionStartDate.Text);//开始日期
                jobEnterpriseJobPositionModel.JobPositionEndDate = DateTime.Parse(txbJobPositionEndDate.Text);//结束日期
                jobEnterpriseJobPositionModel.InterviewTime = txbInterviewTime.Text;//面试时间
                jobEnterpriseJobPositionModel.InterviewAddress = txbInterviewAddress.Text;//面试地点
                jobEnterpriseJobPositionModel.SpecialType = int.Parse(drpSpecialType.SelectedValue);//是否显示在首页
                jobEnterpriseJobPositionModel.UpdateDate = DateTime.Now;//更新日期
                jobEnterpriseJobPositionModel.CreateDate = DateTime.Now;//创建日期
                jobEnterpriseJobPositionModel.CanUsable = 1;
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                jobEnterpriseJobPositionBLL.Add(jobEnterpriseJobPositionModel);
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

        #region 根据Cookie中的ID获取用户名称

        private string Get_UserName()
        {
            if (Request.Cookies["UserID"] != null)
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                DataTable dt = coreUserBLL.GetList("UserGuid='" + Request.Cookies["UserID"].Value + "'").Tables[0];

                return dt.Rows[0]["UserName"].ToString();
            }
            else
            {
                return "未知用户";
            }
        }

        #endregion

        #region 根据企业GUID获取企业名称

        private string Get_EnterpriseName(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='"+ strEnterpriseGUID +"'").Tables[0];
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