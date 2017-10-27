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
    //

    // Summary:
    //   ConnectorFactory - 连接器生产工厂
    //
    public class ConnecterFactory
    {
        // 连接器类名
        private static string ConnectorClassName { set; get; }

        // 获取当前程序集全名，只读
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
            else if(dbType.Equals("MYSQL", StringComparison.CurrentCultureIgnoreCase))
            {
                ConnectorClassName = "DbKitX.MySqlConnector";  // for mysql
            }
        }

        // Summary:
        //   根据数据库类型，获取一个通用连接数据库对象
        public static Connector GetConnector(string dbType)
        {
            SetConnectorClassName(dbType);  // 获取连接器类名

            // TODO: 反射实现带参的类创建
            //
            // eg: object[] param = new object[]{ ... } or not ?

            return (Connector)Assembly.Load(AssemblyName).CreateInstance(ConnectorClassName); // 利用反射创建一个连接器
        }

        // -------------------------------------
        // Extend other connector creators here.
        // -------------------------------------

        // User ...
    }

    // Summary
    //   Connector 连接器 - 接口, 定义了一些与ADO.NET相关的通用方法，包含连接模式（SOME OK）和断开模式（TODO）
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
        //   设置连接字符串
        //
        // Parameters:
        //   dbName:
        //     数据库名
        void SetConnectionString(string dbName);

        // Summary:
        //   连接模式（On Mode）管理数据
        //
        // TODO: delete or not delete ?
        // 
        void ManageData(string sql, params string[] param);

        // Summary:
        //   利用泛型对数据库数据进行增、删、改、查管理
        // 
        // Parameters:
        //   excuteType:
        //     执行类型，三个值
        //       0 - 执行增、删、改操作并返回受影响行数
        //       1 - 执行单条语句查询并返回第一行第一列
        //       2 - 执行查询语句并返回DataReader数据集
        //
        //   cmdText:
        //     SQL语句，带参或不带参
        //
        //   parameter:
        //     SqlParameter参数数组
        //
        T ManageData<T>(int executeType, string cmdText, params object[] parameter);

        // Summary:
        //   利用泛型对数据库数据进行增、删、改、查管理
        // 
        // Parameters:
        //   excuteType:
        //     执行类型，三个值：
        //       0 - 执行增、删、改操作并返回受影响行数
        //       1 - 执行单条语句查询并返回第一行第一列
        //       2 - 执行查询语句并返回DataReader数据集
        //
        //   procdureName:
        //     存储过程名
        //   
        //   securityType:
        //     安全类型 
        // 
        //   parameter:
        //     SqlParameter参数数组
        //
        //  TODO: how to declare this method?
        //
        // T ManageData<T>(int executeType, string procdureName, string securityType, params object[] parameter);

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
        //
        // TODO: has bug or not ?
        //
        void CloseAll();
    }

    // Summary:
    //   MsSqlConnector - SqlServer连接器
    //
    public class MsSqlConnector : Connector
    {
        // Summary:
        //   数据库连接对象
        private SqlConnection DbConnection { set; get; }

        // Summary:
        //   连接字符串
        private string ConnectionString { set; get; }

        // Summary:
        //   数据阅读器
        public SqlDataReader DataReader = null;

        // Override
        public void Connect()
        {
            // TODO
        }

        // Override
        public void Connect(string dbName)
        {
            SetConnectionString(dbName); // 设置连接字符串

            DbConnection = new SqlConnection(ConnectionString); // 创建连接对象

            OpenDb();
        }

        // Override
        public void SetConnectionString(string dbName)
        {
            if (ConnectionString != "")
            {
                ConnectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString; // 从Web.config中获取连接字符串
            }
        }

        // Override
        //
        // TODO: need to modify this method.
        //
        public void ManageData(string sql, params string[] param)
        {
            using (SqlCommand cmd = new SqlCommand(sql, DbConnection))
            {
                // TODO
            }
        }

        // Override
        public T ManageData<T>(int executeType, string cmdText, params object[] parameter)
        {
            using (SqlCommand cmd = new SqlCommand(cmdText, DbConnection))
            {
                if (parameter.Length != 0)
                {
                    SqlParameter[] parameters = (SqlParameter[])parameter; // 设置参数

                    cmd.Parameters.AddRange(parameters);
                }

                object result = null;

                switch (executeType.ToString()) // 判断执行类型
                {
                    // ExecuteNonQuery
                    case "0":  
                        result = cmd.ExecuteNonQuery();
                        break;

                    // ExecuteScalar
                    case "1":  
                        result = cmd.ExecuteScalar();   
                        result = result == null ? 0 : result; // 判断result是否为空
                        break;

                    // ExecuteReader
                    case "2":
                        DataReader = cmd.ExecuteReader();
                        result = DataReader;
                        break;
                }

                if (cmd.Parameters.Count != 0)
                {
                    cmd.Parameters.Clear(); // 清除SqlParameter
                }

                cmd.Cancel(); //  终止执行sql

                return (T)result; // 拆箱
            }
        }

        // Override
        public void ManageDataOffMode()
        {
            throw new NotImplementedException();
        }

        // Override
        public void OpenDb()
        {
            if (this.DbConnection.State != ConnectionState.Open)
            {
                this.DbConnection.Open(); // 打开数据库
            }
        }

        // Override
        public void CloseDb()
        {
            if (DbConnection.State != ConnectionState.Closed)
            {
                DbConnection.Close(); // 关闭数据库
            }
        }

        // Override
        public void CloseReader()
        {
            if (DataReader != null && !DataReader.IsClosed)
            {
                DataReader.Close();
            }
        }

        // Override
        public void CloseAll()
        {
            CloseReader(); // 关闭阅读器

            CloseDb();     // 关闭数据库
        }
        
        // Summary:
        //   This is a constructor of the class without parameter.
        public MsSqlConnector() { }

        // Summary:
        //   A constructor with a parameter.
        //
        // Parameters:
        //   dbName:
        //     The name of database connection string in Web.config. 
        public MsSqlConnector(string dbName)
        {
            SetConnectionString(dbName);
        }
    }

    // Summary:
    //   MySqlConnector - MySql连接器
    //
    // TODO 
    //
    public class MySqlConnector : Connector
    {
        // Override
        public void Connect() { }

        // Override
        public void Connect(string dbName)
        {
            throw new NotImplementedException();
        }

        // Override
        public void SetConnectionString(string dbName)
        {
            throw new NotImplementedException();
        }

        // Override
        public void ManageData(string sql, params string[] param)
        {
            throw new NotImplementedException();
        }

        // Override
        public T ManageData<T>(int executeType, string cmdText, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        // Override
        public void ManageDataOffMode()
        {
            throw new NotImplementedException();
        }

        // Override
        public void OpenDb()
        {
            throw new NotImplementedException();
        }

        // Override
        public void CloseDb()
        {
            throw new NotImplementedException();
        }

        // Override
        public void CloseAll()
        {
            throw new NotImplementedException();
        }
    }
}