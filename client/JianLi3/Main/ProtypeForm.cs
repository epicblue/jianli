using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3.Main
{
    public partial class ProtypeForm : Form
    {
        public ProtypeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string Message
        {
            set
            {
                this.textBox1.Text = value;
            }
        }
    }
}
