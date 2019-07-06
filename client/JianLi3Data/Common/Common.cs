using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using JianLi3Data.FileService;
using System.Threading;
using JianLi3Data;

namespace JianLi3
{
    public class Common2
    {
        public static Process pdf2img(string pdffile, string imgfile)
        {
            //string cmdline = ;
            ProcessStartInfo info = new ProcessStartInfo("\"D:\\Program Files\\PDF2Image v2.0\\pdf2img.exe\"", " -f 1 -l 1 -q 80 -i \"" + pdffile + "\" -o \"" + imgfile + "\"");
            info.UseShellExecute = false;
            Debug.WriteLine(info.FileName + info.Arguments);
            return Process.Start(info);
        }

        // Book
        public static bool UpdateBookCover(ref Book b, JianLi3Data.File file)
        {
            return UpdateBookCover(ref b, JianLi3FileServiceManager.Default.GetPath(file));
        }
        public static bool UpdateBookCover(ref Book b, string filepath)
        {
            return UpdateBookCover(ref b, filepath, true);
        }
        public static bool UpdateBookCover(ref Book b, string filepath, bool submit)
        {
            if (!System.IO.File.Exists(@"D:\Program Files\PDF2Image v2.0\pdf2img.exe"))
                return false;
            string imgfile = "D:\\1.bmp";

            if (filepath.ToUpper().EndsWith(".PDF"))
            {
                if (System.IO.File.Exists(imgfile))
                    System.IO.File.Delete(imgfile);
                Process p = pdf2img(filepath, imgfile);
                p.WaitForExit(10000);
                try
                {
                    b.BookCover = BookHelper.BookCoverConvert(imgfile);
                    if (submit)
                        JianLiLinq.Default.DB.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            return false;
        }
        public static Image GetBookThumbnailImage(Book b)
        {
            MemoryStream ms = new MemoryStream(b.BookCover.ToArray());
            Image img = Image.FromStream(ms);
            return img.GetThumbnailImage(96, 128, null, System.IntPtr.Zero);
        }

    }
}
