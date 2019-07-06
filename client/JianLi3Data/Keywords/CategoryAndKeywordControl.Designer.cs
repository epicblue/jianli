namespace JianLi3.views
{
    partial class CategoryAndKeywordControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem DeletCategoryeMenuItem;
            System.Windows.Forms.ToolStripMenuItem PropertyKeywordMenuItem;
            this.CategoryTree = new System.Windows.Forms.TreeView();
            this.CategoryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewCategoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewKeywordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PropertyCategoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.KeywordMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteKeywordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关注程度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordRate5 = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordRate4 = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordRate3 = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordRate2 = new System.Windows.Forms.ToolStripMenuItem();
            this.keywordRate1 = new System.Windows.Forms.ToolStripMenuItem();
            this.指定文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DeletCategoryeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            PropertyKeywordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CategoryMenu.SuspendLayout();
            this.KeywordMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeletCategoryeMenuItem
            // 
            DeletCategoryeMenuItem.Name = "DeletCategoryeMenuItem";
            DeletCategoryeMenuItem.Size = new System.Drawing.Size(130, 22);
            DeletCategoryeMenuItem.Text = "删除";
            DeletCategoryeMenuItem.Click += new System.EventHandler(this.DeletCategoryeMenuItem_Click);
            // 
            // PropertyKeywordMenuItem
            // 
            PropertyKeywordMenuItem.Name = "PropertyKeywordMenuItem";
            PropertyKeywordMenuItem.Size = new System.Drawing.Size(130, 22);
            PropertyKeywordMenuItem.Text = "编辑";
            PropertyKeywordMenuItem.Click += new System.EventHandler(this.PropertyKeywordMenuItem_Click);
            // 
            // CategoryTree
            // 
            this.CategoryTree.AllowDrop = true;
            this.CategoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryTree.Location = new System.Drawing.Point(0, 0);
            this.CategoryTree.Name = "CategoryTree";
            this.CategoryTree.Size = new System.Drawing.Size(323, 503);
            this.CategoryTree.TabIndex = 0;
            this.CategoryTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.CategoryTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.CategoryTree_DragDrop);
            this.CategoryTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.CategoryTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CategoryTree_MouseDown);
            this.CategoryTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.CategoryTree_DragEnter);
            this.CategoryTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.CategoryTree_ItemDrag);
            this.CategoryTree.DragOver += new System.Windows.Forms.DragEventHandler(this.CategoryTree_DragOver);
            // 
            // CategoryMenu
            // 
            this.CategoryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewCategoryMenuItem,
            this.NewKeywordMenuItem,
            this.toolStripSeparator1,
            DeletCategoryeMenuItem,
            this.PropertyCategoryMenuItem,
            this.toolStripSeparator2,
            this.RefreshMenu});
            this.CategoryMenu.Name = "CategoryMenu";
            this.CategoryMenu.Size = new System.Drawing.Size(131, 126);
            // 
            // NewCategoryMenuItem
            // 
            this.NewCategoryMenuItem.Name = "NewCategoryMenuItem";
            this.NewCategoryMenuItem.Size = new System.Drawing.Size(130, 22);
            this.NewCategoryMenuItem.Text = "新建类别";
            this.NewCategoryMenuItem.Click += new System.EventHandler(this.NewCategoryMenuItem_Click);
            // 
            // NewKeywordMenuItem
            // 
            this.NewKeywordMenuItem.Name = "NewKeywordMenuItem";
            this.NewKeywordMenuItem.Size = new System.Drawing.Size(130, 22);
            this.NewKeywordMenuItem.Text = "新建关键字";
            this.NewKeywordMenuItem.Click += new System.EventHandler(this.NewKeywordMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // PropertyCategoryMenuItem
            // 
            this.PropertyCategoryMenuItem.Name = "PropertyCategoryMenuItem";
            this.PropertyCategoryMenuItem.Size = new System.Drawing.Size(130, 22);
            this.PropertyCategoryMenuItem.Text = "编辑";
            this.PropertyCategoryMenuItem.Click += new System.EventHandler(this.PropertyCategoryMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(127, 6);
            // 
            // RefreshMenu
            // 
            this.RefreshMenu.Name = "RefreshMenu";
            this.RefreshMenu.Size = new System.Drawing.Size(130, 22);
            this.RefreshMenu.Text = "更新";
            this.RefreshMenu.Click += new System.EventHandler(this.RefreshMenu_Click);
            // 
            // KeywordMenu
            // 
            this.KeywordMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteKeywordMenuItem,
            PropertyKeywordMenuItem,
            this.关注程度ToolStripMenuItem,
            this.指定文件夹ToolStripMenuItem,
            this.打开文件夹ToolStripMenuItem});
            this.KeywordMenu.Name = "KeywordMenu";
            this.KeywordMenu.Size = new System.Drawing.Size(153, 136);
            // 
            // DeleteKeywordMenuItem
            // 
            this.DeleteKeywordMenuItem.Name = "DeleteKeywordMenuItem";
            this.DeleteKeywordMenuItem.Size = new System.Drawing.Size(130, 22);
            this.DeleteKeywordMenuItem.Text = "删除";
            this.DeleteKeywordMenuItem.Click += new System.EventHandler(this.DeleteKeywordMenuItem_Click);
            // 
            // 关注程度ToolStripMenuItem
            // 
            this.关注程度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keywordRate5,
            this.keywordRate4,
            this.keywordRate3,
            this.keywordRate2,
            this.keywordRate1});
            this.关注程度ToolStripMenuItem.Name = "关注程度ToolStripMenuItem";
            this.关注程度ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.关注程度ToolStripMenuItem.Text = "关注程度";
            // 
            // keywordRate5
            // 
            this.keywordRate5.Name = "keywordRate5";
            this.keywordRate5.Size = new System.Drawing.Size(94, 22);
            this.keywordRate5.Text = "当前";
            this.keywordRate5.Click += new System.EventHandler(this.keywordRate5_Click);
            // 
            // keywordRate4
            // 
            this.keywordRate4.Name = "keywordRate4";
            this.keywordRate4.Size = new System.Drawing.Size(94, 22);
            this.keywordRate4.Text = "长期";
            this.keywordRate4.Click += new System.EventHandler(this.keywordRate4_Click);
            // 
            // keywordRate3
            // 
            this.keywordRate3.Name = "keywordRate3";
            this.keywordRate3.Size = new System.Drawing.Size(94, 22);
            this.keywordRate3.Text = "关注";
            this.keywordRate3.Click += new System.EventHandler(this.keywordRate3_Click);
            // 
            // keywordRate2
            // 
            this.keywordRate2.Name = "keywordRate2";
            this.keywordRate2.Size = new System.Drawing.Size(94, 22);
            this.keywordRate2.Text = "偶尔";
            this.keywordRate2.Click += new System.EventHandler(this.keywordRate2_Click);
            // 
            // keywordRate1
            // 
            this.keywordRate1.Name = "keywordRate1";
            this.keywordRate1.Size = new System.Drawing.Size(94, 22);
            this.keywordRate1.Text = "无视";
            this.keywordRate1.Click += new System.EventHandler(this.keywordRate1_Click);
            // 
            // 指定文件夹ToolStripMenuItem
            // 
            this.指定文件夹ToolStripMenuItem.Name = "指定文件夹ToolStripMenuItem";
            this.指定文件夹ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.指定文件夹ToolStripMenuItem.Text = "放入文件夹";
            this.指定文件夹ToolStripMenuItem.Click += new System.EventHandler(this.指定文件夹ToolStripMenuItem_Click);
            // 
            // 打开文件夹ToolStripMenuItem
            // 
            this.打开文件夹ToolStripMenuItem.Name = "打开文件夹ToolStripMenuItem";
            this.打开文件夹ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开文件夹ToolStripMenuItem.Text = "打开文件夹";
            this.打开文件夹ToolStripMenuItem.Visible = false;
            this.打开文件夹ToolStripMenuItem.Click += new System.EventHandler(this.打开文件夹ToolStripMenuItem_Click);
            // 
            // CategoryAndKeywordControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CategoryTree);
            this.Name = "CategoryAndKeywordControl";
            this.Size = new System.Drawing.Size(323, 503);
            this.Leave += new System.EventHandler(this.CategoryAndKeywordControl_Leave);
            this.CategoryMenu.ResumeLayout(false);
            this.KeywordMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView CategoryTree;
        private System.Windows.Forms.ContextMenuStrip CategoryMenu;
        private System.Windows.Forms.ToolStripMenuItem NewCategoryMenuItem;
        public System.Windows.Forms.ToolStripMenuItem NewKeywordMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem PropertyCategoryMenuItem;
        private System.Windows.Forms.ContextMenuStrip KeywordMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteKeywordMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关注程度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keywordRate5;
        private System.Windows.Forms.ToolStripMenuItem keywordRate4;
        private System.Windows.Forms.ToolStripMenuItem keywordRate3;
        private System.Windows.Forms.ToolStripMenuItem keywordRate2;
        private System.Windows.Forms.ToolStripMenuItem 指定文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keywordRate1;
        private System.Windows.Forms.ToolStripMenuItem 打开文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem RefreshMenu;
    }
}
