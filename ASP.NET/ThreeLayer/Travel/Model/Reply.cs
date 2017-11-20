using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reply
    {
        public int    ReplyId { set; get; } 
        public string Username { set; get; }
        public int CmntId { set; get; }
        public DateTime ReplyTime { set; get; }
        public int ReplyAim { set; get; }
    }
}
