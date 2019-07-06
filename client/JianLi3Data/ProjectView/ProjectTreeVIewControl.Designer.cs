namespace JianLi3Data.ProjectView
{
    partial class ProjectTreeVIewControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProjectTreeView = new System.Windows.Forms.TreeView();
            this.ModuleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.子任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.子模块ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.子任务ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.优先级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectIterationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.完成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModuleMenu.SuspendLayout();
            this.TaskMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProjectTreeView
            // 
            this.ProjectTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectTreeView.Location = new System.Drawing.Point(0, 0);
            this.ProjectTreeView.Name = "ProjectTreeView";
            this.ProjectTreeView.Size = new System.Drawing.Size(188, 434);
            this.ProjectTreeView.TabIndex = 0;
            this.ProjectTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.ProjectTreeView_BeforeExpand);
            this.ProjectTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProjectTreeView_MouseDown);
            // 
            // ModuleMenu
            // 
            this.ModuleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.子任务ToolStripMenuItem,
            this.子模块ToolStripMenuItem});
            this.ModuleMenu.Name = "ModuleMenu";
            this.ModuleMenu.Size = new System.Drawing.Size(111, 48);
            // 
            // 子任务ToolStripMenuItem
            // 
            this.子任务ToolStripMenuItem.Name = "子任务ToolStripMenuItem";
            this.子任务ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.子任务ToolStripMenuItem.Text = "子任务";
            this.子任务ToolStripMenuItem.Click += new System.EventHandler(this.子任务ToolStripMenuItem_Click);
            // 
            // 子模块ToolStripMenuItem
            // 
            this.子模块ToolStripMenuItem.Name = "子模块ToolStripMenuItem";
            this.子模块ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.子模块ToolStripMenuItem.Text = "子模块";
            this.子模块ToolStripMenuItem.Click += new System.EventHandler(this.子模块ToolStripMenuItem_Click);
            // 
            // TaskMenu
            // 
            this.TaskMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.子任务ToolStripMenuItem1,
            this.toolStripSeparator1,
            this.优先级ToolStripMenuItem,
            this.ProjectIterationMenu,
            this.完成ToolStripMenuItem});
            this.TaskMenu.Name = "TaskMenu";
            this.TaskMenu.Size = new System.Drawing.Size(153, 120);
            // 
            // 子任务ToolStripMenuItem1
            // 
            this.子任务ToolStripMenuItem1.Name = "子任务ToolStripMenuItem1";
            this.子任务ToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.子任务ToolStripMenuItem1.Text = "子任务";
            // 
            // 优先级ToolStripMenuItem
            // 
            this.优先级ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.优先级ToolStripMenuItem.Name = "优先级ToolStripMenuItem";
            this.优先级ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.优先级ToolStripMenuItem.Text = "优先级";
            // 
            // ProjectIterationMenu
            // 
            this.ProjectIterationMenu.Name = "ProjectIterationMenu";
            this.ProjectIterationMenu.Size = new System.Drawing.Size(110, 22);
            this.ProjectIterationMenu.Text = "迭代";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "2";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "3";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "4";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "5";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem7.Text = "6";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem8.Text = "7";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem9.Text = "8";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem10.Text = "9";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem11.Text = "10";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 完成ToolStripMenuItem
            // 
            this.完成ToolStripMenuItem.Name = "完成ToolStripMenuItem";
            this.完成ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.完成ToolStripMenuItem.Text = "完成";
            // 
            // ProjectTreeVIewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProjectTreeView);
            this.Name = "ProjectTreeVIewControl";
            this.Size = new System.Drawing.Size(188, 434);
            this.ModuleMenu.ResumeLayout(false);
            this.TaskMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ProjectTreeView;
        private System.Windows.Forms.ContextMenuStrip ModuleMenu;
        private System.Windows.Forms.ToolStripMenuItem 子任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 子模块ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TaskMenu;
        private System.Windows.Forms.ToolStripMenuItem 子任务ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 优先级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProjectIterationMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 完成ToolStripMenuItem;
    }
}
