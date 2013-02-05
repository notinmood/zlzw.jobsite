using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.EnterpriseInfo
{
    public partial class EnterpriseInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    string strJobID = Request.QueryString["id"];//职位ID
                    string strEnterpriseID = Request.QueryString["type"];//企业ID
                    Load_JobList(strEnterpriseID);//加载职位列表
                    Load_EnterpriseDesc(strEnterpriseID);//加载企业简介
                    Load_JobInfo(strJobID);//加载职位信息
                }
                catch (Exception exp)
                {
                    Response.Redirect("../default.aspx");
                }
            }
        }

        #region 加载职位列表

        private void Load_JobList(string strJobGUID)
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("EnterpriseKey='"+ strJobGUID +"' order by CreateDate desc").Tables[0];
            labBanner.Text = dt.Rows[0]["EnterpriseName"].ToString();
            txbTitle.Text = dt.Rows[0]["EnterpriseName"].ToString() + "-" + dt.Rows[0]["JobPositionName"].ToString();
            labEnterpriseContent.Text = Get_EnterpriseDesc(strJobGUID);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        #endregion

        #region 职位列表加载
        
        private void Load_JobInfo(string strID)
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("jobPositionGuid='"+ strID +"'").Tables[0];
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            strBuilder.Append("<table border='0' style='width:91%;'>");
                strBuilder.Append("<tr>");
                    strBuilder.Append("<td>");
                    strBuilder.Append("<span style='color:#052C65;'>岗位名称:</span> " + dt.Rows[0]["JobPositionName"].ToString());
                    strBuilder.Append("</td>");
                    strBuilder.Append("<td>");
                    strBuilder.Append("<span style='color:#052C65;'>岗位类别: </span>" + dt.Rows[0]["JobPositionKind"].ToString());
                    strBuilder.Append("</td>");
                    strBuilder.Append("<td>");
                    strBuilder.Append("<span style='color:#052C65;'>食宿福利: </span>" + Get_IsHopeRoomAndBoard(dt.Rows[0]["HopeRoomAndBoard"].ToString()));
                    strBuilder.Append("</td>");
                strBuilder.Append("</tr>");
                strBuilder.Append("<tr>");
                    strBuilder.Append("<td>");
                    strBuilder.Append("<span style='color:#052C65;'>性别要求: </span>" + Get_UserSex(dt.Rows[0]["NeedSex"].ToString()));
                    strBuilder.Append("</td>");
                    strBuilder.Append("<td>");
                    strBuilder.Append("<span style='color:#052C65;'>年龄要求: </span>" + dt.Rows[0]["NeedAge"].ToString());
                    strBuilder.Append("</td>");
                    strBuilder.Append("<td>");
                    strBuilder.Append("<span style='color:#052C65;'>最低学历: </span>" + Get_NeedEducation(dt.Rows[0]["NeedEducation"].ToString()));
                    strBuilder.Append("</td>");
                strBuilder.Append("</tr>");
                strBuilder.Append("<tr>");
                    strBuilder.Append("<td>");
                    strBuilder.Append("<span style='color:#052C65;'>综合薪资: </span>" + dt.Rows[0]["ComprehensivePayroll"].ToString());
                    strBuilder.Append("</td>");
                    strBuilder.Append("<td>");
                    strBuilder.Append("<span style='color:#052C65;'>工作性质: </span>" + Get_JobWorkType(dt.Rows[0]["JobWorkType"].ToString()));
                    strBuilder.Append("</td>");
                    strBuilder.Append("<td>");
                    strBuilder.Append("<span style='color:#052C65;'>发布日期: </span>" + DateTime.Parse(dt.Rows[0]["CreateDate"].ToString()).ToString("yyyy年MM月dd"));
                    strBuilder.Append("</td>");
                strBuilder.Append("</tr>");
                strBuilder.Append("<tr colspan='3'>");
                    strBuilder.Append("<td colspan='3'>");
                    strBuilder.Append("<p><span style='color:#052C65;'>职位描述:</span></p>");
                        strBuilder.Append(dt.Rows[0]["JobPositionDesc"].ToString());
                    strBuilder.Append("</tr>");
                strBuilder.Append("</tr>");
                labJobList.Text = strBuilder.ToString();
                labEnterpriseAdd.Text = dt.Rows[0]["JobWorkPlaceNames"].ToString();//公司地址
                labPhone.Text = dt.Rows[0]["ContactTelephone"].ToString();//联系电话
                labEmail.Text = dt.Rows[0]["ContactMail"].ToString();//电子邮件
                labLxr.Text = dt.Rows[0]["ContactPerson"].ToString();//联系人
        }

        #endregion

        #region 获取企业简介

        private string Get_EnterpriseDesc(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strEnterpriseGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["EnterpriseDescription"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion

        #region 获取企业简介&联系方式

        private void Load_EnterpriseDesc(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strEnterpriseGUID + "'").Tables[0];
            labEnterpriseContent.Text = dt.Rows[0]["EnterpriseDescription"].ToString();

            //labEnterpriseAdd.Text = dt.Rows[0]["JobWorkPlaceNames"].ToString();//公司地址
            //labPhone.Text = dt.Rows[0]["ContactTelephone"].ToString();//联系电话
            //labEmail.Text = dt.Rows[0]["ContactMail"].ToString();//电子邮件
            //labLxr.Text = dt.Rows[0]["ContactPerson"].ToString();//联系人
        }

        #endregion

        #region 类型转换

        /// <summary>
        /// 是否食宿
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        private string Get_IsHopeRoomAndBoard(string strType)
        {
            if (strType == "1")
            {
                return "是";
            }
            else
            {
                return "否";
            }
        }

        /// <summary>
        /// 性别要求
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        private string Get_UserSex(string strType)
        {
            if (strType == "0")
            {
                return "女";
            }
            else if (strType == "1")
            {
                return "男";
            }
            else if (strType == "2")
            {
                return "不限";
            }
            else
            {
                return "未知";
            }
        }

        /// <summary>
        /// 工作性质
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        private string Get_JobWorkType(string strType)
        {
            if (strType == "0")
            {
                return "全职";
            }
            else if (strType == "1")
            {
                return "兼职";
            }
            else
            {
                return "未知";
            }
        }

        /// <summary>
        /// 获取最低学历
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        private string Get_NeedEducation(string strType)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("CanUsable=1 and SettingCategory='NeedEducation' and SettingKey='" + strType + "'").Tables[0];
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

        #region 职位列表行绑定事件加载

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labJobTitle = (Label)e.Item.FindControl("labJobTitle");

                //labJobTitle.Text = "<a class='jobList' href='#' onclick=\"javascript:art.dialog.open('JobList.html?id=" + drv["PartnersJobID"].ToString() + "', {width: 577, height: 371})\"; style='text-decoration:none;'>" + drv["PostInfo"].ToString() + "</a>";
                labJobTitle.Text = "<a href='EnterpriseInfo.aspx?type=" + drv["EnterpriseKey"].ToString() + "&id=" + drv["JobPositionGuid"].ToString() + "' style='color:#093C7E;text-decoration:none;'>" + drv["JobPositionName"].ToString() + "</a>";
            }
        }

        #endregion
    }
}