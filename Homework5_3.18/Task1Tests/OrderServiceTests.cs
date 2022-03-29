using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService service;
        List<Cargo> cargoList;
        List<Customer> customerList;
        List<OrderDetails> orderDetailsList;
        List<Order> ordersList;
        Order newOrder;
        [TestInitialize]
        public void TestInitialize()
        {
            Cargo.ResetCounter();
            Customer.ResetCounter();
            OrderDetails.ResetCounter();
            Order.ResetCounter();
            cargoList = new List<Cargo>() { new("Sweather", 20), new("Basketball", 10), new("Notebook", 5), new("Milk", 3) };
            customerList = new List<Customer>() { new("Martin"), new("Jalen"), new("Christopher"), new("Kevin") };
            orderDetailsList = new List<OrderDetails>() { new(cargoList[0], 3), new(cargoList[1], 5), new(cargoList[2], 7), new(cargoList[3], 9) };
            ordersList = new List<Order>() { new(customerList[0]), new(customerList[1]), new(customerList[2]) };
            ordersList[0].AddDetails(orderDetailsList[0]);
            ordersList[0].AddDetails(orderDetailsList[1]);
            ordersList[1].AddDetails(orderDetailsList[1]);
            ordersList[1].AddDetails(orderDetailsList[2]);
            ordersList[2].AddDetails(orderDetailsList[2]);
            ordersList[2].AddDetails(orderDetailsList[3]);
            service = new OrderService();
            foreach (var order in ordersList)
                service.AddOrder(order);

            newOrder = new Order(customerList[3]);
            newOrder.AddDetails(orderDetailsList[3]);
            newOrder.AddDetails(orderDetailsList[0]);
        }
        [TestMethod()]
        public void GetEndTest()
        {
            Assert.AreEqual(3, service.GetEnd().Id);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddOrderTest1()
        {
            service.AddOrder(null);
        }
        [TestMethod()]
        public void AddOrderTest2()
        {
            service.AddOrder(newOrder);
            Assert.AreEqual(4, service.GetEnd().Id);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteOrderTest1()
        {
            service.DeleteOrder(0);
        }
        [TestMethod()]
        public void DeleteOrderTest2()
        {
            service.DeleteOrder(3);
            Assert.AreEqual(2, service.GetEnd().Id);
        }
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteOrderTest3()
        {
            service.DeleteOrder(5);
        }
        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void ModifyOrderTest1()
        {
            service.ModifyOrder(5);
        }

        [TestMethod()]
        public void ModifyOrderTest2()
        {
            service.ModifyOrder(3, null, customerList[3]);
            Assert.AreEqual(customerList[3], service.GetEnd().OrderCustomer);
        }

        [TestMethod()]
        public void ModifyOrderTest3()
        {
            service.ModifyOrder(3, new List<OrderDetails>() { orderDetailsList[1], orderDetailsList[3]});
            List<OrderDetails> toCheck = new List<OrderDetails>() { orderDetailsList[1], orderDetailsList[3] };
            for(int i = 0; i < service.GetEnd().Details.Count; i++)
                Assert.AreEqual(toCheck[i], service.GetEnd().Details[i]);
        }
        [TestMethod()]
        [ExpectedException(typeof (ArgumentException))]
        public void FindByIdTest1()
        {
            service.FindById(-1);
        }
        [TestMethod()]
        public void FindByIdTest2()
        {
            Assert.AreEqual(3, service.FindById(3).Id);
        }
        public void FindByIdTest3()
        {
            Assert.AreEqual(null, service.FindById(5));
        }
        [TestMethod()]
        public void FindTest1()
        {
            List<Order> toCheck = service.Find("Sweather", null, null);
            Assert.AreEqual(1, toCheck.FirstOrDefault().Id);
        }
        [TestMethod()]
        public void FindTest2()
        {
            List<Order> toCheck = service.Find("Computer", null, null);
            Assert.AreEqual(null, toCheck.FirstOrDefault());
        }
        [TestMethod()]
        public void FindByCargoNameTest()
        {
            List<Order> toCheck = service.FindByCargoName("Basketball");
            for (int i = 0; i < toCheck.Count; i++)
                Assert.AreEqual(i + 1, toCheck[i].Id);
        }
        [TestMethod()]
        public void FindByTotalCostTest()
        {
            Assert.AreEqual(110, service.FindByTotalCost(110).First().TotalCost);
        }

        [TestMethod()]
        public void FindByCustomerNameTest()
        {
            Assert.AreEqual("Martin", service.FindByCustomerName("Martin").First().OrderCustomer.Name);
        }

        [TestMethod()]
        public void FindAllTest()
        {
            List<Order> toCheck = service.FindAll();
            for (int i = 0; i < toCheck.Count; i++)
                Assert.AreEqual(3 - i, toCheck[i].Id);
        }
        [TestMethod()]
        public void SortTest()
        {
            service.Sort();
            int i = 1;
            foreach(var item in service.OrderList)
                Assert.AreEqual(i++, item.Id);
        }

        [TestMethod()]
        public void SortTest1()
        {
            service.Sort((o1, o2) => (int)(o2.TotalCost - o1.TotalCost));
            int i = 1;
            foreach (var item in service.OrderList)
                Assert.AreEqual(i++, item.Id);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortTest2()
        {
            service.Sort(null);
        }
        [TestMethod()]
        public void ImportTest()
        {
            service.Export("OrderList.xml");
            int count = service.OrderList.Count;
            for (int i = 1; i < count + 1; i++) 
                service.DeleteOrder(i);
            service.Import("OrderList.xml");
            int j = 1;
            foreach (var item in service.OrderList)
                Assert.AreEqual(j++, item.Id);
        }
    }
}