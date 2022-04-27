using System;
using System.Collections;
using System.Collections.Concurrent;
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
        private int count;
        //将哈希表换成字典形式
        private ConcurrentDictionary<string, bool> DownloadPages { get; set; } = new ConcurrentDictionary<string, bool>();
        private ConcurrentQueue<string> DownloadQueue { get; set; } = new ConcurrentQueue<string>();
        private string startUrl;                    //开始爬取的网站
        public Action<string, string> GetInfo;      //定义获取消息的事件
        
        public SimpleCrawler(string startUrl)
        {
            this.startUrl = startUrl;
            this.urls = new Hashtable();
            this.urls.Add(startUrl, false);
            this.count = 0;
        }
        public async Task CrawlAsync()
        {
            DownloadQueue.Enqueue(startUrl);
            while (DownloadPages.Count <= 10 && DownloadQueue.Count > 0) //爬取网页个数小于10，且存在可爬取网页
            {
                string url;
                DownloadQueue.TryDequeue(out url);
                string html = await DownloadAsync(url);
                DownloadPages[url] = true;
                GetInfo(url, "网页爬取成功");
                Parse(html,url);
            }
        }
        /****这个Crawl方法没有使用并行*****
        public void Crawl()
        {
            while (DownloadPages.Count <= 10)
            {
                string current = null;
                string html = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
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
                Parse(html, current);               //解析,并加入新的链接
            }
        }
        *****************/
        /***************这个Download方法没有使用并行
        public string DownLoad(string url)//下载
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
                throw ex;
            }
        }
        *****************/
        private async Task<string> DownloadAsync(string url)//可以返回值的异步操作
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = await webClient.DownloadStringTaskAsync(url);//作为资源下载string从URI指定为使用task对象的异步操作
                string fileName = DownloadPages.Count.ToString();
                await Task.Factory.StartNew(() => File.WriteAllText(fileName, html, Encoding.UTF8));//创建并启动任务
                return html;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private void Parse(string html, string current)//解析
        {

            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(htm|html|aspx|jsp)[""']";
            string HostRegex = "^" + new Uri(startUrl).Host + "$";          //原网站的host对应正则表达式
            MatchCollection matches = new Regex(strRef).Matches(html);      //找到存在可爬取的网页
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                string abUrl = ToAbsUrl(strRef, current);                   //构造绝对路径
                if (abUrl.Length == 0) continue;
                if (!DownloadPages.ContainsKey(abUrl) && Regex.IsMatch(new Uri(abUrl).Host, HostRegex))
                {
                    DownloadQueue.Enqueue(abUrl);
                    DownloadPages[abUrl] = false;
                }
            }
        }

        private String ToAbsUrl(string strRef, string current)  //相对路径转换为绝对路径
        {
            Uri currentUri = new Uri(current);                  //根据指定的URI和相对URI字符串构造URI实例
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
