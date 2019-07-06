using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianLi3Data.Client;
using JianLi3Data.FileService;
using JianLi3Data;

namespace JianLi3
{
    // 本类的目的是存放单机版的代码，是Linq和本地操作的混合代码，与纯linq操作代码区别开
    public class LocalAction
    {
        // 移动文件同时更新Files.FilePath
        // 单机版
        // Keyword.SubPath 必须有值
        // 同时不提交数据库
        static public bool MoveKeywordFileToFolder(ref Keywords keyword)
        {
            string surepath = keyword.KeywordSubPath;
            try
            {
                int id = keyword.KeywordID;
                // 应该写入事务
                var p = from bk in keyword.BookKeywords
                        where bk.Book.BookDefaultKeyword == id
                        from f in bk.Book.Files
                        select f;

                foreach (File f in p)
                {
                    if (f.FilePath != surepath + "\\" + System.IO.Path.GetFileName(f.FilePath))
                    {
                        string[] segs = f.FilePath.Split(new char[]{'\\'});

                        if (segs.Length == 1)
                            JianLi3FileServiceManager.Default.MoveInLib(f.FilePath, surepath + "\\" + segs[0]);
                        else
                            JianLi3FileServiceManager.Default.MoveInLib(f.FilePath, surepath + "\\" + segs[1]);

                        f.FilePath = surepath + "\\" + System.IO.Path.GetFileName(f.FilePath);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("内部数据错误被更新，且无法追踪，必须退出程序。");

                if (surepath != "")
                {
                    // 文件复位,复位算法有误
                }
            }
            return false;
        }

        // 更新关键词子路径，
        // Keyword.SubPath 不能有值
        // 同时不提交数据库
        static public bool CreateKeywordDefaultSubPath(ref Keywords keyword)
        {
            keyword.KeywordSubPath = JianLi3FileServiceManager.Default.CreateSubFolderInLib(keyword.KeywordName);
            return true;
        }
    }
}
