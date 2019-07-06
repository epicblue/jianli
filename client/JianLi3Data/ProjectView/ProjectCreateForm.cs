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
    public partial class ProjectCreateForm : Form
    {
        public ProjectCreateForm()
        {
            InitializeComponent();
        }
        public Project Project;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Project = DataCenter.CreateProject(NameTextBox.Text, CommentTextBox.Text);
                this.EditIterationButton.Enabled = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void EditIterationButton_Click(object sender, EventArgs e)
        {
            IterationsEditForm f = new IterationsEditForm();
            f.Project = this.Project;
            f.ShowDialog();
        }
    }
}
