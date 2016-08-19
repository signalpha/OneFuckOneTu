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

namespace BingWallpaper
{
    

    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

            //加载用户配置
            UserConfig();

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
            string PathValue = skinTextBox1.Text;
            AppConfig.UpdateConfig("imagepath", PathValue);


            //开机启动
            if (skinCheckBox1.Checked)
            {
                AppConfig.UpdateConfig("bootopen", "1");
            }
            else
            {
                AppConfig.UpdateConfig("bootopen", "0");
            }


            //更新壁纸保存
            if (skinCheckBox2.Checked)
            {
                AppConfig.UpdateConfig("updatesave", "1");
            }
            else
            {
                AppConfig.UpdateConfig("updatesave", "0");
            }



            //更新壁纸退出
            if (skinCheckBox3.Checked)
            {
                AppConfig.UpdateConfig("updateexit", "1");
            }
            else
            {
                AppConfig.UpdateConfig("updateexit", "0");
            }

            //自动更新
            if (skinCheckBox4.Checked)
            {
                AppConfig.UpdateConfig("updateversion", "1");
            }
            else
            {
                AppConfig.UpdateConfig("updateversion", "0");
            }

        }




        public void UserConfig()
        {

            string ImagePath = AppConfig.GetConfigValue("imagepath");
            string BootOpen = AppConfig.GetConfigValue("bootopen");
            string UpdateSave = AppConfig.GetConfigValue("updatesave");
            string UpdateExit = AppConfig.GetConfigValue("updateexit");
            string UpdateVersion = AppConfig.GetConfigValue("updateversion");

            if (String.Equals(ImagePath, ""))
            {
                skinTextBox1.Text = "";
            }
            else
            {
                skinTextBox1.Text = ImagePath;
            }

            //开机启动
            if (String.Equals(BootOpen, "0"))
            {
                 skinCheckBox1.Checked = false;
            }
            else
            {
                 skinCheckBox1.Checked = true;
            }

            //自动保存壁纸
            if (String.Equals(UpdateSave, "0"))
            {
                 skinCheckBox2.Checked = false;
            }
            else
            {
                 skinCheckBox2.Checked = true;
            }

            //更新壁纸自动推出
            if (String.Equals(UpdateExit, "0"))
            {
                 skinCheckBox3.Checked = false;
            }
            else
            {
                 skinCheckBox3.Checked = true;
            }

            //更新推送
            if (String.Equals(UpdateVersion, "0"))
            {
                skinCheckBox4.Checked = false;
            }
            else
            {
                skinCheckBox4.Checked = true;
            }

        }

    }
}
