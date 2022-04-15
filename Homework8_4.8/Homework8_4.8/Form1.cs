using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Task1;

namespace Homework8_4._8
{

    public partial class Form1 : Form
    {

        public OrderService myService = new OrderService();
        public List<Cargo> cargoList;
        public List<Customer> customerList;
        public List<OrderDetails> orderDetailsList;
        public List<Order> ordersList;
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
        private void btn_que_Click(object sender, EventArgs e)      //查询订单按钮
        {
            List<Order> DisplayList;
            switch (comboBox1.SelectedIndex)
            {
                case 0://显示全部订单
                    DisplayList = new List<Order>(myService.OrderList);                 
                    break;
                case 1://按id查询
                    DisplayList = new List<Order>(myService.FindById(int.Parse(txt_que.Text)));
                    break;
                case 2://按总价查询
                    DisplayList = new List<Order>(myService.FindByTotalCost(long.Parse(txt_que.Text)));
                    break;
                case 3://按顾客姓名查询
                    DisplayList = new List<Order>(myService.FindByCustomerName(txt_que.Text));
                    break;
                case 4://按商品名查询
                    DisplayList = new List<Order>(myService.FindByCargoName(txt_que.Text));
                    break;
                default://显示全部订单
                    DisplayList = new List<Order>(myService.OrderList);
                    break;
            }
            bindingSource_order.DataSource = DisplayList;
        }
        private void bindingSource_order_CurrentChanged(object sender, EventArgs e)
        {
            bindingSource_details.DataSource = bindingSource_order.Current;
        }
        private void btn_del_Click(object sender, EventArgs e)      //删除订单按钮
        {
            Order order = bindingSource_order.Current as Order;
            bindingSource_order.RemoveCurrent();
            if (order != null) 
            myService.DeleteOrder(order.Id);
        }

        private void btn_add_Click(object sender, EventArgs e)      //添加订单按钮
        {
            OperationForm oForm = new OperationForm(myService);
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                myService.AddOrder(oForm.newOrder);
                bindingSource_order.Add(oForm.newOrder);  
                comboBox1.SelectedIndex = 0;
                btn_que_Click(sender, e);
            }
        }
        private void btn_upd_Click(object sender, EventArgs e)      //修改订单按钮
        {
            Order orderUpdate = bindingSource_order.Current as Order;
            if (orderUpdate == null)
            {
                MessageBox.Show("Please choose an order");
                return;
            }
            OperationForm oForm = new OperationForm(myService, orderUpdate);
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                orderUpdate = myService.OrderList.Find((item) => item.Id == orderUpdate.Id);
                orderUpdate.OrderCustomer = oForm.newOrder.OrderCustomer;
                orderUpdate.Details = oForm.newOrder.Details;
                btn_que_Click(sender, e);
            }
        }
    }
}
