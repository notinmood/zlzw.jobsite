using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class CareerGuidanceInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string strID = Request.QueryString["id"];
                    Load_CareerGuidanceContent(strID);
                }
                catch (Exception exp)
                {
                    Response.Redirect("CareerGuidanceList.aspx");
                }
            }
        }

        #region 加载就业指导内容

        private void Load_CareerGuidanceContent(string strGUID)
        {
            int nCareerGuidanceID = int.Parse(Get_CareerGuidanceID(strGUID));
            if (nCareerGuidanceID == -1)
            {
                Response.Redirect("CareerGuidanceList.aspx");
            }
            else
            {
                zlzw.BLL.CareerGuidanceListBLL careerGuidanceListBLL = new zlzw.BLL.CareerGuidanceListBLL();
                zlzw.Model.CareerGuidanceListModel careerGuidanceListModel = careerGuidanceListBLL.GetModel(nCareerGuidanceID);
                labNavigateTitle.Text = careerGuidanceListModel.CareerGuidanceTitle;
                labNavTitle.Text = careerGuidanceListModel.CareerGuidanceTitle;
                labTitle.Text = careerGuidanceListModel.CareerGuidanceTitle;
                labPublishDate.Text = DateTime.Parse(careerGuidanceListModel.PublishDate.ToString()).ToString("yyyy年MM月dd日");
                labContent.Text = careerGuidanceListModel.CareerGuidanceContent;
            }
        }

        #endregion

        #region 获取就业指导ID

        private string Get_CareerGuidanceID(string strCareerGuidanceGUID)
        {
            zlzw.BLL.CareerGuidanceListBLL careerGuidanceListBLL = new zlzw.BLL.CareerGuidanceListBLL();
            System.Data.DataTable dt = careerGuidanceListBLL.GetList("CareerGuidanceGUID='" + strCareerGuidanceGUID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["CareerGuidanceID"].ToString();
            }
            else
            {
                return "-1";
            }
        }

        #endregion
    }
}