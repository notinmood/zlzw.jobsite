using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class EnterpriseRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
            generalEnterpriseModel.IndustryKey = drpJobFeildKindsType.SelectedValue;//公司行业
            generalEnterpriseModel.PrincipleAddress = Request.Form["txbPrincipleAddress"];//公司地址
            generalEnterpriseModel.Telephone = Request.Form["txbTelephone"];//联系电话
            generalEnterpriseModel.ContactPerson = Request.Form["txbContactPerson"];//联系人
            generalEnterpriseModel.Email = Request.Form["txbEmail"];//电子邮件
            generalEnterpriseModel.EnterpriseWWW = Request.Form["txbEnterpriseWWW"];//公司网站
            generalEnterpriseModel.BusRoute = Request.Form["txbBusRoute"];//乘车路线
            generalEnterpriseModel.CanUsable = 1;
            generalEnterpriseModel.CreateDate = DateTime.Now;//创建日期

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
    }
}