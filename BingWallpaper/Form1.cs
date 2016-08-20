using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BingWallpaper
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();

            //窗口缩放比例
            PxProcessing(1.5);

            String imageurl = UrlProcessing();
            //将图片并显示到pictureBox上
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageurl);
            Stream s = request.GetResponse().GetResponseStream();
            pictureBox1.Image = Image.FromStream(s);
            s.Close();

            //更新壁纸自动退出被勾选，不跟UserConfigProcessing()放一起是因为设置应用的时候要调用一次UserConfigProcessing()
            if (Properties.Settings.Default.UpdateClose)
            {
                //if (IamgeExists() == 2)
                //{
                //    设置图片为背景ToolStripMenuItem_Click(null, null);
                //    Close();
                //    //Dispose();
                //}
            }

            //加载配置
            UserConfigProcessing();


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

        private void 保存图片到目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //先判断自动保存壁纸有没有被勾选
            if (Properties.Settings.Default.SaveImage)
            {
                //如果有，判断图片是否保存过，保存过则提示已经存
                IamgeExists();
            }
            //如果没选，判断路径是否设置了
            else if (Properties.Settings.Default.ImagePath.Length > 2)
            {
                IamgeExists();
            }
            else
            {
                另存为ToolStripMenuItem_Click(null, null);
            }

        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FilePath = File.DialogSaveFileFloder();
            if (FilePath != null)
            {
                pictureBox1.Image.Save(FilePath);
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

            WebClient MyWebClient = new WebClient();

            //从网页抓取数据
            byte[] WebContent = MyWebClient.DownloadData(url);

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
                IamgeExists();
            }


            //开机启动被勾选
            if (Properties.Settings.Default.BootOpen)
            {
                string strAssName = Application.StartupPath + @"\" + Application.ProductName + @".exe";
                string Appname = Application.ProductName;
                OnBoot o = new OnBoot();
                o.On(strAssName, Appname);
            }

            //关闭开机启动项
            if (!Properties.Settings.Default.BootOpen)
            {
                string Appname = Application.ProductName;
                OnBoot o = new OnBoot();
                o.Off(Appname);
            }

        }


        /// <summary>
        /// 用以判断图片是否存在
        ///     返回值0：无自定义路径，无图片
        ///     返回值1：有自定义路径，无图片，会自动保存图片
        ///     返回值2：有自定义路径，有图片，用以判断是否当天第一次运行    
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public int IamgeExists()
        {

            string ImagePath = Properties.Settings.Default.ImagePath;
            string Image = ImagePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".jpg";

            try
            {
                //判断是否有下载到图片
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("图片获取失败，软件炸了");
                    return 0;
                }

                //判断路径有没有定义
                if (ImagePath.Length <= 2)
                {
                    return 0;
                }

                //判断图片是否已存在
                if (System.IO.File.Exists(Image))
                {
                    //图片存在
                    return 2;
                }
                else
                {
                    //图片不存在
                    pictureBox1.Image.Save(Image);
                    return 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("自定义路径不存在");
                return 0;
            }
        }


        //jpg转bmp方法，用于win7系统
        public string JpgToBmp(string path)
        {
            string bmppath = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".bmp";
            MessageBox.Show("bompath=" + bmppath);
            Bitmap bm = new System.Drawing.Bitmap(path);
            bm.Save(bmppath, System.Drawing.Imaging.ImageFormat.Bmp);
            bm.Dispose();   //释放资源
            return bmppath;
        }

        //调用Windows API，从DLL中导出函数（使用DllImport特性，需要引入System.Runtime.InteropServices命名空间）
        //即声明一个外部函  数。
        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static void SetWallpaper(string path)
        {
            SystemParametersInfo(20, 0, path, 0x01 | 0x02);
        }

        
    }
}
