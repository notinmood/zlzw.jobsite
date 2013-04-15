using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace WebApp
{
    public partial class VerifyCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VryImgGen gen = new VryImgGen();
            string verifyCode = gen.CreateVerifyCode(4,0);
            HttpCookie cookie = new HttpCookie("VerifyCode", verifyCode.ToUpper());
            cookie.Expires = DateTime.Now.AddSeconds(3000);//过期时间为60秒
            Response.Cookies.Add(cookie);
            System.Drawing.Bitmap bitmap = gen.CreateImage(verifyCode);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Response.Clear();
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms.GetBuffer());
            bitmap.Dispose();
            ms.Dispose();
            ms.Close();
            Response.End();
        }
    }
}
