using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DbKit;

public partial class _Default : System.Web.UI.Page
{
    static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

    MsSqlConnector mssql = new MsSqlConnector("mssql", connStr);

    protected void Page_Load(object sender, EventArgs e)
    {

        
    }



    protected void SignInBtn_Click(object sender, EventArgs e)
    {
        mssql.CreateConnection();

        try
        {
            // 连接模式访问

            // mssql.OpenDb();

            string username = Username.Text.Trim();
            string password = Password.Text.Trim();

            string[] arr = { "@username", "@password", "10", "10", username, password };

            ViewData1.DataSource = mssql.SelectData("select * from user_info");
            ViewData1.DataBind();

            mssql.CloseReader(); // 关闭reader

            //ViewData2.DataSource = mssql.SelectData("*", "user_info", arr);
            //ViewData2.DataBind();

            //mssql.CloseReader(); // 关闭reader

            mssql.CloseDb();
        }
        catch (Exception ex)
        {
            prompt.InnerText = ex.Message;
        }
    }

    protected void SignUpBtn_Click(object sender, EventArgs e)
    {

    }
}