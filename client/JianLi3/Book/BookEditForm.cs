using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3.Books
{
    public partial class BookEditForm : Form,IBookEditView
    {
        public BookEditForm()
        {
            InitializeComponent();
        }

        #region IBookEditView Members

        public string BookTitle
        {
            get
            {
                return this.BookNameTextBox.Text;
            }
            set
            {
                BookNameTextBox.Text = value;
            }
        }

        public string BookSubTitle
        {
            get
            {
                return this.subTitleTextBox.Text;
            }
            set
            {
                this.subTitleTextBox.Text=value;
            }
        }

        public byte BookRate
        {
            get
            {
                if (comboBox1.SelectedIndex == 5)
                    return 255;
                else
                    return (byte)(4 - comboBox1.SelectedIndex);
            }
            set
            {
                if(value !=255)
                    comboBox1.SelectedIndex = 4 - value;
                else
                    comboBox1.SelectedIndex = 5;
            }
        }

        public string BookDescription
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        public string BookPublishHouse
        {
            get
            {
                return textBox2.Text;
            }
            set
            {
                textBox2.Text = value;
            }
        }

        public event EventHandler OnBookInfoChanged;

        public event EventHandler OnBookInfoIniting;

        #endregion

        private void BookEditForm_Load(object sender, EventArgs e)
        {
            if (OnBookInfoIniting != null)
                OnBookInfoIniting(this, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnBookInfoChanged != null)
                OnBookInfoChanged(this, null);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
