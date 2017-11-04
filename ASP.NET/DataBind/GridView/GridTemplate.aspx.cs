using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DbKit;

public partial class GirdTemplate : System.Web.UI.Page
{
    object selectIndex = null;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void HeaderCkBox_CheckedChanged(object sender, EventArgs e)
    {

        CheckBox hdCkbox = (CheckBox)ViewData.HeaderRow.FindControl("HeaderCkBox");   // 获取表头控件

        for (int i = 0, length = ViewData.Rows.Count; i < length; i++)
        {
            CheckBox ItemCkbox = (CheckBox)ViewData.Rows[i].FindControl("ItemCkBox"); // 每行的确认控件

            ItemCkbox.Checked = hdCkbox.Checked;
        }
    }

    protected void DeleteMajor_Click(object sender, EventArgs e)
    {
        int[] arr = { 0 };

        List<int> list = new List<int>();

        for (int i = 0; i < ViewData.Rows.Count; i++)
        {
            CheckBox ckbox = (CheckBox)ViewData.Rows[i].FindControl("ItemCkBox"); // 每行的确认控件

            if (ckbox.Checked)
            {
                // 法一：
                // ViewData.DeleteRow(i);

                int majorId = int.Parse(ViewData.Rows[i].Cells[1].Text.Trim()); // 被删课程ID
                list.Add(majorId);
            }
        }

        foreach (var id in list)
        {
            // 法二：

            Connector conn = ConnectorFactory.GetConnector("studentdb");

            // 连接模式

            //conn.Connect();
            //int row = conn.ManageData<int>(0, "delete from [Major] where [MajorId] = " + id);
            //ViewData.DataBind();
            //conn.CloseAll();

            // 断开模式

            conn.ManageDataOffMode("delete", "Major", id);
            ViewData.DataBind();
        }
    }
}