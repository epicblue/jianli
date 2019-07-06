using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JianLi3Data;
using System.Data.Linq;
using JianLi3Data.JLBook.User;
using JianLi3Data.FileService;
using JianLi3.Books;

namespace JianLi3.views
{
    public partial class SearchResultBookViewControl : UserControl
    {
        private static SearchResultBookViewControl Default = null;

        public SearchResultBookViewControl()
        {
            InitializeComponent();
            Default = this;
        }

        #region [  set books  ]

        public static Book[] Books
        {
            set
            {
                if (Default == null)
                    return;

                Default.SetBooks(value);
            }
        }

        private void SetBooks(Book[] books)
        {
            this.listView1.Items.Clear();

            foreach (Book b in books)
            {
                ListViewItem i = new ListViewItem();
                i.Text = b.BookName;
                BookAndUser bu = new BookAndUser();
                bu.UserBook = JianLiLinq.Default.GetUserBook(b);
                bu.Book = b;
                i.Tag = bu;
                i.ToolTipText = b.BookDesc;
                if (b.BookCover != null)
                {
                    Image bm = BookHelper.BookCoverConvert(b.BookCover);
                    imageList1.Images.Add(bm);
                    i.ImageIndex = imageList1.Images.Count - 1;
                }
                else
                {
                    i.ImageIndex = 0;
                }
                this.listView1.Items.Add(i);
            }
        }

        #endregion

        // open file
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Book b = (listView1.SelectedItems[0].Tag as BookAndUser).Book;

