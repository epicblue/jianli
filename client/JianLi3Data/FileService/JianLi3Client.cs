using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JianLi3Data.JianLi3Server;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using JianLi3Data.FileService;
using JianLi3Data.cache;
using JianLi3Data.Common;

namespace JianLi3Data.Client
{
    public class JianLi3Client : IJianLiFileService
    {
        public static JianLi3Client Default
        {
            get
            {
                if (def == null)
                {
                    def = new JianLi3Client();
                }
                return def;
            }
        }
        private static JianLi3Client def;

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="subpath">服务器上面,相对lib的目录</param>
        public string DownloadFile(string subpath)
        {
            string path = System.IO.Path.Combine(FileCache.Default.cachefolder, Path.GetFileName(subpath));

            if (System.IO.File.Exists(path))
            {
                path = JianLiIO.FindNewFileName(path);
            }

            FileStream localstream = new FileStream(
                path, FileMode.Create);


            Stream s = client.DownloadFile(subpath);

            byte[] buffer = new byte[4096];
            int readbytes = 0;

            while ((readbytes = s.Read(buffer, 0, buffer.Length)) > 0)
            {
                localstream.Write(buffer, 0, readbytes);
            }

            localstream.Close();
            s.Close();
            return path;
        }

        StreamedClient client = new StreamedClient();

        #region IJianLiFileService 成员

        public string CreateSubFolderInLib(string subpath)
        {
            return client.CreateSubfolderInLib(subpath);
        }
        public string MoveToLib(string filepath, JianLi3Data.File f)
        {
            string serversubpath;

            FileStream stream = new FileStream(filepath, FileMode.Open);
            client.UploadFile(Path.GetFileName(filepath), stream);
            stream.Close();

            string[] segs = f.FilePath.Split(new char[]{'\\'});

            if (segs.Length == 2)
                serversubpath = client.MoveIncontrolFolder(segs[1], segs[0]);
            else
                serversubpath = client.MoveIncontrolFolder(segs[0], "");

            FileCache.Default.AddFile(f.FileID, filepath);

            return serversubpath;
        }

        public void MoveInLib(string sourcesubpath, string descsubpath)
        {
            var proxy = new StreamedClient();
            proxy.MoveFileInLib(sourcesubpath,descsubpath);
        }

        public string GetPath(JianLi3Data.File f)
        {
            string filepath = "";
            if (!FileCache.Default.TryGetFile(f.FileID, out filepath))
            {
                filepath = DownloadFile(f.FilePath);
                FileCache.Default.AddFile(f.FileID, filepath);
            }
            return filepath;
        }

        #endregion
    }
}
