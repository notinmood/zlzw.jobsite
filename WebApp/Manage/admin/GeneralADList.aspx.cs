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
    public partial class GeneralADList : System.Web.UI.Page
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
                grid1.RecordCount = Get_GeneralADListTotalCount();//获取总页数
                #region 广告列表绑定

                GeneralADList_BindGrid();

                #endregion
                Window1.Title = "添加用户";
                btnAdd.OnClientClick = Window1.GetShowReference("AddGeneralAD.aspx?Type=0", "添加广告") + "return false;";
                btnDel.OnClientClick = grid1.GetNoSelectionAlertReference("请选择要删除的广告!");
            }
        }


        #region 页面方法

        protected string GetMyValue(object value)
        {
            return (Convert.ToInt32(value) * 100).ToString();
        }

        protected string GetEditUrl(object value)
        {
            return "javascript:" + Window1.GetShowReference("AddGeneralAD.aspx?Type=1&value=" + value, "编辑广告");
            //return String.Format("javascript:box.{0}_show(\"AddEnterpriseAfficheList.aspx?value={1}\", \"This is title\");", Window1.ClientID, value);
        }

        #endregion

        #region 数据绑定

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        private int Get_GeneralADListTotalCount()
        {
            zlzw.BLL.GeneralADBLL generalADBLL = new zlzw.BLL.GeneralADBLL();
            DataTable dt = generalADBLL.GetList("CanUsable=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        private void GeneralADList_BindGrid()
        {
            zlzw.BLL.GeneralADBLL generalADBLL = new zlzw.BLL.GeneralADBLL();
            DataTable dt = generalADBLL.GetList(grid1.PageSize, grid1.PageIndex + 1, "*", "UpdateDate", 0, "desc", "CanUsable=1").Tables[0];

            grid1.DataSource = dt;
            grid1.DataBind();
        }

        #endregion

        #region 分页事件

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;

            GeneralADList_BindGrid();
        }


        #endregion

        #region 行绑定事件

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            DataRowView dr = e.DataItem as DataRowView;
            if (dr != null)
            {
                string strEnterpriseGUID = dr["EnterpriseGuid"].ToString();
                e.Values[0] = Get_EnterpriseName(strEnterpriseGUID);
                //string strADType = dr["ADType"].ToString();
                //if (strADType == "1")
                //{
                //    e.Values[2] = "图片类型";
                //}
                //else if(strADType == "2")
                //{
                //    e.Values[2] = "脚本类型";
                //}
                //else
                //{
                //    e.Values[2] = "未知类型";
                //}
            }
        }

        #endregion

        #region 获取企业名称

        private string Get_EnterpriseName(string strEnterpriseGUID)
        {
            if (strEnterpriseGUID == "")
            {
                return "";
            }
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='"+ strEnterpriseGUID +"'").Tables[0];

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

                zlzw.BLL.GeneralADBLL generalADBLL = new zlzw.BLL.GeneralADBLL();
                DataTable dt = generalADBLL.GetList("ADGuid='" + strSelectID + "'").Tables[0];
                zlzw.Model.GeneralADModel generalADModel = generalADBLL.GetModel(int.Parse(dt.Rows[0]["ADGuid"].ToString()));
                generalADModel.CanUsable = 0;
                generalADBLL.Update(generalADModel);
                GeneralADList_BindGrid();

                #endregion
            }
            else
            {
                return;
            }
        }

        #endregion

        #region 辅助函数

        #endregion
    }
}