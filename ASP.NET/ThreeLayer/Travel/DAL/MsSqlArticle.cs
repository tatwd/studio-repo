using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using IDAL;
using DbKit;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MsSqlArticle : IArticle
    {
        Connector connector = DbHelper.GetConnector("TravelDb");

        public bool AddArticle(Article article)
        {
            string sql = "insert into [Article] values(@username, @title, @content, @createTime)";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@username",     article.Username),
                new SqlParameter("@title",           article.Title),
                new SqlParameter("@content",       article.Content),
                new SqlParameter("@createTime", article.CreateTime)
            };

            return (int)connector.Execute("non", sql, parameter) > 0 ? true : false;
        }

        // 选择文章数
        // count.length != 0 时返回前多少篇文章
        //
        public DataTable SelectArticle(params int[] count)
        {
            string sql = "select * from [Article] order by [CreateTime] desc";

            if (count[0] != 0)
            {
                sql = String.Format("select top {0} * from [Article] order by [CreateTime] desc", count[0]);
            }

            return connector.GetDataTable(sql);
        }
    }
}
