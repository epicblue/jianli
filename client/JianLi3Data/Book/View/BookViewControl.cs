using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JianLi3Data.cache;
using JianLi3Data.Client;
using System.Threading;
using JianLi3Data.FileService;
using JianLi3Data;

namespace JianLi3
{
    public partial class BookViewControl : UserControl
    {
        public BookViewControl()
        {
            InitializeComponent();
        }
        public void ReadFile()
        {
        }

        public void LoadFile(JianLi3Data.File f)
        {
            string filepath = JianLi3FileServiceManager.Default.GetPath(f);
            if (System.IO.File.Exists(filepath))
            {
                axAcroPDF1.setShowToolbar(false);
                axAcroPDF1.setShowScrollbars(false);
                axAcroPDF1.setLayoutMode("SinglePage");
                axAcroPDF1.setPageMode("none");
                axAcroPDF1.setView("FitH");
                if (this.axAcroPDF1.LoadFile(filepath) == false)
                    throw new Exception("打开失败。" + filepath);
            }
            else
                throw new Exception("文件不存在:" + filepath);
            _file = f;
            startTime = DateTime.Now;
        }
        JianLi3Data.File _file = null;
        DateTime startTime;

        public void CloseFile()
        {
            TimeSpan t = DateTime.Now - startTime;
            JianLiLinq.Default.EndRead(_file.Book, t);
        }
    }
}
