using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DeleteInfo(object sender, EventArgs e)
    {
        string sql = getInfoWithSqlString();

        if (sql == null)
        {
            Response.Write("数据不能为空");

            return;
        }

        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
        {
            try
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDataBase"].ConnectionString;

                conn.ConnectionString = connStr;

                deleteInfo(sql, conn);
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

        string name = EmpName.Text.Trim();


        if (name != "")
        {
            infoSqlString = String.Format("DELETE FROM Employees WHERE EmpName = '{0}'", name);
        }

        return infoSqlString;
    }

    // 删除员工信息
    protected void deleteInfo(string sql, System.Data.SqlClient.SqlConnection connecter)
    {
        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, connecter))
        {
            try
            {
                connecter.Open();

                cmd.ExecuteNonQuery(); // 删除数据

                Response.Write("删除数据成功！");

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