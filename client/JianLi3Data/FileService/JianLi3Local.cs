using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JianLi3Data.Properties;
using JianLi3Data.Common;
using JianLi3Data.DataSetting;

namespace JianLi3Data.FileService
{
    public class JianLi3Local:IJianLiFileService
    {
        public JianLi3Local()
        {
            incomingfolder = DataSettings.Default.IncomingFolder;
            otherfolder = DataSettings.Default.OtherFolder;
        }

        private string incomingfolder = "";

        private string BookLibFolder
        {
            get
            {
                return DataSettings.Default.LibFolder + @"\Book";
            }
        }

        string otherfolder = "";

        #region IJianLiFileService 成员

        public string MoveToLib(string filepath, JianLi3Data.File f)
        {
            string destpath = Path.Combine(BookLibFolder,f.FilePath);

            if (System.IO.File.Exists(destpath))
                destpath = JianLiIO.FindNewFileName(destpath);

            System.IO.File.Move(filepath, destpath);

            return destpath.Substring(BookLibFolder.Length + 1, destpath.Length - BookLibFolder.Length - 1);
        }
        public string CreateSubFolderInLib(string subpath)
        {
            string destpath = BookLibFolder + @"\" + subpath;

            if (Directory.Exists(destpath))
            {
                for (int i = 0; i < 100; i++)
                {
                    if (Directory.Exists(destpath))
                    {
                        destpath = destpath + "(" + i.ToString() + ")";
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Directory.CreateDirectory(destpath);

            return destpath.Substring(BookLibFolder.Length+1,destpath.Length-BookLibFolder.Length -1);
        }
        public void MoveInLib(string sourcesubpath, string descsubpath)
        {
            System.IO.File.Move(Path.Combine(BookLibFolder, sourcesubpath), Path.Combine(BookLibFolder, descsubpath));
        }
        public string GetPath(JianLi3Data.File f)
        {
            return Path.Combine(BookLibFolder,f.FilePath);
        }

        #endregion
    }
}
