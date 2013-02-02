using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApp.Services
{
    /// <summary>
    /// ManageADImage 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class ManageADImage : System.Web.Services.WebService
    {
        [WebMethod]
        public string Get_ADImageList()
        {
            zlzw.BLL.ADImageListBLL aDImageListBLL = new zlzw.BLL.ADImageListBLL();
            System.Data.DataTable dt = aDImageListBLL.GetList("IsEnable=1 order by PublishDate desc").Tables[0];
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
            {
                if (dt.Rows[0]["ADLink"].ToString() == "")
                {
                    strBuilder.Append("<li><img src='" + dt.Rows[nCount]["ADImagePath"].ToString().Split('~')[1] + "'/></li>");
                }
                else
                {
                    strBuilder.Append("<li><a href='" + dt.Rows[nCount]["ADLink"].ToString().Split('~')[1] + "'><img style='border:0px;' src='" + dt.Rows[nCount]["ADImagePath"].ToString() + "'/></a></li>");
                }
            }
            return strBuilder.ToString();
        }
        

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
