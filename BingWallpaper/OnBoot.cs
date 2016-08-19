using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWallpaper
{
    class OnBoot
    {

        //检索指定子项，并指访问权限true  
        RegistryKey rgkRun = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

        public void On(string AppPath, string AppName)
        {
            
            if (rgkRun == null)
            {
                //未检索到该子项，创建子项  
                rgkRun = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            }

            //添加键值对入注册表  
            rgkRun.SetValue(AppPath, AppName);

        }


        public void Off(string AppName)
        {
            //从此项中删除指定值，并指定在找不到该值时不引发异常  
            rgkRun.DeleteValue(AppName, false);
           
        }

    }
}
