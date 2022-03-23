using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Order
    {
        public static int count = 1;                        //指示订单唯一Id
        public int Id { get;}                               //订单号
        public DateTime Time { get; set; }                  //下单时间
        public List<OrderDetails> Details = new List<OrderDetails>();   //明细列表
        public Customer OrderCustomer { get; set; }         //顾客信息
        public double TotalCost { get                       //账单总花费
            {
                double totalCost = 0;
                foreach (OrderDetails detail in Details)
                    totalCost += detail.TotalPrice;
                return totalCost;
            }}
        public Order(DateTime d, Customer c)
        {
            Id = count++;
            Time = d;
            OrderCustomer = c;
        }
        public void AddDetails(OrderDetails details)    //添加账单明细
        {
            Details.Add(details);           
        }
        public void DeleteDetails(OrderDetails details) //删除账单明细
        {
            Details.Remove(details);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("订单号:" + Id + " 订单时间: " + Time + " 顾客姓名:" + OrderCustomer.Name + " 订单金额: " + TotalCost);
            sb.AppendLine();
            foreach(var detail in Details)
                sb.AppendLine(detail.ToString());
            return sb.ToString();
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        public override bool Equals(object? obj)
        {
            return obj is Order order&&
                Id == order.Id;
        }
    }
}
