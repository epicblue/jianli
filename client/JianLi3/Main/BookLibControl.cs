using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using JianLi3.Properties;
using JianLi3Data;
using JianLi3Data.JLBook.User;
using JianLi3.Books;
using JianLi3.BookComments;
using JianLi3.Main;
using JianLi3Data.DataSetting;
using LusongControl;

namespace JianLi3
{
    public partial class BookLibControl : UserControl
    {
        // 列出关键字下所有的书和用户相关的数据
        Keywords curkeywords;
        JianLi3Data.DataClasses1DataContext db;

        public BookLibControl()
        {
            InitializeComponent();

            if (!JianLi3WinFormSettings.Default.ShowBookComment)
                splitContainer4.Panel2Collapsed = true;

            db = JianLiLinq.Default.DB;

            imageList1.Images[0] = imageList1.Images[0].GetThumbnailImage(96, 128, null, IntPtr.Zero);
            listView1.LargeImageList = imageList1;
            listView1.SmallImageList = imageList1;

            this.categoryAndKeywordControl1.AfterSelectKeyword += new JianLi3.views.AfterSelectKeywordDelegate(ShowKeywordBook);
            JianLi3WinFormSettings.Default.ShowBookCommentChanged += new EventHandler(Default_ShowBookCommentChanged);

        }
        private void BookEditMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 1 || listView1.SelectedItems.Count == 0)
                return;

            BookAndUser bu = (BookAndUser)this.listView1.SelectedItems[0].Tag;
            BookEditForm f = new BookEditForm();

            BookEditPresent p = new BookEditPresent(bu.UserBook, f);

            f.ShowDialog();

