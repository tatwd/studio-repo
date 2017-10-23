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
        if (!IsPostBack)
        {
            if (hasUserInSession()) // 清除上一个用户的会话
            {
                Session["Username"] = "";
            }
        }
    }

    protected void signInBtn_Click(object sender, EventArgs e)
    {

        if (IsValid)
        {

            if (hasUserInSession()) // 判断Session["Username"]已经存了用户
            {
                tipLabel.Text = Session["Username"] + "已登录";

                return; // 终止
            }

            try
            {
                queryUser(); // 查询数据库

                if (hasUserInSession())
                {
                    tipLabel.Text = Session["Username"] + "登录成功！";
                }
                else
                {
                    tipLabel.Text = "账户或密码错误！";
                }
            }
            catch (Exception ex)
            {
                tipLabel.Text = "登录失败：" + ex.Message;
            }
        }
    }

    // 判断用是否已经登录
    protected bool hasUserInSession()
    {
        bool hasUserInSession = false;

        if (Session["Username"] != null && Session["Username"].ToString() != "")
        {
            hasUserInSession = true;
        }

        return hasUserInSession;
    }

    // 查询用户数据
    protected void queryUser()
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        MySqlConnection conn = new MySqlConnection(connStr);

        MySqlCommand cmd = new MySqlCommand();

        // 字符串拼接访问数据库

        // cmd = getCmd(conn);

        // 带参数访问数据库

        cmd = getCmdWithParam(conn);

        openDB(conn);

        MySqlDataReader reader =  cmd.ExecuteReader(); // 查询用户数据

        if (reader.HasRows) // 判断reader数据集是否为空
        {
            if (reader.Read())
            {
                Session["Username"] = nameBox.Text.Trim(); // 会话保存用户名
            }
        }

        closeDB(conn);
    }

    // 获取用户数据并以SQL语句形式返回
    protected MySqlCommand getCmd(MySqlConnection cnn)
    {
        string infoSql = null;

        string username = nameBox.Text.Trim();
        string password = passwdBox.Text.Trim();

        infoSql = String.Format("SELECT * FROM user_info WHERE username = '{0}' AND password = '{1}'", username, password);

        MySqlCommand cmd = new MySqlCommand(infoSql, cnn);

        return cmd;
    }

    // 使用带参处理SQL语句并返回一个MySqlCommand对象
    protected MySqlCommand getCmdWithParam(MySqlConnection cnn)
    {
        string infoSql = null;

        string username = nameBox.Text.Trim();
        string password = passwdBox.Text.Trim();

        infoSql = "SELECT * FROM user_info WHERE username = @username AND password = @password";

        MySqlCommand cmd = setParam(username, password); // 得到一个设置了参数的MySqlCommand对象

        cmd.CommandText = infoSql;
        cmd.Connection  = cnn;

        return cmd;
    }

    protected MySqlCommand setParam(string username, string password)
    {
        MySqlCommand cmd = new MySqlCommand();

        MySqlParameter nameParam = new MySqlParameter("@username", MySqlDbType.VarChar, 45);
        MySqlParameter pswdParam = new MySqlParameter("@password", MySqlDbType.VarChar, 45);

        nameParam.Direction = ParameterDirection.Input;
        nameParam.Value     = username;

        pswdParam.Direction = ParameterDirection.Input;
        pswdParam.Value     = password;

        // 添加参数到cmd

        cmd.Parameters.Add(nameParam); 
        cmd.Parameters.Add(pswdParam);

        return cmd;

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