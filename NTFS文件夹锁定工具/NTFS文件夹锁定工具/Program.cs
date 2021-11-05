// 引用基础命名空间
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Threading;
using System.Windows.Forms;

namespace NTFS_Folder_Locker
{
    internal static class Program
    {
        // 初始化全局GUID常量
        internal const string GUID = "BFB7FB97-61DF-4C86-9EF2-D5B751B64B06";
        // 初始化全局线程同步事件
        internal static EventWaitHandle ProgramStarted;

        /// <summary>
        /// 应用程序的主入口点
        /// </summary>
        [STAThread]
        internal static void Main(string[] args)
        {
            // 判断当前系统版本信息
            Version os = new Version(10, 0);
            if (Environment.OSVersion.Version < os)
            {
                throw new NotSupportedException(
                        "\n[应用程序内部已知错误]无法正常启动应用程序！" +
                        "\n命名空间：NTFS_Folder_Locker" +
                        "\n类：Program" +
                        "\n方法：Main()" +
                        "\n详细信息：(Version)...的值不在允许范围内！");
                //return;
            }
            // 尝试创建一个命名事件
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, GUID);
            // 正常窗口创建流程
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleWarpInstanceApp app = new SingleWarpInstanceApp();
            app.Run(args);
        }
        /// <summary>
        /// 用于保存当前命令行参数的公开字段
        /// </summary>
        internal static string[] args;
        /// <summary>
        /// 用于保存当前是否处处于调试状态
        /// </summary>
        internal static bool is_debugmode = false;
        // 检查是否处于调试状态下
        internal static void debugmode_check()
        {
            if (args.Length == 1 && args[0].ToUpper() == "DEBUGMODE")
                is_debugmode = true;
            else is_debugmode = false;
        }
    }

    // 实现单实例的公开类
    internal class SingleWarpInstanceApp : WindowsFormsApplicationBase
    {
        internal SingleWarpInstanceApp()
        {
            this.IsSingleInstance = true;
        }

        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            // 保存当前命令行参数
            string[] cmdline = new string[eventArgs.CommandLine.Count];
            eventArgs.CommandLine.CopyTo(cmdline, 0);
            Program.args = cmdline;
            Program.debugmode_check();
            // 启动默认主窗口
            Application.Run(new MainForm());
            // 返回窗口过程
            return false;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            // 保存当前命令行参数
            string[] cmdline = new string[eventArgs.CommandLine.Count];
            eventArgs.CommandLine.CopyTo(cmdline, 0);
            Program.args = cmdline;
            Program.debugmode_check();
            // 如果该命名事件已经存在(存在有前一个运行实例)，则发事件通知并退出
            Program.ProgramStarted.Set();
        }
    }
}