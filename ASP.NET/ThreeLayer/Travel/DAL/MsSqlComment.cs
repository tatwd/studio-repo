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
    public class MsSqlComment : IComment
    {
        Connector connector = DbHelper.GetConnector("TravelDb");

        public bool AddCmnt(Comment cmnt)
        {
            string sql = "insert into [Comment] values(@username, @articleId, @content, @cmntTime)";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@username",   cmnt.Username),
                new SqlParameter("@articleId", cmnt.ArticleId),
                new SqlParameter("@content",     cmnt.Content),
                new SqlParameter("@cmntTime",   cmnt.CmntTime)
            };

            return (int)connector.Execute("non", sql, parameter) > 0 ? true : false; 
        }

        public Comment SelectCmnt(int id)
        {
            Comment cmnt = new Comment();

            string sql = "select * from [Comment] where [CommentId] = @cmntId";

            SqlParameter[] parameter = new SqlParameter[] { new SqlParameter("@cmntId", id) };

            DataTable data = connector.GetDataTable(sql, parameter);

            if (data.Rows.Count != 0)
            {
                cmnt.CmntId    = (int)data.Rows[0][0];
                cmnt.Username  = data.Rows[0][1].ToString();
                cmnt.ArticleId = (int)data.Rows[0][2];
                cmnt.Content   = data.Rows[0][3].ToString();
                cmnt.CmntTime  = (DateTime)data.Rows[0][4];

                return cmnt;
            }

            return null;
        }

        public DataTable SameCmntToArticle(int id)
        {
            string sql = "select * from [Comment] where [ArticleId] = @articleId order by [CmntTime] desc";

            SqlParameter[] parameter = new SqlParameter[] { new SqlParameter("@articleId", id) };

            DataTable data = connector.GetDataTable(sql, parameter);

            return (data.Rows.Count != 0) ? data : null;
        }
    }
}
