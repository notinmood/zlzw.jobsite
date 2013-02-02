using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;


namespace WebApp.Manage.admin
{
    public partial class AddExchangeCorner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                Load_ExchangeCornerTypeList();//加载类型
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 加载交流园地类型

        private void Load_ExchangeCornerTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("CanUsable=1 and SettingCategory='ExchangeCornerType' order by OrderNumber").Tables[0];
            drpExchangeCornerTypeKey.DataTextField = "SettingValue";
            drpExchangeCornerTypeKey.DataValueField = "SettingKey";

            drpExchangeCornerTypeKey.DataSource = dt;
            drpExchangeCornerTypeKey.DataBind();
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.ExchangeCornerListBLL exchangeCornerListBLL = new zlzw.BLL.ExchangeCornerListBLL();
                zlzw.Model.ExchangeCornerListModel exchangeCornerListModel = exchangeCornerListBLL.GetModel(int.Parse(Get_ID(exchangeCornerListBLL, strID)));
                txbExchangeCornerTitle.Text = exchangeCornerListModel.ExchangeCornerTitle;//标题
                drpExchangeCornerTypeKey.SelectedValue = exchangeCornerListModel.ExchangeCornerTypeKey;//所属分类
                txbContent.Text = exchangeCornerListModel.ExchangeCornerContent;
                ViewState["FilePath"] = exchangeCornerListModel.ExchangeCornerFilePath;//文件路径
                ViewState["FileSize"] = exchangeCornerListModel.ExchangeCornerFileSize;//文件尺寸
                ViewState["PublishDate"] = exchangeCornerListModel.PublishDate.ToString();
                ViewState["ExchangeCornerGUID"] = exchangeCornerListModel.ExchangeCornerGUID.ToString();
                ToolbarText2.Text = "编辑一个交流园地内容";
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
                zlzw.Model.ExchangeCornerListModel exchangeCornerListModel = new zlzw.Model.ExchangeCornerListModel();
                exchangeCornerListModel.ExchangeCornerTitle = txbExchangeCornerTitle.Text;
                exchangeCornerListModel.ExchangeCornerTypeKey = drpExchangeCornerTypeKey.SelectedValue;
                exchangeCornerListModel.IsEnable = 1;
                exchangeCornerListModel.ExchangeCornerContent = txbContent.Text;
                if (fileExchangeCornerFilePath.PostedFile.ContentLength > 0)
                {
                    fileExchangeCornerFilePath.SaveAs(Server.MapPath(ViewState["FilePath"].ToString()));
                    exchangeCornerListModel.ExchangeCornerFilePath = ViewState["FilePath"].ToString();
                    exchangeCornerListModel.ExchangeCornerFileSize = ViewState["FileSize"].ToString();
                }
                else
                {
                    exchangeCornerListModel.ExchangeCornerFilePath = ViewState["FilePath"].ToString();
                    exchangeCornerListModel.ExchangeCornerFileSize = fileExchangeCornerFilePath.PostedFile.ContentLength.ToString();
                }
                exchangeCornerListModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                exchangeCornerListModel.ExchangeCornerGUID = new Guid(ViewState["ExchangeCornerGUID"].ToString());
                zlzw.BLL.ExchangeCornerListBLL exchangeCornerListBLL = new zlzw.BLL.ExchangeCornerListBLL();
                exchangeCornerListModel.ExchangeCornerID = int.Parse(Get_ID(exchangeCornerListBLL, Request.QueryString["value"]));

                exchangeCornerListBLL.Update(exchangeCornerListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.ExchangeCornerListModel exchangeCornerListModel = new zlzw.Model.ExchangeCornerListModel();
                exchangeCornerListModel.ExchangeCornerTitle = txbExchangeCornerTitle.Text;
                exchangeCornerListModel.ExchangeCornerTypeKey = drpExchangeCornerTypeKey.SelectedValue;
                exchangeCornerListModel.IsEnable = 1;
                exchangeCornerListModel.ExchangeCornerContent = txbContent.Text;
                exchangeCornerListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                if (fileExchangeCornerFilePath.PostedFile.ContentLength > 0)
                {
                    string fileName = DateTime.Now.Ticks.ToString() + "_" + fileExchangeCornerFilePath.FileName;
                    fileExchangeCornerFilePath.SaveAs(Server.MapPath("~/ExchangeCornerFile/" + fileName));
                    exchangeCornerListModel.ExchangeCornerFilePath = "~/ExchangeCornerFile/" + fileName;//保存图片路径
                    exchangeCornerListModel.ExchangeCornerFileSize = fileExchangeCornerFilePath.PostedFile.ContentLength.ToString();//文件尺寸
                }
                zlzw.BLL.ExchangeCornerListBLL exchangeCornerListBLL = new zlzw.BLL.ExchangeCornerListBLL();
                exchangeCornerListBLL.Add(exchangeCornerListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 类型选择事件

        protected void drpExchangeCornerTypeKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpExchangeCornerTypeKey.SelectedValue == "HRJIAOLIUYUANDI")
            {
                txbContent.Hidden = true;
                fileExchangeCornerFilePath.Hidden = true;
                txbExchangeCornerTitle.Required = false;
                txbExchangeCornerTitle.Hidden = true;
            }
            else
            {
                txbContent.Hidden = false;
                fileExchangeCornerFilePath.Hidden = false;
                txbExchangeCornerTitle.Hidden = false;
            }
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.ExchangeCornerListBLL coreUserBLL, string strGUID)
        {
            System.Data.DataTable dt = coreUserBLL.GetList("ExchangeCornerGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["ExchangeCornerID"].ToString();
        }

        #endregion
    }
}