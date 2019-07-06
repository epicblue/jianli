namespace JianLi3
{
    partial class UserViewControl
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("最近看的书");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("看的时间最长的书");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("看的次数最多的书");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("当前");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("长期");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("关注");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("偶尔");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("不关注");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("喜欢程度", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("牛顿");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("作者", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Excel");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("关键词", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("人民出版社");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("出版社", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "最近看的书";
            treeNode2.Name = "NodeLongRead";
            treeNode2.Text = "看的时间最长的书";
            treeNode3.Name = "节点0";
            treeNode3.Text = "看的次数最多的书";
            treeNode4.Name = "Node2";
            treeNode4.Text = "当前";
            treeNode5.Name = "Node3";
            treeNode5.Text = "长期";
            treeNode6.Name = "Node4";
            treeNode6.Text = "关注";
            treeNode7.Name = "Node5";
            treeNode7.Text = "偶尔";
            treeNode8.Name = "Node6";
            treeNode8.Text = "不关注";
            treeNode9.Name = "Node1";
            treeNode9.Text = "喜欢程度";
            treeNode10.Name = "Node12";
            treeNode10.Text = "牛顿";
            treeNode11.Name = "Node7";
            treeNode11.Text = "作者";
            treeNode12.Name = "Node9";
            treeNode12.Text = "Excel";
            treeNode13.Name = "Node8";
            treeNode13.Text = "关键词";
            treeNode14.Name = "Node1";
            treeNode14.Text = "人民出版社";
            treeNode15.Name = "Node0";
            treeNode15.Text = "出版社";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode9,
            treeNode11,
            treeNode13,
            treeNode15});
            this.treeView1.Size = new System.Drawing.Size(220, 462);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // UserViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Name = "UserViewControl";
            this.Size = new System.Drawing.Size(220, 462);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}
