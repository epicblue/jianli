using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using JianLi3Data.Client;
using JianLi3Data.FileService;
using JianLi3Data.JLBook.User;
using JianLi3Data;
using JianLi3Data.Properties;
using JianLi3Data.DataSetting;
using System.Runtime.InteropServices;

namespace JianLi3.views
{
    public delegate void AfterSelectKeywordDelegate(Keywords keyword);
    public delegate void SelectedTypeChangedDelegate(bool iskeyword);

    // ！！！需要图标来分别关键字和类别。
    public partial class CategoryAndKeywordControl : UserControl
    {
        JianLi3Data.DataClasses1DataContext db;
        public CategoryAndKeywordControl()
        {
            InitializeComponent();
            db = JianLiLinq.Default.DB;
            DataSettings.Default.OnUserChanged += new EventHandler(Default_OnUserChanged);
            Init();
        }

        void Default_OnUserChanged(object sender, EventArgs e)
        {
            Init();
        }
        public void Init()
        {
            this.CategoryTree.Nodes.Clear();

            // 初始化子类别
            var cs = from c in db.Categories
                     where c.CategoryParent == -1
                     select c;

            foreach (var c in cs)
            {
                TreeNode tn = new TreeNode();
                tn.Tag = c;
                tn.Text = c.CategoryName;
                tn.ToolTipText = c.CategoryDesc;

                tn.Nodes.Add("占位");
                this.CategoryTree.Nodes.Add(tn);
            }
        }
        private void CreateSonNode(TreeNode target)
        {
            if (target.Tag is Categories)
            {
                if (target.Nodes.Count == 1 && target.Nodes[0].Text == "占位")
                {
                    target.Nodes.Clear();

                    // 初始化子类别
                    var cs = from c in db.Categories
                             where c.CategoryParent == ((Categories)target.Tag).CategoryID
                             select c;

                    foreach (var c in cs)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Tag = c;
                        tn.Text = c.CategoryName;
                        tn.ToolTipText = c.CategoryDesc;

                        tn.Nodes.Add("占位");
                        target.Nodes.Add(tn);
                    }


                    // 初始化关键字
                    var ks = from k in db.Keywords
                             where k.CategoryId == ((Categories)target.Tag).CategoryID
                             orderby k.KeywordRate descending, k.KeywordName descending
                             select k;

                    foreach (var k in ks)
                    {
                        TreeNode tn = new TreeNode();
                        KeywordAndUser ku = new KeywordAndUser();
                        ku.UserKeyword = JianLiLinq.Default.GetUserKeyword(k);
                        ku.Keyword = k;
                        tn.Tag = ku;
                        tn.Text = k.KeywordName;
                        tn.ToolTipText = k.KeywordDesc;
                        PresentColor(ref tn, ku.KeywordRate);
                        target.Nodes.Add(tn);
                    }
                    SortKeyword(target.Nodes);
                }
            }
        }
        private void SortKeyword(TreeNodeCollection tns)
        {
            int c = tns.Count;
            if (c < 2)
                return;

            TreeNode ctn;
            for (int i = 1; i < c; i++)
            {
                ctn = tns[i];
                for (int j = 0; j < c; j++)
                {
                    if (Compare(ctn, tns[j])>0)
                    {
                        tns.Remove(ctn);
                        tns.Insert(j, ctn);
                        break;
                    }
                }

            }
        }
        // 结果为tn1-tn2（如果有效）
        private int Compare(TreeNode tn1, TreeNode tn2)
        {
            if (tn1.Tag is KeywordAndUser && tn2.Tag is KeywordAndUser)
            {
                KeywordAndUser k1 = tn1.Tag as KeywordAndUser;
                KeywordAndUser k2 = tn2.Tag as KeywordAndUser;

                if (k1.KeywordRate != k2.KeywordRate)
                    return k1.KeywordRate - k2.KeywordRate;
                else
                    return k1.KeywordName.CompareTo(k2.KeywordName);
            }
            return 0;
        }
        public string KeywordPath
        {
            get
            {
                TreeNode tn = this.CategoryTree.SelectedNode;
                string path = tn.Text;
                while(tn.Parent!= null)
                {
                    tn = tn.Parent;
                    path = tn.Text +"|"+ path;
                }
                return path;
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            CreateSonNode(e.Node);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 准备右键菜单
            if (CategoryTree.SelectedNode.Tag is Categories)
            {
                CategoryTree.ContextMenuStrip = this.CategoryMenu;
                if (isKeyword == true)
                {
                    isKeyword = false;
                    if (SelectedTypeChanged != null)
                        SelectedTypeChanged(isKeyword);
                }
            }
            else if (CategoryTree.SelectedNode.Tag is KeywordAndUser)
            {
                CategoryTree.ContextMenuStrip = this.KeywordMenu;
                SetCurrentKeywordRate(CategoryTree.SelectedNode);
                if (isKeyword == false)
                {
                    isKeyword = true;
                    if (SelectedTypeChanged != null)
                        SelectedTypeChanged(isKeyword);
                }
                // 看是否存在子文件夹
                Keywords target = ((KeywordAndUser)CategoryTree.SelectedNode.Tag).Keyword;

                if (target.KeywordSubPath == null)
                {
                    this.指定文件夹ToolStripMenuItem.Visible = true;
                    this.打开文件夹ToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.指定文件夹ToolStripMenuItem.Visible = false;
                    this.打开文件夹ToolStripMenuItem.Visible = true;
                }

                if(AfterSelectKeyword!=null)
                    AfterSelectKeyword(target);
            }
        }

        private void NewCategory()
        {
            if (this.CategoryTree.SelectedNode.Tag is Categories)
            {
                Categories cparent = (Categories)(CategoryTree.SelectedNode.Tag);

                NewCategoryForm ncf = new NewCategoryForm();
                if (ncf.ShowDialog() == DialogResult.OK)
                {
                    Categories c = new Categories { CategoryName = ncf.CategoryName, CategoryDesc = ncf.CategoryDesc, CategoryParent = cparent.CategoryID };
                    db.Categories.InsertOnSubmit(c);
                    db.SubmitChanges();

                    TreeNode tn = new TreeNode();
                    tn.Tag = c;
                    tn.Text = c.CategoryName;
                    tn.ToolTipText = c.CategoryDesc;

                    CreateSonNode(this.CategoryTree.SelectedNode);// 起码要初始化

                    this.CategoryTree.SelectedNode.Nodes.Add(tn);// 完成节点添加
                }
            }
        }
        private void NewKeyword()
        {
            if (this.CategoryTree.SelectedNode.Tag is Categories)
            {
                Categories target = (Categories)(this.CategoryTree.SelectedNode.Tag);

                // 这里先借用新建类别的对话框
                NewCategoryForm nkf = new NewCategoryForm();
                nkf.Text = "新建关键字";
                if (nkf.ShowDialog() == DialogResult.OK)
                {
                    Keywords nk = new Keywords {
                        KeywordName = nkf.CategoryName,
                        KeywordDesc = nkf.CategoryDesc,
                        KeywordRate = 3,
                        Categories = target
                    };// 注意这里Categories的赋值
                    nk.KeywordSubPath = JianLi3FileServiceManager.Default.CreateSubFolderInLib(nk.KeywordName);
                    db.Keywords.InsertOnSubmit(nk);
                    db.SubmitChanges();

                    KeywordAndUser ku = new KeywordAndUser();
                    ku.Keyword = nk;
                    ku.UserKeyword = JianLiLinq.Default.GetUserKeyword(nk);

                    db.SubmitChanges();

                    TreeNode tn = new TreeNode();
                    tn.Tag = ku;
                    tn.Text = nk.KeywordName;
                    tn.ToolTipText = nk.KeywordDesc;

                    tn.ForeColor = Color.Blue;

                    CreateSonNode(CategoryTree.SelectedNode);

                    CategoryTree.SelectedNode.Nodes.Add(tn);
                }
            }
        }
        private void EditCategory()
        {
            if (CategoryTree.SelectedNode.Tag is Categories)
            {
                Categories target = (Categories)(CategoryTree.SelectedNode.Tag);
                NewCategoryForm cf = new NewCategoryForm();
                cf.Text = "编辑类别";
                cf.CategoryDesc = target.CategoryDesc;
                cf.CategoryName = target.CategoryName;

                if (cf.ShowDialog() == DialogResult.OK)
                {
                    target.CategoryName = cf.CategoryName;
                    target.CategoryDesc = cf.CategoryDesc;

                    CategoryTree.SelectedNode.Text = target.CategoryName;
                    CategoryTree.SelectedNode.ToolTipText = target.CategoryDesc;

                    db.SubmitChanges();
                }
            }
        }
        private void DelCategory()
        {
            if (CategoryTree.SelectedNode.Tag is Categories)
            {
                if (CategoryTree.SelectedNode.Nodes.Count != 0)
                {
                    MessageBox.Show("当前类别不为空，不能删除。");
                    return;
                }
                if (MessageBox.Show("确定要删除该类别吗？", "删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.Categories.DeleteOnSubmit((Categories)(CategoryTree.SelectedNode.Tag));
                    db.SubmitChanges();
                    CategoryTree.SelectedNode.Remove();
                }
            }
        }
        private void EditKeyword()
        {
            if (CategoryTree.SelectedNode.Tag is KeywordAndUser)
            {
                KeywordAndUser target = (KeywordAndUser)(CategoryTree.SelectedNode.Tag);
                KeywordsEditForm cf = new KeywordsEditForm();
                cf.Text = "编辑关键字";
                cf.KeywordName = target.KeywordName;
                cf.KeywordDesc = target.KeywordDesc;
                cf.KeywordRate = target.KeywordRate;

                if (cf.ShowDialog() == DialogResult.OK)
                {
                    target.KeywordName = cf.KeywordName;
                    target.KeywordDesc = cf.KeywordDesc;
                    target.KeywordRate = cf.KeywordRate;

                    CategoryTree.SelectedNode.Text = target.KeywordName;
                    CategoryTree.SelectedNode.ToolTipText = target.KeywordDesc;

                    db.SubmitChanges();

                    TreeNode tn = CategoryTree.SelectedNode;
                    PresentColor(ref tn, target.KeywordRate);
                }
            }
        }
        private void DelKeyword()
        {
            if (CategoryTree.SelectedNode.Tag is KeywordAndUser)
            {
                KeywordAndUser ku = (KeywordAndUser)CategoryTree.SelectedNode.Tag;
                if (MessageBox.Show("确认删除该关键字吗？所有标记有该关键字的书籍将被取消该关键字。", "删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Keywords k = ku.Keyword;
                    JianLiLinq.Default.DelKeyword(k);

                    CategoryTree.SelectedNode.Tag = null;
                    CategoryTree.SelectedNode.Remove();
                }
            }
        }
        private void MoveFileToKeywordFolder()
        {
            if (CategoryTree.SelectedNode.Tag is KeywordAndUser)
            {
                Keywords target = ((KeywordAndUser)CategoryTree.SelectedNode.Tag).Keyword;

                if (target.KeywordSubPath == null)
                    LocalAction.CreateKeywordDefaultSubPath(ref target);
                else
                    return;

                if(LocalAction.MoveKeywordFileToFolder(ref target))
                {
                    JianLiLinq.Default.DB.SubmitChanges();

                    this.指定文件夹ToolStripMenuItem.Visible = false;
                    this.打开文件夹ToolStripMenuItem.Visible = true;
                }// 没有处理移动失败
            }
        }
        private void OpenKeywordPath()
        {
            if (!JianLi3FileServiceManager.Default.LocalMode)
            {
                ProcessStartInfo info2 = new ProcessStartInfo("explorer");
                info2.Arguments = @"D:\jlcache";
                info2.UseShellExecute = true;
                Process.Start(info2);
            }
            else
            {
                if (CategoryTree.SelectedNode.Tag is KeywordAndUser)
                {
                    /*Keywords target = ((KeywordAndUser)CategoryTree.SelectedNode.Tag).Keyword;
                    IntPtr i = ShellExecute(this.Handle, "explore", DataSettings.Default.LibFolder + "\\" + target.KeywordSubPath,
                        "",
                        DataSettings.Default.LibFolder + "\\" + target.KeywordSubPath, 1);*/

                    Keywords target = ((KeywordAndUser)CategoryTree.SelectedNode.Tag).Keyword;
                    ProcessStartInfo info = new ProcessStartInfo("explorer");
                    info.Arguments = DataSettings.Default.LibFolder + @"\Book\" + target.KeywordSubPath;
                    info.UseShellExecute = true;
                    Process.Start(info);
                }
            }
        }

        [DllImport("shell32.dll")]
        public static extern IntPtr ShellExecute(
            IntPtr hwnd,               // Handle to a parent window.
            [MarshalAs(UnmanagedType.LPTStr)]
            String lpOperation,   // Pointer to a null-terminated string, referred to in 
            // this case as a verb, that specifies the action to 
            // be performed.

            [MarshalAs(UnmanagedType.LPTStr)]
            String lpFile,        // Pointer to a null-terminated string that specifies 
            // the file or object on which to execute the specified 
            // verb.

            [MarshalAs(UnmanagedType.LPTStr)]
            String lpParameters,  // If the lpFile parameter specifies an executable file, 
            // lpParameters is a pointer to a null-terminated string 
            // that specifies the parameters to be passed to the 
            // application.

            [MarshalAs(UnmanagedType.LPTStr)]
            String lpDirectory,   // Pointer to a null-terminated string that specifies
            // the default directory. 

            Int32 nShowCmd);      // Flags that specify how an application is to be 
        // displayed when it is opened.

        // 设定颜色
        private void PresentColor(ref TreeNode tn, int rate)
        {
            switch (rate)
            {
                case 1:
                    tn.ForeColor = Color.LightGray;
                    break;
                case 2:
                    tn.ForeColor = Color.Gray;
                    break;
                case 3:
                    tn.ForeColor = Color.Black;
                    break;
                case 4:
                    tn.ForeColor = Color.DarkBlue;
                    break;
                case 5:
                    tn.ForeColor = Color.Blue;
                    break;
                default:
                    tn.ForeColor = Color.Red;
                    break;
            }
        }

        // 检查节点的继承性
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            return ContainsNode(node1, node2.Parent);
        }

        public event AfterSelectKeywordDelegate AfterSelectKeyword;

        private void CategoryTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is TreeNode)
            {
                // 启动关键字移动
                if (((TreeNode)e.Item).Tag is KeywordAndUser)
                {
                    //((TreeNode)e.Item).Parent.Collapse();
                    DoDragDrop(e.Item, DragDropEffects.Move);
                }
                else if ((((TreeNode)e.Item).Tag is Categories)) //启动类别移动
                {
                    //if (((TreeNode)e.Item).Parent != null)
                        //((TreeNode)e.Item).Parent.Collapse();
                    DoDragDrop(e.Item, DragDropEffects.Move);
                }
            }
        }

