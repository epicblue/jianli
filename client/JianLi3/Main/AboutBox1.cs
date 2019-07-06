﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using JianLi3Data;
using System.Threading;
using System.Diagnostics;

namespace JianLi3
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("关于 {0} {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("版本 {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region 程序集属性访问器

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion


        private void CountButton_Click(object sender, EventArgs e)
        {
            string amount = "当前资料： " + JianLiLinq.Default.DB.Books.Count().ToString() + " 份，其中：";
            amount += Environment.NewLine;

            amount += "书籍： " + BookQuery.TypeBooks(BookTypeEnum.Book).Count().ToString() + " 册";
            amount += Environment.NewLine;

            amount += "海报： " + BookQuery.TypeBooks(BookTypeEnum.Post).Count().ToString() + " 份";
            amount += Environment.NewLine;

            amount += "论文： " + BookQuery.TypeBooks(BookTypeEnum.Paper).Count().ToString() + " 份";
            amount += Environment.NewLine;

            amount += "杂志/期刊： " + BookQuery.TypeBooks(BookTypeEnum.Magzine).Count().ToString() + " 期";
            amount += Environment.NewLine;

            amount += "Cheet Sheet： " + BookQuery.TypeBooks(BookTypeEnum.CheetSheet).Count().ToString() + " 册";
            amount += Environment.NewLine;

            amount += "其它文档： " + BookQuery.TypeBooks(BookTypeEnum.Doc).Count().ToString() + " 册";
            amount += Environment.NewLine;

            amount += "未归类资料： " + BookQuery.TypeBooks(BookTypeEnum.Uncheck).Count().ToString() + " 份";
            amount += Environment.NewLine;
            amount += Environment.NewLine;

            amount += "文件： " + JianLiLinq.Default.DB.Files.Count().ToString() + " 份";
            amount += Environment.NewLine;
            amount += "关键字： " + JianLiLinq.Default.DB.Keywords.Count().ToString() + " 个";
            amount += Environment.NewLine;
            amount += "类别： " + JianLiLinq.Default.DB.Categories.Count().ToString() + " 个";
            MessageBox.Show(amount);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
        }
    }
}
