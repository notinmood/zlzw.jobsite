using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Newtonsoft.Json.Linq;
using Utility;
using System.Data;
using System.Collections;

namespace WebApp.Manage.admin
{
    public partial class AddGeneralEnterprise : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strType = Request.QueryString["Type"];
                if (strType == "1")
                {
                    fileBusinessLicense.Required = false;
                }
                BindSheng(strType);
                Load_IndustryKey();//加载行业信息
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 加载省市区信息

        private void BindSheng(string strType)
        {
            ddlSheng.DataSource = SHENG_JSON;
            ddlSheng.DataBind();
            if (strType == "0")
            {
                ddlSheng.Items.Insert(0, new FineUI.ListItem("选择省份", "-1"));
            }
            BindShi(strType);
        }

        private void BindShi(string strType)
        {
            string sheng = ddlSheng.SelectedValue;

            if (sheng != "-1")
            {
                JArray ja = SHI_JSON.Value<JArray>(sheng); // .getJSONArray(sheng);
                ddlShi.DataSource = ja;
                ddlShi.DataBind();
            }
            if (strType == "0")
            {
                ddlShi.Items.Insert(0, new FineUI.ListItem("选择地区市", "-1"));
            }
            
            BindXian(strType);
        }

        private void BindXian(string strType)
        {
            string shi = ddlShi.SelectedValue;

            if (shi != "-1")
            {
                JArray ja = XIAN_JSON.Value<JArray>(shi); //.getJSONArray(shi);
                ddlXian.DataSource = ja;
                ddlXian.DataBind();
            }
            if (strType == "0")
            {
                ddlXian.Items.Insert(0, new FineUI.ListItem("选择县级市", "-1"));
            }
            
        }

        protected void ddlSheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlShi.Items.Clear();
            BindShi(Request.QueryString["Type"]);

