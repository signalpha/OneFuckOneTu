using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OneFuckOneTu
{
    class UrlProcessing
    {

        //解析网址Url
        public string UrlParsing(string url,string zheng,int location)
        {

            byte[] WebContent = null;
            try
            {
                WebClient MyWebClient = new WebClient();
                //从网页抓取数据
                WebContent = MyWebClient.DownloadData(url);
                MyWebClient.Dispose();
            }
            catch (Exception)
            {
                ////判断是否联网
                //if (ping())
                //    MessageBox.Show("有网络但图片获取失败，请联系作者");
                //else
                //    MessageBox.Show("无网络链接，图片获取失败");
                return null;
            }

            //转String
            string pageHtml = Encoding.UTF8.GetString(WebContent);

            //正则解析
            Regex reg = new Regex(zheng);
            MatchCollection mc = reg.Matches(pageHtml);

            string content = "";

            //获取数据
            foreach (Match m in mc)
            {
                content = m.Groups[location].ToString();
            }

            return content;
        }



        //判断是否联网
        public static bool ping()
        {
            try
            {
                Ping ping = new Ping();
                PingReply pr = ping.Send("www.baidu.com");

                if (pr.Status == IPStatus.Success)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
