using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Linq.SqlClient;

public partial class FuzzyQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        MyPetShopDataContext db = new MyPetShopDataContext();

        // 查找分类名中包含输入内容的分类

        string searchMsg = txtSearch.Text.Trim();

        var results = searchMsg != "" ? from c in db.Category where SqlMethods.Like(c.Name, "%" + searchMsg + "%") select c : null;

        if (results != null)
        {
            if (results.Count() != 0)
            {
                if (lbMsg.Text != null)
                {
                    lbMsg.Text = "";
                }

                gvCategory.DataSource = results;
                gvCategory.DataBind();

            }
            else
            {
                lbMsg.Text = "没有满足条件的数据！";
            }
        }
        else
        {
            lbMsg.Text = "不能为空！";
        }

    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataManage.aspx");
    }
}