using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ParticipatingCompaniesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_ParticipatingCompaniesList();//加载参会企业列表
            }
            //AspNetPager1.RecordCount = Get_ParticipatingCompaniesListRecordCount();//获取参会企业总页数
        }

        private int Get_ParticipatingCompaniesListRecordCount()
        {
            zlzw.BLL.ParticipatingCompaniesListBLL participatingCompaniesListBLL = new zlzw.BLL.ParticipatingCompaniesListBLL();
            System.Data.DataTable dt = participatingCompaniesListBLL.GetList("IsEnable=1 and IsShow=1").Tables[0];

            return dt.Rows.Count;
        }

        #region 加载参会企业列表

        private void Load_ParticipatingCompaniesList()
        {
            //int nPageIndex = AspNetPager1.CurrentPageIndex;
            //int nPageSize = AspNetPager1.PageSize = 10;
            zlzw.BLL.ParticipatingCompaniesListBLL participatingCompaniesListBLL = new zlzw.BLL.ParticipatingCompaniesListBLL();
            //System.Data.DataTable dt = participatingCompaniesListBLL.GetList(nPageSize, nPageIndex, "*", "PublishDate", 0, "desc", "IsEnable=1 and IsShow=1").Tables[0];
            System.Data.DataTable dt = participatingCompaniesListBLL.GetList(1, "IsEnable=1 and IsShow=1", "PublishDate desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                labContent.Text = dt.Rows[0]["ParticipatingCompaniesContent"].ToString();
            }
            else
            {
                labContent.Text = "";
            }
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();
        }

        #endregion

        #region 分页事件

        //protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        //{
        //    Load_ParticipatingCompaniesList();
        //}

        #endregion

        #region 参会企业行绑定事件

        //protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
        //    if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
        //    {
        //        System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
        //        Label labTitle = (Label)e.Item.FindControl("labTitle");
        //        Label labPubnlishDate = (Label)e.Item.FindControl("labPubnlishDate");
        //        Label lanContent = (Label)e.Item.FindControl("labContent");

        //        labTitle.Text = "　<a href='ParticipatingCompaniesInfo.aspx?id=" + drv["ParticipatingCompaniesGUID"].ToString() + "' style='color:#093C7E; text-decoration:none;font-weight:bold;'>" + Get_EnterpriseName(drv["EnterpriseGuid"].ToString()) + "</a>";
        //        labPubnlishDate.Text = "<span style='color:#093C7E;'>" + Set_DateFormat(drv["PublishDate"].ToString()) + "</span>";
        //        lanContent.Text = Get_ContentLength(drv["ParticipatingCompaniesContent"].ToString());
        //    }
        //}

        #endregion

        #region 获取内容长度

        private string Get_ContentLength(string strContent)
        {
            if (strContent.Length >= 200)
            {
                return strContent.Substring(0,200) + "...";
            }
            else
            {
                return strContent;
            }
        }

        #endregion

        #region 获取企业名称

        private string Get_EnterpriseName(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("CanUsable=1 and EnterpriseGuid='" + strEnterpriseGUID + "'").Tables[0];
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

        #region 日期格式转换

        private string Set_DateFormat(string strDate)
        {
            DateTime dateTime = DateTime.Parse(strDate);
            return dateTime.ToString("yyyy年MM月dd日");
        }

        #endregion
    }
}