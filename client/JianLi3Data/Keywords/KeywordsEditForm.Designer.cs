namespace JianLi3
{
    partial class KeywordsEditForm
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
            this.QuitButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.KeywordDescTextBox = new System.Windows.Forms.TextBox();
            this.KeywordNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KeywordRateComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.QuitButton.Location = new System.Drawing.Point(279, 197);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 11;
            this.QuitButton.Text = "取消";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(198, 197);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 10;
            this.OKButton.Text = "确定";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // KeywordDescTextBox
            // 
            this.KeywordDescTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.KeywordDescTextBox.Location = new System.Drawing.Point(72, 65);
            this.KeywordDescTextBox.Multiline = true;
            this.KeywordDescTextBox.Name = "KeywordDescTextBox";
            this.KeywordDescTextBox.Size = new System.Drawing.Size(284, 126);
            this.KeywordDescTextBox.TabIndex = 9;
            // 
            // KeywordNameTextBox
            // 
            this.KeywordNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.KeywordNameTextBox.Location = new System.Drawing.Point(72, 12);
            this.KeywordNameTextBox.Name = "KeywordNameTextBox";
            this.KeywordNameTextBox.Size = new System.Drawing.Size(284, 20);
            this.KeywordNameTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "描述";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "关注程度";
            // 
            // KeywordRateComboBox
            // 
            this.KeywordRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeywordRateComboBox.FormattingEnabled = true;
            this.KeywordRateComboBox.Items.AddRange(new object[] {
            "不关注",
            "偶尔",
            "关注",
            "长期",
            "当前"});
            this.KeywordRateComboBox.Location = new System.Drawing.Point(72, 38);
            this.KeywordRateComboBox.Name = "KeywordRateComboBox";
            this.KeywordRateComboBox.Size = new System.Drawing.Size(90, 21);
            this.KeywordRateComboBox.TabIndex = 13;
            // 
            // KeywordsEditForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.QuitButton;
            this.ClientSize = new System.Drawing.Size(368, 225);
            this.Controls.Add(this.KeywordRateComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.KeywordDescTextBox);
            this.Controls.Add(this.KeywordNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeywordsEditForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关键词";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox KeywordDescTextBox;
        private System.Windows.Forms.TextBox KeywordNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox KeywordRateComboBox;
    }
}