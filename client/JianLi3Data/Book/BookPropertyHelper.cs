using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JianLi3Data.JLBook.User;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace JianLi3Data
{
    public enum BookTypeEnum
    {
        Book,
        Paper,
        Doc,
        Post,//海报
        Magzine,
        CheetSheet,
        Uncheck,
    }
    public enum BookRateEnum
    {
        Love,
        Like,
        Regular,
        NoFeeling,
        NotLike,
        Unrate
    }
    public class BookHelper
    {
        public static BookTypeEnum BookTypeConvert(int? booktype)
        {
            switch (booktype)
            {
                case 0:
                    return BookTypeEnum.Book;
                case 1:
                    return BookTypeEnum.Paper;
                case 2:
                    return BookTypeEnum.Doc;
                case 3:
                    return BookTypeEnum.Post;
                case 4:
                    return BookTypeEnum.Magzine;
                case 5:
                    return BookTypeEnum.CheetSheet;
                default:
                    return BookTypeEnum.Uncheck;
            }
        }
        public static int? BookTypeConvert(BookTypeEnum booktype)
        {
            switch (booktype)
            {
                case BookTypeEnum.Book:
                    return 0;
                case BookTypeEnum.Paper:
                    return 1;
                case BookTypeEnum.Doc:
                    return 2;
                case BookTypeEnum.Post:
                    return 3;
                case BookTypeEnum.Magzine:
                    return 4;
                case BookTypeEnum.CheetSheet:
                    return 5;
                default:
                    return null;
            }
        }
        public static BookTypeEnum GetBookType(Book book)
        {
            return BookTypeConvert(book.BookType);
        }
        public static void SetBookType(Book book,BookTypeEnum booktype)
        {
            book.BookType = BookTypeConvert(booktype);
        }

        public static BookRateEnum BookRateConvert(int bookrate)
        {
            switch (bookrate)
            {
                case 4:
                    return BookRateEnum.Love;
                case 3:
                    return BookRateEnum.Like;
                case 2:
                    return BookRateEnum.Regular;
                case 1:
                    return BookRateEnum.NoFeeling;
                case 0:
                    return BookRateEnum.NotLike;
                default:
                    return BookRateEnum.Unrate;
            }
        }
        public static int BookRateConvert(BookRateEnum bookrate)
        {
            switch (bookrate)
            {
                case BookRateEnum.Love:
                    return 4;
                case BookRateEnum.Like:
                    return 3;
                case BookRateEnum.Regular:
                    return 2;
                case BookRateEnum.NoFeeling:
                    return 1;
                case BookRateEnum.NotLike:
                    return 0;
                default:
                    return 3;
            }
        }

        public static Binary BookCoverConvert(string filename)
        {
            Image bitmap = new Bitmap(filename);
            MemoryStream ms = new MemoryStream();
            bitmap = bitmap.GetThumbnailImage(96, 128, null, IntPtr.Zero);
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }
        public static Binary BookCoverFromClipboard()
        {
            Image bitmap = Clipboard.GetImage();
            if (bitmap == null)
                return null;

            MemoryStream ms = new MemoryStream();
            bitmap = bitmap.GetThumbnailImage(96, 128, null, IntPtr.Zero);
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.GetBuffer();
        }
        public static Image BookCoverConvert(Binary data)
        {
            MemoryStream ms = new MemoryStream(data.ToArray());
            Image bm = Image.FromStream(ms);
            bm = bm.GetThumbnailImage(96, 128, null, System.IntPtr.Zero);
            return bm;
        }
    }
}
