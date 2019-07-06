﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianLi3Data.DataSetting;
using JianLi3Data.FileService;
using System.IO;

namespace JianLi3Data
{
    public partial class DataSettingControl : UserControl
    {
        public DataSettingControl()
        {
            InitializeComponent();
            ChoiseObjectProperty();
            libfolder = DataSettings.Default.LibFolder;
            servername = DataSettings.Default.ServerName;
            userName = DataSettings.Default.UserName;
        }

        private string libfolder;
        public string 文件库目录
        {
            set
            {
                libfolder = value;
            }
            get
            {
                return libfolder;
            }
        }

        private string userName;
        public string 用户名
        {
            set
            {
                userName = value;
            }
            get
            {
                return userName;
            }
        }

        private string servername;
        public string 服务器
        {
            set
            {
                servername = value;
                ChoiseObjectProperty();
            }
            get
            {
                return servername;
            }
        }

        private void ChoiseObjectProperty()
        {
            if (JianLi3FileServiceManager.Default.LocalMode)
            {
                this.propertyGrid1.SelectedObject = new DataSettingLocalModeAccessor(this);
            }
            else
            {
                this.propertyGrid1.SelectedObject = new DataSettingAccessor(this);
            }
        }

        public bool ValidateSetting()
        {
            if (JianLi3FileServiceManager.Default.LocalMode)
            {
                if (!Directory.Exists(文件库目录))
                {
                    MessageBox.Show("文件库目录不存在，请重填！");
                    return false;
                }
            }
            return true;
        }
    }
}
