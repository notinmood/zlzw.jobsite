﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;

namespace WebApp.Manage.admin
{
    public partial class ExchangeCornerList : System.Web.UI.Page
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
                grid1.RecordCount = Get_ExchangeCornerListTotalCount();//获取总页数
                #region 交流园地类型列表绑定

                ExchangeCornerList_BindGrid();

                #endregion
                Window1.Title = "添加交流园地类型";
                btnAdd.OnClientClick = Window1.GetShowReference("AddExchangeCorner.aspx?Type=0", "添加交流园地类型") + "return false;";
                btnDel.OnClientClick = grid1.GetNoSelectionAlertReference("请选择要删除的交流园地类型!");
            }
        }

        #region 页面方法

        protected string GetMyValue(object value)
        {
            return (Convert.ToInt32(value) * 100).ToString();
        }

        protected string GetEditUrl(object value)
        {
            return "javascript:" + Window1.GetShowReference("AddExchangeCorner.aspx?Type=1&value=" + value, "编辑交流园地类型");
            //return String.Format("javascript:box.{0}_show(\"AddEnterpriseAfficheList.aspx?value={1}\", \"This is title\");", Window1.ClientID, value);
        }

        #endregion

        #region 数据绑定

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        private int Get_ExchangeCornerListTotalCount()
        {
            zlzw.BLL.ExchangeCornerListBLL exchangeCornerListBLL = new zlzw.BLL.ExchangeCornerListBLL();
            DataTable dt = exchangeCornerListBLL.GetList("IsEnable=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows.Count;
            }
            else
            {
                return 0;
            }
        }

        private void ExchangeCornerList_BindGrid()
        {
            zlzw.BLL.ExchangeCornerListBLL exchangeCornerListBLL = new zlzw.BLL.ExchangeCornerListBLL();
            DataTable dt = exchangeCornerListBLL.GetList(grid1.PageSize, grid1.PageIndex + 1, "*", "PublishDate", 0, "asc", "IsEnable=1").Tables[0];

            grid1.DataSource = dt;
            grid1.DataBind();
        }



        #endregion

        #region 分页事件

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;

            ExchangeCornerList_BindGrid();
        }


        #endregion

        #region 行绑定事件

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            DataRowView dr = e.DataItem as DataRowView;
            if (dr != null)
            {
                string strType = dr["ExchangeCornerTypeKey"].ToString();
                e.Values[1] = Get_TypeName(strType);

                string strExchangeCornerFileSize = dr["ExchangeCornerFileSize"].ToString();
                if (strExchangeCornerFileSize != "")
                e.Values[3] = Get_FileSize(int.Parse(strExchangeCornerFileSize));
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

                zlzw.BLL.ExchangeCornerListBLL exchangeCornerListBLL = new zlzw.BLL.ExchangeCornerListBLL();
                DataTable dt = exchangeCornerListBLL.GetList("ExchangeCornerGUID='" + strSelectID + "'").Tables[0];
                zlzw.Model.ExchangeCornerListModel exchangeCornerListModel = exchangeCornerListBLL.GetModel(int.Parse(dt.Rows[0]["ExchangeCornerID"].ToString()));
                exchangeCornerListModel.IsEnable = 0;
                exchangeCornerListBLL.Update(exchangeCornerListModel);
                ExchangeCornerList_BindGrid();

                #endregion
            }
            else
            {
                return;
            }
        }

        #endregion

        #region 获取类型名称

        private string Get_TypeName(string strTypeID)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingKey='" + strTypeID + "'").Tables[0];
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

        #region 获取图片尺寸

        private string Get_FileSize(int size)
        {
            string FileSize = ""; 
            if (size != 0)
            {
                if (size >= 1073741824)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1073741824), 2).ToString() + "GB";  //GB            
                }            
                else if (size >= 1048576)            
                {                
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1048576), 2).ToString() + "MB";            
                }            
                else if (size >= 1024)            
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1024), 2).ToString() + "KB"; int a = size / 1024 * 100; int b = size / 1024;
                }
                else 
                { FileSize = size.ToString() + "bytes"; }
            }
            else { FileSize = size.ToString() + "bytes"; } return FileSize;   
        }

        #endregion

        #region 获取所属类型名称

        private string Get_strExchangeCornerTypeName(string strTypeName)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("CanUsable=1 and SettingKey='" + strTypeName + "' and SettingCategory='ExchangeCornerType'").Tables[0];
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
    }
}