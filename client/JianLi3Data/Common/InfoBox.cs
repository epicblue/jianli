using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3.CommonUI
{
    public partial class InfoBox : Form
    {
        public InfoBox()
        {
            InitializeComponent();
        }
        public string Info
        {
            set
            {
                this.label1.Text = value;
            }
        }
    }
}
