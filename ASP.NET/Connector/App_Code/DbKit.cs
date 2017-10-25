using System;

// using System.Collections.Generic;
// using System.Linq;
// using System.Web;

using System.Configuration;

using System.Data;
using System.Data.SqlClient;  // for 'mssql'

// using MySql.Data.MySqlClient; // for 'mysql'

namespace DbKit
{

    // Summary
    //   Connector 连接器 - 基类, 封装一些数据库连接的通用方法, 包含连接模式（SOME OK）和断开模式（TODO）
    //
    public class Connector
    {
        // Summary:
        //   Type of database.
        private string DbType { set; get; }

        // Summary:
        //   Name of database connection string in 'web.config'.
        private string DbName { set; get; }

        // Summary:
        //   The database connection, will be converted(boxing and unboxing) to different database connections.
        public SqlConnection DbConnection { set; get; }

        // Summary:
        //   The connection string of database, can be getted and setted by a object. 
        public string ConnectionString { set; get; }

        // Summary:
        //   The default type of database is 'mssql'.
        public Connector()
        {
            this.DbType = "mssql";
        }

        // Summary:
        //   This constructor will set the type of database by a parameter.
        //
        // Parameters:
        //   dbType_connectionString: 
        //     The string is the type of database or connection string.
        public Connector(string dbType_connectionString)
        {
            if (dbType_connectionString != "mssql" || dbType_connectionString != "mysql")
            {
                // If input a connection string, the type of database will be setted to 'mssql'.
                this.DbType           = "mssql";
                this.ConnectionString = dbType_connectionString;
            }
            else
            {
                this.DbType = dbType_connectionString;
            }
        }

        // Summary:
        //   This constructor will set the 'DbType', 'ConnectionString'.
        //
        // Parameters:
        //   dbType: 
        //     The type of database - 'mssql' or 'mysql'.
        //
        //   connectionString: 
        //     The connection string.
        public Connector(string dbType, string connectionString)
        {
            this.DbType           = dbType;
            this.ConnectionString = connectionString;
        }

        // Summary:
        //   Create a database connection according to 'DbType' and 'ConnectionString' if they are not null.
        public void CreateConnection()
        {
            if (this.ConnectionString != null)
            {
                if (this.DbType == "mssql")
                {
                    this.DbConnection = new SqlConnection(this.ConnectionString); // for 'mssql'
                }
            }
        }

        // Summary:
        //   Create a database connection according to 'DbType' if it is not null.
        //
        // Parameters:
        //   connectionString:
        //     Input a connection string by user.
        public void CreateConnection(string connectionString)
        {
            if (this.DbType == "mssql")
            {
                this.DbConnection = new SqlConnection(connectionString); // for 'mssql'
            }
        }

        // Summary:
        //  This is a open databse method.
        public void OpenDb()
        {
            if (this.DbConnection.State != ConnectionState.Open)
            {
                this.DbConnection.Open();
            }
        }

        // Summary:
        //  This is a close databse method.
        public void CloseDb()
        {
            if (this.DbConnection.State != ConnectionState.Closed)
            {
                this.DbConnection.Close();
            }
        }

