using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    interface IFood
    {
        string Name { get; set; }
        string Taste { get; set; }
        string Area { get; set; }
    }
}
