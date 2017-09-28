using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex4_Course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) // 首次加载
        {
            BindYear();
            BindTerm();
            BindCollege();
            BindTeacher();
        }
    }

    private void BindYear()
    {
        ddlYear.Items.Clear(); // 清空表项

        int startYear   = DateTime.Now.Year - 10;
        int currentYear = DateTime.Now.Year;

        // 添加表项
        for (int i = startYear; i <= currentYear; i++)
        {
            ListItem _year = new ListItem((i - 1).ToString() + "-" + i.ToString());

            ddlYear.Items.Add(_year);
        }

        // 默认表项
        ddlYear.SelectedValue = (currentYear - 1).ToString() + "-" + currentYear.ToString();
    }

    private void BindTerm()
    {
        ddlTerm.Items.Clear();

        for (int i = 1; i <= 2; i++)
        {
            ddlTerm.Items.Add(i.ToString());
        }
    }

    private void BindCollege()
    {
        ddlCollege.Items.Clear();

        ddlCollege.Items.Add("计算机学院");
        ddlCollege.Items.Add("外国语学院");
        ddlCollege.Items.Add("机电学院");
    }

    private void BindTeacher()
    {
        ddlTeacher.Items.Clear();

        switch (ddlCollege.SelectedValue)
        {
            case "计算机学院":
                ddlTeacher.Items.Add(new ListItem("曹明"));
                ddlTeacher.Items.Add(new ListItem("李妙"));
                ddlTeacher.Items.Add(new ListItem("王芳"));
                break;
            case "外国语学院":
                ddlTeacher.Items.Add(new ListItem("张强"));
                ddlTeacher.Items.Add(new ListItem("王第男"));
                break;
            default:
                ddlTeacher.Items.Add(new ListItem("朱兆清"));
                ddlTeacher.Items.Add(new ListItem("毛沁程"));
                break;
        }
    }

    protected void ddlCollege_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTeacher();
    }
}