using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3
{
    public partial class NewCategoryForm : Form
    {
        public NewCategoryForm()
        {
            InitializeComponent();
        }
        public string CategoryName
        {
            get
            {
                return this.CategoryNameTextBox.Text;
            }
            set
            {
                this.CategoryNameTextBox.Text = value;
            }
        }
        public string CategoryDesc
        {
            get
            {
                return this.CategoryDescTextBox.Text;
            }
            set
            {
                this.CategoryDescTextBox.Text = value;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
