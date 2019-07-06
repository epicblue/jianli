using System;
using System.Collections.Generic;
using System.Text;

namespace JianLi.Utils
{
    public class NameValueItem
    {
        private string name;
        private object value;

        public object Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
	

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public NameValueItem(string name, object value)
        {
            this.name = name;
            this.value = value;
        }
	
    }
}
