using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace WebApp
{
    public partial class EnterpriseRegister : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_HangYeList();
                Load_ShengList();//加载省列表
            }
        }

        #region 加载省份信息

        private void Load_ShengList()
        {
            drpShengList.DataSource = SHENG_JSON;
            drpShengList.DataBind();

            drpShengList.Items.Insert(0, new ListItem("选择省份", "-1"));
        }

        #endregion

        #region 加载行业类别（小类）

        private void Load_HangYeList()
        {
            //zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            //System.Data.DataTable dt = generalBasicSettingBLL.GetList("DisplayName='"+ drpJobFeildKindsType.SelectedValue +"'").Tables[0];
            //drpItems.DataTextField = "SettingValue";
            //drpItems.DataValueField = "SettingValue";

            //drpItems.DataSource = dt;
            //drpItems.DataBind();
        }

        #endregion

        #region 提交按钮事件

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["IsEnterpriseSubmit"] != null)
            {
                return;
            }
            zlzw.Model.CoreUserModel coreUserModel = new zlzw.Model.CoreUserModel();
            coreUserModel.UserGuid = Guid.NewGuid();
            coreUserModel.UserName = Request.Form["txbUserName"];//账号
            coreUserModel.Password = Request.Form["txbPassword"];//密码
            coreUserModel.UserMobileNO = Request.Form["txbUserMobileNO"];//手机号
            coreUserModel.UserRegisterDate = DateTime.Now;//用户注册日期
            coreUserModel.UserLastDateTime = DateTime.Now;//用户最后一次登录日期
            coreUserModel.UserType = 2;//企业用户
            coreUserModel.UserStatus = 1;//状态可用

            zlzw.Model.GeneralEnterpriseModel generalEnterpriseModel = new zlzw.Model.GeneralEnterpriseModel();
            generalEnterpriseModel.UserGuid = new Guid(coreUserModel.UserGuid.ToString());//所属账号的GUID
            generalEnterpriseModel.CompanyName = Request.Form["txbEnterpriseName"];//企业名称
            //generalEnterpriseModel.IndustryKey = drpJobFeildKindsType.SelectedValue + "-" + Request.Params["drpItems"];//公司行业
            generalEnterpriseModel.IndustryKey = Get_CurrentValue(Request.Params["txbJobFeildKinds"]) + "-" + Request.Params["txbJobFeildKinds"];//行业类别
            generalEnterpriseModel.PrincipleAddress = Request.Form["txbPrincipleAddress"];//公司地址
            generalEnterpriseModel.Telephone = Request.Form["txbTelephone"];//联系电话
            generalEnterpriseModel.ContactPerson = Request.Form["txbContactPerson"];//联系人
            generalEnterpriseModel.Email = Request.Form["txbEmail"];//电子邮件
            generalEnterpriseModel.EnterpriseWWW = Request.Form["txbEnterpriseWWW"];//公司网站
            generalEnterpriseModel.BusRoute = Request.Form["txbBusRoute"];//乘车路线
            generalEnterpriseModel.CanUsable = 1;
            generalEnterpriseModel.CreateDate = DateTime.Now;//创建日期
            //添加所在省市区信息
            generalEnterpriseModel.ShengName = Request.Form["drpShengList"];//省名称
            generalEnterpriseModel.ShiName = Request.Form["drpShiList"];//市名称
            generalEnterpriseModel.QuName = Request.Form["drpQuList"];//区名称
            generalEnterpriseModel.EnterpriseDescription = Request.Form["txbEnterpriseDescription"];//企业简介
            ////设置企业基本数据
            //generalEnterpriseModel.Expand_PublishJobCount = 0;//企业已发布的职位数
            //generalEnterpriseModel.Expand_MainResumeCount = 0;//企业已查看主投简历数
            //generalEnterpriseModel.Expand_SearchStrangeResumeCount = 0;//企业已搜索陌生简历数
            //generalEnterpriseModel.Expand_DownloadStrangeResumeCount = 0;//企业已下载陌生简历数量
            //generalEnterpriseModel.Expand_Balance = 0;//企业充值金额
            generalEnterpriseModel.IsEmergencyRecruitment = 0;//默认不允许企业发布紧急招聘
            generalEnterpriseModel.DownloadResume = 0;//默认下载陌生简历次数为0
            if (uploadBusinessLicense.HasFile)
            {
                string strFileExt = System.IO.Path.GetExtension(uploadBusinessLicense.FileName);
                if (strFileExt == ".jpg" || strFileExt == ".gif" || strFileExt == ".png" || strFileExt == ".jpeg" || strFileExt == ".bmp")
                {
                    string strFilePath = "~/BusinessLicense/" + txbEnterpriseName.Text + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + strFileExt;
                    uploadBusinessLicense.SaveAs(Server.MapPath(strFilePath));
                    generalEnterpriseModel.BusinessLicense = strFilePath;
                }
            }
            try
            {
                zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
                coreUserBLL.Add(coreUserModel);
                zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
                generalEnterpriseBLL.Add(generalEnterpriseModel);
                if (Session["IsEnterpriseSubmit"] == null)
                {
                    FineUI.Alert.Show("用户注册成功");
                    Session["IsEnterpriseSubmit"] = "1";
                }
                HttpCookie userGUID = new HttpCookie("CurrentUserGUID", coreUserModel.UserGuid.ToString());
                HttpCookie uerName = new HttpCookie("CurrentUserName", coreUserModel.UserName);
                userGUID.Expires = DateTime.Now.AddDays(1);
                uerName.Expires = DateTime.Now.AddDays(1);
                System.Web.HttpContext.Current.Response.Cookies.Add(userGUID);
                System.Web.HttpContext.Current.Response.Cookies.Add(uerName);
                Response.Redirect("default.aspx");
            }
            catch (Exception exp)
            {
                FineUI.Alert.Show("用户注册失败，请稍后重试");
            }
        }

        #endregion

        #region 获取当前职位类别的大类

        private string Get_CurrentValue(string strValue)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("SettingValue='" + strValue + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["DisplayName"].ToString();
            }
            else
            {
                return "未知";
            }
        }

        #endregion
    }
}