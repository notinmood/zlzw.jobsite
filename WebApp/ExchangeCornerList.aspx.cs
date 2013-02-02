using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ExchangeCornerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Load_NavigateConten(Request.QueryString["id"]);
                    Load_MenuList();//加载菜单内容
                }
                catch (Exception exp)
                {
                    Response.Redirect("default.aspx");
                }
            }
        }

        #region 加载导航内容

        private void Load_NavigateConten(string strType)
        {
            if (strType == "hr")
            {
                zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
                System.Data.DataTable dt = generalBasicSettingBLL.GetList("DisplayName='" + strType + "'").Tables[0];
                zlzw.BLL.ExchangeCornerListBLL exchangeCornerListBLL = new zlzw.BLL.ExchangeCornerListBLL();
                System.Data.DataTable dt01 = exchangeCornerListBLL.GetList("ExchangeCornerTypeKey='" + dt.Rows[0]["SettingKey"].ToString() + "'").Tables[0];
                titleName.Text = dt01.Rows[0]["ExchangeCornerTitle"].ToString();
                System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
                strBuilder.Append("<table style='width:100%;'><tr><td algin='center' style='width:38%;font-size:14px;'>文件名称</td><td style='font-size:14px;'>文件大小</td><td style='font-size:14px;'>发布日期</td><td style='font-size:14px;'>点击下载</td></tr>");
                for (int nCount = 0; nCount < dt01.Rows.Count; nCount++)
                {
                    strBuilder.Append("<tr><td algin='center'><a href='" + dt01.Rows[nCount]["ExchangeCornerFilePath"].ToString().Split('~')[1] + "' style='text-decoration:none;color:#000; href='" + dt01.Rows[nCount]["ExchangeCornerFilePath"].ToString().Split('~')[1] + "' style='color:#355F95;font-weight:bold;text-decoration:none;''>" + dt01.Rows[nCount]["ExchangeCornerTitle"].ToString() + "</a></td><td algin='center'>" + Get_FileSize(int.Parse(dt01.Rows[nCount]["ExchangeCornerFileSize"].ToString())) + "</td><td algin='center'>" + Set_DateFormat(dt01.Rows[nCount]["PublishDate"].ToString()) + "</td><td algin='center'><a href='" + dt01.Rows[nCount]["ExchangeCornerFilePath"].ToString().Split('~')[1] + "' style='color:#355F95;font-weight:bold;text-decoration:none;'>下载地址</td></tr>");
                }
                strBuilder.Append("</table>");
                labContent.Text = strBuilder.ToString();
            }
            else
            {
                zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
                System.Data.DataTable dt = generalBasicSettingBLL.GetList("DisplayName='" + strType + "'").Tables[0];
                zlzw.BLL.ExchangeCornerListBLL exchangeCornerListBLL = new zlzw.BLL.ExchangeCornerListBLL();
                System.Data.DataTable dt01 = exchangeCornerListBLL.GetList("ExchangeCornerTypeKey='" + dt.Rows[0]["SettingKey"].ToString() + "'").Tables[0];
                titleName.Text = dt01.Rows[0]["ExchangeCornerTitle"].ToString();
                labContent.Text = dt01.Rows[0]["exchangecornercontent"].ToString();
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

        #region 日期格式转化

        private string Set_DateFormat(string strDate)
        {
            try
            {
                return DateTime.Parse(strDate).ToString("yyyy年MM月dd日");
            }
            catch (Exception exp)
            {
                return "未知";
            }
        }

        #endregion

        #region 加载菜单内容

        private void Load_MenuList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("CanUsable=1 and SettingCategory='ExchangeCornerType' order by OrderNumber asc").Tables[0];

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        #endregion

        #region 根据GUID获取导航名称

        private string Get_NavigateName(string strGUID)
        {
            zlzw.BLL.NavigateListBLL navigateListBLL = new zlzw.BLL.NavigateListBLL();
            System.Data.DataTable dt = navigateListBLL.GetList("DisplayName='" + strGUID + "'").Tables[0];

            return dt.Rows[0]["SettingValue"].ToString();
        }

        #endregion

        #region 菜单行绑定事件

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.WebControls.ListItemType lit = e.Item.ItemType;
            if (lit == System.Web.UI.WebControls.ListItemType.Item || lit == System.Web.UI.WebControls.ListItemType.AlternatingItem)
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)e.Item.DataItem;
                Label labMenuItem = (Label)e.Item.FindControl("labMenuItem");
                if (drv["DisplayName"].ToString() == Request.QueryString["id"])
                {
                    labMenuItem.Text = "<td style='width:100%;background-color:#FA9A08;'><a href='#' style='text-decoration:none;color:#fff; font-weight:bold;'>" + drv["SettingValue"].ToString() + "</a></td>";
                }
                else
                {
                    labMenuItem.Text = "<td style='width:100%;'><a href='ExchangeCornerList.aspx?id=" + drv["DisplayName"].ToString() + "' style='text-decoration:none;color:#fff;color:#093C7E;'>" + drv["SettingValue"].ToString() + "</a></td>";
                }

            }
        }

        #endregion
    }
}