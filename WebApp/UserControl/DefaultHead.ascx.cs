using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.UserControl
{
    public partial class DefaultHead : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_NavigateList();//加载导航菜单
        }

        #region 加载导航菜单

        private void Load_NavigateList()
        {
            zlzw.BLL.NavigateListBLL navigateListBLL = new zlzw.BLL.NavigateListBLL();
            DataTable dt = navigateListBLL.GetList("IsEnable=1 and IsShow=1 order by OrderNumber asc").Tables[0];
            labNavigate.Text = "";
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                if (nCount == 3)
                {
                    labNavigate.Text += "<a href='NaviagteInfo.aspx?id=" + dt.Rows[nCount]["NavigateGUID"].ToString() + "' style='color:#093C7E;text-decoration:none;'>" + dt.Rows[nCount]["NavigateName"].ToString() + "</a><br/>";
                }
                else if (nCount == 7)
                {
                    labNavigate.Text += "<a href='NaviagteInfo.aspx?id=" + dt.Rows[nCount]["NavigateGUID"].ToString() + "' style='color:#093C7E;text-decoration:none;'>" + dt.Rows[nCount]["NavigateName"].ToString() + "</a>";
                }
                else
                {
                    labNavigate.Text += "<a href='NaviagteInfo.aspx?id=" + dt.Rows[nCount]["NavigateGUID"].ToString() + "' style='color:#093C7E;text-decoration:none;'>" + dt.Rows[nCount]["NavigateName"].ToString() + "</a> | ";
                }
            }
        }

        #endregion
    }
}