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
    public partial class KeywordsEditForm : Form
    {
        public KeywordsEditForm()
        {
            InitializeComponent();
        }
        public string KeywordName
        {
            set
            {
                this.KeywordNameTextBox.Text = value;
            }
            get
            {
                return this.KeywordNameTextBox.Text;
            }
        }
        public string KeywordDesc
        {
            set
            {
                this.KeywordDescTextBox.Text = value;
            }
            get
            {
                return this.KeywordDescTextBox.Text;
            }
        }
        public int KeywordRate
        {
            set
            {
                this.KeywordRateComboBox.SelectedIndex = value - 1;
            }
            get
            {
                return this.KeywordRateComboBox.SelectedIndex + 1;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
