using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddAdImage : System.Web.UI.Page
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
                zlzw.BLL.ADImageListBLL aDImageListBLL = new zlzw.BLL.ADImageListBLL();
                zlzw.Model.ADImageListModel aDImageListModel = aDImageListBLL.GetModel(int.Parse(Get_ID(aDImageListBLL, strID)));
                txbAdImageTitle.Text = aDImageListModel.AdImageTitle;//图片名称 `
                txbADLink.Text = aDImageListModel.ADLink;//链接地址
                txbADContent.Text = aDImageListModel.ADContent;//内容简介
                ViewState["fileADImagePath"] = aDImageListModel.ADImagePath.ToString();//图片地址
                ViewState["AdminGUID"] = aDImageListModel.ADImageGUID.ToString();
                ToolbarText2.Text = "编辑一个图片";
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
                zlzw.Model.ADImageListModel aDImageListModel = new zlzw.Model.ADImageListModel();
                aDImageListModel.AdImageTitle = txbAdImageTitle.Text;
                aDImageListModel.ADLink = txbADLink.Text;
                if (fileADImagePath.PostedFile.ContentLength > 0)
                {
                    fileADImagePath.SaveAs(Server.MapPath(ViewState["fileADImagePath"].ToString()));
                    aDImageListModel.ADImagePath = ViewState["fileADImagePath"].ToString();
                }
                else
                {
                    aDImageListModel.ADImagePath = ViewState["fileADImagePath"].ToString();
                }
                aDImageListModel.ADContent = txbADContent.Text;
                aDImageListModel.IsEnable = 1;
                aDImageListModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                aDImageListModel.ADImageGUID = new Guid(ViewState["AdminGUID"].ToString());
                zlzw.BLL.ADImageListBLL aDImageListBLL = new zlzw.BLL.ADImageListBLL();
                aDImageListModel.ADImageID = int.Parse(Get_ID(aDImageListBLL, Request.QueryString["value"]));

                aDImageListBLL.Update(aDImageListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.ADImageListModel aDImageListModel = new zlzw.Model.ADImageListModel();
                aDImageListModel.AdImageTitle = txbAdImageTitle.Text;
                aDImageListModel.ADLink = txbADLink.Text;
                if (fileADImagePath.PostedFile.ContentLength > 0)
                {
                    string fileName = DateTime.Now.Ticks.ToString() + "_" + fileADImagePath.FileName;
                    fileADImagePath.SaveAs(Server.MapPath("~/UploadImages/" + fileName));
                    aDImageListModel.ADImagePath = "~/UploadImages/" + fileName;//保存图片路径
                }
                aDImageListModel.ADContent = txbADContent.Text;
                aDImageListModel.IsEnable = 1;
                aDImageListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.ADImageListBLL aDImageListBLL = new zlzw.BLL.ADImageListBLL();
                aDImageListBLL.Add(aDImageListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.ADImageListBLL aDImageListBLL, string strGUID)
        {
            System.Data.DataTable dt = aDImageListBLL.GetList("ADImageGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["ADImageID"].ToString();
        }

        #endregion
    }
}