using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char op;
            double x, y;
            x = Double.Parse(textBox1.Text);
            y = Double.Parse(textBox2.Text);
            op = Char.Parse(comboBox1.SelectedItem.ToString());
            switch (op)
            {
                case '+':
                    label1.Text = (x + y).ToString();
                    break;
                case '-':
                    label1.Text = (x - y).ToString();
                    break;
                case '*':
                    label1.Text = (x * y).ToString();
                    break;
                case '/':
                    label1.Text = (x / y).ToString();
                    break;
                case '%':
                    label1.Text = (x % y).ToString();
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
