using Microsoft.Win32;
using System;
using TaskScheduler;

namespace BingWallpaper
{
    class OnBoot
    {



        //获取计划任务列表
        public static IRegisteredTaskCollection GetAllTasks()
        {
            TaskSchedulerClass ts = new TaskSchedulerClass();
            ts.Connect(null, null, null, null);
            ITaskFolder folder = ts.GetFolder("\\");
            IRegisteredTaskCollection tasks_exists = folder.GetTasks(1);
            return tasks_exists;
        }


        //判断计划任务是否存在
        public static bool TaskIsExists(string taskName)
        {
            var isExists = false;

            IRegisteredTaskCollection tasks_exists = GetAllTasks();

            for (int i = 1; i <= tasks_exists.Count; i++)
            {
                IRegisteredTask t = tasks_exists[i];
                if (t.Name.Equals(taskName))
                {
                    isExists = true;
                    break;
                }
            }

            return isExists;
        }


        //创建计划任务，任何用户登陆都执行
        public static _TASK_STATE TaskCreate(string creator, string taskName, string path)
        {
            try
            {
                //实例化任务对象
                TaskSchedulerClass scheduler = new TaskSchedulerClass();
                scheduler.Connect(null, null, null, null);  //连接
                ITaskFolder folder = scheduler.GetFolder("\\");


                //设置常规属性
                ITaskDefinition task = scheduler.NewTask(0);
                task.RegistrationInfo.Author = creator;//创造者
                task.RegistrationInfo.Description = "测试用";//描述信息
                task.Principal.RunLevel = _TASK_RUNLEVEL.TASK_RUNLEVEL_HIGHEST; //使用最高权限运行


                //设置触发器
                ILogonTrigger tt = (ILogonTrigger)task.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_LOGON); //触发器里的开始任务,其他开始任务方式用的是其他接口
                tt.UserId = Environment.MachineName + "\\" + creator; //特定用户


                //设置操作
                IExecAction action = (IExecAction)task.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
                action.Path = path; //计划任务调用的程序路径


                //其他设置
                task.Settings.ExecutionTimeLimit = "PT0S"; //运行任务时间超时停止任务吗? PTOS 不开启超时
                task.Settings.DisallowStartIfOnBatteries = false;//只有在交流电源下才执行
                task.Settings.RunOnlyIfIdle = false;//仅当计算机空闲下才执行


                //注册任务
                IRegisteredTask regTask = folder.RegisterTaskDefinition(
                    taskName, //计划任务名字
                    task,
                    (int)_TASK_CREATION.TASK_CREATE, //创建
                    null,   //user
                    null,   //password
                    _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN,// Principal.LogonType
                    "");

                IRunningTask runTask = regTask.Run(null);
                return runTask.State;
            }
            catch (Exception)
            {
                throw;
            }

            
        }


        //删除任务计划
        public static void DeleteTask(string taskName)
        {

            try
            {
                TaskSchedulerClass ts = new TaskSchedulerClass();
                ts.Connect(null, null, null, null);
                ITaskFolder folder = ts.GetFolder("\\");
                folder.DeleteTask(taskName, 0);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            

        }


    }
}
