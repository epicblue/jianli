using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3Data.ToolView
{
    public partial class ToolInfo : UserControl
    {
        public ToolInfo()
        {
            InitializeComponent();
        }
        private Tool tool;
        public Tool Tool
        {
            set
            {
                tool = value;
            }
        }
    }
}
