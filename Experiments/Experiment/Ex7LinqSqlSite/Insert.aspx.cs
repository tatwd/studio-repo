using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Insert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        MyPetShopDataContext db = new MyPetShopDataContext();

        Category category = new Category(); // 实例化Category

        category.Name  = txtName.Text.Trim();
        category.Descn = txtDescn.Text.Trim();

        db.Category.InsertOnSubmit(category); // 插入实体category
        db.SubmitChanges();                   // 提交更改
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataManage.aspx");
    }
}