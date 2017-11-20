using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article
    {
        public int ArticleId { set; get; }
        public string Username { set; get; }
        public string Title { set; get; }
        public string Content { set; get; }
        public DateTime CreateTime { set; get; }

    }
}
