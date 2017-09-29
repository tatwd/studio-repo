using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 输出Application["message"], 将其传递给Chat.aspx中的text变量
        Response.Write(Application["message"].ToString());
    }
}