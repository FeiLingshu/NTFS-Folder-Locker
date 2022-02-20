// 引用基础命名空间
using System;
using System.Runtime.InteropServices;

namespace NTFS_Folder_Locker_HotfixTool.functions
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
            MB_OK = 0x00000000U, // 0x00000000U,
            MB_ICONHAND = 0x00000010U, // 0x00000010U,
            MB_ICONQUESTION = 0x00000020U, // 0x00000020U,
            MB_ICONEXCLAMATION = 0x00000030U, // 0x00000030U,
            [Obsolete("该枚举值无法产生任何效果，原因未知")]
            MB_ICONASTERISK = 0x00000040U, // 0x00000040U,
            [Obsolete("该枚举值将产生与MB_OK枚举值相同的作用，无需使用")]
            MS_UNNAMED = 0xFFFFFFFFU, // 0xFFFFFFFFU,
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
                case uType.MB_ICONQUESTION:
                    MessageBeep(0x00000020U);
                    break;
                case uType.MB_ICONEXCLAMATION:
                    MessageBeep(0x00000030U);
                    break;
                default:
                    throw new NotImplementedException(
                        "\n[应用程序内部已知错误]无法生成指定的系统声音！" +
                        "\n命名空间：NTFS_Folder_Locker.functions" +
                        "\n类：msgbeep" +
                        "\n方法：beep(uType uType)" +
                        "\n详细信息：(uType)uType的值不在枚举范围内！");
                    //break;
            }
        }
    }
}
