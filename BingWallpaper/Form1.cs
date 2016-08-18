using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
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
            System.IO.Stream s = request.GetResponse().GetResponseStream();
            pictureBox1.Image = System.Drawing.Bitmap.FromStream(s);

            //读取用户配置


            
            

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

        }

        

        private void 保存图片到目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ImagePath = AppConfig.GetConfigValue("imagepath");
           
            //
            try
            {
                //判断是否有图片
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("图片获取失败，软件炸了");
                    Close();
                }

                //判断保存路径有没有被自定义
                if (String.Equals(ImagePath, "0") || ImagePath.Length < 3)
                {

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\bing每日美图\";

                    //目录不存在就创建
                    if (Directory.Exists(path))
                    {
                        pictureBox1.Image.Save(path + DateTime.Now.ToString("yyyyMMdd") + ".jpg");
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                        pictureBox1.Image.Save(path + DateTime.Now.ToString("yyyyMMdd") + ".jpg");
                        MessageBox.Show("保存成功");
                    }

                }
                else
                {
                    pictureBox1.Image.Save(ImagePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".jpg");
                    MessageBox.Show("保存成功");
                }


            }
            catch
            {
                MessageBox.Show("保存失败，也许是自定义路径不存在");
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
        private void UserConfigProcessing()
        {
            
            string BootOpen = AppConfig.GetConfigValue("bootopen");
            string AutoUpdate = AppConfig.GetConfigValue("autoupdate");
            string UpdateSave = AppConfig.GetConfigValue("updatesave");
            string UpdateExit = AppConfig.GetConfigValue("updateexit");


        }


    }
}
