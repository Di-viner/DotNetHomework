using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class OrderDetails
    {
        public static int counter = 1;
        public int Id { get; }
        public Cargo OrderCargo { get; set; }   //货物
        public int Num { get; set; }            //货物数量
        public double TotalPrice { get
            { return OrderCargo.Price * Num; } }   //单则明细的货物价钱
        public OrderDetails(Cargo c, int num)
        {
            Id = counter++;
            OrderCargo = c;
            Num = num;
        }
        public override string ToString()
        {
            return "订单明细    " + OrderCargo.ToString() + " 货物数量: " + Num + " 货物花费: " + TotalPrice;
        }
        public override bool Equals(object? obj)
        {
            return obj is OrderDetails details &&
                Id == details.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
