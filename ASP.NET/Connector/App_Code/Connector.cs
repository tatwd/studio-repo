using System;

// using System.Collections.Generic;
// using System.Linq;
// using System.Web;

using System.Data;
using System.Data.SqlClient; // for mssql


// Summary
//   Connector 连接器 - 封装一些数据库连接的通用方法.
//
public class Connector
{
    // Summary:
    //   Type of database.
    private string DbType { set; get; }

    // Summary:
    //   The database connection.
    private string DbConnection { set; get; }

    // Summary:
    //   The type of database is 'mssql'.
    public Connector()
    {
        this.DbType = "mssql";
    }

    // Summary:
    //   This constructor will set the type of database by a parameter.
    //
    // Parameters:
    //   dbType: the type of database - 'mssql' or 'mysql'.
    public Connector(string dbType)
    {
        this.DbType = dbType;
    }
}