using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChatLogin : System.Web.UI.Page
{
    // 存用户名和密码
    string[,] user =
    {
        { "张三", "111111" },
        { "王五", "111111" },
        { "李四", "111111" }
    };

    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Focus();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 2; i++)
        {
            if (txtName.Text == user[i, 0] && txtPassword.Text == user[i, 1])
            {
                Session["user"] = user[i, 0];    // 将用户名存入Session变量user
                Response.Redirect("Chat.aspx");  // 页面重定向到Chat.aspx
            }
        }

        Response.Write("<script>alert('用户名或密码错误！');</script>");
    }
}