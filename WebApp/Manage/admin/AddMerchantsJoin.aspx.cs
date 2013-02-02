using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddMerchantsJoin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                labPublishName.Text = Get_UserName(Request.Cookies["UserID"].Value);
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
                zlzw.BLL.MerchantsJoinListBLL merchantsJoinListBLL = new zlzw.BLL.MerchantsJoinListBLL();
                zlzw.Model.MerchantsJoinListModel merchantsJoinListModel = merchantsJoinListBLL.GetModel(int.Parse(Get_ID(merchantsJoinListBLL, strID)));
                labPublishName.Text = merchantsJoinListModel.PublishName;//发布人
                txbContent.Text = merchantsJoinListModel.MerchantsJoinConetnt;//发布内容
                ViewState["PublishDate"] = merchantsJoinListModel.PublisDate.ToString();
                ViewState["MerchantsJoinGUID"] = merchantsJoinListModel.MerchantsJoinGUID.ToString();
                ToolbarText2.Text = "编辑一条招商加盟";
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
                zlzw.Model.MerchantsJoinListModel merchantsJoinListModel = new zlzw.Model.MerchantsJoinListModel();
                merchantsJoinListModel.PublishName = Get_UserName(Request.Cookies["UserID"].Value);
                merchantsJoinListModel.MerchantsJoinConetnt = txbContent.Text;
                merchantsJoinListModel.IsEnable = 1;
                merchantsJoinListModel.PublisDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                merchantsJoinListModel.MerchantsJoinGUID = new Guid(ViewState["MerchantsJoinGUID"].ToString());
                zlzw.BLL.MerchantsJoinListBLL merchantsJoinListBLL = new zlzw.BLL.MerchantsJoinListBLL();
                merchantsJoinListModel.MerchantsJoinID = int.Parse(Get_ID(merchantsJoinListBLL, Request.QueryString["value"]));

                merchantsJoinListBLL.Update(merchantsJoinListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.MerchantsJoinListModel merchantsJoinListModel = new zlzw.Model.MerchantsJoinListModel();
                merchantsJoinListModel.PublishName = Get_UserName(Request.Cookies["UserID"].Value);
                merchantsJoinListModel.MerchantsJoinConetnt = txbContent.Text;
                merchantsJoinListModel.IsEnable = 1;
                merchantsJoinListModel.PublisDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.MerchantsJoinListBLL merchantsJoinListBLL = new zlzw.BLL.MerchantsJoinListBLL();
                merchantsJoinListBLL.Add(merchantsJoinListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取姓名

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
                return "未知用户";
            }
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.MerchantsJoinListBLL merchantsJoinListBLL, string strGUID)
        {
            System.Data.DataTable dt = merchantsJoinListBLL.GetList("MerchantsJoinGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["MerchantsJoinID"].ToString();
        }

        #endregion
    }
}