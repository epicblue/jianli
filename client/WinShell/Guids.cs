//程序开发：lc_mtt
//CSDN博客：http://lemony.cnblogs.com
//个人主页：http://www.3lsoft.com
//注：此代码禁止用于商业用途。有修改者发我一份，谢谢！
//---------------- 开源世界，你我更进步 ----------------

using System;
using System.Collections.Generic;
using System.Text;

namespace WinShell
{
    public class Guids
    {
        public static Guid IID_DesktopGUID = new Guid("{00021400-0000-0000-C000-000000000046}");

        public static Guid IID_IShellFolder = new Guid("{000214E6-0000-0000-C000-000000000046}");
        public static Guid IID_IContextMenu = new Guid("{000214e4-0000-0000-c000-000000000046}");
        public static Guid IID_IContextMenu2 = new Guid("{000214f4-0000-0000-c000-000000000046}");
        public static Guid IID_IContextMenu3 = new Guid("{bcfce0a0-ec17-11d0-8d10-00a0c90f2719}");

        public static Guid IID_IDropTarget = new Guid("{00000122-0000-0000-C000-000000000046}");
        public static Guid IID_IDataObject = new Guid("{0000010e-0000-0000-C000-000000000046}");

        public static Guid IID_IQueryInfo = new Guid("{00021500-0000-0000-C000-000000000046}");
        public static Guid IID_IPersistFile = new Guid("{0000010b-0000-0000-C000-000000000046}");

        public static Guid CLSID_DragDropHelper = new Guid("{4657278A-411B-11d2-839A-00C04FD918D0}");
        public static Guid CLSID_NewMenu = new Guid("{D969A300-E7FF-11d0-A93B-00A0C90F2719}");
        public static Guid IID_IDragSourceHelper = new Guid("{DE5BF786-477A-11d2-839D-00C04FD918D0}");
        public static Guid IID_IDropTargetHelper = new Guid("{4657278B-411B-11d2-839A-00C04FD918D0}");

        public static Guid IID_IShellExtInit = new Guid("{000214e8-0000-0000-c000-000000000046}");
        public static Guid IID_IStream = new Guid("{0000000c-0000-0000-c000-000000000046}");
        public static Guid IID_IStorage = new Guid("{0000000B-0000-0000-C000-000000000046}");
    }
}
