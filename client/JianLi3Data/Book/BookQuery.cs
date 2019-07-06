using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JianLi3Data
{
    public class BookQuery
    {
        public static IQueryable<Book> RecentReadBooks(User user)
        {
            var bs = from ub in JianLiLinq.Default.DB.UserBooks
                     where ub.UserID == user.UserID
                     orderby ub.BookReadTick descending
                     select ub.Book;
            return bs.Take(8);
        }
        public static IQueryable<Book> MostReadBooks(User user)
        {
            var bs = from ub in JianLiLinq.Default.DB.UserBooks
                     where ub.UserID == user.UserID
                     orderby ub.BookReadTime descending
                     select ub.Book;
            return bs.Take(8);
        }
        public static IQueryable<Book> MostOpenBooks(User user)
        {
            var bs = from ub in JianLiLinq.Default.DB.UserBooks
                     where ub.UserID == user.UserID
                     orderby ub.BookReadCounts descending
                     select ub.Book;
            return bs.Take(8);
        }
        public static IQueryable<Book> RateBooks(User user,BookRateEnum bookrate)
        {
            int rate = BookHelper.BookRateConvert(bookrate);
            var bs = from ub in JianLiLinq.Default.DB.UserBooks
                     where ub.BookRate == rate && ub.UserID == user.UserID
                     select ub.Book;
            return bs.Take(8);
        }
        public static IQueryable<Book> IsolateBooks()
        {
            var bs = from book in JianLiLinq.Default.DB.Books
                     where book.BookDefaultKeyword == null
                     select book;
            return bs.Take(8);
        }
        public static IQueryable<Book> NewBooks()
        {
            var bs = from file in JianLiLinq.Default.DB.Files
                     orderby file.UploadDate descending
                     select file.Book;
            return bs.Take(10);
        }
        public static IQueryable<Book> NewBooks(User user)
        {
            var bs = from file in JianLiLinq.Default.DB.Files
                     where file.UploadDate > user.UserLastCheckBookDate
                     orderby file.UploadDate descending
                     select file.Book;
            return bs.Take(10);
        }
        public static IQueryable<Book> TypeBooks(BookTypeEnum booktype)
        {
            int? type = BookHelper.BookTypeConvert(booktype);
            if (type == null)
            {
                var bs = from book in JianLiLinq.Default.DB.Books
                         where book.BookType == null
                         select book;
                return bs;
            }
            else
            {
                var bs = from book in JianLiLinq.Default.DB.Books
                         where book.BookType == type
                         select book;
                return bs;
            }

        }

    }
}
