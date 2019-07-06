using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianLi3Data;
using JianLi3Data.DataSetting;

namespace JianLi3
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var answers = from h in JianLiLinq.Default.DB.Helps
                          where h.HelpTitle == this.QuestTextBox.Text
                          select h;

            foreach (var a in answers)
            {
                if(a.HelpAnswered)
                    AnswerListBox.Items.Add(a.HelpTitle);
            }

            if (answers.Count() == 0)
            {
                JianLi3Data.Help h = new JianLi3Data.Help();
                h.HelpSubmitUser = DataSettings.Default.User.UserID;
                h.HelpTitle = this.QuestTextBox.Text;
                JianLiLinq.Default.DB.Helps.InsertOnSubmit(h);
                JianLiLinq.Default.DB.SubmitChanges();

                MessageBox.Show("问题不存在。");
            }
        }

        private void AnswerListBox_DoubleClick(object sender, EventArgs e)
        {
            var answers = from h in JianLiLinq.Default.DB.Helps
                          where h.HelpTitle == this.AnswerListBox.SelectedItem.ToString() && h.HelpAnswered
                          select h;

            foreach (var a in answers)
            {
                MessageBox.Show(a.HelpAnswer);
            }
        }
    }
}
