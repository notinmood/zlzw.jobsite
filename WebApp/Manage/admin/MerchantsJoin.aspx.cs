﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class MerchantsJoin : System.Web.UI.Page
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
                grid1.RecordCount = Get_MerchantsJoinListTotalCount();//获取总页数
                #region 招商加盟列表绑定

                MerchantsJoinList_BindGrid();

                #endregion
                Window1.Title = "添加招商加盟";
                btnAdd.OnClientClick = Window1.GetShowReference("AddMerchantsJoin.aspx?Type=0", "添加招商加盟") + "return false;";
                btnDel.OnClientClick = grid1.GetNoSelectionAlertReference("请选择要删除的招商加盟!");
            }
        }


        #region 页面方法

        protected string GetMyValue(object value)
        {
            return (Convert.ToInt32(value) * 100).ToString();
        }

        protected string GetEditUrl(object value)
        {
            return "javascript:" + Window1.GetShowReference("AddMerchantsJoin.aspx?Type=1&value=" + value, "编辑招商加盟");
            //return String.Format("javascript:box.{0}_show(\"AddEnterpriseAfficheList.aspx?value={1}\", \"This is title\");", Window1.ClientID, value);
        }

        #endregion

        #region 数据绑定

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        private int Get_MerchantsJoinListTotalCount()
        {
            zlzw.BLL.MerchantsJoinListBLL merchantsJoinListBLL = new zlzw.BLL.MerchantsJoinListBLL();
            System.Data.DataTable dt = merchantsJoinListBLL.GetList("IsEnable=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        private void MerchantsJoinList_BindGrid()
        {
            zlzw.BLL.MerchantsJoinListBLL merchantsJoinListBLL = new zlzw.BLL.MerchantsJoinListBLL();
            System.Data.DataTable dt = merchantsJoinListBLL.GetList(grid1.PageSize, grid1.PageIndex + 1, "*", "PublisDate", 0, "desc", "IsEnable=1").Tables[0];

            grid1.DataSource = dt;
            grid1.DataBind();
        }



        #endregion

        #region 分页事件

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;

            MerchantsJoinList_BindGrid();
        }


        #endregion

        #region 行绑定事件

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            //System.Data.DataRowView dr = e.DataItem as System.Data.DataRowView;
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

                zlzw.BLL.MerchantsJoinListBLL merchantsJoinListBLL = new zlzw.BLL.MerchantsJoinListBLL();
                System.Data.DataTable dt = merchantsJoinListBLL.GetList("MerchantsJoinGUID='" + strSelectID + "'").Tables[0];
                zlzw.Model.MerchantsJoinListModel merchantsJoinListModel = merchantsJoinListBLL.GetModel(int.Parse(dt.Rows[0]["MerchantsJoinID"].ToString()));
                merchantsJoinListModel.IsEnable = 0;
                merchantsJoinListBLL.Update(merchantsJoinListModel);
                MerchantsJoinList_BindGrid();

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