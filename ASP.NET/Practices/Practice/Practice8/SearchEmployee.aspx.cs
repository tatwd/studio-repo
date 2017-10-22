using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // 查询部门员工记录
    protected void QueryInfo(object sender, EventArgs e)
    {
        string sql = getInfoWithSqlString();

        if (sql == null)
        {
            Response.Write("数据不能为空！");

            return;
        }

        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDataBase"].ConnectionString;

        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr))
        {
            try
            {
                System.Data.SqlClient.SqlDataAdapter adpater = new System.Data.SqlClient.SqlDataAdapter(sql, conn);

                System.Data.DataSet data = new System.Data.DataSet();
                
                // TODO: 检查adpater, data

                adpater.Fill(data); // 填充data


                ResultView.DataSource = data;

                ResultView.DataBind();

                Response.Write("查询成功！");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected string getInfoWithSqlString()
    {
        String infoSqlString = null;

        string name = DepartmentName.Text.Trim();

        if (name != "")
        {
            infoSqlString = String.Format("SELECT * FROM Employees WHERE EmpDepartment LIKE (SELECT DepartmentID FROM Department WHERE DepartmentName = N'{0}')", name);
        }

        return infoSqlString;
    }
}