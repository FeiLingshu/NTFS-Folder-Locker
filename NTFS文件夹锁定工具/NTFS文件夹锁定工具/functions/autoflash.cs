// 引用基础命名空间
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace NTFS_Folder_Locker.functions
{
    /// <summary>
    /// 实现窗口动画效果的公开类
    /// <para>▣ 注意：非静态类，使用前需实例化</para>
    /// </summary>
    internal class autoflash
    {
        /// <summary>
        /// 指示当前窗口状态是否可关闭
        /// </summary>
        internal bool canclose = false;
        /// <summary>
        /// GotFocus函数重定向，启动显示动画
        /// </summary>
        /// <param name="window">窗口类实例</param>
        /// <param name="start">起始透明度值</param>
        /// <param name="end">终止透明度值</param>
        /// <param name="tool">附加处理控件，可以为null</param>
        /// <param name="isclose">指示当前动画效果结束后是否关闭窗口，默认值为false</param>
        internal void to_GotFocus(Form window, double start, double end, Control tool, bool isclose = false)
        {
            if (((window == null) ? false : !window.Enabled) &&
                ((tool == null) ? false : !tool.Enabled)) return;
            window.Enabled = false;
            if (tool != null) tool.Enabled = false;
            window.Visible = true;
            (new Thread(flash)).Start(
                new flashinfo(window, start, end, tool, isclose));
        }
        /// <summary>
        /// LostFocus函数重定向，启动隐藏动画
        /// </summary>
        /// <param name="window">窗口类实例</param>
        /// <param name="start">起始透明度值</param>
        /// <param name="end">终止透明度值</param>
        /// <param name="tool">附加处理控件，可以为null</param>
        /// <param name="isclose">指示当前动画效果结束后是否关闭窗口，默认值为false</param>
        internal void to_LostFocus(Form window, double start, double end, Control tool, bool isclose = false)
        {
            if (((window == null) ? false : !window.Enabled) &&
                ((tool == null) ? false : !tool.Enabled)) return;
            window.Enabled = false;
            if (tool != null) tool.Enabled = false;
            window.Visible = true;
            (new Thread(flash)).Start(
                new flashinfo(window, start, end, tool, isclose));
        }

        // 保存线程参数的结构体
        private struct flashinfo
        {
            internal readonly Form window;
            internal readonly double start;
            internal readonly double end;
            internal readonly Control tool;
            internal readonly bool isclose;
            internal flashinfo(Form _window,
                double _start,
                double _end,
                Control _tool,
                bool _isclose)
            {
                if (_start < 0 || _start > 1)
                {
                    throw new NotImplementedException(
                        "\n[应用程序内部已知错误]无法配置动画参数！" +
                        "\n命名空间：NTFS_Folder_Locker.functions" +
                        "\n类：autoflash" +
                        "\n方法：flashinfo(int startopacity, int endopacity)" +
                        "\n详细信息：(int)startopacity的值不在允许范围内！");
                }
                if (_end < 0 || _end > 1)
                {
                    throw new NotImplementedException(
                        "\n[应用程序内部已知错误]无法配置动画参数！" +
                        "\n命名空间：NTFS_Folder_Locker.functions" +
                        "\n类：autoflash" +
                        "\n方法：flashinfo(int startopacity, int endopacity)" +
                        "\n详细信息：(int)endopacity的值不在允许范围内！");
                }
                window = _window;
                start = _start;
                end = _end;
                tool = _tool;
                isclose = _isclose;
            }
        }
        // 动画效果实现线程
        private void flash(object e)
        {
            if (e.GetType() != typeof(flashinfo))
            {
                throw new NotImplementedException(
                       "\n[应用程序内部已知错误]无法配置动画参数！" +
                       "\n命名空间：NTFS_Folder_Locker.functions" +
                       "\n类：autoflash" +
                       "\n方法：flash(object e)" +
                       "\n详细信息：(object)e的值无法被解析！");
                //return;
            }
            flashinfo info = (flashinfo)e;
            int step = 0;
            if (info.start < info.end)
            {
                step = 1;
            }
            if (info.start > info.end)
            {
                step = -1;
            }
            if (step == 0)
            {
                throw new NotImplementedException(
                       "\n[应用程序内部已知错误]无法配置动画参数！" +
                       "\n命名空间：NTFS_Folder_Locker.functions" +
                       "\n类：autoflash" +
                       "\n方法：flash(object e)" +
                       "\n详细信息：(int)start和(int)end的值不能相等！");
                //return;
            }
            d_reflash _reflash = new d_reflash(reflash);
            switch (step)
            {
                case 1:
                    for (double op = info.start; op < info.end + 0.01; op += 0.1)
                    {
                        info.window.Invoke(_reflash, info.window, op);
                        Thread.Sleep(16);
                    }
                    break;
                case -1:
                    for (double op = info.start; op > info.end - 0.01; op -= 0.1)
                    {
                        info.window.Invoke(_reflash, info.window, op);
                        Thread.Sleep(16);
                    }
                    break;
                default:
                    break;
            }
            info.window.Invoke(_reflash, info.window, info.end);
            Thread.Sleep(1);
            d_setstate _setstate = new d_setstate(setstate);
            info.window.Invoke(_setstate, info.window, info.tool, (step == -1) ? true : false, info.isclose);
        }
        private delegate void d_reflash(Form window, double op);
        private void reflash(Form window, double op)
        {
            window.Opacity = op;
        }
        private delegate void d_setstate(Form window, Control tool, bool reset, bool isclose);
        private void setstate(Form window, Control tool, bool reset, bool isclose)
        {
            window.Enabled = true;
            if (tool != null) tool.Enabled = true;
            if (reset)
            {
                window.Visible = false;
            }
            else
            {
                window.Handle.bringtotop(window.TopMost);
                window.Activate();
                flashcomplete?.Invoke(this, new EventArgs());
            }
            if (isclose)
            {
                canclose = true;
                window.Close();
            }
        }

        // 初始化动画结束事件
        internal delegate void EventHandler(object sender, EventArgs e);
        /// <summary>
        /// 窗口显示动画结束后触发
        /// </summary>
        [Description("窗口动画结束后触发")]
        [Category("Event of Windowflash")]
        internal event EventHandler flashcomplete;
    }
}
