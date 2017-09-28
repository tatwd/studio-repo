using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex3_UserInfoPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string   name     = txtName.Text;
        DateTime birthday = DateTime.ParseExact(txtBirthday.Text, "yyyyMMdd", null);

        UserInfo userinfo = new UserInfo(name, birthday);

        Response.Write(userinfo.DecideAge());
    }
}