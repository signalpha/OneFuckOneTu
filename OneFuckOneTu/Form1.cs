using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace OneFuckOneTu
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();

            //窗口缩放比例
            PxProcessing(1.5);

            string zheng = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?.jpg";
            string url = "http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1";
            UrlProcessing up = new UrlProcessing();
            string content = up.UrlParsing(url,zheng,0);

            if (content != null)
            {
                //分辨率设置
                if (!Properties.Settings.Default.Resolution)
                {
                    content = content.Replace("1920x1080", "1366x768");
                }

                try
                {
                    //将图片并显示到pictureBox上
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(content);
                    Stream s = request.GetResponse().GetResponseStream();
                    pictureBox1.Image = Image.FromStream(s);
                    s.Dispose(); //释放资源

                    //讲图片保存到配置路径作为缓存
                    string SettingPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\OneFuckOneTu\\CacheImage.jpg";
                    pictureBox1.Image.Save(SettingPath);

                    //取配置处理
                    UserConfigProcessing();
                }
                catch (Exception)
                {
                    MessageBox.Show("图片下载成功，但加载失败，请联系作者");
                }

                url = "http://cn.bing.com/cnhp/coverstory/";
                zheng = "\"para1\":\"(?<para1>.*?)\",\"para2\":\"";
                content = up.UrlParsing(url, zheng, 1);
                
                TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel htmlLabel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel();
                htmlLabel.Text = "<span style = 'color:#292524; line-height:25px;'>" + content + "</span>";
                htmlLabel.Dock = DockStyle.Fill;
                htmlLabel.AutoSizeHeightOnly = true;
                panel1.Controls.Add(htmlLabel);
                panel1.Height = htmlLabel.Height + 6;

            }


            //判断是否修改标题栏
            if (UserAdmin.AdminIsExists())
                this.Text = "Bing每日美图  ( 管理员模式 )";
            else
                this.Text = "Bing每日美图";
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

        //空格键绑定
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 32)
            {
                switch (Properties.Settings.Default.ComboBox)
                {
                    case 1:
                        设置图片为背景ToolStripMenuItem_Click(null, null);
                        break;
                    case 2:
                        保存图片到目录ToolStripMenuItem_Click(null, null);
                        break;
                    case 3:
                        显示美图故事ToolStripMenuItem_Click(null, null);
                        break;

                }

            }
        }


        private void 设置图片为背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\OneFuckOneTu\\CacheImage.jpg";

                //判断系统是win7还是win10
                Version currentVersion = Environment.OSVersion.Version;
                Version compareToVersion = new Version("6.2");
                if (currentVersion.CompareTo(compareToVersion) >= 0)
                {
                    //win8及其以上版本的系统
                    SetWallpaper(path);

                }
                else
                {
                    string bmppath = JpgToBmp(path);
                    SetWallpaper(bmppath);
                    System.IO.File.Delete(bmppath);
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

        private void 显示美图故事ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                contextMenuStrip1.Items[2].Text = "显示美图故事";
                Properties.Settings.Default.Story = false;
            }
            else
            {
                panel1.Visible = true;
                contextMenuStrip1.Items[2].Text = "隐藏美图故事";
                Properties.Settings.Default.Story = true;
            }

            Properties.Settings.Default.Save();
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

        


        //用户配置信息处理
        public void UserConfigProcessing()
        {
            
            //自动保存图片被勾选
            if (Properties.Settings.Default.SaveImage)
            {
                保存图片到目录ToolStripMenuItem_Click(null,null);
            }

            //美图故事
            if (Properties.Settings.Default.Story)
            {
                panel1.Visible = true;
                contextMenuStrip1.Items[2].Text = "隐藏美图故事";
            }
            else
            {
                panel1.Visible = false;
                contextMenuStrip1.Items[2].Text = "显示美图故事";
            }

            //没必要在这里判断开机启动项，开机启动项只需要在 应用 被按下才选择是否去创建计划任务。


            //更新壁纸自动退出被勾选
            if (Properties.Settings.Default.UpdateClose)
            {
                //取今天的日期，和配置文件的日期判断是否相同，如果相同，则不是第一次打开，不执行退出。
                string data = DateTime.Now.ToString("yyyyMMdd");
                if (!data.Equals(Properties.Settings.Default.DataValue))
                {
                    设置图片为背景ToolStripMenuItem_Click(null, null);
                    Properties.Settings.Default.DataValue = data;
                    Properties.Settings.Default.Save();
                    Environment.Exit(0); //退出真个程序
                }
            }

        }

        


        //jpg转bmp方法，用于win7系统
        public string JpgToBmp(string path)
        {
            string bmppath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\OneFuckOneTu\\CacheImage.bmp";
            Bitmap bm = new Bitmap(path);
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
