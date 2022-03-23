using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task1
{
    internal class Customer
    {
        public static int counter = 1;       //指示顾客唯一Id
        public int Id { get; }
        public string Name { get; set; }
        public Customer(string name)
        {
            Id = counter++;
            Name = name;
        }
        public override string ToString()
        {
            return "客户名称: " + Name; 
        }
    }
}
