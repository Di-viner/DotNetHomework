using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Task1
{
    public class Cargo
    {
        private static int counter = 1;    //用static类型变量counter初始化货物唯一ID
        public int ID { get; set; }
        public string Name { get; set; }  //货物名字
        public double Price { get;set; } //货物单价
        public Cargo() { }
        public Cargo(string name, double p)
        {
            //ID = counter++;
            Name = name;
            Price = p;
        }
        public override string ToString()
        {
            return ID + "-" + Name + "(" + Price + "￥)";
        }
        public override bool Equals(object obj)
        {
            return obj is Cargo cargo &&
                ID == cargo.ID;
        }
        
        public override int GetHashCode()
        {
            return 2108858624 + ID.GetHashCode();
        }
        
        public static void ResetCounter()
        {
            counter = 1;
        }
    }
}
