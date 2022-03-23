using System;
namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OrderService orderservice = new();
            Random random = new Random();
            Cargo[] cargoList = { new("Apple", 5), new("Milk", 3), new("Book", 20), new("T-shirt", 50), new("Desk", 80) };
            Customer[] customerList = { new("James"), new("Jalen"), new("Martin") };
            OrderDetails[] orderDetailsList = { new(cargoList[0], random.Next(100)), 
                                                new(cargoList[1], random.Next(100)),
                                                new(cargoList[2], random.Next(100)),
                                                new(cargoList[3], random.Next(100)),
                                                new(cargoList[4], random.Next(100))};
            //在orderservice添加订单
            for(int i = 0; i < customerList.Length; i++)
            {
                Order o = new(DateTime.Now.AddDays(i), customerList[i]);
                for (int j = 0; j < 3; j++)
                {
                    bool flag = true;               //flag为false，则有相同的账单明细
                    OrderDetails od = orderDetailsList[random.Next(orderDetailsList.Length)];
                    foreach(var d in o.Details)
                    {
                        if (d.Equals(od))
                            flag = false;
                    }
                    if (flag)
                        o.AddDetails(od);
                }
                orderservice.AddOrder(o);
            }
            Console.WriteLine("添加订单");
            Console.WriteLine(orderservice.ToString());

            //在orderservice修改订单,这里修改第一条订单的第一个订单明细里的货物和数量
            List<OrderDetails> tempList = orderservice.OrderList[0].Details;
            if(tempList != null)
            {
                tempList[0].OrderCargo = cargoList[0];
                tempList[0].Num = 100;
            }
            Console.WriteLine("修改订单");
            Console.WriteLine(orderservice.ToString());

            //查询订单
            Console.WriteLine("查询订单");
            Console.WriteLine(orderservice.FindById(3));
            //按货物名查询订单，并按价钱排序
            List<Order> tempList2 = orderservice.Find("Apple");
            if (tempList2 != null)
                foreach(var d in tempList2)
                    Console.WriteLine(d.ToString());

            //删除订单
            orderservice.DeleteOrder(1);
            Console.WriteLine("删除订单");
            Console.WriteLine(orderservice.ToString());

            //排序，这里按照Id号降序重新排序
            Console.WriteLine("对订单进行排序");
            orderservice.Sort((o1, o2) => o2.Id - o1.Id);
            Console.WriteLine(orderservice.ToString());

        }
    }

}
