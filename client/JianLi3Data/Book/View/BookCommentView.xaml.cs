using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JianLi3Data.BookComments
{
    /// <summary>
    /// Interaction logic for BookCommentView.xaml
    /// </summary>
    public partial class BookCommentView : UserControl
    {
        public BookCommentView()
        {
            InitializeComponent();
        }
        public void ShowBookComment(Book book)
        {
            var p = from b in JianLiLinq.Default.DB.BookComments
                    where b.Book == book
                    select b;
            this.listBox1.ItemsSource = p;
        }
    }
}
