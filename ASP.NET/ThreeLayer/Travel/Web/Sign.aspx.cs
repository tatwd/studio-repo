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
    public partial class Home1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                display.InnerText = "你已经登录了！";
                return;
            }

            string username = UsernameTb.Text.Trim();
            string password = PasswordTb.Text.Trim();

            UserInfo user = UserInfoService.SignIn(username, password);

            if (user != null)
            {
                Session["Username"] = user.Username;
                Response.Redirect("Home.aspx");
            }
            else
            {
                display.InnerText = "用户名或密码错误！";
            }
        }

        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTb.Text.Trim();
            string password = PasswordTb.Text.Trim();

            UserInfo user = new UserInfo();

            user.Username = username;
            user.Password = password;

            bool isOk = UserInfoService.SignUp(user);

            display.InnerText = isOk ? "恭喜您，注册成功！" : "用户已注册！";
        }
    }
}