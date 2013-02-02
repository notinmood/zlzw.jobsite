﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Change_LoginPage();
            if (!IsPostBack)
            {
                Load_NewsList();//加载新闻列表
                Load_NonManageTypeList();//加载非管理类职位
                Load_ManageTypeList();//加载管理类职位
                Load_zzyList();//加载制造业职位
                Load_dscyList();//加载第三产业职位
                Load_ddcyTypeList();//家在第一产业职位
                Load_GeneralADList();//加载企业图片列表
                Load_EnterpriseServiceList();//加载企业服务列表
                Load_ParticipatingCompaniesList();//加载最近参会企业列表
                Load_FriendlyLinkList();//加载友情链接列表
                Load_JobEnterpriseJobPositionList();//加载紧急招聘列表
            }
        }

        #region 更改登陆窗口
        
        private void Change_LoginPage()
        {
            if (Request.Cookies["CurrentUserGUID"] == null && Request.Cookies["UserName"] == null)
            {
                return;
            }
            loginForm.Style["display"] = "none;";
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            strBuilder.Append("<table id='loginForm' width='213' border='0' cellpadding='0' cellspacing='0' style='height: 165px' runat='server'><tr id='row4'><td align='center'><table style='width:100%;'><tr><td style='height:20px;'></td></tr>");
            strBuilder.Append("<tr><td align='center'><span style='font-size:14px;'>欢迎用户 </span><span style='color:#FA7E00;font-weight:bold;font-size:18px;'>" + Request.Cookies["CurrentUserName"].Value + "</span> 您可以<td>");
            strBuilder.Append("</td></tr><tr><td style='height:30px;'></td></tr>");
            if (Get_UserType(Request.Cookies["CurrentUserGUID"].Value) == "1")
            {
                strBuilder.Append("<tr><td><table style='width:100%;'><tr><td style='width:50%;text-align:center;'>[<a href='EditPersonalInfo.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value + "' style='text-decoration:none;color:#093C7E;'>简历中心</a>]<br/><br/>[<a href='ActivityList.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value + "' id='linkBtnEdit' style='text-decoration:none;color:#093C7E;'>招 聘 会</a>]</td>");
                strBuilder.Append("<td style='width:50%;text-align:center;'>[<a href='JobSearchList.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value + "' style='text-decoration:none;color:#093C7E;'>职位搜索</a>]<br/><br/>[<a id='linkBtnCancel' href='#'style='text-decoration:none;color:#093C7E;'>退出登录</a>]</td></tr></table></td></tr></table></td></tr></table>");
            }
            else if(Get_UserType(Request.Cookies["CurrentUserGUID"].Value) == "2")
            {
                strBuilder.Append("<tr><td><table style='width:100%;'><tr><td style='width:50%;text-align:center;'>[<a href='JobPosting.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value + "' style='text-decoration:none;color:#093C7E;'>职位发布</a>]<br/><br/>[<a href='EditEnterpriseInfo.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value + "' id='linkBtnEdit' style='text-decoration:none;color:#093C7E;'>企业修改</a>]</td>");
                strBuilder.Append("<td style='width:50%;text-align:center;'>[<a href='ResumeSearchList.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value + "' style='text-decoration:none;color:#093C7E;'>简历搜索</a>]<br/><br/>[<a id='linkBtnCancel' href='#'style='text-decoration:none;color:#093C7E;'>退出登录</a>]</td></tr></table></td></tr></table></td></tr></table>");
            }
            labSuccessLogin.Text = strBuilder.ToString();
        }

        #endregion

        #region 根据用户GUID获取用户类型

        private string Get_UserType(string strUserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            DataTable dt = coreUserBLL.GetList("UserGuid='"+ strUserGUID +"'").Tables[0];

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["UserType"].ToString();
            }
            else
            {
                return "-1";
            }
        }

        #endregion

        #region 加载招聘会新闻列表

        private void Load_NewsList()
        {
            zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
            DataTable dt = generalActivityBLL.GetList(4, "CanUsable=1 and SpecialType=1", "PublishDate desc").Tables[0];

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        #endregion

        #region 加载企业服务列表

        private void Load_EnterpriseServiceList()
        {
            zlzw.BLL.EnterpriseServiceTypeListBLL enterpriseServiceTypeListBLL = new zlzw.BLL.EnterpriseServiceTypeListBLL();
            DataTable dt = enterpriseServiceTypeListBLL.GetList("IsEnable=1 order by OrderNumber asc").Tables[0];
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        #endregion

        #region 加载非管理类职位

        private void Load_NonManageTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='非管理' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                if (nCount > 15)
                {
                    if (nCount == 15)
                    {
                        labNonManageTypeOther.Text += dt.Rows[nCount]["SettingValue"].ToString();
                    }
                    else
                    {
                        labNonManageTypeOther.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
                    }
                }
                else
                {
                    labNonManageType.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
                }
            }
        }

        #endregion

        #region 加载管理类职位

        private void Load_ManageTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='管理' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                labManageType.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
            }
        }

        #endregion

        #region 加载第三产业职位

        private void Load_dscyList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='第三产业' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                if (nCount > 10)
                {
                    if (nCount == 12)
                    {
                        lablandscyOther.Text += dt.Rows[nCount]["SettingValue"].ToString();
                    }
                    else
                    {
                        lablandscyOther.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
                    }
                }
                else
                {
                    landscy.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
                }
            }
        }

        #endregion

        #region 加载第一产业职位

        private void Load_ddcyTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='第一产业' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                labddcyType.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
            }
        }

        #endregion

        #region 加载制造业职位

        private void Load_zzyList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("DisplayName='制造行业' and CanUsable=1").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                labzzyType.Text += dt.Rows[nCount]["SettingValue"].ToString() + "　";
            }
        }

        #endregion

        #region 加载企业图片列表

        private void Load_GeneralADList()
        {
            zlzw.BLL.GeneralADBLL generalADBLL = new zlzw.BLL.GeneralADBLL();
            DataTable dt = generalADBLL.GetList(8, "CanUsable=1 and ADStatus=1", "ADOrderNumber asc").Tables[0];

            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }

        #endregion

        #region 加载最近参会企业列表

        private void Load_ParticipatingCompaniesList()
        {
            zlzw.BLL.ParticipatingCompaniesListBLL participatingCompaniesListBLL = new zlzw.BLL.ParticipatingCompaniesListBLL();
            DataTable dt = participatingCompaniesListBLL.GetList("IsEnable=1 and IsShow=1 order by PublishDate desc").Tables[0];

            Repeater3.DataSource = dt;
            Repeater3.DataBind();
        }

        #endregion

        #region 加载友情链接图片

        private void Load_FriendlyLinkList()
        {
            zlzw.BLL.GeneralFriendlyLinkBLL generalFriendlyLinkBLL = new zlzw.BLL.GeneralFriendlyLinkBLL();
            DataTable dt = generalFriendlyLinkBLL.GetList("LinkType=0 and CanUsable=1 order by LinkOrderNumber asc").Tables[0];
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                if (nCount < 7)
                {
                    labLink.Text += "<a target='_blank' style='text-decoration:none;color:#6e6e6e;' href='" + dt.Rows[nCount]["LinkTargetUrl"].ToString() + "'>" + dt.Rows[nCount]["LinkTitle"].ToString() + "</a>　";
                }
                else if (nCount > 7 && nCount <= 14)
                {
                    labLink01.Text += "<a target='_blank' style='text-decoration:none;color:#6e6e6e;' href='" + dt.Rows[nCount]["LinkTargetUrl"].ToString() + "'>" + dt.Rows[nCount]["LinkTitle"].ToString() + "</a>　";
                }
                else if (nCount > 14 && nCount <= 21)
                {
                    labLink02.Text += "<a target='_blank' style='text-decoration:none;color:#6e6e6e;' href='" + dt.Rows[nCount]["LinkTargetUrl"].ToString() + "'>" + dt.Rows[nCount]["LinkTitle"].ToString() + "</a>　";
                }
                else if (nCount > 21 && nCount <= 28)
                {
                    labLink03.Text += "<a target='_blank' style='text-decoration:none;color:#6e6e6e;' href='" + dt.Rows[nCount]["LinkTargetUrl"].ToString() + "'>" + dt.Rows[nCount]["LinkTitle"].ToString() + "</a>　";
                }
                else if (nCount > 28 && nCount <= 35)
                {
                    labLink04.Text += "<a target='_blank' style='text-decoration:none;color:#6e6e6e;' href='" + dt.Rows[nCount]["LinkTargetUrl"].ToString() + "'>" + dt.Rows[nCount]["LinkTitle"].ToString() + "</a>　";
                }
            }
        }

        #endregion

        #region 加载紧急招聘列表

        private void Load_JobEnterpriseJobPositionList()
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            DataTable dt = jobEnterpriseJobPositionBLL.GetList("CanUsable=1 and SpecialType=1 order by CreateDate desc").Tables[0];

            Repeater4.DataSource = dt;
            Repeater4.DataBind();
        }

        #endregion

        #region 招聘会行绑定事件

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labNewsTitle = (Label)e.Item.FindControl("labNewsTitle");

                labNewsTitle.Text = "<span style='color:#FA7A00;'> ★ </span><a href='ActivityInfo.aspx?id=" + drv["ActivityGuid"].ToString() + "' style='color:#6e6e6e;text-decoration:none;'>" + Set_ActivityTitle_Length(drv["ActivityTitle"].ToString()) + "</a>";
            }
        }

        #endregion

        #region 辅助函数

        private string Set_ActivityTitle_Length(string strTitle)
        {
            if (strTitle.Length >= 24)
            {
                return strTitle.Substring(0, 24) + "...";
            }
            else
            {
                return strTitle;
            }
        }

        #endregion

        #region 企业服务列表绑定

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labEnterpriseService = (Label)e.Item.FindControl("labEnterpriseService");
                if (drv["IsHot"].ToString() == "1")
                {
                    labEnterpriseService.Text = "<a href='EnterpriseService.aspx?id=" + drv["EnterpriseServiceTypeGUID"].ToString() + "' style='text-decoration:none;color:#093C7E;'>" + drv["EnterpriseServiceTypeName"].ToString() + "</a>" + "<img src='image/img21.png' alt=''/>";
                }
                else
                {
                    labEnterpriseService.Text = "<a href='EnterpriseService.aspx?id=" + drv["EnterpriseServiceTypeGUID"].ToString() + "' style='text-decoration:none;color:#093C7E;'>" + drv["EnterpriseServiceTypeName"].ToString() + "</a>";
                } 
            }
        }

        #endregion

        #region 图片链接加载

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labGeneralAD = (Label)e.Item.FindControl("labGeneralAD");

                labGeneralAD.Text = "<a href='#'><img src='" + drv["ADImagePath"].ToString().Split('~')[1] + "' style=border:0px;' alt='" + drv["ADName"].ToString() + "' /></a>";
            }
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

        #region 最近参会企业行绑定

        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labParticipatingCompaniesList = (Label)e.Item.FindControl("labParticipatingCompaniesList");

                labParticipatingCompaniesList.Text = "<p style='line-height: 25px; '><img src='image/img7.png' width='11' height='12' />" + drv["ParticipatingCompaniesContent"].ToString() + "</span></p>";
            }
        }

        #endregion

        #region 紧急招聘行绑定事件

        protected void Repeater4_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labJobTitle = (Label)e.Item.FindControl("labJobTitle");
                Label labAdd = (Label)e.Item.FindControl("labAdd");
                Label labXueLi = (Label)e.Item.FindControl("labXueLi");
                Label labTel = (Label)e.Item.FindControl("labTel");
                labJobTitle.Text = "<a href='#' target='_blank' style='text-decoration:none;color:#6e6e6e;'>" + drv["EnterpriseName"].ToString() + "</a>";
                labAdd.Text = "<a href='#'  style='text-decoration:none;color:#6e6e6e;' target='_blank'>" + drv["JobWorkPlaceNames"].ToString() + "</a>";
                labXueLi.Text = "<a href='#' style='text-decoration:none;color:#6e6e6e;'>" + drv["JobPositionKind"].ToString() + "</a>";
                labTel.Text = "<span style='text-decoration:none;color:#6e6e6e;'>" + drv["ContactTelephone"].ToString() + "</span>";
            }
        }

        #endregion

        #region 查询按钮事件响应

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string strGangWei = Request.Params["txbJobPositionKinds"];//岗位类别
            string strHangYe = Request.Params["txbJobFeildKinds"];//行业类别
            string strWorkAreas = Request.Params["txbWorkAreas"];//工作地区
            string strSearchKey = Request.Params["txbSearchKey"];//关键字
            string strSex = drpSex.SelectedValue;//性别
            string strShiSu = drpShiSu.SelectedValue;//食宿
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            strBuilder.Append("CanUsable=1");
            if (strGangWei != "")
            {
                strBuilder.Append(" and JobPositionKind like '%" + strGangWei + "%'");
            }
            if (strHangYe != "")
            {
                strBuilder.Append(" and JobFeildKinds like '%" + strHangYe + "%'");
            }
            if (strWorkAreas != "")
            {
                strBuilder.Append(" and JobWorkPlaceNames like '%" + strWorkAreas + "%'");
            }
            if (strSex != "-1")
            {
                strBuilder.Append(" and NeedSex like '%" + strSex + "%'");
            }

            if (strSearchKey != "")
            {
                strBuilder.Append(" or (JobPositionDesc like '%" + strSearchKey + "%' or EnterpriseName like '%" + strSearchKey + "%' or JobPositionName like '%" + strSearchKey + "%')");
            }
            Session["DefaultSearchWhere"] = strBuilder.ToString();
            Response.Redirect("JobSearchList.aspx?id=" + Request.Cookies["CurrentUserGUID"].Value);
        }

        #endregion
    }
}