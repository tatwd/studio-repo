using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditEmployee : System.Web.UI.Page
{
    string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDataBase"].ConnectionString;  // 连接字符串

    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(); // 连接对象

    protected void Page_Load(object sender, EventArgs e)
    {
        string sqlColName = "SELECT name FROM syscolumns WHERE id = Object_id('Employees')  AND name != 'EmpID'";

        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlColName, conn))
        {
            try
            {
                conn.ConnectionString = connStr;

                OpenDB(conn);

                System.Data.SqlClient.SqlDataReader colNameReader = cmd.ExecuteReader();

                UpdateItem.DataSource = colNameReader;

                UpdateItem.DataTextField = "name";

                UpdateItem.DataBind();

                if (!colNameReader.IsClosed)
                {
                    colNameReader.Close();
                }

                CloseDB(conn);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected void UpdateInfo(object sender, EventArgs e)
    {
        string sql = getInfoWithSqlString();

        if (sql == null)
        {
            Response.Write("数据不能为空");

            return;
        }

        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
        {
            try
            {
                OpenDB(conn);

                cmd.ExecuteNonQuery(); // 更新数据

                Response.Write("修改成功！");

                CloseDB(conn);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected string getInfoWithSqlString()
    {
        String infoSqlString = null;

        string 
            col  = UpdateItem.SelectedValue,
            data = UpdateData.Text.Trim(),
            id   = EmpID.Text.Trim();


        if (col != "" && id != "") 
        {
            infoSqlString = String.Format("UPDATE Employees SET {0} = {1} WHERE EmpID = {2}", col, data, id);

            if (col == "EmpName")
            {
                infoSqlString = String.Format("UPDATE Employees SET {0} = '{1}' WHERE EmpID = {2}", col, data, id);
            }
        }

        return infoSqlString;
    }

    // 打开数据库
    protected void OpenDB(System.Data.SqlClient.SqlConnection connecter)
    {
        if (connecter.State == System.Data.ConnectionState.Closed)
        {
            connecter.Open();
        }
    }

    // 关闭数据库
    protected void CloseDB(System.Data.SqlClient.SqlConnection connecter)
    {
        if (connecter.State == System.Data.ConnectionState.Open)
        {
            connecter.Close();
        }
    }
}