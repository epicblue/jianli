using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JianLi3Data.Client;
using System.Diagnostics;
using JianLi3Data;
using JianLi3Data.Properties;
using JianLi3Data.DataSetting;

namespace JianLi3Data.FileService
{
    public class JianLi3FileServiceManager:IJianLiFileService
    {
        public static JianLi3FileServiceManager Default
        {
            get
            {
                if (def == null)
                {
                    def = new JianLi3FileServiceManager();

                    DataSettings.Default.OnServerNameChanged += new EventHandler(def.Default_OnServerNameChanged);
                    def.Default_OnServerNameChanged(def, null);

                    Debug.WriteLine("本地模式："+def.LocalMode.ToString());
                }
                return def;
            }
        }

        // update service
        void Default_OnServerNameChanged(object sender, EventArgs e)
        {
            if (LocalMode)
                service = new JianLi3Local();
            else
                service = JianLi3Client.Default;
        }
        // decide localmode
        public bool LocalMode
        {
            get
            {

#if FORCEREMOTE
                return false;
#else
                return (Environment.MachineName == DataSettings.Default.ServerName.ToUpper());
#endif
            }
        }

        private IJianLiFileService service;
        private static JianLi3FileServiceManager def;

        #region IJianLiFileService 成员

        public string MoveToLib(string filepath,File f)
        {
            return service.MoveToLib(filepath, f);
        }
        public string CreateSubFolderInLib(string subpath)
        {
            return service.CreateSubFolderInLib(subpath);
        }
        public void MoveInLib(string sourcesubpath, string destsubpath)
        {
            service.MoveInLib(sourcesubpath, destsubpath);
        }

        public string GetPath(File f)
        {
            return service.GetPath(f);
        }

        #endregion
    }
}
