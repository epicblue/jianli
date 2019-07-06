using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace JianLi.Utils
{
    public class NameValueCollection : Collection<NameValueItem>
    {
        public void Add(string name, object value)
        {
            NameValueItem item = new NameValueItem(name, value);
            this.Add(item);
        }
    }
}
