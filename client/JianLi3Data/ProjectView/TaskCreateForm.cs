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
    public partial class TaskCreateForm : Form
    {
        public TaskCreateForm()
        {
            InitializeComponent();
        }

        private Project project;
        public Project Project
        {
            set
            {
                project = value;
                //TODO: 排除掉已经完成的周期
                foreach (ProjectIteration pi in project.ProjectIterations)
                    this.comboBox2.Items.Add(pi.Name);
                comboBox2.SelectedItem = project.ProjectIteration.Name;
            }
            get
            {
                return project;
            }
        }

        public ProjectModule Module;

        public Task Task;

        private void TaskCreateForm_Load(object sender, EventArgs e)
        {
            PriorityComboBox.SelectedIndex = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectIteration pi = project.ProjectIterations[comboBox2.SelectedIndex];
            this.Task = DataCenter.CreateTask(this.Module,pi,textBox1.Text,textBox2.Text,(byte)(PriorityComboBox.SelectedIndex+1));
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        // 应该被快速的编辑替代。
    }
}
