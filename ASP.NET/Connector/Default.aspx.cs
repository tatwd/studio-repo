using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DbKit;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        //Connector conn = new Connector("mssql", connStr);
        MsSqlConnector msconn = new MsSqlConnector("mssql", connStr);

        //conn.CreateConnection();
        msconn.CreateConnection();

        //object cnn = new System.Data.SqlClient.SqlConnection(connStr); //装箱

        //System.Data.SqlClient.SqlConnection conn = (System.Data.SqlClient.SqlConnection)cnn; // 拆箱

        try
        {
            //conn.DbConnection.Open();
            msconn.OpenDb();

            prompt.InnerText = "成功连接！";

            ViewData.DataSource = msconn.SelectData("username, password", "user_info", "@username", "@password", "10", "10", "test", "test");
            ViewData.DataBind();

            //conn.DbConnection.Close();
            msconn.CloseDb();
        }
        catch (Exception ex)
        {
            prompt.InnerText = ex.Message;
        }

        //prompt.InnerText = connector.ConnectionString + "==" + connector.ToString();
    }
}