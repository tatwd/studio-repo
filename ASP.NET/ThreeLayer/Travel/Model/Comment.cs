using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comment
    {
        public int      CmntId    { set; get; }
        public string   Username  { set; get; }
        public int      ArticleId { set; get; }
        public string   Content   { set; get; }
        public DateTime CmntTime  { set; get; } 
    }
}
