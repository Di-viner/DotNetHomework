using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7_4._1
{
    public partial class Form1 : Form
    {
		private Graphics graphics;
		Pen[] pen = new Pen[] { Pens.Black, Pens.Red, Pens.Green, Pens.Blue, Pens.Purple, Pens.Pink, Pens.Brown, Pens.Lavender };
		Pen selectedPen = Pens.Black;
		double th1;
		double th2;
		double per1;
		double per2;
		double length;
		int n;
		public Form1()
        {
            InitializeComponent();
			//this.Paint += new PaintEventHandler(this.Form1_Paint);
        }

		private void Panel1_Paint(object sender, PaintEventArgs e)
		{
			graphics = e.Graphics;
			n = int.Parse(textBox_recusionLength.Text);
			length = double.Parse(textBox_Length.Text);
			per1 = double.Parse(textBox_per1.Text);
			per2 = double.Parse(textBox_per2.Text);
			th1 = double.Parse(textBox_th1.Text) * Math.PI / 180;
			th2 = double.Parse(textBox_th2.Text) * Math.PI / 180;
			drawCayleyTree(n, panel1.Width / 2, panel1.Height, length, -Math.PI / 2);
		}



		void drawCayleyTree(int n,
				double x0, double y0, double length, double th)
		{
			if (n == 0) return;

			double x1 = x0 + length * Math.Cos(th);
			double y1 = y0 + length * Math.Sin(th);

			drawLine(x0, y0, x1, y1);

			drawCayleyTree(n - 1, x1, y1, per1 * length, th + th1);
			drawCayleyTree(n - 1, x1, y1, per2 * length, th - th2);
		}
		void drawLine(double x0, double y0, double x1, double y1)
		{
			graphics.DrawLine(
				selectedPen,
				(int)x0, (int)y0, (int)x1, (int)y1);
		}

        private void button_draw_Click(object sender, EventArgs e)
        {
			this.panel1.Refresh();
		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			selectedPen = pen[this.comboBox1.SelectedIndex];
        }
    }
}
