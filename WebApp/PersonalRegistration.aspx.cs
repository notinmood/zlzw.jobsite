using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;

namespace WebApp
{
    public partial class PersonalRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_UserEducationalBackground();//学历加载
                Load_JobSalaryList();//期望薪资加载
                Load_JobWorkTypeList();//求职性质加载
                Load_MaritalStatusList();//婚姻状况加载
                Load_JobPositionKindsTypeList();//加载职位类别
                Load_JobFeildKinds();//加载期望行业

            }
        }

        #region 加载学历列表

        private void Load_UserEducationalBackground()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='NeedEducation' and CanUsable=1 order by OrderNumber asc").Tables[0];
            
            drpUserEducationalBackground.DataTextField = "SettingValue";
            drpUserEducationalBackground.DataValueField = "SettingKey";

            drpUserEducationalBackground.DataSource = dt;
            drpUserEducationalBackground.DataBind();
            drpUserEducationalBackground.Items.RemoveAt(0);
        }

        #endregion

        #region 加载求职性质

        private void Load_JobWorkTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobWorkType' and CanUsable=1 order by OrderNumber asc").Tables[0];

            drpJobWorkType.DataTextField = "SettingValue";
            drpJobWorkType.DataValueField = "SettingKey";

            drpJobWorkType.DataSource = dt;
            drpJobWorkType.DataBind();
        }

        #endregion

        #region 加载婚姻状况列表

        private void Load_MaritalStatusList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='MaritalStatus' and CanUsable=1 order by OrderNumber asc").Tables[0];

            drpMaritalStatus.DataTextField = "SettingValue";
            drpMaritalStatus.DataValueField = "SettingKey";

            drpMaritalStatus.DataSource = dt;
            drpMaritalStatus.DataBind();
        }

        #endregion

        #region 加载期望薪资列表

        private void Load_JobSalaryList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobSalary' and CanUsable=1 order by OrderNumber asc").Tables[0];

            drpJobSalary.DataTextField = "SettingValue";
            drpJobSalary.DataValueField = "SettingKey";

            drpCurrentSalary.DataTextField = "SettingValue";
            drpCurrentSalary.DataValueField = "SettingKey";

            drpJobSalary.DataSource = dt;
            drpJobSalary.DataBind();

            drpCurrentSalary.DataSource = dt;
            drpCurrentSalary.DataBind();
        }

        #endregion

        #region 加载职位类别

        private void Load_JobPositionKindsTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='" + drpJobPositionKindsType.SelectedValue + "'").Tables[0];

            drpJobPositionKinds.DataTextField = "SettingValue";
            drpJobPositionKinds.DataValueField = "SettingValue";

            drpJobPositionKinds.DataSource = dt;
            drpJobPositionKinds.DataBind();
        }

        #endregion

        #region 加载期望行业

        private void Load_JobFeildKinds()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='" + drpJobFeildKindsType.SelectedValue + "'").Tables[0];

            drpJobFeildKinds.DataTextField = "SettingValue";
            drpJobFeildKinds.DataValueField = "SettingValue";

            drpJobFeildKinds.DataSource = dt;
            drpJobFeildKinds.DataBind();
        }

        #endregion

        #region 简历提交按钮事件

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["IsSubmit"] != null)
            {
                return;
            }
            zlzw.Model.CoreUserModel coreUserModel = new zlzw.Model.CoreUserModel();
            coreUserModel.UserGuid = Guid.NewGuid();
            coreUserModel.UserName = Request.Form["txbUserName"];//用户名
            coreUserModel.Password = Request.Form["txbPassword"];//用户密码
            coreUserModel.UserNameCN = Request.Form["txbUserNameCN"];//用户姓名
            coreUserModel.UserSex = int.Parse(Request.Form["drpUserSex"]);//用户性别
            coreUserModel.UserEducationalBackground = int.Parse(Request.Form["drpUserEducationalBackground"]);//用户学历
            coreUserModel.UserBirthDay = DateTime.Parse(Request.Form["txbUserBirthDay"]);//出生日期
            coreUserModel.UserMobileNO = Request.Form["txbUserMobileNO"];//联系电话
            coreUserModel.UserCountry = Request.Form["txbUserCountry"];//户口原籍
            coreUserModel.CurrentResidence = Request.Form["txbCurrentResidence"];//当前居住地
            coreUserModel.UserEmail = Request.Form["txbUserEmail"];//用户电子信箱
            coreUserModel.MaritalStatus = int.Parse(Request.Form["drpMaritalStatus"]);//婚姻状态
            if (txbUserHeight.Text.Length == 0)
            {
                coreUserModel.UserHeight = Decimal.Parse("0");//身高
            }
            else
            {
                coreUserModel.UserHeight = Decimal.Parse(Request.Form["txbUserHeight"]);//身高
            }
            if (txbUserWeight.Text.Length == 0)
            {
                coreUserModel.UserWeight = Decimal.Parse("0");//体重
            }
            else
            {
                coreUserModel.UserWeight = Decimal.Parse(Request.Form["txbUserWeight"]);//体重
            }
            coreUserModel.UserRegisterDate = DateTime.Now;//用户注册日期
            coreUserModel.UserLastDateTime = DateTime.Now;//用户最后一次登录日期
            coreUserModel.UserType = 1;//普通用户
            coreUserModel.UserStatus = 1;//状态可用
            if (uploadUserPhoto.HasFile)
            {
                string strFileExt = System.IO.Path.GetExtension(uploadUserPhoto.FileName);
                if (strFileExt == ".jpg" || strFileExt == ".gif" || strFileExt == ".png" || strFileExt == ".jpeg" || strFileExt == ".bmp")
                {
                    string strFilePath = "~/UserPhotos/" + txbUserName.Text + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + strFileExt;
                    uploadUserPhoto.SaveAs(Server.MapPath(strFilePath));
                    coreUserModel.UserPhoto = strFilePath;
                }
            }

            zlzw.Model.JobPersonResumeModel jobPersonResumeModel = new zlzw.Model.JobPersonResumeModel();
            jobPersonResumeModel.OwnerUserKey = coreUserModel.UserGuid.ToString();//用户表GUID 
            jobPersonResumeModel.JobPositionKinds = drpJobPositionKindsType.SelectedValue + "-" + Request.Form["drpJobPositionKinds"];//职位类别
            jobPersonResumeModel.JobFeildKinds = drpJobFeildKindsType.SelectedValue + "-" + Request.Form["drpJobFeildKinds"];//期望行业
            jobPersonResumeModel.HopeJob = Request.Form["txbHopeJob"];//意向职位
            jobPersonResumeModel.JobWorkPlaceNames = Request.Form["txbJobWorkPlaceNames"];//期望地址
            jobPersonResumeModel.HopeRoomAndBoard = int.Parse(Request.Form["drpHopeRoomAndBoard"]);//期望食宿
            jobPersonResumeModel.JobSalary = int.Parse(Request.Form["drpJobSalary"]);//期望薪资
            jobPersonResumeModel.PersonalSkills = Request.Form["txbPersonalSkills"];//个人技能
            jobPersonResumeModel.SkillsCertificate = Request.Form["txbSkillsCertificate"];//技能证书
            jobPersonResumeModel.JobCurrentWorkStatus = int.Parse(Request.Form["drpJobCurrentWorkStatus"]);//当前状态
            jobPersonResumeModel.CurrentSalary = Request.Form["drpCurrentSalary"];//当前薪资
            jobPersonResumeModel.JobWorkType = int.Parse(Request.Form["drpJobWorkType"]);//当前状态
            jobPersonResumeModel.WorkExperience = Request.Form["txbWorkExperience"];//工作经历
            jobPersonResumeModel.EducationExperience = Request.Form["txbEducationExperience"];//教育经历
            jobPersonResumeModel.CreateDate = DateTime.Now;//创建日期
            jobPersonResumeModel.UpdateDate = DateTime.Now;//更新日期
            jobPersonResumeModel.CanUsable = 1;//状态可用
            jobPersonResumeModel.ResumeStatus = 1;//状态可用
            jobPersonResumeModel.UserAge = int.Parse(Get_CurrentUserAge(Request.Form["txbUserBirthDay"]));//用户年龄
            jobPersonResumeModel.UserSex = Get_UserSex(Request.Form["drpUserSex"]);//用户性别

            try
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                coreUserBLL.Add(coreUserModel);
                zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
                jobPersonResumeBLL.Add(jobPersonResumeModel);
                txbUserName.Text = "";
                txbPassword.Text = "";
                txbUserNameCN.Text = "";
                txbUserMobileNO.Text = "";
                txbUserCountry.Text = "";
                txbCurrentResidence.Text = "";
                txbUserEmail.Text = "";
                txbHopeJob.Text = "";
                txbJobWorkPlaceNames.Text = "";
                txbPersonalSkills.Text = "";
                txbSkillsCertificate.Text = "";
                txbWorkExperience.Text = "";
                txbEducationExperience.Text = "";
                if (Session["IsSubmit"] == null)
                {
                    FineUI.Alert.Show("简历提交成功");
                    Session["IsSubmit"] = "1";
                }
                HttpCookie userGUID = new HttpCookie("CurrentUserGUID", coreUserModel.UserGuid.ToString());
                HttpCookie uerName = new HttpCookie("CurrentUserName", coreUserModel.UserName);
                userGUID.Expires = DateTime.Now.AddDays(1);
                uerName.Expires = DateTime.Now.AddDays(1);
                System.Web.HttpContext.Current.Response.Cookies.Add(userGUID);
                System.Web.HttpContext.Current.Response.Cookies.Add(uerName);
                Response.Redirect("default.aspx");
            }
            catch (Exception exp)
            {
                FineUI.Alert.Show("简历提交失败，请稍后重试");
            }

        }

        #endregion

        #region 获取用户性别（中文）

        private string Get_UserSex(string strSexTag)
        {
            if (strSexTag == "1")
            {
                return "男";
            }
            else if(strSexTag == "0")
            {
                return "女";
            }

            return "未知";
        }

        #endregion

        #region 获取用户当前年龄

        private string Get_CurrentUserAge(string strUserBirthDay)
        {
            DateTime dateUserBirthday = DateTime.Parse(strUserBirthDay);

            return (DateTime.Now.Year - dateUserBirthday.Year).ToString();
        }

        #endregion
    }
}