using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3Data.ProjectView
{
    public partial class IterationsEditForm : Form
    {
        public IterationsEditForm()
        {
            InitializeComponent();
        }
        Project project;
        public Project Project
        {
            set
            {
                this.project = value;
            }
            get
            {
                return this.project;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            IterationEditForm f = new IterationEditForm();
            if(f.ShowDialog() == DialogResult.Cancel)
                return;

            if (project.ProjectIterations.Count() == 256)
                throw new Exception("最多只支持256个迭代。");
            ProjectIteration iteration = new ProjectIteration();
            iteration.Order = (byte)(project.ProjectIterations.Count());
            iteration.ProjectID = project.ID;
            iteration.Name = f.IterationName;
            iteration.Comment= f.IterationComment;
            iteration.ID = Guid.NewGuid();
            JianLiLinq.Default.DB.ProjectIterations.InsertOnSubmit(iteration);
            JianLiLinq.Default.DB.SubmitChanges();

            this.listBox1.Items.Add(iteration);
        }

        private bool CheckProjectIterationOrder()
        {
            throw new NotImplementedException("CheckProjectIterationOrder");
        }

        private void IterationsEditForm_Load(object sender, EventArgs e)
        {
            foreach (ProjectIteration iteration in project.ProjectIterations)
                this.listBox1.Items.Add(iteration.Name);
        }
    }
}
