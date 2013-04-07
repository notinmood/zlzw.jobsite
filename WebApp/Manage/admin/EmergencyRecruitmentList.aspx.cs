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
    public partial class EmergencyRecruitmentList : System.Web.UI.Page
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
                grid1.RecordCount = Get_EmergencyRecruitmentListTotalCount();//获取总页数
                #region 紧急招聘列表绑定

                EmergencyRecruitmentList_BindGrid();

                #endregion
                Window1.Title = "添加紧急招聘";
                btnadd.OnClientClick = Window1.GetShowReference("AddEmergencyRecruitment.aspx?Type=0", "添加管理员") + "return false;";
                btnDel.OnClientClick = grid1.GetNoSelectionAlertReference("请选择要删除的管理员!");
            }
        }

        #region 页面方法

        protected string GetMyValue(object value)
        {
            return (Convert.ToInt32(value) * 100).ToString();
        }

        protected string GetEditUrl(object value)
        {
            return "javascript:" + Window1.GetShowReference("AddEmergencyRecruitment.aspx?Type=1&value=" + value, "编辑紧急招聘信息");
            //return String.Format("javascript:box.{0}_show(\"AddEnterpriseAfficheList.aspx?value={1}\", \"This is title\");", Window1.ClientID, value);
        }

        #endregion

        #region 数据绑定

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        private int Get_EmergencyRecruitmentListTotalCount()
        {
            zlzw.BLL.jjzpListBLL jjzpListBLL = new zlzw.BLL.jjzpListBLL();
            DataTable dt = jjzpListBLL.GetList("IsEnable=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        private void EmergencyRecruitmentList_BindGrid()
        {
            zlzw.BLL.jjzpListBLL jjzpListBLL = new zlzw.BLL.jjzpListBLL();
            DataTable dt = jjzpListBLL.GetList(grid1.PageSize, grid1.PageIndex + 1, "*", "PublishDate", 0, "desc", "IsEnable=1").Tables[0];

            grid1.DataSource = dt;
            grid1.DataBind();
        }



        #endregion

        #region 分页事件

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;

            EmergencyRecruitmentList_BindGrid();
        }


        #endregion

        #region 行绑定事件

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            DataRowView dr = e.DataItem as DataRowView;
            if (dr != null)
            {
                string strCreateUserKey = dr["PublishID"].ToString();
                e.Values[0] = Get_UserName(strCreateUserKey);
            }
        }

        #endregion

        #region 删除按钮事件

        protected void btndel_click(object sender, EventArgs e)
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

                zlzw.BLL.jjzpListBLL jjzpListBLL = new zlzw.BLL.jjzpListBLL();
                System.Data.DataTable dt = jjzpListBLL.GetList("SysGUID='" + strSelectID + "'").Tables[0];
                zlzw.Model.jjzpListModel jjzpListModel = jjzpListBLL.GetModel(int.Parse(dt.Rows[0]["JobPositionID"].ToString()));
                jjzpListModel.IsEnable = 0;
                jjzpListBLL.Update(jjzpListModel);
                EmergencyRecruitmentList_BindGrid();

                #endregion
            }
            else
            {
                return;
            }
        }

        #endregion

        #region 获取用户名称

        private string Get_UserName(string strUserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["UserName"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion

    }
}