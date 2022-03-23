using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Cargo
    {
        public static int counter = 1;    //用static类型变量counter初始化货物唯一ID
        public int Id { get; }
        public string Name { get; set; }  //货物名字
        public double Price { get; set; } //货物单价
        public Cargo(string name, double p)
        {
            Name = name;
            Price = p;
            Id = counter++;
        }
        public override string ToString()
        {
            return " 货物Id: " + Id + " 货物名称: " + Name + " 货物单价: " + Price;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cargo cargo &&
                Id == cargo.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
