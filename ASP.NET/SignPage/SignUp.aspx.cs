using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MySql.Data.MySqlClient; // 引入MySsl程序集

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void checkPasswdLength_ServerValidate(object source, ServerValidateEventArgs args)
    {
        // validator in server
        // not be used

        if (args.Value.Length < 6 || args.Value.Length > 20)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void signUpBtn_Click(object sender, EventArgs e)
    {
        if (IsValid) 
        {
            try
            {
                addUser(); // 添加到数据库

                tipLabel.Text = "注册成功！";
            }
            catch (Exception ex)
            {
                tipLabel.Text = "注册失败：" + ex.Message;
            }
        }
    }

    // 添加用户数据到数据库
    protected void addUser()
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        MySqlConnection conn = new MySqlConnection(connStr);


        string sql = getUserInfoWithSql();

        MySqlCommand cmd = new MySqlCommand(sql, conn);

        openDB(conn);

        cmd.ExecuteNonQuery(); // 插入用户数据

        closeDB(conn);
    }

    // 获取用户数据并以SQL语句形式返回
    protected string getUserInfoWithSql()
    {
        string infoSql = null;

        string username  = nameBox.Text.Trim();
        string password  = passwdBox.Text.Trim();
        string email     = emailBox.Text.Trim();
        string telephone = phoneBox.Text.Trim();

        infoSql = String.Format("INSERT INTO user_info(username, password, email, telephone) VALUES('{0}', '{1}', '{2}', '{3}')", username, password, email, telephone);

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