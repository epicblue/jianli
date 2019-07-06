using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WinShell;
using System.Runtime.InteropServices;

namespace JianLi.Editor
{
    public partial class ExplorerTreeControl : UserControl
    {
        public ExplorerTreeControl()
        {
            InitializeComponent();
        }
        // 照旧的桌面
        private IShellFolder iDeskTop;

        private static IntPtr m_ipSmallSystemImageList = IntPtr.Zero;

        private void ExplorerTreeControl_Load(object sender, EventArgs e)
        {
            this.toolStrip1.Visible = false;
            m_ipSmallSystemImageList = Shell.Default.SmallSystemImageList;

            API.SendMessage(treeView1.Handle, API.TVM_SETIMAGELIST, API.TVSIL_NORMAL, m_ipSmallSystemImageList);

            iDeskTop = Shell.Default.DeskTop;

            IntPtr deskTopPtr = Shell.Default.DeskTopPIDL;

            //添加 桌面 节点
            int imgIndex = API.GetSmallIconIndex(deskTopPtr);
            TreeNode tnDesktop = new TreeNode("桌面", imgIndex, imgIndex);
            tnDesktop.Tag = new ShellItem(deskTopPtr, iDeskTop);
            tnDesktop.Nodes.Add("...");

            //把节点添加到树中
            treeView1.Nodes.Add(tnDesktop);
            treeView1.SelectedNode = tnDesktop;
            //tnDesktop.Expand(); 避免开始不必要的停顿。
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            #region 判断节点是否已经展开
            if (e.Node.Nodes.Count != 1)
            {
                return;
            }
            else
            {
                if (e.Node.FirstNode.Text != "...")
                {
                    return;
                }
            }

            e.Node.Nodes.Clear();
            #endregion
            try // 因为文件夹安全设置和设备准备问题，可能导致失败。
            {
                ShellItem sItem = (ShellItem)e.Node.Tag;
                IShellFolder root = sItem.ShellFolder;

                //循环查找子项
                IEnumIDList Enum = null;
                IntPtr EnumPtr = IntPtr.Zero;
                IntPtr pidlSub;
                int celtFetched;

                if (root.EnumObjects(this.Handle, SHCONTF.FOLDERS | SHCONTF.INCLUDEHIDDEN, out EnumPtr) == API.S_OK)
                {
                    Enum = (IEnumIDList)Marshal.GetObjectForIUnknown(EnumPtr);
                    while (Enum.Next(1, out pidlSub, out celtFetched) == 0 && celtFetched == API.S_FALSE)
                    {
                        string name = API.GetNameByIShell(root, pidlSub);
                        IShellFolder iSub;
                        root.BindToObject(pidlSub, IntPtr.Zero, ref Guids.IID_IShellFolder, out iSub);

                        ShellItem shellItem = new ShellItem(pidlSub, iSub, sItem);
                        int imgIndex = API.GetSmallIconIndex(shellItem.PIDLFull.Ptr);
                        TreeNode nodeSub = new TreeNode(name, imgIndex, imgIndex);

                        nodeSub.Tag = shellItem;
                        nodeSub.Nodes.Add("...");
                        e.Node.Nodes.Add(nodeSub);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ShellItem SelectedShellItem;

        // 发出路径选择事件
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedShellItem = (ShellItem)e.Node.Tag;
            if (SelectedShellItemChangedHandler != null)
                SelectedShellItemChangedHandler(SelectedShellItem);

            System.Text.StringBuilder path = new System.Text.StringBuilder(256);
            API.SHGetPathFromIDList(SelectedShellItem.PIDLFull.Ptr, path);

            selectedpath = path.ToString();

            if (OnPathChanged != null)
                OnPathChanged(this,null);
        }
        // 以文件系统路径方式保存选择路径
        private string selectedpath;
        public string SelectedPath
        {
            get
            {
                return selectedpath;
            }
            set
            {
                if (treeView1.Nodes.Count == 0)// 以免窗体初始化的设置代码导致出错。
                    return;

                //如何从路径获取循环的IDL
                IntPtr pidlRoot;
                uint iAttribute;

                API.SHParseDisplayName(value, IntPtr.Zero, out pidlRoot, 0, out iAttribute);

                PIDL fullidl = new PIDL(pidlRoot, false);
                int size = PIDL.ItemIDListCount(pidlRoot);
                fullidl.PrintItemIDList();


                treeView1.Nodes[0].Expand();
                TreeNodeCollection tns = treeView1.Nodes[0].Nodes;
                // 逐级展开
                for (int i = 0; i < size; i++)
                {
                    byte[] bs = fullidl.GetItemID(i);


                    foreach (TreeNode tn in tns)
                    {
                        PIDL pidl =new PIDL(((ShellItem)tn.Tag).PIDL,false);
                        byte[] bs2 = pidl.GetItemID(0);

                        // 对比2个pidl的同级数组
                        if (bs2.Length == bs.Length)
                        {
                            bool con = true;
                            for (int j = 0; j < bs2.Length; j++)
                            {
                                if (bs[j] != bs2[j])
                                {
                                    con = false;
                                    break;
                                }
                            }
                            if (con)//对比成功
                            {
                                tn.Expand();
                                tns = tn.Nodes;
                                if (i == size - 1)
                                {
                                    treeView1.Focus();// 强调显示
                                    treeView1.SelectedNode = tn;
                                }
                                break;
                            }
                        }
                    }
                    //
                }
                selectedpath = value;
            }
        }

        public event EventHandler OnPathChanged;

        public delegate void SelectedShellItemChangedDelegate(ShellItem item);
        public event SelectedShellItemChangedDelegate SelectedShellItemChangedHandler;

        private void treeView1_Enter(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            treeView1.SelectedNode.BackColor = Color.White;
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;
            treeView1.SelectedNode.BackColor = Color.LightGray;
        }
    }
}
