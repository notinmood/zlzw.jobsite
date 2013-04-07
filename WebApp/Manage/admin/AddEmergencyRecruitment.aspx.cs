using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddEmergencyRecruitment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                labCreateUserKey.Text = Get_UserName(Request.Cookies["UserID"].Value);
                string strType = Request.QueryString["Type"];
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

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

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.jjzpListBLL jjzpListBLL = new zlzw.BLL.jjzpListBLL();
                zlzw.Model.jjzpListModel jjzpListModel = jjzpListBLL.GetModel(int.Parse(Get_ID(jjzpListBLL, strID)));
                labContent.Text = jjzpListModel.jjzpContent;//紧急招聘
                ViewState["CreateDate"] = jjzpListModel.PublishDate.ToString();
                ViewState["JobPositionGuid"] = jjzpListModel.SysGUID.ToString();
                ToolbarText2.Text = "编辑一个紧急招聘";
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
                zlzw.BLL.jjzpListBLL jjzpListBLL = new zlzw.BLL.jjzpListBLL();
                zlzw.Model.jjzpListModel jjzpListModel = jjzpListBLL.GetModel(int.Parse(Get_ID(jjzpListBLL, Request.QueryString["value"])));
                jjzpListModel.jjzpContent = labContent.Text;//紧急招聘内容
                if (Request.Cookies["UserID"] != null)
                {
                    jjzpListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);
                }
                
                jjzpListModel.PublishDate = DateTime.Parse(ViewState["CreateDate"].ToString());
                jjzpListBLL.Update(jjzpListModel);
            }
            else
            {
                //添加保存
                zlzw.BLL.jjzpListBLL jjzpListBLL = new zlzw.BLL.jjzpListBLL();
                zlzw.Model.jjzpListModel jjzpListModel = new zlzw.Model.jjzpListModel();
                jjzpListModel.jjzpContent = labContent.Text;//紧急招聘内容
                jjzpListModel.PublishDate = DateTime.Now;
                if (Request.Cookies["UserID"] != null)
                {
                    jjzpListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);
                }
                
                jjzpListBLL.Add(jjzpListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.jjzpListBLL jjzpListBLL, string strGUID)
        {
            System.Data.DataTable dt = jjzpListBLL.GetList("SysGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["id"].ToString();
        }

        #endregion
    }
}