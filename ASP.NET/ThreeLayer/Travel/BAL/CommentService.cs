using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class CommentService
    {
        private static IComment icmnt = (IComment)DataAccess.Get("Comment");

        public static bool AddCmnt(Comment cmnt)
        {
            return icmnt.AddCmnt(cmnt);
        }

        public static Comment GetCmnt(int id)
        {
            return icmnt.SelectCmnt(id);
        }

        public static DataTable GetSameCmntToArticle(int id)
        {
            return icmnt.SameCmntToArticle(id);
        }
    }
}
