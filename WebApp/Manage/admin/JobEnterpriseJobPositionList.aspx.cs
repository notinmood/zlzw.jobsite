using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;

namespace WebApp.Manage.admin
{
    public partial class JobEnterpriseJobPositionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserID"] == null)
                {
                    Response.Write("<script type='text/javascript'>window.parent.location='login.aspx'</script>");
                    return;
                }
                grid1.RecordCount = Get_JobEnterpriseJobPositionListTotalCount();//获取总页数
                #region 企业发布岗位列表绑定

                JobEnterpriseJobPositionList_BindGrid();

                #endregion
                Window1.Title = "添加岗位";
                btnAdd.OnClientClick = Window1.GetShowReference("AddJobEnterpriseJobPosition.aspx?Type=0", "添加岗位") + "return false;";
                btnDel.OnClientClick = grid1.GetNoSelectionAlertReference("请选择要删除的岗位!");
            }
        }


        #region 页面方法

        protected string GetMyValue(object value)
        {
            return (Convert.ToInt32(value) * 100).ToString();
        }

        protected string GetEditUrl(object value)
        {
            return "javascript:" + Window1.GetShowReference("AddJobEnterpriseJobPosition.aspx?Type=1&value=" + value, "编辑岗位");
            //return String.Format("javascript:box.{0}_show(\"AddEnterpriseAfficheList.aspx?value={1}\", \"This is title\");", Window1.ClientID, value);
        }

        #endregion

        #region 数据绑定

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        private int Get_JobEnterpriseJobPositionListTotalCount()
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            DataTable dt = jobEnterpriseJobPositionBLL.GetList("CanUsable=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        private void JobEnterpriseJobPositionList_BindGrid()
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            DataTable dt = jobEnterpriseJobPositionBLL.GetList(grid1.PageSize, grid1.PageIndex + 1, "*", "CreateDate", 0, "desc", "CanUsable=1").Tables[0];

            grid1.DataSource = dt;
            grid1.DataBind();
        }



        #endregion

        #region 分页事件

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;

            JobEnterpriseJobPositionList_BindGrid();
        }


        #endregion

        #region 行绑定事件

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            DataRowView dr = e.DataItem as DataRowView;
            if (dr != null)
            {
                string strEnterpriseKey = dr["EnterpriseKey"].ToString();
                e.Values[0] = Get_EnterpriseName(strEnterpriseKey);

                string strJobWorkType = dr["JobWorkType"].ToString();
                e.Values[3] = Get_JobWorkType(strJobWorkType);

                string strJobPositionStatus = dr["JobPositionStatus"].ToString();
                e.Values[5] = Get_JobPositionStatus(strJobPositionStatus);

                string strJobSalary = dr["JobSalary"].ToString();
                e.Values[8] = Get_JobSalary(strJobSalary);

            }
        }

        #endregion

        #region 删除按钮事件

        protected void btnDel_Click(object sender, EventArgs e)
        {
            if (grid1.SelectedRowIndexArray != null && grid1.SelectedRowIndexArray.Length > 0)
            {
                string strSelectID = "0";
                for (int i = 0, count = grid1.SelectedRowIndexArray.Length; i < count; i++)
                {
                    int rowIndex = grid1.SelectedRowIndexArray[i];
                    foreach (object key in grid1.DataKeys[rowIndex])
                    {
                        strSelectID = key.ToString();
                    }
                }
                #region 删除逻辑

                zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
                DataTable dt = jobEnterpriseJobPositionBLL.GetList("JobPositionGuid='" + strSelectID + "'").Tables[0];
                zlzw.Model.JobEnterpriseJobPositionModel jobEnterpriseJobPositionModel = jobEnterpriseJobPositionBLL.GetModel(int.Parse(dt.Rows[0]["JobPositionID"].ToString()));
                jobEnterpriseJobPositionModel.CanUsable = 0;
                jobEnterpriseJobPositionBLL.Update(jobEnterpriseJobPositionModel);
                JobEnterpriseJobPositionList_BindGrid();

                #endregion
            }
            else
            {
                return;
            }
        }

        #endregion

        #region 辅助函数

        #region 获取企业名称

        private string Get_EnterpriseName(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='"+ strEnterpriseGUID +"'").Tables[0];
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

        #region 获取工作性质

        private string Get_JobWorkType(string strID)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobWorkType' and SettingKey="+strID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SettingValue"].ToString();
            }
            else
            {
                return "未知类型";
            }
        }

        #endregion

        #region 获取月薪

        private string Get_JobSalary(string strID)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobSalary' and SettingKey=" + strID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SettingValue"].ToString();
            }
            else
            {
                return "未知月薪";
            }
        }

        #endregion

        #region 获取岗位状态

        private string Get_JobPositionStatus(string strID)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='JobPositionStatus' and SettingKey=" + strID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SettingValue"].ToString();
            }
            else
            {
                return "未知类型";
            }
        }

        #endregion

        #endregion
    }
}