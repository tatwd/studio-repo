using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using DbKitS;

public partial class TestDbKitS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnExecute_Click(object sender, EventArgs e)
    {

        string username = Username.Text.Trim(),
            password = Password.Text.Trim();

        string query = "select * from [user_info] where [username] = @username and [password] = @password";

        //string insert = String.Format("insert into [user_info] values('{0}', '{1}')", username, password);

        string insert = "insert into [user_info] values(@username, @password)";

        SqlParameter[] cmdParams = new SqlParameter[]
        {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password)
        };

        try
        {
            Connector conn = DbHelper.GetConnector("TestDB");

            if (conn.Execute("scalar", query, cmdParams) == null)
            {
                int line = (int)conn.Execute("non", insert, cmdParams);

                display.InnerText = line.ToString();
            }
            else
            {
                display.InnerText = "已注册！";
            }

            SqlDataReader reader = (SqlDataReader)conn.Execute("reader", query, cmdParams);

            ViewData.DataSource = reader;
            ViewData.DataBind();

        }
        catch (Exception ex)
        {
            display.InnerText = ex.Message;
        }
    }

    protected void BtnExecuteBySp_Click(object sender, EventArgs e)
    {
        string username = Username.Text.Trim(),
            password = Password.Text.Trim();

        SqlParameter[] cmdParams = new SqlParameter[]
        {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password)
        };

        try
        {
            Connector conn = DbHelper.GetConnector("TestDB");

            // 支持存储过程的执行
            SqlDataReader reader = (SqlDataReader)conn.Execute("reader", "GetUserInfo", CommandType.StoredProcedure, cmdParams);

            ViewData.DataSource = reader;
            ViewData.DataBind();
        }
        catch (Exception ex)
        {
            display.InnerText = ex.Message;
        }
    }

    protected void BtnExecuteDisc_Click(object sender, EventArgs e)
    {
        string username = Username.Text.Trim(),
            password = Password.Text.Trim();

        string query = "select * from [user_info] where [username] = @username and [password] = @password";

        SqlParameter[] cmdParams = new SqlParameter[]
        {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password)
        };

        try
        {
            Connector conn = DbHelper.GetConnector("TestDB");

            // DataTable data = conn.GetDataTable("select * from [user_info]");

            // DataTable data = conn.GetDataTable(query, cmdParams) // 支持带安全参数

            // DataTable data = conn.GetDataTable("GetUserInfo", CommandType.StoredProcedure, cmdParams); // 支持存储过程

            DataSet data = conn.GetDataSet("GetUserInfo", CommandType.StoredProcedure, cmdParams); // 支持存储过程

            ViewData.DataSource = data;
            ViewData.DataBind();
        }
        catch (Exception ex)
        {
            display.InnerText = ex.Message;
        }
    }
}