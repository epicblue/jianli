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
            this.DelBookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.listView1.Size = new System.Drawing.Size(458, 416);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            // 
            // BookMenu
            // 
            this.BookMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelBookMenuItem});
            this.BookMenu.Name = "BookMenu";
            this.BookMenu.Size = new System.Drawing.Size(95, 26);
            // 
            // DelBookMenuItem
            // 
            this.DelBookMenuItem.Name = "DelBookMenuItem";
            this.DelBookMenuItem.Size = new System.Drawing.Size(94, 22);
            this.DelBookMenuItem.Text = "删除";
            this.DelBookMenuItem.Visible = false;
            this.DelBookMenuItem.Click += new System.EventHandler(this.DelBookMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "book12.jpg");
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
    }
}
