using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework9_4._15
{
    class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private string startUrl;
        private int count;
        public Action<string, string> GetInfo;
        public SimpleCrawler(string startUrl)
        {
            this.startUrl = startUrl;
            this.urls = new Hashtable();
            this.urls.Add(startUrl, false);
            this.count = 0;
        }
        /*************
        static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);//加入初始页面
            new Thread(myCrawler.Crawl).Start();
        }
        ****************/
        public void Crawl()
        {
            //Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                string current = null;
                string html = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                //Console.WriteLine("爬行" + current + "页面!");
                try
                {
                    html = DownLoad(current); // 下载
                }
                catch (Exception ex)
                {
                    GetInfo(current, "网页爬取失败：" + ex.Message);
                }
                urls[current] = true;
                count++;
                GetInfo(current, "网页爬取成功");
                Parse(html, current);//解析,并加入新的链接
                //Console.WriteLine("爬行结束");
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //return "";
                throw ex;
            }
        }

        private void Parse(string html, string current)
        {

            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(htm|html|aspx|jsp)[""']";
            string HostRegex = "^" + new Uri(startUrl).Host + "$";          //原网站的host对应正则表达式
            MatchCollection matches = new Regex(strRef).Matches(html);      //找到存在可爬取的网页
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                string abUrl = ToAbsUrl(strRef, current);        //构造完整地址
                if (strRef.Length == 0) continue;
                if (urls[abUrl] == null && Regex.IsMatch(new Uri(abUrl).Host, HostRegex))   //只爬取指定网站
                    urls[abUrl] = false;
            }
        }
        private String ToAbsUrl(string strRef, string current)
        {
            Uri currentUri = new Uri(current);    //根据指定的URI和相对URI字符串构造URI实例 
            try
            {
                Uri result = new Uri(strRef);
                return result.IsAbsoluteUri ? result.ToString() : new Uri(currentUri, strRef).ToString();
            }
            catch (Exception)
            {
                return new Uri(currentUri, strRef).ToString();
            }
        }
    }
}
