using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApp.Services
{
    /// <summary>
    /// GetGeneralBasicSetting 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class GetGeneralBasicSetting : System.Web.Services.WebService
    {
        /// <summary>
        /// 根据职位类别获取具体职位列表
        /// </summary>
        /// <param name="strJobPositionKindsType">选中的职位类别</param>
        /// <returns></returns>
        [WebMethod]
        public string Get_JobPositionKindsList(string strJobPositionKindsType)
        {
            zlzw.BLL.GeneralBasicSettingBLL generalBasicSettingBLL = new zlzw.BLL.GeneralBasicSettingBLL();
            System.Data.DataTable dt = generalBasicSettingBLL.GetList("DisplayName='" + strJobPositionKindsType + "'").Tables[0];

            if (dt.Rows.Count > 0)
            {
                System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
                string strTemp = "";
                for (int nCount = 0; nCount < dt.Rows.Count; nCount++)
                {
                    strTemp = dt.Rows[nCount]["SettingValue"].ToString();
                    strBuilder.Append("<option value='" + strTemp + "'>" + strTemp + "</option>");
                }

                return strBuilder.ToString();
            }
            else
            {
                return "-1";
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
