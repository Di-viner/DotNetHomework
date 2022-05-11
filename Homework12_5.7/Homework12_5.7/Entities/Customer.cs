using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task1
{
    [Serializable]
    public class Customer
    {
        private static int counter = 1;       //指示顾客唯一Id
        public int ID { get; set; }
        public string Name { get; set; }
        public Customer() { }
        public Customer(string name)
        {
            //ID = counter++;
            Name = name;
        }
        public override string ToString()
        {
            return Name + "(" + ID + ")"; 
        }
        public override bool Equals(object obj)
        {
            return obj is Customer customer && 
                ID == customer.ID;
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
