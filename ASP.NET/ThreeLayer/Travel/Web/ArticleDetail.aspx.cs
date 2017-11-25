using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Model;
using BLL;

namespace Web
{
    public partial class ArticleDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] != null)
            {
                CmntContent.Attributes.Remove("disabled");
                CmntContent.Attributes["placeholder"] = "请输入文字（不得超过100个字）";

                SubmitCmnt.Attributes.Remove("disabled");

                SignOutLb.Style["display"] = "block";

                SignInLb.Style["display"] = "none";
                SignUpLb.Style["display"] = "none";

                TipText.Style["display"] = "none";
            }
            else
            {
                //CmntContent.Attributes["disabled"] = "true";
                CmntContent.Attributes["placeholder"] = "请先登录，再进行评论！";

                //SubmitCmnt.Attributes["disabled"] = "true";
                
                SignOutLb.Style["display"] = "none";

                ReplyMainBox.Style["display"] = "none";
            }


            if (Request.QueryString.Count != 0)
            {
                int id = GetId();

                SetArticleToPage(id);

                SetCmntToPage(id);
            }
            else
            {
                hTitle.InnerText = "未设置查询字符串！";
            }

            
        }

        protected void SetArticleToPage(int id)
        {
            if (id == -1)
            {
                hTitle.InnerText = "查询字符串为空！";
                return;
            }

            Article article = ArticleService.GetArtCleById(id);

            if (article != null)
            {
                hTitle.InnerText   = article.Title;
                hAuthor.InnerText  = article.Username + "/文";
                pContent.InnerText = article.Content;
            }
        }

        protected void SetCmntToPage(int id)
        {
            DataTable data = CommentService.GetSameCmntToArticle(id);

            ListCmnt.DataSource = data;
            ListCmnt.DataBind();
        }

        // 提交评论
        protected void SubmitCmnt_Click(object sender, EventArgs e)
        {
            string cmntContent = CmntContent.Text;

            if (cmntContent == "")
            {
                CmntContent.Attributes["placeholder"] = "输入内容不能为空！";

                return;
            }

            Comment cmnt = new Comment();

            cmnt.ArticleId = GetId();
            cmnt.Username = Session["Username"].ToString();
            cmnt.Content = cmntContent;
            cmnt.CmntTime = DateTime.Now.ToLocalTime();

            bool isOk = CommentService.AddCmnt(cmnt);

            if (isOk)
            {
                SetArticleToPage(GetId());

                Response.Redirect(Request.Url.ToString()); // 刷新本页
            }

        }

        protected int GetId()
        {
            string _articleId = Request.QueryString["articleId"].Trim();

            int id = (_articleId != "") ? int.Parse(_articleId) : -1;

            return id;
        }

        // 注销
        protected void SignOutLb_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect(Request.Url.ToString());
        }
    }
}