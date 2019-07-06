using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JianLi3Data.FileService;
using JianLi3.Properties;
using JianLi3Data.DataSetting;
using JianLi3Data;

namespace JianLi3.AppSetting
{
    public partial class AppSettingForm : Form
    {
        public AppSettingForm()
        {
            InitializeComponent();
        }

        private void AppSettingForm_Load(object sender, EventArgs e)
        {
            jianLi3WinFormSettingsControl1.用户名 = DataSettings.Default.UserName;
            jianLi3WinFormSettingsControl1.文件库目录 = DataSettings.Default.LibFolder;
            jianLi3WinFormSettingsControl1.服务器 = DataSettings.Default.ServerName;
            jianLi3WinFormSettingsControl1.是否显示评论 = JianLi3WinFormSettings.Default.ShowBookComment;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.jianLi3WinFormSettingsControl1.ValidateSetting())
                return;

            if (JianLi3FileServiceManager.Default.LocalMode)
            {
                DataSettings.Default.LibFolder = this.jianLi3WinFormSettingsControl1.文件库目录;
            }
            DataSettings.Default.UserName = this.jianLi3WinFormSettingsControl1.用户名;

            JianLi3WinFormSettings.Default.ShowBookComment = this.jianLi3WinFormSettingsControl1.是否显示评论;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
