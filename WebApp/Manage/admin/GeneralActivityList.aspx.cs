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
    public partial class GeneralActivityList : System.Web.UI.Page
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
                grid1.RecordCount = Get_GeneralActivityListTotalCount();//获取总页数
                #region 管理员列表绑定

                GeneralActivityList_BindGrid();

                #endregion
                Window1.Title = "添加招聘会";
                btnAdd.OnClientClick = Window1.GetShowReference("AddGeneralActivity.aspx?Type=0", "添加招聘会") + "return false;";
                btnDel.OnClientClick = grid1.GetNoSelectionAlertReference("请选择要删除的招聘会!");
            }
        }

        #region 页面方法

        protected string GetMyValue(object value)
        {
            return (Convert.ToInt32(value) * 100).ToString();
        }

        protected string GetEditUrl(object value)
        {
            return "javascript:" + Window1.GetShowReference("AddGeneralActivity.aspx?Type=1&value=" + value, "编辑招聘会");
            //return String.Format("javascript:box.{0}_show(\"AddEnterpriseAfficheList.aspx?value={1}\", \"This is title\");", Window1.ClientID, value);
        }

        #endregion

        #region 数据绑定

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        private int Get_GeneralActivityListTotalCount()
        {
            zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
            DataTable dt = generalActivityBLL.GetList("CanUsable=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        private void GeneralActivityList_BindGrid()
        {
            zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
            DataTable dt = generalActivityBLL.GetList(grid1.PageSize, grid1.PageIndex + 1, "*", "PublishDate", 0, "desc", "CanUsable=1").Tables[0];

            grid1.DataSource = dt;
            grid1.DataBind();
        }



        #endregion

        #region 分页事件

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;

            GeneralActivityList_BindGrid();
        }


        #endregion

        #region 行绑定事件

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            //DataRowView dr = e.DataItem as DataRowView;
            //if (dr != null)
            //{
            //    string strUserType = dr["UserType"].ToString();
            //    e.Values[0] = Get_UserTypeName(strUserType);
            //}
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

                zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
                DataTable dt = generalActivityBLL.GetList("ActivityGuid='" + strSelectID + "'").Tables[0];
                zlzw.Model.GeneralActivityModel generalActivityModel = generalActivityBLL.GetModel(int.Parse(dt.Rows[0]["ActivityID"].ToString()));
                generalActivityModel.CanUsable = 0;
                generalActivityBLL.Update(generalActivityModel);
                GeneralActivityList_BindGrid();

                #endregion
            }
            else
            {
                return;
            }
        }

        #endregion
    }
}