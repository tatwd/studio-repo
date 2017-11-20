using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Model;

namespace IDAL
{
    public interface IReply
    {
        bool AddReply(Reply reply);

        DataTable SelectReply(int id);
    }
}
