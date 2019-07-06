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
    public partial class KeywordSelectForm : Form
    {
        public KeywordSelectForm()
        {
            InitializeComponent();
            this.categoryAndKeywordControl1.SelectedTypeChanged += new JianLi3.views.SelectedTypeChangedDelegate(categoryAndKeywordControl1_SelectedTypeChanged);
        }

        void categoryAndKeywordControl1_SelectedTypeChanged(bool iskeyword)
        {
                okbutton.Enabled = iskeyword;
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        public string path
        {
            get
            {
                return this.categoryAndKeywordControl1.KeywordPath;
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
