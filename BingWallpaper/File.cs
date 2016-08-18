using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BingWallpaper
{
    class File
    {

        //打开目录对话框
        public static string DialogFloder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult ret = fbd.ShowDialog();
            if (ret != DialogResult.OK && ret != DialogResult.Yes)
            {
                //点取消或关闭了
                return null;
            }
            // 返回选择的路径
            return fbd.SelectedPath;
        }

        //打开保存文件对话框
        public static string DialogSaveFileFloder()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = "E:\\";  
            sfd.RestoreDirectory = true;    //保存对话框上次的目录
            sfd.FileName = DateTime.Now.ToString("yyyyMMdd");
            sfd.Filter = "jpg文件(*.jpg)|*.jpg";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return null;
            }
            return sfd.FileName.ToString();
            //return sfd.FileName.ToString(); //获得文件路径
            //return localFilePath.Substring(localFilePath.LastIndexOf("//") + 1); //获取文件名，不带路径
            //return FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("//")); 获取文件路径，不带文件名 
        }



        //保存文件
        public static void SaveFile(string path,string filename)
        {

        }

        //保存文件
        public static void SaveFile(string filepath)
        {
            
        }

    }
}
