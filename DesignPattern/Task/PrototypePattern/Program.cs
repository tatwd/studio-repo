
namespace PrototypePattern
{
    using System;
    using CopyKeyDemo;

    class Program
    {
        static void Main(string[] args)
        {
            CopperKey copperKey = new CopperKey("黄色");

            Key key = (Key)KeyManager.Copy(copperKey, "铁质", "银色"); // 开始配

            // Console.WriteLine(key is InorKey); // False
            Console.WriteLine($"这是把{ key.Type }{ key.Color }的钥匙！");
        }
    }
}
