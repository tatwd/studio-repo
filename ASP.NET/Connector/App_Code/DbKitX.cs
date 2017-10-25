using System;

// using System.Collections.Generic;
// using System.Linq;
using System.Web;

using System.Configuration;   // must hava

using System.Data;
using System.Data.SqlClient;  // for 'mssql'

using MySql.Data.MySqlClient; // for 'mysql'

namespace DbKitX
{
    // 工厂模式

    // Summary:
    //   ConnectorFactory - 连接器生产工厂
    public class ConnecterFactory
    {
        // static method
        public static Connector GetConnector(string dbType)
        {
            if (dbType == null)
            {
                return null;
            }

            if (dbType.Equals("MSSQL", StringComparison.CurrentCultureIgnoreCase))
            {
                return new MsSqlConnector(); // 创建mssql数据库连接器
            }
            else
            {
                return new MySQLConnector(); // 创建mysql数据库连接器
            }

            // return null;
        }
    }

    // Summary
    //   Connector 连接器 - 基类, 封装一些数据库连接的通用方法, 包含连接模式（SOME OK）和断开模式（TODO）
    //
    public interface Connector
    {
        void Connect();              // connect database
        void Connect(string dbName); // connect database with a connection string

        void ManageDataOnMode();  // 连接模式（On Mode）管理数据 
        void ManageDataOffMode(); // 连接模式（Off Mode）管理数据 

    }

    // Summary:
    //   This class is for 'MSSQL'.
    //
    public class MsSqlConnector : Connector
    {
        // Override
        public void Connect()
        {
            //
        }

        public void Connect(string dbName)
        {
            throw new NotImplementedException();
        }

        public void ManageDataOffMode()
        {
            throw new NotImplementedException();
        }

        public void ManageDataOnMode()
        {
            throw new NotImplementedException();
        }
    }

    // Summary:
    //   This class is for 'MYSQL'.
    public class MySQLConnector : Connector
    {
        // Override
        public void Connect() { }

        public void Connect(string dbName)
        {
            throw new NotImplementedException();
        }

        public void ManageDataOffMode()
        {
            throw new NotImplementedException();
        }

        public void ManageDataOnMode()
        {
            throw new NotImplementedException();
        }
    }
}