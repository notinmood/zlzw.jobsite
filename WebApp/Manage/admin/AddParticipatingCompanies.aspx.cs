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
    public partial class AddParticipatingCompanies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                Load_EnterpriseList();//加载企业列表
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 加载企业列表

        private void Load_EnterpriseList()
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("CanUsable=1 order by CreateDate desc").Tables[0];

            drpEnterpriseGuid.DataTextField = "CompanyName";
            drpEnterpriseGuid.DataValueField = "EnterpriseGuid";

            drpEnterpriseGuid.DataSource = dt;
            drpEnterpriseGuid.DataBind();
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.ParticipatingCompaniesListBLL participatingCompaniesListBLL = new zlzw.BLL.ParticipatingCompaniesListBLL();
                zlzw.Model.ParticipatingCompaniesListModel participatingCompaniesListModel = participatingCompaniesListBLL.GetModel(int.Parse(Get_ID(participatingCompaniesListBLL, strID)));
                drpEnterpriseGuid.SelectedValue = participatingCompaniesListModel.ParticipatingCompaniesGUID.ToString();//所属企业
                txbParticipatingCompaniesContent.Text = participatingCompaniesListModel.ParticipatingCompaniesContent;//发布内容
                if (participatingCompaniesListModel.IsShow == 1)
                {
                    ckbIsShow.Checked = true;
                }
                else
                {
                    ckbIsShow.Checked = false;
                }
                ViewState["PublishDate"] = participatingCompaniesListModel.PublishDate.ToString();
                ViewState["ParticipatingCompaniesGUID"] = participatingCompaniesListModel.ParticipatingCompaniesGUID.ToString();
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
                zlzw.Model.ParticipatingCompaniesListModel participatingCompaniesListModel = new zlzw.Model.ParticipatingCompaniesListModel();
                participatingCompaniesListModel.EnterpriseGuid = new Guid(drpEnterpriseGuid.SelectedValue);
                participatingCompaniesListModel.ParticipatingCompaniesContent = txbParticipatingCompaniesContent.Text;
                if(ckbIsShow.Checked)
                {
                    participatingCompaniesListModel.IsShow = 1;
                }
                else
                {
                    participatingCompaniesListModel.IsShow = 0;
                }
                participatingCompaniesListModel.IsEnable = 1;
                participatingCompaniesListModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                participatingCompaniesListModel.ParticipatingCompaniesGUID = new Guid(ViewState["ParticipatingCompaniesGUID"].ToString());
                zlzw.BLL.ParticipatingCompaniesListBLL participatingCompaniesListBLL = new zlzw.BLL.ParticipatingCompaniesListBLL();
                participatingCompaniesListModel.ParticipatingCompaniesID = int.Parse(Get_ID(participatingCompaniesListBLL, Request.QueryString["value"]));

                participatingCompaniesListBLL.Update(participatingCompaniesListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.ParticipatingCompaniesListModel participatingCompaniesListModel = new zlzw.Model.ParticipatingCompaniesListModel();
                participatingCompaniesListModel.EnterpriseGuid = new Guid(drpEnterpriseGuid.SelectedValue);
                participatingCompaniesListModel.ParticipatingCompaniesContent = txbParticipatingCompaniesContent.Text;
                if (ckbIsShow.Checked)
                {
                    participatingCompaniesListModel.IsShow = 1;
                }
                else
                {
                    participatingCompaniesListModel.IsShow = 0;
                }
                participatingCompaniesListModel.IsEnable = 1;
                participatingCompaniesListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.ParticipatingCompaniesListBLL participatingCompaniesListBLL = new zlzw.BLL.ParticipatingCompaniesListBLL();
                participatingCompaniesListBLL.Add(participatingCompaniesListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.ParticipatingCompaniesListBLL participatingCompaniesListBLL, string strGUID)
        {
            System.Data.DataTable dt = participatingCompaniesListBLL.GetList("ParticipatingCompaniesGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["ParticipatingCompaniesID"].ToString();
        }

        #endregion
    }
}