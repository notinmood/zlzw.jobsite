using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class EmergencyRecruitmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_EmergencyRecruitmentList();//加载紧急招聘列表
            }
            //AspNetPager1.RecordCount = Get_EmergencyRecruitmentListRecordCount();//获取紧急招聘总页数
        }
        //private int Get_EmergencyRecruitmentListRecordCount()
        //{
        //    zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
        //    System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("CanUsable=1 and SpecialType=1 order by CreateDate desc").Tables[0];

        //    return dt.Rows.Count;
        //}

        #region 加载招聘会列表

        private void Load_EmergencyRecruitmentList()
        {
            //int nPageIndex = AspNetPager1.CurrentPageIndex;
            //int nPageSize = AspNetPager1.PageSize = 15;
            //zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            //System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList(nPageSize, nPageIndex, "*", "CreateDate", 0, "desc", "CanUsable=1 and SpecialType=1").Tables[0];

            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();
            #region 更改后的紧急招聘

            zlzw.BLL.jjzpListBLL jjzpListBLL = new zlzw.BLL.jjzpListBLL();
            System.Data.DataTable dt = jjzpListBLL.GetList(1,"IsEnable=1","PublishDate desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                labActivityTitle.Text = dt.Rows[0]["jjzpContent"].ToString();
            }
            else
            {
                labActivityTitle.Text = "";
            }

            #endregion
        }

        #endregion

        #region 分页事件

        //protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        //{
        //    Load_EmergencyRecruitmentList();
        //}

        #endregion

        #region 招聘会行绑定事件

        //protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
        //    if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
        //    {
        //        System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
        //        Label labActivityTitle = (Label)e.Item.FindControl("labActivityTitle");

        //        labActivityTitle.Text = "<span style='color:#FA7A00;'> ★ </span><a href='EnterpriseInfo/EnterpriseInfo.aspx?type="+ drv["EnterpriseKey"].ToString() +"&id=" + drv["JobPositionGuid"].ToString() + "' style='color:#6e6e6e;text-decoration:none;'>" + drv["EnterpriseName"].ToString() + " - <span style='color:#093C7E;'>" + drv["JobPositionName"].ToString() + "</span></a><div style='float:right; padding-right:20px;'>" + Set_DateFormat(drv["CreateDate"].ToString()) + "</div>";
        //    }
        //}

        #endregion

        #region 日期格式转换

        private string Set_DateFormat(string strDate)
        {
            DateTime dateTime = DateTime.Parse(strDate);
            return dateTime.ToString("yyyy年MM月dd日");
        }

        #endregion
    }
}