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
    public partial class GeneralFriendlyLink : System.Web.UI.Page
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
                grid1.RecordCount = Get_GeneralFriendlyListTotalCount();//获取总页数
                #region 友情链接列表绑定

                GeneralFriendlyList_BindGrid();

                #endregion
                Window1.Title = "添加友情链接";
                btnAdd.OnClientClick = Window1.GetShowReference("AddGeneralFriendlyLink.aspx?Type=0", "添加友情链接") + "return false;";
                btnDel.OnClientClick = grid1.GetNoSelectionAlertReference("请选择要删除的友情链接!");
            }
        }


        #region 页面方法

        protected string GetMyValue(object value)
        {
            return (Convert.ToInt32(value) * 100).ToString();
        }

        protected string GetEditUrl(object value)
        {
            return "javascript:" + Window1.GetShowReference("AddGeneralFriendlyLink.aspx?Type=1&value=" + value, "编辑友情链接");
            //return String.Format("javascript:box.{0}_show(\"AddEnterpriseAfficheList.aspx?value={1}\", \"This is title\");", Window1.ClientID, value);
        }

        #endregion

        #region 数据绑定

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        private int Get_GeneralFriendlyListTotalCount()
        {
            zlzw.BLL.GeneralFriendlyLinkBLL generalFriendlyLinkBLL = new zlzw.BLL.GeneralFriendlyLinkBLL();
            DataTable dt = generalFriendlyLinkBLL.GetList("CanUsable=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        private void GeneralFriendlyList_BindGrid()
        {
            zlzw.BLL.GeneralFriendlyLinkBLL generalFriendlyLinkBLL = new zlzw.BLL.GeneralFriendlyLinkBLL();
            DataTable dt = generalFriendlyLinkBLL.GetList(grid1.PageSize, grid1.PageIndex + 1, "*", "PublishDate", 0, "desc", "CanUsable=1").Tables[0];

            grid1.DataSource = dt;
            grid1.DataBind();
        }



        #endregion

        #region 分页事件

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;

            GeneralFriendlyList_BindGrid();
        }


        #endregion

        #region 行绑定事件

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            DataRowView dr = e.DataItem as DataRowView;
            if (dr != null)
            {
                string strLinkType = dr["LinkType"].ToString();
                if (strLinkType == "0")
                {
                    e.Values[1] = "文字链接";
                }
                else
                {
                    e.Values[1] = "图片链接";
                }
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

                zlzw.BLL.GeneralFriendlyLinkBLL generalFriendlyLinkBLL = new zlzw.BLL.GeneralFriendlyLinkBLL();
                DataTable dt = generalFriendlyLinkBLL.GetList("LinkGuid='" + strSelectID + "'").Tables[0];
                zlzw.Model.GeneralFriendlyLinkModel generalFriendlyLinkModel = generalFriendlyLinkBLL.GetModel(int.Parse(dt.Rows[0]["LinkID"].ToString()));
                generalFriendlyLinkModel.CanUsable = 0;
                generalFriendlyLinkBLL.Update(generalFriendlyLinkModel);
                GeneralFriendlyList_BindGrid();

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