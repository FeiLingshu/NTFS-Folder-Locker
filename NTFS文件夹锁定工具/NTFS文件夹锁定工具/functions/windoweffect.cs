using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace NTFS_Folder_Locker.functions
{
    /// <summary>
    /// 设置窗口dwm混合特效的公开类
    /// </summary>
    internal static class windoweffect
    {
        [DllImport("user32.dll")] //设置dwm特效win32函数
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        // 表示dwm特效常数
        private enum AccentState
        {
            //完全禁用dwm的叠加特效
            ACCENT_DISABLED = 0,
            //其他特效常数值
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_ENABLE_ACRYLICBLURBEHIND = 4,
            ACCENT_INVALID_STATE = 5,
        }

        // win32参数结构
        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        // win32参数结构
        [StructLayout(LayoutKind.Sequential)]
        private struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        // win32参数结构
        private enum WindowCompositionAttribute
        {
            // 省略其他未使用的字段
            WCA_ACCENT_POLICY = 19,
            // 省略其他未使用的字段
        }

        // 实现向win32颜色参数的单向转换
        private static int colorconvert(Color color)
        {
            return (color.R << 0 | color.G << 8 | color.B << 16 | color.A << 24);
        }

        // 存储是否使用亚克力效果的字段
        private static bool blur = false;
        /// <summary>
        /// 获取或设置是否使用亚克力效果
        /// </summary>
        internal static bool acryliblur
        {
            get
            {
                return blur;
            }
            set
            {
                blur = value;
            }
        }
        /// <summary>
        /// 设置dwm特效的公开方法
        /// </summary>
        /// <param name="hwnd">目标窗口句柄</param>
        /// <param name="color">叠加色值</param>
        internal static void set(IntPtr hwnd, Color color)
        {
            // 创建 AccentPolicy 对象。
            var accent = new AccentPolicy();
            accent.AccentState = acryliblur
                ? AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND
                : AccentState.ACCENT_ENABLE_GRADIENT;
            accent.GradientColor = colorconvert(color);
            // 将托管结构转换为非托管对象。
            var accentPolicySize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentPolicySize);
            Marshal.StructureToPtr(accent, accentPtr, false);
            // 设置窗口组合特性。
            try
            {
                // 设置窗口特效。
                var data = new WindowCompositionAttributeData
                {
                    Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
                    SizeOfData = accentPolicySize,
                    Data = accentPtr,
                };
                SetWindowCompositionAttribute(hwnd, ref data);
            }
            finally
            {
                // 释放非托管对象。
                Marshal.FreeHGlobal(accentPtr);
            }
        }
    }
}
