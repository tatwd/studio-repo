using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Session_Hello : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblName.Text      = Session["userName"].ToString();
        lblEmail.Text     = Session["userEmail"].ToString();
        lblTelephone.Text = Session["userTelephone"].ToString();
    }
}