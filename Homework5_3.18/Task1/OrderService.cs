using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace Task1
{
    public class OrderService
    {
        public List<Order> OrderList = new List<Order>();       //订单服务类里的订单列表,测试时为public属性
        public void AddOrder(Order order)                       //添加订单，参数为Order类型对象
        {
            if (order == null)
                throw new ArgumentNullException("添加订单失败，添加订单为NULL");
            if (OrderList.Contains(order))
                throw new ArgumentException("添加订单失败，此订单已存在");
            OrderList.Add(order);
        }
        public void DeleteOrder(int id)                         //删除id号订单
        {
            Order? order = FindById(id);
            if (order == null)
                throw new ApplicationException("删除订单失败，不存在此ID");
            OrderList.Remove(order);
        }
        public void ModifyOrder(int id, List<OrderDetails> details)//修改订单
        {
            Order? order = FindById(id);
            if (order == null)
                throw new ApplicationException("修改订单失败，不存在此ID");
            order.ModifyDetails(details);
        }
        public void ModifyOrder(int id, DateTime? datetime = null, Customer? customer = null)
        {
            Order? order = FindById(id);
            if (order == null)
                throw new ApplicationException("修改订单失败，不存在此ID");
            if(datetime != null)
                order.Time = (DateTime)datetime;
            if(customer != null)
                order.OrderCustomer = customer;
        }
        public Order? FindById(int id)                               //按照id查询订单
        {
            if (id <= 0)
                throw new ArgumentException("查询订单异常，查询ID应大于0");
            return OrderList.Where(i => i.Id == id).FirstOrDefault(); 
        }                                                           
        public List<Order> Find(string? cargoName = null, string? customerName = null, int? totalCost = null)//按照货物名，顾客姓名，总价钱查找订单
        {
            var result = OrderList.AsEnumerable();
            if (cargoName != null)
            {
                result = result.Where(i =>
                {
                    foreach (var detail in i.Details)
                        if (detail.OrderCargo.Name == cargoName)
                            return true;
                    return false;
                });
            }
            if (customerName != null)
                result = result.Where(i => i.OrderCustomer.Name == customerName);
            if (totalCost != null)
                result = result.Where(i => i.TotalCost == totalCost);
            return result.OrderBy(i => i.TotalCost).ToList();//查询结果按照订单总金额排序返回
        }
        public List<Order> FindByCargoName(string cargoName)
        {
            return OrderList.Where(o =>
            {
                foreach (var detail in o.Details)
                    if (detail.OrderCargo.Name == cargoName)
                        return true;
                return false;
            }).ToList();
        }
        public List<Order> FindByTotalCost(double cost)
        {
            return OrderList.Where(o =>
            {
                return o.TotalCost == cost;
            }).ToList();
        }
        public List<Order> FindByCustomerName(string customerName)
        {
            return OrderList.Where(o =>
            {
                return o.OrderCustomer.Name == customerName;    
            }).ToList();
        }
        public List<Order> FindAll()
        {
            return OrderList.OrderBy(o => o.TotalCost).ToList();
        }
        public void Sort()                      //按照Id号进行排序
        {
            OrderList.Sort((o1, o2) => o1.Id - o2.Id);
        }
        public void Sort(Comparison<Order> cmp) //按照自定义方法进行排序
        {
            if (cmp == null)
                throw new ArgumentNullException("排序时参数错误，未指定排序方式");
            OrderList.Sort(cmp);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in OrderList)
                sb.Append(item.ToString());
            return sb.ToString();
        }
        public void Export(string fileName = "OrderList.xml")
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)) 
            {
                xmlSerializer.Serialize(fs, OrderList);
            }
        }
        public void Import(string fileName = "OrderList.xml")
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
              
                List<Order> list = (List<Order>)xmlSerializer.Deserialize(fs);
                if (list == null)
                    throw new FileLoadException("载入文件错误");
                OrderList.AddRange(list);
            }
        }
        public Order GetEnd()
        {
            if (OrderList == null)
                throw new ApplicationException("返回最后一个订单异常，此时订单列表无订单");
            return OrderList[OrderList.Count - 1];
        }
    }
}
