using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JianLi3Data;

namespace JianLi3.Books
{
    public delegate void OnViewCreateDelegate(ref bool iscreated);
    public interface INewBookView
    {
        string BookTitle { get; set; }//分解文件名初始化
        string BookSubTitle { get; set; }//根据BookTitle初始化
        string BookVersion { get; }
        string BookDescription { get;  }// 根据BookTitle初始化
        string FileDescription { get; }
        string PublishHouse { set; get; }
        BookTypeEnum BookType { get; }

        event EventHandler OnViewLoaded;
        event OnViewCreateDelegate OnBookCreate;
        event EventHandler OnBookTitleChanged;

        bool IsResource { get; }
        // for init
        AutoCompleteStringCollection acbooknames { set; }// BookNameEdit
        byte BookRate { get; set; }//根据BookTitle初始化 0最不喜欢，4最喜欢
        string LocalPath { set; }
        string BookKeywords { get; set; }//根据BookTitle初始化\
        DialogResult ShowDialog();
    }
}
