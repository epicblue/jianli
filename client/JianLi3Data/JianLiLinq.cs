using System;
using System.Linq;
using System.Diagnostics;
using JianLi3Data.FileService;
using JianLi3Data.DataSetting;
using JianLi3Data.Properties;
using System.Collections.Generic;

namespace JianLi3Data
{
    public class JianLiLinq
    {
        public JianLiLinq()
        {
        }
        public static JianLiLinq Default
        {
            get
            {
                if (def == null)
                {
                    def = new JianLiLinq();
                    def.DB = new DataClasses1DataContext();
#if OFFICE
                    def.DB.Connection.ConnectionString = @"Data Source=" + DataSettings.Default.ServerName + @"\;Initial Catalog=JianLi;User ID=bee;Password=beegee";
#endif
#if HOME
                    def.DB.Connection.ConnectionString = @"Data Source=" + DataSettings.Default.ServerName + @"\;Initial Catalog=JianLi;Integrated Security=True";
#endif
                }
                    return def;
            }
        }
        private static JianLiLinq def;
        // the class become my setting class

        public JianLi3Data.DataClasses1DataContext DB;

        // 处理不确定Category和Keyword是否存在的情况，比如：添加"试验|Microsoft Office|Excel"
        /**/
        #region Keyword

        public Keywords CreateOrGetKeyword(string keywordpath)
        {
            string[] keyword = keywordpath.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            bool isadding = false;// 如果不在添加的话，就是在检查
            int parentcategoryid = -1;
            for (int i = 0; i < keyword.Length-1; i++)
            {
                // check category
                if (!isadding)
                {
                    var p = from category in DB.Categories
                            where category.CategoryName == keyword[i] && category.CategoryParent == parentcategoryid
                            select category;
                    switch (p.Count())
                    {
                        case 0:// 该项不存在,那么接下来的所有子类别和子类别的关键词都不存在
                            isadding = true;
                            break;
                        case 1:// 已经存在
                            parentcategoryid = p.Single().CategoryID;
                            Debug.WriteLine("Category: \"" + keyword[i] + "\" exsist");
                            break;
                        default:// 提示重复
                            Debug.WriteLine("Category=" + keyword[i] + " parentcategoryid=" + parentcategoryid.ToString() + "出现重复。");
                            break;
                    }
                }
                if (isadding)
                {
                    // 下一步需要获得
                    Categories c = new Categories { CategoryName = keyword[i], CategoryDesc = "", CategoryParent = parentcategoryid };
                    DB.Categories.InsertOnSubmit(c);
                    // !!!自引用问题没有处理，导致必须在这里执行更新，来获取数据库分配的ID。
                    DB.SubmitChanges();
                    parentcategoryid = c.CategoryID;
                    Debug.WriteLine("Category: \"" + keyword[i] + "\" add." + "id: " + parentcategoryid.ToString());
                }

            }
            // check keyword
            if (!isadding)
            {
                var kws = from kw in DB.Keywords
                          where kw.KeywordName == keyword[keyword.Length - 1] && kw.CategoryId == parentcategoryid
                          select kw;
                switch (kws.Count())
                {
                    case 0:// 该项不存在
                        isadding = true;
                        Debug.WriteLine("Keyword: \"" + keyword[keyword.Length - 1] + "\" add." + "id: " + parentcategoryid.ToString());
                        break ;
                    case 1:// 已经存在
                        Debug.WriteLine("keyword: \"" + keyword[keyword.Length - 1] + "\" exsist");
                        return kws.Single();
                    default:// 提示重复
                        throw new Exception("Keyword=" + keyword[keyword.Length - 1] + " parentcategoryid=" + parentcategoryid.ToString() + "出现重复。");
                }
            }
            if (isadding)
            {
                Keywords c = new Keywords { KeywordDesc = "", CategoryId = parentcategoryid, KeywordName = keyword[keyword.Length - 1],KeywordRate = 3 };
                c.KeywordSubPath = JianLi3FileServiceManager.Default.CreateSubFolderInLib(c.KeywordName);

                DB.Keywords.InsertOnSubmit(c);
                DB.SubmitChanges();
                return c;
            }
            else
            {
                throw new Exception("i dont belive this happen");
            }
            // update
            
        }
        public string GetKeywordPath(Keywords k)
        {
            int parentcategory = k.CategoryId;
            string s = k.KeywordName;
            while (parentcategory != -1)
            {
                Categories c = DB.Categories.Where(o => o.CategoryID == parentcategory).Single();
                s = c.CategoryName + '|' + s;
                parentcategory = c.CategoryParent;
            }
            return s;
        }

