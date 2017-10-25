using System;

// using System.Collections.Generic;
// using System.Linq;
// using System.Web;

using System.Reflection;      // must 

using System.Configuration;   // must

using System.Data;
using System.Data.SqlClient;  // for 'mssql'

using MySql.Data.MySqlClient; // for 'mysql'

namespace DbKitX
{
    // 抽象工厂模式（Abstract factory pattern） + 反射（Reflection）

    // Summary:
    //   ConnectorFactory - 连接器生产工厂
    //
    public class ConnecterFactory
    {
        // 连接器类名
        private static string ConnectorClassName { set; get; }

        // 获取当前程序集全名
        private static readonly string AssemblyName = Assembly.GetExecutingAssembly().FullName;

        // Summary:
        //   根据数据库类型来设置连接器类名
        //
        // Parameters:
        //   dbType:
        //     数据库类型
        public static void SetConnectorClassName(string dbType)
        {
            if (dbType.Equals("MSSQL", StringComparison.CurrentCultureIgnoreCase)) // 忽视大小写
            {
                ConnectorClassName = "DbKitX.MsSqlConnector";  // for mssql
            }
            else if(dbType.Equals("MSSQL", StringComparison.CurrentCultureIgnoreCase))
            {
                ConnectorClassName = "DbKitX.MySqlConnector";  // for mysql
            }
        }

        // Summary:
        //   根据数据库类型，获取一个通用连接数据库对象
        public static Connector GetConnector(string dbType)
        {
            SetConnectorClassName(dbType);  // 获取连接器类名

            return (Connector)Assembly.Load(AssemblyName).CreateInstance(ConnectorClassName); // 利用反射创建一个连接器
        }


        // ------------------------------
        // Extend other connectors here.
        // ------------------------------
    }

    // Summary
    //   Connector 连接器 - 接口, 定义了一些与ADO.NET相关的通用方法, 包含连接模式（SOME OK）和断开模式（TODO）
    //
    public interface Connector
    {
        // Summary:
        //   Connect database.
        void Connect();

        // Summary:
        //   Connect database with a connection string.
        void Connect(string dbName);

        // Summary:
        //   处理连接字符串
        void SetConnectionString(string dbName);

        // Summary:
        //   连接模式（On Mode）管理数据 
        void ManageData();

        // Summary:
        //   断开模式（Off Mode）管理数据 
        void ManageDataOffMode();

        // Summary:
        //   打开数据库
        void OpenDb();

        // Summary:
        //   关闭数据库
        void CloseDb();

        // Summary:
        //   关闭所有资源
        void CloseAll(); 

    }

    // Summary:
    //   This class is for 'MSSQL'.
    //
    public class MsSqlConnector : Connector
    {
        private SqlConnection DbConnection { set; get; }

        private string ConnectionString { set; get; }

        // Override
        public void Connect()
        {
            // TODO
        }

        public void Connect(string dbName)
        {
            SetConnectionString(dbName); // 设置连接字符串

            this.DbConnection = new SqlConnection(this.ConnectionString);

            OpenDb();
        }

        public void SetConnectionString(string dbName)
        {
            if (this.ConnectionString != "")
            {
                this.ConnectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
            }
        }

        public void ManageData()
        {
            throw new NotImplementedException();
        }

        public void ManageDataOffMode()
        {
            throw new NotImplementedException();
        }

        public void OpenDb()
        {
            if (this.DbConnection.State != ConnectionState.Open)
            {
                this.DbConnection.Open(); // 打开数据库
            }
        }

        public void CloseDb()
        {
            if (this.DbConnection.State != ConnectionState.Closed)
            {
                this.DbConnection.Close(); // 关闭数据库
            }
        }

        public void CloseAll()
        {
            CloseDb();
        }

        public MsSqlConnector() { }

        public MsSqlConnector(string dbName)
        {
            SetConnectionString(dbName);
        }
    }

    // Summary:
    //   This class is for 'MYSQL'.
    public class MySqlConnector : Connector
    {
        // Override
        public void Connect() { }

        public void Connect(string dbName)
        {
            throw new NotImplementedException();
        }

        public void SetConnectionString(string dbName)
        {
            throw new NotImplementedException();
        }

        public void ManageData()
        {
            throw new NotImplementedException();
        }

        public void ManageDataOffMode()
        {
            throw new NotImplementedException();
        }

        public void OpenDb()
        {
            throw new NotImplementedException();
        }

        public void CloseDb()
        {
            throw new NotImplementedException();
        }

        public void CloseAll()
        {
            throw new NotImplementedException();
        }
    }
}