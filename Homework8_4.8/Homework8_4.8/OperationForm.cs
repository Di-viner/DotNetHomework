using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Task1;

namespace Homework8_4._8
{
    public partial class OperationForm : Form
    {
        public Order newOrder;                      //新订单或传入待修改的订单
        public OrderService orderService;           //传入的orderservice参数
        public bool addFlag;                        //是否为新添加订单
        public OperationForm(OrderService myService)                    //添加订单构造函数
        {
            InitializeComponent();
            newOrder = new Order();//新建订单
            labelTitle.Text = "ADDING ORDER...";
            orderService = myService;
            addFlag = true;
        }
        public OperationForm(OrderService myService, Order OrderUpdate) //修改订单构造函数
        {
            InitializeComponent();
            newOrder = OrderUpdate;//获得传入订单
            labelTitle.Text = "UPDATING ORDER...";
            orderService = myService;
            addFlag = false;
        }
        private void OperationForm_Load(object sender, EventArgs e)     //窗口启动时
        {
            bindingSource_customer.DataSource = orderService.CustomerList;      //进行数据绑定
            bindingSource_details.DataSource = orderService.CargoList;
            if(addFlag == false)
            {
                int index = newOrder.OrderCustomer.Id;          //修改订单时，将选中订单高亮，并显示选中订单的订单明细
                dataGridView1.Rows[orderService.CustomerList.FindIndex((item) => item.Id == index)].Selected = true;
                foreach (var detail in newOrder.Details)
                {
                    var row = dataGridView2.Rows[orderService.CargoList.FindIndex((item) => item.Id == detail.OrderCargo.Id)];//根据订单具有的订单明细勾选复选框
                    row.Cells[0].Value = true;
                    row.Cells[4].Value = detail.Num;
                }
            }
        }
        private void btn_addcustomer_Click(object sender, EventArgs e)       //添加顾客按钮
        {
            string Name = Interaction.InputBox("Input Customer Name");       //获取顾客姓名
            try
            {
                Customer newCustomer = new Customer(Name);                   
                bindingSource_customer.Add(newCustomer);
            }
            catch(Exception)
            {
                MessageBox.Show("添加顾客异常");
            }
        }

        private void btn_addcargo_Click(object sender, EventArgs e)           //添加货物按钮
        {
            string Name = Interaction.InputBox("Input Cargo Name");           //获取货物名       
            string Price = Interaction.InputBox("Input Price");               //获取单价
            try
            {
                Cargo newCargo = new Cargo(Name, double.Parse(Price));
                bindingSource_details.Add(newCargo);
            }
            catch (Exception)
            {
                MessageBox.Show("添加货物异常");
            }
        }
        private void btn_save_Click(object sender, EventArgs e)                 //保存订单
        {
            Customer customer = bindingSource_customer.Current as Customer;
            if (customer == null)                                               //未选择订单
            {
                MessageBox.Show("Please Choose a customer");
                return;
            }
            if (addFlag)
                newOrder.Time = DateTime.Now;                                   //需要新建时设定下单时间
            newOrder.OrderCustomer = customer;
            newOrder.Details = new List<OrderDetails>();                        //新建或修改订单都重建一个details列表
            for (int i = 0; i < dataGridView2.RowCount; i++)                    //相当于将勾选中的选项添加进details列表
            {
               bool flag_include = (bool)dataGridView2[0, i].EditedFormattedValue;
                if (flag_include == false || (string)dataGridView2[4, i].EditedFormattedValue == "")
                    continue;
                int num = int.Parse((string)dataGridView2[4, i].EditedFormattedValue);
                int id = int.Parse((string)dataGridView2[1, i].EditedFormattedValue);
                if (num > 0)
                {
                    Cargo cargo = orderService.CargoList.Find((item) => item.Id == id);
                    newOrder.AddDetails(new OrderDetails(cargo, num));
                }
            }
            DialogResult = DialogResult.OK;
            Close();          
        }
    }
}
