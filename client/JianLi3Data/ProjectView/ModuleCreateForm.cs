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
    public partial class ModuleCreateForm : Form
    {
        public ModuleCreateForm()
        {
            InitializeComponent();
        }

        private ProjectModule module;
        public ProjectModule Module
        {
            get { return module; }
            set { module = value; }
        }

        private ProjectModule parentModule;

        public ProjectModule ParentModule
        {
            get { return parentModule; }
            set { parentModule = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            module = DataCenter.CreateModule(parentModule,NameTextBox.Text,CommentTextBox.Text);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
