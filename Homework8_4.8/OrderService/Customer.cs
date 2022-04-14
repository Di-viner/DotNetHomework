using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task1
{
    public class Customer
    {
        private static int counter = 1;       //指示顾客唯一Id
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer() { }
        public Customer(string name)
        {
            Id = counter++;
            Name = name;
        }
        public override string ToString()
        {
            return Name + "(" + Id + ")"; 
        }
        public override bool Equals(object obj)
        {
            return obj is Customer customer && 
                Id == customer.Id;
        }
        
        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
        public static void ResetCounter()
        {
            counter = 1;
        }
    }
}
