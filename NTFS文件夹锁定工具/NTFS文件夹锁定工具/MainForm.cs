using Microsoft.VisualBasic.Devices;
using NTFS_Folder_Locker.functions;
using NTFS_Folder_Locker.functions.customfunc;
using NTFS_Folder_Locker.moreform;
using NTFS_Folder_Locker.Properties;
using NTFS_Folder_Locker.reportform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace NTFS_Folder_Locker
{
    internal partial class MainForm : Form
    {
        #region 窗口类内部方法逻辑
        // 窗口类公共函数
        internal MainForm()
        {
            InitializeComponent(); // 以默认方式初始化窗口类
            ThreadPool.RegisterWaitForSingleObject(Program.ProgramStarted, OnProgramStarted, null, -1, false);
            // 设置dwm颜色混合，覆盖1px边框线
            windoweffect.acryliblur = true;
            windoweffect.set(this.Handle, Color.FromArgb(0x9F, Color.FromArgb(0x202020)));
            this.Paint += form_paint; // 动态绘制窗口背景
            // 窗口动画绑定
            this.Load += mainform_load;
            this.FormClosing += mainform_formclosing;
            // 窗口特效绑定
            this.Load += setpztion;
            label_title.Paint += title_paint;
            picturebox_closebutton.MouseEnter += closebutton_in;
            picturebox_closebutton.MouseLeave += closebutton_out;
            label_path.HandleCreated += path_initialize;
            label_path.Paint += path_paint;
            picturebox_morebutton.MouseEnter += morebutton_in;
            picturebox_morebutton.MouseLeave += morebutton_out;
            label_break_01.Paint += breakline_paint;
            label_break_02.Paint += breakline_paint;
            label_password_tips.Paint += password_tips_paint;
            checkbox_password.Paint += password_tips_paint;
            textbox_password.TextChanged += password_tips;
            label_password_tips.MouseClick += password_click;
            panel_password.MouseClick += password_click;
            textbox_password.GotFocus += password_startflash;
            label_password_tips.VisibleChanged += password_startflash;
            timer_password.Tick += password_tips_timer;
            checkbox_password.HandleCreated += password_initialize;
            checkbox_password.CheckStateChanged += password_showhide;
            picturebox_password.MouseEnter += passwordbutton_in;
            picturebox_password.MouseLeave += passwordbutton_out;
            label_copyright.Paint += copyright_paint;
            // 密钥输入框视觉行为绑定
            af.flashcomplete += copyright_lostfocus;
            label_copyright.LostFocus += copyright_lostfocus;
            this.MouseClick += password_lostfocus;
            panel_title_detail.MouseClick += password_lostfocus;
            picturebox_icon.MouseClick += password_lostfocus;
            label_title.MouseClick += password_lostfocus;
            picturebox_closebutton.MouseClick += password_lostfocus;
            picturebox_morebutton.MouseClick += password_lostfocus;
            label_break_01.MouseClick += password_lostfocus;
            label_detail_01.MouseClick += password_lostfocus;
            label_detail_02.MouseClick += password_lostfocus;
            label_detail_03.MouseClick += password_lostfocus;
            label_detail_04.MouseClick += password_lostfocus;
            label_detailinfo.MouseClick += password_lostfocus;
            label_readme.MouseClick += password_lostfocus;
            panel_copyright.MouseClick += password_lostfocus;
            label_break_02.MouseClick += password_lostfocus;
            picturebox_copyright.MouseClick += password_lostfocus;
            label_copyright.MouseClick += password_lostfocus;
            textbox_password.LostFocus += supplement_lostfocus;
            // 窗口按键功能绑定
            picturebox_closebutton.MouseClick += closebutton_click;
            label_copyright.KeyUp += closebutton_esc;
            picturebox_morebutton.MouseClick += morebutton_click;
            textbox_password.KeyPress += password_keypress;
            textbox_password.KeyDown += password_keydown;
            textbox_password.KeyUp += password_keyUp;
            textbox_password.LostFocus += password_lostfocus;
            // 主功能Alpha绑定
            af.flashcomplete += mainform_ready;
            // 主功能Beta绑定
            picturebox_password.MouseClick += startentry_beta;
        }
        // 实例化自定义窗口样式类
        private windowstyle ws = new windowstyle();
        // 设置窗口样式
        protected override CreateParams CreateParams
        {
            get
            {
                return ws.to_CreateParams(base.CreateParams);
            }
        }
        // 接管窗口windows消息
        protected override void WndProc(ref Message m)
        {
            ws.to_WndProc(ref m, this.BackColor);
            base.WndProc(ref m);
        }
        // 窗口默认绘制重写，覆盖可能出现的1px边框
        private void form_paint(object sender, PaintEventArgs e)
        {
            // 绘制上标题栏(0px偏移补偿)
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(0xFF, 0x00, 0x41, 0x70)),
                0,
                panel_title_detail.Top,
                this.Width,
                label_break_01.Top);
            LinearGradientBrush lgbrush_up =
                new LinearGradientBrush(
                    new Rectangle(0, label_break_01.Top, this.Width, 6),
                    Color.FromArgb(0x7F0076A9),
                    Color.FromArgb(0x00202020),
                    LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(
                lgbrush_up,
                new Rectangle(0, label_break_01.Top, this.Width, 6));
            // 绘制下标题栏(0px偏移补偿)
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(0xFF, 0x00, 0x41, 0x70)),
                0,
                label_break_02.Bottom + panel_copyright.Top,
                this.Width,
                panel_copyright.Height - label_break_02.Bottom);
            LinearGradientBrush lgbrush_down =
                new LinearGradientBrush(
                    new Rectangle(0, label_break_02.Bottom + panel_copyright.Top - 6, this.Width, 6),
                    Color.FromArgb(0x00202020),
                    Color.FromArgb(0x7F0076A9),
                    LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(
                lgbrush_down,
                new Rectangle(0, label_break_02.Bottom + panel_copyright.Top - 6, this.Width, 6));
        }

        // 当收到第二进程的通知时，响应消息
        private bool canrestart = true;
        private void OnProgramStarted(object state, bool timeout)
        {
            if (canrestart && !threadrunning)
            {
                d_restart drs = new d_restart(mainform_restart);
                Invoke(drs);
            }
        }
        #endregion

        #region 窗口类动画逻辑
        // 实例化窗口动画类
        private autoflash af = new autoflash();
        // 窗口初始显示时使用动画
        private void mainform_load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Opacity = 0;
            af.to_GotFocus(this, 0, 1, null);
        }
        // 主窗口关闭重定向
        private void mainform_formclosing(object sender, CancelEventArgs e)
        {
            if (this.Enabled == false)
            {
                e.Cancel = true;
                return;
            }
            if (threadrunning)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                if (thread_pathcheck != null && thread_pathcheck.IsAlive)
                    thread_pathcheck.Abort();
                if (thread_pathrecode != null && thread_pathrecode.IsAlive)
                    thread_pathcheck.Abort();
            }
            e.Cancel = !af.canclose;
            if (!af.canclose)
            {
                this.Opacity = 1;
                af.to_LostFocus(this, 1, 0, null, true);
            }
        }
        #endregion

        #region 窗口类显示特效逻辑
        // 初始化窗口停靠位置
        private void setpztion(object sender, EventArgs e)
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            Point lction = new Point(
                screen.Left + screen.Width / 32,
                screen.Top + (screen.Height - this.Height) / 3 * 2);
            this.Location = lction;
        }
        // 绘制标题文本
        private void title_paint(object sender, PaintEventArgs e)
        {
            label_title.Text = null;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.DrawString(
                (string)label_title.Tag,
                label_title.Font,
                new SolidBrush(label_title.ForeColor),
                new Rectangle(Point.Empty, label_title.Size),
                sf);
        }
        // 关闭按钮特效
        private void closebutton_in(object sender, EventArgs e)
        {
            picturebox_closebutton.Image = Resources.close_dark;
            picturebox_closebutton.BackColor = Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
        }
        private void closebutton_out(object sender, EventArgs e)
        {
            picturebox_closebutton.Image = Resources.close;
            picturebox_closebutton.BackColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
        }
        // 绘制路径文本
        private string path_string = null;
        private void path_initialize(object sender, EventArgs e)
        {
            label_path.Text = null;
            path_string = (string)label_path.Tag;
            label_path.Invalidate();
        }
        private void path_paint(object sender, PaintEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            sf.Trimming = StringTrimming.EllipsisCharacter;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.DrawString(
                path_string,
                label_path.Font,
                new SolidBrush(label_path.ForeColor),
                new Rectangle(Point.Empty, label_path.Size),
                sf);
        }
        // 关闭按钮特效
        private void morebutton_in(object sender, EventArgs e)
        {
            picturebox_morebutton.Image = Resources.more_dark;
            picturebox_morebutton.BackColor = Color.FromArgb(0xFF, 0xE3, 0xE3, 0xE3);
        }
        private void morebutton_out(object sender, EventArgs e)
        {
            picturebox_morebutton.Image = Resources.more;
            picturebox_morebutton.BackColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
        }
        // 绘制分割线
        private void breakline_paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush lgbrush_start =
                new LinearGradientBrush(
                    new Rectangle(0, 0, 32, ((Control)sender).Height),
                    Color.FromArgb(0x00, 0x98, 0xCA, 0xEC),
                    Color.FromArgb(0xFF, 0x98, 0xCA, 0xEC),
                    LinearGradientMode.Horizontal);
            LinearGradientBrush lgbrush_end =
                new LinearGradientBrush(
                    new Rectangle(((Control)sender).Width - 32, 0, 32, ((Control)sender).Height),
                    Color.FromArgb(0xFF, 0x98, 0xCA, 0xEC),
                    Color.FromArgb(0x00, 0x98, 0xCA, 0xEC),
                    LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(
                lgbrush_start,
                0, 0, 32, ((Control)sender).Height);
            e.Graphics.FillRectangle(
                lgbrush_end,
                ((Control)sender).Width - 32, 0, 32, ((Control)sender).Height);
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(0xFF, 0x98, 0xCA, 0xEC)),
                32, 0, ((Control)sender).Width - 64, ((Control)sender).Height);
        }
        // 重绘密码框相关控件
        private void password_tips_paint(object sender, PaintEventArgs e)
        {
            Control ctrl = (Control)sender;
            ctrl.Text = null;
            Size size = ctrl.Size;
            size.Width -= ctrl.Padding.Horizontal;
            size.Height -= ctrl.Padding.Vertical;
            StringFormat sf = new StringFormat();
            if (ctrl == label_password_tips)
                sf.Alignment = StringAlignment.Center;
            if (ctrl == checkbox_password)
                sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.DrawString(
                (string)ctrl.Tag,
                ctrl.Font,
                new SolidBrush(ctrl.ForeColor),
                new Rectangle(Point.Empty, size),
                sf);
        }
        // 密钥输入框特效
        private void password_tips(object sender, EventArgs e)
        {
            if (textbox_password.Text == null || textbox_password.Text == string.Empty)
                label_password_tips.Visible = true;
            else label_password_tips.Visible = false;
        }
        private void password_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textbox_password.Focus();
            }
        }
        // 密钥输入框输入等待特效
        private void password_startflash(object sender, EventArgs e)
        {
            if (label_password_tips.Visible) timer_password.Enabled = true;
        }
        private bool istipsflash = false;
        private void password_tips_timer(object sender, EventArgs e)
        {
            // 由于GDI+绘制符号文本时会包含每行文本结尾处的空格
            // 故初始化字符串时应在起始位置添加一个空格，确保文本正确居中绘制
            if (!textbox_password.Focused || !label_password_tips.Visible)
            {
                timer_password.Enabled = false;
                istipsflash = false;
                label_password_tips.Tag = "输入32位以内的密钥";
                label_password_tips.Invalidate();
                return;
            }
            if (!istipsflash)
            {
                istipsflash = true;
                label_password_tips.Tag = " ->  输入32位以内的密钥  <-";
                label_password_tips.Invalidate();
            }
            else
            {
                istipsflash = false;
                label_password_tips.Tag = "输入32位以内的密钥";
                label_password_tips.Invalidate();
            }
        }
        // 密钥明文显示和隐藏特效
        private CheckState checkbox_state = CheckState.Unchecked;
        private void password_initialize(object sender, EventArgs e)
        {
            checkbox_state = checkbox_password.CheckState;
        }
        private void password_showhide(object sender, EventArgs e)
        {
            switch (checkbox_password.CheckState)
            {
                case CheckState.Unchecked:
                    checkbox_state = CheckState.Unchecked;
                    textbox_password.PasswordChar = '█';
                    break;
                case CheckState.Checked:
                    switch (checkbox_state)
                    {
                        case CheckState.Unchecked:
                            checkbox_password.CheckState = CheckState.Indeterminate;
                            break;
                        case CheckState.Checked:
                            // unsafe:未知因素可能导致不处理故障...
                            break;
                        case CheckState.Indeterminate:
                            checkbox_password.CheckState = CheckState.Unchecked;
                            break;
                        default:
                            break;
                    }
                    break;
                case CheckState.Indeterminate:
                    checkbox_state = CheckState.Indeterminate;
                    textbox_password.PasswordChar = char.MinValue;
                    break;
                default:
                    break;
            }
            textbox_password.Focus();
        }
        // 密钥提交按钮特效
        private void passwordbutton_in(object sender, EventArgs e)
        {
            picturebox_password.Image = Resources.password_dark;
            picturebox_password.BackColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
        }
        private void passwordbutton_out(object sender, EventArgs e)
        {
            picturebox_password.Image = Resources.password;
            picturebox_password.BackColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
        }
        // 绘制版权信息文本
        private void copyright_paint(object sendeer, PaintEventArgs e)
        {
            label_copyright.Text = null;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            e.Graphics.DrawString(
                (string)label_copyright.Tag,
                label_copyright.Font,
                new SolidBrush(label_copyright.ForeColor),
                new Rectangle(Point.Empty, label_copyright.Size),
                sf);
        }
        #endregion

        #region 密钥输入框视觉行为逻辑
        // 强制转移焦点
        private void copyright_lostfocus(object sender, EventArgs e)
        {
            if (!textbox_password.Focused) label_copyright.Focus();
        }
        private void password_lostfocus(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                label_copyright.Focus();
            }
        }
        private void supplement_lostfocus(object sender, EventArgs e)
        {
            if (!label_copyright.Focused) label_copyright.Focus();
        }
        #endregion

        #region 窗口按键功能逻辑
        // 点击关闭按钮关闭窗口
        private void closebutton_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Close();
            }
        }
        // 按下Esc按键关闭窗口
        private void closebutton_esc(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        // 点击更多按钮进入多选状态
        private void morebutton_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                canrestart = false;
                more moreform = new more();
                moreform.ShowDialog(this);
                if (psinfo != null && psinfo.Count != 0)
                {
                    label_detail_01.BackColor = this.BackColor;
                    label_detail_01.ForeColor = this.ForeColor;
                    label_detail_01.Text = "路径合法性检查：未知";
                    label_detail_02.BackColor = this.BackColor;
                    label_detail_02.ForeColor = this.ForeColor;
                    label_detail_02.Text = "目标状态：未知";
                    label_detail_03.BackColor = this.BackColor;
                    label_detail_03.ForeColor = this.ForeColor;
                    label_detail_03.Text = "密钥匹配：未知";
                    label_detail_04.BackColor = this.BackColor;
                    label_detail_04.ForeColor = this.ForeColor;
                    label_detail_04.Text = "自动操作信息：未知";
                    label_detailinfo.Text =
                        string.Format("日志信息：\n—— {0}\n—— {1}...",
                        "Code_0b0000",
                        "暂无错误信息");
                    path_string = "路径：-";
                    label_path.Invalidate();
                    Thread t = new Thread((object _) =>
                    {
                        resetstate reset;
                        Thread.Sleep(200);
                        reset = new resetstate(() =>
                        {
                            label_detail_03.BackColor = this.BackColor;
                            label_detail_03.ForeColor = this.ForeColor;
                            label_detail_03.Text = "密钥匹配：未知";
                            label_detail_04.BackColor = this.BackColor;
                            label_detail_04.ForeColor = this.ForeColor;
                            label_detail_04.Text = "自动操作信息：未知";
                        });
                        Invoke(reset);
                        Thread.Sleep(200);
                        reset = new resetstate(() =>
                        {
                            label_detail_01.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
                            label_detail_01.BackColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                            label_detail_01.Text = "路径合法性检查：路径合法";
                        });
                        Invoke(reset);
                        Thread.Sleep(200);
                        reset = new resetstate(() =>
                        {
                            label_detail_02.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
                            label_detail_02.BackColor = Color.FromArgb(0xFF, 0x00, 0x76, 0xA9);
                            label_detail_02.Text = "目标状态：混合";
                        });
                        Invoke(reset);
                        Thread.Sleep(200);
                        reset = new resetstate(() =>
                        {
                            label_detailinfo.Text = "日志信息：\n—— Code_0bxxxx\n—— 具体信息详情未知...";
                            picturebox_morebutton.Enabled = true;
                            panel_password.Enabled = true;
                            picturebox_password.Enabled = true;
                            textbox_password.Focus();
                            this.Handle.bringtotop(this.TopMost);
                        });
                        Invoke(reset);
                        canrestart = true;
                    });
                    t.Start();
                }
                else canrestart = true;
            }
        }
        // 重写密钥输入框的Enter键和Esc键行为
        private void password_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D) // Enter key
            {
                startentry_beta(sender, new MouseEventArgs(
                    MouseButtons.Left, 1, 0, 0, 0));
                e.Handled = true;
            }
            if (e.KeyChar == 0x1B) // Esc key
            {
                this.Close();
                e.Handled = true;
            }
            if (e.KeyChar == 1) msgbeep.beep(msgbeep.uType.MB_OK);
        }
        // Enter按键按钮特效同步
        private void password_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                picturebox_password.Image = Resources.password_dark;
                picturebox_password.BackColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
            }
        }
        private void password_keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                picturebox_password.Image = Resources.password;
                picturebox_password.BackColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
            }
        }
        private void password_lostfocus(object sender, EventArgs e)
        {
            picturebox_password.Image = Resources.password;
            picturebox_password.BackColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
        }
        #endregion

        #region 主功能引导逻辑
        // 初始化时自动引导
        private void mainform_ready(object sender, EventArgs e)
        {
            if (Program.is_debugmode)
            {
                label_detailinfo.Text =
                    string.Format("日志信息：\n—— {0}\n—— {1}...",
                    "Code_0b1111",
                    "当前模式为调试模式");
                panel_password.Enabled = true;
                picturebox_password.Enabled = true;
            }
            else
            {
                if (Program.args.Length == 0)
                {
                    canrestart = false;
                    more moreform = new more();
                    moreform.ShowDialog(this);
                    if (psinfo != null && psinfo.Count != 0)
                    {
                        label_detail_01.BackColor = this.BackColor;
                        label_detail_01.ForeColor = this.ForeColor;
                        label_detail_01.Text = "路径合法性检查：未知";
                        label_detail_02.BackColor = this.BackColor;
                        label_detail_02.ForeColor = this.ForeColor;
                        label_detail_02.Text = "目标状态：未知";
                        label_detail_03.BackColor = this.BackColor;
                        label_detail_03.ForeColor = this.ForeColor;
                        label_detail_03.Text = "密钥匹配：未知";
                        label_detail_04.BackColor = this.BackColor;
                        label_detail_04.ForeColor = this.ForeColor;
                        label_detail_04.Text = "自动操作信息：未知";
                        label_detailinfo.Text =
                            string.Format("日志信息：\n—— {0}\n—— {1}...",
                            "Code_0b0000",
                            "暂无错误信息");
                        path_string = "路径：-";
                        label_path.Invalidate();
                        Thread t = new Thread((object _) =>
                        {
                            resetstate reset;
                            Thread.Sleep(200);
                            reset = new resetstate(() =>
                            {
                                label_detail_03.BackColor = this.BackColor;
                                label_detail_03.ForeColor = this.ForeColor;
                                label_detail_03.Text = "密钥匹配：未知";
                                label_detail_04.BackColor = this.BackColor;
                                label_detail_04.ForeColor = this.ForeColor;
                                label_detail_04.Text = "自动操作信息：未知";
                            });
                            Invoke(reset);
                            Thread.Sleep(200);
                            reset = new resetstate(() =>
                            {
                                label_detail_01.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
                                label_detail_01.BackColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                                label_detail_01.Text = "路径合法性检查：路径合法";
                            });
                            Invoke(reset);
                            Thread.Sleep(200);
                            reset = new resetstate(() =>
                            {
                                label_detail_02.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
                                label_detail_02.BackColor = Color.FromArgb(0xFF, 0x00, 0x76, 0xA9);
                                label_detail_02.Text = "目标状态：混合";
                            });
                            Invoke(reset);
                            Thread.Sleep(200);
                            reset = new resetstate(() =>
                            {
                                label_detailinfo.Text = "日志信息：\n—— Code_0bxxxx\n—— 具体信息详情未知...";
                                picturebox_morebutton.Enabled = true;
                                panel_password.Enabled = true;
                                picturebox_password.Enabled = true;
                                textbox_password.Focus();
                                this.Handle.bringtotop(this.TopMost);
                            });
                            Invoke(reset);
                            canrestart = true;
                        });
                        t.Start();
                    }
                    else canrestart = true;
                }
                else startentry_alpha();
            }
        }
        private void startentry_alpha()
        {
            if (thread_pathcheck != null && thread_pathcheck.IsAlive)
                thread_pathcheck.Abort();
            picturebox_morebutton.Enabled = false;
            thread_pathcheck = new Thread(check_path);
            threadrunning = true;
            thread_pathcheck.Start();
        }
        // 重复启动时自动引导
        private delegate void d_restart();
        private void mainform_restart()
        {
            // 重置控件状态
            label_path.Invalidate();
            label_detail_01.BackColor = this.BackColor;
            label_detail_01.ForeColor = this.ForeColor;
            label_detail_01.Text = "路径合法性检查：未知";
            label_detail_02.BackColor = this.BackColor;
            label_detail_02.ForeColor = this.ForeColor;
            label_detail_02.Text = "目标状态：未知";
            label_detail_03.BackColor = this.BackColor;
            label_detail_03.ForeColor = this.ForeColor;
            label_detail_03.Text = "密钥匹配：未知";
            label_detail_04.BackColor = this.BackColor;
            label_detail_04.ForeColor = this.ForeColor;
            label_detail_04.Text = "自动操作信息：未知";
            label_detailinfo.Text =
                    string.Format("日志信息：\n—— {0}\n—— {1}...",
                    "Code_0b0000",
                    "暂无错误信息");
            textbox_password.Text = null;
            checkbox_password.CheckState = CheckState.Unchecked;
            picturebox_morebutton.Enabled = true;
            panel_password.Enabled = false;
            picturebox_password.Enabled = false;
            // 启动自动化序列
            if (Program.is_debugmode)
            {
                label_detailinfo.Text =
                    string.Format("日志信息：\n—— {0}\n—— {1}...",
                    "Code_0b1111",
                    "当前模式为调试模式");
                picturebox_morebutton.Enabled = true;
                panel_password.Enabled = true;
                picturebox_password.Enabled = true;
            }
            else
            {
                if (Program.args.Length == 0)
                {
                    canrestart = false;
                    more moreform = new more();
                    moreform.ShowDialog(this);
                    if (psinfo != null && psinfo.Count != 0)
                    {
                        label_detail_01.BackColor = this.BackColor;
                        label_detail_01.ForeColor = this.ForeColor;
                        label_detail_01.Text = "路径合法性检查：未知";
                        label_detail_02.BackColor = this.BackColor;
                        label_detail_02.ForeColor = this.ForeColor;
                        label_detail_02.Text = "目标状态：未知";
                        label_detail_03.BackColor = this.BackColor;
                        label_detail_03.ForeColor = this.ForeColor;
                        label_detail_03.Text = "密钥匹配：未知";
                        label_detail_04.BackColor = this.BackColor;
                        label_detail_04.ForeColor = this.ForeColor;
                        label_detail_04.Text = "自动操作信息：未知";
                        label_detailinfo.Text =
                            string.Format("日志信息：\n—— {0}\n—— {1}...",
                            "Code_0b0000",
                            "暂无错误信息");
                        path_string = "路径：-";
                        label_path.Invalidate();
                        Thread t = new Thread((object _) =>
                        {
                            resetstate reset;
                            Thread.Sleep(200);
                            reset = new resetstate(() =>
                            {
                                label_detail_03.BackColor = this.BackColor;
                                label_detail_03.ForeColor = this.ForeColor;
                                label_detail_03.Text = "密钥匹配：未知";
                                label_detail_04.BackColor = this.BackColor;
                                label_detail_04.ForeColor = this.ForeColor;
                                label_detail_04.Text = "自动操作信息：未知";
                            });
                            Invoke(reset);
                            Thread.Sleep(200);
                            reset = new resetstate(() =>
                            {
                                label_detail_01.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
                                label_detail_01.BackColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
                                label_detail_01.Text = "路径合法性检查：路径合法";
                            });
                            Invoke(reset);
                            Thread.Sleep(200);
                            reset = new resetstate(() =>
                            {
                                label_detail_02.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
                                label_detail_02.BackColor = Color.FromArgb(0xFF, 0x00, 0x76, 0xA9);
                                label_detail_02.Text = "目标状态：混合";
                            });
                            Invoke(reset);
                            Thread.Sleep(200);
                            reset = new resetstate(() =>
                            {
                                label_detailinfo.Text = "日志信息：\n—— Code_0bxxxx\n—— 具体信息详情未知...";
                                picturebox_morebutton.Enabled = true;
                                panel_password.Enabled = true;
                                picturebox_password.Enabled = true;
                                textbox_password.Focus();
                                this.Handle.bringtotop(this.TopMost);
                            });
                            Invoke(reset);
                            canrestart = true;
                        });
                        t.Start();
                    }
                    else canrestart = true;
                }
                else startentry_alpha();
            }
        }
        // 自动启动操作执行序列
        private void startentry_beta(object sender, MouseEventArgs e)
        {
            if (Program.is_debugmode) return;
            if (e.Button == MouseButtons.Left)
            {
                if (psinfo != null && psinfo.Count != 0)
                {
                    picturebox_morebutton.Enabled = false;
                    panel_password.Enabled = false;
                    picturebox_password.Enabled = false;
                    password_code = textbox_password.Text.SHA512_code();
                    if (thread_pathsrecode != null && thread_pathsrecode.IsAlive)
                        thread_pathsrecode.Abort();
                    thread_pathsrecode = new Thread(recode_paths);
                    threadrunning = true;
                    thread_pathsrecode.Start();
                    return;
                }
                if (textbox_password.Text == null || textbox_password.Text == string.Empty)
                    return;
                canrestart = false;
                picturebox_morebutton.Enabled = false;
                panel_password.Enabled = false;
                picturebox_password.Enabled = false;
                password_code = textbox_password.Text.SHA512_code();
                if (thread_pathrecode != null && thread_pathrecode.IsAlive)
                    thread_pathrecode.Abort();
                thread_pathrecode = new Thread(recode_path);
                threadrunning = true;
                thread_pathrecode.Start();
            }
        }

        internal struct pathsinfo
        {
            internal bool islocked;
            internal string path;
            internal pathsinfo(bool _islocked, string _path)
            {
                islocked = _islocked;
                path = _path;
            }
        }
        internal List<pathsinfo> psinfo = new List<pathsinfo>();
        internal List<string> errorpath = new List<string>();
        private delegate void resetstate();
        private delegate void writeunknown();
        private Thread thread_pathsrecode = null;
        private void recode_paths(object e)
        {
            resetstate rstate = new resetstate(() =>
            {
                label_detail_03.BackColor = this.BackColor;
                label_detail_03.ForeColor = this.ForeColor;
                label_detail_03.Text = "密钥匹配：未知";
                label_detail_04.BackColor = this.BackColor;
                label_detail_04.ForeColor = this.ForeColor;
                label_detail_04.Text = "自动操作信息：未知";
            });
            errorpath.Clear();
            for (int i = 0; i < psinfo.Count; i++)
            {
                // 重置回显状态
                Thread.Sleep(200);
                Invoke(rstate);
                // 设置全局标志
                is_locked = psinfo[i].islocked;
                // 初始化状态bool变量
                bool ischecked = true;
                // 加载路径字符串
                string pathstring = psinfo[i].path;
                // 密钥检查
                runstateinfo rsinfo_p = passwordcheck(pathstring, password_code);
                Thread.Sleep(200);
                d_setpassword dsp = new d_setpassword(_setpassword);
                Invoke(dsp, rsinfo_p);
                ischecked = rsinfo_p.state;
                if (!ischecked)
                {
                    errorpath.Add(pathstring);
                    continue;
                }
                // 检查目录可用性并执行相关操作
                runstateinfo rsinfo_r = recodedirectory(pathstring, password_code);
                Thread.Sleep(200);
                d_setrunreport dsrr = new d_setrunreport(_setrunreport);
                Invoke(dsrr, rsinfo_r);
                ischecked = rsinfo_r.state;
                if (!ischecked)
                {
                    errorpath.Add(pathstring);
                    continue;
                }
                // 更新全局缓存
                System.Collections.Specialized.StringCollection stringc = Settings.Default.paths;
                if (psinfo[i].islocked)
                {
                    stringc[i] = Regex.Replace(stringc[i], guid_directory + "*$", string.Empty);
                }
                else
                {
                    stringc[i] = stringc[i] + guid_directory;
                }
                Settings.Default.paths = stringc;
                Settings.Default.Save();
            }
            // 执行后续操作
            writeunknown wunknown = new writeunknown(() =>
            {
                label_detailinfo.Text = "日志信息：\n—— Code_0bxxxx\n—— 具体信息详情未知...";
            });
            Invoke(wunknown);
            d_setctrl_beta dscb = new d_setctrl_beta(_setctrl_beta);
            Invoke(dscb, errorpath.Count == 0);
            threadrunning = false;
        }
        #endregion

        #region 主功能所需值
        // 用于实现主要功能的windows注册表Guid
        private const string guid_directory = ".{00021401-0000-0000-C000-000000000046}";
        // 用于保存操作结果参数的结构体
        internal struct runstateinfo
        {
            internal string path;
            internal bool state;
            internal string code;
            internal string information;
            internal runstateinfo(string _path, bool _state, string _code, string _information)
            {
                path = _path;
                state = _state;
                code = _code;
                information = _information;
            }
        }
        // 用于存储功能实现相关信息的变量
        private bool is_locked = false;
        private string password_code = null;
        // 线程运行标志变量
        private bool threadrunning = false;
        #endregion

        #region 主功能实现逻辑Alpha
        // 路径检查线程
        private Thread thread_pathcheck = null;
        private void check_path(object e)
        {
            // 初始化状态bool变量
            bool ischecked = true;
            // 检查路径
            string[] pathargs = Program.args;
            runstateinfo rsinfo = pathcheck(pathargs);
            Thread.Sleep(200);
            d_setpath dsp = new d_setpath(_setpath);
            Invoke(dsp, rsinfo.path);
            d_setpathinfo dspi = new d_setpathinfo(_setpathinfo);
            Invoke(dspi, rsinfo);
            ischecked = rsinfo.state;
            if (!ischecked) goto abort;
            // 检查状态
            Thread.Sleep(200);
            d_setstateinfo dssi = new d_setstateinfo(_setstateinfo);
            Invoke(dssi, pathstate(rsinfo.path));
            ischecked = rsinfo.state;
            if (!ischecked) goto abort;
            // 执行后续操作
            abort:
            d_setctrl_alpha dsca = new d_setctrl_alpha(_setctrl_alpha);
            Invoke(dsca, ischecked);
            threadrunning = false;
        }
        private delegate void d_setpath(string path);
        private void _setpath(string path)
        {
            path_string = (path == null || path == string.Empty)
                ? (string)label_path.Tag
                : "路径：" + Regex.Replace(path, guid_directory + "*$", string.Empty);
            label_path.Invalidate();
        }
        private delegate void d_setpathinfo(runstateinfo rsinfo);
        private void _setpathinfo(runstateinfo rsinfo)
        {
            label_detail_01.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
            label_detail_01.BackColor = rsinfo.state
                ? Color.FromArgb(0xFF, 0x15, 0xAE, 0x67)
                : Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
            label_detail_01.Text = rsinfo.state
                ? "路径合法性检查：路径合法"
                : "路径合法性检查：路径非法";
            label_detailinfo.Text = 
                string.Format("日志信息：\n—— {0}\n—— {1}...",
                rsinfo.code,
                rsinfo.information);
        }
        private delegate void d_setstateinfo(string state);
        private void _setstateinfo(string state)
        {
            switch (state.Substring(0, 1))
            {
                case "未":
                    is_locked = false;
                    break;
                case "已":
                    is_locked = true;
                    break;
                default:
                    break;
            }
            label_detail_02.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
            label_detail_02.BackColor = Color.FromArgb(0xFF, 0x15, 0xAE, 0x67);
            label_detail_02.Text = "目标状态：" + state;
        }
        private delegate void d_setctrl_alpha(bool state);
        private void _setctrl_alpha(bool state)
        {
            picturebox_morebutton.Enabled = true;
            panel_password.Enabled = state;
            picturebox_password.Enabled = state;
            if (state) textbox_password.Focus();
            this.Handle.bringtotop(this.TopMost);
        }
        // 路径检查内部方法
        internal runstateinfo pathcheck(string[] args)
        {
            if (args.Length == 0)
                return new runstateinfo(null, false, "Code_0b0001", "路径不能为空");
            string path = string.Empty;
            if (args[0].Length >= 2)
            {
                path = (args[0].Substring(args[0].Length - 2, 2) == ":\"")
                    ? args[0].Substring(0, args[0].Length - 2) + ":\\"
                    : args[0];
            }
            if (!Directory.Exists(path))
                return new runstateinfo(null, false, "Code_0b0010", "路径不存在");
            if (new DriveInfo(path.Substring(0, 1)).DriveFormat.ToUpper() != "NTFS")
                return new runstateinfo(null, false, "Code_0b0011", "路径不能为非NTFS结构");
            if (new DirectoryInfo(path).Parent == null)
                return new runstateinfo(null, false, "Code_0b0100", "路径不能为磁盘根目录");
            if (!path_matched(path)) return new runstateinfo(null, false, "Code_0b0101", "路径不能执行操作");
            if (Application.ExecutablePath.IndexOf(path, StringComparison.OrdinalIgnoreCase) == 0)
                return new runstateinfo(null, false, "Code_0b0101", "路径不能执行操作");
            return new runstateinfo(path, true, "Code_0b0000", "暂无错误信息");
        }
        // 匹配合法文件夹
        private bool path_matched(string path)
        {
            // Program Files & Program Files (x86)
            if (Environment.Is64BitOperatingSystem)
            {
                if (path.IndexOf(Environment.GetEnvironmentVariable("ProgramW6432"),
                    StringComparison.OrdinalIgnoreCase) == 0) return false;
                if (path.IndexOf(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    StringComparison.OrdinalIgnoreCase) == 0) return false;
            }
            else
            {
                if (path.IndexOf(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    StringComparison.OrdinalIgnoreCase) == 0) return false;
            }
            // ProgramData
            if (path.IndexOf(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                StringComparison.OrdinalIgnoreCase) == 0) return false;
            // Windows
            if (path.IndexOf(Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                StringComparison.OrdinalIgnoreCase) == 0) return false;
            // User
            if (path.IndexOf(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)),
                StringComparison.OrdinalIgnoreCase) == 0)
            {
                // Desktop
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (path != desktop && path.IndexOf(desktop, StringComparison.OrdinalIgnoreCase) == 0)
                    return true;
                return false;
            }
            return true;
        }
        // 状态检查内部方法
        internal string pathstate(string path)
        {
            if (File.Exists(path + "\\" + "PASSWORD".MD5_code()))
                return "已锁定";
            else return "未锁定";
        }
        #endregion

        #region 主功能实现逻辑Beta
        // 目录操作线程
        private Thread thread_pathrecode = null;
        private void recode_path(object e)
        {
            // 初始化状态bool变量
            bool ischecked = true;
            // 加载路径字符串
            string pathstring = Program.args[0];
            // 密钥检查
            runstateinfo rsinfo_p = passwordcheck(pathstring, password_code);
            Thread.Sleep(200);
            d_setpassword dsp = new d_setpassword(_setpassword);
            Invoke(dsp, rsinfo_p);
            ischecked = rsinfo_p.state;
            if (!ischecked) goto abort;
            // 检查目录可用性并执行相关操作
            runstateinfo rsinfo_r = recodedirectory(pathstring, password_code);
            Thread.Sleep(200);
            d_setrunreport dsrr = new d_setrunreport(_setrunreport);
            Invoke(dsrr, rsinfo_r);
            ischecked = rsinfo_r.state;
            if (!ischecked) goto abort;
            // 执行后续操作
            abort:
            d_setctrl_beta dscb = new d_setctrl_beta(_setctrl_beta);
            Invoke(dscb, ischecked);
            threadrunning = false;
        }
        private delegate void d_setpassword(runstateinfo rsinfo);
        private void _setpassword(runstateinfo rsinfo)
        {
            label_detail_03.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
            label_detail_03.BackColor = (rsinfo.state)
                ? Color.FromArgb(0xFF, 0x15, 0xAE, 0x67)
                : Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
            label_detail_03.Text = (rsinfo.state)
                ? "密钥匹配：成功"
                : "密钥匹配：失败";
            label_detailinfo.Text =
                string.Format("日志信息：\n—— {0}\n—— {1}...",
                rsinfo.code,
                rsinfo.information);
        }
        private delegate void d_setrunreport(runstateinfo rsinfo);
        private void _setrunreport(runstateinfo rsinfo)
        {
            label_detail_04.ForeColor = Color.FromArgb(0xFF, 0x20, 0x20, 0x20);
            label_detail_04.BackColor = (rsinfo.state)
                ? Color.FromArgb(0xFF, 0x15, 0xAE, 0x67)
                : Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
            label_detail_04.Text = (rsinfo.state)
                ? "自动操作信息：成功"
                : "自动操作信息：失败";
            label_detailinfo.Text =
                string.Format("日志信息：\n—— {0}\n—— {1}...",
                rsinfo.code,
                rsinfo.information);
        }
        private delegate void d_setctrl_beta(bool state);
        private void _setctrl_beta(bool state)
        {
            textbox_password.Text = null;
            checkbox_password.CheckState = CheckState.Unchecked;
            picturebox_morebutton.Enabled = !state;
            panel_password.Enabled = !state;
            picturebox_password.Enabled = !state;
            if (!state) textbox_password.Focus();
            this.Handle.bringtotop(this.TopMost);
            report reportform = new report();
            reportform.label_detail.Text = (state)
                ? "自动化操作执行成功！\n点击按钮退出..."
                : "自动化操作执行失败！\n点击按钮重试...";
            reportform.button_ok.FlatAppearance.MouseOverBackColor = (state)
                ? Color.FromArgb(0xFF, 0x15, 0xAE, 0x67)
                : Color.FromArgb(0xFF, 0xE8, 0x11, 0x20);
            string errorstring = (psinfo == null || psinfo.Count == 0)
                ? ((Program.args == null || Program.args.Length == 0) ? "未获取到发生错误的目标..." : Program.args[0])
                : ((errorpath == null || errorpath.Count == 0) ? "未获取到发生错误的目标..." : string.Join("\n", errorpath));
            reportform.tooltip.SetToolTip(reportform.picturebox_tips,
                (state) ? "未发生任何错误..." : errorstring);
            reportform.ShowDialog(this);
            if (!state)
            {
                canrestart = true;
                textbox_password.Focus(); // 为防止焦点由于异常无法转移，重复执行
            }
            threadrunning = false;
            if (state) Close();
        }
        // 密钥检查内部方法
        private runstateinfo passwordcheck(string path, string code_input)
        {
            if (is_locked)
            {
                if (!ntfs_locker.decodetest(path))
                    return new runstateinfo(path, false, "Code_0b1101", "访问目标文件夹被拒绝");
                FileStream fs = new FileStream(
                    path + "\\" + "PASSWORD".MD5_code(), FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, new UTF8Encoding(false));
                string code_standard = null;
                try
                {
                    code_standard = sr.ReadToEnd();
                }
                catch (Exception)
                {
                    sr.Close(); sr.Dispose();
                    fs.Close(); fs.Dispose();
                    return new runstateinfo(path, false, "Code_0b0110", "无法读取密钥缓存文件");
                }
                sr.Close(); sr.Dispose();
                fs.Close(); fs.Dispose();
                if (!ntfs_locker.encodetest(path))
                    return new runstateinfo(path, false, "Code_0b1110", "MAR权限设置异常(未知错误)");
                if (code_input.ToUpper() == code_standard.ToUpper())
                    return new runstateinfo(path, true, "Code_0b0000", "暂无错误信息");
                else return new runstateinfo(path, false, "Code_0b0111", "密钥不匹配");
            }
            else return new runstateinfo(path, true, "Code_0b0000", "暂无错误信息");
        }
        // 检查目录可用性并执行相关操作内部方法
        private runstateinfo recodedirectory(string path, string code_input)
        {
            if (is_locked)
            {
                bool decodetest = ntfs_locker.decodetest(path);
                bool encodetest = ntfs_locker.encodetest(path);
                if (!(decodetest && encodetest))
                    return new runstateinfo(path, false, "Code_0b1101", "访问目标文件夹被拒绝");
                if (!ntfs_locker.decode(path))
                    return new runstateinfo(path, false, "Code_0b1110", "MAR权限设置异常(未知错误)");
                try
                {
                    File.Delete(path + "\\" + "PASSWORD".MD5_code());
                }
                catch (Exception)
                {
                    return new runstateinfo(path, true, "Code_0b1101", "访问目标文件夹被拒绝");
                }
                try
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    string name = Regex.Replace(di.Name, guid_directory + "*$", string.Empty);
                    (new Computer()).FileSystem.RenameDirectory(path, name);
                }
                catch (Exception)
                {
                    return new runstateinfo(path, true, "Code_0b1101", "访问目标文件夹被拒绝");
                }
                return new runstateinfo(path, true, "Code_0b0000", "暂无错误信息");
            }
            else
            {
                bool encodetest = ntfs_locker.encodetest(path);
                bool decodetest = ntfs_locker.decodetest(path);
                if (!(encodetest && decodetest))
                    return new runstateinfo(path, false, "Code_0b1101", "访问目标文件夹被拒绝");
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = new FileStream(
                        path + "\\" + "PASSWORD".MD5_code(), FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fs, new UTF8Encoding(false));
                    sw.Write(code_input);
                }
                catch (Exception)
                {
                    sw.Close(); sw.Dispose();
                    fs.Close(); fs.Dispose();
                    return new runstateinfo(path, false, "Code_0b1000", "无法创建密钥缓存文件");
                }
                sw.Close(); sw.Dispose();
                fs.Close(); fs.Dispose();
                try
                {
                    (new Computer()).FileSystem.RenameDirectory(
                        path, new DirectoryInfo(path).Name + guid_directory);
                }
                catch (Exception)
                {
                    return new runstateinfo(path, true, "Code_0b1101", "访问目标文件夹被拒绝");
                }
                if (!ntfs_locker.encode(path + guid_directory))
                    return new runstateinfo(path, false, "Code_0b1110", "MAR权限设置异常(未知错误)");
                return new runstateinfo(path, true, "Code_0b0000", "暂无错误信息");
            }
        }
        #endregion
    }
}
