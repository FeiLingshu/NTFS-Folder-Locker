// 引用基础命名空间
using Microsoft.Win32;
using System;

namespace NTFS_Folder_Locker_HotfixTool.functions.main_function
{
    /// <summary>
    /// 实现注册自动启动安装项的公开类
    /// </summary>
    internal static class installer
    {
        /// <summary>
        /// 保存更新的需求状态
        /// <para>
        /// 已安装且版本为不兼容旧版本时为true
        /// </para>
        /// </summary>
        internal static bool needupdate = false;

        /// <summary>
        /// 保存最后一次错误的错误信息
        /// </summary>
        internal static string lusterror = null;

        /// <summary>
        /// 保存最后一次获取到的注册表项所指应用程序路径
        /// </summary>
        internal static string lustpath = null;

        /// <summary>
        /// 判断注册表项是否存在(1=存在，0=不存在，-1=异常)
        /// </summary>
        /// <param name="keyname">项名称</param>
        /// <returns>表示是否存在匹配项的整形值</returns>
        internal static int iskeyexist(string keyname)
        {
            lusterror = null;
            try
            {
                int isexist = 0;
                RegistryKey root = Registry.ClassesRoot;
                RegistryKey shell = root.OpenSubKey("Folder\\shell", true);
                if (shell == null) // 为保证runs列表为空不是由于目录尚未创建引起的，执行以下操作
                {
                    RegistryKey[] keys = new RegistryKey[2];
                    keys[0] = root.CreateSubKey("Folder");
                    keys[1] = keys[0].CreateSubKey("shell");
                    shell = keys[1];
                }
                string[] runsname = shell.GetSubKeyNames();
                foreach (string strname in runsname)
                {
                    if (strname.ToUpper() == keyname.ToUpper())
                    {
                        isexist = 1;
                        RegistryKey cmd = shell.OpenSubKey(strname + "\\command", true);
                        if (cmd == null)
                        {
                            RegistryKey[] keys = new RegistryKey[2];
                            keys[0] = shell.CreateSubKey(strname);
                            keys[1] = keys[0].CreateSubKey("command");
                            shell = keys[1];
                        }
                        string a = cmd.GetValue(string.Empty).ToString();
                        string path = cmd.GetValue(string.Empty).ToString()
                            .Split(new string[] { " \"%1\"" }, StringSplitOptions.RemoveEmptyEntries)[0];
                        lustpath = path.Substring(1, path.Length - 2);
                        cmd.Close();
                        break;
                    }
                }
                shell.Close();
                return isexist;
            }
            catch (Exception exception) // 防止最终结果呈现runs列表为空导致抛出异常，添加try-catch结构
            {
                lusterror = exception.Message;
                return -1;
                // throw;
            }
        }

        /// <summary>
        /// 写入注册表项
        /// </summary>
        /// <param name="name">项名称</param>
        /// <param name="info">说明文本</param>
        /// <param name="path">应用程序完整路径</param>
        /// <returns>表示操作是否成功的布尔值</returns>
        internal static bool on(string name, string info, string path)
        {
            lusterror = null;
            try
            {
                RegistryKey root = Registry.ClassesRoot;
                RegistryKey shell = root.OpenSubKey("Folder\\shell", true);
                if (shell == null) // 为保证runs列表为空不是由于目录尚未创建引起的，执行以下操作
                {
                    RegistryKey[] keys = new RegistryKey[2];
                    keys[0] = root.CreateSubKey("Folder");
                    keys[1] = keys[0].CreateSubKey("shell");
                    shell = keys[1];
                }
                RegistryKey rightcommondkey = shell.CreateSubKey(name);
                rightcommondkey.SetValue("icon", "\"" + path + "\"");
                rightcommondkey.SetValue("MUIVerb", info);
                rightcommondkey.SetValue("MultiSelectModel", "Single");
                rightcommondkey.SetValue("Position", string.Empty);
                rightcommondkey.SetValue("SeparatorAfter", string.Empty);
                rightcommondkey.SetValue("SeparatorBefore", string.Empty);
                RegistryKey associatedprogramkey = rightcommondkey.CreateSubKey("command");
                associatedprogramkey.SetValue(string.Empty, "\"" + path + "\" \"%1\"");
                associatedprogramkey.Close();
                rightcommondkey.Close();
                shell.Close();
            }
            catch (Exception exception)
            {
                lusterror = exception.Message;
                return false;
            }
            return overlay(name, info, path);
        }