        // Summary:
        //   Get connection string.
        // 
        // Returns:
        //   A connection string.
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[this.DbName].ConnectionString;
        }
    }

    // Summary:
    //   This class is for 'mssql', and it inherit from Connector class.
    //
    public class MsSqlConnector : Connector
    {
        // These class constructors inherit from base class.

        // Summary:
        //   A reader to read data from execute sql string.
        private SqlDataReader reader { set; get; }

        public MsSqlConnector() : base() { }

        public MsSqlConnector(string dbType_connectionString) : base(dbType_connectionString) { }

        public MsSqlConnector(string dbType, string connectionString) : base(dbType, connectionString) { }

        // Summary:
        //   Close SqlDataReader.
        public void CloseReader()
        {
            if (!this.reader.IsClosed)
            {
                this.reader.Close();
            }
        }

        // Summary:
        //   Close all resources.
        public void CloseAll()
        {
            this.CloseReader();
            this.CloseDb();
        } 

        // Summary:
        //   Query database table by using 'SelectString'
        //
        // Parameters:
        //   commandText: 
        //     A command text string.
        //     eg: "select * from user_name where username = @username and password = @password"
        //   
        //   args:
        //     This is parameters array, includes vlues, sizes.
        //     eg: "test, test, 10, 10"
        //
        // Returns:
        //   A SqlDataReader object.
        public SqlDataReader SelectData(string commandText, params string[] args)
        {
            this.OpenDb(); // 打开数据库

            SqlCommand cmd = new SqlCommand();

            // 字符串拼接查询
            cmd.CommandText = commandText;
            cmd.Connection  = this.DbConnection;
            
            // 带参数查询
            //
            // TODO: 封装以下代码

            if (args.Length != 0)
            {
                string[] arr = new string[args.Length / 2]; // 用数组存放sql参数

                int i = 0;

                string str = commandText + " ";
                int    at  = str.IndexOf('@');

                str = str.Substring(at);

                int space = str.IndexOf(' ');

                while (at != -1 && space != -1)
                { 
                    arr[i] = str.Substring(0, space);
                    str    = str.Substring(space + 1);

                    if (str == "")
                    {
                        break;
                    }

                    at    = str.IndexOf('@');
                    str   = str.Substring(at);
                    space = str.IndexOf(' ');

                    i++;
                }

                for (int j = 0, length = args.Length / 2; j < length; j++)
                {
                    SqlParameter param = new SqlParameter(arr[j], SqlDbType.NChar, int.Parse(args[j + length]));
                    param.Direction = ParameterDirection.Input;

                    param.Value = args[j];

                    cmd.Parameters.Add(param);
                }
            }

            this.reader = cmd.ExecuteReader();

            // this.CloseAll(); // 关闭所以资源

            return this.reader;
        }

        // Summary:
        //   Query data by parameters.
        //
        // Parameters:
        //   tableName: 
        //     The data table name.
        //   
        //   selectString:
        //     Need to select strings. eg: "*" or "username, password"
        // 
        //   args:
        //     Threen parts of it, frist are parameters, second are sizes, last are values. 
        //     eg: "@username, @password, 10, 10, test, test"
        // 
        //  Returns:
        //     A SqlDataReader object.
        public SqlDataReader SelectData(string selectString, string tableName, params string[] args)
        {
            OpenDb(); // 打开数据库

            SqlCommand    cmd      = new SqlCommand();
            string        paramStr = null;

            if (args.Length != 0)
            {
                paramStr = getParamStr(args);
            }

            cmd.CommandText = String.Format("select {0} from {1} {2}", selectString, tableName, paramStr);
            cmd.Connection  = this.DbConnection;

            AddParameters(ref cmd, 3, args);

            this.reader = cmd.ExecuteReader();

            // this.CloseAll(); // 关闭所以资源

            return this.reader;
        }

        // Summary:
        //   Format parameters for sql string.
        private string getParamStr(params string[] args)
        {
            string paramStr = "";

            for (int i = 0, length = args.Length / 3; i < length; i++)
            {
                var str = args[i].Substring(1) + " = " + args[i];

                if (paramStr != "") // 不是第一个元素
                {
                    paramStr = paramStr + " and " + str;
                }
                else
                {
                    paramStr = paramStr + str;
                }
            }

            return ("where " + paramStr).Trim();
        }

        // Summary:
        //   Add parameters to a SqlCommand object.
        //
        // Parameters:
        //   cmd:
        //     A SqlCommand object.
        //
        //   n:
        //     The number of part of 'args'
        //
        //   args:
        //     The parameter array.
        private void AddParameters(ref SqlCommand cmd, int n, params string[] args)
        {
            for (int i = 0, length = args.Length / n; i < length; i++)
            {
                SqlParameter parms = new SqlParameter(args[i], SqlDbType.NChar, int.Parse(args[i + length]));
                parms.Direction    = ParameterDirection.Input;

                parms.Value = args[i + length * (n - 1)].Trim();

                cmd.Parameters.Add(parms);
            }
        }
    }

}