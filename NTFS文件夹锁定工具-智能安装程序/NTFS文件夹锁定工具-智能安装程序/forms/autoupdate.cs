// 引用基础命名空间
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
// 引用扩展命名空间
using NTFS_Folder_Locker_Installer.functions;
using NTFS_Folder_Locker_Installer.functions.main_function;
using NTFS_Folder_Locker_Installer.Properties;

namespace NTFS_Folder_Locker_Installer.forms
{
    internal partial class autoupdate : Form
    {
        #region 窗口内部过程
        // 窗口唯一入口函数
        internal autoupdate(bool needupdate)
        {
            InitializeComponent(); // 以默认方式初始化窗口类
            // 同步额外操作指示
            this.needupdate = needupdate;
            // 窗口位置同步绑定
            this.Shown += form_shown;
            this.FormClosing += form_formclosing;
            // 用户操作绑定
            button_ok.MouseClick += ok;
            button_cancel.MouseClick += cancel;
            this.FormClosing += form_close;
        }
        #endregion

        #region 窗口位置同步
        // 位置同步线程
        private Thread pztionthread = null;
        private delegate void d_setpztion(Point pztion);
        private Point pointless = Point.Empty;
        private void domath(object e)
        {
            int threadcount = 0;
            Point value = (Point)e;
            d_setpztion _setpztion = new d_setpztion(setpztion);
            do
            {
                threadcount++;
                Point pztion = this.Location;
                pztion.Offset(-value.X, -value.Y);
                Invoke(_setpztion, pztion);
                if (threadcount == 200)
                {
                    threadcount = 0;
                    GC.Collect();
                }
                Thread.Sleep(1);
            } while (Thread.CurrentThread.IsAlive);
        }
        private void setpztion(Point pztion)
        {
            this.Owner.Location = pztion;
        }
        // 线程随窗口启动
        private void form_shown(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                pointless = this.Location;
                pointless.Offset(-this.Owner.Left, -this.Owner.Top);
                pztionthread = new Thread(domath);
                pztionthread.Start(pointless);
            }
        }
        // 窗口关闭重定向
        private void form_formclosing(object sender, CancelEventArgs e)
        {
            if (pztionthread != null && pztionthread.IsAlive)
                pztionthread.Abort();
        }
        #endregion

        #region 用户操作
        // 对话框返回值参数
        private DialogResult dr = DialogResult.Cancel;
        // 额外操作指示
        private bool needupdate = false;
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
                    if (needupdate)
                    {
                        if (!installer.overlay(
                            "NTFS_Folder_Locker_Installer".MD5_code(),
                            "锁定/解锁NTFS文件夹...",
                            installer.lustpath))
                            throw new NotImplementedException(installer.lusterror);
                    }
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
                dr = DialogResult.OK;
                msgbeep.beep(msgbeep.uType.MB_OK);
            }
        }
        // 响应取消按钮
        private void cancel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dr = DialogResult.Cancel;
                this.Close();
            }
        }
        // 窗口关闭重定向
        private void form_close(object sender, CancelEventArgs e)
        {
            if (pztionthread != null && pztionthread.IsAlive) pztionthread.Abort();
            this.DialogResult = dr;
        }
        #endregion
    }
}
