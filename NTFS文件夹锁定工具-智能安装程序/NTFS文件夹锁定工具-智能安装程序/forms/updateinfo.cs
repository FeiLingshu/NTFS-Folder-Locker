// 引用基础命名空间
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace NTFS_Folder_Locker_Installer.forms
{
    internal partial class updateinfo : Form
    {
        #region 窗口内部过程
        // 窗口唯一入口函数
        internal updateinfo()
        {
            InitializeComponent(); // 以默认方式初始化窗口类
            // 窗口位置同步绑定
            this.Shown += form_shown;
            this.FormClosing += form_formclosing;
            // 重绘列表外观绑定
            treeview_list.MouseUp += treevive_freeselect;
            treeview_list.DrawNode += treeview_paint;
            this.Shown += treeview_showall;
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

        #region 重绘列表外观
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
        // 列表中无节点被选取时释放焦点
        private void treevive_freeselect(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (treeview_list.SelectedNode != null)
                    if (!treeview_list.SelectedNode.Bounds.Contains(e.Location))
                        treeview_list.SelectedNode = null;
        }
        // 重绘列表外观
        private void treeview_paint(object sender, DrawTreeNodeEventArgs e)
        {
            TreeView targate = (TreeView)sender;
            Color backcolor = targate.BackColor;
            Color forecolor = e.Node.ForeColor;
            if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
            {
                backcolor = Color.FromArgb(0xFF, 0x32, 0x32, 0x32);
                forecolor = forecolor == Color.FromArgb(0xFF, 0x20, 0x20, 0x20)
                    ? Color.WhiteSmoke : forecolor;
                goto drawnode;
            }
            if ((e.State & TreeNodeStates.Focused) == TreeNodeStates.Focused)
            {
                backcolor = Color.FromArgb(0xFF, 0x64, 0x64, 0x64);
                forecolor = forecolor == Color.FromArgb(0xFF, 0x20, 0x20, 0x20)
                    ? Color.WhiteSmoke : forecolor;
                goto drawnode;
            }
            if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
            {
                if (e.Node != ((TreeView)sender).SelectedNode)
                {
                    backcolor = Color.FromArgb(0xFF, 0xDE, 0xDE, 0xDE);
                    goto drawnode;
                }
            }
            drawnode:
            e.Graphics.FillRectangle(
                new SolidBrush(backcolor),
                e.Node.Bounds.X,
                e.Node.Bounds.Y,
                e.Node.Bounds.Width,
                e.Node.Bounds.Height);
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null) nodeFont = targate.Font;
            int spacewidth = 0;
            using (Graphics gdi = treeview_list.CreateGraphics())
            {
                spacewidth = gdi.MeasureString(" ", nodeFont).ToSize().Width;
            }
            if (e.Node.Tag == null)
            {
                int realwidth = 0;
                using (Graphics gdi = treeview_list.CreateGraphics())
                {
                    realwidth = gdi.MeasureString(e.Node.Text, nodeFont).ToSize().Width;
                }
                int spacecount = 
                    (int)((realwidth - TextRenderer.MeasureText(e.Node.Text, nodeFont).Width) / (double)spacewidth) + 1;
                if (spacecount > 0)
                {
                    e.Node.Text += new string(' ', (spacecount > 0) ? spacecount : 0);
                    e.Node.Tag = "null";
                    return;
                }
                else e.Node.Tag = "null";
            }
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            e.Graphics.DrawString(
                Regex.Replace(e.Node.Text, " *$", string.Empty),
                nodeFont,
                new SolidBrush(forecolor),
                new Rectangle(
                    e.Node.Bounds.X,
                    e.Node.Bounds.Y,
                    e.Node.Bounds.Width + spacewidth,
                    e.Node.Bounds.Height),
                sf);
        }
        // 实现反色的内部方法(已弃用)
        [Obsolete("界面设计经过改良，无需此方法", true)]
        private Color inversecolor(Color value)
        {
            return Color.FromArgb(value.A, 0xFF - value.R, 0xFF - value.G, 0xFF - value.B);
        }
        // 初始化时展开特定节点
        private void treeview_showall(object sender, EventArgs e)
        {
            treeview_list.BeginUpdate();
            TreeNode targate = treeview_list.Nodes.Find("5121", true)[0];
            targate.EnsureVisible();
            targate.Expand();
            treeview_list.EndUpdate();
        }
        #endregion
    }
}