        public void DelKeyword(Keywords k)
        {                    // 处理一遍默认关键字   
            var books = from book in DB.Books
                        where book.BookDefaultKeyword == k.KeywordID
                        select book;
            foreach (Book b in books)
            {
                if (b.BookKeywords.Count > 1)
                {
                    for (int i = 0; i < b.BookKeywords.Count; i++)
                    {
                        if (b.BookKeywords[i].KeywordId != k.KeywordID)
                        {
                            b.BookDefaultKeyword = b.BookKeywords[i].KeywordId;
                            break;
                        }
                    }
                }
                else
                {
                    b.BookDefaultKeyword = null;
                }
            }
            // 删除书籍关键字信息
            foreach (BookKeywords bk in k.BookKeywords)
                DB.BookKeywords.DeleteOnSubmit(bk);

            // 删除用户关键字信息
            var uks = from uk in JianLiLinq.Default.DB.UserKeywords
                      where uk.KeywordID == k.KeywordID
                      select uk;

            foreach (UserKeyword uk in uks)
                DB.UserKeywords.DeleteOnSubmit(uk);

            DB.SubmitChanges();// 要哭了，一定要这样吗？

            DB.Keywords.DeleteOnSubmit(k);

            DB.SubmitChanges();
        }

        #endregion

        #region Keyword User

        public UserKeyword CreateUserKeyword(Keywords k)
        {
            UserKeyword uk = new UserKeyword();
            uk.KeywordID = k.KeywordID;
            uk.UserID = DataSettings.Default.User.UserID;
            uk.KeywordRate = 2;
            JianLiLinq.Default.DB.UserKeywords.InsertOnSubmit(uk);
            return uk;
        }
        internal UserKeyword GetUserKeyword(Keywords k)
        {
            UserKeyword ub = null;

            var ubs = (from u in DB.UserKeywords
                       where u.KeywordID == k.KeywordID && u.UserID == DataSettings.Default.User.UserID
                       select u);

            if (ubs.Count() == 1)
                ub = ubs.Single();
            else
            {
                ub = CreateUserKeyword(k);
                JianLiLinq.Default.DB.SubmitChanges();
            }

            return ub;
        }

        #endregion

        public User UserCreateOrGet(string name)
        {
            User user;
            var p = from u in JianLiLinq.Default.DB.Users
                    where u.UserName == name
                    select u;

            if (p.Count() == 1)
            {
                user = p.Single();
            }
            else
            {
                user = new User();
                user.UserLoginCount = 0;
                user.UserLastLoginDate = DateTime.Now;
                user.UserLastBookTick = 0;
                user.UserName = name;
                user.UserPassword = "";
                user.UserLastCheckBookDate = DateTime.Parse("2007.01.01");
                DB.Users.InsertOnSubmit(user);
                DB.SubmitChanges();
            }
            return user;
        }

        public File[] GetBookFiles(Book b)
        {
            var p= from f in DB.Files
                   where f.Book == b
                   select f;

            return p.ToArray();
        }

        #region Book

