using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace JianLi3
{
    public class JianLi3WinFormSettingsAccessor
    {
        public JianLi3WinFormSettingsAccessor(JianLi3WinFormSettingsControl c)
        {
            control = c;
        }

        JianLi3WinFormSettingsControl control;

        [Browsable(true)]
        [Description("用户名称。")]
        [Category("服务器")]
        public string 用户名
        {
            get
            {
                return control.用户名;
            }
            set
            {
                control.用户名 = value;
            }
        }

        [Browsable(true)]
        [Description("服务器名称。")]
        [Category("服务器")]
        public string 服务器
        {
            get
            {
                return control.服务器;
            }
            set
            {
                control.服务器 = value;
            }
        }
        [Browsable(true)]
        [Description("是否显示评论。")]
        [Category("服务器")]
        public bool 是否显示评论
        {
            get
            {
                return control.是否显示评论;
            }
            set
            {
                control.是否显示评论 = value;
            }
        }
    }
    public class JianLi3WinFormSettingsLocalModeAccessor
    {
        public JianLi3WinFormSettingsLocalModeAccessor(JianLi3WinFormSettingsControl c)
        {
            control = c;
        }

        [Browsable(true)]
        [Description("用户名称。")]
        [Category("服务器")]
        public string 用户名
        {
            get
            {
                return control.用户名;
            }
            set
            {
                control.用户名 = value;
            }
        }

        JianLi3WinFormSettingsControl control;

        [Browsable(true)]
        [Description("文件库目录。本地模式有效。")]
        [Category("路径")]
        [Editor(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string 文件库目录
        {
            get
            {
                return control.文件库目录;
            }
            set
            {
                control.文件库目录 = value;
            }
        }
        [Browsable(true)]
        [Description("是否显示评论。")]
        [Category("服务器")]
        public bool 是否显示评论
        {
            get
            {
                return control.是否显示评论;
            }
            set
            {
                control.是否显示评论 = value;
            }
        }
    }
}
