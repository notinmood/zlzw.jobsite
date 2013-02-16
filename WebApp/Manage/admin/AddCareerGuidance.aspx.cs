using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddCareerGuidance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserID"] != null)
                {
                    labPublishID.Text = Get_UserName(Request.Cookies["UserID"].Value);
                }
                string strType = Request.QueryString["Type"];
                LoadData(strType);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
            Panel2.Title = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        #region 根据用户GUID获取用户名称

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

        #region 加载就业指导信息

        private void LoadData(string strType)
        {
            if (strType == "1")
            {
                string strID = Request.QueryString["value"];//操作ID
                zlzw.BLL.CareerGuidanceListBLL careerGuidanceListBLL = new zlzw.BLL.CareerGuidanceListBLL();
                zlzw.Model.CareerGuidanceListModel careerGuidanceListModel = careerGuidanceListBLL.GetModel(int.Parse(Get_ID(careerGuidanceListBLL, strID)));
                txbCareerGuidanceTitle.Text = careerGuidanceListModel.CareerGuidanceTitle;//就业指导标题
                if (careerGuidanceListModel.IsHot == 0)
                {
                    ckbIsHot.Checked = false;
                }
                else
                {
                    ckbIsHot.Checked = true;
                }
                txbCareerGuidanceContent.Text = careerGuidanceListModel.CareerGuidanceContent;//就业指导正文
                ViewState["PublishDate"] = careerGuidanceListModel.PublishDate.ToString();
                ViewState["CareerGuidanceGUID"] = careerGuidanceListModel.CareerGuidanceGUID.ToString();
                ToolbarText2.Text = "编辑一条就业指导";
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
                zlzw.Model.CareerGuidanceListModel careerGuidanceListModel = new zlzw.Model.CareerGuidanceListModel();
                careerGuidanceListModel.CareerGuidanceTitle = txbCareerGuidanceTitle.Text;
                careerGuidanceListModel.CareerGuidanceContent = txbCareerGuidanceContent.Text;
                if (ckbIsHot.Checked)
                {
                    careerGuidanceListModel.IsHot = 1;
                }
                else
                {
                    careerGuidanceListModel.IsHot = 0;
                }
                if (Request.Cookies["UserID"] != null)
                {
                    careerGuidanceListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);
                }
                careerGuidanceListModel.IsEnable = 1;
                careerGuidanceListModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                careerGuidanceListModel.CareerGuidanceGUID = new Guid(ViewState["CareerGuidanceGUID"].ToString());
                zlzw.BLL.CareerGuidanceListBLL careerGuidanceListBLL = new zlzw.BLL.CareerGuidanceListBLL();
                careerGuidanceListModel.CareerGuidanceID = int.Parse(Get_ID(careerGuidanceListBLL, Request.QueryString["value"]));

                careerGuidanceListBLL.Update(careerGuidanceListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.CareerGuidanceListModel careerGuidanceListModel = new zlzw.Model.CareerGuidanceListModel();
                careerGuidanceListModel.CareerGuidanceTitle = txbCareerGuidanceTitle.Text;
                careerGuidanceListModel.CareerGuidanceContent = txbCareerGuidanceContent.Text;
                careerGuidanceListModel.IsEnable = 1;
                if (Request.Cookies["UserID"] != null)
                {
                    careerGuidanceListModel.PublishID = new Guid(Request.Cookies["UserID"].Value);
                }
                if (ckbIsHot.Checked)
                {
                    careerGuidanceListModel.IsHot = 1;
                }
                else
                {
                    careerGuidanceListModel.IsHot = 0;
                }
                careerGuidanceListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.CareerGuidanceListBLL careerGuidanceListBLL = new zlzw.BLL.CareerGuidanceListBLL();
                careerGuidanceListBLL.Add(careerGuidanceListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.CareerGuidanceListBLL careerGuidanceListBLL, string strGUID)
        {
            System.Data.DataTable dt = careerGuidanceListBLL.GetList("CareerGuidanceGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["CareerGuidanceID"].ToString();
        }

        #endregion
    }
}