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

    protected void DeleteAll_Click(object sender, EventArgs e)
    {
        for (int i = 0, length = ViewData.Rows.Count; i < length; i++)
        {
            CheckBox ckbox = (CheckBox)ViewData.Rows[i].FindControl("ItemCkBox"); // 每行的确认控件

            if (ckbox.Checked)
            {

                // 此处开始删除

                // 法一：
                // ViewData.DeleteRow(i);

                // 法二：
                //int majorId = int.Parse(ViewData.Rows[i].Cells[1].Text.Trim()); // 课程ID

                //Connector conn = ConnectorFactory.GetConnector("StudentDb");

                //conn.Connect();

                //conn.ManageData<int>(0, "delete from [Major] where [MajorId] = " + majorId);

                //conn.CloseAll();

            }
        }
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

    protected void ItemCkBox_CheckedChanged(object sender, EventArgs e)
    {
        
    }
}