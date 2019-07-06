using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WinShell
{
    public class Shell
    {
        public Shell()
        {
            SHFILEINFO shfi = new SHFILEINFO();

            smallSystemImageList = API.SHGetFileInfo("", 0, out shfi, Marshal.SizeOf(typeof(SHFILEINFO)), SHGFI.SYSICONINDEX | SHGFI.SMALLICON | SHGFI.USEFILEATTRIBUTES);
            largeSystemImageList = API.SHGetFileInfo("", 0, out shfi, Marshal.SizeOf(typeof(SHFILEINFO)), SHGFI.SYSICONINDEX | SHGFI.LARGEICON | SHGFI.USEFILEATTRIBUTES);

            deskTop = API.GetDesktopFolder(out deskTopPtr);
            API.SHGetSpecialFolderLocation(IntPtr.Zero, CSIDL.DESKTOP, out deskTopPtr);
        }
        public static Shell Default
        {
            get
            {
                if (defaultShell == null)
                {
                    defaultShell = new Shell();
                }
                return defaultShell;
            }
        }
        private static Shell defaultShell;

        public IntPtr SmallSystemImageList
        {
            get
            {
                return smallSystemImageList;
            }
        }
        IntPtr smallSystemImageList = IntPtr.Zero;

        public IntPtr LargeSystemImageList
        {
            get
            {
                return largeSystemImageList;
            }
        }
        IntPtr largeSystemImageList = IntPtr.Zero;

        public IShellFolder DeskTop
        {
            get
            {
                return deskTop;
            }
        }
        IShellFolder deskTop;

        public IntPtr DeskTopPIDL
        {
            get
            {
                return deskTopPtr;
            }
        }
        IntPtr deskTopPtr;
    }
}
