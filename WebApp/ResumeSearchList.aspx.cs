using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ResumeSearchList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //AspNetPager1.RecordCount = Get_RecordCount();
            }
            
        }

        #region 分页事件

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Get_RecordCount();
            Load_SearchResultList();
        }

        #endregion

        #region 获取查询结果总页数

        private void Get_RecordCount()
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
                strBuilder.Append(" and JobPositionKinds like '%" + strGangWei + "%'");
            }
            if (strHangYe != "")
            {
                strBuilder.Append(" and JobFeildKinds like '%" + strHangYe + "%'");
            }
            if(strWorkAreas != "")
            {
                strBuilder.Append(" and JobWorkPlaceNames like '%" + strWorkAreas + "%'");
            }
            if (strShiSu != "-1" && strShiSu != "0")
            {
                strBuilder.Append(" and HopeRoomAndBoard like '%" + strShiSu + "%'");
            }
            if (strSex != "-1")
            {
                strBuilder.Append(" and UserSex like '%" + strSex + "%'");
            }
            if (strSearchKey != "")
            {
                strBuilder.Append("or (HopeJob like '%" + strSearchKey + "%' or PersonalSkills like '%" + strSearchKey + "%')");
            }

            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            System.Data.DataTable dt = jobPersonResumeBLL.GetList(strBuilder.ToString()).Tables[0];
            AspNetPager1.RecordCount = dt.Rows.Count;
        }

        #endregion

        #region 获取查询结果列表

        private void Load_SearchResultList()
        {
            string strGangWei = Request.Params["txbJobPositionKinds"];//岗位类别
            string strHangYe = Request.Params["txbJobFeildKinds"];//行业类别
            string strWorkAreas = Request.Params["txbWorkAreas"];//工作地区
            string strSearchKey = Request.Params["txbSearchKey"];//关键字
            string strSex = drpSex.SelectedValue;//性别
            string strShiSu = drpShiSu.SelectedValue;//食宿
            int nPageIndex = AspNetPager1.CurrentPageIndex;
            int nPageSize = AspNetPager1.PageSize = 15;

            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            strBuilder.Append("CanUsable=1");
            if (strGangWei != "")
            {
                strBuilder.Append(" and JobPositionKinds like '%" + strGangWei + "%'");
            }
            if (strHangYe != "")
            {
                strBuilder.Append(" and JobFeildKinds like '%" + strHangYe + "%'");
            }
            if (strWorkAreas != "")
            {
                strBuilder.Append(" and JobWorkPlaceNames like '%" + strWorkAreas + "%'");
            }
            if (strShiSu != "-1" && strShiSu != "0")
            {
                strBuilder.Append(" and HopeRoomAndBoard like '%" + strShiSu + "%'");
            }
            if (strSex != "-1")
            {
                strBuilder.Append(" and UserSex like '%" + strSex + "%'");
            }
            if (strSearchKey != "")
            {
                strBuilder.Append("or (HopeJob like '%" + strSearchKey + "%' or PersonalSkills like '%" + strSearchKey + "%')");
            }

            zlzw.BLL.JobPersonResumeBLL jobPersonResumeBLL = new zlzw.BLL.JobPersonResumeBLL();
            System.Data.DataTable dt = jobPersonResumeBLL.GetList(nPageSize, nPageIndex, "*", "UpdateDate", 0, "desc", strBuilder.ToString()).Tables[0];

            if (dt.Rows.Count == 0)
            {
                labDataIsNull.Visible = true;
            }
            else if (dt.Rows.Count > 0)
            {
                labDataIsNull.Visible = false;
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        #endregion

        #region 查询按钮事件

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Get_RecordCount();//总数
            Load_SearchResultList();//查询
        }

        #endregion

        #region 行绑定事件

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labJobName = (Label)e.Item.FindControl("labJobName");
                Label labShiSu = (Label)e.Item.FindControl("labShiSu");
                Label labHangye = (Label)e.Item.FindControl("labHangye");
                Label labGangwei = (Label)e.Item.FindControl("labGangwei");
                Label labSex = (Label)e.Item.FindControl("labSex");
                Label labAge = (Label)e.Item.FindControl("labAge");
                Label labPublishDate = (Label)e.Item.FindControl("labPublishDate");
                Label labView = (Label)e.Item.FindControl("labView");

                labJobName.Text = Get_UserName(drv["OwnerUserKey"].ToString());//求职者姓名
                labShiSu.Text = Get_HopeRoomAndBoard(drv["HopeRoomAndBoard"].ToString());//期望食宿
                labHangye.Text = drv["JobFeildKinds"].ToString().Split('-')[1];//期望行业
                labGangwei.Text = drv["JobPositionKinds"].ToString().Split('-')[1];//期望岗位
                labSex.Text = drv["UserSex"].ToString();//性别
                labAge.Text = Get_UserAge(drv["OwnerUserKey"].ToString());//年龄
                labPublishDate.Text = DateTime.Parse(drv["UpdateDate"].ToString()).ToString("yyyy年MM月dd");
                labView.Text = "<a class='linkResumeID' target='_blank' href='ResumeSearchInfo.aspx?id=" + drv["OwnerUserKey"].ToString() + "' style='font-size:14px;font-weight:bold;color:#F97D00; text-decoration:none;'>查看简历</a>";
            }
        }

        #endregion

        #region 格式转换

        #region 获取求职者姓名

        private string Get_UserName(string strUserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
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

        private string Get_UserAge(string struserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + struserGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                DateTime userDate = DateTime.Parse(dt.Rows[0]["UserBirthDay"].ToString());

                return (DateTime.Now.Year - userDate.Year).ToString();
            }
            else
            {
                return "未知";
            }
        }

        private string Get_UserSex(string strUserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["UserSex"].ToString() == "1")
                {
                    return "男";
                }
                else
                {
                    return "女";
                }
            }
            else
            {
                return "未知";
            }
        }

        private string Get_HopeRoomAndBoard(string strType)
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

        #endregion
    }
}