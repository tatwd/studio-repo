using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    sealed class GenerateID
    {
        private static GenerateID instance = new GenerateID();
        private int id = 10001;

        private GenerateID() { }

        public static GenerateID GetInstance()
        {
            return instance;
        }

        // generate a id
        public int GetId()
        {
            return id ++;
        }
    }
}
