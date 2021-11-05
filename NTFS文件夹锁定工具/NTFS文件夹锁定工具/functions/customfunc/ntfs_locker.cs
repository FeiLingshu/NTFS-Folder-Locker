// 引用基础命名空间
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace NTFS_Folder_Locker.functions.customfunc
{
    internal static class ntfs_locker
    {
        /// <summary>
        /// 执行文件夹锁定操作
        /// </summary>
        /// <param name="path">目标文件夹路径</param>
        /// <returns>指示操作是否执行成功</returns>
        internal static bool encode(string path)
        {
            deleteblocker(path, handleway.creat);
            bool report = MARchange(path, authority.deny);
            return report;
        }
        /// <summary>
        /// 执行文件夹解锁操作
        /// </summary>
        /// <param name="path">目标文件夹路径</param>
        /// <returns>指示操作是否执行成功</returns>
        internal static bool decode(string path)
        {
            bool report = MARchange(path, authority.allow);
            if (report) deleteblocker(path, handleway.delete);
            return report;
        }
        /// <summary>
        /// 对锁定操作进行初始化测试
        /// <para>▣ 相关测试结束后请调用decodetest(string path)方法</para>
        /// </summary>
        /// <param name="path">目标文件夹路径</param>
        /// <returns>指示操作是否执行成功</returns>
        internal static bool encodetest(string path)
        {
            bool testreport = MARchange(path, authority.deny);
            return testreport;
        }
        /// <summary>
        /// 对解锁操作进行初始化测试
        /// <para>▣ 相关测试结束后请调用encodetest(string path)方法</para>
        /// </summary>
        /// <param name="path">目标文件夹路径</param>
        /// <returns>指示操作是否执行成功</returns>
        internal static bool decodetest(string path)
        {
            bool testreport = MARchange(path, authority.allow);
            return testreport;
        }
        
        // 指示将如何操作文件夹的枚举        
        private enum handleway
        {
            creat, // 创建文件夹
            delete, // 删除文件夹
        }
        // 指示将如何设置权限标识符的枚举
        private enum authority
        {
            allow, // 允许标志
            deny, // 拒绝标志
        }
        // 防删除文件夹自适应操作内部方法
        private static void deleteblocker(string path, handleway flag)
        {
            if (flag != handleway.creat && flag != handleway.delete)
                throw new NotImplementedException(
                    "\n[应用程序内部已知错误]无法执行权限调整操作！" +
                    "\n命名空间：NTFS_Folder_Locker.functions.customfunc" +
                    "\n类：ntfs_locker" +
                    "\n方法：deleteblocker(string path, handleway flag)" +
                    "\n详细信息：(handleway)flag的值不在允许范围内！");
            string cmdline = null;
            string filepath = "\"" + path + "\\" + "DELETEBLOCKER".MD5_code() + "..\\\"";
            switch (flag)
            {
                case handleway.creat:
                    cmdline = "cmd /c md " + filepath;
                    break;
                case handleway.delete:
                    cmdline = "cmd /c rd /s /q " + filepath;
                    break;
                default:
                    break;
            }
            Interaction.Shell(cmdline, AppWinStyle.Hide, true, -1);
        }
        // 调整文件夹权限的内部方法
        private static bool MARchange(string path, authority flag)
        {
            if (flag != authority.allow && flag != authority.deny)
                throw new NotImplementedException(
                    "\n[应用程序内部已知错误]无法执行权限调整操作！" +
                    "\n命名空间：NTFS_Folder_Locker.functions.customfunc" +
                    "\n类：ntfs_locker" +
                    "\n方法：MARchange(string path, authority flag)" +
                    "\n详细信息：(authority)flag的值不在允许范围内！");
            DirectoryInfo dir_info = new DirectoryInfo(path);
            DirectorySecurity dir_security = dir_info.GetAccessControl();
            try
            {
                FileSystemAccessRule everyone_allow =
                    new FileSystemAccessRule("Everyone",
                        FileSystemRights.FullControl,
                        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                        PropagationFlags.None,
                        AccessControlType.Allow);
                dir_security.AddAccessRule(everyone_allow);
                dir_security.SetAccessRuleProtection(true, false);
                dir_info.SetAccessControl(dir_security);
                AuthorizationRuleCollection rules = dir_security.GetAccessRules(true, false, typeof(SecurityIdentifier));
                foreach (FileSystemAccessRule rule in rules)
                {
                    dir_security.RemoveAccessRule(rule);
                }
                dir_security.AddAccessRule(everyone_allow);
                if (flag == authority.deny)
                {
                    FileSystemRights fsr =
                        FileSystemRights.ReadData |
                        FileSystemRights.CreateFiles |
                        FileSystemRights.AppendData |
                        FileSystemRights.ExecuteFile |
                        FileSystemRights.DeleteSubdirectoriesAndFiles |
                        FileSystemRights.Delete |
                        FileSystemRights.TakeOwnership;
                    FileSystemAccessRule everyone_deny =
                        new FileSystemAccessRule("Everyone", fsr, AccessControlType.Deny);
                    dir_security.AddAccessRule(everyone_deny);
                }
                dir_info.SetAccessControl(dir_security);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}