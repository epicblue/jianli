using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3Data.ToolView
{
    public partial class ToolTree : UserControl
    {
        public ToolTree()
        {
            InitializeComponent();
        }

        private void ToolTree_Load(object sender, EventArgs e)
        {
            CreateTreeNode(this.treeView1.Nodes,new Guid("a990a04f-6c9d-4309-8fd2-2d45ba423c8a"));
        }

        private void CreateTreeNode(TreeNodeCollection tns,Guid guid)
        {
            var cs = from category in JianLiLinq.Default.DB.ToolCategories
                     where category.CategoryParent == guid
                     select category;

            foreach (ToolCategory c in cs)
            {
                TreeNode tn = new TreeNode();
                tn.Text = c.CategoryName;
                tn.Tag = c;
                tn.Nodes.Add("占位");
                if (c.CategoryDesc != null)
                    tn.ToolTipText = c.CategoryDesc;
                tns.Add(tn);
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            CreateTreeNode(this.treeView1.Nodes, new Guid("a990a04f-6c9d-4309-8fd2-2d45ba423c8a"));
        }
    }
}
