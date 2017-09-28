using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex4_Choice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label           question    = new Label();
        RadioButtonList rdoltChoice = new RadioButtonList();

        question.ID    = "lblQuestion";
        question.Text  = "1、服务器控件不包括（&nbsp;&nbsp;&nbsp;&nbsp;）。";
        rdoltChoice.ID = "rdoltChoice"; 

        // 将question控件添加到plhChoice控件中
        plhChoice.Controls.Add(question);

        // 设置单选选项
        rdoltChoice.Items.Add(new ListItem("A. Wizard",    "A"));
        rdoltChoice.Items.Add(new ListItem("B. input",     "B"));
        rdoltChoice.Items.Add(new ListItem("C. AdRotator", "C"));
        rdoltChoice.Items.Add(new ListItem("D. Calendar",  "D"));

        plhChoice.Controls.Add(rdoltChoice);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // 查找rdoltChoice控件
        RadioButtonList rdoltChoice = (RadioButtonList)plhChoice.FindControl("rdoltChoice");

        lblDisplay.Text = "你选择了：" + rdoltChoice.SelectedValue;
    }
}