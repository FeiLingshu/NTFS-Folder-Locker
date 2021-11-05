// 引用基础命名空间
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
// 引用附加命名空间
using NTFS_Folder_Locker.functions;

namespace NTFS_Folder_Locker.reportform
{
    internal partial class report : Form
    {
        #region 窗口类内部方法逻辑
        internal report()
        {
            InitializeComponent(); // 以默认方式初始化窗口类
            // 设置dwm颜色混合，覆盖1px边框线
            windoweffect.acryliblur = false;
            windoweffect.set(this.Handle, Color.FromArgb(0xFF, Color.Black));
            // 窗口特效绑定
            this.Load += form_load;
            this.FormClosing += form_formclosing;
            af.flashcomplete += form_flashcomplete;
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
        private const int WM_EXITSIZEMOVE = 0x0232;
        protected override void WndProc(ref Message m)
        {
            ws.to_WndProc(ref m, this.BackColor);
            base.WndProc(ref m);
        }
        // 动态设置窗口位置及大小
        private void mainform_autoset()
        {
            MainForm mainform = (MainForm)this.Owner;
            Point location = mainform.PointToScreen(mainform.label_readme.Location);
            Size size = mainform.label_readme.Size;
            this.Location = location;
            this.Size = size;
        }
        #endregion

        #region 窗口类动画逻辑
        // 实例化窗口动画类
        private autoflash af = new autoflash();
        // 窗口初始显示时使用动画
        private void form_load(object sender, EventArgs e)
        {
            mainform_autoset(); // 跳转 => 动态设置窗口位置及大小
            this.Visible = false;
            this.Opacity = 0;
            af.to_GotFocus(this, 0, 1, null);
        }
        // 窗口关闭重定向
        private void form_formclosing(object sender, CancelEventArgs e)
        {
            e.Cancel = !af.canclose;
            if (!af.canclose)
            {
                this.Opacity = 1;
                af.to_LostFocus(this, 1, 0, null, true);
            }
        }
        // 动画结束自适应事件
        private void form_flashcomplete(object sender, EventArgs e)
        {
            // do nothing
        }
        #endregion
    }
}
