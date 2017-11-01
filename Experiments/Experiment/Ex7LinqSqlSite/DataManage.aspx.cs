using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataManage : System.Web.UI.Page
{
    MyPetShopDataContext db = new MyPetShopDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Bind()
    {
        var results = from c in db.Category select c;

        gvCategory.DataSource = results;
        gvCategory.DataBind();
    }

    protected void btnQueryAll_Click(object sender, EventArgs e)
    {
        Bind();
    }

    protected void btnFuzzy_Click(object sender, EventArgs e)
    {
        Response.Redirect("FuzzyQuery.aspx");
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        Response.Redirect("Insert.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("Update.aspx?CategoryId=" + txtCategoryId.Text.Trim());
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        var results = from c in db.Category
                      where c.CategoryId == int.Parse(txtCategoryId.Text.Trim())
                      select c;

        db.Category.DeleteAllOnSubmit(results);
        db.SubmitChanges();

        Bind();
    }
}