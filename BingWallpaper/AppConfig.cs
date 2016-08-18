using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.Reflection;

namespace BingWallpaper
{


    class AppConfig
    {


        //更新配置
        public static void UpdateConfig(string key, string value)
        {
            //程序运行的时候实际调用的两个文件（vshost.exe.config和exe.config  ）都被修改了，这样每次启动 配置文件里的内容也都是最新的。

            //获得两个config的路径
            var assemblyConfigFile = Assembly.GetEntryAssembly().Location;  //exe.config
            var appDomainConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile; //vshost.exe.config
            UpdateConfigValue(key, value, assemblyConfigFile);
            UpdateConfigValue2(key, value, appDomainConfigFile);
        }


        //获取配置值
        public static string GetConfigValue(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            string result = string.Empty;
            if (config.AppSettings.Settings[key] != null)
            {
                result = config.AppSettings.Settings[key].Value;
            }

            return result;
        }


        //更新配置，改exe.config
        public static void UpdateConfigValue(string key, string value, string path)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(path);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        //更新配置，改vshost.exe.config
        private static void UpdateConfigValue2(string key, string value, string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);

            //找出名称为“add”的所有元素  
            var nodes = doc.GetElementsByTagName("add");
            for (int i = 0; i < nodes.Count; i++)
            {
                //获得将当前元素的key属性  
                var xmlAttributeCollection = nodes[i].Attributes;
                if (xmlAttributeCollection != null)
                {
                    var att = xmlAttributeCollection["key"];
                    if (att == null) continue;
                    //根据元素的第一个属性来判断当前的元素是不是目标元素  
                    if (att.Value != key) continue;
                    //对目标元素中的第二个属性赋值  
                    att = xmlAttributeCollection["value"];
                    att.Value = value;
                }
                break;
            }

            //保存上面的修改  
            doc.Save(path);
            ConfigurationManager.RefreshSection("appSettings");
        }




    }
}
