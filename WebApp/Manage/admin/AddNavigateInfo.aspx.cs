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
    public partial class AddNavigateInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    string strType = Request.QueryString["Type"];
                    labPublishID.Text = Get_UserName(Request.Cookies["UserID"].ToString());
                    Load_NavigateList();//加载导航类型
                    LoadData(strType);
                }
                btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
                Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
            }
        }

        #region 加载类型列表

        private void Load_NavigateList()
        {
            zlzw.BLL.NavigateListBLL navigateListBLL = new zlzw.BLL.NavigateListBLL();
            DataTable dt = navigateListBLL.GetList("IsEnable=1 order by OrderNumber asc").Tables[0];

            drpNavigateGUID.DataTextField = "NavigateName";
            drpNavigateGUID.DataValueField = "NavigateGUID";

            drpNavigateGUID.DataSource = dt;
            drpNavigateGUID.DataBind();
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.NavigateInfoListBLL navigateInfoListBLL = new zlzw.BLL.NavigateInfoListBLL();
                zlzw.Model.NavigateInfoListModel navigateInfoListModel = navigateInfoListBLL.GetModel(int.Parse(strID));
                drpNavigateGUID.Text = navigateInfoListModel.NavigateGUID.ToString();//所属类型
                txbNavigateInfoTitle.Text = navigateInfoListModel.NavigateInfoTitle;//标题
                txbNavigateInfoContent.Text = navigateInfoListModel.NavigateInfoContent;//内容
                
                ViewState["PublishDate"] = navigateInfoListModel.PublishDate.ToString();
                ToolbarText2.Text = "编辑一个导航内容";
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
        }

        #endregion

        #region 保存按钮事件

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Type"] == "1")
            {
                //编辑保存
                zlzw.Model.NavigateInfoListModel navigateInfoListModel = new zlzw.Model.NavigateInfoListModel();
                navigateInfoListModel.NavigateGUID = new Guid(drpNavigateGUID.SelectedValue);
                navigateInfoListModel.NavigateInfoTitle = txbNavigateInfoTitle.Text;
                navigateInfoListModel.NavigateInfoContent = txbNavigateInfoContent.Text;
                navigateInfoListModel.IsEnable = 1;
                navigateInfoListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);
                navigateInfoListModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                zlzw.BLL.NavigateInfoListBLL navigateInfoListBLL = new zlzw.BLL.NavigateInfoListBLL();
                navigateInfoListModel.NavigateInfoID = int.Parse(Request.QueryString["value"]);

                navigateInfoListBLL.Update(navigateInfoListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.NavigateInfoListModel navigateInfoListModel = new zlzw.Model.NavigateInfoListModel();
                navigateInfoListModel.NavigateGUID = new Guid(drpNavigateGUID.SelectedValue);
                navigateInfoListModel.NavigateInfoTitle = txbNavigateInfoTitle.Text;
                navigateInfoListModel.NavigateInfoContent = txbNavigateInfoContent.Text;
                navigateInfoListModel.IsEnable = 1;
                navigateInfoListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);
                navigateInfoListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.NavigateInfoListBLL navigateInfoListBLL = new zlzw.BLL.NavigateInfoListBLL();
                navigateInfoListBLL.Add(navigateInfoListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取用户名称

        private string Get_UserName(string strUserGUID)
        {
            if (Request.Cookies["UserID"] != null)
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                DataTable dt = coreUserBLL.GetList("UserGuid='" + Request.Cookies["UserID"].Value + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["UserName"].ToString();
                }
                else
                {
                    return "未知用户";
                }
            }
            else
            {
                return "未知用户";
            }
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.CoreUserBLL coreUserBLL, string strGUID)
        {
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["UserID"].ToString();
        }

        #endregion
    }
}