        private void CategoryTree_DragDrop(object sender, DragEventArgs e)
        {
            // 获取拖拽到的节点
            Point targetPoint = CategoryTree.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = CategoryTree.GetNodeAt(targetPoint);

            // 获取被拖拽得节点
            if (e.Data.GetDataPresent(typeof(List<Book>)))
            {
                List<Book> books = (List<Book>)e.Data.GetData(typeof(List<Book>));
                if (targetNode.Tag is KeywordAndUser)
                {
                    Keywords k = ((KeywordAndUser)targetNode.Tag).Keyword;
                    for (int i = 0; i < books.Count; i++)
                    {
                        JianLiLinq.Default.BookMarkKeyword(books[i], k);
                    }
                    db.SubmitChanges();

                    if (AfterSelectKeyword != null)
                        AfterSelectKeyword(k);
                }
            }
            else if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                // 不能在关键词之下建立类别
                if (targetNode.Tag is KeywordAndUser)
                    return;

                if (ContainsNode(draggedNode, targetNode))
                {
                    if(draggedNode.Parent!=null)
                        draggedNode.Parent.Expand();
                    return;
                }
                // 处理被移动的关键字
                    if (draggedNode.Tag is KeywordAndUser)
                    {
                        if (!draggedNode.Equals(targetNode))
                        {
                            Keywords k = ((KeywordAndUser)draggedNode.Tag).Keyword;
                            k.CategoryId = ((Categories)(targetNode.Tag)).CategoryID;

                            db.SubmitChanges();

                            draggedNode.Remove();

                            // 父节点完成初始化
                            if (targetNode.Nodes.Count == 1 && targetNode.Nodes[0].Text == "占位")
                                CreateSonNode(targetNode);
                            else
                                targetNode.Nodes.Add(draggedNode);
                        }
                    }
                    else if (draggedNode.Tag is Categories)
                    {
                        if (!draggedNode.Equals(targetNode))
                        {
                            Categories c = (Categories)(draggedNode.Tag);
                            c.CategoryParent = ((Categories)(targetNode.Tag)).CategoryID;

                            db.SubmitChanges();

                            draggedNode.Remove();

                            // 父节点完成初始化
                            if (targetNode.Nodes.Count == 1 && targetNode.Nodes[0].Text == "占位")
                                CreateSonNode(targetNode);
                            else
                                targetNode.Nodes.Add(draggedNode);
                        }
                    }
                    draggedNode.Parent.Expand();
            }
        }

        private void CategoryTree_DragEnter(object sender, DragEventArgs e)
        {
            CategoryTree.Focus();
            e.Effect = e.AllowedEffect;
        }

        private void CategoryTree_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
                CategoryTree.SelectedNode = CategoryTree.GetNodeAt(new Point(e.X, e.Y));
        }

        private bool isKeyword = false;
        public event SelectedTypeChangedDelegate SelectedTypeChanged;

        #region Keyword Rate

        void SetCurrentKeywordRate(TreeNode tn)
        {
            int rate = ((KeywordAndUser)tn.Tag).KeywordRate;

            if (rate == 5)
                this.keywordRate5.Checked = true;
            else
                this.keywordRate5.Checked = false;

            if (rate == 2)
                this.keywordRate2.Checked = true;
            else
                this.keywordRate2.Checked = false;

            if (rate == 3)
                this.keywordRate3.Checked = true;
            else
                this.keywordRate3.Checked = false;

            if (rate == 4)
                this.keywordRate4.Checked = true;
            else
                this.keywordRate4.Checked = false;

            if (rate == 1)
                this.keywordRate1.Checked = true;
            else
                this.keywordRate1.Checked = false;

            PresentColor(ref tn, rate);
        }


        private void keywordRate5_Click(object sender, EventArgs e)
        {
            if (this.CategoryTree.SelectedNode.Tag is KeywordAndUser)
            {
                (((KeywordAndUser)this.CategoryTree.SelectedNode.Tag).UserKeyword).KeywordRate = 5;
                TreeNode tn = this.CategoryTree.SelectedNode;
                PresentColor(ref tn, 5);
                db.SubmitChanges();
            }
        }

        private void keywordRate4_Click(object sender, EventArgs e)
        {
            if (this.CategoryTree.SelectedNode.Tag is KeywordAndUser)
            {
                (((KeywordAndUser)this.CategoryTree.SelectedNode.Tag).UserKeyword).KeywordRate = 4;
                TreeNode tn = this.CategoryTree.SelectedNode;
                PresentColor(ref tn, 4);
                db.SubmitChanges();
            }
        }

        private void keywordRate3_Click(object sender, EventArgs e)
        {
            if (this.CategoryTree.SelectedNode.Tag is KeywordAndUser)
            {
                (((KeywordAndUser)this.CategoryTree.SelectedNode.Tag).UserKeyword).KeywordRate = 3;
                TreeNode tn = this.CategoryTree.SelectedNode;
                PresentColor(ref tn, 3);
                db.SubmitChanges();
            }
        }

        private void keywordRate2_Click(object sender, EventArgs e)
        {

            if (this.CategoryTree.SelectedNode.Tag is KeywordAndUser)
            {
                (((KeywordAndUser)this.CategoryTree.SelectedNode.Tag).UserKeyword).KeywordRate = 2;
                TreeNode tn = this.CategoryTree.SelectedNode;
                PresentColor(ref tn, 2);
                db.SubmitChanges();
            }
        }

        private void keywordRate1_Click(object sender, EventArgs e)
        {
            if (this.CategoryTree.SelectedNode.Tag is KeywordAndUser)
            {
                (((KeywordAndUser)this.CategoryTree.SelectedNode.Tag).UserKeyword).KeywordRate = 1;
                TreeNode tn = this.CategoryTree.SelectedNode;
                PresentColor(ref tn, 1);
                db.SubmitChanges();
            }
        }

        #endregion

        private void DeleteKeywordMenuItem_Click(object sender, EventArgs e)
        {
            DelKeyword();
        }

        private void PropertyKeywordMenuItem_Click(object sender, EventArgs e)
        {
            EditKeyword();
        }

        private void NewCategoryMenuItem_Click(object sender, EventArgs e)
        {
            NewCategory();
        }

        private void NewKeywordMenuItem_Click(object sender, EventArgs e)
        {
            NewKeyword();
        }

        private void DeletCategoryeMenuItem_Click(object sender, EventArgs e)
        {
            DelCategory();
        }

        private void PropertyCategoryMenuItem_Click(object sender, EventArgs e)
        {
            EditCategory();
        }

        private void 指定文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveFileToKeywordFolder();
        }

        private void 打开文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenKeywordPath();
        }

        private void RefreshMenu_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void CategoryTree_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = CategoryTree.PointToClient(new Point(e.X, e.Y));
            CategoryTree.SelectedNode = CategoryTree.GetNodeAt(targetPoint);
        }

        bool leftcontrol = false;
        private void CategoryAndKeywordControl_Leave(object sender, EventArgs e)
        {
            leftcontrol = true;
        }
    }
}
