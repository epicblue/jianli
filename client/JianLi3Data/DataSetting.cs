using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace JianLi3Data.DataSetting
{
    public class DataSettings
    {
        static DataSettings def;
        public static DataSettings Default
        {
            get
            {
                if (def == null)
                    def = new DataSettings();
                return def;
            }
        }
        public bool UnInit
        {
            get
            {
                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3");
                return jlk == null;
            }
        }

#if HOME
        private const string IncomingFolderDefault = @"F:\编程\Book\incoming";
        private const string LibFolderDefault = @"F:\编程\Book\Lib";
        private const string OtherFolderDefault = @"F:\TDDOWNLOAD\Other";
        private const string UserNameDefault = "unknow";
        private const string ServerNameDefault = "powerbox-d8kz18";
#endif
#if OFFICE
        private const string IncomingFolderDefault = @"C:\jianli\incomingfolder";
        private const string LibFolderDefault = @"C:\jianli\libfolder";
        private const string OtherFolderDefault = @"C:\jianli\otherfolder";
        private const string UserNameDefault = "unknow";
        private const string ServerNameDefault = "htkssy-epicblue";
        private readonly byte[] bs = { 0x00, 0x01, 0x2a };
#endif

        private void Init()
        {
            RegistryKey k = Registry.CurrentUser;
            RegistryKey swk = k.OpenSubKey("Software",true);
            RegistryKey jlk = swk.OpenSubKey("JianLi3", true);

            if (jlk == null)
            {
                jlk = swk.CreateSubKey("JianLi3");
                jlk.SetValue("ServerName", ServerNameDefault);
                jlk.SetValue("IncomingFolder", IncomingFolderDefault);
                jlk.SetValue("LibFolder", LibFolderDefault);
                jlk.SetValue("OtherFolder", OtherFolderDefault);
                jlk.SetValue("UserName",UserNameDefault);
                jlk.Close();
                swk.Close();

                serverName = ServerNameDefault;
                incomingFolder = IncomingFolderDefault;
                libFolder = LibFolderDefault;
                otherFolder = OtherFolderDefault;

                user = JianLiLinq.Default.UserCreateOrGet(UserNameDefault);
            }
        }

        private string serverName;
        public string ServerName
        {// 必须先Get然后Set
            get
            {
                if (serverName != null)
                    return serverName;
                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3");

                if (jlk == null)
                    Init();
                else
                    serverName = jlk.GetValue("ServerName").ToString();

                return serverName;
            }
            set
            {
                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3",true);

                jlk.SetValue("ServerName",value);

                jlk.Close();
                swk.Close();

                serverName = value;

                if (OnServerNameChanged != null)
                    OnServerNameChanged(this, null);
            }
        }
        public event EventHandler OnServerNameChanged;
        public event EventHandler OnIncomingFolderChanged;

        private string incomingFolder;
        public string IncomingFolder
        {
            set
            {
                if (!Directory.Exists(value))
                {
                    if (!Directory.Exists(IncomingFolderDefault))
                        Directory.CreateDirectory(IncomingFolderDefault);
                    value = IncomingFolderDefault;
                }

                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3", true);

                jlk.SetValue("IncomingFolder", value);

                jlk.Close();
                swk.Close();

                incomingFolder = value;
                if (OnIncomingFolderChanged != null)
                    OnIncomingFolderChanged(this, null);
            }
            get
            {
                if (incomingFolder != null)
                    return incomingFolder;

                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3");

                if (jlk == null)
                    Init();
                else
                    incomingFolder = jlk.GetValue("IncomingFolder").ToString();
                return incomingFolder; 
            }
        }

        private string otherFolder;
        public string OtherFolder
        {
            set
            {
                if (!Directory.Exists(value))
                {
                    if (!Directory.Exists(OtherFolderDefault))
                        Directory.CreateDirectory(OtherFolderDefault);
                    value = IncomingFolderDefault;
                }

                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3", true);

                jlk.SetValue("OtherFolder", value);

                jlk.Close();
                swk.Close();

                otherFolder = value;
            }
            get
            {
                if (otherFolder != null)
                    return otherFolder;

                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3");

                if (jlk == null)
                {
                    Init();
                    jlk = swk.OpenSubKey("JianLi3");
                }
                else
                    otherFolder = jlk.GetValue("OtherFolder").ToString();
                return otherFolder;
            }
        }

        private string libFolder;
        public string LibFolder
        {
            set
            {
                if (!Directory.Exists(value))
                {
                    if (!Directory.Exists(LibFolderDefault))
                        Directory.CreateDirectory(LibFolderDefault);
                    value = LibFolderDefault;
                }

                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3", true);

                jlk.SetValue("LibFolder", value);

                jlk.Close();
                swk.Close();

                libFolder = value;
            }
            get
            {
                if (libFolder != null)
                    return libFolder;

                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3");

                if (jlk == null)
                    Init();
                else
                    LibFolder = jlk.GetValue("LibFolder").ToString();
                return LibFolder;
            }
        }

        public string UserName
        {
            set
            {
                User = JianLiLinq.Default.UserCreateOrGet(value);
            }
            get
            {
                return User.UserName;
            }
        }

        private static void SaveUserName(string value)
        {

            RegistryKey k = Registry.CurrentUser;
            RegistryKey swk = k.OpenSubKey("Software");
            RegistryKey jlk = swk.OpenSubKey("JianLi3", true);

            jlk.SetValue("UserName", value);

            jlk.Close();
            swk.Close();
        }


        public event EventHandler OnUserChanged;
        private User user = null;
        public User User
        {
            get
            {
                if (user != null)
                    return user;

                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3");

                if (jlk == null)
                    Init();
                else
                    user = JianLiLinq.Default.UserCreateOrGet(jlk.GetValue("UserName").ToString());

                return user;
            }
            set
            {
                SaveUserName(value.UserName);

                user = value;

                if (OnUserChanged != null)
                    OnUserChanged(this, null);
            }
        }
    }
}
