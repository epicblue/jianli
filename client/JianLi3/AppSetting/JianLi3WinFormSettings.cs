using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace JianLi3
{
    public class JianLi3WinFormSettings
    {
        public JianLi3WinFormSettings()
        {
        }
        private static JianLi3WinFormSettings def;
        public static JianLi3WinFormSettings Default
        {
            get
            {
                if (def == null)
                    def = new JianLi3WinFormSettings();
                return def;
            }        
        }
        public bool ShowBookComment
        {
            set
            {
                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3WinForm", true);

                jlk.SetValue("ShowBookComment", value);

                jlk.Close();
                swk.Close();

                if (ShowBookCommentChanged != null)
                    ShowBookCommentChanged(this, null);

            }
            get
            {
                RegistryKey k = Registry.CurrentUser;
                RegistryKey swk = k.OpenSubKey("Software");
                RegistryKey jlk = swk.OpenSubKey("JianLi3WinForm");

                if (jlk == null)
                {
                    Init();
                    jlk = swk.OpenSubKey("JianLi3WinForm");
                }

                return Boolean.Parse(jlk.GetValue("ShowBookComment").ToString());
            }
        }

        public event EventHandler ShowBookCommentChanged;

        private void Init()
        {
            RegistryKey k = Registry.CurrentUser;
            RegistryKey swk = k.OpenSubKey("Software", true);
            RegistryKey jlk = swk.OpenSubKey("JianLi3WinForm", true);

            if (jlk == null)
            {
                jlk = swk.CreateSubKey("JianLi3WinForm");
                jlk.SetValue("ShowBookComment", true);
                jlk.Close();
                swk.Close();
            }
        }
    }
}
