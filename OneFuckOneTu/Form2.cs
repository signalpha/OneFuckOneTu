using System;
using System.Windows.Forms;

namespace OneFuckOneTu
{


    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

            //加载用户配置
            UserConfig();

            TextBox1.AutoSize = false;
            TextBox1.Height = 26;

            dSkinToolTip1.SetToolTip(dSkinCheckBox1, "不建议手动拨号上网的用户开启");
            dSkinToolTip1.SetToolTip(dSkinCheckBox2, "每天保存一张壁纸，设置幻灯片放映也是个不错的选择");
            dSkinToolTip1.SetToolTip(dSkinCheckBox3, "只在每天第一次打开软件时更新后自动退出");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string path = File.DialogFloder();
            if (path != null)
            {
                TextBox1.Text = path;
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {


            //保存目录
            Properties.Settings.Default.ImagePath = TextBox1.Text;


            //开机启动
            if (dSkinCheckBox1.Checked)
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
            if (dSkinCheckBox2.Checked)
                Properties.Settings.Default.SaveImage = true;
            else
                Properties.Settings.Default.SaveImage = false;


            //更新壁纸退出
            if (dSkinCheckBox3.Checked)
                Properties.Settings.Default.UpdateClose = true;
            else
                Properties.Settings.Default.UpdateClose = false;

            //分辨率选项
            if (dSkinRadioButton1.Checked)
                Properties.Settings.Default.Resolution = true;
            else
                Properties.Settings.Default.Resolution = false;


            //空格键选择
            Properties.Settings.Default.ComboBox = comboBox1.SelectedIndex;
            
            Properties.Settings.Default.Save();

        }


        //加载用户配置
        public void UserConfig()
        {

            //保存目录
            if (String.Equals(Properties.Settings.Default.ImagePath, ""))
                TextBox1.Text = "";
            else
                TextBox1.Text = Properties.Settings.Default.ImagePath;


            //开机启动
            if (Properties.Settings.Default.BootOpen)
                dSkinCheckBox1.Checked = true;
            else
                dSkinCheckBox1.Checked = false;
            

            //自动保存壁纸
            if (Properties.Settings.Default.SaveImage)
                dSkinCheckBox2.Checked = true;
            else
                dSkinCheckBox2.Checked = false;

            //更新壁纸自动推出
            if (Properties.Settings.Default.UpdateClose)
                dSkinCheckBox3.Checked = true;
            else
                dSkinCheckBox3.Checked = false;

            //分辨率选择，真为1920，假为1366
            if (Properties.Settings.Default.Resolution)
                dSkinRadioButton1.Checked = true;
            else
                dSkinRadioButton2.Checked = true;

            //快捷键选择
            comboBox1.SelectedIndex = Properties.Settings.Default.ComboBox;

        }


        private void dSkinCheckBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (TextBox1.Text.Length < 3)
            {
                MessageBox.Show("需先设置路径");
                dSkinCheckBox2.Checked = true;
            }
        }
    }
}
