using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Homework11_4._29
{
    internal class Program
    {
        static void Main(string[] args)
        {

            OrderService orderservice = new();
            Random random = new Random();
            Cargo[] cargoList = { new("Apple", 5), new("Milk", 3), new("Book", 20), new("T-shirt", 50), new("Desk", 80) };
            //for(int i = 0; i < cargoList.Length; i++)
            //orderservice.AddCargo(cargoList[i]);
            Customer[] customerList = { new("James"), new("Jalen"), new("Martin") };
            //for (int i = 0; i < customerList.Length; i++) 
            //orderservice.AddCustomer(customerList[i]);
            //OrderDetails[] orderDetailsList = { new(cargoList[0], random.Next(100)),
            //new(cargoList[1], random.Next(100)),
            //new(cargoList[2], random.Next(100)),
            //new(cargoList[3], random.Next(100)),
            //new(cargoList[4], random.Next(100))};
            //for (int i = 0; i < orderDetailsList.Length; i++)
            //orderservice.AddOrderDetail(orderDetailsList[i]);

            //在orderservice添加订单
            for (int i = 0; i < customerList.Length; i++)
            {
                Order o = new(customerList[i], new List<OrderDetails>() { new(cargoList[i], random.Next(100)) });
                orderservice.AddOrder(o);
                /*
                for (int j = 0; j < 3; j++)
                {
                    bool flag = true;               //flag为false，则有相同的账单明细
                    OrderDetails od = orderDetailsList[random.Next(orderDetailsList.Length)];
                    foreach (var d in o.Details)
                    {
                        if (d.Equals(od))
                            flag = false;
                    }
                    if (flag)
                        o.AddDetails(od);
                }*/
            }

            Console.WriteLine("查找ID为1的订单：");
            Order item = orderservice.QueryByID(1).FirstOrDefault();
            Console.WriteLine(item);

            Console.WriteLine("删除ID为1的订单");
            orderservice.DeleteOrder(1);

            Console.WriteLine("查找ID为2的订单,并对下单顾客进行修改");
            item = orderservice.Query(i => i.ID == 2).FirstOrDefault();
            Console.WriteLine(item);
            Customer customer = new Customer("Chet");
            orderservice.UpdateOrder(2, customer);
            item = orderservice.Query(i => i.ID == 2).FirstOrDefault();
            Console.WriteLine(item);
            Console.WriteLine();

        }
     }
    
}
