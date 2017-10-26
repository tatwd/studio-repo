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
    }

    protected void SignInBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Connector connector = ConnecterFactory.GetConnector("MSSQL");

            connector.Connect("TestDB");

            string selectSql1 = "select * from user_info";
            string selectSql2 = "select * from user_info where username = @username and password = @password";

            // connector.ManageData(Manager.SELECT, sql);

            //int data = connector.ManageData<int>(Manager.SELECT, sql);

            //prompt.InnerText = data.ToString();

            SqlDataReader reader = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@username", Username.Text.Trim()),
                new SqlParameter("@password", Password.Text.Trim())
            };

            //reader = connector.ManageData<SqlDataReader>(sql, param); // 执行带参SQL语句并返回SqlDataReader对象

            int id = connector.ManageData<int>(1, selectSql2, param);

            reader = connector.ManageData<SqlDataReader>(2, selectSql2, param);

            ViewData1.DataSource = reader;
            ViewData1.DataBind();

            prompt.InnerText = id.ToString();

            connector.CloseAll();
        }
        catch (Exception ex)
        {
            prompt.InnerText = ex.Message;
        }
    }

    protected void SignUpBtn_Click(object sender, EventArgs e)
    {
        string username = Username.Text.Trim();
        string password = Password.Text.Trim();

        string tmp = String.Format("select count(*) from user_info where username = '{0}'", username);
        string sql = String.Format("insert into user_info(username, password) values('{0}', '{1}')", username, password);

        try
        {
            Connector msConn = ConnecterFactory.GetConnector("MSSQL");

            msConn.Connect("TestDB");       // 连接数据库

            if (msConn.ManageData<int>(1, tmp) == 0)
            {
                msConn.ManageData<int>(0, sql); // 插入数据
            }
            else
            {
                prompt.InnerText = "已注册！";
            }

            SqlDataReader reader = msConn.ManageData<SqlDataReader>(2, "select * from user_info");

            ViewData1.DataSource = reader;
            ViewData1.DataBind();

            msConn.CloseAll();  // a bug here!!! 

        }
        catch (Exception ex)
        {
            prompt.InnerText = ex.Message;
        }
    }
}