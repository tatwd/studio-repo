using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Model;

namespace IDAL
{
    public interface IComment
    {
        bool AddCmnt(Comment cmnt);

        Comment SelectCmnt(int id);

        DataTable SameCmntToArticle(int id);
    }
}
