using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QueryString_Hello : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblName.Text      = Request.QueryString["userName"].ToString();
        //lblEmail.Text     = Request.QueryString["userEmail"].ToString();
        //lblTelephone.Text = Request.QueryString["userTelephone"].ToString();

        lblName.Text      = Request["userName"].ToString();
        lblEmail.Text     = Request["useremail"].ToString();
        lblTelephone.Text = Request["userTelephone"].ToString();
    }
}