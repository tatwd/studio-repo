using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InsertEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitInfo(object sender, EventArgs e)
    {
        string sql =  getInfoWithSqlString();

        if (sql == null)
        {
            Response.Write("数据不能为空");

            return;
        }

        using (System.Data.SqlClient.SqlConnection  conn = new System.Data.SqlClient.SqlConnection())
        {
            try
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDataBase"].ConnectionString;

                conn.ConnectionString = connStr;

                insertInfo(sql, conn);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    // 获取信息并以SQL语句的形式返回
    protected string getInfoWithSqlString()
    {
        String infoSqlString = null;

        string 
            id         = EmpID.Text.Trim(),
            name       = EmpName.Text.Trim(),
            age        = EmpAge.Text.Trim(),
            department = EmpDepartment.Text.Trim();


        if (id != "" && name != "" && age != "" && department != "")
        {
            infoSqlString = String.Format("INSERT INTO Employees VALUES({0}, '{1}', {2}, {3})", id, name, age, department);
        }

        return infoSqlString;
    }

    // 插入员工信息到数据库
    protected void insertInfo(string sql, System.Data.SqlClient.SqlConnection connecter)
    {
        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, connecter))
        {
            try
            {
                connecter.Open();

                cmd.ExecuteNonQuery(); // 插入数据

                Response.Write("插入数据成功！");

                if (connecter.State == System.Data.ConnectionState.Open)
                {
                    connecter.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}