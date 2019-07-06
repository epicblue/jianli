using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianLi3Data;
using System.IO;
using JianLi3Data.FileService;
using JianLi3Data.DataSetting;

namespace JianLi3.Books
{
    public class NewBookPresent
    {
        public NewBookPresent(INewBookView view,string localpath)
        {
            View = view;
            LocalPath = localpath;
            View.OnViewLoaded += new EventHandler(View_OnViewLoaded);
            View.OnBookCreate += new OnViewCreateDelegate(View_OnBookCreate);
            View.OnBookTitleChanged += new EventHandler(View_OnBookTitleChanged);
        }
        Book book;
        void View_OnBookTitleChanged(object sender, EventArgs e)
        {
            JianLi3Data.DataClasses1DataContext db = JianLiLinq.Default.DB;
            // 判断是否存在书
            if (acs.Contains(View.BookTitle))
            {
                isBookInLib = true;

                book = (from b in db.Books
                        where b.BookName == View.BookTitle
                        select b).Single();


                var ks = from k in book.BookKeywords
                         select k.Keywords;

                string keywordpaths = "";
                foreach (Keywords k in ks)
                    keywordpaths = keywordpaths + JianLiLinq.Default.GetKeywordPath(k) + ";";

                View.BookKeywords = keywordpaths;
                View.BookRate = book.BookRate;

                View.BookSubTitle = book.BookSubTitle;
                isBookInLib = true;
            }
            else
            {
                isBookInLib = false;
            }
        }
        void View_OnBookCreate(ref bool iscreated)
        {
            JianLi3Data.DataClasses1DataContext db = JianLiLinq.Default.DB;
            string filesubpath;
            // 更新数据库
            if (isBookInLib)
            {
            book = (from b in db.Books
                         where b.BookName == View.BookTitle
                         select b).Single();
                book.BookName = View.BookTitle;
                book.BookPublishHouse = View.PublishHouse;
                book.BookRate = View.BookRate;
                if (book.BookCover == null)
                    Common2.UpdateBookCover(ref book, LocalPath);

                JianLi3Data.File f = new JianLi3Data.File();
                f.UploadDate = DateTime.Now;
                // 确定子文件路径
                if (book.Keywords.KeywordSubPath != null)
                {
                    f.FilePath = book.Keywords.KeywordSubPath + "\\" + Path.GetFileName(LocalPath);
                }
                else
                {
                    f.FilePath = Path.GetFileName(LocalPath);
                }
                // 文件最终位置
                filesubpath = f.FilePath;

                f.FileVersion = View.BookVersion;
                f.Book = book;
                f.FileDesc = View.FileDescription;

                db.Files.InsertOnSubmit(f);

                f.FilePath = JianLi3FileServiceManager.Default.MoveToLib(LocalPath, f);
                // 更新数据库
                db.SubmitChanges();
            }
            else
            {
                List<Keywords> bookkeywords = new List<Keywords>();

                if (View.BookKeywords == "")
                {
                    MessageBox.Show("没有给书籍设定关键字，无法完成归类，请使用“添加”按钮！");
                    return;
                }
                string[] keywordpaths = View.BookKeywords.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string kp in keywordpaths)
                {
                    string[] ks = kp.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (ks.Length <= 1)
                        throw new Exception("关键字不该存在于顶层，需要类别。");
                    Keywords k = JianLiLinq.Default.CreateOrGetKeyword(kp);

                    if (!bookkeywords.Contains(k))
                        bookkeywords.Add(k);
                }

                Book b = new Book();
                JianLi3Data.File f = new JianLi3Data.File();

                f.UploadDate = DateTime.Now;

                b.BookName = View.BookTitle;
                b.BookPublishHouse = View.PublishHouse;
                b.BookRate = View.BookRate;
                b.BookSubTitle = View.BookSubTitle;
                b.BookDefaultKeyword = bookkeywords[0].KeywordID;
                b.BookType = BookHelper.BookTypeConvert(View.BookType);


                Common2.UpdateBookCover(ref b, LocalPath, false);

                if (bookkeywords[0].KeywordSubPath != null)
                {
                    f.FilePath = bookkeywords[0].KeywordSubPath + "\\" + Path.GetFileName(LocalPath);
                }
                else
                {
                    f.FilePath = Path.GetFileName(LocalPath);
                }

                f.FileVersion = View.BookVersion;
                f.Book = b;
                f.BookResource = View.IsResource;
                f.FileDesc = View.FileDescription;
                f.UserID = DataSettings.Default.User.UserID;


                db.Books.InsertOnSubmit(b);
                db.Files.InsertOnSubmit(f);
                db.SubmitChanges();

                b.File = f;// 出现循环的时候，还需要这么搞一下？
                db.SubmitChanges();

                foreach (Keywords k in bookkeywords)
                {
                    BookKeywords bk = new BookKeywords();
                    bk.Book = b;
                    bk.Keywords = k;
                    b.BookKeywords.Add(bk);
                    db.BookKeywords.InsertOnSubmit(bk);
                }

                f.FilePath = JianLi3FileServiceManager.Default.MoveToLib(LocalPath, f);
                // 更新数据库
                db.SubmitChanges();
            }
            iscreated = true;
        }

        INewBookView View;
        AutoCompleteStringCollection acs;
        bool isBookInLib = false;
        string LocalPath = "";
        void View_OnViewLoaded(object sender, EventArgs e)
        {
            // 初始自动完成书名功能数据
            acs = new AutoCompleteStringCollection();
            var bns = from b in JianLiLinq.Default.DB.Books
                      select b.BookName;

            foreach (string bn in bns)
                acs.Add(bn);

            View.acbooknames = acs;

            // 初始化书籍关注度，normal
            View.BookRate = 2;
            View.LocalPath = LocalPath;
        }


    }
}
