// 引用基础命名空间
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NTFS_Folder_Locker.functions
{
    /// <summary>
    /// 设置窗口样式的公开类
    /// <para>▣ 注意：非静态类，使用前需实例化</para>
    /// </summary>
    internal class windowstyle
    {
        // dwm函数声明
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        // dwm函数所需结构体声明
        private struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        // user32函数声明
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern bool ReleaseDC(IntPtr hwnd, IntPtr hdc);
        // 判断aero功能状态方法
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        // 状态全局变量
        private bool m_aeroEnabled = false;

        // 窗口风格常数
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WS_CLIPCHILDREN = 0x02000000;
        /// <summary>
        /// CreateParams函数重定向，初始化窗口风格
        /// </summary>
        /// <param name="cp">窗口风格结构</param>
        /// <returns>处理完成的窗口风格结构</returns>
        internal CreateParams to_CreateParams(CreateParams cp)
        {
            m_aeroEnabled = CheckAeroEnabled();
            if (!m_aeroEnabled)
            {
                cp.ClassStyle |= CS_DROPSHADOW;
                cp.ExStyle |= WS_CLIPCHILDREN;
            }
            return cp;
        }

        // windows消息常数声明
        private const int WM_PAINT = 0x000F;
        private const int WM_NCPAINT = 0x0085;
        /// <summary>
        /// WndProc函数重定向，监听窗口windows消息
        /// </summary>
        /// <param name="m">消息参数结构</param>
        /// <param name="bc">指示当前用于重绘的颜色</param>
        /// <returns>处理完成的消息参数结构</returns>
        internal Message to_WndProc(ref Message m, Color bc)
        {
            switch (m.Msg)
            {
                // 绘制空白阴影窗口
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(m.HWnd, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 0,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 1,
                        };
                        DwmExtendFrameIntoClientArea(m.HWnd, ref margins);
                    }
                    break;
                // 非预处理字段
                default:
                    break;
            }
            return m;
        }
        /// <summary>
        /// 已使用新的dwm函数实现相同效果，此方法永久弃用
        /// </summary>
        [Obsolete("已使用新的dwm函数实现相同效果，此方法永久弃用", true)]
        internal void autopaint(IntPtr hwnd, Color bc)
        {
            IntPtr hdc = GetWindowDC(hwnd);
            Graphics gr = Graphics.FromHdc(hdc);
            RectangleF rect = gr.VisibleClipBounds;
            rect.Width--;
            rect.Height--;
            gr.DrawRectangle(new Pen(bc, 2), rect.X, rect.Y, rect.Width, rect.Height);
            gr.Dispose();
            ReleaseDC(hwnd, hdc);
        }
    }
}
