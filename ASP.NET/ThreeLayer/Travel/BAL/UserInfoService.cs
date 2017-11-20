using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class UserInfoService
    {
        // private static IUserInfo iuser = DataAccess.GetUserInfo();

        private static IUserInfo iuser = (IUserInfo)DataAccess.Get("UserInfo");

        // 注册
        public static bool SignUp(UserInfo user)
        {
            return iuser.AddUser(user);
        }

        // 登录
        public static UserInfo SignIn(string username, string password)
        {
            return iuser.GetUser(username, password);
        }
    }
}
