using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JianLi3Data;
using JianLi3.editor;
using JianLi3Data.JLBook.User;

namespace JianLi3.Books
{
    public class BookEditPresent
    {
        public BookEditPresent(UserBooks ub, IBookEditView view)
        {
            this.UserBooks = ub;
            this.Book = ub.Book;
            this.View = view;
            // bind event
            View.OnBookInfoChanged += new EventHandler(VIew_OnBookInfoChanged);
            View.OnBookInfoIniting += new EventHandler(View_OnBookInfoIniting);
        }
        
        // 初始化Model数据到View上
        void View_OnBookInfoIniting(object sender, EventArgs e)
        {
            View.BookDescription = Book.BookDesc;
            View.BookTitle = Book.BookName;
            View.BookPublishHouse = Book.BookPublishHouse;
            View.BookRate = (byte)UserBooks.BookRate;
            View.BookSubTitle = Book.BookSubTitle;
        }

        //从View上更新数据到Model中
        void VIew_OnBookInfoChanged(object sender, EventArgs e)
        {
            Book.BookDesc = View.BookDescription;
            Book.BookName = View.BookTitle;
            Book.BookPublishHouse = View.BookPublishHouse;
            UserBooks.BookRate = View.BookRate;
            Book.BookSubTitle = View.BookSubTitle;

            JianLiLinq.Default.DB.SubmitChanges();
            // keywords ,重复设定问题
            // Book.BookDefaultFile = null;
            // Book.BookDefaultKeyword = null;
            // Book.BookCover = null;
        }
        UserBooks UserBooks;
        Book Book;
        IBookEditView View;
    }
}
