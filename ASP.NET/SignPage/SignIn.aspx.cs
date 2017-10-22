using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MySql.Data.MySqlClient;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void signInBtn_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            try
            {
                queryUser(); // 添加到数据库

                tipLabel.Text = Session["Username"] + "登录成功！";
            }
            catch (Exception ex)
            {
                tipLabel.Text = "用户名或密码错误：" + ex.Message;
            }
        }
    }

    // 查询用户数据
    protected void queryUser()
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        MySqlConnection conn = new MySqlConnection(connStr);

        string sql = getUserInfoWithSql();

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        openDB(conn);

        MySqlDataReader reader =  cmd.ExecuteReader(); // 查询用户数据

        if (reader.Read())
        {
            Session["Username"] = nameBox.Text.Trim(); // 会话保存用户名
        }

        closeDB(conn);
    }

    // 获取用户数据并以SQL语句形式返回
    protected string getUserInfoWithSql()
    {
        string infoSql = null;

        string username = nameBox.Text.Trim();
        string password = passwdBox.Text.Trim();

        infoSql = String.Format("SELECT * FROM user_info WHERE username = '{0}' AND password = '{1}'", username, password);

        return infoSql;
    }

    // 打开数据库
    protected void openDB(MySqlConnection conn)
    {
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
    }

    // 关闭数据库
    protected void closeDB(MySqlConnection conn)
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
    }
}