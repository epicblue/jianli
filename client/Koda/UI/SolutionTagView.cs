using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EnvDTE80;
using EnvDTE;
using JianLi3Data;
using System.Diagnostics;

namespace JianLi.UI
{
    public partial class SolutionTagView : UserControl
    {
        public SolutionTagView()
        {
            InitializeComponent();
        }
        private Window parentWindow;
        private DTE2 dte;

        public DTE2 DTE
        {
            get
            {
                return this.dte;
            }
            set
            {
                this.dte = value;
                Events2 events = (Events2)this.dte.Events;
            }
        }
        public Window ParentWindow
        {
            get
            {
                return this.parentWindow;
            }
            set
            {
                this.parentWindow = value;
            }
        }


        private void LoadAllSolutionKeyword()
        {
            this.treeView1.Nodes.Clear();

            JianLi3Data.DataClasses1DataContext db = JianLi3Data.JianLiLinq.Default.DB;
            var sks = from sk in db.SolutionKeywords
                      select sk;

            foreach (JianLi3Data.SolutionKeyword sk in sks)
            {
                TreeNode tn = new TreeNode();
                tn.Text = sk.SolutionKeywordName;
                tn.Tag = sk;
                tn.Nodes.Add("占位");
                this.treeView1.Nodes.Add(tn);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadAllSolutionKeyword();
        }

        private void SolutionTagView_Load(object sender, EventArgs e)
        {
            LoadAllSolutionKeyword();
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode stn = e.Node;
            if (stn.Tag is JianLi3Data.SolutionKeyword)
            {
                if (stn.Nodes.Count == 1 && stn.Nodes[0].Text == "占位")
                {
                    stn.Nodes.Clear();
                    JianLi3Data.SolutionKeyword sk = (JianLi3Data.SolutionKeyword)stn.Tag;
                    var slnks = from slnk in JianLi3Data.JianLiLinq.Default.DB.SolusionToKeywords
                                where slnk.SolutionKeywordID == sk.SolusionKeywordID
                                select slnk.Solution;

                    foreach (JianLi3Data.Solution s in slnks)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = s.SolutionPath;
                        tn.Tag = s;
                        stn.Nodes.Add(tn);
                    }
                }
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = this.treeView1.HitTest(e.X, e.Y);
            if (info.Node == null)
                return;
            if (info.Node.Tag is JianLi3Data.Solution)
            {
                JianLi3Data.Solution s = (JianLi3Data.Solution)info.Node.Tag;
                // 代码重复
                if (dte.Solution.FullName == "")
                {
                    dte.Solution.Open(s.SolutionPath);
                }
                else
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo ps = new ProcessStartInfo(s.SolutionPath);
                    p.StartInfo = ps;
                    p.Start();
                }
            }
        }
    }
}
