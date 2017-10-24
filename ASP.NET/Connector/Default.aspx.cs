using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        Connector connector = new Connector("mssql", connStr);

        //System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);

        //try
        //{
        //    conn.Open();

        //    prompt.InnerText = "成功连接！";

        //    conn.Close();
        //}
        //catch (Exception ex)
        //{
        //    prompt.InnerText = ex.Message;
        //}

        prompt.InnerText = connector.ConnectionString + "==" + connector.ToString();
    }
}