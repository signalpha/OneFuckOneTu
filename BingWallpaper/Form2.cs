using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Environment;
using System.Diagnostics;
using System.Security.Principal;

namespace BingWallpaper
{
    

    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

            //加载用户配置
            UserConfig();

            Tips(skinCheckBox1, "Win7之后由于UAC的缘故，");
            Tips(skinCheckBox2, "每天保存一张壁纸，设置幻灯片放映也是个不错的选择");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string path = File.DialogFloder();
            if (path != null)
            {
                skinTextBox1.Text = path;
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {


            //保存目录
            Properties.Settings.Default.ImagePath = skinTextBox1.Text;


            //开机启动
            if (skinCheckBox1.Checked)
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
                Properties.Settings.Default.BootOpen = true;
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
                Properties.Settings.Default.BootOpen = false;
            }

            //更新壁纸保存
            if (skinCheckBox2.Checked)
                Properties.Settings.Default.SaveImage = true;
            else
                Properties.Settings.Default.SaveImage = false;


            //更新壁纸退出
            if (skinCheckBox3.Checked)
                Properties.Settings.Default.UpdateClose = true;
            else
                Properties.Settings.Default.UpdateClose = false;

            //分辨率选项
            if (skinRadioButton1.Checked)
                Properties.Settings.Default.Resolution = true;
            else
                Properties.Settings.Default.Resolution = false;


            Properties.Settings.Default.Save();

        }


        public void Tips(CheckBox Checkbox,string TipsContent)
        {
            ToolTip ttpSettings = new ToolTip();
            ttpSettings.InitialDelay = 200;
            ttpSettings.AutoPopDelay = 10 * 1000;
            ttpSettings.ReshowDelay = 200;
            ttpSettings.ShowAlways = true;
            ttpSettings.IsBalloon = true;
            ttpSettings.SetToolTip(Checkbox, TipsContent);
        }

        //加载用户配置
        public void UserConfig()
        {

            //保存目录
            if (String.Equals(Properties.Settings.Default.ImagePath, ""))
                skinTextBox1.Text = "";
            else
                skinTextBox1.Text = Properties.Settings.Default.ImagePath;


            //开机启动
            if (Properties.Settings.Default.BootOpen)
                skinCheckBox1.Checked = true;
            else
                skinCheckBox1.Checked = false;
            

            //自动保存壁纸
            if (Properties.Settings.Default.SaveImage)
                skinCheckBox2.Checked = true;
            else
                skinCheckBox2.Checked = false;

            //更新壁纸自动推出
            if (Properties.Settings.Default.UpdateClose)
                skinCheckBox3.Checked = true;
            else
                skinCheckBox3.Checked = false;

            //更新壁纸自动推出
            if (Properties.Settings.Default.Resolution)
                skinRadioButton1.Checked = true;
            else
                skinRadioButton2.Checked = true;

        }

        private void skinCheckBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (skinTextBox1.Text.Length < 3)
            {
                MessageBox.Show("需先设置路径");
                skinCheckBox2.Checked = false;
            }
        }
    }
}
