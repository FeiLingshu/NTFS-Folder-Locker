using NTFS_Folder_Locker_HotfixTool.functions;
using NTFS_Folder_Locker_HotfixTool.functions.main_function;
using NTFS_Folder_Locker_HotfixTool.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace NTFS_Folder_Locker_HotfixTool
{
    internal partial class MainForm : Form
    {
        #region 窗口内部过程
        // 窗口唯一入口函数
        internal MainForm()
        {
            InitializeComponent(); // 以默认方式初始化窗口类
            // 注册单实例响应函数
            ThreadPool.RegisterWaitForSingleObject(Program.ProgramStarted, OnProgramStarted, null, -1, false);
            // 窗口数据初始化
            this.Load += checkinfo;
            // 用户操作绑定
            button_ok.MouseClick += ok;
            button_cancel.MouseClick += cancel;
        }
        // 当收到第二进程的通知时，响应消息
        private delegate void restart();
        private void OnProgramStarted(object state, bool timeout)
        {
            restart r = new restart(() =>
            {
                this.Handle.bringtotop(this.TopMost);
                msgbeep.beep(msgbeep.uType.MB_OK);
            }
            );
            Invoke(r);
        }
        #endregion

        #region 窗口数据初始化
        // 初始化窗口数据
        private string installpath = string.Empty;
        private void checkinfo(object sender, EventArgs e)
        {
            this.label_info.Text =
                $"NTFS文件夹锁定工具-热修补(Hotfix)工具，已准备就绪！" +
                $"\n目标版本号：0.0.0.0/0.0.0.0" +
                $"\nHotfix版本：#-0x00000000";
            int report = installer.iskeyexist("NTFS_Folder_Locker_Installer".MD5_code());
            switch (report)
            {
                case 1:
                    button_ok.Enabled = true;
                    button_cancel.Enabled = true;
                    if (File.Exists(installer.lustpath))
                    {
                        Version targatefvers = new Version(FileVersionInfo.GetVersionInfo(installer.lustpath).FileVersion);
                        Version targatepvers = new Version(FileVersionInfo.GetVersionInfo(installer.lustpath).ProductVersion);
                        Version fvers = new Version(FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion);
                        Version pvers = new Version(FileVersionInfo.GetVersionInfo(Application.ExecutablePath).ProductVersion);
                        if (targatefvers == fvers && targatepvers == pvers)
                        {
                            this.label_info.Text =
                                $"NTFS文件夹锁定工具-热修补(Hotfix)工具，已准备就绪！" +
                                $"\n目标版本号：{targatefvers}/{targatepvers}" +
                                $"\nHotfix版本：#-0x00000001";
                            installpath = installer.lustpath;
                        }
                        else
                        {
                            button_ok.Enabled = false;
                            button_cancel.Enabled = true;
                            tooltip.SetToolTip(label_state, $"应用程序版本<{targatefvers}/{targatepvers}>与当前Hotfix目标版本不符！");
                            label_state.Text = "— 自检失败，悬停以查看信息 —";
                            label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                            msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                        }
                    }
                    else
                    {
                        button_ok.Enabled = false;
                        button_cancel.Enabled = true;
                        tooltip.SetToolTip(label_state, $"文件\"{installer.lustpath}\"不存在！");
                        label_state.Text = "— 自检失败，悬停以查看信息 —";
                        label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                        msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                    }
                    break;
                case 0:
                    button_ok.Enabled = false;
                    button_cancel.Enabled = true;
                    tooltip.SetToolTip(label_state, null);
                    tooltip.SetToolTip(label_state, "应用程序<NTFS文件夹锁定工具.exe>未被安装！");
                    label_state.Text = "— 自检失败，悬停以查看信息 —";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                    break;
                case -1:
                    button_ok.Enabled = false;
                    button_cancel.Enabled = true;
                    tooltip.SetToolTip(label_state,
                        (installer.lusterror == null || installer.lusterror == string.Empty)
                        ? "未获取到错误信息..."
                        : installer.lusterror);
                    label_state.Text = "— 自检失败，悬停以查看信息 —";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                    msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 用户操作
        // 响应确认按钮
        private void ok(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Process pcs in Process.GetProcessesByName("NTFS文件夹锁定工具"))
                {
                    try
                    {
                        pcs.Kill();
                        pcs.WaitForExit();
                        pcs.Close();
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                try
                {
                    FileStream fs = new FileStream(installer.lustpath, FileMode.Create, FileAccess.Write);
                    fs.Write(Resources.mainapp, 0, Resources.mainapp.Length);
                    fs.Close(); fs.Dispose();
                }
                catch (Exception exception)
                {
                    label_state.Text = "— 出现错误，悬停以查看信息 —";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                    tooltip.SetToolTip(label_state, exception.Message);
                    button_ok.Text = "— 重试 —";
                    button_ok.BackColor = Color.FromArgb(0xFF, 0x64, 0x95, 0xED);
                    button_cancel.Text = "— 取消 —";
                    msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                    return;
                }
                label_state.Text = "— 操作完成，关闭窗口以退出 —";
                label_state.ForeColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                tooltip.SetToolTip(label_state, null);
                button_ok.BackColor = Color.FromArgb(0xFF, 0x28, 0x28, 0x28);
                button_ok.ForeColor = Color.FromArgb(0xFF, 0x28, 0x28, 0x28);
                button_ok.Enabled = false;
                button_cancel.BackColor = Color.FromArgb(0xFF, 0x28, 0x28, 0x28);
                button_cancel.ForeColor = Color.FromArgb(0xFF, 0x28, 0x28, 0x28);
                button_cancel.Enabled = false;
                msgbeep.beep(msgbeep.uType.MB_OK);
            }
        }
        // 响应取消按钮
        private void cancel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Close();
            }
        }
        #endregion
    }
}
