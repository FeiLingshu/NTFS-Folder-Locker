// 引用基础命名空间
using System;
using System.Security.Cryptography;
using System.Text;

namespace NTFS_Folder_Locker_Installer.functions.main_function
{
    internal static class byte_encryption
    {
        /// <summary>
        /// 计算字符串的MD5值
        /// <para>▣ 包含格式化信息：共32位，示例_00000000-0000-0000-0000-000000000000</para>
        /// </summary>
        /// <param name="str">计算生成的MD5字符串</param>
        internal static string MD5_code(this string str)
        {
            byte[] bytes = getstringbyte(str);
            byte[] hash = MD5.Create().ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }
            builder.Insert(8 + 0 * (4 + 1), '-');
            builder.Insert(8 + 1 * (4 + 1), '-');
            builder.Insert(8 + 2 * (4 + 1), '-');
            builder.Insert(8 + 3 * (4 + 1), '-');
            return builder.ToString();
        }

        /// <summary>
        /// 计算字符串的SHA512值
        /// <para>▣ 不包含格式化信息，共64位，因未做处理不提供示例</para>
        /// </summary>
        /// <param name="str">计算生成的SHA512字符串</param>
        internal static string SHA512_code(this string str)
        {
            byte[] bytes = getstringbyte(str);
            byte[] hash = SHA512.Create().ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("X2"));
            }
            return builder.ToString();
        }

        // 获取字符串byte数组的内部过程
        private static byte[] getstringbyte(string str)
        {
            UTF8Encoding utf8 = new UTF8Encoding(false, true);
            byte[] bytes = null;
            try
            {
                bytes = utf8.GetBytes(str);
            }
            catch (EncoderFallbackException)
            {
                throw new NotImplementedException(
                        "\n[应用程序内部已知错误]无法获取指定文本的UTF-8编码！" +
                        "\n命名空间：NTFS_Folder_Locker.functions.customfunc" +
                        "\n类：byte_encryption" +
                        "\n方法：(byte[])getstringbyte(string str)" +
                        "\n详细信息：(string)str的值不在UTF-8编码范围内！");
            }
            return bytes;
        }
    }
}
