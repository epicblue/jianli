using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JianLi3.Books
{

    public interface IBookEditView
    {
        string BookTitle { get; set; }
        string BookSubTitle { get; set; }
        byte BookRate { get; set; }
        string BookDescription { get; set; }
        string BookPublishHouse { get; set; }

        event EventHandler OnBookInfoChanged;
        event EventHandler OnBookInfoIniting;

    }
}
