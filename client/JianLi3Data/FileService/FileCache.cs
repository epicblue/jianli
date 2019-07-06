using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using JianLi3Data.Client;
using JianLi3Data.Common;

namespace JianLi3Data.cache
{
    public class FileCache
    {
        #region single

        public static FileCache Default
        {
            get
            {
                if (def == null)
                {
                    def = new FileCache();
                    def.Load();
                }
                return def;
            }
        }
        private static FileCache def;

        #endregion

        readonly string cachefile = @"D:\jlcache\cache.dat";
        public readonly string cachefolder = @"D:\jlcache";

        public void Load()
        {
            if (!System.IO.File.Exists(cachefile))
            {
                if (Directory.Exists(cachefolder))
                {
                    foreach (string filepath in Directory.GetFiles(cachefolder))
                    {
                        System.IO.File.Delete(filepath);
                    }
                }
                return;
            }
            cache.Clear();
            using (Stream s = new FileStream(cachefile, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(s))
                {
                    int count = br.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        cache.Add(br.ReadInt32(), br.ReadString());
                    }
                }
            }

        }

        public void Save()
        {
            if (System.IO.File.Exists(cachefile))
                System.IO.File.Delete(cachefile);

            using (Stream s = new FileStream(cachefile, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(s))
                {
                    bw.Write(cache.Count);
                    foreach (KeyValuePair<int, string> p in cache)
                    {
                        bw.Write(p.Key);
                        bw.Write(p.Value);
                    }
                }
            }
        }

        //将文件添加进缓存
        public void AddFile(int key,string filepath)
        {
            string destpath = filepath;

            if (!filepath.StartsWith(cachefolder))
            {
                if (System.IO.File.Exists(Path.Combine(cachefolder, Path.GetFileName(filepath))))
                destpath = JianLiIO.FindNewFileName(
                    Path.Combine(cachefolder, Path.GetFileName(filepath)));
                else
                    destpath = Path.Combine(cachefolder, Path.GetFileName(filepath));
                System.IO.File.Move(filepath, destpath);
            }
            cache.Add(key, destpath);
        }
        private Dictionary<int, string> cache = new Dictionary<int, string>();

        internal bool TryGetFile(int key, out string filepath)
        {
            bool havefile = cache.TryGetValue(key, out filepath);
            if (havefile)
            {
                havefile = System.IO.File.Exists(filepath);
                if (!havefile)
                    cache.Remove(key);
            }
            return havefile;
        }
    }
}
