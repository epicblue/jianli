using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JianLi3Data;

namespace JianLi3Data.FileService
{
    public interface IJianLiFileService
    {
        string MoveToLib(string filepath,File f);
        string CreateSubFolderInLib(string subpath);
        void MoveInLib(string sourcesubpath,string descsubpath);
        string GetPath(File f);
    }
}
