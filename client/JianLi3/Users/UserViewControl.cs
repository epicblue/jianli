using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianLi3.views;
using JianLi3Data;
using JianLi3Data.DataSetting;

namespace JianLi3
{
    public partial class UserViewControl : UserControl
    {
        public UserViewControl()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "最近看的书")
            {
                SearchResultBookViewControl.Books = BookQuery.RecentReadBooks(DataSettings.Default.User).ToArray();
            }
            else if (e.Node.Text == "看的时间最长的书")
            {
                SearchResultBookViewControl.Books = BookQuery.MostReadBooks(DataSettings.Default.User).ToArray();
            }
            else if (e.Node.Text == "看的次数最多的书")
            {
                SearchResultBookViewControl.Books = BookQuery.MostOpenBooks(DataSettings.Default.User).ToArray();
            }
            else if (e.Node.Text == "非常喜欢")
            {
                SearchResultBookViewControl.Books = BookQuery.RateBooks(DataSettings.Default.User,BookRateEnum.Love).ToArray();
            }
            else if (e.Node.Text == "喜欢")
            {
                SearchResultBookViewControl.Books = BookQuery.RateBooks(DataSettings.Default.User, BookRateEnum.Like).ToArray();
            }
            else if (e.Node.Text == "正规")
            {
                SearchResultBookViewControl.Books = BookQuery.RateBooks(DataSettings.Default.User, BookRateEnum.Regular).ToArray();
            }
            else if (e.Node.Text == "没有感觉")
            {
                SearchResultBookViewControl.Books = BookQuery.RateBooks(DataSettings.Default.User, BookRateEnum.NoFeeling).ToArray();

            }
            else if (e.Node.Text == "不喜欢")
            {
                SearchResultBookViewControl.Books = BookQuery.RateBooks(DataSettings.Default.User, BookRateEnum.NotLike).ToArray();
            }
            else if (e.Node.Text == "孤立的书")
            {

                SearchResultBookViewControl.Books = BookQuery.IsolateBooks().ToArray();
            }
            else if (e.Node.Text == "新添加的书")
            {

                SearchResultBookViewControl.Books = BookQuery.NewBooks().ToArray();
            }
            else if (e.Node.Text == "有新书")
            {

                SearchResultBookViewControl.Books = BookQuery.NewBooks(DataSettings.Default.User).ToArray();

                // update notsee color
                TreeNode tn = FindNode("有新书", treeView1.Nodes);
                tn.ForeColor = Color.Black;

                // update usercheck time
                DataSettings.Default.User.UserLastCheckBookDate = DateTime.Now;
                JianLiLinq.Default.DB.SubmitChanges();
            }
            else if (e.Node.Text == "未定类型的书")
            {
                Book[] bs = BookQuery.TypeBooks(BookTypeEnum.Uncheck).ToArray();
                SearchResultBookViewControl.Books = bs;
            }
        }

        private void UserViewControl_Load(object sender, EventArgs e)
        {
            if (this.Site != null)
            {
                if (this.Site.DesignMode == true)
                    return;
            }
            var bs = BookQuery.NewBooks(DataSettings.Default.User);

            if (bs.Count() > 0)
            {
                TreeNode tn = FindNode("有新书", treeView1.Nodes);
                tn.ForeColor = Color.Red;
            }
        }
        private TreeNode FindNode(string text,TreeNodeCollection c)
        {
            foreach (TreeNode tn in c)
            {
                if (tn.Text == text)
                    return tn;

                TreeNode tn1 = FindNode(text, tn.Nodes);

                if (tn1 != null)
                    return tn1;
            }
            return null;
        }
    }
}
