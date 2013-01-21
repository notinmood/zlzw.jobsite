using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddJobPersonResume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                Load_UserEducationalBackgroundList();//加载学历背景列表
                Load_JobSalaryList();//加载期望月薪列表
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 绑定学历背景列表

        private void Load_UserEducationalBackgroundList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='NeedEducation' order by OrderNumber asc").Tables[0];

            drpUserEducationalBackground.DataTextField = "SettingValue";
            drpUserEducationalBackground.DataValueField = "SettingKey";

            drpUserEducationalBackground.DataSource = dt;
            drpUserEducationalBackground.DataBind();
        }

        #endregion

        #region 绑定期望月薪列表

        private void Load_JobSalaryList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobSalary' order by OrderNumber asc").Tables[0];

            drpJobSalary.DataTextField = "SettingValue";
            drpJobSalary.DataValueField = "SettingKey";

            drpJobSalary.DataSource = dt;
            drpJobSalary.DataBind();
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
                zlzw.Model.JobPersonResumeModel jobPersonResumeModel = jobPersonResumeBLL.GetModel(int.Parse(Get_ID(jobPersonResumeBLL, strID)));
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                zlzw.Model.CoreUserModel coreUserModel = coreUserBLL.GetModel(int.Parse(Get_UserID(coreUserBLL, jobPersonResumeModel.OwnerUserKey)));
                drpResumeStatus.SelectedValue = jobPersonResumeModel.ResumeStatus.ToString();//是否允许企业查看
                txbOwnerUserName.Text = jobPersonResumeModel.OwnerUserName;//求职者姓名
                drpUserSex.SelectedValue = coreUserModel.UserSex.ToString();//用户性别
                drpUserEducationalBackground.SelectedValue = coreUserModel.UserEducationalBackground.ToString();//教育背景
                txbUserBirthDay.Text = DateTime.Parse(coreUserModel.UserBirthDay.ToString()).ToString("yyyy年MM月dd");
                txbUserMobileNO.Text = coreUserModel.UserMobileNO;//手机号
                txbUserCountry.Text = coreUserModel.UserCountry;//户口原籍
                txbCurrentResidence.Text = coreUserModel.CurrentResidence; //现居住地
                txbCompanyMail.Text = coreUserModel.CompanyMail;//电子邮件
                txbJobPositionKinds.Text =jobPersonResumeModel.JobPositionKinds;//行业分类
                labJobPositionKinds01.Text = jobPersonResumeModel.JobFeildKinds;//期望所从事的行业
                labHopeJob.Text = jobPersonResumeModel.HopeJob;//意向职位名称
                txbJobWorkPlaceNames.Text = jobPersonResumeModel.JobWorkPlaceNames;//期望的工作地址
                drpHopeRoomAndBoard.SelectedValue = jobPersonResumeModel.HopeRoomAndBoard.ToString();//期望食宿
                drpJobSalary.SelectedValue = jobPersonResumeModel.JobSalary.ToString();//期望月薪
                txbPersonalSkills.Text = jobPersonResumeModel.PersonalSkills;//个人技能
                txbSkillsCertificate.Text = jobPersonResumeModel.SkillsCertificate;//技能证书
                drpJobWorkType.SelectedValue = jobPersonResumeModel.JobWorkType.ToString();//求职性质(工作性质)
                txbWorkExperience.Text = jobPersonResumeModel.WorkExperience;//工作经历
                txbEducationExperience.Text = jobPersonResumeModel.EducationExperience;//教育经历
                txbUserHeight.Text = coreUserModel.UserHeight.ToString();//身高
                txbUserWeight.Text = coreUserModel.UserWeight.ToString();//体重
                imgUserPhoto.ImageUrl = coreUserModel.UserPhoto.Split('~')[1];//求职者照片
                labCreateDate.Text = DateTime.Parse(jobPersonResumeModel.CreateDate.ToString()).ToString("yyyy年MM月dd");//简历创建时间
                labUpdateDate.Text = DateTime.Parse(jobPersonResumeModel.UpdateDate.ToString()).ToString("yyyy年MM月dd");//简历更新时间

                ToolbarText2.Text = "查看一份个人简历";
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
        }

        #endregion

        #region 保存按钮事件

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            //if (Request.QueryString["Type"] == "1")
            //{
            //    //编辑保存
            //    zlzw.Model.CoreUserModel coreUserModel = new zlzw.Model.CoreUserModel();
            //    coreUserModel.UserName = txbAdminName.Text;
            //    coreUserModel.Password = txbAdminPassword.Text;
            //    coreUserModel.UserStatus = 1;
            //    coreUserModel.UserType = 64;
            //    coreUserModel.UserRegisterDate = DateTime.Parse(ViewState["PublishDate"].ToString());
            //    coreUserModel.UserGuid = new Guid(ViewState["AdminGUID"].ToString());
            //    zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            //    coreUserModel.UserID = int.Parse(Get_ID(coreUserBLL, Request.QueryString["value"]));

            //    coreUserBLL.Update(coreUserModel);
            //}
            //else
            //{
            //    //添加保存

            //    zlzw.Model.CoreUserModel coreUserModel = new zlzw.Model.CoreUserModel();
            //    coreUserModel.UserName = txbAdminName.Text;
            //    coreUserModel.Password = txbAdminPassword.Text;
            //    coreUserModel.UserStatus = 1;
            //    coreUserModel.UserType = 64;
            //    coreUserModel.UserRegisterDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            //    coreUserModel.UserGuid = System.Guid.NewGuid();
            //    zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            //    coreUserBLL.Add(coreUserModel);
            //}

            //// 2. Close this window and Refresh parent window
            //PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取用户ID

        private string Get_UserID(zlzw.BLL.CoreUserBLL coreUserBLL, string strGUID)
        {
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='"+ strGUID +"'").Tables[0];

            return dt.Rows[0]["UserID"].ToString();
        }

        #endregion

        #region 获取行业类别

        private string Get_JobFeildKinds(string strSettingID)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            zlzw.Model.GeneralBasicSettingModel GeneralBasicSettingModel = generalBasicSettingBLL.GetModel(int.Parse(strSettingID));

            return GeneralBasicSettingModel.DisplayName;
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL, string strGUID)
        {
            System.Data.DataTable dt = jobPersonResumeBLL.GetList("ResumeGuid='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["ResumeID"].ToString();
        }

        #endregion

    }
}