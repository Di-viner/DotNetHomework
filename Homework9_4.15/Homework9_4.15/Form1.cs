using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework9_4._15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Uri startUri = new Uri(textBox1.Text);
            }
            catch(UriFormatException ex)
            {
                MessageBox.Show("URL格式错误:" + ex.Message);
                textBox1.Clear();
                return;
            }
            SimpleCrawler simpleCrawler = new SimpleCrawler(textBox1.Text);
            simpleCrawler.GetInfo += GetCrawlInfo;
            richTextBox1.Clear();
            richTextBox1.AppendText("开始爬取");
            Task task = simpleCrawler.CrawlAsync();
        }
        private void GetCrawlInfo(string url, string info)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                Invoke(() => richTextBox1.AppendText($"URL: {url}\n爬取信息: {info}\n\n"),new object[] {url, info});
            }
            else
            {
                richTextBox1.AppendText($"URL: {url}\n爬取信息: {info}\n\n");
            }
        }

        private void Invoke(Action p, object[] vs)
        {
            throw new NotImplementedException();
        }
    }
}
