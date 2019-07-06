namespace JianLi3
{
    partial class BookLibControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookLibControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.categoryAndKeywordControl1 = new JianLi3.views.CategoryAndKeywordControl();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.userViewControl1 = new JianLi3.UserViewControl();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.pythonConsole1 = new LusongControl.PythonConsole();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.BookMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VersionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LikeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegularMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NoFeelingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BookEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelBookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateCoverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectCoverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.bookCommentView1 = new JianLi3Data.BookComments.BookCommentView();
            this.searchResultBookViewControl1 = new JianLi3.views.SearchResultBookViewControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.consoleOutputPanel1 = new LusongControl.ConsoleOutputPanel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.BookMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(847, 506);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.categoryAndKeywordControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer2.Size = new System.Drawing.Size(210, 506);
            this.splitContainer2.SplitterDistance = 223;
            this.splitContainer2.TabIndex = 0;
            // 
            // categoryAndKeywordControl1
            // 
            this.categoryAndKeywordControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryAndKeywordControl1.Location = new System.Drawing.Point(0, 0);
            this.categoryAndKeywordControl1.Name = "categoryAndKeywordControl1";
            this.categoryAndKeywordControl1.Size = new System.Drawing.Size(210, 223);
            this.categoryAndKeywordControl1.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.userViewControl1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(210, 279);
            this.splitContainer5.SplitterDistance = 134;
            this.splitContainer5.TabIndex = 0;
            // 
            // userViewControl1
            // 
            this.userViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userViewControl1.Location = new System.Drawing.Point(0, 0);
            this.userViewControl1.Name = "userViewControl1";
            this.userViewControl1.Size = new System.Drawing.Size(210, 134);
            this.userViewControl1.TabIndex = 1;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.pythonConsole1);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.consoleOutputPanel1);
            this.splitContainer6.Size = new System.Drawing.Size(210, 141);
            this.splitContainer6.SplitterDistance = 70;
            this.splitContainer6.TabIndex = 0;
            // 
            // pythonConsole1
            // 
            this.pythonConsole1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pythonConsole1.Location = new System.Drawing.Point(0, 0);
            this.pythonConsole1.Name = "pythonConsole1";
            this.pythonConsole1.Size = new System.Drawing.Size(210, 70);
            this.pythonConsole1.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.searchResultBookViewControl1);
            this.splitContainer3.Size = new System.Drawing.Size(633, 506);
            this.splitContainer3.SplitterDistance = 383;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.elementHost1);
            this.splitContainer4.Size = new System.Drawing.Size(633, 383);
            this.splitContainer4.SplitterDistance = 462;
            this.splitContainer4.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.BookMenu;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(462, 383);
            this.listView1.TabIndex = 2;
            this.listView1.TileSize = new System.Drawing.Size(1, 1);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            // 
            // BookMenu
            // 
            this.BookMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionsMenuItem,
            this.RatesMenuItem,
            this.CommentMenuItem,
            this.toolStripSeparator1,
            this.BookEditMenuItem,
            this.DelBookMenuItem,
            this.UpdateCoverMenuItem,
            this.SelectCoverMenuItem});
            this.BookMenu.Name = "BookMenu";
            this.BookMenu.Size = new System.Drawing.Size(131, 164);
            // 
            // VersionsMenuItem
            // 
            this.VersionsMenuItem.Name = "VersionsMenuItem";
            this.VersionsMenuItem.Size = new System.Drawing.Size(130, 22);
            this.VersionsMenuItem.Text = "版本";
            // 
            // RatesMenuItem
            // 
            this.RatesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoveMenuItem,
            this.LikeMenuItem,
            this.RegularMenuItem,
            this.NoFeelingMenuItem,
            this.HateMenuItem});
            this.RatesMenuItem.Name = "RatesMenuItem";
            this.RatesMenuItem.Size = new System.Drawing.Size(130, 22);
            this.RatesMenuItem.Text = "评分";
            // 
            // LoveMenuItem
            // 
            this.LoveMenuItem.Name = "LoveMenuItem";
            this.LoveMenuItem.Size = new System.Drawing.Size(94, 22);
            this.LoveMenuItem.Text = "有爱";
            this.LoveMenuItem.Click += new System.EventHandler(this.非常喜欢ToolStripMenuItem_Click);
            // 
            // LikeMenuItem
            // 
            this.LikeMenuItem.Name = "LikeMenuItem";
            this.LikeMenuItem.Size = new System.Drawing.Size(94, 22);
            this.LikeMenuItem.Text = "喜欢";
            this.LikeMenuItem.Click += new System.EventHandler(this.喜欢ToolStripMenuItem_Click);
            // 
            // RegularMenuItem
            // 
            this.RegularMenuItem.Name = "RegularMenuItem";
            this.RegularMenuItem.Size = new System.Drawing.Size(94, 22);
            this.RegularMenuItem.Text = "正规";
            this.RegularMenuItem.Click += new System.EventHandler(this.正规ToolStripMenuItem_Click);
            // 
            // NoFeelingMenuItem
            // 
            this.NoFeelingMenuItem.Name = "NoFeelingMenuItem";
            this.NoFeelingMenuItem.Size = new System.Drawing.Size(94, 22);
            this.NoFeelingMenuItem.Text = "无视";
            this.NoFeelingMenuItem.Click += new System.EventHandler(this.没有感觉ToolStripMenuItem_Click);
            // 
            // HateMenuItem
            // 
            this.HateMenuItem.Name = "HateMenuItem";
            this.HateMenuItem.Size = new System.Drawing.Size(94, 22);
            this.HateMenuItem.Text = "讨厌";
            this.HateMenuItem.Click += new System.EventHandler(this.不喜欢ToolStripMenuItem_Click);
            // 
            // CommentMenuItem
            // 
            this.CommentMenuItem.Name = "CommentMenuItem";
            this.CommentMenuItem.Size = new System.Drawing.Size(130, 22);
            this.CommentMenuItem.Text = "我有话说";
            this.CommentMenuItem.Click += new System.EventHandler(this.CommentMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // BookEditMenuItem
            // 
            this.BookEditMenuItem.Name = "BookEditMenuItem";
            this.BookEditMenuItem.Size = new System.Drawing.Size(130, 22);
            this.BookEditMenuItem.Text = "编辑";
            this.BookEditMenuItem.Click += new System.EventHandler(this.BookEditMenuItem_Click);
            // 
            // DelBookMenuItem
            // 
            this.DelBookMenuItem.Name = "DelBookMenuItem";
            this.DelBookMenuItem.Size = new System.Drawing.Size(130, 22);
            this.DelBookMenuItem.Text = "解除关键字";
            this.DelBookMenuItem.Click += new System.EventHandler(this.DelBookMenuItem_Click);
            // 
            // UpdateCoverMenuItem
            // 
            this.UpdateCoverMenuItem.Name = "UpdateCoverMenuItem";
            this.UpdateCoverMenuItem.Size = new System.Drawing.Size(130, 22);
            this.UpdateCoverMenuItem.Text = "更新封面";
            this.UpdateCoverMenuItem.Click += new System.EventHandler(this.更新封面ToolStripMenuItem_Click);
            // 
            // SelectCoverMenuItem
            // 
            this.SelectCoverMenuItem.Name = "SelectCoverMenuItem";
            this.SelectCoverMenuItem.Size = new System.Drawing.Size(130, 22);
            this.SelectCoverMenuItem.Text = "选择封面";
            this.SelectCoverMenuItem.Click += new System.EventHandler(this.SelectCoverMenuItem_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(167, 383);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.bookCommentView1;
            // 
            // searchResultBookViewControl1
            // 
            this.searchResultBookViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchResultBookViewControl1.Location = new System.Drawing.Point(0, 0);
            this.searchResultBookViewControl1.Name = "searchResultBookViewControl1";
            this.searchResultBookViewControl1.Size = new System.Drawing.Size(633, 119);
            this.searchResultBookViewControl1.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "book12.jpg");
            // 
            // consoleOutputPanel1
            // 
            this.consoleOutputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleOutputPanel1.Location = new System.Drawing.Point(0, 0);
            this.consoleOutputPanel1.Name = "consoleOutputPanel1";
            this.consoleOutputPanel1.Size = new System.Drawing.Size(210, 67);
            this.consoleOutputPanel1.TabIndex = 0;
            // 
            // BookLibControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BookLibControl";
            this.Size = new System.Drawing.Size(847, 506);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.BookMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip BookMenu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem SelectCoverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateCoverMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripMenuItem VersionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RatesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LikeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegularMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NoFeelingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HateMenuItem;
        private JianLi3.views.CategoryAndKeywordControl categoryAndKeywordControl1;
        private System.Windows.Forms.ToolStripMenuItem DelBookMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BookEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CommentMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private JianLi3Data.BookComments.BookCommentView bookCommentView1;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private UserViewControl userViewControl1;
        private JianLi3.views.SearchResultBookViewControl searchResultBookViewControl1;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private LusongControl.PythonConsole pythonConsole1;
        private LusongControl.ConsoleOutputPanel consoleOutputPanel1;
    }
}
