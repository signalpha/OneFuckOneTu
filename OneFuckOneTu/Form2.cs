using System;
using System.Windows.Forms;
using OneFuckOneTu.Properties;

namespace OneFuckOneTu
{


    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

            //加载用户配置
            UserConfig();

            textBox1.AutoSize = false;
            textBox1.Height = 26;


            Tips(checkBox1, "开机不会有UAC提示，首次启动需以管理员模式开启");
            Tips(checkBox2, "每天保存一张壁纸，设置幻灯片放映也是个不错的选择");
            Tips(checkBox3, "手动开启软件只在每天第一次开启时更新后自动退出");
        }


        //鼠标提示
        public void Tips(CheckBox Checkbox, string TipsContent)
        {
            ToolTip ttpSettings = new ToolTip();
            ttpSettings.InitialDelay = 200;
            ttpSettings.AutoPopDelay = 10 * 1000;
            ttpSettings.ReshowDelay = 200;
            ttpSettings.ShowAlways = true;
            ttpSettings.IsBalloon = true;
            ttpSettings.SetToolTip(Checkbox, TipsContent);
        }


        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text.Length < 3)
            {
                MessageBox.Show("需先设置路径");
                checkBox2.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = File.DialogFloder();
            if (path != null)
            {
                textBox1.Text = path;
                //保存目录
                Settings.Default.ImagePath = textBox1.Text;
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //开机启启
            if (checkBox1.Checked)
            {
                string taskname = "one_fuck_one_tu";
                if (!OnBoot.TaskIsExists(taskname))
                {
                    if (UserAdmin.AdminIsExists())
                    {
                        string strAssName = Application.ExecutablePath;
                        OnBoot.TaskCreate(taskname, strAssName);
                    }
                    else
                    {
                        //重启获取管理员权限
                        UserAdmin.Upgrade();
                    }
                }

            }
            else
            {
                string taskname = "one_fuck_one_tu";
                if (OnBoot.TaskIsExists(taskname))
                {
                    if (UserAdmin.AdminIsExists())
                    {
                        OnBoot.DeleteTask(taskname);
                    }
                    else
                    {
                        //重启获取管理员权限
                        UserAdmin.Upgrade();
                    }
                }
            }
        }



        //窗口关闭发生
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //壁纸保存
            if (checkBox2.Checked)
                Settings.Default.SaveImage = true;
            else
                Settings.Default.SaveImage = false;


            //更新壁纸退出
            if (checkBox3.Checked)
                Settings.Default.UpdateClose = true;
            else
                Settings.Default.UpdateClose = false;

            //分辨率选项
            if (radioButton1.Checked)
                Settings.Default.Resolution = true;
            else
                Settings.Default.Resolution = false;


            //空格键选择
            Settings.Default.ComboBox = comboBox1.SelectedIndex;

            Settings.Default.Save();

        }

        //超链接
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.signalpha.cn");
        }


        //加载用户配置
        public void UserConfig()
        {

            //保存目录
            if (String.Equals(Settings.Default.ImagePath, ""))
                textBox1.Text = "";
            else
                textBox1.Text = Settings.Default.ImagePath;


            //开机启动
            if (OnBoot.TaskIsExists("one_fuck_one_tu"))
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
            

            //自动保存壁纸
            if (Settings.Default.SaveImage)
                checkBox2.Checked = true;
            else
                checkBox2.Checked = false;

            //更新壁纸自动推出
            if (Settings.Default.UpdateClose)
                checkBox3.Checked = true;
            else
                checkBox3.Checked = false;

            //分辨率选择，真为1920，假为1366
            if (Settings.Default.Resolution)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

            //快捷键选择
            comboBox1.SelectedIndex = Settings.Default.ComboBox;

        }

        
    }
}
