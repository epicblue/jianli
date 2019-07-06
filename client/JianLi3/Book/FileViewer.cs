using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using JianLi3Data.cache;
using JianLi3Data.Client;
using JianLi3Data.FileService;
using JianLi3Data;

namespace JianLi3
{
    public class FileViewer
    {
        public static void OpenFile(JianLi3Data.File f)
        {
            if (AppendTab == null)
                return;
            JianLiLinq.Default.SetLastOpenBook(f.Book);
            string filepath = JianLi3FileServiceManager.Default.GetPath(f);
            string fileext = filepath.ToUpper().Substring(filepath.Length - 3, 3);
            switch (fileext)
            {
                case "PDF":
                    try
                    {
                        TabPage tp = new TabPage(f.Book.BookName);
                        BookViewControl bookViewControl1 = new JianLi3.BookViewControl();

                        tp.Controls.Add(bookViewControl1);


                        bookViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
                        bookViewControl1.Location = new System.Drawing.Point(3, 3);
                        bookViewControl1.Name = "bookViewControl"+tp.Controls.Count.ToString();
                        bookViewControl1.Size = new System.Drawing.Size(728, 357);
                        bookViewControl1.TabIndex = 0;
                        bookViewControl1.LoadFile(f);
                        AppendTab.TabPages.Add(tp);
                        AppendTab.SelectedIndex = AppendTab.TabPages.Count - 1;
                    }
                    catch (Exception ex)
                    {
                        Process.Start(filepath);
                    }
                    break;
                case "CHM":
                    if (MessageBox.Show("警告，当前文件为可执行文件，可能包含病毒，是否打开？", "危险！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        Process.Start(filepath);
                    else
                        Process.Start(Path.GetDirectoryName(filepath));
                    break;
                case "EXE":
                    if (MessageBox.Show("警告，当前文件为可执行文件，可能包含病毒，是否打开？", "危险！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        Process.Start(filepath);
                    else
                        Process.Start(Path.GetDirectoryName(filepath));
                    break;
                default:
                    Process.Start(filepath);
                    break;
            }
        }
        public static TabControl AppendTab = null;
    }
}
