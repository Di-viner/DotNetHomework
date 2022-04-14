using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task1;

namespace Homework8_4._8
{

    public partial class Form1 : Form
    {
        public List<Order> DisplayOrders { get; set; }

        OrderService myService = new OrderService();
        List<Cargo> cargoList;
        List<Customer> customerList;
        List<OrderDetails> orderDetailsList;
        List<Order> ordersList;
        public Form1()
        {
            InitializeComponent();
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
            foreach (var order in ordersList)
                myService.AddOrder(order);
            this.comboBox1.SelectedIndex = 0;

            bindingSource_order.DataSource = new List<Order>(myService.OrderList);

        }

        private void btn_que_Click(object sender, EventArgs e)
        {
            List<Order> DisplayList;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    DisplayList = new List<Order>(myService.OrderList);
                    break;
                case 1:
                    DisplayList = new List<Order>(myService.FindById(int.Parse(txt_que.Text)));
                    break;
                case 2:
                    DisplayList = new List<Order>(myService.FindByTotalCost(long.Parse(txt_que.Text)));
                    break;
                case 3:
                    DisplayList = new List<Order>(myService.FindByCustomerName(txt_que.Text));
                    break;
                case 4:
                    DisplayList = new List<Order>(myService.FindByCargoName(txt_que.Text));
                    break;
                default:
                    DisplayList = new List<Order>(myService.OrderList);
                    //bindingSource_order.DataSource = myService;
                    //bindingSource_order.DataMember = "OrderList";
                    break;
            }
            bindingSource_order.DataSource = DisplayList;
        }

        private void bindingSource_order_CurrentChanged(object sender, EventArgs e)
        {
            bindingSource_details.DataSource = bindingSource_order.Current;
            //bindingSource_order.RemoveCurrent();
        }
        private void btn_del_Click(object sender, EventArgs e)
        {
            Order order = bindingSource_order.Current as Order;
            bindingSource_order.RemoveCurrent();
            if (order != null)
            myService.DeleteOrder(order.Id);
        }
    }
}