            listView1.SelectedItems[0].ToolTipText = bu.UserBook.Book.BookDesc;
        }

        private void CommentMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 1 || listView1.SelectedItems.Count == 0)
                return;

            Book b = ((BookAndUser)this.listView1.SelectedItems[0].Tag).Book;

            CreateCommentForm f = new CreateCommentForm();
            f.Book = b;

            f.ShowDialog();
        }

        void Default_ShowBookCommentChanged(object sender, EventArgs e)
        {
            splitContainer4.Panel2Collapsed = !JianLi3WinFormSettings.Default.ShowBookComment;
        }

        private void DelBookMenuItem_Click(object sender, EventArgs e)
        {
            List<ListViewItem> delitems = new List<ListViewItem>();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                delitems.Add(item);
                Book b = ((BookAndUser)(item.Tag)).Book;
                JianLiLinq.Default.DelBookKeyword(b, curkeywords);
            }

            foreach (ListViewItem lvitem in delitems)
                listView1.Items.Remove(lvitem);
        }

        private void item_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                if (((ToolStripMenuItem)sender).Tag is JianLi3Data.File)
                {
                    FileViewer.OpenFile(((JianLi3Data.File)((ToolStripMenuItem)sender).Tag));
                }
            }
        }

        // 双击时打开默认文件
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                BookAndUser bu = (BookAndUser)(listView1.SelectedItems[0].Tag);
                Book b = bu.Book;

                if (b.Files != null)
                    FileViewer.OpenFile(b.File);

                if (bu.UserBook == null)
                {
                    UserBooks ub = JianLiLinq.Default.CreateUserBook(b);
                    ub.BookReadCounts = 1;
                    JianLiLinq.Default.DB.SubmitChanges();
                }
                else
                {
                    bu.UserBook.BookReadCounts++;
                    db.SubmitChanges();
                }

            }
        }

        // 拖拽
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;

            List<Book> items = new List<Book>();

            for (int i = 0; i < this.listView1.SelectedItems.Count; i++)
                items.Add(((BookAndUser)(listView1.SelectedItems[0].Tag)).Book);

            DoDragDrop(items, DragDropEffects.Copy);

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);

            if (info.Item is ListViewItem && e.Button == MouseButtons.Right)
            {
                listView1.SelectedItems.Clear();
                info.Item.Selected = true;
                PopulateMenu();
            }
            // 判断是否需要显示评论
            if (splitContainer4.Panel2Collapsed)
                return;

            if (listView1.SelectedItems.Count > 1 || listView1.SelectedItems.Count == 0)
                return;

            ShowBookComment();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            PopulateMenu();
        }

        private void PopulateMenu()
        {
            this.VersionsMenuItem.Visible = false;
            this.VersionsMenuItem.DropDownItems.Clear();

            if (this.listView1.SelectedItems.Count != 1)
                return;
            BookAndUser bu = (BookAndUser)this.listView1.SelectedItems[0].Tag;

            JianLi3Data.File[] fs = JianLiLinq.Default.GetBookFiles(bu.Book);

            LoveMenuItem.Checked = false;
            LikeMenuItem.Checked = false;
            RegularMenuItem.Checked = false;
            NoFeelingMenuItem.Checked = false;
            HateMenuItem.Checked = false;

            if(bu.UserBook!=null)
                ShowUserBookRate(bu.UserBook.BookRate);

            if (fs.Count() == 1)
                return;
            else
                this.VersionsMenuItem.Visible = true;

            foreach (JianLi3Data.File f in fs)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Tag = f;
                item.Text = f.FileVersion;
                item.Click += new EventHandler(item_Click);
                this.VersionsMenuItem.DropDownItems.Add(item);
            }
        }

        private void SelectCoverMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                OpenFileDialog o = new OpenFileDialog();
                o.Filter = "bmp,jpg,tiff,png,gif文件|*.bmp;*.jpg;*.tiff;*.png;*.gif";
                if (o.ShowDialog() == DialogResult.OK)
                {
                    Book b = ((BookAndUser)listView1.SelectedItems[0].Tag).Book;
                    b.BookCover = BookHelper.BookCoverConvert(o.FileName);
                    db.SubmitChanges();

                    Image bitmap = BookHelper.BookCoverConvert(b.BookCover);
                    imageList1.Images.Add(bitmap);
                    listView1.SelectedItems[0].ImageIndex = imageList1.Images.Count - 1;
                }
            }
        }

        private void ShowBookComment()
        {
            // get book
            Book b = ((BookAndUser)this.listView1.SelectedItems[0].Tag).Book;
            bookCommentView1.ShowBookComment(b);
        }

        private void ShowKeywordBook(Keywords keywords)
        {
            listView1.Items.Clear();
            // 选出所有的书
            var bs = from bk in keywords.BookKeywords
                     select bk.Book;

            Image image = imageList1.Images[0];
            imageList1.Images.Clear();
            imageList1.Images.Add(image);

            foreach (Book b in bs)
            {
                // 加入用户与书相关的数据
                BookAndUser bu = new BookAndUser();
                bu.Book = b;
                bu.UserBook = JianLiLinq.Default.GetUserBook(b);

                // 配置ListViewItem
                ListViewItem i = new ListViewItem();
                i.Text = b.BookName;
                i.Tag = bu;
                string names = "";
                foreach (User u in JianLiLinq.Default.GetBookContributors(b))
                {
                    names = names + u.UserName + "  ";
                }
                i.ToolTipText = "贡献者：" + names + Environment.NewLine + "简介：" + b.BookDesc;
                if (b.BookCover != null)
                {
                    Image bm = Common2.GetBookThumbnailImage(b);
                    imageList1.Images.Add(bm);
                    i.ImageIndex = imageList1.Images.Count - 1;
                }
                else
                {
                    i.ImageIndex = 0;
                }
                //
                this.listView1.Items.Add(i);
            }
            curkeywords = keywords;
        }

        private void ShowUserBookRate(int bookrate)
        {
            LoveMenuItem.Checked = false;
            LikeMenuItem.Checked = false;
            this.RegularMenuItem.Checked = false;
            this.NoFeelingMenuItem.Checked = false;
            this.HateMenuItem.Checked = false;
            switch (bookrate)
            {
                case 0:
                    this.HateMenuItem.Checked = true;
                    break;
                case 1:
                    this.NoFeelingMenuItem.Checked = true;
                    break;
                case 2:
                    this.RegularMenuItem.Checked = true;
                    break;
                case 3:
                    LikeMenuItem.Checked = true;
                    break;
                case 4:
                    LoveMenuItem.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void 更新封面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                // PDF ~!!
                Book b = ((BookAndUser)(listView1.SelectedItems[0].Tag)).Book;

                if (Common2.UpdateBookCover(ref b, b.File))
                {
                    imageList1.Images.Add(Common2.GetBookThumbnailImage(b));
                    listView1.SelectedItems[0].ImageIndex = imageList1.Images.Count - 1;
                }
            }
        }

        private void SetSelectedBookRate(BookRateEnum rate)
        {
            if (this.listView1.SelectedItems.Count != 1)
                return;
            BookAndUser bu = this.listView1.SelectedItems[0].Tag as BookAndUser;

            if (bu.UserBook == null)
            {
                bu.UserBook = JianLiLinq.Default.GetUserBook(bu.Book);
                if(bu.UserBook == null)
                    bu.UserBook = JianLiLinq.Default.CreateUserBook(bu.Book);
            }

            bu.UserBook.BookRate = BookHelper.BookRateConvert(rate);
            JianLiLinq.Default.DB.SubmitChanges();
        }

        private void 不喜欢ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.NotLike);
        }

        private void 非常喜欢ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.Love);
        }

        private void 没有感觉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.NoFeeling);
        }

        private void 喜欢ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.Like);
        }

        private void 正规ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectedBookRate(BookRateEnum.Regular);
        }

    }
}
