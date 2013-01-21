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
    public partial class AddGeneralActivity : System.Web.UI.Page
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
                zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
                zlzw.Model.GeneralActivityModel generalActivityModel = generalActivityBLL.GetModel(int.Parse(Get_ID(generalActivityBLL, strID)));
                labCreateUserName.Text = generalActivityModel.CreateUserName;//创建人姓名
                txbActivityTitle.Text = generalActivityModel.ActivityTitle;//招聘会标题
                txbActivityAddress.Text = generalActivityModel.ActivityAddress;//招聘会举行地点
                FCKeditor1.Value = generalActivityModel.ActivityDesc;//招聘会简介
                labCreateUserName.Text = generalActivityModel.CreateUserName;//创建人姓名
                if(generalActivityModel.SpecialType == 0)
                {
                    ckbIsDefaultShow.Checked = false;
                }
                else
                {
                    ckbIsDefaultShow.Checked = true;
                }
                ViewState["PublishDate"] = generalActivityModel.PublishDate.ToString();
                ViewState["ActivityGuid"] = generalActivityModel.ActivityGuid.ToString();
                ToolbarText2.Text = "编辑一条招聘会信息";
            }
            else
            {
                labCreateUserName.Text = Get_UserName(Request.Cookies["UserID"].Value);
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
                zlzw.Model.GeneralActivityModel generalActivityModel = new zlzw.Model.GeneralActivityModel();
                generalActivityModel.ActivityTitle = txbActivityTitle.Text;//招聘会标题
                generalActivityModel.ActivityAddress = txbActivityAddress.Text;//招聘会举行地点
                generalActivityModel.ActivityDesc = FCKeditor1.Value;//招聘会简介
                generalActivityModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                generalActivityModel.ActivityGuid = new Guid(ViewState["AdminGUID"].ToString());
                if (ckbIsDefaultShow.Checked)
                {
                    generalActivityModel.SpecialType = 1;
                }
                else
                {
                    generalActivityModel.SpecialType = 0;
                }
                zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
                generalActivityModel.ActivityID = int.Parse(Get_ID(generalActivityBLL, Request.QueryString["value"]));

                generalActivityBLL.Update(generalActivityModel);
            }
            else
            {
                //添加保存

                zlzw.Model.GeneralActivityModel generalActivityModel = new zlzw.Model.GeneralActivityModel();
                generalActivityModel.ActivityTitle = txbActivityTitle.Text;//招聘会标题
                generalActivityModel.ActivityAddress = txbActivityAddress.Text;//招聘会举行地点
                generalActivityModel.ActivityDesc = FCKeditor1.Value;//招聘会简介
                generalActivityModel.CreateUserKey = Request.Cookies["UserID"].Value;//创建者GUID
                generalActivityModel.CreateUserName = Get_UserName(Request.Cookies["UserID"].Value);//创建者姓名
                generalActivityModel.CanUsable = 1;
                if (ckbIsDefaultShow.Checked)
                {
                    generalActivityModel.SpecialType = 1;
                }
                else
                {
                    generalActivityModel.SpecialType = 0;
                }
                generalActivityModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.GeneralActivityBLL generalActivityBLL = new zlzw.BLL.GeneralActivityBLL();
                generalActivityBLL.Add(generalActivityModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取用户名

        private string Get_UserName(string strUserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            DataTable dt = coreUserBLL.GetList("UserGuid='"+ strUserGUID +"'").Tables[0];

            return dt.Rows[0]["UserName"].ToString();
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.GeneralActivityBLL coreUserBLL, string strGUID)
        {
            System.Data.DataTable dt = coreUserBLL.GetList("ActivityGuid='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["ActivityID"].ToString();
        }

        #endregion
    }
}