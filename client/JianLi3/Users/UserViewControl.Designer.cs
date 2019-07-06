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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("非常喜欢");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("喜欢");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("正规");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("没有感觉");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("不喜欢");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("喜欢程度", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("孤立的书");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("新添加的书");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("有新书");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("未定类型的书");
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
            treeNode4.ForeColor = System.Drawing.Color.Blue;
            treeNode4.Name = "Node2";
            treeNode4.Text = "非常喜欢";
            treeNode5.ForeColor = System.Drawing.Color.DarkBlue;
            treeNode5.Name = "Node3";
            treeNode5.Text = "喜欢";
            treeNode6.Name = "Node4";
            treeNode6.Text = "正规";
            treeNode7.ForeColor = System.Drawing.Color.Gray;
            treeNode7.Name = "Node5";
            treeNode7.Text = "没有感觉";
            treeNode8.ForeColor = System.Drawing.Color.LightGray;
            treeNode8.Name = "Node6";
            treeNode8.Text = "不喜欢";
            treeNode9.Name = "Node1";
            treeNode9.Text = "喜欢程度";
            treeNode10.Name = "IsolateBooks";
            treeNode10.Text = "孤立的书";
            treeNode11.Name = "NewBookNode";
            treeNode11.Text = "新添加的书";
            treeNode12.Name = "NewBookSinceLastLoginNode";
            treeNode12.Text = "有新书";
            treeNode13.Name = "Node0";
            treeNode13.Text = "未定类型的书";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
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
            this.Load += new System.EventHandler(this.UserViewControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}
