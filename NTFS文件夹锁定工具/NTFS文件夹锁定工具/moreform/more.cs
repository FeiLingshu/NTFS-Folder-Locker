using NTFS_Folder_Locker.functions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace NTFS_Folder_Locker.moreform
{
    internal partial class more : Form
    {
        #region 窗口类内部方法逻辑
        internal more()
        {
            InitializeComponent(); // 以默认方式初始化窗口类
            // 设置dwm颜色混合，覆盖1px边框线
            windoweffect.acryliblur = false;
            windoweffect.set(this.Handle, Color.FromArgb(0xFF, Color.Black));
            // 窗口特效绑定
            this.Load += form_load;
            this.FormClosing += form_formclosing;
            af.flashcomplete += form_flashcomplete;
            // 列表控件绑定
            treeview_list.MouseUp += treeview_mouseup;
            menuitem1.Click += treeview_add;
            menuitem2.Click += treeview_remove;
            // 按钮操作响应
            menuitem3.Click += clearinfo;
            button_ok.MouseUp += button_ok_mouseup;
        }
        // 实例化自定义窗口样式类
        private windowstyle ws = new windowstyle();
        // 设置窗口样式
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return ws.to_CreateParams(cp);
            }
        }
        // 接管窗口windows消息
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
            }
            ws.to_WndProc(ref m, this.BackColor);
            base.WndProc(ref m);
        }
        #endregion

        #region 窗口类动画逻辑
        // 实例化窗口动画类
        private autoflash af = new autoflash();
        // 窗口初始显示时使用动画
        private void form_load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Opacity = 0;
            af.to_GotFocus(this, 0, 1, null);
        }
        // 窗口关闭重定向
        private void form_formclosing(object sender, CancelEventArgs e)
        {
            if (istrunning)
            {
                e.Cancel = istrunning;
                return;
            }
            if (!canok)
            {
                e.Cancel = !canok;
                canok = true;
                return;
            }
            e.Cancel = !af.canclose;
            if (!af.canclose)
            {
                this.Opacity = 1;
                af.to_LostFocus(this, 1, 0, null, true);
            }
        }
        // 动画结束自适应事件
        private bool istrunning = false;
        private void form_flashcomplete(object sender, EventArgs e)
        {
            System.Collections.Specialized.StringCollection paths = Properties.Settings.Default.paths;
            if (paths == null || paths.Count == 0) return;
            menu_list.Enabled = false;
            Thread t = new Thread(addall);
            t.Start(paths);
        }
        #endregion

        #region 列表组件客制化逻辑
        // 节点操作相应
        private void treeview_mouseup(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (treeview_list.SelectedNode != null) treeview_list.SelectedNode = null;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (treeview_list.Nodes.Count == 6)
                    menuitem1.Enabled = false;
                else menuitem1.Enabled = true;
                if (treeview_list.SelectedNode == null)
                {
                    menuitem2.Enabled = false;
                }
                else
                {
                    menuitem2.Enabled = true;
                }
            }
        }
        // 添加删除节点
        private int errorcount = 0;
        private void treeview_add(object sender, EventArgs e)
        {
            #region ==> 引导：增强C++对话框模块 <==
            //...保存窗口位置参数
            mainform_rect = new Rectangle(this.Location, this.Size);
            //...抹除历史句柄记录
            dialog_hwnd = IntPtr.Zero;
            //...开启轮询线程
            if (cppdialog != null && cppdialog.IsAlive) cppdialog.Abort();
            cppdialog = new Thread(_cppdialog);
            cppdialog.IsBackground = true;
            cppdialog.Start();
            //...启动对话框
            DialogResult dresult = folderbrowserdialog.ShowDialog(this);
            //...判断并终止轮询线程
            lock (locker)
            {
                if (cppdialog != null && cppdialog.IsAlive) cppdialog.Abort();
            }
            #endregion
            if (dresult != DialogResult.OK) return;
            foreach (TreeNode nownode in treeview_list.Nodes)
            {
                if (folderbrowserdialog.SelectedPath == ((MainForm.pathsinfo)nownode.Tag).path) return;
            }
            string pathinfo =
                $"{Path.GetDirectoryName(folderbrowserdialog.SelectedPath)}\\{Path.GetFileNameWithoutExtension(folderbrowserdialog.SelectedPath)}";
            TreeNode node = new TreeNode(pathinfo);
            MainForm.pathsinfo psinfo = new MainForm.pathsinfo();
            node.ToolTipText = pathinfo;
            node.BackColor = treeview_list.BackColor;
            node.ForeColor = treeview_list.ForeColor;
            if (((MainForm)this.Owner).pathcheck(new string[1] { folderbrowserdialog.SelectedPath }).code != "Code_0b0000")
            {
                node.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                errorcount++;
            }
            else
            {
                psinfo.path = folderbrowserdialog.SelectedPath;
                switch (((MainForm)this.Owner).pathstate(folderbrowserdialog.SelectedPath).Substring(0, 1))
                {
                    case "未":
                        psinfo.islocked = false;
                        node.ForeColor = Color.FromArgb(0xFF, 0x00, 0x76, 0xA9);
                        break;
                    case "已":
                        psinfo.islocked = true;
                        node.ForeColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                        break;
                    default:
                        break;
                }
            }
            node.Tag = psinfo;
            treeview_list.Nodes.Add(node);
            treeview_list.SelectedNode = null;
        }
        private void treeview_remove(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(((MainForm.pathsinfo)treeview_list.SelectedNode.Tag).path))
                errorcount--;
            treeview_list.Nodes.Remove(treeview_list.SelectedNode);
            treeview_list.SelectedNode = null;
        }
        #endregion

        #region 自动化添加列表项
        // 数据预读取
        private delegate void addnode(TreeNode node);
        private delegate void reset();
        private void addall(object e)
        {
            istrunning = true;
            addnode addn = new addnode((TreeNode enode) =>
            {
                treeview_list.Nodes.Add(enode);
                treeview_list.SelectedNode = null;
            });
            foreach (string item in (System.Collections.Specialized.StringCollection)e)
            {
                string pathinfo =
                $"{Path.GetDirectoryName(item)}\\{Path.GetFileNameWithoutExtension(item)}";
                TreeNode node = new TreeNode(pathinfo);
                MainForm.pathsinfo psinfo = new MainForm.pathsinfo();
                node.ToolTipText = pathinfo;
                node.BackColor = treeview_list.BackColor;
                node.ForeColor = treeview_list.ForeColor;
                if (((MainForm)this.Owner).pathcheck(new string[1] { item }).code != "Code_0b0000")
                {
                    node.ForeColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
                    errorcount++;
                }
                else
                {
                    psinfo.path = item;
                    switch (((MainForm)this.Owner).pathstate(item).Substring(0, 1))
                    {
                        case "未":
                            psinfo.islocked = false;
                            node.ForeColor = Color.FromArgb(0xFF, 0x00, 0x76, 0xA9);
                            break;
                        case "已":
                            psinfo.islocked = true;
                            node.ForeColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                            break;
                        default:
                            break;
                    }
                }
                node.Tag = psinfo;
                Invoke(addn, node);
                Thread.Sleep(100);
            }
            reset r = new reset(() =>
            {
                menu_list.Enabled = true;
            });
            Invoke(r);
            istrunning = false;
        }
        #endregion

        #region 用户操作响应
        // 响应按钮操作
        private bool canok = true;
        private void button_ok_mouseup(object sender, MouseEventArgs e)
        {
            if (errorcount == 0 && treeview_list.Nodes.Count != 0)
            {
                ((MainForm)this.Owner).psinfo.Clear();
                System.Collections.Specialized.StringCollection _ = new System.Collections.Specialized.StringCollection();
                foreach (TreeNode node in treeview_list.Nodes)
                {
                    ((MainForm)this.Owner).psinfo.Add((MainForm.pathsinfo)node.Tag);
                    _.Add(((MainForm.pathsinfo)node.Tag).path);
                }
                Properties.Settings.Default.paths = _;
                Properties.Settings.Default.Save();
            }
            else canok = false;
        }
        private void clearinfo(object sender, EventArgs e)
        {
            ((MainForm)this.Owner).psinfo.Clear();
            Properties.Settings.Default.paths = null;
            Properties.Settings.Default.Save();
            errorcount = 0;
            treeview_list.Nodes.Clear();
        }
        #endregion



        #region 增强C++对话框模块
        // 保存主窗口原始位置的变量
        private Rectangle mainform_rect = Rectangle.Empty;
        // 保存对话框句柄信息的变量
        private IntPtr dialog_hwnd = IntPtr.Zero;

        // 操作所需win32api
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        private const int SC_SIZE = 0xF000;
        private const int SC_MOVE = 0xF010;
        private const int MF_BYCOMMAND = 0;
        [DllImport("user32.dll")]
        private static extern bool RemoveMenu(IntPtr hMenu, int nPos, int flags);

        // 线程内循环抓取对话框信息
        private Thread cppdialog = null;
        private object locker = new object();
        private void _cppdialog(object e)
        {
            IntPtr menuhwnd = IntPtr.Zero;
            int threadcount = 0;
            do
            {
                threadcount++;
                if (dialog_hwnd != IntPtr.Zero)
                {
                    menuhwnd = GetSystemMenu(dialog_hwnd, false);
                    if (menuhwnd != IntPtr.Zero) break;
                }
                if (threadcount == 200)
                {
                    threadcount = 0;
                    GC.Collect();
                }
                Thread.Sleep(1);
            } while (Thread.CurrentThread.IsAlive);
            MoveWindow(dialog_hwnd,
                mainform_rect.X + 8, mainform_rect.Y + 16, mainform_rect.Width * 3, mainform_rect.Height,
                true);
            RemoveMenu(menuhwnd, SC_MOVE, MF_BYCOMMAND);
            RemoveMenu(menuhwnd, SC_SIZE, MF_BYCOMMAND);
        }
        #endregion
    }
}
