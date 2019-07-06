using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

using IronPython.Hosting;
using IronPython.Runtime;

namespace LusongControl
{
    public partial class PythonConsole : UserControl
    {
        public PythonConsole()
        {
            InitializeComponent();
        }

        private void RunPythonScriptButton_Click(object sender, EventArgs e)
        {
            UniIronPython.Default.Exec(this.textBox1.Text);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Enter))
            {
                UniIronPython.Default.Exec(this.textBox1.Text);
            }
        } 
    }
}
