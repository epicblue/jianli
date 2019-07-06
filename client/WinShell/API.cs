//程序开发：lc_mtt
//CSDN博客：http://lemony.cnblogs.com
//个人主页：http://www.3lsoft.com
//注：此代码禁止用于商业用途。有修改者发我一份，谢谢！
//---------------- 开源世界，你我更进步 ----------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WinShell
{
    public class API
    {

        #region 常数

        public const int MAX_PATH = 260;
        public const int S_OK = 0;
        public const int S_FALSE = 1;
        public const uint CMD_FIRST = 1;
        public const uint CMD_LAST = 30000;

        public const int TV_FIRST = 0x1100;
        public const int TVM_SETIMAGELIST = (TV_FIRST + 9);
        public const int TVSIL_NORMAL = 0;

        public const int LVM_FIRST = 0x1000;
        public const int LVM_GETHEADER = (LVM_FIRST + 31);
        public const int LVM_SETIMAGELIST = LVM_FIRST + 3;
        public const int LVSIL_NORMAL = 0;
        public const int LVSIL_SMALL = 1;


        #endregion

        #region API 导入

        [DllImport("shell32.dll")]
        public static extern Int32 SHGetDesktopFolder(out IntPtr ppshf);

        [DllImport("Shlwapi.Dll", CharSet = CharSet.Auto)]
        public static extern Int32 StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);

        [DllImport("shell32.dll")]
        public static extern int SHGetSpecialFolderLocation(IntPtr handle, CSIDL nFolder, out IntPtr ppidl);

        [DllImport("shell32", EntryPoint = "SHGetFileInfo", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SHGetFileInfo(IntPtr ppidl, FILE_ATTRIBUTE dwFileAttributes, ref SHFILEINFO sfi, int cbFileInfo, SHGFI uFlags);

        [DllImport("Shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(string Path, FILE_ATTRIBUTE fileAttributes, out SHFILEINFO sfi, int cbFileInfo, SHGFI flags);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int SendMessage(IntPtr hwnd, uint Msg, int wParam, IntPtr lParam);

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreatePopupMenu();

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern uint TrackPopupMenuEx(IntPtr hmenu, TPM flags, int x, int y, IntPtr hwnd, IntPtr lptpm);

        [DllImport("Shell32.Dll")]
        private static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, StringBuilder lpszPath, ShellSpecialFolders nFolder, bool fCreate);

        [DllImport("shell32.dll")]
        public static extern Int32 SHGetRealIDL(IShellFolder psf, IntPtr pidlSimple, out IntPtr ppidlReal);

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool InsertMenu(IntPtr hmenu, uint uPosition, MFT uflags, uint uIDNewItem, [MarshalAs(UnmanagedType.LPTStr)] string lpNewItem);

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetMenuDefaultItem(IntPtr hMenu, uint uItem, bool fByPos);

        [DllImport("shell32.dll", EntryPoint = "ILIsEqual", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern bool ILIsEqual(IntPtr pidl1, IntPtr pidl2);

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags);

        #endregion

        /// <summary>
        /// 获得桌面 Shell
        /// </summary>
        public static IShellFolder GetDesktopFolder(out IntPtr ppshf)
        {
            SHGetDesktopFolder(out ppshf);
            Object obj = Marshal.GetObjectForIUnknown(ppshf);
            return (IShellFolder)obj;
        }
        #region 绝对IDL

        // 从绝对IDL中得到绝对路径，比如：(C:\Windows)
        [DllImport("shell32.dll")]
        public static extern Int32 SHGetPathFromIDList(
            IntPtr pidl,                // Address of an item identifier list that
                                        // specifies a file or directory location
                                        // relative to the root of the namespace (the
                                        // desktop). 
            StringBuilder pszPath);

        // 从绝对路径中得到绝对IDL
        // Translates a Shell namespace object's display name into an item 
        // identifier list and returns the attributes of the object. This function is 
        // the preferred method to convert a string to a pointer to an item identifier 
        // list (PIDL). 
        [DllImport("shell32.dll")]
        public static extern Int32 SHParseDisplayName(
            [MarshalAs(UnmanagedType.LPWStr)]String pszName,    // Pointer to a zero-terminated wide string that
                                                                // contains the display name 
                                                                // to parse. 
            IntPtr pbc,                                 // Optional bind context that controls the parsing
                                                        // operation. This parameter 
                                                        // is normally set to NULL.
            out IntPtr ppidl,                   // Address of a pointer to a variable of type
                                                // ITEMIDLIST that receives the item
                                                // identifier list for the object.
            UInt32 sfgaoIn,                     // ULONG value that specifies the attributes to
                                        // query.
            out UInt32 psfgaoOut);      // Pointer to a ULONG. On return, those attributes
        /* sample
        ShellLib.IMalloc pMalloc;
        pMalloc = ShellLib.ShellFunctions.GetMalloc();

        IntPtr pidlRoot;
        String sPath = @"c:\temp\divx";
        uint iAttribute;

        ShellLib.ShellApi.SHParseDisplayName(sPath,IntPtr.Zero,out pidlRoot,0,
            out iAttribute);

        if (pidlRoot != IntPtr.Zero)
            pMalloc.Free(pidlRoot);

        System.Runtime.InteropServices.Marshal.ReleaseComObject(pMalloc);*/
        #endregion

        /// <summary>
        /// 获取路径
        /// </summary>
        public static string GetPathByIShell(IShellFolder Root, IntPtr pidlSub)
        {
            IntPtr strr = Marshal.AllocCoTaskMem(MAX_PATH * 2 + 4);
            Marshal.WriteInt32(strr, 0, 0);
            StringBuilder buf = new StringBuilder(MAX_PATH);
            Root.GetDisplayNameOf(pidlSub, SHGNO.FORADDRESSBAR | SHGNO.FORPARSING, strr);
            API.StrRetToBuf(strr, pidlSub, buf, MAX_PATH);
            Marshal.FreeCoTaskMem(strr);
            return buf.ToString();
        }

        /// <summary>
        /// 获取显示名称
        /// </summary>
        public static string GetNameByIShell(IShellFolder Root, IntPtr pidlSub)
        {
            IntPtr strr = Marshal.AllocCoTaskMem(MAX_PATH * 2 + 4);
            Marshal.WriteInt32(strr, 0, 0);
            StringBuilder buf = new StringBuilder(MAX_PATH);
            Root.GetDisplayNameOf(pidlSub, SHGNO.INFOLDER, strr);
            API.StrRetToBuf(strr, pidlSub, buf, MAX_PATH);
            Marshal.FreeCoTaskMem(strr);
            return buf.ToString();
        }

        /// <summary>
        /// 根据 PIDL 获取显示名称
        /// </summary>
        public static string GetNameByPIDL(IntPtr pidl)
        {
            SHFILEINFO info = new SHFILEINFO();
            API.SHGetFileInfo(pidl, 0, ref info, Marshal.SizeOf(typeof(SHFILEINFO)),
                SHGFI.PIDL | SHGFI.DISPLAYNAME | SHGFI.TYPENAME);
            return info.szDisplayName;
        }

        /// <summary>
        /// 获取特殊文件夹的路径
        /// </summary>
        public static string GetSpecialFolderPath(IntPtr hwnd, ShellSpecialFolders nFolder)
        {
            StringBuilder sb = new StringBuilder(MAX_PATH);
            SHGetSpecialFolderPath(hwnd, sb, nFolder, false);
            return sb.ToString();
        }

        /// <summary>
        /// 根据路径获取 IShellFolder 和 PIDL
        /// </summary>
        public static IShellFolder GetShellFolder(IShellFolder desktop, string path, out IntPtr Pidl)
        {
            IShellFolder IFolder;
            uint i, j = 0;
            desktop.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, path, out i, out Pidl, ref j);
            desktop.BindToObject(Pidl, IntPtr.Zero, ref Guids.IID_IShellFolder, out IFolder);
            return IFolder;
        }

        /// <summary>
        /// 根据路径获取 IShellFolder
        /// </summary>
        public static IShellFolder GetShellFolder(IShellFolder desktop, string path)
        {
            IntPtr Pidl;
            return GetShellFolder(desktop, path, out Pidl);
        }

        /// <summary>
        /// 获取大图标索引
        /// </summary>
        public static int GetLargeIconIndex(string strFilename)
        {
            SHFILEINFO psfi = new SHFILEINFO();
            SHGFI dwflag = SHGFI.ICON | SHGFI.LARGEICON | SHGFI.SYSICONINDEX;
            IntPtr ipIcon = SHGetFileInfo(strFilename, 0, out psfi, Marshal.SizeOf(psfi), dwflag);

            return psfi.iIcon;
        }

        /// <summary>
        /// 获取大图标索引
        /// </summary>
        public static int GetLargeIconIndex(IntPtr ipIDList)
        {
            SHFILEINFO psfi = new SHFILEINFO();
            SHGFI dwflag = SHGFI.ICON | SHGFI.LARGEICON | SHGFI.PIDL | SHGFI.SYSICONINDEX;
            IntPtr ipIcon = SHGetFileInfo(ipIDList, 0, ref psfi, Marshal.SizeOf(psfi), dwflag);

            return psfi.iIcon;
        }

        /// <summary>
        /// 获取小图标索引
        /// </summary>
        public static int GetSmallIconIndex(string strFilename)
        {
            SHFILEINFO psfi = new SHFILEINFO();
            SHGFI dwflag = SHGFI.ICON | SHGFI.SMALLICON | SHGFI.SYSICONINDEX;
            IntPtr ipIcon = SHGetFileInfo(strFilename, 0, out psfi, Marshal.SizeOf(psfi), dwflag);

            return psfi.iIcon;
        }

        public static int GetSmallIconIndex(IntPtr ipIDList)
        {
            SHFILEINFO psfi = new SHFILEINFO();
            SHGFI dwflag = SHGFI.ICON | SHGFI.PIDL | SHGFI.SMALLICON | SHGFI.SYSICONINDEX;
            IntPtr ipIcon = SHGetFileInfo(ipIDList, 0, ref psfi, Marshal.SizeOf(psfi), dwflag);

            return psfi.iIcon;
        }


        public static IntPtr GetPIDLByPath(IShellFolder deskfolder, string path)
        {
            IntPtr  Pidl = IntPtr.Zero;
            uint i, j = 0;
            deskfolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, path, out i, out Pidl, ref j);
            return Pidl;
        }
    }
}
