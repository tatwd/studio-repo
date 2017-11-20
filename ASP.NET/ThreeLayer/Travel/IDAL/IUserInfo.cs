using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Model;

namespace IDAL
{
    public interface IUserInfo
    {
        bool AddUser(UserInfo user);

        UserInfo GetUser(string username, string password);
    }
}
