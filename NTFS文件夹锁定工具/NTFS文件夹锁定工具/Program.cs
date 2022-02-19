using Microsoft.VisualBasic.ApplicationServices;
using NTFS_Folder_Locker.functions;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using UnhandledExceptionEventArgs = System.UnhandledExceptionEventArgs;
using UnhandledExceptionEventHandler = System.UnhandledExceptionEventHandler;

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
            try
            {
                // 判断当前系统版本信息
                Version os = new Version(10, 0);
                if (Environment.OSVersion.Version < os)
                {
                    throw new NotSupportedException("操作系统版本不在支持范围内！");
                }
                // 判断命令行参数
                if (args.Length > 1) throw new NotSupportedException("使用的命令行参数不在合法范围内！");
                if (args.Length == 1 && args[0].ToUpper() != "DEBUGMODE")
                {
                    if (!link(args[0])) throw new NotSupportedException("使用的命令行参数不在合法范围内！");
                }
            }
            catch (Exception e)
            {
                SingleWarpInstanceApp.Exception_throw(e);
            }
            try
            {
                // 尝试创建一个命名事件
                ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, GUID);
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            }
            catch (Exception e)
            {
                SingleWarpInstanceApp.Exception_throw(e);
            }
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

        // 临时方法体
        private static bool link(string path)
        {
            if (path.Length >= 2)
            {
                path = (path.Substring(path.Length - 2, 2) == ":\"")
                    ? path.Substring(0, path.Length - 2) + ":\\" : path;
            }
            if (!Directory.Exists(path)) return false;
            return true;
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
            // 挂载异常处理
            try
            {
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            }
            catch (Exception e)
            {
                Exception_throw(e);
            }
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

        // 异常捕获
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception_throw(e.Exception);
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception_throw((Exception)e.ExceptionObject);
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        internal static void Exception_throw(Exception e)
        {
            // 播放提示音
            msgbeep.beep(msgbeep.uType.MB_ICONHAND);
            // 匹配已知未知异常
            MessageBox.Show($"[应用程序内部异常] [{DateTime.Now:yyyy/MM/dd HH:mm:ss}]"
                + $"\n\n根命名空间:{e.Source}"
                + $"\n方法体:{e.TargetSite}"
                + $"\n详细信息:{e.GetType().Name}\n{e.Message}"
                + $"{(Regex.IsMatch(e.Message, @"\n\z") ? string.Empty : "\n")}"
                + $"\n位置:\n{e.StackTrace}"
                + "\n\nNTFS文件夹锁定工具 - Exceptions Processed By FeiLingshu");
            // 强制退出程序进程
            Environment.Exit(0);
        }
    }
}