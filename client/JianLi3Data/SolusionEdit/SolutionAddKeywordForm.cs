using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3Data.SolusionEdit
{
    public partial class SolutionAddKeywordForm : Form
    {
        public SolutionAddKeywordForm()
        {
            InitializeComponent();
        }

        public string Keyword;
        public byte Rate;

        private void button1_Click(object sender, EventArgs e)
        {
            Keyword = this.textBox1.Text;
            Rate = (byte)(this.comboBox1.SelectedIndex + 1);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SolutionAddKeywordForm_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 2;
        }
    }
}
