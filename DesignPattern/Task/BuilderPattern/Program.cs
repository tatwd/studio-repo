using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            Builder b1 = new PuTongTaoCanBuilder();
            Builder b2 = new HuangJinTaoCanBuilder();

            director.Construct(b1);
            TaoCan taocan1 = b1.GetTaoCan();
            taocan1.Show();

            director.Construct(b2);
            TaoCan taocan2 = b2.GetTaoCan();
            taocan2.Show();
        }
    }
}
