using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddGeneralFriendlyLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                if (strType == "1")
                {
                    fileUploadImage.Required = false;
                }
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 友情链接类型选择

        protected void drpLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpLinkType.SelectedValue == "0")
            {
                fileUploadImage.Required = false;
            }
            else
            {
                fileUploadImage.Required = true;
            }
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.GeneralFriendlyLinkBLL generalFriendlyLinkBLL = new zlzw.BLL.GeneralFriendlyLinkBLL();
                zlzw.Model.GeneralFriendlyLinkModel generalFriendlyLinkModel = generalFriendlyLinkBLL.GetModel(int.Parse(Get_ID(generalFriendlyLinkBLL, strID)));
                txbLinkTitle.Text = generalFriendlyLinkModel.LinkTitle;//友情链接标题
                drpLinkType.SelectedValue = generalFriendlyLinkModel.LinkType.ToString();//友情链接类型
                txbLinkTargetUrl.Text = generalFriendlyLinkModel.LinkTargetUrl;//友情链接跳转地址
                txbOrderNumber.Text = generalFriendlyLinkModel.LinkOrderNumber.ToString();//排序
                txbLinkDesc.Text = generalFriendlyLinkModel.LinkDesc;//友情链接描述
                ViewState["LinkImagePath"] = generalFriendlyLinkModel.LinkImagePath;//上传图片路径
                ViewState["PublishDate"] = generalFriendlyLinkModel.PublishDate.ToString();
                ViewState["LinkGuid"] = generalFriendlyLinkModel.LinkGuid.ToString();
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
                zlzw.Model.GeneralFriendlyLinkModel generalFriendlyLinkModel = new zlzw.Model.GeneralFriendlyLinkModel();
                generalFriendlyLinkModel.LinkTitle = txbLinkTitle.Text;
                generalFriendlyLinkModel.LinkType = int.Parse(drpLinkType.SelectedValue);
                generalFriendlyLinkModel.LinkTargetUrl = txbLinkTargetUrl.Text;
                generalFriendlyLinkModel.LinkOrderNumber = int.Parse(txbOrderNumber.Text);
                generalFriendlyLinkModel.LinkDesc = txbLinkDesc.Text;
                generalFriendlyLinkModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                generalFriendlyLinkModel.LinkGuid = new Guid(ViewState["LinkGuid"].ToString());
                zlzw.BLL.GeneralFriendlyLinkBLL generalFriendlyLinkBLL = new zlzw.BLL.GeneralFriendlyLinkBLL();
                generalFriendlyLinkModel.LinkID = int.Parse(Get_ID(generalFriendlyLinkBLL, Request.QueryString["value"]));
                generalFriendlyLinkModel.CanUsable = 1;
                if (fileUploadImage.PostedFile.ContentLength > 0)
                {
                    fileUploadImage.SaveAs(Server.MapPath(ViewState["LinkImagePath"].ToString()));
                    generalFriendlyLinkModel.LinkImagePath = ViewState["LinkImagePath"].ToString();
                }
                else
                {
                    generalFriendlyLinkModel.LinkImagePath = ViewState["LinkImagePath"].ToString();
                }
                generalFriendlyLinkBLL.Update(generalFriendlyLinkModel);
            }
            else
            {
                //添加保存

                zlzw.Model.GeneralFriendlyLinkModel generalFriendlyLinkModel = new zlzw.Model.GeneralFriendlyLinkModel();
                generalFriendlyLinkModel.LinkTitle = txbLinkTitle.Text;
                generalFriendlyLinkModel.LinkType = int.Parse(drpLinkType.SelectedValue);
                generalFriendlyLinkModel.LinkTargetUrl = txbLinkTargetUrl.Text;
                generalFriendlyLinkModel.LinkOrderNumber = int.Parse(txbOrderNumber.Text);
                generalFriendlyLinkModel.LinkDesc = txbLinkDesc.Text;
                generalFriendlyLinkModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                generalFriendlyLinkModel.CanUsable = 1;
                if (fileUploadImage.PostedFile.ContentLength > 0)
                {
                    string fileName = DateTime.Now.Ticks.ToString() + "_" + fileUploadImage.FileName;
                    fileUploadImage.SaveAs(Server.MapPath("~/UploadImages/" + fileName));
                    generalFriendlyLinkModel.LinkImagePath = "~/UploadImages/" + fileName;//保存友情链接图片路径
                }
                zlzw.BLL.GeneralFriendlyLinkBLL generalFriendlyLinkBLL = new zlzw.BLL.GeneralFriendlyLinkBLL();
                generalFriendlyLinkBLL.Add(generalFriendlyLinkModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.GeneralFriendlyLinkBLL generalFriendlyLinkBLL, string strGUID)
        {
            System.Data.DataTable dt = generalFriendlyLinkBLL.GetList("LinkGuid='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["LinkID"].ToString();
        }

        #endregion
    }
}