using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3Data.ProjectView
{
    public partial class ProjectTreeVIewControl : UserControl
    {
        const string placeholder = "占位";
        private Project project;

        public ProjectTreeVIewControl()
        {
            InitializeComponent();
        }

        public Project Project
        {
            set
            {
                project = value;
                if (value == null)
                    return;
                LoadProjectRootModule(project);
                //重新设定菜单
                ProjectIterationMenu.DropDownItems.Clear();
                foreach(ProjectIteration pi in project.ProjectIterations)
                {
                    ToolStripMenuItem menu = new ToolStripMenuItem();
                    menu.Text = pi.Name;
                    menu.Click += new EventHandler(menu_Click);
                    ProjectIterationMenu.DropDownItems.Add(menu);
                    
                }
            }
            get
            {
                return project;
            }
        }

        // 重新设定周期
        void menu_Click(object sender, EventArgs e)
        {
            if (!(ProjectTreeView.SelectedNode.Tag is Task))
                throw new Exception("期望对项目设定周期。");

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Task t = (Task)ProjectTreeView.SelectedNode.Tag;

            ProjectIteration pi = DataCenter.GetProjectIteration(project, item.Text);

            DataCenter.SetTaskIteration(ref t, pi);
        }

        private void LoadProjectRootModule(Project project)
        {
            TreeNode tn = new TreeNode();
            tn.Text = project.ProjectModule.Name;
            tn.Tag = project.ProjectModule;
            tn.ForeColor = Color.Blue;
            tn.Nodes.Add(placeholder);
            ProjectTreeView.Nodes.Add(tn);
        }
        private void InitNode(ref TreeNode node)
        {
            if (node.Tag is ProjectModule && node.Nodes.Count == 1 && node.Nodes[0].Text == placeholder)
            {
                InitModuleNode(ref node);
            }
            else if (node.Tag is Task && node.Nodes.Count == 1 && node.Nodes[0].Text == placeholder)
            {
                InitTaskNode(ref node);
            }
        }
        private void InitModuleNode(ref TreeNode tn)
        {
            tn.Nodes.Clear();

            ProjectModule pm = (ProjectModule)tn.Tag;

            var ms = from m in JianLiLinq.Default.DB.ProjectModules
                     where m.Parent == pm.ID
                     select m;

            foreach (ProjectModule module in ms)
            {
                TreeNode stn = new TreeNode();
                stn.Text = module.Name;
                stn.Tag = module;
                stn.Nodes.Add(placeholder);
                stn.ForeColor = Color.Blue;
                tn.Nodes.Add(stn);
            }
            var ts = from t in JianLiLinq.Default.DB.Tasks
                     where t.Parent == pm.ID
                     select t;

            foreach (Task task in ts)
            {
                TreeNode stn = new TreeNode();
                stn.Text = task.Title;
                stn.Tag = task;
                stn.Nodes.Add(placeholder);
                tn.Nodes.Add(stn);
            }
        }
        private void InitTaskNode(ref TreeNode tn)
        {
            tn.Nodes.Clear();

            Task parenttask = (Task)tn.Tag;

            var ts = from t in JianLiLinq.Default.DB.Tasks
                     where t.Parent == parenttask.ID
                     select t;

            foreach (Task task in ts)
            {
                TreeNode stn = new TreeNode();
                stn.Text = task.Title;
                stn.Tag = task;
                stn.Nodes.Add(placeholder);
                tn.Nodes.Add(stn);
            }
        }


        private void ProjectTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode parentnode = e.Node;
            InitNode(ref parentnode);
        }

        private void ProjectTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = this.ProjectTreeView.HitTest(e.X, e.Y);
            if (!(info.Node is TreeNode))
                return;

            TreeNode tn =info.Node;
            InitNode(ref tn);

            if (e.Button != MouseButtons.Right)
                return;
            // 如果是右键必须重新配置菜单
            ProjectTreeView.SelectedNode = info.Node;

            if (tn.Tag is ProjectModule)
                ProjectTreeView.ContextMenuStrip = ModuleMenu;
            else if (tn.Tag is Task)
            {
                Task t = (Task)tn.Tag;
                ProjectTreeView.ContextMenuStrip = TaskMenu;

                // update iteration info
                foreach (ToolStripMenuItem item in ProjectIterationMenu.DropDownItems)
                    if (item.Text == t.ProjectIteration.Name)
                        item.Checked = true;
                    else
                        item.Checked = false;
            }
        }

        private void 子任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = ProjectTreeView.SelectedNode;
            if (!(tn.Tag is ProjectModule))
                return;

            ProjectModule module = (ProjectModule)tn.Tag;

            Task t = PathCenter.CreateTask(module, project);
            if (t == null)
                return;
            
            TreeNode ntn = new TreeNode();
            ntn.Text = t.Title;
            ntn.Tag = t;
            tn.Nodes.Add(ntn);
        }

        private void 子模块ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.ProjectTreeView.SelectedNode.Tag is ProjectModule))
                return;

            ProjectModule pm = (ProjectModule)this.ProjectTreeView.SelectedNode.Tag;

            ProjectModule npm = PathCenter.CreateModule(pm);

            if (npm == null)
                return;

            TreeNode tn = new TreeNode();
            tn.Text = npm.Name;
            tn.Tag = npm;
            tn.ForeColor = Color.Blue;

            this.ProjectTreeView.SelectedNode.Nodes.Add(tn);
        }
    }
}
