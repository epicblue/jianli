using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace WCF.ServiceLib.Message
{
    /// <summary>
    /// IStreamed类
    /// </summary>
    public class Streamed : IStreamed
    {
        public Streamed()
        {
        }
#if HOME
        /// <summary>
        /// 新文件目录
        /// </summary>
        public static string incomingfolder = @"F:\编程\Book\incoming";
        public static string libfolder = @"F:\编程\Book\lib";
#endif
#if OFFICE
        public static string incomingfolder = @"C:\cache\2008.06.19 JianLi\server\incoming";
        public static string libfolder = @"C:\cache\2008.06.19 JianLi\server\lib\book";
#endif
        /// <summary>
        /// 上传文件(对客户端来说)
        /// </summary>
        /// <param name="fileWrapper">WCF.ServiceLib.Message.FileWrapper</param>
        public void UploadFile(FileWrapper fileWrapper)
        {
            string filename = Path.GetFileNameWithoutExtension(fileWrapper.FilePath);
            string fileext = Path.GetExtension(fileWrapper.FilePath);
            string newpath = Path.Combine(incomingfolder, filename + fileext);

            var sourceStream = fileWrapper.FileData;

            if (File.Exists(newpath))
                throw new System.Exception(DateTime.Now.ToLongTimeString() + "上传文件已经存在:" + newpath);


            try
            {
                var targetStream = new FileStream(newpath,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None);

                var buffer = new byte[4096];
                var count = 0;

                while ((count = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    targetStream.Write(buffer, 0, count);

                targetStream.Close();
                sourceStream.Close();

                LogEntry log = new LogEntry();
                log.Message = newpath + "上传成功.";
                log.Categories.Add("文件上传");
                Logger.Write(log);

                Console.WriteLine(DateTime.Now.ToLongTimeString() + log.Message);
                return;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 下载文件(对客户端来说),仅提供服务器端incontrol目录下的文件下载.
        /// </summary>
        /// <param name="controlpath">相对路径,相对于incontrol</param>
        /// <returns></returns>
        public Stream DownloadFile(string subpath)
        {
            string path = Path.Combine(libfolder, subpath);
            if (!File.Exists(path))
            {
                LogEntry log1 = new LogEntry();
                log1.Message = "请求的文件不存在：" + path;
                log1.Categories.Add("下载错误");
                Logger.Write(log1);

                throw new System.Exception(DateTime.Now.ToLongTimeString() + log1.Message );
            }

            LogEntry log = new LogEntry();
            log.Message = " 请求文件：" + path;
            log.Categories.Add("文件下载");
            Logger.Write(log);

            Console.WriteLine(DateTime.Now.ToLongTimeString() + log.Message);
            Stream s = new FileStream(path,FileMode.Open);
            return s;
        }

        /// <summary>
        /// 将文件从临时文件夹中转移出来.
        /// </summary>
        /// <param name="filename">文件名,不包括文件路径.</param>
        /// <returns></returns>
        public string MoveIncontrolFolder(string filename,string subpath)
        {
            if (!File.Exists(Path.Combine(incomingfolder, filename)))
                throw new System.IO.FileNotFoundException(filename);
            
            string path = Path.Combine(libfolder, subpath+"\\"+filename);

            if (File.Exists(path))
                path = FindNewFileName(path);

            File.Move(Path.Combine(incomingfolder, filename), path);

            LogEntry log = new LogEntry();
            log.Message = " 移动到文件库：" + subpath + ";" + filename;
            log.Categories.Add("文件下载");
            Logger.Write(log);

            Console.WriteLine(DateTime.Now.ToLongTimeString() + log.Message);
            return path.Substring(incomingfolder.Length+1,path.Length-incomingfolder.Length-1);
        }

        private string FindNewFileName(string filepath)
        {
            if (!File.Exists(filepath))
                throw new System.Exception(DateTime.Now.ToLongTimeString() + " 文件不存在,无需更改文件名.");

            string folder = Path.GetDirectoryName(filepath);
            string fn = Path.GetFileNameWithoutExtension(filepath);
            string ext = Path.GetExtension(filepath);

            for (int i = 0; i < 1000; i++)
            {
                filepath = Path.Combine(folder, fn + " ("+i.ToString()+")" + ext);
                if (!File.Exists(filepath))
                    return filepath;
            }
            throw new System.Exception(DateTime.Now.ToLongTimeString() + " 重命名失败,该目录下文件数太多了.");
        }

        /// <summary>
        /// 在incontrol目录中移动文件.
        /// </summary>
        /// <param name="sourcepath">相对路径,相对于incontrol目录</param>
        /// <param name="descpath">相对路径,相对于incontrol目录</param>
        /// <returns></returns>
        public string MoveFileInLib(string sourcepath, string descpath)
        {
            string sp = Path.Combine(libfolder, sourcepath);

            if (!File.Exists(sp))
                throw new FileNotFoundException(sourcepath);

            string dp = Path.Combine(libfolder, descpath);

            if (File.Exists(Path.Combine(libfolder,descpath)))
                dp = FindNewFileName(Path.Combine(libfolder, descpath));

            File.Move(sp, dp);

            LogEntry log = new LogEntry();
            log.Message = " 文件库 移动文件：" + sourcepath + ";" + descpath;
            log.Categories.Add("文件移动");
            Logger.Write(log);

            Console.WriteLine(DateTime.Now.ToLongTimeString() + log.Message);

            return dp;
        }

        /// <summary>
        /// 建立唯一子目录
        /// </summary>
        /// <param name="subpath">相对lib的子目录</param>
        /// <returns>相对lib的子目录</returns>
        public string CreateSubfolderInLib(string subpath)
        {
            subpath = RemoveInvalidPathChar(subpath);
            string path = System.IO.Path.Combine(libfolder,subpath );
            string finalpath = path;
            int i = 1;
            while (System.IO.Directory.Exists(finalpath))
            {
                finalpath = System.IO.Path.Combine(libfolder, subpath + " (" + i.ToString() + ")");
                i++;
            }

            System.IO.Directory.CreateDirectory(finalpath);

            LogEntry log = new LogEntry();
            log.Message = " 文件库 建立子文件夹：" + subpath;
            log.Categories.Add("文件移动");
            Logger.Write(log);

            Console.WriteLine(DateTime.Now.ToLongTimeString() + log.Message);

            return finalpath.Substring(libfolder.Length + 1, finalpath.Length - libfolder.Length - 1);
        }

        // 去除不该出现在目录中的字符
        public static string RemoveInvalidPathChar(string input)
        {
            char[] s = System.IO.Path.GetInvalidPathChars();
            string[] paths = input.Split(s, StringSplitOptions.RemoveEmptyEntries);
            string path = "";
            foreach (string seg in paths)
                path += seg;
            return path;
        }
    }
}
