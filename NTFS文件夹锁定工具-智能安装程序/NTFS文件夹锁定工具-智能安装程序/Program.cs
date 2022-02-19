// 引用基础命名空间
using System;
using System.Threading;
using System.Windows.Forms;

namespace NTFS_Folder_Locker_Installer
{
    internal static class Program
    {
        // 初始化全局GUID常量
        internal const string GUID = "D22756B8-994A-4A40-89E3-A4FD757D066C";

        // 初始化全局线程同步事件
        internal static EventWaitHandle ProgramStarted;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            // 判断当前系统版本信息
            Version os = new Version(10, 0);
            if (Environment.OSVersion.Version < os)
            {
                throw new NotSupportedException(
                        "\n[应用程序内部已知错误]无法正常启动应用程序！" +
                        "\n命名空间：WindowTranslucenceTool" +
                        "\n类：Program" +
                        "\n方法：Main()" +
                        "\n详细信息：(Version)...的值不在允许范围内！");
                //return;
            }
            // 尝试创建一个命名事件
            bool createNew = false;
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, GUID, out createNew);
            // 如果该命名事件已经存在(存在有前一个运行实例)，则发事件通知并退出
            if (!createNew)
            {
                ProgramStarted.Set();
                return;
            }
            // 正常窗口创建流程
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
