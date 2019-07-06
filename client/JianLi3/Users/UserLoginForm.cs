using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianLi3.Properties;
using JianLi3Data;
using JianLi3Data.DataSetting;

namespace JianLi3.editor
{
    public partial class UserLoginForm : Form
    {
        public UserLoginForm()
        {
            InitializeComponent();
            this.textBox1.Text = DataSettings.Default.User.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User = JianLiLinq.Default.UserCreateOrGet(this.textBox1.Text);
            this.DialogResult = DialogResult.OK;
            Close();
        }
        public User User;

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
