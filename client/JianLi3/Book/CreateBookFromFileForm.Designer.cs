namespace JianLi3
{
    partial class CreateBookFromFileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateBookFromFileForm));
            this.OKButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BookNameTextBox = new System.Windows.Forms.TextBox();
            this.FileVersionTextBox = new System.Windows.Forms.TextBox();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.AddKeywordButton = new System.Windows.Forms.Button();
            this.ResourceCheckBox = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nextbutton = new System.Windows.Forms.Button();
            this.prebutton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.PublishHouseTextBox = new System.Windows.Forms.TextBox();
            this.FileDescTextBox = new System.Windows.Forms.TextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.subTitleTextBox = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(228, 381);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(57, 39);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "* 书名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "* 版本";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "* 关键词";
            // 
            // BookNameTextBox
            // 
            this.BookNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BookNameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.BookNameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.BookNameTextBox.Location = new System.Drawing.Point(65, 12);
            this.BookNameTextBox.Name = "BookNameTextBox";
            this.BookNameTextBox.Size = new System.Drawing.Size(673, 20);
            this.BookNameTextBox.TabIndex = 4;
            this.BookNameTextBox.Leave += new System.EventHandler(this.BookNameTextBox_Leave);
            // 
            // FileVersionTextBox
            // 
            this.FileVersionTextBox.Location = new System.Drawing.Point(65, 65);
            this.FileVersionTextBox.Name = "FileVersionTextBox";
            this.FileVersionTextBox.Size = new System.Drawing.Size(157, 20);
            this.FileVersionTextBox.TabIndex = 5;
            // 
            // KeywordTextBox
            // 
            this.KeywordTextBox.Enabled = false;
            this.KeywordTextBox.Location = new System.Drawing.Point(65, 93);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(157, 20);
            this.KeywordTextBox.TabIndex = 6;
            // 
            // AddKeywordButton
            // 
            this.AddKeywordButton.Location = new System.Drawing.Point(228, 91);
            this.AddKeywordButton.Name = "AddKeywordButton";
            this.AddKeywordButton.Size = new System.Drawing.Size(42, 23);
            this.AddKeywordButton.TabIndex = 8;
            this.AddKeywordButton.Text = "添加";
            this.AddKeywordButton.UseVisualStyleBackColor = true;
            this.AddKeywordButton.Click += new System.EventHandler(this.AddKeywordButton_Click);
            // 
            // ResourceCheckBox
            // 
            this.ResourceCheckBox.AutoSize = true;
            this.ResourceCheckBox.Location = new System.Drawing.Point(228, 67);
            this.ResourceCheckBox.Name = "ResourceCheckBox";
            this.ResourceCheckBox.Size = new System.Drawing.Size(50, 17);
            this.ResourceCheckBox.TabIndex = 9;
            this.ResourceCheckBox.Text = "资源";
            this.ResourceCheckBox.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "当前",
            "长期",
            "关注",
            "偶尔",
            "无视"});
            this.comboBox1.Location = new System.Drawing.Point(65, 121);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "关注程度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "书籍描述";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "文件描述";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 148);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 67);
            this.textBox1.TabIndex = 15;
            // 
            // nextbutton
            // 
            this.nextbutton.Location = new System.Drawing.Point(261, 287);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(24, 23);
            this.nextbutton.TabIndex = 16;
            this.nextbutton.Text = ">";
            this.nextbutton.UseVisualStyleBackColor = true;
            this.nextbutton.Click += new System.EventHandler(this.nextbutton_Click);
            // 
            // prebutton
            // 
            this.prebutton.Location = new System.Drawing.Point(261, 258);
            this.prebutton.Name = "prebutton";
            this.prebutton.Size = new System.Drawing.Size(24, 23);
            this.prebutton.TabIndex = 17;
            this.prebutton.Text = "<";
            this.prebutton.UseVisualStyleBackColor = true;
            this.prebutton.Click += new System.EventHandler(this.prebutton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "出版社";
            // 
            // PublishHouseTextBox
            // 
            this.PublishHouseTextBox.Location = new System.Drawing.Point(65, 294);
            this.PublishHouseTextBox.Name = "PublishHouseTextBox";
            this.PublishHouseTextBox.Size = new System.Drawing.Size(157, 20);
            this.PublishHouseTextBox.TabIndex = 19;
            // 
            // FileDescTextBox
            // 
            this.FileDescTextBox.Location = new System.Drawing.Point(65, 224);
            this.FileDescTextBox.Multiline = true;
            this.FileDescTextBox.Name = "FileDescTextBox";
            this.FileDescTextBox.Size = new System.Drawing.Size(157, 64);
            this.FileDescTextBox.TabIndex = 20;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(228, 121);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(57, 23);
            this.OpenFileButton.TabIndex = 21;
            this.OpenFileButton.Text = "打开";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "副标题";
            // 
            // subTitleTextBox
            // 
            this.subTitleTextBox.Location = new System.Drawing.Point(65, 39);
            this.subTitleTextBox.Name = "subTitleTextBox";
            this.subTitleTextBox.Size = new System.Drawing.Size(157, 20);
            this.subTitleTextBox.TabIndex = 23;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "书籍",
            "论文",
            "未出版文档",
            "海报",
            "杂志",
            "cheat sheel",
            "未定"});
            this.comboBox2.Location = new System.Drawing.Point(65, 320);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 25;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(354, 54);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(371, 343);
            this.axAcroPDF1.TabIndex = 26;
            // 
            // CreateBookFromFileForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 432);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.subTitleTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.FileDescTextBox);
            this.Controls.Add(this.PublishHouseTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.prebutton);
            this.Controls.Add(this.nextbutton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ResourceCheckBox);
            this.Controls.Add(this.AddKeywordButton);
            this.Controls.Add(this.KeywordTextBox);
            this.Controls.Add(this.FileVersionTextBox);
            this.Controls.Add(this.BookNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKButton);
            this.MinimizeBox = false;
            this.Name = "CreateBookFromFileForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateBookFromFileForm";
            this.Load += new System.EventHandler(this.CreateBookFromFileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BookNameTextBox;
        private System.Windows.Forms.TextBox FileVersionTextBox;
        private System.Windows.Forms.TextBox KeywordTextBox;
        private System.Windows.Forms.Button AddKeywordButton;
        private System.Windows.Forms.CheckBox ResourceCheckBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button nextbutton;
        private System.Windows.Forms.Button prebutton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PublishHouseTextBox;
        private System.Windows.Forms.TextBox FileDescTextBox;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox subTitleTextBox;
        private System.Windows.Forms.ComboBox comboBox2;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
    }
}