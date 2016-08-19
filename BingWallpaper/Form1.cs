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
            
            String imageurl = UrlProcessing();
            //将图片并显示到pictureBox上
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageurl);
            Stream s = request.GetResponse().GetResponseStream();
            pictureBox1.Image = Image.FromStream(s);
            s.Close();

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
            string ImagePath = AppConfig.GetConfigValue("imagepath");
            string UpdateSave = AppConfig.GetConfigValue("updatesave");

            if (String.Equals(UpdateSave, "1"))
            {
                path = ImagePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".jpg";
                SetWallpaper(path);
                //MessageBox.Show("壁纸自动保存，不用删除");
            }
            else 
            {
                path = path = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".jpg";
                pictureBox1.Image.Save(path);
                SetWallpaper(path);
                System.IO.File.Delete(path);
                //MessageBox.Show("壁纸没有自动保存，存了删");
            }
           
        }

        private void 保存图片到目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ImagePath = AppConfig.GetConfigValue("imagepath");
            string UpdateSave = AppConfig.GetConfigValue("updatesave");

            //先判断自动保存壁纸有没有被勾选
            if (String.Equals(UpdateSave, "1"))
            {
                //如果有，判断图片是否保存过，保存过则提示已经存
                IamgeExists();
            }
            //如果没被勾选，则判断是否定义了路径，如果有，保存到路径。
            else if (ImagePath.Length > 2)
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
            
            string BootOpen = AppConfig.GetConfigValue("bootopen");
            string UpdateSave = AppConfig.GetConfigValue("updatesave");
            string UpdateExit = AppConfig.GetConfigValue("updateexit");

            

            //自动保存图片被勾选
            if (String.Equals(UpdateSave, "1"))
            {
                IamgeExists();
            }

            //更新壁纸自动退出被勾选
            if (String.Equals(UpdateExit, "1"))
            {
                //if (IamgeExists() == 2)
                //{
                //    设置图片为背景ToolStripMenuItem_Click(null, null);
                //    Close();
                //    //Dispose();
                //}
            }

            //开机启动被勾选
            if (String.Equals(BootOpen, "1"))
            {
                string strAssName = Application.StartupPath + @"\" + Application.ProductName + @".exe";
                string Appname = Application.ProductName;
                OnBoot o = new OnBoot();
                o.On(strAssName, Appname);
            }

            //关闭开机启动项
            if (String.Equals(BootOpen, "0"))
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

            string ImagePath = AppConfig.GetConfigValue("imagepath");
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