            ddlXian.Items.Clear();
            BindXian(Request.QueryString["Type"]);
        }

        protected void ddlShi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlXian.Items.Clear();
            BindXian(Request.QueryString["Type"]);
        }

        #endregion

        #region 行业信息加载

        private void Load_IndustryKey()
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            DataTable dt = generalBasicSettingBLL.GetList("SettingCategory='IndustrySector'").Tables[0];
            ArrayList arrList = new ArrayList();
            string strTemp;
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                strTemp = dt.Rows[nCount]["DisplayName"].ToString();
                if (!arrList.Contains(strTemp))
                {
                    arrList.Add(strTemp);
                }
            }
            drpIndustryKey.DataSource = arrList;
            drpIndustryKey.DataBind();
        }

        #endregion

        #region 加载用户信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
                zlzw.Model.GeneralEnterpriseModel generalEnterpriseModel = generalEnterpriseBLL.GetModel(int.Parse(Get_ID(generalEnterpriseBLL, strID)));
                txbCompanyName.Text = generalEnterpriseModel.CompanyName;//企业名称
                drpIndustryKey.SelectedValue = generalEnterpriseModel.IndustryKey;//所属行业
                ddlSheng.SelectedValue = generalEnterpriseModel.ShengCode;//企业所在省代码
                BindShi("1");
                ddlShi.SelectedValue = generalEnterpriseModel.ShiCode;//企业所在市代码
                BindXian("1");
                ddlXian.SelectedValue = generalEnterpriseModel.QuCode;//企业所在区代码
                txbPrincipleAddress.Text = generalEnterpriseModel.PrincipleAddress;//企业所在地址
                txbTelephone.Text = generalEnterpriseModel.Telephone;//联系电话
                txbTelephoneOther.Text = generalEnterpriseModel.TelephoneOther;//其他联系电话
                txbFax.Text = generalEnterpriseModel.Fax;//传真
                txbEmail.Text = generalEnterpriseModel.Email;//电子邮件
                txbContactPerson.Text = generalEnterpriseModel.ContactPerson;//联系人
                txbEnterpriseWWW.Text = generalEnterpriseModel.EnterpriseWWW;//企业网址
                txbBusRoute.Text = generalEnterpriseModel.BusRoute;//乘车路线
                if (generalEnterpriseModel.IsEmergencyRecruitment.ToString() == "0")
                {
                    ckbIsEmergencyRecruitment.Checked = false;
                }
                else
                {
                    ckbIsEmergencyRecruitment.Checked = true;
                }
                //是否允许职位发布
                if (generalEnterpriseModel.IsEnablePublishJob.ToString() == "1")
                {
                    ckbIsEnablePublishJob.Checked = true;
                }
                else
                {
                    ckbIsEnablePublishJob.Checked = false;
                }
                txbDownloadResume.Text = generalEnterpriseModel.DownloadResume.ToString();//允许陌生简历下载次数
                txbEnterpriseDescription.Text = generalEnterpriseModel.EnterpriseDescription;//企业简介
                ViewState["fileBusinessLicense"] = generalEnterpriseModel.BusinessLicense;//营业执照存储地址
                ViewState["CreateDate"] = generalEnterpriseModel.CreateDate.ToString();
                ViewState["EnterpriseGuid"] = generalEnterpriseModel.EnterpriseGuid.ToString();
                ViewState["UserGuid"] = generalEnterpriseModel.UserGuid.ToString();
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
                zlzw.Model.GeneralEnterpriseModel generalEnterpriseModel = new zlzw.Model.GeneralEnterpriseModel();
                generalEnterpriseModel.CompanyName = txbCompanyName.Text;//企业名称
                generalEnterpriseModel.IndustryKey = drpIndustryKey.SelectedValue;//所属行业
                generalEnterpriseModel.ShengCode = ddlSheng.SelectedValue;//企业所在省代码
                generalEnterpriseModel.ShiCode = ddlShi.SelectedValue;//企业所在市代码
                generalEnterpriseModel.QuCode = ddlXian.SelectedValue;//企业所在区代码
                generalEnterpriseModel.PrincipleAddress = txbPrincipleAddress.Text;//企业所在地址
                generalEnterpriseModel.Telephone = txbTelephone.Text;//联系电话
                generalEnterpriseModel.TelephoneOther = txbTelephoneOther.Text;//其他联系电话
                generalEnterpriseModel.Fax = txbFax.Text;//传真
                generalEnterpriseModel.Email = txbEmail.Text;//电子邮件
                generalEnterpriseModel.ContactPerson = txbContactPerson.Text;//联系人
                generalEnterpriseModel.EnterpriseWWW = txbEnterpriseWWW.Text;//企业网址
                generalEnterpriseModel.BusRoute = txbBusRoute.Text;//乘车路线
                generalEnterpriseModel.EnterpriseDescription = txbEnterpriseDescription.Text;//企业简介
                generalEnterpriseModel.CanUsable = 1;
                if (ckbIsEmergencyRecruitment.Checked)
                {
                    generalEnterpriseModel.IsEmergencyRecruitment = 1;
                }
                else
                {
                    generalEnterpriseModel.IsEmergencyRecruitment = 0;
                }
                //是否允许职位发布
                if (ckbIsEnablePublishJob.Checked)
                {
                    generalEnterpriseModel.IsEnablePublishJob = 1;
                }
                else
                {
                    generalEnterpriseModel.IsEnablePublishJob = 0;
                }
                generalEnterpriseModel.DownloadResume = int.Parse(txbDownloadResume.Text);//允许下载陌生简历数量
                generalEnterpriseModel.CreateDate = DateTime.Parse(ViewState["CreateDate"].ToString());
                zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
                generalEnterpriseModel.EnterpriseID = int.Parse(Get_ID(generalEnterpriseBLL, Request.QueryString["value"]));
                if (fileBusinessLicense.PostedFile.ContentLength > 0)
                {
                    fileBusinessLicense.SaveAs(Server.MapPath(ViewState["fileBusinessLicense"].ToString()));
                    generalEnterpriseModel.BusinessLicense = ViewState["fileBusinessLicense"].ToString();
                }
                else
                {
                    generalEnterpriseModel.BusinessLicense = ViewState["fileBusinessLicense"].ToString();
                }
                generalEnterpriseModel.UserGuid = new Guid(ViewState["UserGuid"].ToString());
                generalEnterpriseModel.EnterpriseGuid = new Guid(ViewState["EnterpriseGuid"].ToString());
                generalEnterpriseBLL.Update(generalEnterpriseModel);
            }
            else
            {
                //添加保存

                zlzw.Model.GeneralEnterpriseModel generalEnterpriseModel = new zlzw.Model.GeneralEnterpriseModel();
                generalEnterpriseModel.CompanyName = txbCompanyName.Text;//企业名称
                generalEnterpriseModel.IndustryKey = drpIndustryKey.SelectedValue;//所属行业
                generalEnterpriseModel.ShengCode = ddlSheng.SelectedValue;//企业所在省代码
                generalEnterpriseModel.ShiCode = ddlShi.SelectedValue;//企业所在市代码
                generalEnterpriseModel.QuCode = ddlXian.SelectedValue;//企业所在区代码
                generalEnterpriseModel.PrincipleAddress = txbPrincipleAddress.Text;//企业所在地址
                generalEnterpriseModel.Telephone = txbTelephone.Text;//联系电话
                generalEnterpriseModel.TelephoneOther = txbTelephoneOther.Text;//其他联系电话
                generalEnterpriseModel.Fax = txbFax.Text;//传真
                generalEnterpriseModel.Email = txbEmail.Text;//电子邮件
                generalEnterpriseModel.ContactPerson = txbContactPerson.Text;//联系人
                generalEnterpriseModel.EnterpriseWWW = txbEnterpriseWWW.Text;//企业网址
                generalEnterpriseModel.BusRoute = txbBusRoute.Text;//乘车路线
                generalEnterpriseModel.EnterpriseDescription = txbEnterpriseDescription.Text;//企业简介
                generalEnterpriseModel.CreateDate = DateTime.Now;//企业系统创建日期
                generalEnterpriseModel.CanUsable = 1;//可用
                generalEnterpriseModel.UserGuid = new Guid(Request.Cookies["UserID"].Value);
                if (ckbIsEmergencyRecruitment.Checked)
                {
                    generalEnterpriseModel.IsEmergencyRecruitment = 1;
                }
                else
                {
                    generalEnterpriseModel.IsEmergencyRecruitment = 0;
                }
                //是否允许职位发布
                //是否允许职位发布
                if (ckbIsEnablePublishJob.Checked)
                {
                    generalEnterpriseModel.IsEnablePublishJob = 1;
                }
                else
                {
                    generalEnterpriseModel.IsEnablePublishJob = 0;
                }
                generalEnterpriseModel.DownloadResume = int.Parse(txbDownloadResume.Text);//允许下载陌生简历数量
                generalEnterpriseModel.EnterpriseGuid = new Guid(ViewState["EnterpriseGuid"].ToString());
                generalEnterpriseModel.UserGuid = new Guid(Request.Cookies["UserID"].Value);
                if (fileBusinessLicense.PostedFile.ContentLength > 0)
                {
                    string fileName = DateTime.Now.Ticks.ToString() + "_" + fileBusinessLicense.FileName;
                    fileBusinessLicense.SaveAs(Server.MapPath("~/UploadImages/" + fileName));
                    generalEnterpriseModel.BusinessLicense = "~/UploadImages/" + fileName;//保存营业执照图片路径
                }
                zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
                generalEnterpriseBLL.Add(generalEnterpriseModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL, string strGUID)
        {
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["EnterpriseID"].ToString();
        }

        #endregion
    }
}