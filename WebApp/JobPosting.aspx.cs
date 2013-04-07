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
    public partial class JobPosting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Get_IsEnablePublishJob(Request.QueryString["id"]) == "0")
            {
                Alert.Show("当前账号暂不允许发布职位");
                return;
            }
            if (!IsPostBack)
            {
                try
                {
                    Get_UserIsEmergencyRecruitment(Get_EnterpriseGUID(Request.QueryString["id"]));//获取当前企业是否具有发布紧急招聘的权限
                    Load_SpecialTypeList();//加载职位发布类型
                    Load_JobPositionKindsTypeList();//加载职位类别
                    //Load_JobFeildKinds();//加载期望行业
                    Load_UserEducationalBackground();//学历加载
                    Load_JobWorkTypeList();//加载工作性质
                    Load_DefaultValue(Get_EnterpriseGUID(Request.QueryString["id"]));//加载默认值
                    labReceive.InnerText = Get_ReceiveCount(Request.Cookies["CurrentUserGUID"].Value) + " ";
                    labView02.Text = "<a style='font-size:14px;color:#fff;font-weight:bold;text-decoration:none;' target='_blank' href='AlreadyDownLoadResumeList.aspx?id=" + Request.QueryString["id"] + "&type=1'>查看简历</a>";
                    labView01.Text = " " + "<a style='font-size:14px;color:#fff;font-weight:bold;text-decoration:none;' target='_blank' href='AlreadyDownLoadResumeList.aspx?id=" + Request.QueryString["id"] + "&type=0'>查看简历</a>";
                    labJobPublish.InnerText = " " + Get_EnterpriseJobPublishCount(Request.Cookies["CurrentUserGUID"].Value) + " ";//发布职位数量
                    labDownloadCount.InnerText = " " + Get_DownLoadCount(Request.Cookies["CurrentUserGUID"].Value) + " ";
                    labAlreadyDownload.InnerText = " " + Get_AlreadyDownLoadCount(Request.Cookies["CurrentUserGUID"].Value) + " ";//已下载的简历数
                }
                catch (Exception exp)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        #region 获取是否允许发布职位

        private string Get_IsEnablePublishJob(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("UserGuid='"+ strUserGUID +"'").Tables[0];
            string strEnterpriseGUID = dt.Rows[0]["EnterpriseGuid"].ToString();
            if (dt.Rows[0]["IsEnablePublishJob"].ToString() == "0")
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        #endregion

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

        #region 加载职位发布类型

        private void Load_SpecialTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='SpecialType' and CanUsable=1 order by OrderNumber asc").Tables[0];
            drpSpecialType.DataTextField = "SettingValue";
            drpSpecialType.DataValueField = "SettingKey";

            drpSpecialType.DataSource = dt;
            drpSpecialType.DataBind();
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

        #region 加载期望行业

        private void Load_JobFeildKinds()
        {
            //zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            //DataTable dt = generalBasicSettingBLL.GetList("DisplayName='" + drpJobFeildKindsType.SelectedValue + "'").Tables[0];

            //drpJobFeildKinds.DataTextField = "SettingValue";
            //drpJobFeildKinds.DataValueField = "SettingValue";

            //drpJobFeildKinds.DataSource = dt;
            //drpJobFeildKinds.DataBind();
        }

        #endregion

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

        #region 加载工作性质

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

        #region 加载所需默认值

        private void Load_DefaultValue(string strUserGUID)
        {
            txbJobWorkPlaceNames.Text = GetEnterpriseAddres(strUserGUID);//默认公司地址
        }

        #endregion

        #region 获取企业地址

        private string GetEnterpriseAddres(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("UserGuid='"+ strUserGUID +"'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["PrincipleAddress"].ToString();
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region 获取当前企业是否具有发布紧急招聘的权限

        private bool Get_UserIsEmergencyRecruitment(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strUserGUID + "'").Tables[0];

            if (dt.Rows[0]["IsEmergencyRecruitment"].ToString() != "0")
            {
                drpSpecialType.Enabled = true;
                return true;
            }
            else
            {
                drpSpecialType.Enabled = false;
                return false;
            }
        }

        #endregion

        #region 获取企业名称

        private string Get_EnterpriseName(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strUserGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["CompanyName"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion

        #region 获取企业GUID

        private string Get_EnterpriseGUID(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["EnterpriseGuid"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion

        #region 发布职位按钮事件

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Get_IsEnablePublishJob(Request.QueryString["id"]) == "0")
                {
                    Alert.Show("当前账号暂不允许发布职位");
                    return;
                }
                string strUserGUID = Request.QueryString["id"];//用户ID
                strUserGUID = Get_EnterpriaseGUID(strUserGUID);//获取企业GUID
                zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = new zlzw.Model.JobEnterpriseJobPositionModel();
                jobEnterpriseJobPositionModel.JobPositionName = Request.Form["txbJobPositionName"];//岗位名称
                //jobEnterpriseJobPositionModel.JobPositionKind = drpJobPositionKindsType.SelectedValue + "-" + Request.Params["drpJobPositionKinds"];//岗位类别
                jobEnterpriseJobPositionModel.JobPositionKind = Get_CurrentValue(Request.Params["txbJobPositionKinds"]) + "-" + Request.Params["txbJobPositionKinds"];//岗位类别
                jobEnterpriseJobPositionModel.JobWorkPlaceNames = Request.Form["txbJobWorkPlaceNames"];//工作地点
                jobEnterpriseJobPositionModel.ComprehensivePayroll = txbComprehensivePayroll.Text;//综合薪资
                jobEnterpriseJobPositionModel.HopeRoomAndBoard = int.Parse(drpHopeRoomAndBoard.SelectedValue);//是否提供食宿
                jobEnterpriseJobPositionModel.NeedSex = int.Parse(drpNeedSex.SelectedValue);//性别要求
                jobEnterpriseJobPositionModel.NeedAge = Request.Form["txbNeedAge"];//年龄要求
                jobEnterpriseJobPositionModel.NeedEducation = int.Parse(drpUserEducationalBackground.SelectedValue);//学历要求
                jobEnterpriseJobPositionModel.ContactTelephone = Request.Form["txbContactTelephone"];//联系人电话
                jobEnterpriseJobPositionModel.ContactPerson = Request.Form["txbContactPerson"];//联系人
                jobEnterpriseJobPositionModel.ContactMail = Request.Form["txbContactMail"];//联系人邮箱
                jobEnterpriseJobPositionModel.JobPositionDesc = Request.Form["txbJobPositionDesc"];//职位描述
                jobEnterpriseJobPositionModel.EnterpriseName = Get_EnterpriseName(strUserGUID);//所属企业名称
                jobEnterpriseJobPositionModel.EnterpriseKey = strUserGUID;//所属企业GUID
                jobEnterpriseJobPositionModel.CreateUserKey = strUserGUID;//发布人GUID
                jobEnterpriseJobPositionModel.CreateDate = DateTime.Now;//创建日期
                jobEnterpriseJobPositionModel.UpdateDate = DateTime.Now;//修改日期
                jobEnterpriseJobPositionModel.IsEnableEmergencyRecruitment = 0;//不显示在首页的紧急发布中
                if (drpSpecialType.Enabled == true)
                {
                    jobEnterpriseJobPositionModel.SpecialType = int.Parse(drpSpecialType.SelectedValue);
                }
                else
                {
                    jobEnterpriseJobPositionModel.SpecialType = 0;//普通招聘
                }
                if (Request.Form["txbInterviewTime"].Length > 0)
                {
                    jobEnterpriseJobPositionModel.InterviewTime = Request.Form["txbInterviewTime"];//面试时间
                }
                if (drpSpecialType.Enabled)
                {
                    jobEnterpriseJobPositionModel.SpecialType = 1;//职位为紧急招聘
                }
                else
                {
                    jobEnterpriseJobPositionModel.SpecialType = 0;//职位为普通职位
                }
                jobEnterpriseJobPositionModel.InterviewAddress = Request.Form["txbInterviewAddress"];//面试地点
                jobEnterpriseJobPositionModel.JobWorkType = int.Parse(drpJobWorkType.SelectedValue);//工作性质
                jobEnterpriseJobPositionModel.CanUsable = 1;//
                jobEnterpriseJobPositionModel.JobPositionStatus = 1;
                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                jobEnterpriseJobPositionBLL.Add(jobEnterpriseJobPositionModel);
                Set_FormValue();
                Alert.Show("职位发布成功");
                //跳转到企业登录成功页面
            }
            catch (Exception exp)
            {
                Alert.Show("职位发布失败，请稍后重试");
            }


        }

        #endregion

        #region 获取当前职位类别的大类

        private string Get_CurrentValue(string strValue)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingValue='" + strValue + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["DisplayName"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion

        #region 根据用户ID获取企业ID

        private string Get_EnterpriaseGUID(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("UserGuid='"+ strUserGUID +"'").Tables[0];

            return dt.Rows[0]["EnterpriseGuid"].ToString();
        }

        #endregion

        #region 清空表单值

        private void Set_FormValue()
        {
            txbJobPositionName.Text = "";
            txbNeedAge.Text = "";
            txbContactTelephone.Text = "";
            txbContactPerson.Text = "";
            txbContactMail.Text = "";
            txbJobPositionDesc.Text = "";
        }

        #endregion
    }
}