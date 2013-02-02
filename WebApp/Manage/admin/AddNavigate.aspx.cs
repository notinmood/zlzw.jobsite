using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddNavigate : System.Web.UI.Page
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
                zlzw.BLL.NavigateListBLL navigateListBLL = new zlzw.BLL.NavigateListBLL();
                zlzw.Model.NavigateListModel navigateListModel = navigateListBLL.GetModel(int.Parse(Get_ID(navigateListBLL, strID)));
                txbNavigateName.Text = navigateListModel.NavigateName;//菜单名称
                txbOrderNumber.Text = navigateListModel.OrderNumber.ToString();//排序
                if (navigateListModel.IsShow == 1)
                {
                    ckbIsShow.Checked = true;
                }
                else
                {
                    ckbIsShow.Checked = false;
                }
                ViewState["PublishDate"] = navigateListModel.PublishDate.ToString();
                ViewState["NavigateGUID"] = navigateListModel.NavigateGUID.ToString();
                ToolbarText2.Text = "编辑一个导航菜单";
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
                zlzw.Model.NavigateListModel navigateListModel = new zlzw.Model.NavigateListModel();
                navigateListModel.NavigateName = txbNavigateName.Text;
                navigateListModel.OrderNumber = int.Parse(txbOrderNumber.Text);
                navigateListModel.IsEnable = 1;
                if (ckbIsShow.Checked)
                {
                    navigateListModel.IsShow = 1;
                }
                else
                {
                    navigateListModel.IsShow = 0;
                }
                navigateListModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                navigateListModel.NavigateGUID = new Guid(ViewState["NavigateGUID"].ToString());
                zlzw.BLL.NavigateListBLL navigateListBLL = new zlzw.BLL.NavigateListBLL();
                navigateListModel.NavigateID = int.Parse(Get_ID(navigateListBLL, Request.QueryString["value"]));

                navigateListBLL.Update(navigateListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.NavigateListModel navigateListModel = new zlzw.Model.NavigateListModel();
                navigateListModel.NavigateName = txbNavigateName.Text;
                navigateListModel.OrderNumber = int.Parse(txbOrderNumber.Text);
                navigateListModel.IsEnable = 1;
                if (ckbIsShow.Checked)
                {
                    navigateListModel.IsShow = 1;
                }
                else
                {
                    navigateListModel.IsShow = 0;
                }
                navigateListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.NavigateListBLL navigateListBLL = new zlzw.BLL.NavigateListBLL();
                navigateListBLL.Add(navigateListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.NavigateListBLL navigateListBLL, string strGUID)
        {
            System.Data.DataTable dt = navigateListBLL.GetList("NavigateGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["NavigateID"].ToString();
        }

        #endregion
    }
}