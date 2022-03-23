using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task1
{
    internal class OrderService
    {
        public List<Order> OrderList = new List<Order>();   //订单服务类里的订单列表
        public void AddOrder(Order o)                       //添加订单，参数为Order类型对象
        {
            OrderList.Add(o);
        }
        public void DeleteOrder(int id)                     //删除id号订单
        {
            Order o = FindById(id);
            OrderList.Remove(o);
            /*******************
            if (OrderList.FindIndex(i => i.Id == id) != -1)
                OrderList.RemoveAt(OrderList.FindIndex(i => i.Id == id));
            else
                throw new ArgumentException("删除订单时参数错误");
            ********************/
        }
        public void ModifyOrder(int id, List<OrderDetails> details)//修改订单
        {
            Order o = FindById(id);
            o.Details = details;
        }

        public Order FindById(int id)                               //按照id查询订单
        {
            Order o = OrderList.Where(i => i.Id == id).First();
            if (o == null)
                throw new ArgumentException("按照id查找订单时参数错误");
            return o;
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
                result = result.Where(i =>
                {
                    return i.OrderCustomer.Name == customerName;
                });
            if (totalCost != null)
                result = result.Where(i =>
                {
                    return i.TotalCost == totalCost;
                });
            return result.OrderBy(i => i.TotalCost).ToList();//查询结果按照订单总金额排序返回
        }

        public void Sort()                      //按照Id号进行排序
        {
            OrderList.Sort((o1, o2) => o1.Id - o2.Id);
        }
        public void Sort(Comparison<Order> cmp) //按照自定义方法进行排序
        {
            OrderList.Sort(cmp);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in OrderList)
                sb.Append(item.ToString());
            return sb.ToString();
        }


        /*******************
        public void Modify(Order o)
        {
            OutputOrderInfo(o);
        }
        public void OutputOrderInfo(Order o)
        {
            Console.WriteLine("修改订单中，订单明细如下:");
            Console.WriteLine(o.Details.ToString());
        }
        public Order GetOrderFromConsole()              //从控制台获得订单信息
        {
            
            Console.WriteLine("请输入订单消息");
            Console.Write("请输入下单时间(年、月、日):");
            string[] date = Console.ReadLine().Split(' ');
            Console.WriteLine("请输入顾客姓名:");
            string name = Console.ReadLine();
            return new Order(new(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])), new(name));           
        }
        *******************/
    }
}
