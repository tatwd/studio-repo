using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Session : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string userName      = txtName.Text;
        string userEmail     = txtEmail.Text;
        string userTelephone = txtTelephone.Text;

        if (userName != null && userEmail != null && userTelephone != null)
        {
            Session["userName"]      = userName;
            Session["userEmail"]     = userEmail;
            Session["userTelephone"] = userTelephone;

            Response.Redirect("~/Session_Hello.aspx");
        }
    }
}