using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;

namespace WebApp
{
    public partial class EditPersonalInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                Load_UserInfo(Request.QueryString["ID"]);
                Load_UserEducationalBackground();//学历加载
                Load_JobSalaryList();//期望薪资加载
                Load_JobWorkTypeList();//求职性质加载
                Load_MaritalStatusList();//婚姻状况加载
                Load_JobPositionKindsTypeList();//加载职位类别
                Load_JobFeildKinds();//加载期望行业
            }
            else
            {
                Response.Redirect("default.aspx");
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

        #region 加载用信息

        private void Load_UserInfo(string strUserID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            DataTable dt = coreUserBLL.GetList("UserGuid='"+ strUserID +"'").Tables[0];
            zlzw.Model.CoreUserModel coreUserModel = coreUserBLL.GetModel(int.Parse(dt.Rows[0]["UserID"].ToString()));
            txbUserName.Text = coreUserModel.UserName;//用户名
            txbPassword.Text = coreUserModel.Password;//用户密码
            txbUserNameCN.Text = coreUserModel.UserNameCN;//用户姓名
            drpUserSex.SelectedValue = coreUserModel.UserSex.ToString();//用户性别
            drpUserEducationalBackground.SelectedValue = coreUserModel.UserEducationalBackground.ToString();//用户学历
            txbUserBirthDay.Text = DateTime.Parse(coreUserModel.UserBirthDay.ToString()).ToString("yyyy-MM-dd");//出生日期
            txbUserMobileNO.Text = coreUserModel.UserMobileNO;//联系电话
            txbUserCountry.Text = coreUserModel.UserCountry;//户口原籍
            txbCurrentResidence.Text = coreUserModel.CurrentResidence;//当前居住地
            txbUserEmail.Text = coreUserModel.UserEmail;//用户电子信箱
            drpMaritalStatus.SelectedValue = coreUserModel.MaritalStatus.ToString();//婚姻状态
            txbUserHeight.Text = coreUserModel.UserHeight.ToString();//身高
            txbUserWeight.Text = coreUserModel.UserWeight.ToString();//体重
            ViewState["UserRegisterDate"] = coreUserModel.UserRegisterDate;//用户注册日期
            ViewState["UserLastDateTime"] = coreUserModel.UserLastDateTime;//用户最后一次登录日期
            ViewState["UserPhoto"] = coreUserModel.UserPhoto;//用户头像

            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            DataTable dt01 = jobPersonResumeBLL.GetList("OwnerUserKey='" + strUserID + "'").Tables[0];
            zlzw.Model.JobPersonResumeModel jobPersonResumeModel = jobPersonResumeBLL.GetModel(int.Parse(dt01.Rows[0]["ResumeID"].ToString()));
            drpJobPositionKindsType.SelectedValue = jobPersonResumeModel.JobPositionKinds.Split('-')[0];//职位类别（大类）
            drpJobPositionKinds.SelectedValue = jobPersonResumeModel.JobPositionKinds.Split('-')[1];//职位列别（小类）
            drpJobFeildKindsType.SelectedValue = jobPersonResumeModel.JobFeildKinds.Split('-')[0];//期望行业（小类）
            drpJobFeildKinds.SelectedValue = jobPersonResumeModel.JobFeildKinds.Split('-')[1];//期望行业（小类）
            txbHopeJob.Text = jobPersonResumeModel.HopeJob;//意向职位
            txbJobWorkPlaceNames.Text = jobPersonResumeModel.JobWorkPlaceNames;//期望地址
            drpHopeRoomAndBoard.SelectedValue = jobPersonResumeModel.HopeRoomAndBoard.ToString();//期望食宿
            drpJobSalary.SelectedValue = jobPersonResumeModel.JobSalary.ToString();//期望薪资
            txbPersonalSkills.Text = jobPersonResumeModel.PersonalSkills;//个人技能
            txbSkillsCertificate.Text = jobPersonResumeModel.SkillsCertificate;//技能证书
            drpJobCurrentWorkStatus.SelectedValue = jobPersonResumeModel.JobCurrentWorkStatus.ToString();//当前状态
            drpCurrentSalary.SelectedValue = jobPersonResumeModel.CurrentSalary;//当前薪资
            drpJobWorkType.SelectedValue = jobPersonResumeModel.JobWorkType.ToString();//当前状态
            txbWorkExperience.Text = jobPersonResumeModel.WorkExperience;//工作经历
            txbEducationExperience.Text = jobPersonResumeModel.EducationExperience;//教育经历
            ViewState["CreateDate"] = jobPersonResumeModel.CreateDate.ToString();//创建日期
            
        }

        #endregion

        #region 简历提交修改事件

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(Request.QueryString["ID"] == null)
            {
                Response.Redirect("default.aspx");
            }
            if (Session["IsUpdateSubmit"] != null)
            {
                return;
            }
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            DataTable dt = coreUserBLL.GetList("UserGuid='" + Request.QueryString["ID"] + "'").Tables[0];
            zlzw.Model.CoreUserModel coreUserModel = coreUserBLL.GetModel(int.Parse(dt.Rows[0]["UserID"].ToString()));
            coreUserModel.UserGuid = new Guid(Request.QueryString["ID"]);
            coreUserModel.UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
            coreUserModel.UserName = Request.Params["txbUserName"]; //txbUserName.Text;//用户名
            coreUserModel.Password = Request.Params["txbPassword"];//用户密码
            coreUserModel.UserNameCN = Request.Params["txbUserNameCN"];//用户姓名
            coreUserModel.UserSex = int.Parse(Request.Form["drpUserSex"]);//用户性别
            coreUserModel.UserEducationalBackground = int.Parse(Request.Form["drpUserEducationalBackground"]);//用户学历
            coreUserModel.UserBirthDay = DateTime.Parse(Request.Params["txbUserBirthDay"]);//出生日期
            coreUserModel.UserMobileNO = Request.Params["txbUserMobileNO"];//联系电话
            coreUserModel.UserCountry = Request.Params["txbUserCountry"];//户口原籍
            coreUserModel.CurrentResidence = Request.Params["txbCurrentResidence"];//当前居住地
            coreUserModel.UserEmail = Request.Params["txbUserEmail"];//用户电子信箱
            coreUserModel.MaritalStatus = int.Parse(Request.Form["drpMaritalStatus"]);//婚姻状态
            coreUserModel.UserHeight = Decimal.Parse(Request.Params["txbUserHeight"]);//身高
            coreUserModel.UserWeight = Decimal.Parse(Request.Params["txbUserWeight"]);//体重
            coreUserModel.UserRegisterDate = DateTime.Parse(ViewState["UserRegisterDate"].ToString());//用户注册日期
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
            else
            {
                coreUserModel.UserPhoto = ViewState["UserPhoto"].ToString();
            }

            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            DataTable dt01 = jobPersonResumeBLL.GetList("OwnerUserKey='" + Request.QueryString["ID"] + "'").Tables[0];
            zlzw.Model.JobPersonResumeModel jobPersonResumeModel = jobPersonResumeBLL.GetModel(int.Parse(dt01.Rows[0]["ResumeID"].ToString()));
            jobPersonResumeModel.ResumeID = int.Parse(dt01.Rows[0]["ResumeID"].ToString());
            jobPersonResumeModel.OwnerUserKey = Request.QueryString["ID"];
            jobPersonResumeModel.JobPositionKinds = drpJobPositionKindsType.SelectedValue + "-" + Request.Form["drpJobPositionKinds"];//职位类别
            jobPersonResumeModel.JobFeildKinds = drpJobFeildKindsType.SelectedValue + "-" + Request.Form["drpJobFeildKinds"];//期望行业
            jobPersonResumeModel.HopeJob = Request.Params["txbHopeJob"];//意向职位
            jobPersonResumeModel.JobWorkPlaceNames = Request.Params["txbJobWorkPlaceNames"];//期望地址
            jobPersonResumeModel.HopeRoomAndBoard = int.Parse(Request.Form["drpHopeRoomAndBoard"]);//期望食宿
            jobPersonResumeModel.JobSalary = int.Parse(Request.Form["drpJobSalary"]);//期望薪资
            jobPersonResumeModel.PersonalSkills = Request.Params["txbPersonalSkills"];//个人技能
            jobPersonResumeModel.SkillsCertificate = Request.Params["txbSkillsCertificate"];//技能证书
            jobPersonResumeModel.JobCurrentWorkStatus = int.Parse(Request.Form["drpJobCurrentWorkStatus"]);//当前状态
            jobPersonResumeModel.CurrentSalary = Request.Form["drpCurrentSalary"];//当前薪资
            jobPersonResumeModel.JobWorkType = int.Parse(Request.Form["drpJobWorkType"]);//工作性质
            jobPersonResumeModel.WorkExperience = Request.Params["txbWorkExperience"];//工作经历
            jobPersonResumeModel.EducationExperience = Request.Params["txbEducationExperience"];//教育经历
            jobPersonResumeModel.CreateDate = DateTime.Parse(ViewState["CreateDate"].ToString());//创建日期
            jobPersonResumeModel.UpdateDate = DateTime.Now;//简历更新时间
            jobPersonResumeModel.CanUsable = 1;//状态可用
            jobPersonResumeModel.ResumeStatus = 1;//状态可用
            jobPersonResumeModel.UserAge = int.Parse(Get_CurrentUserAge(Request.Form["txbUserBirthDay"]));//用户年龄
            jobPersonResumeModel.UserSex = Get_UserSex(Request.Form["drpUserSex"]);//用户性别

            try
            { 
                coreUserBLL.Update(coreUserModel);
                jobPersonResumeBLL.Update(jobPersonResumeModel);
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
                if (Session["IsUpdateSubmit"] == null)
                {
                    FineUI.Alert.Show("简历更新成功");
                    Session["IsUpdateSubmit"] = "1";
                }
                System.Web.HttpCookie UserGUID = System.Web.HttpContext.Current.Request.Cookies["CurrentUserGUID"];
                System.Web.HttpCookie UserName = System.Web.HttpContext.Current.Request.Cookies["CurrentUserName"];

                UserGUID.Expires = DateTime.Now.AddDays(-1);
                UserName.Expires = DateTime.Now.AddDays(-1);

                System.Web.HttpContext.Current.Response.Cookies.Add(UserGUID);
                System.Web.HttpContext.Current.Response.Cookies.Add(UserName);
                Response.Redirect("default.aspx");
            }
            catch (Exception exp)
            {
                FineUI.Alert.Show("简历更新失败，请稍后重试");
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
            else if (strSexTag == "0")
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