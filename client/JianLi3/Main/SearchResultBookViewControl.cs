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

namespace JianLi3.views
{
    public partial class SearchResultBookViewControl : UserControl
    {
        public SearchResultBookViewControl()
        {
            InitializeComponent();
            Default = this;
        }

        private static SearchResultBookViewControl Default = null;

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
                i.Tag = b;
                i.ToolTipText = b.BookDesc;
                if (b.BookCover != null)
                {
                    MemoryStream ms = new MemoryStream(b.BookCover.ToArray());
                    Image bm = Image.FromStream(ms);
                    bm = bm.GetThumbnailImage(96, 128, null, System.IntPtr.Zero);
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

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Book b = (Book)(listView1.SelectedItems[0].Tag);
                if (b.Files != null)
                    FileViewer.OpenFile(b.File);
            }
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;

            List<Book> items = new List<Book>();

            for (int i = 0; i < this.listView1.SelectedItems.Count; i++)
                items.Add(((Book)listView1.SelectedItems[i].Tag));

            DoDragDrop(items, DragDropEffects.Copy);
        }

        internal void DeleteSelect()
        {
            if (this.listView1.SelectedItems.Count == 0)
                return;

            List<ListViewItem> dels = new List<ListViewItem>();
            for (int i = 0; i < this.listView1.SelectedItems.Count; i++)
            {
                dels.Add(listView1.SelectedItems[i]);
                JianLiLinq.Default.DelBook(((Book)listView1.SelectedItems[i].Tag));
            }

            foreach (ListViewItem item in dels)
                listView1.Items.Remove(item);
        }

        private void DelBookMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelect();
        }
    }
}
