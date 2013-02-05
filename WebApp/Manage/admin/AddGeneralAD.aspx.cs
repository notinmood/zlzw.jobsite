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
    public partial class AddGeneralAD : System.Web.UI.Page
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
                Load_EnterpriseList();//加载所属企业列表
                Load_ADTypeList();//加载广告类型
                LoadData(strType);
                labCreateUserName.Text = Get_UserName();//获取创建人名称
                if (drpADType.SelectedText == "脚本类型")
                {
                    txbADScript.Hidden = false;
                }
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 加载企业列表

        private void Load_EnterpriseList()
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("Canusable=1 order by CreateDate desc").Tables[0];
            drpEnterpriseType.DataTextField = "CompanyName";
            drpEnterpriseType.DataValueField = "EnterpriseGuid";

            drpEnterpriseType.DataSource = dt;
            drpEnterpriseType.DataBind();
        }

        #endregion

        #region 加载广告类型

        private void Load_ADTypeList()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='ADKind'").Tables[0];

            drpADType.DataTextField = "SettingValue";
            drpADType.DataValueField = "SettingKey";

            drpADType.DataSource = dt;
            drpADType.DataBind();

        }

        #endregion

        #region 广告类型选择
        
        protected void drpADType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpADType.SelectedText == "脚本类型")
            {
                txbADScript.Hidden = false;
            }
            else
            {
                txbADScript.Hidden = true;
            }
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.GeneralADBLL generalADBLL = new zlzw.BLL.GeneralADBLL();
                zlzw.Model.GeneralADModel generalADModel = generalADBLL.GetModel(int.Parse(Get_ID(generalADBLL, strID)));
                txbADName.Text = generalADModel.ADName;//广告名称
                drpADType.SelectedValue = generalADModel.ADType.ToString();//广告类型
                txbADScript.Text = generalADModel.ADScript;//广告脚本
                txbADTargetUrl.Text = generalADModel.ADTargetUrl;//跳转地址
                txbOrderNumber.Text = generalADModel.ADOrderNumber.ToString();//排序字段
                if (generalADModel.ADStatus == 1)
                {
                    ckbADStatus.Checked = true;
                }
                else
                {
                    ckbADStatus.Checked = false;
                }
                drpEnterpriseType.SelectedValue = generalADModel.EnterpriseGuid.ToString();//所属企业ID
                txbADDesc.Text = generalADModel.ADDesc;//广告简介
                ViewState["ADImagePath"] = generalADModel.ADImagePath;//广告图片路径
                ViewState["CreateDate"] = generalADModel.CreateDate.ToString();//创建日期
                ViewState["ADGuid"] = generalADModel.ADGuid.ToString();
                ToolbarText2.Text = "编辑一个广告";
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
                zlzw.Model.GeneralADModel generalADModel = new zlzw.Model.GeneralADModel();
                generalADModel.ADName = txbADName.Text;//广告名称
                generalADModel.ADType = int.Parse(drpADType.SelectedValue);//广告类型
                generalADModel.ADScript = txbADScript.Text;//广告脚本
                generalADModel.ADTargetUrl = txbADTargetUrl.Text;//跳转地址
                generalADModel.CreateDate = DateTime.Parse(ViewState["CreateDate"].ToString());
                generalADModel.UpdateDate = DateTime.Now;//更新日期
                generalADModel.ADOrderNumber = int.Parse(txbOrderNumber.Text);//排序字段
                if (ckbADStatus.Checked)
                {
                    generalADModel.ADStatus = 1;
                }
                else
                {
                    generalADModel.ADStatus = 0;
                }
                if (fileUploadImage.PostedFile.ContentLength > 0)
                {
                    fileUploadImage.SaveAs(Server.MapPath(ViewState["ADImagePath"].ToString()));
                    generalADModel.ADImagePath = ViewState["ADImagePath"].ToString();
                }
                else
                {
                    generalADModel.ADImagePath = ViewState["ADImagePath"].ToString();
                }
                generalADModel.EnterpriseGuid = new Guid(drpEnterpriseType.SelectedValue);//所属企业GUID
                generalADModel.CreateUserKey = Request.Cookies["UserID"].Value;//创建人GUID
                generalADModel.CreateUserName = Get_UserName();
                generalADModel.CanUsable = 1;
                generalADModel.ADDesc = txbADDesc.Text;//广告简介
                generalADModel.ADGuid = new Guid(ViewState["ADGuid"].ToString());
                zlzw.BLL.GeneralADBLL generalADBLL = new zlzw.BLL.GeneralADBLL();
                generalADModel.ADID = int.Parse(Get_ID(generalADBLL, Request.QueryString["value"]));

                generalADBLL.Update(generalADModel);
            }
            else
            {
                //添加保存
                zlzw.Model.GeneralADModel generalADModel = new zlzw.Model.GeneralADModel();
                generalADModel.ADName = txbADName.Text;//广告名称
                generalADModel.ADType = int.Parse(drpADType.SelectedValue);//广告类型
                generalADModel.ADScript = txbADScript.Text;//广告脚本
                generalADModel.ADTargetUrl = txbADTargetUrl.Text;//跳转地址
                generalADModel.ADOrderNumber = int.Parse(txbOrderNumber.Text);//排序字段
                generalADModel.CreateDate = DateTime.Now;//创建日期
                generalADModel.UpdateDate = DateTime.Now;//更新日期
                if (ckbADStatus.Checked)
                {
                    generalADModel.ADStatus = 1;
                }
                else
                {
                    generalADModel.ADStatus = 0;
                }
                generalADModel.CanUsable = 1;
                if (fileUploadImage.PostedFile.ContentLength > 0)
                {
                    string fileName = DateTime.Now.Ticks.ToString() + "_" + fileUploadImage.FileName;
                    fileUploadImage.SaveAs(Server.MapPath("~/UploadImages/" + fileName));
                    generalADModel.ADImagePath = "~/UploadImages/" + fileName;//保存广告图片路径
                }
                generalADModel.EnterpriseGuid = new Guid(drpEnterpriseType.SelectedValue);//所属企业GUID
                generalADModel.CreateUserKey = Request.Cookies["UserID"].Value;//创建人GUID
                generalADModel.CreateUserName = Get_UserName();
                generalADModel.ADDesc = txbADDesc.Text;//广告简介
                zlzw.BLL.GeneralADBLL generalADBLL = new zlzw.BLL.GeneralADBLL();
                generalADBLL.Add(generalADModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 辅助函数

        #region 根据Cookie中的ID获取用户名称

        private string Get_UserName()
        {
            if (Request.Cookies["UserID"] != null)
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                DataTable dt = coreUserBLL.GetList("UserGuid='" + Request.Cookies["UserID"].Value + "'").Tables[0];

                return dt.Rows[0]["UserName"].ToString();
            }
            else
            {
                return "未知用户";
            }
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.GeneralADBLL generalADBLL, string strGUID)
        {
            System.Data.DataTable dt = generalADBLL.GetList("ADGuid='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["ADID"].ToString();
        }

        #endregion

        #endregion
    }
}