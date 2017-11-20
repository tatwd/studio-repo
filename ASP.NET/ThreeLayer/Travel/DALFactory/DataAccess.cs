using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Reflection;
using IDAL;

namespace DALFactory
{
    public class DataAccess
    {
        // Summary:
        //   利用反射得到对应的接口
        //

        private static string dbType  = ConfigurationManager.AppSettings["DbType"].ToString();
        private static string dalType = ConfigurationManager.AppSettings["DalType"].ToString();

        // public static IUserInfo GetUserInfo()
        // {
        //     string className = dalType + "." + dbType + "UserInfo";
        // 
        //     return (IUserInfo)Assembly.Load(dalType).CreateInstance(className);
        // }

        // Summary:
        //   合并所有的方法
        //
        public static object Get(string interfaceName)
        {
            string className = dalType + "." + dbType + interfaceName;

            return Assembly.Load(dalType).CreateInstance(className); // 赋值时需作拆箱处理
        }
    }
}
