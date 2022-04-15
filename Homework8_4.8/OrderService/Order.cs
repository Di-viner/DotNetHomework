using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task1
{
    [Serializable]
    public class Order
    {
        private static int counter = 1;                                    //指示订单唯一Id
        public int Id { get; set; }                                           //订单号
        public Customer OrderCustomer { get; set; }                     //顾客信息
        public DateTime Time { get; set; }                              //下单时间
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();   //明细列表
        public double TotalCost { 
            get => Details.Sum(d => d.TotalPrice);
            /*get                                   //账单总花费
            {
                double totalCost = 0;
                foreach (OrderDetails detail in Details)
                    totalCost += detail.TotalPrice;
                return totalCost;
            }*/}
        public Order()
        {
            Id = counter++;
            Time = DateTime.Now;
        }
        public Order(Customer customer)
        {
            Id = counter++;
            Time = DateTime.Now;
            if (customer == null)
                throw new ArgumentNullException("添加订单异常，顾客名不能为空");
            OrderCustomer = customer;
        }
        public void AddDetails(OrderDetails details)    //添加账单明细
        {
            if (Details.Contains(details))
                throw new ApplicationException("此订单明细已存在，添加失败");
            Details.Add(details);           
        }
        public void DeleteDetails(OrderDetails details) //删除账单明细
        {
            if (!Details.Contains(details))
                throw new ApplicationException("此订单明细不存在，删除失败");
            Details.Remove(details);
        }
        public void ModifyDetails(List<OrderDetails> detailList)
        {
            if (detailList == null)
                throw new ApplicationException("为订单修改明细失败，调用参数为NULL");
            Details = detailList;
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
            return 2108858624 + Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return obj is Order order&&
                Id == order.Id;
        }
        public static void ResetCounter()
        {
            counter = 1;
        }


    }
}
