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
using JianLi3Data.ProjectView;
using JianLi3Data;

namespace JianLi.UI
{
    public partial class ProjectView : UserControl
    {
        private DTE2 dte;
        private Window parentWindow;
        private JianLi3Data.User2 user;

        public ProjectView()
        {
            InitializeComponent();
        }

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

        public JianLi3Data.User2 User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JianLi3Data.Project p = PathCenter.CreateProject();
            TryLoadProject(p);
        }
        private void TryLoadProject(JianLi3Data.Project project)
        {
            if (project != null)
                LoadProject(project);
        }
        private void LoadProject(JianLi3Data.Project project)
        {
            // init summary
            label2.Text = project.Name;
            if (project.CurIteration.HasValue)
                label4.Text = project.ProjectIteration.Name;
            else
                label4.Text = "";
            // init module
            this.projectTreeVIewControl1.Project = project;

        }

        // 载入默认项目
        private void ProjectView_Load(object sender, EventArgs e)
        {
            var us = from u in JianLi3Data.JianLiLinq.Default.DB.User2s
                     where u.Name == "epicblue"
                     select u;

            user = us.Single();
            // powerbox-14qm8h
            var ps = from p in JianLi3Data.JianLiLinq.Default.DB.Projects
                     from pu in p.ProjectUsers
                     where pu.User2 == user
                     select pu.Project1;

            foreach (JianLi3Data.Project p in ps)
                this.toolStripComboBox1.Items.Add(p.Name);

            if (user.DefaultProject.HasValue)
            {
                LoadProject(user.Project);
                toolStripComboBox1.Text = user.Project.Name;
            }
            else
            {

                JianLi3Data.Project p = PathCenter.CreateProject();
                if (p != null)
                {
                    LoadProject(p);
                    // 用户关联默认项目
                    user.Project = p;
                    // 项目关联用户
                    JianLi3Data.ProjectUser pu = new JianLi3Data.ProjectUser();
                    pu.Project1 = p;
                    pu.User2 = user;
                    JianLi3Data.JianLiLinq.Default.DB.ProjectUsers.InsertOnSubmit(pu);

                    JianLi3Data.JianLiLinq.Default.DB.SubmitChanges();
                }
            }
        }

        private void projectTreeVIewControl1_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
