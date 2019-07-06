using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JianLi3Data.Common
{
    public class JianLiIO
    {
        public static string FindNewFileName(string filepath)
        {
            if (!System.IO.File.Exists(filepath))
                throw new System.Exception("文件不存在,无需更改文件名.");

            string folder = Path.GetDirectoryName(filepath);
            string fn = Path.GetFileNameWithoutExtension(filepath);
            string ext = Path.GetExtension(filepath);

            for (int i = 0; i < 1000; i++)
            {
                filepath = Path.Combine(folder, fn + " (" + i.ToString() + ")" + ext);
                if (!System.IO.File.Exists(filepath))
                    return filepath;
            }
            throw new System.Exception("重命名失败,该目录下文件数太多了.");
        }
    }
}
