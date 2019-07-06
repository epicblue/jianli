namespace JianLi3.views
{
    partial class SearchResultBookViewControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchResultBookViewControl));
            this.listView1 = new System.Windows.Forms.ListView();
            this.BookMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.评分ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LikeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noFeelingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HateMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.notRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.封面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectBookCoverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateBookCoverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClipboardCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsBookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsPaperMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsDocMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsPostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsMagzineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsCheetSheetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.IsUncheckMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.DelBookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BookMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.BookMenu;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(458, 416);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            // 
            // BookMenu
            // 
            this.BookMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.评分ToolStripMenuItem,
            this.封面ToolStripMenuItem,
            this.类别ToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.版本ToolStripMenuItem,
            this.toolStripSeparator2,
            this.DelBookMenuItem});
            this.BookMenu.Name = "BookMenu";
            this.BookMenu.Size = new System.Drawing.Size(153, 186);
            // 
            // 评分ToolStripMenuItem
            // 
            this.评分ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoveMenuItem,
            this.LikeMenuItem,
            this.regularToolStripMenuItem,
            this.noFeelingToolStripMenuItem,
            this.HateMenuItem1,
            this.toolStripSeparator3,
            this.notRateToolStripMenuItem});
            this.评分ToolStripMenuItem.Name = "评分ToolStripMenuItem";
            this.评分ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.评分ToolStripMenuItem.Text = "评分";
            // 
            // LoveMenuItem
            // 
            this.LoveMenuItem.Name = "LoveMenuItem";
            this.LoveMenuItem.Size = new System.Drawing.Size(160, 22);
            this.LoveMenuItem.Text = "有爱 ★★★★★";
            this.LoveMenuItem.Click += new System.EventHandler(this.LoveMenuItem_Click);
            // 
            // LikeMenuItem
            // 
            this.LikeMenuItem.Name = "LikeMenuItem";
            this.LikeMenuItem.Size = new System.Drawing.Size(160, 22);
            this.LikeMenuItem.Text = "喜欢 ★★★★";
            this.LikeMenuItem.Click += new System.EventHandler(this.LikeMenuItem_Click);
            // 
            // regularToolStripMenuItem
            // 
            this.regularToolStripMenuItem.Name = "regularToolStripMenuItem";
            this.regularToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.regularToolStripMenuItem.Text = "正规 ★★★";
            this.regularToolStripMenuItem.Click += new System.EventHandler(this.regularToolStripMenuItem_Click);
            // 
            // noFeelingToolStripMenuItem
            // 
            this.noFeelingToolStripMenuItem.Name = "noFeelingToolStripMenuItem";
            this.noFeelingToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.noFeelingToolStripMenuItem.Text = "无视 ★★";
            this.noFeelingToolStripMenuItem.Click += new System.EventHandler(this.noFeelingToolStripMenuItem_Click);
            // 
            // HateMenuItem1
            // 
            this.HateMenuItem1.Name = "HateMenuItem1";
            this.HateMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.HateMenuItem1.Text = "讨厌 ★";
            this.HateMenuItem1.Click += new System.EventHandler(this.HateMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // notRateToolStripMenuItem
            // 
            this.notRateToolStripMenuItem.Name = "notRateToolStripMenuItem";
            this.notRateToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.notRateToolStripMenuItem.Text = "未定 ☆";
            this.notRateToolStripMenuItem.Click += new System.EventHandler(this.notRateToolStripMenuItem_Click);
            // 
            // 封面ToolStripMenuItem
            // 
            this.封面ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectBookCoverMenuItem,
            this.UpdateBookCoverMenuItem,
            this.ClipboardCopyMenuItem});
            this.封面ToolStripMenuItem.Name = "封面ToolStripMenuItem";
            this.封面ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.封面ToolStripMenuItem.Text = "封面";
            // 
            // SelectBookCoverMenuItem
            // 
            this.SelectBookCoverMenuItem.Name = "SelectBookCoverMenuItem";
            this.SelectBookCoverMenuItem.Size = new System.Drawing.Size(94, 22);
            this.SelectBookCoverMenuItem.Text = "选取";
            this.SelectBookCoverMenuItem.Click += new System.EventHandler(this.SelectBookCoverMenuItem_Click);
            // 
            // UpdateBookCoverMenuItem
            // 
            this.UpdateBookCoverMenuItem.Name = "UpdateBookCoverMenuItem";
            this.UpdateBookCoverMenuItem.Size = new System.Drawing.Size(94, 22);
            this.UpdateBookCoverMenuItem.Text = "更新";
            this.UpdateBookCoverMenuItem.Click += new System.EventHandler(this.UpdateBookCoverMenuItem_Click);
            // 
            // ClipboardCopyMenuItem
            // 
            this.ClipboardCopyMenuItem.Name = "ClipboardCopyMenuItem";
            this.ClipboardCopyMenuItem.Size = new System.Drawing.Size(94, 22);
            this.ClipboardCopyMenuItem.Text = "粘贴";
            this.ClipboardCopyMenuItem.Click += new System.EventHandler(this.ClipboardCopyMenuItem_Click);
            // 
            // 类别ToolStripMenuItem
            // 
            this.类别ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IsBookMenuItem,
            this.IsPaperMenuItem,
            this.IsDocMenuItem,
            this.IsPostMenuItem,
            this.IsMagzineMenuItem,
            this.IsCheetSheetMenuItem,
            this.toolStripSeparator1,
            this.IsUncheckMenuItem});
            this.类别ToolStripMenuItem.Name = "类别ToolStripMenuItem";
            this.类别ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.类别ToolStripMenuItem.Text = "类别";
            // 
            // IsBookMenuItem
            // 
            this.IsBookMenuItem.Name = "IsBookMenuItem";
            this.IsBookMenuItem.Size = new System.Drawing.Size(136, 22);
            this.IsBookMenuItem.Text = "书籍";
            this.IsBookMenuItem.Click += new System.EventHandler(this.IsBookMenuItem_Click);
            // 
            // IsPaperMenuItem
            // 
            this.IsPaperMenuItem.Name = "IsPaperMenuItem";
            this.IsPaperMenuItem.Size = new System.Drawing.Size(136, 22);
            this.IsPaperMenuItem.Text = "论文";
            this.IsPaperMenuItem.Click += new System.EventHandler(this.IsPaperMenuItem_Click);
            // 
            // IsDocMenuItem
            // 
            this.IsDocMenuItem.Name = "IsDocMenuItem";
            this.IsDocMenuItem.Size = new System.Drawing.Size(136, 22);
            this.IsDocMenuItem.Text = "未出版文档";
            this.IsDocMenuItem.Click += new System.EventHandler(this.IsDocMenuItem_Click);
            // 
            // IsPostMenuItem
            // 
            this.IsPostMenuItem.Name = "IsPostMenuItem";
            this.IsPostMenuItem.Size = new System.Drawing.Size(136, 22);
            this.IsPostMenuItem.Text = "海报";
            this.IsPostMenuItem.Click += new System.EventHandler(this.IsPostMenuItem_Click);
            // 
            // IsMagzineMenuItem
            // 
            this.IsMagzineMenuItem.Name = "IsMagzineMenuItem";
            this.IsMagzineMenuItem.Size = new System.Drawing.Size(136, 22);
            this.IsMagzineMenuItem.Text = "杂志";
            this.IsMagzineMenuItem.Click += new System.EventHandler(this.IsMagzineMenuItem_Click);
            // 
            // IsCheetSheetMenuItem
            // 
            this.IsCheetSheetMenuItem.Name = "IsCheetSheetMenuItem";
            this.IsCheetSheetMenuItem.Size = new System.Drawing.Size(136, 22);
            this.IsCheetSheetMenuItem.Text = "Cheet Sheet";
            this.IsCheetSheetMenuItem.Click += new System.EventHandler(this.IsCheetSheetMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // IsUncheckMenuItem
            // 
            this.IsUncheckMenuItem.Name = "IsUncheckMenuItem";
            this.IsUncheckMenuItem.Size = new System.Drawing.Size(136, 22);
            this.IsUncheckMenuItem.Text = "未定";
            this.IsUncheckMenuItem.Click += new System.EventHandler(this.IsUncheckMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "文件复制";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // 版本ToolStripMenuItem
            // 
            this.版本ToolStripMenuItem.Name = "版本ToolStripMenuItem";
            this.版本ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.版本ToolStripMenuItem.Text = "版本";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // DelBookMenuItem
            // 
            this.DelBookMenuItem.Name = "DelBookMenuItem";
            this.DelBookMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DelBookMenuItem.Text = "删除";
            this.DelBookMenuItem.Click += new System.EventHandler(this.DelBookMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "book12.jpg");
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // SearchResultBookViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "SearchResultBookViewControl";
            this.Size = new System.Drawing.Size(458, 416);
            this.BookMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip BookMenu;
        private System.Windows.Forms.ToolStripMenuItem DelBookMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 评分ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 封面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectBookCoverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateBookCoverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 类别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsBookMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsPaperMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsDocMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsUncheckMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsPostMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IsMagzineMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem IsCheetSheetMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ClipboardCopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LikeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HateMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem notRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noFeelingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
    }
}
