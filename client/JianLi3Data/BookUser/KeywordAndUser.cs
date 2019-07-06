using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JianLi3Data;

namespace JianLi3Data.JLBook.User
{
    public class KeywordAndUser
    {
        public Keywords Keyword;
        public UserKeyword UserKeyword;
        public string KeywordName
        {
            get
            {
                return this.Keyword.KeywordName;
            }
            set
            {
                this.Keyword.KeywordName = value;
            }
        }
        public int KeywordRate
        {
            get
            {
                return this.UserKeyword.KeywordRate;
            }
            set
            {
                this.UserKeyword.KeywordRate = value;
            }
        }
        public string KeywordDesc
        {
            get
            {
                return this.Keyword.KeywordDesc;
            }
            set
            {
                this.Keyword.KeywordDesc = value;
            }
        }
    }
}
