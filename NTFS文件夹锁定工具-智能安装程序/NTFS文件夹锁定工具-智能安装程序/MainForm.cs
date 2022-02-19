// 引用基础命名空间
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
// 引用扩展命名空间
using NTFS_Folder_Locker_Installer.forms;
using NTFS_Folder_Locker_Installer.functions;
using NTFS_Folder_Locker_Installer.functions.main_function;
using NTFS_Folder_Locker_Installer.Properties;

namespace NTFS_Folder_Locker_Installer
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
            // 安装程序自检绑定
            this.Load += mainform_load;
            // 智能安装检测绑定
            this.Shown += mainform_shown;
            // 安装模块绑定
            button_setpath.MouseClick += setpath;
            button_install.MouseClick += runinstall;
            // 卸载模块绑定
            button_uninstall.MouseClick += rununinstall;
            // UI特效绑定
            groupbox_install.EnabledChanged += control_statechanged;
            groupbox_uninstall.EnabledChanged += control_statechanged;
            button_setpath.MouseUp += button_resetfocus;
            button_install.MouseUp += button_resetfocus;
            button_uninstall.MouseUp += button_resetfocus;
            button_version.MouseUp += button_resetfocus;
            textbox_info.MouseLeave += button_resetfocus_sup;
            checkbox_delete.CheckedChanged += checkbox_statechanged;
            // 版本信息展示绑定
            button_version.MouseClick += showupdate;
        }
        // 重载封装信息，防止控件闪烁
        private const int WS_CLIPCHILDREN = 0x02000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_CLIPCHILDREN;
                // 风格常数解释：当在父窗口内绘图时，排除子窗口区域。在创建父窗口时使用这个风格。
                return base.CreateParams;
            }
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

        #region 安装程序自检
        // 智能初始化
        private void mainform_load(object sender, EventArgs e)
        {
            int report = installer.iskeyexist("NTFS_Folder_Locker_Installer".MD5_code());
            switch (report)
            {
                case 1:
                    groupbox_install.Enabled = false;
                    groupbox_uninstall.Enabled = true;
                    if (File.Exists(installer.lustpath))
                    {
                        tooltip.SetToolTip(label_state, null);
                        label_state.Text = "检测到已经安装<NTFS文件夹锁定工具>，自动启用卸载序列！";
                        label_state.ForeColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                    }
                    else
                    {
                        checkbox_delete.Checked = false;
                        checkbox_delete.Enabled = false;
                        tooltip.SetToolTip(label_state, "文件\"" + installer.lustpath + "\"不存在！");
                        label_state.Text = "主程序文件已经损坏或被删除！请直接卸载并重新安装！";
                        label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                        msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                    }
                    break;
                case 0:
                    groupbox_install.Enabled = true;
                    groupbox_uninstall.Enabled = false;
                    tooltip.SetToolTip(label_state, null);
                    label_state.Text = "检测到没有安装<NTFS文件夹锁定工具>，自动启用安装序列！";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                    break;
                case -1:
                    groupbox_install.Enabled = false;
                    groupbox_uninstall.Enabled = false;
                    tooltip.SetToolTip(label_state,
                        (installer.lusterror == null || installer.lusterror == string.Empty)
                        ? "未获取到错误信息..."
                        : installer.lusterror);
                    label_state.Text = "注册表错误，悬停以查看错误信息，请排除错误后重启安装程序！";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                    msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 智能安装检测
        // 智能安装检测
        private bool needupdate = false; // 已安装且版本为不兼容旧版本时为true
        private void mainform_shown(object sender, EventArgs e)
        {
            if (!checkbox_delete.Enabled) return;
            if (groupbox_uninstall.Enabled
                && installer.lustpath != null && installer.lustpath != string.Empty)
            {
                Version oldfvers = new Version(FileVersionInfo.GetVersionInfo(installer.lustpath).FileVersion);
                Version oldpvers = new Version(FileVersionInfo.GetVersionInfo(installer.lustpath).ProductVersion);
                Version newfvers = new Version(FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion);
                Version newpvers = new Version(FileVersionInfo.GetVersionInfo(Application.ExecutablePath).ProductVersion);
                if (newfvers > oldfvers && newpvers > oldpvers)
                {
                    needupdate = true;
                    autoupdate form = new autoupdate(needupdate);
                    form.label_info.Text = string.Format("安装程序检测到已经存在旧版本程序！是否覆盖安装新版本？"
                        + "\n旧版本号：{0}/{1}\n新版本号：{2}/{3}\n",
                        new string[4]
                        {
                            oldfvers.ToString(),
                            oldpvers.ToString(),
                            newfvers.ToString(),
                            newpvers.ToString(),
                        });
                    DialogResult dr = form.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                        return;
                    }
                }
            }
        }
        #endregion

        #region 安装模块
        // 保存自定义安装路径的变量
        private string installpath = null;
        // 选择安装路径
        private void setpath(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                folder_picker.Description =
                    "请选择要将软件安装到的目录！\n如果可能，不要将软件安装到系统盘中，否则会有极小概率造成安装失败或软件运行不正常！";
                #region ==> 引导：增强C++对话框模块 <==
                //...保存窗口位置参数
                mainform_rect = new Rectangle(this.Location, this.Size);
                dialog_point = this.Location;
                //...调整主窗口状态
                // this.WindowState = FormWindowState.Minimized;
                this.Opacity = 0;
                // this.WindowState = FormWindowState.Normal;
                //...抹除历史句柄记录
                dialog_hwnd = IntPtr.Zero;
                //...开启轮询线程
                if (cppdialog != null && cppdialog.IsAlive) cppdialog.Abort();
                cppdialog = new Thread(_cppdialog);
                cppdialog.IsBackground = true;
                cppdialog.Start();
                //...启动对话框
                DialogResult dr = folder_picker.ShowDialog(this);
                //...判断并终止轮询线程
                lock (locker)
                {
                    if (cppdialog != null && cppdialog.IsAlive) cppdialog.Abort();
                }
                //...设置窗口位置参数
                this.Location = dialog_point;
                //...重置主窗口状态
                this.Handle.bringtotop(this.TopMost);
                this.WindowState = FormWindowState.Minimized;
                this.Opacity = 1;
                this.WindowState = FormWindowState.Normal;
                #endregion
                if (dr == DialogResult.OK)
                {
                    installpath = folder_picker.SelectedPath;
                    label_path.Text = "— 安装目录已识别 —";
                    label_path.ForeColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                }
                else
                {
                    installpath = null;
                    label_path.Text = "— 安装目录未识别 —";
                    label_path.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                }
            }
        }
        // 开始安装
        private void runinstall(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                installer.needupdate = needupdate;
                if (installpath == null || installpath == string.Empty)
                {
                    tooltip.SetToolTip(label_state, null);
                    label_state.Text = "警告：未检测到安装路径，安装操作已被自动取消！";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                    msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                    return;
                }
                try
                {
                    FileStream fs = new FileStream(installpath + "\\NTFS文件夹锁定工具.exe",
                        FileMode.Create, FileAccess.Write);
                    fs.Write(Resources.mainapp, 0, Resources.mainapp.Length);
                    fs.Close(); fs.Dispose();
                }
                catch (Exception exception)
                {
                    groupbox_install.Enabled = false;
                    tooltip.SetToolTip(label_state,
                        (exception.Message == null || exception.Message == string.Empty)
                        ? "未获取到错误信息..."
                        : exception.Message);
                    label_state.Text = "主要文件注入失败，悬停以查看错误信息，请排除错误后重启安装程序！";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                    msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                    installpath = null;
                    return;
                    // throw;
                }
                bool report = installer.on(
                    "NTFS_Folder_Locker_Installer".MD5_code(),
                    "锁定/解锁NTFS文件夹...",
                    installpath + "\\NTFS文件夹锁定工具.exe");
                if (report)
                {
                    installpath = null;
                    groupbox_install.Enabled = false;
                    tooltip.SetToolTip(label_state, null);
                    label_state.Text = "安装序列已经完成，直接退出安装程序即可！";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                    msgbeep.beep(msgbeep.uType.MB_OK);
                }
                else
                {
                    installpath = null;
                    groupbox_install.Enabled = false;
                    tooltip.SetToolTip(label_state,
                        (installer.lusterror == null || installer.lusterror == string.Empty)
                        ? "未获取到错误信息..."
                        : installer.lusterror);
                    label_state.Text = "注册表错误，悬停以查看错误信息，请排除错误后重启安装程序！";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                    msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                }
            }
        }
        #endregion

        #region 卸载模块
        // 开始卸载
        private void rununinstall(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                installer.needupdate = needupdate;
                bool report = installer.off("NTFS_Folder_Locker_Installer".MD5_code());
                if (report)
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
                            // throw;
                        }
                    }
                    string delete_error = null;
                    if (checkbox_delete.Checked)
                    {
                        try
                        {
                            File.Delete(installer.lustpath);
                        }
                        catch (Exception exception)
                        {
                            delete_error = exception.Message;
                            throw;
                        }
                    }
                    groupbox_uninstall.Enabled = false;
                    tooltip.SetToolTip(label_state,
                        (delete_error == null || delete_error == string.Empty)
                        ? null : delete_error);
                    label_state.Text = (delete_error == null || delete_error == string.Empty)
                        ? "卸载序列已经完成，若出现意外错误请联系开发者！"
                        : "移除主程序时出现错误，悬停以查看错误信息，并尝试手动修复！";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                    msgbeep.beep(msgbeep.uType.MB_OK);
                }
                else
                {
                    groupbox_uninstall.Enabled = false;
                    tooltip.SetToolTip(label_state,
                        (installer.lusterror == null || installer.lusterror == string.Empty)
                        ? "未获取到错误信息..."
                        : installer.lusterror);
                    label_state.Text = "注册表错误，悬停以查看错误信息，请排除错误后重启安装程序！";
                    label_state.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                    msgbeep.beep(msgbeep.uType.MB_ICONEXCLAMATION);
                }
            }
        }
        #endregion

        #region UI特效
        // 按钮和文字颜色动态变化
        private void control_statechanged(object sender, EventArgs e)
        {
            GroupBox control = (GroupBox)sender;
            switch (control.Name)
            {
                case "groupbox_install":
                    button_install.BackColor = (control.Enabled)
                        ? Color.FromArgb(0xFF, 0x15, 0xAE, 0x67)
                        : Color.FromArgb(0xFF, 0x64, 0x64, 0x64);
                    break;
                case "groupbox_uninstall":
                    button_uninstall.BackColor = (control.Enabled)
                        ? Color.FromArgb(0xFF, 0xE8, 0x11, 0x20)
                        : Color.FromArgb(0xFF, 0x64, 0x64, 0x64);
                    break;
                default:
                    break;
            }
        }
        // 按钮控制权转交
        private void button_resetfocus(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) label_state.Focus();
        }
        private void button_resetfocus_sup(object sender, EventArgs e)
        {
            if (textbox_info.Focused) label_state.Focus();
        }
        // 复选框文字动态变化
        private void checkbox_statechanged(object sender, EventArgs e)
        {
            checkbox_delete.ForeColor = (checkbox_delete.Checked)
               ? Color.FromArgb(0xFF, 0x15, 0xAE, 0x67)
               : Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
        }
        #endregion

        #region 版本信息展示
        // 启动版本信息展示窗口
        private void showupdate(object semder, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                (new updateinfo()).ShowDialog(this);
            }
        }
        #endregion



        #region 增强C++对话框模块
        // 保存主窗口原始位置的变量
        private Rectangle mainform_rect = Rectangle.Empty;
        // 保存对话框句柄信息的变量
        private IntPtr dialog_hwnd = IntPtr.Zero;
        // 保存对话框位置信息的变量
        private Point dialog_point = Point.Empty;

        // 操作所需win32api
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        // 线程内循环抓取对话框信息
        private Thread cppdialog = null;
        private object locker = new object();
        private void _cppdialog(object e)
        {
            int threadcount = 0;
            do
            {
                threadcount++;
                if (dialog_hwnd != IntPtr.Zero) break;
                if (threadcount == 200)
                {
                    threadcount = 0;
                    GC.Collect();
                }
                Thread.Sleep(1);
            } while (Thread.CurrentThread.IsAlive);
            MoveWindow(dialog_hwnd,
                mainform_rect.X, mainform_rect.Y, mainform_rect.Width, mainform_rect.Height,
                true);
            do
            {
                threadcount++;
                RECT rect = new RECT();
                bool rp = GetWindowRect(dialog_hwnd, ref rect);
                if (rp)
                {
                    lock (locker)
                    {
                        dialog_point = new Point(rect.Left, rect.Top);
                    }
                }
                if (threadcount == 200)
                {
                    threadcount = 0;
                    GC.Collect();
                }
                Thread.Sleep(16);
            } while (Thread.CurrentThread.IsAlive);
        }

        // 通过win32消息获取对话框句柄
        private const int WM_ENTERIDLE = 0x0121;
        private const int MSGF_DIALOGBOX = 0;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_ENTERIDLE:
                    if (dialog_hwnd == IntPtr.Zero
                        && m.WParam.ToInt32() == MSGF_DIALOGBOX)
                        dialog_hwnd = m.LParam;
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion
    }
}
