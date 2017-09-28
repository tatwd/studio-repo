using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ex3_ArrayDescending : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string[] arr = txtInput.Text.Trim().Split(' ');

        if (arr.Length != 10)
        {
            Response.Write("请输入10个数！");
            return;
        }

        Array.Sort(arr);    // 升序排列

        Array.Reverse(arr); // 反转数组

        foreach (var item in arr)
        {
            if (int.Parse(item) != 0)
            {
                Response.Write(item + " ");
            }
        }
    }
}