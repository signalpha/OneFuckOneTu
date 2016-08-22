using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TaskScheduler;

namespace BingWallpaper
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();

            //窗口缩放比例
            PxProcessing(1.5);


            string imageurl = UrlProcessing();

            if (imageurl != null)
            {
                //分辨率设置
                if (!Properties.Settings.Default.Resolution)
                {
                    imageurl = imageurl.Replace("1920x1080", "1366x768");
                }

                try
                {
                    //将图片并显示到pictureBox上
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageurl);
                    Stream s = request.GetResponse().GetResponseStream();
                    pictureBox1.Image = Image.FromStream(s);
                    s.Dispose();

                    //取配置处理
                    UserConfigProcessing();
                }
                catch (Exception)
                {
                    MessageBox.Show("图片下载成功，但加载失败，请联系作者");
                }

            }

            //判断是否修改标题栏
            if (UserAdmin.AdminIsExists())
                this.Text = "Bing每日美图  ( 管理员模式 )";
            else
                this.Text = "Bing每日美图";



            //到底该如何判断程序是自动启动还是手动启动

            
        }


        public void tong()
        {
            
        }

        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //右键弹出菜单项
            if (e.Button == MouseButtons.Right)
            {
                PictureBox pe = (PictureBox)sender;
                this.contextMenuStrip1.Show(MousePosition);
            }
        }

        private void 设置图片为背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                string path = "";

                //判断系统是win7还是win10
                Version currentVersion = Environment.OSVersion.Version;
                Version compareToVersion = new Version("6.2");
                if (currentVersion.CompareTo(compareToVersion) >= 0)
                {
                    //win8及其以上版本的系统
                    path = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".jpg";
                    pictureBox1.Image.Save(path);
                    SetWallpaper(path);
                    System.IO.File.Delete(path);

                }
                else
                {
                    path = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".jpg";
                    pictureBox1.Image.Save(path);
                    string bmppath = JpgToBmp(path);
                    SetWallpaper(bmppath);
                    System.IO.File.Delete(bmppath);
                    System.IO.File.Delete(path);
                }
            }
            else
            {
                MessageBox.Show("图片获取不到，设置失败。");
            }


            

        }

        private void 保存图片到目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                string ImagePath = Properties.Settings.Default.ImagePath;
                string Image = ImagePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".jpg";

                //先判断自动保存壁纸有没有被勾选，如果被勾选，路径一定存在
                if (Properties.Settings.Default.SaveImage)
                {
                    pictureBox1.Image.Save(Image);
                }
                else if (ImagePath.Length > 2)
                {
                    pictureBox1.Image.Save(Image);
                }
                else
                {
                    另存为ToolStripMenuItem_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("图片获取不到，保存失败。");
            }

        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FilePath = File.DialogSaveFileFloder();
            if (FilePath != null)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Save(FilePath);
                }
                else
                {
                    MessageBox.Show("图片获取不到，保存失败。");
                }
                
            }
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }


        //适应不同分辨率
        public void PxProcessing(double ratin)
        {
            ////获取屏幕分辨率
            double sh = (double)Screen.PrimaryScreen.Bounds.Height;
            double sw = (double)Screen.PrimaryScreen.Bounds.Width;

            ////计算缩放比列
            double height = sh / ratin;
            double width = sw / ratin - 52;

            this.Height = (int)height;
            this.Width = (int)width;
        }


        //解析网页图片地址
        public String UrlProcessing()
        {
            String url = "http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1";
            byte[] WebContent = null;

            try
            {

                WebClient MyWebClient = new WebClient();

                //从网页抓取数据
                WebContent = MyWebClient.DownloadData(url);

            }
            catch (Exception)
            {
                //判断是否联网
                if (ping())
                    MessageBox.Show("有网络但图片获取失败，请联系作者");
                else
                    MessageBox.Show("无网络链接，图片获取失败");
                return null;
            }

            //转String
            String pageHtml = Encoding.Default.GetString(WebContent);

            //正则解析出图片地址
            Regex reg = new Regex(@"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?.jpg");
            MatchCollection mc = reg.Matches(pageHtml);

            String ImageUrl = "";

            //获取图片地址
            foreach (Match m in mc)
            {
                ImageUrl = m.Groups[0].ToString();
            }

            return ImageUrl;

        }


        //用户配置信息处理
        public void UserConfigProcessing()
        {
            
            //自动保存图片被勾选
            if (Properties.Settings.Default.SaveImage)
            {
                保存图片到目录ToolStripMenuItem_Click(null,null);
            }

            //没必要在这里判断开机启动项，开机启动项只需要在 应用 被按下才选择是否去创建计划任务。


            //更新壁纸自动退出被勾选，不跟UserConfigProcessing()放一起是因为设置应用的时候要调用一次UserConfigProcessing()
            //if (Properties.Settings.Default.UpdateClose)
            //{
            //    if (IamgeExists() == 2)
            //    {
            //        设置图片为背景ToolStripMenuItem_Click(null, null);
            //        Close();
            //        //Dispose();
            //    }
            //}

        }



        //判断是否联网
        public bool ping()
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


        //jpg转bmp方法，用于win7系统
        public string JpgToBmp(string path)
        {
            string bmppath = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".bmp";
            Bitmap bm = new System.Drawing.Bitmap(path);
            bm.Save(bmppath, System.Drawing.Imaging.ImageFormat.Bmp);
            bm.Dispose();   //释放资源
            return bmppath;
        }




        //设置背景调用Windows API，从DLL中导出函数（使用DllImport特性，需要引入System.Runtime.InteropServices命名空间）
        //即声明一个外部函  数。
        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static void SetWallpaper(string path)
        {
            SystemParametersInfo(20, 0, path, 0x01 | 0x02);
        }

        
    }
}
