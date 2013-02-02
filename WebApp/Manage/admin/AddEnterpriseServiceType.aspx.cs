using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WebApp.Manage.admin
{
    public partial class AddEnterpriseServiceType : System.Web.UI.Page
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
                zlzw.BLL.EnterpriseServiceTypeListBLL enterpriseServiceTypeListBLL = new zlzw.BLL.EnterpriseServiceTypeListBLL();
                zlzw.Model.EnterpriseServiceTypeListModel enterpriseServiceTypeListModel     = enterpriseServiceTypeListBLL.GetModel(int.Parse(Get_ID(enterpriseServiceTypeListBLL, strID)));
                txbEnterpriseServiceTypeName.Text = enterpriseServiceTypeListModel.EnterpriseServiceTypeName;//服务名称
                txbOrderNumber.Text = enterpriseServiceTypeListModel.OrderNumber.ToString();//排序号
                if (enterpriseServiceTypeListModel.IsHot == 1)
                {
                    ckbIsHot.Checked = true;
                }
                else
                {
                    ckbIsHot.Checked = false; ;
                }
                ViewState["PublishDate"] = enterpriseServiceTypeListModel.PublishDate.ToString();
                ViewState["EnterpriseServiceTypeGUID"] = enterpriseServiceTypeListModel.EnterpriseServiceTypeGUID.ToString();
                ToolbarText2.Text = "编辑一个企业服务类型";
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
                zlzw.Model.EnterpriseServiceTypeListModel enterpriseServiceTypeListModel = new zlzw.Model.EnterpriseServiceTypeListModel();
                enterpriseServiceTypeListModel.EnterpriseServiceTypeName = txbEnterpriseServiceTypeName.Text;
                enterpriseServiceTypeListModel.OrderNumber = int.Parse(txbOrderNumber.Text);
                if (ckbIsHot.Checked)
                {
                    enterpriseServiceTypeListModel.IsHot = 1;
                }
                else
                {
                    enterpriseServiceTypeListModel.IsHot = 0;
                }
                enterpriseServiceTypeListModel.IsEnable = 1;
                enterpriseServiceTypeListModel.PublishDate = DateTime.Parse(ViewState["PublishDate"].ToString());
                enterpriseServiceTypeListModel.EnterpriseServiceTypeGUID = new Guid(ViewState["EnterpriseServiceTypeGUID"].ToString());
                zlzw.BLL.EnterpriseServiceTypeListBLL enterpriseServiceTypeListBLL = new zlzw.BLL.EnterpriseServiceTypeListBLL();
                enterpriseServiceTypeListModel.EnterpriseServiceTypeID = int.Parse(Get_ID(enterpriseServiceTypeListBLL, Request.QueryString["value"]));

                enterpriseServiceTypeListBLL.Update(enterpriseServiceTypeListModel);
            }
            else
            {
                //添加保存

                zlzw.Model.EnterpriseServiceTypeListModel enterpriseServiceTypeListModel = new zlzw.Model.EnterpriseServiceTypeListModel();
                enterpriseServiceTypeListModel.EnterpriseServiceTypeName = txbEnterpriseServiceTypeName.Text;
                enterpriseServiceTypeListModel.OrderNumber = int.Parse(txbOrderNumber.Text);
                if (ckbIsHot.Checked)
                {
                    enterpriseServiceTypeListModel.IsHot = 1;
                }
                else
                {
                    enterpriseServiceTypeListModel.IsHot = 0;
                }
                enterpriseServiceTypeListModel.IsEnable = 1;
                enterpriseServiceTypeListModel.PublishDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                zlzw.BLL.EnterpriseServiceTypeListBLL enterpriseServiceTypeListBLL = new zlzw.BLL.EnterpriseServiceTypeListBLL();
                enterpriseServiceTypeListBLL.Add(enterpriseServiceTypeListModel);
            }

            // 2. Close this window and Refresh parent window
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #endregion

        #region 根据GUID获取ID

        private string Get_ID(zlzw.BLL.EnterpriseServiceTypeListBLL enterpriseServiceTypeListBLL, string strGUID)
        {
            System.Data.DataTable dt = enterpriseServiceTypeListBLL.GetList("EnterpriseServiceTypeGUID='" + strGUID + "'").Tables[0];
            return dt.Rows[0]["EnterpriseServiceTypeID"].ToString();
        }

        #endregion
    }
}