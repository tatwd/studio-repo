using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex3_Multiplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 1; i <= 9; i++)
        {
            //for (int j = 1; j <= i; j++)
            for(int j = i; j <= 9; j++)
            {
                Response.Write(i + "x" + j + "=" + i * j + "&nbsp;&nbsp;");
            }

            Response.Write("<br>");
        }
    }
}