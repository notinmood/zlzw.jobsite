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
    public partial class GeneralEnterpriseList : System.Web.UI.Page
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
                grid1.RecordCount = Get_GeneralEnterpriseListTotalCount();//获取总页数
                #region 企业列表绑定

                GeneralEnterpriseList_BindGrid();

                #endregion
                Window1.Title = "添加用户";
                btnAdd.OnClientClick = Window1.GetShowReference("AddGeneralEnterprise.aspx?Type=0", "添加企业信息") + "return false;";
                btnDel.OnClientClick = grid1.GetNoSelectionAlertReference("请选择要删除的企业信息!");
            }
        }

        #region 页面方法

        protected string GetMyValue(object value)
        {
            return (Convert.ToInt32(value) * 100).ToString();
        }

        protected string GetEditUrl(object value)
        {
            return "javascript:" + Window1.GetShowReference("AddGeneralEnterprise.aspx?Type=1&value=" + value, "编辑企业信息");
            //return String.Format("javascript:box.{0}_show(\"AddEnterpriseAfficheList.aspx?value={1}\", \"This is title\");", Window1.ClientID, value);
        }

        #endregion

        #region 数据绑定

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        private int Get_GeneralEnterpriseListTotalCount()
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("CanUsable=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        private void GeneralEnterpriseList_BindGrid()
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList(grid1.PageSize, grid1.PageIndex + 1, "CompanyName,EnterpriseGuid,BusinessType,IndustryKey,PrincipleAddress,Telephone,CreateDate,CanUsable", "CreateDate", 0, "desc", "CanUsable=1").Tables[0];

            grid1.DataSource = dt;
            grid1.DataBind();
        }



        #endregion

        #region 分页事件

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;

            GeneralEnterpriseList_BindGrid();
        }


        #endregion

        #region 行绑定事件

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            //DataRowView dr = e.DataItem as DataRowView;
            //if (dr != null)
            //{
            //    string strBusinessType = dr["BusinessType"].ToString();
            //    e.Values[1] = Get_EnterpriseTypeName(strBusinessType);

            //    string strIndustryKey = dr["IndustryKey"].ToString();
            //    e.Values[1] = Get_IndustrySectorName(strIndustryKey);
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

                zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
                DataTable dt = generalEnterpriseBLL.GetList("UserGuid='" + strSelectID + "'").Tables[0];
                zlzw.Model.GeneralEnterpriseModel generalEnterpriseModel = generalEnterpriseBLL.GetModel(int.Parse(dt.Rows[0]["UserID"].ToString()));
                generalEnterpriseModel.CanUsable = 0;
                generalEnterpriseBLL.Update(generalEnterpriseModel);
                GeneralEnterpriseList_BindGrid();

                #endregion
            }
            else
            {
                return;
            }
        }

        #endregion

        #region 辅助函数

        #region 获取企业性质中文名称

        private string Get_EnterpriseTypeName(string strEnterpriseType)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingKey='" + strEnterpriseType + "'").Tables[0];
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

        #region 获取企业所属类别中文名称

        private string Get_IndustrySectorName(string strIndustryKey)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingKey='" + strIndustryKey + "'").Tables[0];
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

        #endregion
    }
}