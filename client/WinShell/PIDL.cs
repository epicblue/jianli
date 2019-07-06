using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;

namespace WinShell
{
    public class PIDL
    {
        private IntPtr pidl = IntPtr.Zero;

        public PIDL(IntPtr pidl, bool clone)
        {
            if (clone)
                this.pidl = ILClone(pidl);
            else
                this.pidl = pidl;
        }

        public PIDL(PIDL pidl, bool clone)
        {
            if (clone)
                this.pidl = ILClone(pidl.Ptr);
            else
                this.pidl = pidl.Ptr;
        }


        public IntPtr Ptr 
        { 
            get { return pidl; } 
        }

        public void Insert(IntPtr insertPidl)
        {
            IntPtr newPidl = ILCombine(insertPidl, pidl);

            Marshal.FreeCoTaskMem(pidl);
            pidl = newPidl;
        }

        public void Free()
        {
            if (pidl != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(pidl);
                pidl = IntPtr.Zero;
            }
        }


        private static int ItemIDSize(IntPtr pidl)
        {
            if (!pidl.Equals(IntPtr.Zero))
            {
                byte[] buffer = new byte[2];
                Marshal.Copy(pidl, buffer, 0, 2);
                return buffer[1] * 256 + buffer[0];
            }
            else
                return 0;
        }
        // ��ȡȫ��
        public static int ItemIDListSize(IntPtr pidl)
        {
            if (pidl.Equals(IntPtr.Zero))
                return 0;
            else
            {
                int size = ItemIDSize(pidl);
                int nextSize = Marshal.ReadByte(pidl, size) + (Marshal.ReadByte(pidl, size + 1) * 256);
                while (nextSize > 0)
                {
                    size += nextSize;
                    nextSize = Marshal.ReadByte(pidl, size) + (Marshal.ReadByte(pidl, size + 1) * 256);
                }

                return size;
            }
        }

        public static IntPtr ILClone(IntPtr pidl)
        {
            int size = ItemIDListSize(pidl);

            byte[] bytes = new byte[size + 2];
            Marshal.Copy(pidl, bytes, 0, size);

            IntPtr newPidl = Marshal.AllocCoTaskMem(size + 2);
            Marshal.Copy(bytes, 0, newPidl, size + 2);

            return newPidl;
        }
        //�ɼ�����id����id֮ǰ�����ԣ���ǰ���������id
        public static IntPtr ILCombine(IntPtr pidl1, IntPtr pidl2)
        {
            int size1 = ItemIDListSize(pidl1);
            int size2 = ItemIDListSize(pidl2);

            IntPtr newPidl = Marshal.AllocCoTaskMem(size1 + size2 + 2);
            byte[] bytes = new byte[size1 + size2 + 2];

            Marshal.Copy(pidl1, bytes, 0, size1);
            Marshal.Copy(pidl2, bytes, size1, size2);

            Marshal.Copy(bytes, 0, newPidl, bytes.Length);

            return newPidl;
        }

#region Ϊ�˱Ƚ�PIDL
        public byte[] GetItemID(int idx)
        {
            if (pidl.Equals(IntPtr.Zero))
                    throw new Exception("pidlΪIntPtr.Zero��");
            else
            {
                int size = ItemIDListSize(pidl);
                if (size == 0)
                    return null;//Ϊ����

                if (idx >= size)
                    throw new Exception("ItemID idx�����߽磡");

                int len = ItemIDSize(pidl);
                byte[] bs;
                if (idx == 0)
                {
                     bs = new byte[len-2];
                    for (int i = 0; i < len-2; i++)
                        bs[i] = Marshal.ReadByte(pidl, 2+i);
                    return bs;
                }
                int nextlen = Marshal.ReadByte(pidl, len) + (Marshal.ReadByte(pidl, len + 1) * 256);

                while (idx > 1)
                {
                    idx--;
                    len += nextlen;
                    nextlen = Marshal.ReadByte(pidl, len) + (Marshal.ReadByte(pidl, len + 1) * 256);
                }

                bs = new byte[nextlen-2];

                for (int i = 0; i < nextlen - 2; i++)
                    bs[i] = Marshal.ReadByte(pidl,len+ 2 + i);

                return bs;
            }
        }
        //��ӡ������ItemID
        public void PrintItemIDList()
        {
            if (pidl.Equals(IntPtr.Zero))
            {
                Console.WriteLine("Zero ItemIDList");
                return;
            }
            else
            {
                int size = ItemIDSize(pidl);// ��һ��IID����

                Console.Write(size + "  ");
                for (int i = 2; i < size; i++)
                    Console.Write(Marshal.ReadByte(pidl, i).ToString() + " ");
                Console.WriteLine();

                int nextSize = Marshal.ReadByte(pidl, size) + (Marshal.ReadByte(pidl, size + 1) * 256);//�ڶ���IID����
                while (nextSize > 0)
                {
                    Console.Write(nextSize + "  ");
                    for (int i = 2; i < nextSize; i++)
                        Console.Write(Marshal.ReadByte(pidl, size + i).ToString() + " ");
                    Console.WriteLine();

                    size += nextSize;
                    nextSize = Marshal.ReadByte(pidl, size) + (Marshal.ReadByte(pidl, size + 1) * 256);
                }
            }
        }
        // ��ȡIDList����
        public static int ItemIDListCount(IntPtr pidl)
        {
            int count = 0;
            if (pidl.Equals(IntPtr.Zero))
                return 0;
            else
            {
                int size = ItemIDSize(pidl);
                if (size > 0)
                    count++;
                int nextSize = Marshal.ReadByte(pidl, size) + (Marshal.ReadByte(pidl, size + 1) * 256);
                while (nextSize > 0)
                {
                    count++;
                    size += nextSize;
                    nextSize = Marshal.ReadByte(pidl, size) + (Marshal.ReadByte(pidl, size + 1) * 256);
                }

                return count;
            }
        }
#endregion
    }
}
