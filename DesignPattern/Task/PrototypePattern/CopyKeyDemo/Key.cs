using System;

namespace PrototypePattern.CopyKeyDemo
{
    abstract class Key : ICloneable
    {
        public string Type { set; get; }
        public string Color { set; get; }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public void Setting(string type, string color)
        {
            Type = type;
            Color = color;
        }
    }
}
