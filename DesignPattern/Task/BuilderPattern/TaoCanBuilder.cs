using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    // 套餐
    class TaoCan
    {
        IList<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            foreach (var part in parts)
                Console.WriteLine(part);

            Console.WriteLine();
        }
    }

    // 建造者
    abstract class Builder
    {
        public abstract void AddHanBao();  // 汉堡
        public abstract void AddKeLe();    // 可乐
        public abstract void AddShuTiao(); // 薯条

        public abstract TaoCan GetTaoCan(); // 获取套餐

    }

    // 普通套装
    class PuTongTaoCanBuilder : Builder
    {
        TaoCan taocan = new TaoCan();

        public override void AddHanBao()
        {
            taocan.Add("普通套餐 - 汉堡");
        }

        public override void AddKeLe()
        {
            taocan.Add("普通套餐 - 可乐");
        }

        public override void AddShuTiao()
        {
            taocan.Add("普通套餐 - 薯条");
        }

        public override TaoCan GetTaoCan()
        {
            return taocan;
        }
    }

    // 黄金套餐
    class HuangJinTaoCanBuilder : Builder
    {
        TaoCan taocan = new TaoCan();

        public override void AddHanBao()
        {
            taocan.Add("黄金套餐 - 汉堡");
        }

        public override void AddKeLe()
        {
            taocan.Add("黄金套餐 - 可乐");
        }

        public override void AddShuTiao()
        {
            taocan.Add("黄金套餐 - 薯条");
        }

        public override TaoCan GetTaoCan()
        {
            return taocan;
        }
    }

    class Director
    {
        public void Construct(Builder builder)
        {
            builder.AddHanBao();
            builder.AddKeLe();
            builder.AddShuTiao();
        }
    }
}
