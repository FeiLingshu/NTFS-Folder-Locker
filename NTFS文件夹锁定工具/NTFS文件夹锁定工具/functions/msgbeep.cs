using System;
using System.Runtime.InteropServices;

namespace NTFS_Folder_Locker.functions
{
    /// <summary>
    /// C++函数MessageBeep的基础类
    /// </summary>
    internal static class msgbeep
    {
        /// <summary>
        /// C++结构uType
        /// </summary>
        [Flags] // 启用位运算，保证枚举值的唯一性
        internal enum uType : uint
        {
            MB_OK = 0x0001U, // 0x00000000U,
            MB_ICONHAND = 0x0002U, // 0x00000010U,
            [Obsolete("该枚举值无法产生任何效果，原因未知")]
            MB_ICONQUESTION = 0x0004U, // 0x00000020U,
            MB_ICONEXCLAMATION = 0x0008U, // 0x00000030U,
            MB_ICONASTERISK = 0x0010U, // 0x00000040U,
            [Obsolete("该枚举值将产生与MB_OK枚举值相同的作用，无需使用")]
            MS_UNNAMED = 0xFFFFU, // 0xFFFFFFFFU,
        }
        // 播放windows系统声音函数
        [DllImport("user32.dll")]
        private static extern bool MessageBeep(uint uType);
        /// <summary>
        /// 调用系统声音播放函数播放指定声音
        /// </summary>
        /// <param name="uType">指定要播放的声音类型</param>
        internal static void beep(uType uType)
        {
            switch (uType)
            {
                case uType.MB_OK:
                    MessageBeep(0x00000000U);
                    break;
                case uType.MB_ICONHAND:
                    MessageBeep(0x00000010U);
                    break;
                case uType.MB_ICONEXCLAMATION:
                    MessageBeep(0x00000030U);
                    break;
                case uType.MB_ICONASTERISK:
                    MessageBeep(0x00000040U);
                    break;
                default:
                    throw new NotImplementedException("无法生成指定的系统声音！");
            }
        }
    }
}
