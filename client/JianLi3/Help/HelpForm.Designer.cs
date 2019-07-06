namespace JianLi3
{
    partial class HelpForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.QuestTextBox = new System.Windows.Forms.TextBox();
            this.AnswerListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "查找";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuestTextBox
            // 
            this.QuestTextBox.Location = new System.Drawing.Point(3, 5);
            this.QuestTextBox.Name = "QuestTextBox";
            this.QuestTextBox.Size = new System.Drawing.Size(225, 20);
            this.QuestTextBox.TabIndex = 1;
            // 
            // AnswerListBox
            // 
            this.AnswerListBox.FormattingEnabled = true;
            this.AnswerListBox.Location = new System.Drawing.Point(3, 31);
            this.AnswerListBox.Name = "AnswerListBox";
            this.AnswerListBox.Size = new System.Drawing.Size(225, 160);
            this.AnswerListBox.TabIndex = 2;
            this.AnswerListBox.DoubleClick += new System.EventHandler(this.AnswerListBox_DoubleClick);
            // 
            // HelpForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 194);
            this.Controls.Add(this.AnswerListBox);
            this.Controls.Add(this.QuestTextBox);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "寻求帮助或提交建议";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox QuestTextBox;
        private System.Windows.Forms.ListBox AnswerListBox;
    }
}