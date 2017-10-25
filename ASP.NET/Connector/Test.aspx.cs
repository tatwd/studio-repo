using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using DbKitX;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        

        // Manager.SELECT;
    }

    protected void SignInBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Connector connector = ConnecterFactory.GetConnector("MSSQL");

            connector.Connect("TestDB");

            string sql = "select * from user_info where username = @username and password = @password";

            // connector.ManageData(Manager.SELECT, sql);

            //int data = connector.ManageData<int>(Manager.SELECT, sql);

            //prompt.InnerText = data.ToString();

            SqlDataReader reader = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username", Username.Text.Trim()),
                new SqlParameter("@password", Password.Text.Trim())
            };

            reader = connector.ManageData<SqlDataReader>(sql, param); // 执行带参SQL语句并返回SqlDataReader对象

            ViewData1.DataSource = reader;
            ViewData1.DataBind();

            //prompt.InnerText = "okokokok";

            connector.CloseAll();
        }
        catch (Exception ex)
        {
            prompt.InnerText = ex.Message;
        }
    }
}