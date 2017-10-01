using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cookie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSaveCookie_Click(object sender, EventArgs e)
    {
        // 利用HttpCookie来保存Cookie
        HttpCookie cookie = new HttpCookie("userInfo");

        cookie.Values["UserName"]      = txtName.Text.Trim();
        cookie.Values["UserEmail"]     = txtEmail.Text.Trim();
        cookie.Values["UserTelephone"] = txtTelephone.Text.Trim();

        txtName.Text = "";
        txtEmail.Text = "";
        txtTelephone.Text = "";

        // 指定Cookie保存时间，否则保存在浏览器进程的内存中
        //cookie.Expires = System.DateTime.Now.AddHours(1);

        Response.Cookies.Add(cookie);
    }

    protected void btnViewCookie_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["userInfo"];

        if (cookie != null)
        {
            string userName      = cookie["UserName"];
            string userEmail     = cookie["UserEmail"];
            string userTelephone = cookie["UserTelephone"];

            if (userName != null && userEmail != null && userTelephone != null)
            {
                txtName.Text      = Server.HtmlEncode(userName);
                txtEmail.Text     = Server.HtmlEncode(userEmail);
                txtTelephone.Text = Server.HtmlEncode(userTelephone);
            }
        }
    }
}