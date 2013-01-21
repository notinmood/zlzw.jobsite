using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                zlzw.Model.CoreUserModel coreUserModel = coreUserBLL.GetModel(int.Parse(Get_ID(coreUserBLL,strID)));
                txbAdminName.Text = coreUserModel.UserName;//用户名称
                txbAdminPassword.Text = coreUserModel.Password;//用户密码
                ViewState["PublishDate"] = coreUserModel.UserRegisterDate.ToString();
                ViewState["AdminGUID"] = coreUserModel.UserGuid.ToString();
                ToolbarText2.Text = "编辑一个管理员账号";
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
                zlzw.Model.CoreUserModel coreUserModel = new zlzw.Model.CoreUserModel();
                coreUserModel.UserName = txbAdminName.Text;
                coreUserModel.Password = txbAdminPassword.Text;
                coreUserModel.UserStatus = 1;
                coreUserModel.UserType = 64;
                coreUserModel.UserRegisterDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                coreUserModel.UserGuid = new Guid(ViewState["AdminGUID"].ToString());
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                coreUserModel.UserID = int.Parse(Get_ID(coreUserBLL,Request.QueryString["value"]));
                
                coreUserBLL.Update(coreUserModel);
            }
            else
            {
                //添加保存

                zlzw.Model.CoreUserModel coreUserModel = new zlzw.Model.CoreUserModel();
                coreUserModel.UserName = txbAdminName.Text;
                coreUserModel.Password = txbAdminPassword.Text;
                coreUserModel.UserStatus = 1;
                coreUserModel.UserType = 64;
                coreUserModel.UserRegisterDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                coreUserModel.UserGuid = System.Guid.NewGuid();
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                coreUserBLL.Add(coreUserModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.CoreUserBLL coreUserBLL,string strGUID)
        {
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='"+ strGUID +"'").Tables[0];
            return dt.Rows[0]["UserID"].ToString();
        }

        #endregion

    }
}