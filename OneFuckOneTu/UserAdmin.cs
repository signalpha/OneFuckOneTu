using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace OneFuckOneTu
{
    class UserAdmin
    {

        /// <summary>
        /// 判断当前用户是否是管理员用户，如果是，返回真
        /// </summary>
        /// <returns></returns>
        public static bool AdminIsExists()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            Boolean isRunasAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            identity.Dispose(); //释放资源

            if (isRunasAdmin)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 重启进程提升至管理员权限
        /// </summary>
        public static void Upgrade()
        {

            //以管理员方式重新启动
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Application.ExecutablePath;
            psi.Verb = "runas";

            try
            {
                Process.Start(psi);
                Application.Exit();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }

        }
    }
}