        // 绑定关键字
        public void BookMarkKeyword(Book book,Keywords keyword)
        {
            // 检查Book是否已经有了Keyword。
            var bks = from bk0 in DB.BookKeywords
                      where bk0.BookId == book.BookID && bk0.KeywordId == keyword.KeywordID
                      select bk0;
            if (bks.Count() > 0)
                return;

            // 新建BookKeywords。
            BookKeywords bk = new BookKeywords();
            bk.Keywords = keyword;
            bk.Book = book;
            book.BookKeywords.Add(bk);

            // 该书籍没有设定一个关键字
            if (book.BookDefaultKeyword == null)
                book.BookDefaultKeyword = keyword.KeywordID;

            DB.BookKeywords.InsertOnSubmit(bk);
        }
        // 解除绑定关键字
        public void DelBookKeyword(Book book, Keywords keyword)
        {
            var bks = from bk in DB.BookKeywords
                      where bk.BookId == book.BookID && bk.KeywordId == keyword.KeywordID
                      select bk;

            if (bks.Count() != 1)
                throw new Exception("出现多个相同的BookKeyword！");

            foreach (var bk in bks)
                DB.BookKeywords.DeleteOnSubmit(bk);

            // 更新书籍的默认关键字
            bool newkey = false;
            if (book.BookDefaultKeyword == keyword.KeywordID)
            {
                foreach (BookKeywords k in book.BookKeywords)
                {
                    if (k.KeywordId != keyword.KeywordID)
                    {
                        // 随便找一个作为默认关键字
                        book.BookDefaultKeyword = k.KeywordId;
                        newkey = true;
                        break;
                    }
                }

                // 使用-1作为该书没有关键字的标识
                if (!newkey)
                    book.BookDefaultKeyword = null;
            }

            DB.SubmitChanges();
        }

        public void DelBook(Book b)
        {
            b.BookDefaultFile = null;
            DB.SubmitChanges();

            DB.Books.DeleteOnSubmit(b);

            var ubs = from ub in DB.UserBooks
                      where ub.BookID == b.BookID
                      select ub;
            foreach (var u in ubs)
                DB.UserBooks.DeleteOnSubmit(u);

            var fs = from f in DB.Files
                     where f.BookID == b.BookID
                     select f;
            foreach (var f in fs)
                DB.Files.DeleteOnSubmit(f);

            var bks = from bk in DB.BookKeywords
                      where bk.BookId == b.BookID
                      select bk;
            foreach (var bk in bks)
                DB.BookKeywords.DeleteOnSubmit(bk);

            var bws = from bw in DB.BookWriters
                      where bw.BookId == b.BookID
                      select bw;
            foreach (var bw in bws)
                DB.BookWriters.DeleteOnSubmit(bw);

            DB.SubmitChanges();
        }

        public bool IsBookExsit(string bookname)
        {
            return DB.Books.Where(o => o.BookName == bookname).Count() == 1;
        }

        #endregion

        #region Book Comment

        public void CreateBookComment(string comment, Book book)
        {
            BookComment bc = new BookComment();
            bc.CommentID = Guid.NewGuid();
            bc.BookID = book.BookID;
            bc.Comment = comment;
            bc.Date = DateTime.Now;
            bc.UserID = DataSettings.Default.User.UserID;
            bc.Against = 0;
            bc.Support = 0;
            DB.BookComments.InsertOnSubmit(bc);
            DB.SubmitChanges();
        }

        public IQueryable<BookComment> GetBookComments(Book book)
        {
            var bcs = from bc in DB.BookComments
                      where bc.BookID == book.BookID
                      select bc;
            return bcs;
        }

        #endregion

        public User GetUser(int userid)
        {
            var names = from user in DB.Users
                        where user.UserID == userid
                        select user;
            return names.Single();
        }

        #region Book User

