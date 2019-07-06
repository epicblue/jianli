using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianLi3.views;

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
                var bs = from ub in JianLiLinq.Default.DB.UserBooks
                         where ub.UserID == JianLiLinq.Default.User.UserID
                         orderby ub.BookReadTick descending
                         select ub.Books;

                SearchResultBookViewControl.Books = bs.Take(8).ToArray();
            }
            else if (e.Node.Text == "看的时间最长的书")
            {
                var bs = from ub in JianLiLinq.Default.DB.UserBooks
                         where ub.UserID == JianLiLinq.Default.User.UserID
                         orderby ub.BookReadTime descending
                         select ub.Books;

                SearchResultBookViewControl.Books = bs.Take(8).ToArray();
            }
            else if (e.Node.Text == "看的次数最多的书")
            {
                var bs = from ub in JianLiLinq.Default.DB.UserBooks
                         where ub.UserID == JianLiLinq.Default.User.UserID
                         orderby ub.BookReadCounts descending
                         select ub.Books;

                SearchResultBookViewControl.Books = bs.Take(8).ToArray();
            }
        }

    }
}
