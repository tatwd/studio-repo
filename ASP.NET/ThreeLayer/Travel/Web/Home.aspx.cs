using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using BLL;

namespace Web
{
    public partial class Home2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] == null)
            {
                SignOutLb.Style["display"] = "none";
            }
            else
            {
                SignInLb.Style["display"] = "none";
                SignUpLb.Style["display"] = "none";
            }

            ListArticle.DataSource = ArticleService.GetArticle(10);

            ListArticle.DataBind();
        }

        protected void SignOutLb_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect(Request.Url.ToString());

            //SignOutLb.Style["display"] = "none";
            //SignInLb.Style["display"] = "block";
            //SignUpLb.Style["display"] = "block";
        }
    }
}