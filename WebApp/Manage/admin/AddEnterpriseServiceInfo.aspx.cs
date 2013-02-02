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
    public partial class AddEnterpriseServiceInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                Load_EnterpriseServiceTypeGUID();//加载企业服务
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 加载企业服务类型

        private void Load_EnterpriseServiceTypeGUID()
        {
            zlzw.BLL.EnterpriseServiceTypeListBLL enterpriseServiceTypeListBLL = new zlzw.BLL.EnterpriseServiceTypeListBLL();
            DataTable dt = enterpriseServiceTypeListBLL.GetList("IsEnable=1 order by OrderNumber asc").Tables[0];

            drpEnterpriseServiceTypeGUID.DataTextField = "EnterpriseServiceTypeName";
            drpEnterpriseServiceTypeGUID.DataValueField = "EnterpriseServiceTypeGUID";

            drpEnterpriseServiceTypeGUID.DataSource = dt;
            drpEnterpriseServiceTypeGUID.DataBind();
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.EnterpriseServiceInfoListBLL enterpriseServiceInfoListBLL = new zlzw.BLL.EnterpriseServiceInfoListBLL();
                zlzw.Model.EnterpriseServiceInfoListModel enterpriseServiceInfoListModel = enterpriseServiceInfoListBLL.GetModel(int.Parse(Get_ID(enterpriseServiceInfoListBLL, strID)));
                labPublisID.Text = Get_UserName(enterpriseServiceInfoListModel.PublishID.ToString());
                drpEnterpriseServiceTypeGUID.SelectedValue = enterpriseServiceInfoListModel.EnterpriseServiceTypeGUID.ToString();//所属服务类型
                txbEnterpriseServiceInfoTitle.Text = enterpriseServiceInfoListModel.EnterpriseServiceInfoTitle;//服务名称
                txbEnterpriseServiceInfointroduction.Text = enterpriseServiceInfoListModel.EnterpriseServiceInfointroduction;//内容简介
                FCKeditor1.Value = enterpriseServiceInfoListModel.EnterpriseServiceInfoContent;//内容正文；
                
                ViewState["PublishDate"] = enterpriseServiceInfoListModel.PublishDate.ToString();
                ViewState["EnterpriseServiceInfoGUID"] = enterpriseServiceInfoListModel.EnterpriseServiceInfoGUID.ToString();
                ToolbarText2.Text = "编辑一个企业服务内容";
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
                zlzw.Model.EnterpriseServiceInfoListModel enterpriseServiceInfoListModel = new zlzw.Model.EnterpriseServiceInfoListModel();
                enterpriseServiceInfoListModel.EnterpriseServiceTypeGUID = new Guid(drpEnterpriseServiceTypeGUID.SelectedValue);//所属企业服务类型
                enterpriseServiceInfoListModel.EnterpriseServiceInfoTitle = txbEnterpriseServiceInfoTitle.Text;//企业内名称
                enterpriseServiceInfoListModel.EnterpriseServiceInfointroduction = txbEnterpriseServiceInfointroduction.Text;//内容简介
                enterpriseServiceInfoListModel.EnterpriseServiceInfoContent = FCKeditor1.Value;//内容正文
                enterpriseServiceInfoListModel.IsEnable = 1;
                enterpriseServiceInfoListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);//发布人ID
                enterpriseServiceInfoListModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                enterpriseServiceInfoListModel.EnterpriseServiceInfoGUID = new Guid(ViewState["EnterpriseServiceInfoGUID"].ToString());
                zlzw.BLL.EnterpriseServiceInfoListBLL enterpriseServiceInfoListBLL = new zlzw.BLL.EnterpriseServiceInfoListBLL();
                enterpriseServiceInfoListModel.EnterpriseServiceInfoID = int.Parse(Get_ID(enterpriseServiceInfoListBLL, Request.QueryString["value"]));

                enterpriseServiceInfoListBLL.Update(enterpriseServiceInfoListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.EnterpriseServiceInfoListModel enterpriseServiceInfoListModel = new zlzw.Model.EnterpriseServiceInfoListModel();
                enterpriseServiceInfoListModel.EnterpriseServiceTypeGUID = new Guid(drpEnterpriseServiceTypeGUID.SelectedValue);//所属企业服务类型
                enterpriseServiceInfoListModel.EnterpriseServiceInfoTitle = txbEnterpriseServiceInfoTitle.Text;//企业内名称
                enterpriseServiceInfoListModel.EnterpriseServiceInfointroduction = txbEnterpriseServiceInfointroduction.Text;//内容简介
                enterpriseServiceInfoListModel.EnterpriseServiceInfoContent = FCKeditor1.Value;//内容正文
                enterpriseServiceInfoListModel.IsEnable = 1;
                enterpriseServiceInfoListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);//发布人ID
                enterpriseServiceInfoListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.EnterpriseServiceInfoListBLL enterpriseServiceInfoListBLL = new zlzw.BLL.EnterpriseServiceInfoListBLL();
                enterpriseServiceInfoListBLL.Add(enterpriseServiceInfoListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.EnterpriseServiceInfoListBLL enterpriseServiceInfoListBLL, string strGUID)
        {
            System.Data.DataTable dt = enterpriseServiceInfoListBLL.GetList("EnterpriseServiceInfoGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["EnterpriseServiceInfoID"].ToString();
        }

        #endregion

        #region 根据用户GUID获取用户名称

        private string Get_UserName(string strUserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            DataTable dt = coreUserBLL.GetList("UserGuid='"+ strUserGUID +"'").Tables[0];
            if(dt.Rows.Count > 0)
            {
                return dt.Rows[0]["UserName"].ToString();
            }
            else
            {
                return "未知用户";
            }
        }

        #endregion

    }
}