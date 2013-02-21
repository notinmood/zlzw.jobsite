using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ResumeSearchInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Load_UserInfo(Request.QueryString["id"]);
                }
                catch (Exception exp)
                {

                }
            }
        }

        #region 判断当前企业是否下载过该简历

        private bool Get_IsDownload()
        {
            string strCurrentResumeID = Request.QueryString["id"];//简历ID
            string strCurrentEnterpriseID = Request.Cookies["CurrentUserGUID"].Value;//当前企业ID
            zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();
            System.Data.DataTable dt = resumeCollectionListBLL.GetList("ResumeGuid='" + strCurrentResumeID + "' and EnterpriseGuid='" + strCurrentEnterpriseID + "' and ResumeCollectionType=0 and EnterpriseIsDel=1 and IsEnable=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 加载用户简历信息

        /// <summary>
        /// 根据简历ID获取简历信息
        /// </summary>
        /// <param name="strUserGUID"></param>
        private void Load_UserInfo(string strUserGUID)
        {
            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            zlzw.Model.JobPersonResumeModel jobPersonResumeModel = jobPersonResumeBLL.GetModel(Get_JobPersonResumeID(strUserGUID));
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + jobPersonResumeModel.OwnerUserKey + "'").Tables[0];
            ViewState["CoreUserDataTable"] = dt;
            labUserName.Text = Get_UserName(jobPersonResumeModel.OwnerUserKey);//用户名称
            labUserSex.Text = Get_UserSex(strUserGUID);//用户性别
            labEducational.Text = Get_UserEducationalBackground(strUserGUID);//用户学历
            labUserAge.Text = Get_UserAge(strUserGUID);//用户年龄
            labOrigin.Text = Get_UserCountry(strUserGUID);//原籍
            labUserMarriage.Text = Get_MaritalStatus(strUserGUID);//婚姻状况
            if (Get_IsDownload())
            {
                lanUserPhone.Text = Get_UserTel(strUserGUID);//用户电话
                labUserMail.Text = Get_UserEmail(strUserGUID);//电子邮件
                imgBtnDownload.Visible = false;
                imgBtnReturn.Visible = true;
            }
            else
            {
                imgBtnDownload.Visible = true;
                imgBtnReturn.Visible = false;
                lanUserPhone.Text = "<span style='color:#093C7E;font-weight:bold;'>请下载后查看</span>";//用户电话
                labUserMail.Text = "<span style='color:#093C7E;font-weight:bold;'>请下载后查看</span>";
            }
            if (jobPersonResumeModel.JobCurrentWorkStatus.ToString() == "0")//当前状态
            {
                labJobCurrentWorkStatus.Text = "离职";
            }
            else
            {
                labJobCurrentWorkStatus.Text = "在职";
            }
            if (jobPersonResumeModel.HopeRoomAndBoard.ToString() == "0")//期望食宿s
            {
                labHopeRoomAndBoard.Text = "不限";
            }
            else
            {
                labHopeRoomAndBoard.Text = "提供食宿";
            }
            labJobSalary.Text = Get_labJobSalary(jobPersonResumeModel.JobSalary.ToString());//期望薪资
            if (jobPersonResumeModel.JobWorkType.ToString() == "0")
            {
                labJobWorkType.Text = "全职";//求职性质
            }
            else
            {
                labJobWorkType.Text = "兼职";//求职性质
            }
            labCurrentSalary.Text = Get_labJobSalary(jobPersonResumeModel.CurrentSalary);//当前薪资
            labUserHeight.Text = Get_UserHeight(strUserGUID) + "cm";//身高
            labUserWeight.Text = Get_UserWeight(strUserGUID) + "kg";//体重
            labPersonalSkills.Text = jobPersonResumeModel.PersonalSkills;//个人技能
            labSkillsCertificate.Text = jobPersonResumeModel.SkillsCertificate;//技能证书
            labCurrentResidence.Text = get_CurrentResidence(strUserGUID);//当前居住地
            labJobPositionKinds.Text = jobPersonResumeModel.JobPositionKinds.Split('-')[1];//期望职位
            labJobFeildKinds.Text = jobPersonResumeModel.JobFeildKinds.Split('-')[1];//期望行业
            labHopeJob.Text = jobPersonResumeModel.HopeJob;//意向职位名称
            labJobWorkPlaceNames.Text = jobPersonResumeModel.JobWorkPlaceNames;//期望工作地点
            labWorkExperience.Text = jobPersonResumeModel.WorkExperience;//工作经历
            labEducationExperience.Text = jobPersonResumeModel.EducationExperience;//教育经历
        }

        #endregion

        #region 获取期望薪资

        private string Get_labJobSalary(string strJobSalaryKey)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("SettingKey='" + strJobSalaryKey + "'").Tables[0];
            return dt.Rows[0]["SettingValue"].ToString();
        }

        #endregion

        #region 获取电子邮件

        private string Get_UserEmail(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["UserEmail"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    return newDT.Rows[0]["UserEmail"].ToString();
                }
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows[0]["CurrentResidence"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    return dt.Rows[0]["UserEmail"].ToString();
                }
            }
        }

        #endregion

        #region 获取当前居住地

        private string get_CurrentResidence(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["CurrentResidence"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                    System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                    return newDT.Rows[0]["CurrentResidence"].ToString();
                }
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows[0]["CurrentResidence"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    return dt.Rows[0]["CurrentResidence"].ToString();
                }
            }
        }

        #endregion

        #region 获取用户体重

        private string Get_UserWeight(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["UserWeight"].ToString() != "")
                {
                    return newDT.Rows[0]["UserWeight"].ToString();
                }
                else
                {
                    return "未提供";
                }
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows[0]["UserWeight"].ToString() != "")
                {
                    return dt.Rows[0]["UserWeight"].ToString();
                }
                else
                {
                    return "未提供";
                }
            }
        }

        #endregion

        #region 获取用户身高

        private string Get_UserHeight(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["UserHeight"].ToString() != "")
                {
                    return newDT.Rows[0]["UserHeight"].ToString();
                }
                else
                {
                    return "未提供";
                }
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows[0]["UserHeight"].ToString() != "")
                {
                    return dt.Rows[0]["UserHeight"].ToString();
                }
                else
                {
                    return "未提供";
                }
            }
        }

        #endregion

        #region 获取用户婚姻状态

        private string Get_MaritalStatus(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["MaritalStatus"].ToString() == "")
                {
                    return "未提供";
                }
                if (newDT.Rows[0]["MaritalStatus"].ToString() == "1")
                {
                    return "未婚";
                }
                else if (newDT.Rows[0]["MaritalStatus"].ToString() == "2")
                {
                    return "已婚";
                }
                else if (newDT.Rows[0]["MaritalStatus"].ToString() == "3")
                {
                    return "离异";
                }
                else if (newDT.Rows[0]["MaritalStatus"].ToString() == "4")
                {
                    return "丧偶";
                }
                else
                {
                    return "未提供";
                }

            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows[0]["MaritalStatus"].ToString() == "")
                {
                    return "未提供";
                }
                if (dt.Rows[0]["MaritalStatus"].ToString() == "1")
                {
                    return "未婚";
                }
                else if (dt.Rows[0]["MaritalStatus"].ToString() == "2")
                {
                    return "已婚";
                }
                else if (dt.Rows[0]["MaritalStatus"].ToString() == "3")
                {
                    return "离异";
                }
                else if (dt.Rows[0]["MaritalStatus"].ToString() == "4")
                {
                    return "丧偶";
                }
                else
                {
                    return "未提供";
                }
            }
        }

        #endregion

        #region 获取用户原籍

        private string Get_UserCountry(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["UserCountry"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    return newDT.Rows[0]["UserCountry"].ToString();
                }
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows[0]["UserCountry"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    return dt.Rows[0]["UserCountry"].ToString();
                }
            }

        }

        #endregion

        #region 获取用户电话

        private string Get_UserTel(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["UserMobileNO"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    return newDT.Rows[0]["UserMobileNO"].ToString();
                }
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows[0]["UserMobileNO"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    return dt.Rows[0]["UserMobileNO"].ToString();
                }
            }


        }

        #endregion

        #region 获取用户年龄

        private string Get_UserAge(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["UserBirthDay"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    int nCurrentyear = DateTime.Now.Year;
                    DateTime dateTime = DateTime.Parse(newDT.Rows[0]["UserBirthDay"].ToString());
                    return (nCurrentyear - dateTime.Year).ToString();
                }
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows[0]["UserBirthDay"].ToString() == "")
                {
                    return "未提供";
                }
                else
                {
                    int nCurrentyear = DateTime.Now.Year;
                    DateTime dateTime = DateTime.Parse(dt.Rows[0]["UserBirthDay"].ToString());
                    return (nCurrentyear - dateTime.Year).ToString();
                }
            }
        }

        #endregion

        #region 获取用户学历

        private string Get_UserEducationalBackground(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["UserEducationalBackground"].ToString() != "")
                {
                    int nUserEducationalBackgroundID = int.Parse(newDT.Rows[0]["UserEducationalBackground"].ToString());
                    zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
                    System.Data.DataTable dt01 = generalBasicSettingBLL.GetList("DisplayName='学历要求' and SettingKey='" + nUserEducationalBackgroundID + "'").Tables[0];
                    return dt01.Rows[0]["SettingValue"].ToString();
                }
                else
                {
                    return "未提供";
                }
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows[0]["UserEducationalBackground"].ToString() != "")
                {
                    int nUserEducationalBackgroundID = int.Parse(dt.Rows[0]["UserEducationalBackground"].ToString());
                    zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
                    System.Data.DataTable dt01 = generalBasicSettingBLL.GetList("DisplayName='学历要求' and SettingKey='" + nUserEducationalBackgroundID + "'").Tables[0];
                    return dt01.Rows[0]["SettingValue"].ToString();
                }
                else
                {
                    return "未提供";
                }
            }
        }

        #endregion

        #region 获取用户性别

        private string Get_UserSex(string strUserGUID)
        {
            if (ViewState["CoreUserDataTable"] != null)
            {
                System.Data.DataTable newDT = ViewState["CoreUserDataTable"] as System.Data.DataTable;
                if (newDT.Rows[0]["UserSex"].ToString() != "")
                {
                    if (newDT.Rows[0]["UserSex"].ToString() == "0")
                    {
                        return "女";
                    }
                    else
                    {
                        return "男";
                    }
                }
                else
                {
                    return "未提供";
                }
            }
            else
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["UserSex"].ToString() == "0")
                    {
                        return "女";
                    }
                    else
                    {
                        return "男";
                    }
                }
                else
                {
                    return "未知";
                }
            }
        }

        #endregion

        #region 获取用户名

        private string Get_UserName(string strUserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["UserNameCN"].ToString() == "")
                {
                    return "无";
                }
                else
                {
                    return dt.Rows[0]["UserNameCN"].ToString();
                }
            }
            else
            {
                return "未知";
            }
        }

        #endregion

        #region 根据用户的GUID获取简历表ID

        private int Get_JobPersonResumeID(string strGUID)
        {
            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            System.Data.DataTable dt = jobPersonResumeBLL.GetList("ResumeGuid='" + strGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["ResumeID"].ToString());
            }
            else
            {
                return -1;
            }
        }

        #endregion

        #region 简历下载按钮事件

        protected void imgBtnDownload_Click(object sender, ImageClickEventArgs e)
        {
            string strEnterpriseGUID = Get_EnterpriaseGUID(Request.Cookies["CurrentUserGUID"].Value);
            zlzw.Model.ResumeCollectionListModel resumeCollectionListModel = new zlzw.Model.ResumeCollectionListModel();
            resumeCollectionListModel.ResumeCollectionType = 0;//类型为企业简历收藏
            resumeCollectionListModel.ResumeGuid = new Guid(Request.QueryString["id"]);//当前简历GUID
            resumeCollectionListModel.EnterpriseGuid = new Guid(strEnterpriseGUID);//收藏企业的GUID
            resumeCollectionListModel.EnterpriseIsDel = 1;//企业标注为可显示
            resumeCollectionListModel.IsEnable = 1;
            resumeCollectionListModel.PublishDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

            #region 减去可下载简历数

            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strEnterpriseGUID + "'").Tables[0];
            zlzw.Model.GeneralEnterpriseModel generalEnterpriseModel = generalEnterpriseBLL.GetModel(int.Parse(dt.Rows[0]["EnterpriseID"].ToString()));
            if (generalEnterpriseModel.DownloadResume < 1)
            {
                FineUI.Alert.Show("您剩余的简历下载数不足，请联系我们的客服人员");
                return;
            }
            generalEnterpriseModel.DownloadResume = generalEnterpriseModel.DownloadResume - 1;
            generalEnterpriseModel.CreateDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();
            resumeCollectionListBLL.Add(resumeCollectionListModel);
            generalEnterpriseBLL.Update(generalEnterpriseModel);

            FineUI.Alert.Show("简历下载成功");

            #endregion

        }

        #endregion

        #region 根据用户ID获取企业ID

        private string Get_EnterpriaseGUID(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];

            return dt.Rows[0]["EnterpriseGuid"].ToString();
        }

        #endregion

        protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
        {
            imgBtnReturn.PostBackUrl = "AlreadyDownLoadResumeList.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value;
        }
    }
}