//���򿪷���lc_mtt
//CSDN���ͣ�http://lemony.cnblogs.com
//������ҳ��http://www.3lsoft.com
//ע���˴����ֹ������ҵ��;�����޸��߷���һ�ݣ�лл��
//---------------- ��Դ���磬���Ҹ����� ----------------

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
        /// ���� PIDL��ѭ����ȡ�õ���
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
