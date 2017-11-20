using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Model;

namespace IDAL
{
    public interface IArticle
    {
        // 添加用户
        // true: 成功，false: 失败
        bool AddArticle(Article article);

        // 选择文章数
        DataTable SelectArticle(params int[] count);
    }
}