        /// <summary>
        /// 移除注册表项
        /// </summary>
        /// <param name="name">项名称</param>
        /// <returns>表示操作是否成功的布尔值</returns>
        internal static bool off(string name)
        {
            lusterror = null;
            try
            {
                RegistryKey root = Registry.ClassesRoot;
                RegistryKey shell = root.OpenSubKey("Folder\\shell", true);
                if (shell == null) // 为保证runs列表为空不是由于目录尚未创建引起的，执行以下操作
                {
                    RegistryKey[] keys = new RegistryKey[2];
                    keys[0] = root.CreateSubKey("Folder");
                    keys[1] = keys[0].CreateSubKey("shell");
                    shell = keys[1];
                }
                string[] keynames = shell.GetSubKeyNames();
                foreach (string keyname in keynames)
                {
                    if (keyname.ToUpper() == name.ToUpper())
                    {
                        shell.DeleteSubKeyTree(name);
                        shell.Close();
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                lusterror = exception.Message;
                return false;
            }
            if (!needupdate)
            {
                lusterror = null;
                try
                {
                    RegistryKey root = Registry.ClassesRoot;
                    RegistryKey shell = root.OpenSubKey("Directory\\Background\\shell", true);
                    if (shell == null) // 为保证runs列表为空不是由于目录尚未创建引起的，执行以下操作
                    {
                        RegistryKey[] keys = new RegistryKey[3];
                        keys[0] = root.CreateSubKey("Directory");
                        keys[1] = keys[0].CreateSubKey("Background");
                        keys[2] = keys[1].CreateSubKey("shell");
                        shell = keys[2];
                    }
                    string[] keynames = shell.GetSubKeyNames();
                    foreach (string keyname in keynames)
                    {
                        if (keyname.ToUpper() == name.ToUpper())
                        {
                            shell.DeleteSubKeyTree(name);
                            shell.Close();
                            break;
                        }
                    }
                }
                catch (Exception exception)
                {
                    lusterror = exception.Message;
                    return false;
                }
            }
            return true;
        }

        internal static bool overlay(string name, string info, string path)
        {
            lusterror = null;
            try
            {
                RegistryKey root = Registry.ClassesRoot;
                RegistryKey shell = root.OpenSubKey("Directory\\Background\\shell", true);
                if (shell == null) // 为保证runs列表为空不是由于目录尚未创建引起的，执行以下操作
                {
                    RegistryKey[] keys = new RegistryKey[3];
                    keys[0] = root.CreateSubKey("Directory");
                    keys[1] = keys[0].CreateSubKey("Background");
                    keys[2] = keys[1].CreateSubKey("shell");
                    shell = keys[2];
                }
                RegistryKey rightcommondkey = shell.CreateSubKey(name);
                rightcommondkey.SetValue("icon", "\"" + path + "\"");
                rightcommondkey.SetValue("MUIVerb", info);
                rightcommondkey.SetValue("Position", string.Empty);
                rightcommondkey.SetValue("SeparatorAfter", string.Empty);
                rightcommondkey.SetValue("SeparatorBefore", string.Empty);
                RegistryKey associatedprogramkey = rightcommondkey.CreateSubKey("command");
                associatedprogramkey.SetValue(string.Empty, "\"" + path + "\"");
                associatedprogramkey.Close();
                rightcommondkey.Close();
                shell.Close();
                return true;
            }
            catch (Exception exception)
            {
                lusterror = exception.Message;
                return false;
            }
        }
    }
}
