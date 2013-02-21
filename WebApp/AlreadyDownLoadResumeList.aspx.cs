using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class AlreadyDownLoadResumeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //AspNetPager1.RecordCount = Get_RecordCount();
                if (Request.Cookies["CurrentUserGUID"] == null)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    Load_RecordCount(Request.Cookies["CurrentUserGUID"].Value);//获取总页数
                    Load_DataList(Request.Cookies["CurrentUserGUID"].Value);//获取数据列表
                }

            }
        }

        #region 获取总页数

        private void Load_RecordCount(string strUserGUID)
        {
            if (Request.QueryString["type"] == "1")
            {
                string strEnterpriseGUID = Get_EnterpriseGUID(strUserGUID);//企业GUID
                zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();//获取当前企业所下载的简历
                System.Data.DataTable dt = resumeCollectionListBLL.GetList("ResumeCollectionType=1 and EnterpriseGuid='" + strEnterpriseGUID + "' and EnterpriseIsDel=1 and IsEnable=1").Tables[0];
                AspNetPager1.RecordCount = dt.Rows.Count;
                tdName.InnerText = "职位名称";
                tdqiuzhi.InnerText = "年龄";
                tdPublishDate.InnerText = "投递日期";
                labDataIsNull.Text = "暂无求职者简历";
                titleName.Text = "查看投递简历";
            }
            else
            {
                string strEnterpriseGUID = Get_EnterpriseGUID(strUserGUID);//企业GUID
                zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();//获取当前企业所下载的简历
                System.Data.DataTable dt = resumeCollectionListBLL.GetList("ResumeCollectionType=0 and EnterpriseGuid='" + strEnterpriseGUID + "' and EnterpriseIsDel=1 and IsEnable=1").Tables[0];
                AspNetPager1.RecordCount = dt.Rows.Count;
                tdName.InnerText = "求职者";
                tdqiuzhi.InnerText = "求职意向";
                tdPublishDate.InnerText = "下载日期";
                labDataIsNull.Text = "暂无下载简历";
                titleName.Text = "查看已下载简历";
            }
        }

        #endregion

        #region 数据绑定

        private void Load_DataList(string strUserGUID)
        {
            if (Request.QueryString["type"] == "1")
            {
                string strEnterpriseGUID = Get_EnterpriseGUID(strUserGUID);//企业GUID
                zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();//获取当前企业所下载的简历
                int nPageIndex = AspNetPager1.CurrentPageIndex;
                int nPageSize = AspNetPager1.PageSize = 15;
                System.Data.DataTable dt = resumeCollectionListBLL.GetList(nPageSize, nPageIndex, "*", "PublishDate", 0, "desc", "ResumeCollectionType=1 and EnterpriseGuid='" + strEnterpriseGUID + "' and EnterpriseIsDel=1 and IsEnable=1").Tables[0];
                if (dt.Rows.Count == 0)
                {
                    labDataIsNull.Visible = true;
                }
                else
                {
                    labDataIsNull.Visible = false;
                }
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                string strEnterpriseGUID = Get_EnterpriseGUID(strUserGUID);//企业GUID
                zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();//获取当前企业所下载的简历
                int nPageIndex = AspNetPager1.CurrentPageIndex;
                int nPageSize = AspNetPager1.PageSize = 15;
                System.Data.DataTable dt = resumeCollectionListBLL.GetList(nPageSize, nPageIndex, "*", "PublishDate", 0, "desc", "ResumeCollectionType=0 and EnterpriseGuid='" + strEnterpriseGUID + "' and EnterpriseIsDel=1 and IsEnable=1").Tables[0];
                if (dt.Rows.Count == 0)
                {
                    labDataIsNull.Visible = true;
                }
                else
                {
                    labDataIsNull.Visible = false;
                }
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        #endregion

        #region 根据用户GUID获取企业GUID

        private string Get_EnterpriseGUID(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strUserGUID + "'").Tables[0];
            return dt.Rows[0]["EnterpriseGuid"].ToString();
        }

        #endregion

        #region 行绑定事件

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labUserName = (Label)e.Item.FindControl("labUserName");//求职者姓名
                Label labYiXiang = (Label)e.Item.FindControl("labYiXiang");//求职意向
                Label labSex = (Label)e.Item.FindControl("labSex");//用户姓名
                Label labXueLi = (Label)e.Item.FindControl("labXueLi");//学历
                Label labTel = (Label)e.Item.FindControl("labTel");//联系电话
                Label labDownLoadDate = (Label)e.Item.FindControl("labDownLoadDate");//下载日期
                Label labDel = (Label)e.Item.FindControl("labDel");
                LinkButton libkBtnDel = (LinkButton)e.Item.FindControl("libkBtnDel");//
                if (Request.QueryString["type"] == "1")
                {
                    labUserName.Text = Get_Jobname(drv["ResumeGuid"].ToString());//申请职位名称
                }
                else
                {
                    labUserName.Text = Get_UserName(drv["ResumeGuid"].ToString());//求职者姓名
                }
                if (Request.QueryString["type"] == "1")
                {
                    labYiXiang.Text = Get_UserAge(drv["Other01"].ToString());//年龄
                }
                else
                {
                    labYiXiang.Text = Get_HopeJob(drv["ResumeGuid"].ToString());//求职意向
                }
                if (Request.QueryString["type"] == "1")
                {
                    labSex.Text = Get_UserSex01(drv["Other01"].ToString());//用户性别
                }
                else
                {
                    labSex.Text = Get_UserSex(drv["ResumeGuid"].ToString());//用户性别
                }
                if (Request.QueryString["type"] == "1")
                {
                    labXueLi.Text = Get_UserEducation(drv["Other01"].ToString());//用户学历
                }
                else
                {
                    labXueLi.Text = Get_UserEducation(drv["ResumeGuid"].ToString());//用户学历
                }
                if (Request.QueryString["type"] == "1")
                {
                    labTel.Text = Get_UserTel(drv["Other01"].ToString());//电话
                }
                else
                {
                    labTel.Text = Get_UserTel(drv["ResumeGuid"].ToString());//电话
                }
                if (Request.QueryString["type"] == "1")
                {
                    labDel.Text = "<a class='linkResumeID' target='_blank' href='ResumeSearchInfo.aspx?id=" + Get_JianLiGUID(drv["Other01"].ToString()) + "' style='font-size:14px;font-weight:bold;color:#F97D00; text-decoration:none;'>查看简历</a>";
                }
                else
                {
                    labDel.Text = "<a class='linkResumeID' target='_blank' href='ResumeSearchInfo.aspx?id=" + drv["ResumeGuid"].ToString() + "' style='font-size:14px;font-weight:bold;color:#F97D00; text-decoration:none;'>查看简历</a>";
                }
                labDownLoadDate.Text = DateTime.Parse(drv["PublishDate"].ToString()).ToString("yyyy年MM月dd");//下载日期
                //labDel.Text = "<a class='linkResumeID' target='_blank' href='ResumeSearchInfo.aspx?id=" + drv["ResumeGuid"].ToString() + "' style='font-size:14px;font-weight:bold;color:#F97D00; text-decoration:none;'>查看简历</a>";
                libkBtnDel.CommandName = drv["ResumeCollectionID"].ToString();//简历ID
            }
        }

        #endregion

        #region 分页事件

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Load_DataList(Request.Cookies["CurrentUserGUID"].Value);
        }

        #endregion

        #region 根据用户GUID获取简历GUID

        private string Get_JianLiGUID(string strUserGUID)
        {
            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            System.Data.DataTable dt = jobPersonResumeBLL.GetList("OwnerUserKey='" + strUserGUID + "'").Tables[0];

            return dt.Rows[0]["ResumeGuid"].ToString();
        }

        #endregion

        #region 获取职位名称

        private string Get_Jobname(string strResumeGUID)
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("JobPositionGuid='"+ strResumeGUID +"'").Tables[0];

            return dt.Rows[0]["JobPositionName"].ToString();
        }

        #endregion

        #region 获取用户名称

        private string Get_UserName(string strResumeGUID)
        {
            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            System.Data.DataTable dt01 = jobPersonResumeBLL.GetList("ResumeGuid='" + strResumeGUID + "'").Tables[0];
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + dt01.Rows[0]["OwnerUserKey"].ToString() + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["UserNameCN"].ToString();
            }
            else
            {
                return "未知";
            }

        }

        #endregion

        #region 获取用户年龄

        private string Get_UserAge(string strUserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='"+ strUserGUID +"'").Tables[0];
            int nBirthdayYear = DateTime.Parse(dt.Rows[0]["UserBirthday"].ToString()).Year;//用户出生年
            int nCrrentYear = DateTime.Now.Year;//当前年

            return (nCrrentYear - nBirthdayYear).ToString();
        }

        #endregion

        #region 获取求职意向

        private string Get_HopeJob(string strUserGUID)
        {
            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            System.Data.DataTable dt = jobPersonResumeBLL.GetList("ResumeGuid='"+ strUserGUID +"'").Tables[0];
            string strHopeJob = dt.Rows[0]["JobPositionKinds"].ToString().Split('-')[1] + " / " + dt.Rows[0]["JobFeildKinds"].ToString().Split('-')[1];

            return strHopeJob;
        }

        #endregion

        #region 获取用户性别(求职者)

        private string Get_UserSex01(string strResumeGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt01 = coreUserBLL.GetList("UserGuid='" + strResumeGUID + "'").Tables[0];
            if (dt01.Rows.Count > 0)
            {
                if (dt01.Rows[0]["UserSex"].ToString() == "0")
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

        #endregion

        #region 获取用户性别

        private string Get_UserSex(string strUserGUID)
        {
            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            System.Data.DataTable dt = jobPersonResumeBLL.GetList("ResumeGuid='" + strUserGUID + "'").Tables[0];

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["UserSex"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion

        #region 获取用户学历

        private string Get_UserEducation(string strResumeGUID)
        {
            if (Request.QueryString["type"] == "1")
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt01 = coreUserBLL.GetList("UserGuid='" + strResumeGUID + "'").Tables[0];
                zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
                System.Data.DataTable dt02 = generalBasicSettingBLL.GetList("SettingCategory='NeedEducation' and SettingKey='" + dt01.Rows[0]["UserEducationalBackground"].ToString() + "'").Tables[0];
                if (dt02.Rows.Count > 0)
                {
                    return dt02.Rows[0]["SettingValue"].ToString();
                }
                else
                {
                    return "未知";
                }
            }
            else
            {
                zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
                System.Data.DataTable dt = jobPersonResumeBLL.GetList("ResumeGuid='" + strResumeGUID + "'").Tables[0];
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt01 = coreUserBLL.GetList("UserGuid='" + dt.Rows[0]["OwnerUserKey"].ToString() + "'").Tables[0];
                zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
                System.Data.DataTable dt02 = generalBasicSettingBLL.GetList("SettingCategory='NeedEducation' and SettingKey='" + dt01.Rows[0]["UserEducationalBackground"].ToString() + "'").Tables[0];
                if (dt02.Rows.Count > 0)
                {
                    return dt02.Rows[0]["SettingValue"].ToString();
                }
                else
                {
                    return "未知";
                }
            }
        }

        #endregion

        #region 获取用户电话

        private string Get_UserTel(string strResumeGUID)
        {
            if (Request.QueryString["type"] == "1")
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt01 = coreUserBLL.GetList("UserGuid='" + strResumeGUID + "'").Tables[0];
                if (dt01.Rows.Count > 0)
                {
                    return dt01.Rows[0]["UserMobileNO"].ToString();
                }
                else
                {
                    return "未知";
                }
            }
            else
            {
                zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
                System.Data.DataTable dt = jobPersonResumeBLL.GetList("ResumeGuid='" + strResumeGUID + "'").Tables[0];
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                System.Data.DataTable dt01 = coreUserBLL.GetList("UserGuid='" + dt.Rows[0]["OwnerUserKey"].ToString() + "'").Tables[0];
                if (dt01.Rows.Count > 0)
                {
                    return dt01.Rows[0]["UserMobileNO"].ToString();
                }
                else
                {
                    return "未知";
                }
            }
        }

        #endregion

        #region 删除按钮事件

        protected void libkBtnDel_Click(object sender, EventArgs e)
        {
            LinkButton linkBtnDel = sender as LinkButton;
            zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();
            zlzw.Model.ResumeCollectionListModel resumeCollectionListModel = resumeCollectionListBLL.GetModel(int.Parse(linkBtnDel.CommandName));
            resumeCollectionListModel.EnterpriseIsDel = 0;
            resumeCollectionListBLL.Update(resumeCollectionListModel);
            Load_DataList(Request.Cookies["CurrentUserGUID"].Value);
            
        }

        #endregion
    }
}