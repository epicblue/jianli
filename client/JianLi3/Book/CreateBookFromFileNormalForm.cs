using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using JianLi3.Books;
using JianLi3Data;

namespace JianLi3.editor
{
    public partial class CreateBookFromFileNormalForm : Form,INewBookView
    {
        public CreateBookFromFileNormalForm()
        {
            InitializeComponent();
        }

        #region INewBookView

        public AutoCompleteStringCollection acbooknames
        {
            set
            {
                BookNameTextBox.AutoCompleteCustomSource = value;
            }
            get
            {
                return BookNameTextBox.AutoCompleteCustomSource;
            }
        }

        public byte BookRate
        {
            get { return (byte)(4 - this.comboBox1.SelectedIndex); }
            set { this.comboBox1.SelectedIndex = 4 - value; }
        }
        public string PublishHouse
        {
            set
            {
                this.PublishHouseTextBox.Text = value;
            }
            get
            {
                return this.PublishHouseTextBox.Text;
            }
        }
        public string BookTitle
        {
            get
            {
                return BookNameTextBox.Text;
            }
            set
            {
                BookNameTextBox.Text = value;
            }
        }
        public string BookDescription
        { get { return FileDescTextBox.Text; } }
        public string BookKeywords
        {
            get { return this.KeywordTextBox.Text; }
            set { this.KeywordTextBox.Text = value; }
        }
        public BookTypeEnum BookType { get { throw new NotImplementedException(); } }

        public string BookSubTitle
        {
            get { return this.subTitleTextBox.Text; }
            set { this.subTitleTextBox.Text = value; }
        }
        public string BookVersion
        { get { return this.FileVersionTextBox.Text; } }
        public bool IsResource
        { get { return this.ResourceCheckBox.Checked; } }
        public string FileDescription
        { get { return this.FileDescTextBox.Text; } }
        public string LocalPath
        {
            set
            {
                if (System.IO.File.Exists(value ) == false)
                    throw new Exception("文件不存在");
                localpath = value;
                ShowFile();
            }
        }

        public event EventHandler OnBookTitleChanged;
        public event EventHandler OnViewLoaded;
        public event OnViewCreateDelegate OnBookCreate;
        // 文件路径
        private string localpath; // 需要处理的文件路径

        #endregion

        // 从文件中解析出能够使用的数据
        private char[] spc = new char[] { '.' };
        private void ShowFile()
        {
            // 从文件名中获取信息
            // 获取独立文件名
            string filename = Path.GetFileNameWithoutExtension(localpath);

            string processingname = filename;
            if (filename.Split(spc).Count() > 3)
                processingname = filename.Replace('.', ' ');

            // 获取其中的出版社
            string publishpatten = "(Microsoft Press|OReilly|Addison Wesley|Sams|Apress)";
            PublishHouseTextBox.Text = Regex.Match(processingname, publishpatten, RegexOptions.IgnoreCase).Value;
            processingname = Regex.Replace(processingname, publishpatten, "");

            // 获取其中的日期
            string datepatten = "(Jan|January|February|Feb|Mar|March|Apr|April|May|Jun|June|Jul|July|Aug|August|Sep|September|Dec|December|Oct|October|Nov|November) [0-9]{4}";
            FileDescTextBox.Text = Regex.Match(processingname, datepatten, RegexOptions.IgnoreCase).Value;
            processingname = Regex.Replace(processingname, datepatten, "");

            // 去除比如ebook-XXX的文字
            string grouppatten = "ebook-[a-z]{3}";
            processingname = Regex.Replace(processingname, grouppatten, "", RegexOptions.IgnoreCase);

            BookNameTextBox.Text = processingname.Trim();

            // 检查书籍数据库记录
            BookNameTextBox_Leave(null, null);
        }

        // 通知初始化数据的消息
        private void CreateBookFromFileForm_Load(object sender, EventArgs e)
        {
            if (OnViewLoaded != null)
                OnViewLoaded(this, null);
        }
        // 提交修改
        private void OKButton_Click(object sender, EventArgs e)
        {
            // validate
            if (this.FileVersionTextBox.Text == "")
            {
                MessageBox.Show("文件版本不能为空。");
                return;
            }
            if (this.KeywordTextBox.Text == "")
            {
                MessageBox.Show("关键字不能为空。");
                return;

            }
            bool iscreated = false;


            if (OnBookCreate != null)
                OnBookCreate(ref iscreated);

            if (iscreated)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        // 检查书籍数据库记录
        private void BookNameTextBox_Leave(object sender, EventArgs e)
        {
            if (OnBookTitleChanged != null)
                OnBookTitleChanged(this, null);
        }

        private void AddKeywordButton_Click(object sender, EventArgs e)
        {
            KeywordSelectForm f = new KeywordSelectForm();

            if (f.ShowDialog() == DialogResult.OK)
            {
                if (this.KeywordTextBox.Text != "")
                    this.KeywordTextBox.Text = this.KeywordTextBox.Text + ";";

                this.KeywordTextBox.Text = this.KeywordTextBox.Text + f.path;
            }
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            Process.Start(localpath);
        }
    }
}
