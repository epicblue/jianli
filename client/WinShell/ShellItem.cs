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
    public class ShellItem
    {
        public ShellItem()
        {
        }

        public ShellItem(IntPtr PIDL, IShellFolder ShellFolder)
        {
            m_PIDL = PIDL;
            m_ShellFolder = ShellFolder;
            m_ParentItem = null;
        }

        public ShellItem(IntPtr PIDL, IShellFolder ShellFolder, ShellItem ParentItem)
        {
            m_PIDL = PIDL;
            m_ShellFolder = ShellFolder;
            m_ParentItem = ParentItem;
        }

        private IntPtr m_PIDL;

        public IntPtr PIDL
        {
            get { return m_PIDL; }
            set { m_PIDL = value; }
        }

        private ShellItem m_ParentItem;

        public ShellItem ParentItem
        {
            get { return m_ParentItem; }
            set { m_ParentItem = value; }
        }
        
        private IShellFolder m_ShellFolder;

        public IShellFolder ShellFolder
        {
            get { return m_ShellFolder; }
            set { m_ShellFolder = value; }
        }

        /// <summary>
        /// 绝对 PIDL，循环获取得到的
        /// </summary>
        public PIDL PIDLFull
        {
            get
            {
                PIDL pidlFull = new PIDL(PIDL, true);
                ShellItem current = ParentItem;
                while (current != null)
                {
                    pidlFull.Insert(current.PIDL);
                    current = current.ParentItem;
                }
                return pidlFull;
            }
        }

    }
}
