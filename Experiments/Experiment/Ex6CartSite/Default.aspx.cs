using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["cart"] = ""; // cart变量用于储存宠物
        }
    }

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        // 查找选中的宠物
        for (int i = 0; i < chklsPet.Items.Count; i++)
        {
            if (chklsPet.Items[i].Selected)
            {
                Session["cart"] += chklsPet.Items[i].Text + ",";
            }
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewCart.aspx"); // 重定向到ViewCart.aspx
    }
}