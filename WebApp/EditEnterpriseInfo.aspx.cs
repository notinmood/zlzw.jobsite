using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class EditEnterpriseRegisterInfo : Utility.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Load_ShengList();//加载省列表
                Load_EnterpriseInfo(Get_EnterpriseGUID(Request.QueryString["ID"]));
                labReceive.InnerText = Get_ReceiveCount(Request.Cookies["CurrentUserGUID"].Value) + " ";
                labView02.Text = " " + "<a style='font-size:14px;color:#fff;font-weight:bold;text-decoration:none;' target='_blank' href='AlreadyDownLoadResumeList.aspx?id=" + Request.QueryString["id"] + "&type=1'>查看简历</a>";
                labView01.Text = " " + "<a style='font-size:14px;color:#fff;font-weight:bold;text-decoration:none;' target='_blank' href='AlreadyDownLoadResumeList.aspx?id=" + Request.QueryString["id"] + "&type=0'>查看简历</a>";
                labJobPublish.InnerText = " " + Get_EnterpriseJobPublishCount(Request.Cookies["CurrentUserGUID"].Value) + " ";//发布职位数量
                labDownloadCount.InnerText = " " + Get_DownLoadCount(Request.Cookies["CurrentUserGUID"].Value) + " ";
                labAlreadyDownload.InnerText = " " + Get_AlreadyDownLoadCount(Request.Cookies["CurrentUserGUID"].Value) + " ";//已下载的简历数
            }
            catch (Exception exp)
            {
                Response.Redirect("default.aspx");
            }
        }

        #region 获取收到的简历数量

        private string Get_ReceiveCount(string strEnterpriseGUID)
        {
            zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();
            DataTable dt = resumeCollectionListBLL.GetList("ResumeCollectionType=1 and EnterpriseGuid='" + strEnterpriseGUID + "' and EnterpriseIsDel=1 and IsEnable=1 order by PublishDate desc").Tables[0];

            return dt.Rows.Count.ToString();
        }

        #endregion

        #region 企业发布职位数量

        private string Get_EnterpriseJobPublishCount(string strEnterpriseGUID)
        {
            zlzw.BLL.JobEnterpriseJobPositionBLL jobEnterpriseJobPositionBLL = new zlzw.BLL.JobEnterpriseJobPositionBLL();
            System.Data.DataTable dt = jobEnterpriseJobPositionBLL.GetList("EnterpriseKey='" + strEnterpriseGUID + "' and JobPositionStatus=1 and CanUsable=1").Tables[0];

            return dt.Rows.Count.ToString();
        }

        #endregion

        #region 获取当前企业已下载简历数量

        private string Get_AlreadyDownLoadCount(string strEnterpriseGUID)
        {
            zlzw.BLL.ResumeCollectionListBLL resumeCollectionListBLL = new zlzw.BLL.ResumeCollectionListBLL();
            DataTable dt = resumeCollectionListBLL.GetList("ResumeCollectionType=0 and EnterpriseGuid='" + strEnterpriseGUID + "' and ResumeCollectionType=0 and EnterpriseIsDel=1 and IsEnable=1 order by PublishDate desc").Tables[0];


            return dt.Rows.Count.ToString();
        }

        #endregion

        #region 获取当前企业剩余下载简历数

        private string Get_DownLoadCount(string strEnterpriseGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            System.Data.DataTable dt = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strEnterpriseGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["DownloadResume"].ToString();
            }
            else
            {
                return "0";
            }
        }

        #endregion

        #region 加载省份信息

        private void Load_ShengList()
        {
            drpShengList.DataSource = SHENG_JSON;
            drpShengList.DataBind();

            drpShengList.Items.Insert(0, new ListItem("选择省份", "-1"));
        }

        #endregion

        #region 加载选中的市列表

        private void Load_ShiList(string strSheng)
        {
            if (strSheng != "-1")
            {
                JArray ja = SHI_JSON.Value<JArray>(strSheng); // .getJSONArray(sheng);
                drpShiList.DataSource = ja;
                drpShiList.DataBind();
            }
        }

        #endregion

        #region 加载选中的区列表

        private void Load_QuList(string strQu)
        {
            if (strQu != "-1")
            {
                JArray ja = XIAN_JSON.Value<JArray>(strQu); //.getJSONArray(shi);
                drpQuList.DataSource = ja;
                drpQuList.DataBind();
            }
        }

        #endregion

        #region 加载行业分类（小类）

        private void LoadItemList(string strType)
        {
            //zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            //System.Data.DataTable dt = generalBasicSettingBLL.GetList("DisPlayName='"+ strType +"'").Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    drpItems.DataTextField = "SettingValue";
            //    drpItems.DataValueField = "SettingValue";
            //    drpItems.DataSource = dt;
            //    drpItems.DataBind();
            //}
        }

        #endregion

        #region 加载企业信息

        private void Load_EnterpriseInfo(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt01 = generalEnterpriseBLL.GetList("EnterpriseGuid='" + strUserGUID + "'").Tables[0];
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            DataTable dt = coreUserBLL.GetList("UserGuid='" + dt01.Rows[0]["UserGuid"].ToString() + "'").Tables[0];
            zlzw.Model.CoreUserModel coreUserModel = coreUserBLL.GetModel(int.Parse(dt.Rows[0]["UserID"].ToString()));
            
            zlzw.Model.GeneralEnterpriseModel generalEnterpriseModel = generalEnterpriseBLL.GetModel(int.Parse(dt01.Rows[0]["EnterpriseID"].ToString()));
            txbUserName.Text = coreUserModel.UserName;//账号
            txbEnterpriseName.Text = generalEnterpriseModel.CompanyName;//公司名称
            //drpJobFeildKindsType.SelectedValue = generalEnterpriseModel.IndustryKey.Split('-')[0];//所属行业
            //LoadItemList(generalEnterpriseModel.IndustryKey.Split('-')[0]);
            //drpItems.SelectedValue = generalEnterpriseModel.IndustryKey.Split('-')[1];//所属行业分类
            txbJobFeildKinds.Value = generalEnterpriseModel.IndustryKey;//所属行业分类
            drpShengList.SelectedValue = generalEnterpriseModel.ShengName;
            Load_ShiList(generalEnterpriseModel.ShengName);
            drpShiList.SelectedValue = generalEnterpriseModel.ShiName;
            Load_QuList(generalEnterpriseModel.ShiName);
            drpQuList.SelectedValue = generalEnterpriseModel.QuName;

            txbPrincipleAddress.Text = generalEnterpriseModel.PrincipleAddress;//公司地址
            txbTelephone.Text = generalEnterpriseModel.Telephone;//联系电话
            txbContactPerson.Text = generalEnterpriseModel.ContactPerson;//联系人
            txbUserMobileNO.Text = coreUserModel.UserMobileNO;//手机号码
            txbEmail.Text = generalEnterpriseModel.Email;//邮箱地址
            txbEnterpriseWWW.Text = generalEnterpriseModel.EnterpriseWWW;//企业网址
            txbBusRoute.Text = generalEnterpriseModel.BusRoute;//乘车路线
            drpShengList.SelectedValue = generalEnterpriseModel.ShengName;//省名称
            drpShiList.SelectedValue = generalEnterpriseModel.ShiName;//市名称
            drpQuList.SelectedValue = generalEnterpriseModel.QuName;//区名称
            txbEnterpriseDescription.Text = generalEnterpriseModel.EnterpriseDescription;//企业简介
            ViewState["CreateDate"] = generalEnterpriseModel.CreateDate.ToString();//创建日期
            ViewState["uploadBusinessLicense"] = generalEnterpriseModel.BusinessLicense;//营业执照
            ViewState["UserRegisterDate"] = DateTime.Parse(coreUserModel.UserRegisterDate.ToString());//CoreUser注册时间
            ViewState["UserLastDateTime"] = DateTime.Parse(coreUserModel.UserRegisterDate.ToString());//CoreUser最后一次登陆时间
        }

        #endregion

        #region 提交按钮事件

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["EditIsEnterpriseSubmit"] != null)
            {
                return;
            }
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            DataTable dt = coreUserBLL.GetList("UserGuid='" + Request.QueryString["ID"] + "'").Tables[0];
            zlzw.Model.CoreUserModel coreUserModel = coreUserBLL.GetModel(int.Parse(dt.Rows[0]["UserID"].ToString()));
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt01 = generalEnterpriseBLL.GetList("UserGuid='" + Request.QueryString["ID"] + "'").Tables[0];
            zlzw.Model.GeneralEnterpriseModel generalEnterpriseModel = generalEnterpriseBLL.GetModel(int.Parse(dt01.Rows[0]["EnterpriseID"].ToString()));
            coreUserModel.UserName = Request.Form["txbUserName"];//账号
            coreUserModel.Password = Request.Form["txbPassword"];//密码
            coreUserModel.UserMobileNO = Request.Form["txbUserMobileNO"];//手机号
            coreUserModel.UserRegisterDate = DateTime.Parse(ViewState["UserRegisterDate"].ToString());//用户注册日期
            coreUserModel.UserLastDateTime = DateTime.Parse(ViewState["UserLastDateTime"].ToString());//用户最后一次登录日期
            coreUserModel.UserType = 2;//企业用户
            coreUserModel.UserStatus = 1;//状态可用
            coreUserModel.UserID = int.Parse(dt.Rows[0]["UserID"].ToString());//CoerUser表ID

            generalEnterpriseModel.EnterpriseID = int.Parse(dt01.Rows[0]["EnterpriseID"].ToString());//企业表ID
            generalEnterpriseModel.CompanyName = txbEnterpriseName.Text;//企业名称
            //generalEnterpriseModel.IndustryKey = Request.Form["drpJobFeildKindsType"] + "-" + Request.Form["drpItems"];//公司行业
            generalEnterpriseModel.IndustryKey = Get_CurrentValue(Request.Params["txbJobFeildKinds"]) + "-" + Request.Params["txbJobFeildKinds"];
            generalEnterpriseModel.PrincipleAddress = Request.Form["txbPrincipleAddress"];//公司地址
            generalEnterpriseModel.Telephone = Request.Form["txbTelephone"];//联系电话
            generalEnterpriseModel.ContactPerson = Request.Form["txbContactPerson"];//联系人
            generalEnterpriseModel.Email = Request.Form["txbEmail"];//电子邮件
            generalEnterpriseModel.EnterpriseWWW = Request.Form["txbEnterpriseWWW"];//公司网站
            generalEnterpriseModel.BusRoute = Request.Form["txbBusRoute"];//乘车路线
            generalEnterpriseModel.CanUsable = 1;
            generalEnterpriseModel.LastUpdateDate = DateTime.Now;//最后一次修改日期
            generalEnterpriseModel.CreateDate = DateTime.Parse(ViewState["CreateDate"].ToString());//创建日期
            generalEnterpriseModel.ShengName = Request.Form["drpShengList"];//省名称
            generalEnterpriseModel.ShiName = Request.Form["drpShiList"];//市名称
            generalEnterpriseModel.QuName = Request.Form["drpQuList"];//区名称
            generalEnterpriseModel.EnterpriseDescription = Request.Form["txbEnterpriseDescription"];//企业简介

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
                coreUserBLL.Update(coreUserModel);
                generalEnterpriseBLL.Update(generalEnterpriseModel);
                if (Session["EditIsEnterpriseSubmit"] == null)
                {
                    FineUI.Alert.Show("修改信息注册成功");
                    Session["EditIsEnterpriseSubmit"] = "1";
                }
                System.Web.HttpCookie UserGUID = System.Web.HttpContext.Current.Request.Cookies["CurrentUserGUID"];
                System.Web.HttpCookie UserName = System.Web.HttpContext.Current.Request.Cookies["CurrentUserName"];

                UserGUID.Expires = DateTime.Now.AddDays(-1);
                UserName.Expires = DateTime.Now.AddDays(-1);

                System.Web.HttpContext.Current.Response.Cookies.Add(UserGUID);
                System.Web.HttpContext.Current.Response.Cookies.Add(UserName);
                Response.Redirect("default.aspx");
            }
            catch (Exception exp)
            {
                FineUI.Alert.Show("修改信息失败，请稍后重试");
            }
        }

        #endregion

        #region 获取企业GUID

        private string Get_EnterpriseGUID(string strUserGUID)
        {
            zlzw.BLL.GeneralEnterpriseBLL generalEnterpriseBLL = new zlzw.BLL.GeneralEnterpriseBLL();
            DataTable dt = generalEnterpriseBLL.GetList("UserGuid='" + strUserGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["EnterpriseGuid"].ToString();
            }
            else
            {
                return "未知";
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