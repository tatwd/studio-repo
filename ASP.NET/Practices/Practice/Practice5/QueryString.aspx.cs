using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QueryString : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/QueryString_Hello.aspx?userName=" + txtName.Text.Trim() +
            "&userEmail=" + txtEmail.Text.Trim() +
            "&userTelephone=" + txtTelephone.Text.Trim());
    }
}