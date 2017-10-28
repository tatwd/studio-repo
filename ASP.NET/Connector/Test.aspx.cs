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
        QueryUser();
    }

    protected void SignUpBtn_Click(object sender, EventArgs e)
    {
        AddUser();
    }

    protected void QueryUser()
    {
        try
        {
            // --------------------

            //Connector connector = ConnecterFactory.GetConnector("MSSQL");

            //connector.Connect("TestDB");

            //string selectSql1 = "select * from user_info";
            //string selectSql2 = "select * from user_info where username = @username and password = @password";

            //// connector.ManageData(Manager.SELECT, sql);

            ////int data = connector.ManageData<int>(Manager.SELECT, sql);

            ////prompt.InnerText = data.ToString();

            //SqlDataReader reader = null;

            //SqlParameter[] param = new SqlParameter[]
            //{
            //    new SqlParameter("@username", Username.Text.Trim()),
            //    new SqlParameter("@password", Password.Text.Trim())
            //};

            ////reader = connector.ManageData<SqlDataReader>(sql, param); // 执行带参SQL语句并返回SqlDataReader对象

            //int id = connector.ManageData<int>(1, selectSql2, param);

            //reader = connector.ManageData<SqlDataReader>(2, selectSql2, param);

            //ViewData1.DataSource = reader;
            //ViewData1.DataBind();

            //prompt.InnerText = id.ToString();

            //connector.CloseAll();

            // --------------------

            string username = Username.Text.Trim();
            string password = Password.Text.Trim();

            string tmp = String.Format("select * from [user_info] where [username] = '{0}' and [password] = '{1}'", username, password);

            string cnnStr = System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(tmp, cnn);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                ViewData1.DataSource = ds;
                ViewData1.DataBind();

            }

        }
        catch (Exception ex)
        {
            prompt.InnerText = ex.Message;
        }
    }

    protected void AddUser()
    {
        string username = Username.Text.Trim();
        string password = Password.Text.Trim();

        string sql1 = String.Format("insert into [user_info](username, password) values('{0}', '{1}')", username, password);
        //string sql2 = "select * from [user_info] where username = @username and password = @password";
        //string sql3 = "select * from [user_info] where username = @username and password = @password";

        //string tmp  = String.Format("select count([user_id]) from [user_info] where [username] = '{0}'", username);
        string all  = "select * from [user_info]";


        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@username", Username.Text.Trim()),
            new SqlParameter("@password", Password.Text.Trim())
        };

        try
        {
            Connector msConn = ConnecterFactory.GetConnector("TestDB");

            msConn.ManageDataOffMode("insert", "user_info", username, password);

            DataSet ds = msConn.GetDataSet(all);

            ViewData1.DataSource = ds;
            ViewData1.DataBind(); // this case, has no bug. why?

        }
        catch (Exception ex)
        {
            prompt.InnerText = ex.Message;
        }
    }

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        string username = Username.Text.Trim();
        string password = Password.Text.Trim();

        string sql1 = String.Format("insert into [user_info](username, password) values('{0}', '{1}')", username, password);
        string all = "select * from [user_info]";


        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@username", Username.Text.Trim()),
            new SqlParameter("@password", Password.Text.Trim())
        };

        try
        {
            Connector msConn = ConnecterFactory.GetConnector("TestDB");

            msConn.ManageDataOffMode("update", "user_info", 7, username, password);

            DataSet ds = msConn.GetDataSet(all);

            ViewData1.DataSource = ds;
            ViewData1.DataBind(); // this case, has no bug. why?

        }
        catch (Exception ex)
        {
            prompt.InnerText = ex.Message;
        }
    }

    protected void DeleteBtn_Click(object sender, EventArgs e)
    {
        string username = Username.Text.Trim();
        string password = Password.Text.Trim();

        string all = "select * from [user_info]";


        SqlParameter[] param = new SqlParameter[]
        {
            new SqlParameter("@username", Username.Text.Trim()),
            new SqlParameter("@password", Password.Text.Trim())
        };

        try
        {
            Connector msConn = ConnecterFactory.GetConnector("TestDB");

            msConn.ManageDataOffMode("delete", "user_info", username, password);

            DataSet ds = msConn.GetDataSet(all);

            ViewData1.DataSource = ds;
            ViewData1.DataBind();

        }
        catch (Exception ex)
        {
            prompt.InnerText = ex.Message;
        }
    }
}