                if (b.Files != null)
                {
                    FileViewer.OpenFile(b.File);
                }
            }
        }
        // delete selected book
        private void DelBookMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;
            if (MessageBox.Show("", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            List<ListViewItem> dels = new List<ListViewItem>();
            for (int i = 0; i < this.listView1.SelectedItems.Count; i++)
            {
                dels.Add(listView1.SelectedItems[i]);
                JianLiLinq.Default.DelBook((listView1.SelectedItems[i].Tag as BookAndUser).Book);
            }

            foreach (ListViewItem item in dels)
                listView1.Items.Remove(item);
        }
        // provide books for drag data
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;

            List<Book> items = new List<Book>();

            for (int i = 0; i < this.listView1.SelectedItems.Count; i++)
                items.Add((listView1.SelectedItems[i].Tag as BookAndUser).Book);

            DoDragDrop(items, DragDropEffects.Copy);
        }
        // copy selected files
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Book> books = GetSelectedBook();
            if (books.Count == 0)
                return;

            string[] file = new string[books.Count];
            for (int i = 0; i < books.Count; i++)
                file[i] = JianLi3FileServiceManager.Default.GetPath(books[i].File);

            DataObject dataObject = new DataObject();
            dataObject.SetData(DataFormats.FileDrop, file);
            Clipboard.SetDataObject(dataObject, true);
        }
        // when mouse down, populate menu
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // type
                IsBookMenuItem.Checked = false;
                IsPaperMenuItem.Checked = false;
                IsDocMenuItem.Checked = false;
                IsUncheckMenuItem.Checked = false;
                // rate
                LoveMenuItem.Checked = false;
                LikeMenuItem.Checked = false;
                regularToolStripMenuItem.Checked = false;
                noFeelingToolStripMenuItem.Checked = false;
                HateMenuItem1.Checked = false;
                notRateToolStripMenuItem.Checked = false;
                ClipboardCopyMenuItem.Visible = Clipboard.ContainsImage();

                if (this.listView1.SelectedItems.Count == 0)
                {
                    return;
                }
                else if (this.listView1.SelectedItems.Count == 1)
                {

                    BookAndUser ubook = this.listView1.SelectedItems[0].Tag as BookAndUser;

                    if (ubook == null)
                        return;
                    Book book = ubook.Book;                    

                    // book type
                    BookTypeEnum btype = BookHelper.GetBookType(book);

                    switch (btype)
                    {
                        case BookTypeEnum.Book:
                            IsBookMenuItem.Checked = true;
                            break;
                        case BookTypeEnum.Paper:
                            IsPaperMenuItem.Checked = true;
                            break;
                        case BookTypeEnum.Doc:
                            IsDocMenuItem.Checked = true;
                            break;
                        case BookTypeEnum.Uncheck:
                            IsUncheckMenuItem.Checked = true;
                            break;
                        default:
                            IsUncheckMenuItem.Checked = true;
                            break;
                    }

                    UserBooks ubinfo = ubook.UserBook;
                    if(ubinfo == null)
                    {
                        notRateToolStripMenuItem.Checked = true;
                        return;
                    }
                    // book rate
                    BookRateEnum rate = BookHelper.BookRateConvert(ubinfo.BookRate);
                    switch (rate)
                    {
                        case BookRateEnum.Love:
                            LoveMenuItem.Checked = true;
                            break;
                        case BookRateEnum.Like:
                            LikeMenuItem.Checked = true;
                            break;
                        case BookRateEnum.Regular:
                            regularToolStripMenuItem.Checked = true;
                            break;
                        case BookRateEnum.NoFeeling:
                            noFeelingToolStripMenuItem.Checked = true;
                            break;
                        case BookRateEnum.NotLike:
                            HateMenuItem1.Checked = true;
                            break;
                        default:
                            notRateToolStripMenuItem.Checked = true;
                            break;
                    }
                }
                else
                {
                    foreach (ListViewItem item in this.listView1.SelectedItems)
                    {
                    }
                }

            }
        }

        private List<Book> GetSelectedBook()
        {
            if (listView1.SelectedItems.Count == 0)
                return null;

            List<Book> books = new List<Book>();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                BookAndUser ubook = item.Tag as BookAndUser;
                if (ubook != null)
                    books.Add(ubook.Book);
            }
            return books;
        }

        private List<BookAndUser> GetSelectedUserBookInfos()
        {
            if (listView1.SelectedItems.Count == 0)
                return null;

            List<BookAndUser> ubooks = new List<BookAndUser>();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                BookAndUser ubook = item.Tag as BookAndUser;
                if (ubook != null)
                    ubooks.Add(ubook);
            }
            return ubooks;
        }

        #region [  set selected book cover  ]

        private void SelectBookCoverMenuItem_Click(object sender, EventArgs e)
        {
            List<Book> books = GetSelectedBook();
            if (books.Count != 1)
                return;

            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "bmp,jpg,tiff,png,gif文件|*.bmp;*.jpg;*.tiff;*.png;*.gif";
            if (o.ShowDialog() != DialogResult.OK)
                return;

            books[0].BookCover = BookHelper.BookCoverConvert(o.FileName);
            JianLiLinq.Default.DB.SubmitChanges();

            UpdateBookCoverView(listView1.SelectedIndices[0]);

        }

        private void UpdateBookCoverMenuItem_Click(object sender, EventArgs e)
        {
            List<Book> books = GetSelectedBook();
            if (books.Count != 1)
                return;

            Book b = books[0];
            Common2.UpdateBookCover(ref b, b.File);

            UpdateBookCoverView(listView1.SelectedIndices[0]);
        }

        private void ClipboardCopyMenuItem_Click(object sender, EventArgs e)
        {
            List<Book> books = GetSelectedBook();
            if (books.Count != 1)
                return;

            Book book = books[0];

            Binary b = BookHelper.BookCoverFromClipboard();
            if (b == null) return;

            book.BookCover = b;
            JianLiLinq.Default.DB.SubmitChanges();

            UpdateBookCoverView(listView1.SelectedIndices[0]);
        }

        private void UpdateBookCoverView(int idx)
        {
            if (listView1.Items.Count < idx) return;

            BookAndUser b = listView1.Items[idx].Tag as BookAndUser;
            if (b == null) return;
            if (b.Book.BookCover == null) return;

            Image bm = BookHelper.BookCoverConvert(b.Book.BookCover);
            imageList1.Images.Add(bm);
            this.listView1.Items[idx].ImageIndex = imageList1.Images.Count - 1;
        }

        #endregion

        #region [  set selected book rate  ]

        private void notRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.Unrate);
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.Regular);
        }

        private void noFeelingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.NoFeeling);
        }

        private void LikeMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.Like);
        }

        private void LoveMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.Love);
        }

        private void HateMenuItem1_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.NotLike);
        }

        private void SetSelectedBookRate(BookRateEnum rate)
        {
            List<BookAndUser> ubinfos = GetSelectedUserBookInfos();

            if (ubinfos.Count != 1)
                return;

            if (ubinfos[0].UserBook == null)
            {
                ubinfos[0].UserBook = JianLiLinq.Default.CreateUserBook(ubinfos[0].Book);
                JianLiLinq.Default.DB.SubmitChanges();
            }
            ubinfos[0].UserBook.BookRate = BookHelper.BookRateConvert(rate);

            JianLiLinq.Default.DB.SubmitChanges();
        }

        #endregion

        #region [  set selected book type  ]

        private void SetSelectedBookType(BookTypeEnum type)
        {
            List<Book> books = GetSelectedBook();

            foreach (Book book in books)
                BookHelper.SetBookType(book, type);

            JianLiLinq.Default.DB.SubmitChanges();
        }

        private void IsBookMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookType(BookTypeEnum.Book);
        }

        private void IsCheetSheetMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookType(BookTypeEnum.CheetSheet);
        }

        private void IsDocMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookType(BookTypeEnum.Doc);
        }

        private void IsMagzineMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookType(BookTypeEnum.Magzine);
        }

        private void IsPaperMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookType(BookTypeEnum.Paper);
        }

        private void IsPostMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookType(BookTypeEnum.Post);
        }

        private void IsUncheckMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookType(BookTypeEnum.Uncheck);
        }

        #endregion

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 1 || listView1.SelectedItems.Count == 0)
                return;

            BookAndUser bu = (BookAndUser)this.listView1.SelectedItems[0].Tag;
            BookEditForm f = new BookEditForm();

            BookEditPresent p = new BookEditPresent(bu.UserBook, f);

            f.ShowDialog();

            listView1.SelectedItems[0].ToolTipText = bu.UserBook.Book.BookDesc;
            listView1.SelectedItems[0].Text = bu.Book.BookName;
        }

    }
}
