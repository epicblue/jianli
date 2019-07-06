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
    public partial class IterationEditForm : Form
    {
        public IterationEditForm()
        {
            InitializeComponent();
        }
        public string IterationName
        {
            get
            {
                return this.NameTextBox.Text;
            }
        }
        public string IterationComment
        {
            get
            {
                return CommentTextBox.Text;
            }
        }
    }
}
