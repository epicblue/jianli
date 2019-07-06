using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using EnvDTE80;
using EnvDTE;
using JianLi3Data.SolusionEdit;
using JianLi3Data;

namespace JianLi.UI
{
    public partial class SolutionListView : UserControl
    {
        public SolutionListView()
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dte.Solution.FullName);
        }

        private void SolutionListView_Load(object sender, EventArgs e)
        {
            LoadAllSolution();
        }

        private void LoadAllSolution()
        {
            this.listBox1.Items.Clear();

            JianLi3Data.DataClasses1DataContext db = JianLi3Data.JianLiLinq.Default.DB;
            var slns = from solution in db.Solutions
                       where solution.MachineName == Environment.MachineName.ToUpper()
                      select solution;

            foreach (JianLi3Data.Solution sln in slns)
                this.listBox1.Items.Add(sln.SolutionPath);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SolutionAddKeywordForm f = new SolutionAddKeywordForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                JianLi3Data.JianLiLinq.Default.SolutionAddKeyword(this.listBox1.SelectedItem.ToString(), f.Keyword,f.Rate);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadAllSolution();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;
            string solutionpath = listBox1.SelectedItem.ToString();
            if (!System.IO.File.Exists(solutionpath))
            {
                MessageBox.Show("该项目已经移动，或不存在了。");
                PathCenter.DelSolution(solutionpath);
                return;
            }
            if (dte.Solution.FullName == "")
            {
                dte.Solution.Open(solutionpath);
            }
            else
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo(solutionpath);
                p.StartInfo = ps;
                p.Start();
            }
        }
    }
}
