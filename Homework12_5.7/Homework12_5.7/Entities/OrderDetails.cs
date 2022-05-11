using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    public class OrderDetails
    {
        private static int counter = 1;
        public int Id { get; set; }
        public virtual Cargo OrderCargo { get; set; }   //货物
        public int Num { get; set; }            //货物数量
        public double TotalPrice { get
            { return OrderCargo.Price * Num; } }   //单则明细的货物价钱
        public OrderDetails() { }
        public OrderDetails(Cargo c, int num)
        {
            //Id = counter++;
            OrderCargo = c;
            Num = num;
        }
        public override string ToString()
        {
            return "订单明细    " + OrderCargo + " 货物数量: " + Num;
        }
        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                details.GetHashCode() == GetHashCode();
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
