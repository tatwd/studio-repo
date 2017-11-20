using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Model;
using IDAL;
using DbKit;

namespace DAL
{
    public class MsSqlUserInfo : IUserInfo
    {
        Connector connector = DbHelper.GetConnector("TravelDb");

        public bool AddUser(UserInfo user)
        {
            string sql   = "insert into [UserInfo] values(@username, @password)";
            string query = "select count([Username]) from [UserInfo] where [Username] = @username or [Password] = @password";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@username", user.Username),
                new SqlParameter("@password", user.Password)
            };

            int line = 0;

            if ((int)connector.Execute("scalar", query, parameter) <= 0) // 判断用户是否存在
            {
                line = (int)connector.Execute("non", sql, parameter); // 添加用户到数据库
            }

            return line > 0 ? true : false;
        }

        public UserInfo GetUser(string username, string password)
        {
            UserInfo user = new UserInfo();

            string sql = "select * from [UserInfo] where [Username] = @username and [Password] = @password";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            SqlDataReader reader = (SqlDataReader)connector.Execute("reader", sql, parameter);

            if (reader.Read())
            {
                user.Username = reader[0].ToString();
                user.Password = reader[1].ToString();
            }
            else
            {
                user = null;
            }

            reader.Close(); // Must close the reader!

            return user;
        }
    }
}
