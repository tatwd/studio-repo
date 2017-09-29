using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex5_GroupValidation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void csvIdentity_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string id = args.Value; // 获取身份证号

        args.IsValid = true;    // 初始值设置为验证通过

        try
        {
            // 360122 19961111 061X
            DateTime.Parse(id.Substring(6, 4) + "-" + id.Substring(10, 2) + "-" + id.Substring(12, 2));
        }
        catch (Exception)
        {
            args.IsValid = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = ""; // 清空值

        if (Page.IsValid)
        {
            lblMsg.Text = "验证通过";

            // TODO:存入数据库
        }
    }

    protected void btnValidateName_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "root")
        {
            lblName.Text = "抱歉！改用户名已被占用！";
        }
        else
        {
            lblName.Text = "恭喜！该用户名可用！";
        }
    }
}