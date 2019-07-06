using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinShell;
using System.Diagnostics;
using JianLi3Data;
using JianLi3Data.DataSetting;
using JianLi3Data.FileService;
using JianLi3Data.cache;
using JianLi3.Books;
using JianLi3.editor;

namespace JianLi3
{
    public partial class NewFilesControl : UserControl
    {
        public NewFilesControl()
        {
            InitializeComponent();
        }

        void explorerTreeControl1_OnPathChanged(object sender, EventArgs e)
        {
            if (JianLi3FileServiceManager.Default.LocalMode)
            {
                if (explorerTreeControl1.SelectedPath.ToUpper().StartsWith(DataSettings.Default.LibFolder.ToUpper()))
                {
                    listView1.Items.Clear();
                    return;
                }
            }
            else
            {
                if (explorerTreeControl1.SelectedPath.ToUpper().StartsWith(FileCache.Default.cachefolder.ToUpper()))
                {
                    listView1.Items.Clear();
                    return;
                }
            }

            DataSettings.Default.IncomingFolder = explorerTreeControl1.SelectedPath;
        }

        void Default_OnIncomingFolderChanged(object sender, EventArgs e)
        {
            RefreshFileList(DataSettings.Default.IncomingFolder);
        }

        
        IShellFolder deskfolder;
        private static IntPtr m_ipLargeSystemImageList;// 图标

        // 列出所有文件
        private void RefreshFileList(string path)
        {
            listView1.Items.Clear();
            if (!Directory.Exists(path))
                return;
            try // 文件夹权限，设备就绪问题。
            {
                string[] filenames = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);

                foreach (string f in filenames)
                {
                    string s = Path.GetFileName(f);

                    IntPtr pidl = API.GetPIDLByPath(deskfolder, f);

                    ListViewItem item = new ListViewItem(s, API.GetLargeIconIndex(pidl));
                    item.Tag = f;

                    this.listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewBookControl_Load(object sender, EventArgs e)
        {
            // 初始化图标
            deskfolder = Shell.Default.DeskTop;
            m_ipLargeSystemImageList = Shell.Default.LargeSystemImageList;
            API.SendMessage(listView1.Handle, API.LVM_SETIMAGELIST, API.LVSIL_NORMAL, m_ipLargeSystemImageList);

            DataSettings.Default.OnIncomingFolderChanged += new EventHandler(Default_OnIncomingFolderChanged);
            explorerTreeControl1.OnPathChanged += new EventHandler(explorerTreeControl1_OnPathChanged);
            explorerTreeControl1.SelectedPath = DataSettings.Default.IncomingFolder;
            RefreshFileList(DataSettings.Default.IncomingFolder);
        }

        #region Execute File
        // 执行打开
        private void RunFirstSelectedFile()
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                string filename = (string)(this.listView1.SelectedItems[0].Tag);
                try
                {
                    Process.Start(filename);
                }catch(Exception ex)// 文件没有关联的时候会弹出错误。
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // 右键打开操作
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunFirstSelectedFile();
        }

        // 双击打开操作
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            RunFirstSelectedFile();
        }

        #endregion

        // 将被破坏、无价值的文件(比如：getfile.asp) 删除。注意：不会留在垃圾桶里面！
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string filepath = (string)(listView1.SelectedItems[0].Tag);

                if (MessageBox.Show("确认要删除： " + Path.GetFileName(filepath) + " 吗？操作无法恢复。", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    System.IO.File.Delete(filepath);

                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }
            }
        }
        // 将文件标记为书籍
        private void 添加信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;
            bool acrobatvalid = true;

            // 检测Acrobat控件是否能够使用
            try
            {
                AxAcroPDFLib.AxAcroPDF axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            }
            catch (Exception ex)
            {
                acrobatvalid = false;
            }

            INewBookView view;

            if (acrobatvalid)
                view = new CreateBookFromFileForm();
            else
                view = new CreateBookFromFileNormalForm();

            NewBookPresent p = new NewBookPresent(view, listView1.SelectedItems[0].Tag.ToString());

            if (view.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshFileList(DataSettings.Default.IncomingFolder);
        }

        private void OpenFolderMenu_Click(object sender, EventArgs e)
        {
            Process.Start(DataSettings.Default.IncomingFolder);
        }
    }
}