        public List<User> GetBookContributors(Book b)
        {
            List<User> us = new List<User>();
            foreach (File f in b.Files)
            {
                if (f.UserID != null)
                {
                    us.Add(GetUser((int)f.UserID));
                }
            }
            return us;
        }
        public UserBooks CreateUserBook(Book b)
        {
            UserBooks ub = new UserBooks();
            ub.Book = b;
            ub.BookReadCounts = 0;
            ub.BookReadTime = 0;
            ub.BookReadTick = 0;
            ub.BookRate = -1;
            ub.User = DataSettings.Default.User;
            JianLiLinq.Default.DB.UserBooks.InsertOnSubmit(ub);
            return ub;
        }
        public UserBooks GetUserBook(Book book)
        {
            UserBooks ub = null;

            var ubs = (from u in DB.UserBooks
                       where u.BookID == book.BookID && u.UserID == DataSettings.Default.User.UserID
                       select u);

            if (ubs.Count() == 1)
                ub = ubs.Single();

            return ub;
        }

        // 更新阅读时间
        internal void EndRead(Book book, TimeSpan t)
        {
            UserBooks ub = JianLiLinq.Default.GetUserBook(book);

            ub.BookReadTime += (int)t.TotalSeconds;

            DB.SubmitChanges();
        }
        // 设定用户上次读的书
        public void SetLastOpenBook(Book book)
        {
            UserBooks ub = GetUserBook(book);

            if (ub == null)
                ub = Default.CreateUserBook(book);

            if (DataSettings.Default.User.UserLastBookTick < 2)
                DataSettings.Default.User.UserLastBookTick = 2;

            if (DataSettings.Default.User.UserLastBookTick != ub.BookReadTick + 1)
            {
                ub.BookReadTick = DataSettings.Default.User.UserLastBookTick;
                DataSettings.Default.User.UserLastBookTick++;
            }

            DB.SubmitChanges();
        }

        #endregion




        #region Solution
        public void CreateSolution(string solutionpath)
        {
            var sln = from solution in DB.Solutions
                      where solution.SolutionPath == solutionpath
                      select solution;
            if (sln.Count() == 0)
            {
                Solution s = new Solution();
                s.SolusionID = Guid.NewGuid();
                s.RecentOpenTime = DateTime.Now;
                s.SolutionPath = solutionpath;
                s.MachineName = Environment.MachineName.ToUpper();
                DB.Solutions.InsertOnSubmit(s);
                DB.SubmitChanges();
            }
            else if (sln.Count() == 1)
            {
                Solution s = sln.Single();
                s.RecentOpenTime = DateTime.Now;
                DB.SubmitChanges();
            }
            else
            {
                throw new Exception("解决方案重复！");
            }
        }
        public Solution GetSolution(string solutionpath)
        {
            var sln = from solution in DB.Solutions
                      where solution.SolutionPath == solutionpath
                      select solution;

            if (sln.Count() == 0)
                throw new Exception("没有发现解决方案："+solutionpath);
            else if (sln.Count() == 1)
                return sln.Single();
            else
                throw new Exception("发现多条记录："+solutionpath);
        }


        public void SolutionAddKeyword(string solutionpath, string keywordname,byte rate)
        {

            var sln = from solution in DB.Solutions
                      where solution.SolutionPath == solutionpath
                      select solution;
            if (sln.Count() > 1)
                throw new Exception("数据库中包含重复的解决方案路径！");
            if (sln.Count() == 0)
                throw new Exception("数据库中无解决方案路径！");
            Solution s = sln.Single();
            


            var key = from keyword in DB.SolutionKeywords
                      where keyword.SolutionKeywordName == keywordname
                      select keyword;

            SolutionKeyword sk;
            if(key.Count()>1)
                throw new Exception("数据库中包含重复的解决方案关键字！");

            if (key.Count() == 0)
            {
                sk = new SolutionKeyword();
                sk.SolusionKeywordID = Guid.NewGuid();
                sk.SolutionKeywordName = keywordname;
                DB.SolutionKeywords.InsertOnSubmit(sk);
            }
            else
            {
                sk = key.Single();
            }

            SolusionToKeyword stk = new SolusionToKeyword();
            stk.Solution = s;
            stk.SolutionKeyword = sk;
            stk.Rate = rate;

            s.SolusionToKeywords.Add(stk);
            DB.SubmitChanges();
        }

        #endregion

        #region Project
        #endregion

    }
}
