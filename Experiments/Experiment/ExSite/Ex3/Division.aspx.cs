using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex3_Division : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int divsor = int.Parse(txtDivsor.Text);
        int dividend = int.Parse(txtDividend.Text);

        // float, double类型除数允许为0, 结果为 ∞ （.net framework 4.5）

        // float divsor = float.Parse(txtDivsor.Text);
        // float dividend = float.Parse(txtDividend.Text);

        // double divsor   = double.Parse(txtDivsor.Text);
        // double dividend = double.Parse(txtDividend.Text);

        try
        {
            Response.Write(dividend);
            
            Response.Write("商为：" + divsor / dividend);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }
}