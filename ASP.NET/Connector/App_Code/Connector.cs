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
    private object DbConnection { set; get; }

    // Summary:
    //   The connection string of database, can be getted and setted by a object. 
    public string ConnectionString { set; get; }

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
    //   dbType_connectionString: the string is the type of database or connection string.
    public Connector(string dbType_connectionString)
    {
        if(dbType_connectionString != "mssql" || dbType_connectionString != "mysql")
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
    //   dbType: the type of database - 'mssql' or 'mysql'.
    //
    //   connectionString: the connection string.
    public Connector(string dbType, string connectionString)
    {
        this.DbType           = dbType;
        this.ConnectionString = connectionString;
    }
}