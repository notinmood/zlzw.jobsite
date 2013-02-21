using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddPaidServices : System.Web.UI.Page
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
                zlzw.BLL.PaidServicesListBLL paidServicesListBLL = new zlzw.BLL.PaidServicesListBLL();
                zlzw.Model.PaidServicesListModel paidServicesListModel = paidServicesListBLL.GetModel(int.Parse(Get_ID(paidServicesListBLL, strID)));
                labPublishID.Text = Get_UserName(paidServicesListModel.PublishID.ToString());//发布人
                txbPublishJobCount.Text = paidServicesListModel.PublishJobCount.ToString();//职位发布数
                txbPublishJobPrice.Text = paidServicesListModel.PublishJobPrice.ToString();//职位发布价格
                txbMainResumeCount.Text = paidServicesListModel.MainResumeCount.ToString();//主投简历数
                txbMainResumePrice.Text = paidServicesListModel.MainResumePrice.ToString();//主投简历价格
                txbSearchStrangeResumeCount.Text = paidServicesListModel.SearchStrangeResumeCount.ToString();//查询陌生简历数
                txbSearchStrangeResumePrice.Text = paidServicesListModel.SearchStrangeResumePrice.ToString();//查询陌生简历价格
                txbDownloadStrangeResumeCount.Text = paidServicesListModel.DownloadStrangeResumeCount.ToString();//下载陌生简历数
                txbDownloadStrangeResumePrice.Text = paidServicesListModel.DownloadStrangeResumePrice.ToString();//下载陌生简历价格
                txbJobAdLargePrice.Text = paidServicesListModel.JobAdLargePrice.ToString();//名企招聘(大)
                txbJobAdSmallPrice.Text = paidServicesListModel.JobAdSmallPrice.ToString();//名企招聘(小)
                txbEmergencyRecruitmentPrice.Text = paidServicesListModel.EmergencyRecruitmentPrice.ToString();//紧急招聘价格
                ViewState["PaidServicesGUID"] = paidServicesListModel.PaidServicesGUID.ToString();
                ToolbarText2.Text = "编辑一个基本数据";
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
                zlzw.Model.PaidServicesListModel paidServicesListModel = new zlzw.Model.PaidServicesListModel();
                paidServicesListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);//发布人
                paidServicesListModel.PublishJobCount = int.Parse(txbPublishJobCount.Text);//职位发布数
                paidServicesListModel.PublishJobPrice = decimal.Parse(txbPublishJobPrice.Text);//职位发布价格
                paidServicesListModel.MainResumeCount = int.Parse(txbMainResumeCount.Text);//主投简历数
                paidServicesListModel.MainResumePrice = decimal.Parse(txbMainResumePrice.Text);//主投简历价格
                paidServicesListModel.SearchStrangeResumeCount = int.Parse(txbSearchStrangeResumeCount.Text);//查询陌生简历数
                paidServicesListModel.SearchStrangeResumePrice = decimal.Parse(txbSearchStrangeResumePrice.Text);//查询陌生简历价格
                paidServicesListModel.DownloadStrangeResumeCount = int.Parse(txbDownloadStrangeResumeCount.Text);//下载陌生简历数
                paidServicesListModel.DownloadStrangeResumePrice = decimal.Parse(txbDownloadStrangeResumePrice.Text);//下载陌生简历价格
                paidServicesListModel.JobAdLargePrice = decimal.Parse(txbJobAdLargePrice.Text);//名企招聘(大)
                paidServicesListModel.JobAdSmallPrice = decimal.Parse(txbJobAdSmallPrice.Text);//名企招聘(小)
                paidServicesListModel.EmergencyRecruitmentPrice = decimal.Parse(txbEmergencyRecruitmentPrice.Text);//紧急招聘价格
                paidServicesListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                paidServicesListModel.PaidServicesGUID = new Guid(ViewState["PaidServicesGUID"].ToString());
                zlzw.BLL.PaidServicesListBLL paidServicesListBLL = new zlzw.BLL.PaidServicesListBLL();
                paidServicesListModel.PaidServicesID = int.Parse(Get_ID(paidServicesListBLL, Request.QueryString["value"]));

                paidServicesListBLL.Update(paidServicesListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.PaidServicesListModel paidServicesListModel = new zlzw.Model.PaidServicesListModel();
                paidServicesListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);//发布人
                paidServicesListModel.PublishJobCount = int.Parse(txbPublishJobCount.Text);//职位发布数
                paidServicesListModel.PublishJobPrice = decimal.Parse(txbPublishJobPrice.Text);//职位发布价格
                paidServicesListModel.MainResumeCount = int.Parse(txbMainResumeCount.Text);//主投简历数
                paidServicesListModel.MainResumePrice = decimal.Parse(txbMainResumePrice.Text);//主投简历价格
                paidServicesListModel.SearchStrangeResumeCount = int.Parse(txbSearchStrangeResumeCount.Text);//查询陌生简历数
                paidServicesListModel.SearchStrangeResumePrice = decimal.Parse(txbSearchStrangeResumePrice.Text);//查询陌生简历价格
                paidServicesListModel.DownloadStrangeResumeCount = int.Parse(txbDownloadStrangeResumeCount.Text);//下载陌生简历数
                paidServicesListModel.DownloadStrangeResumePrice = decimal.Parse(txbDownloadStrangeResumePrice.Text);//下载陌生简历价格
                paidServicesListModel.JobAdLargePrice = decimal.Parse(txbJobAdLargePrice.Text);//名企招聘(大)
                paidServicesListModel.JobAdSmallPrice = decimal.Parse(txbJobAdSmallPrice.Text);//名企招聘(小)
                paidServicesListModel.EmergencyRecruitmentPrice = decimal.Parse(txbEmergencyRecruitmentPrice.Text);//紧急招聘价格
                paidServicesListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.PaidServicesListBLL paidServicesListBLL = new zlzw.BLL.PaidServicesListBLL();
                paidServicesListBLL.Add(paidServicesListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.PaidServicesListBLL paidServicesListBLL, string strGUID)
        {
            System.Data.DataTable dt = paidServicesListBLL.GetList("PaidServicesGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["PaidServicesID"].ToString();
        }

        #endregion

        #region 获取用户姓名

        private string Get_UserName(string strUserGUID)
        {
            zlzw.BLL.CoreUserBLL coreUserBLL = new zlzw.BLL.CoreUserBLL();
            System.Data.DataTable dt = coreUserBLL.GetList("UserGuid='"+ strUserGUID +"'").Tables[0];
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
    }
}