using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using JianLi3.views;
using JianLi3.Properties;
using JianLi3.editor;
using System.IO;
using JianLi3;
using JianLi3Data.cache;
using JianLi3Data.Client;
using JianLi3Data.FileService;
using JianLi3Data;
using JianLi3.AppSetting;
using JianLi3Data.DataSetting;
using LusongControl;

namespace JianLi3
{
    public partial class Form1 : Form
    {
        string title = "JianLi 3";
        string version = "0.5";
        string modestring = "";
        bool havetoleft = false;
        public Form1()
        {
            // hook the exception
#if DEBUG
#else
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
#endif
            // cache file
            if (!Directory.Exists(FileCache.Default.cachefolder))
                Directory.CreateDirectory(FileCache.Default.cachefolder);

            if (DataSettings.Default.UnInit && !JianLiLinq.Default.DB.DatabaseExists())
            {
                AppSettingForm f = new AppSettingForm();

                if(f.ShowDialog()== DialogResult.Cancel)
                    havetoleft = true;
            }
            DataSettings.Default.OnUserChanged += new EventHandler(Default_OnUserChanged);


            InitializeComponent();


            FileViewer.AppendTab = this.tabControl1;


            // register for python
            UniIronPython.Default.Register(this, "m");
            UniIronPython.Default.Register(JianLiLinq.Default.DB, "db");
            UniIronPythonHelper.ImportWinForm(UniIronPython.Default);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ReportException((Exception)e.ExceptionObject);
            Process.GetCurrentProcess().Kill();
        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ReportException(e.Exception);

            Process.GetCurrentProcess().Kill();
        }

        private void ReportException(Exception ex)
        {

            DataClasses1DataContext DB = new DataClasses1DataContext();
#if OFFICE
            DB.Connection.ConnectionString = @"Data Source=" + DataSettings.Default.ServerName + @"\;Initial Catalog=JianLi;User ID=bee;Password=beegee";
#endif
#if HOME
            DB.Connection.ConnectionString = @"Data Source=" + DataSettings.Default.ServerName + @"\;Initial Catalog=JianLi;Integrated Security=True";
#endif
            ReportException ep = new ReportException();
            ep.Message = ex.Message;
            ep.UserID = DataSettings.Default.User.UserID;
            ep.StackTrace = ex.StackTrace;
            ep.ReportID = Guid.NewGuid();
            ep.UserWords = "";
            ep.Date = DateTime.Now;
            ep.State = 0;
            ep.SoftwareName = "JianLi3";
            ep.SoftwareVersion = version;

            DB.ReportExceptions.InsertOnSubmit(ep);

            DB.SubmitChanges();

            MessageBox.Show("出现未知错误，程序将关闭。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                CloseFile();
        }
        // 关闭书
        private void CloseFile()
        {
            if (this.tabControl1.SelectedIndex < 2)
                return;

            ((BookViewControl)(tabControl1.TabPages[this.tabControl1.SelectedIndex].Controls[0])).CloseFile();
            TabPage seltab = this.tabControl1.SelectedTab;
            int seltabindex = this.tabControl1.SelectedIndex;

            tabControl1.Controls.Remove(seltab);
            tabControl1.SelectTab(seltabindex - 1);
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            TabControl tabControl1 = (TabControl)sender;
            Point pt = new Point(e.X, e.Y);

            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                Rectangle recTab = tabControl1.GetTabRect(i);
                if (recTab.Contains(pt))
                {
                    CloseFile();
                }
            }
        }


        void Default_OnUserChanged(object sender, EventArgs e)
        {
            toolStripButton2.Text = DataSettings.Default.User.UserName;
        }

        private void AddNewBookButton_Click(object sender, EventArgs e)
        {
            AppSettingForm sf = new AppSettingForm();
            sf.ShowDialog();
        }

        void AddFile(string path)
        {
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.tabControl1.SelectedIndex = 1;

                var bs = from b in JianLiLinq.Default.DB.Books
                         where b.BookName.Contains(this.toolStripTextBox1.Text)
                         select b;

                SearchResultBookViewControl.Books = bs.ToArray();


                this.toolStripTextBox1.Focus();
            }
        }
        // 切换用户
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            UserLoginForm uf = new UserLoginForm();
            if (uf.ShowDialog() == DialogResult.OK)
            {
                DataSettings.Default.User = uf.User;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (havetoleft)
                Close();

            this.Text = title + " Ver:" + version;

            #region show mode in title
#if HOME
            modestring += "Home-";
#endif
#if FORCEREMOTE
            modestring += "Force remote-";
#endif
            if (JianLi3FileServiceManager.Default.LocalMode)
                modestring += "Local-";

            if (modestring != "")
                modestring = " Mode: " + modestring.Substring(0,modestring.Length -1);

            this.Text += modestring;

            #endregion

            toolStripButton2.Text = DataSettings.Default.User.UserName;
        }


        // 数据库维护
        // 书本设定默认关键字
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            var p = from b in JianLiLinq.Default.DB.Books
                    select b;
            foreach (Book b in p)
            {
                b.BookDefaultKeyword = b.BookKeywords[0].KeywordId;
            }
            JianLiLinq.Default.DB.SubmitChanges();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!JianLi3FileServiceManager.Default.LocalMode)
                FileCache.Default.Save();
            // 更新用户信息
            DataSettings.Default.User.UserLoginCount++;
            DataSettings.Default.User.UserLastLoginDate = DateTime.Now;
            JianLiLinq.Default.DB.SubmitChanges();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            //HelpForm h = new HelpForm();
            //h.ShowDialog();
            Process.Start("http://htkssy-epicblue/Lists/Team%20Discussion/Flat.aspx?RootFolder=%2fLists%2fTeam%20Discussion%2fJianLi3&FolderCTID=0x012002002AAF53B5865C314E98D0B35A522B9BB4&TopicsView=http%3A%2F%2Fhtkssy-epicblue%2FLists%2FTeam%2520Discussion%2FAllItems.aspx");
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

    }
}
