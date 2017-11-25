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
    public class ArticleService
    {
        private static IArticle iartitcle = (IArticle)DataAccess.Get("Article");

        public static bool AddArticle(Article article)
        {
            return iartitcle.AddArticle(article);
        }

        public static DataTable GetArticle(params int[] count)
        {
            return iartitcle.SelectArticle(count);
        }

        public static Article GetArtCleById(int id)
        {
            //return null;

            DataTable data = GetArticle(0); // 返回所有文章

            List<Article> list = new List<Article>();

            foreach (DataRow row in data.Rows)
            {
                Article article = new Article();

                article.ArticleId = (int)row["ArticleId"];
                article.Username = (string)row["Username"];
                article.Title = (string)row["Title"];
                article.Content = (string)row["Contents"];
                article.CreateTime = (DateTime)row["CreateTime"];

                list.Add(article);
            }

            foreach (Article item in list)
            {
                if (item.ArticleId == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
