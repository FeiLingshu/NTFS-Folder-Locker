using System;
using System.Runtime.InteropServices;

namespace NTFS_Folder_Locker.functions
{
    /// <summary>
    /// 设置当前前台窗口的扩展类
    /// </summary>
    internal static class settopwindow
    {
        /// <summary>
        /// 设置前台窗口的扩展方法
        /// </summary>
        /// <param name="hWnd">目标窗口句柄</param>
        /// <param name="isTopmost">指示窗口是否为置顶窗口</param>
        /// <returns>指示操作是否成功</returns>
        internal static bool bringtotop(this IntPtr hWnd, bool isTopmost)
        {
            IntPtr hForeWnd = stw.GetForegroundWindow();
            uint dwForeID = 0U;
            uint num2 = 0U;
            if (hForeWnd != IntPtr.Zero)
            {
                int id = 0;
                dwForeID = (uint)stw.GetWindowThreadProcessId(hForeWnd, out id);
                if (dwForeID == 0U) { return false; }
                num2 = (uint)stw.GetCurrentThreadId();
                if (num2 == 0U) { return false; }
                if (!stw.AttachThreadInput((int)num2, (int)dwForeID, 1)) { return false; }
            }
            if (!stw.ShowWindow(hWnd, 1U)) { return false; }
            if (!stw.SetWindowPos(hWnd, stw.HWND_TOPMOST, 0, 0, 0, 0, 3)) { return false; }
            if (!stw.SetWindowPos(hWnd, isTopmost ? stw.HWND_TOPMOST : stw.HWND_NOTOPMOST, 0, 0, 0, 0, 3)) { return false; }
            if (!stw.SetForegroundWindow(hWnd)) { return false; }
            if (hForeWnd != IntPtr.Zero)
            {
                if (!stw.AttachThreadInput((int)num2, (int)dwForeID, 0)) { return false; }
            }
            return true;
        }
    }
    // 内置公开类
    internal static class stw
    {
        // API调用声明
        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        internal static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        [DllImport("kernel32.dll")]
        internal static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        internal static extern bool AttachThreadInput(int idAttach, int idAttachTo, int fAttach);
        internal const int SW_SHOWNORMAL = 1;
        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        internal static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        internal static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        internal const uint SWP_NOSIZE = 1U;
        internal const uint SWP_NOMOVE = 2U;
        [DllImport("user32.dll")]
        internal static extern bool SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hwnd);
    }
}
