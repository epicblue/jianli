using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using EnvDTE;

namespace JianLi.VisualStudio.Integration
{
    public class VsCommandEventArgs : EventArgs
    {
        private DTE2 dte;
        private AddIn addIn;

        public AddIn AddIn
        {
            get
            {
                return this.addIn;
            }
        }

        public DTE2 DTE
        {
            get
            {
                return this.dte;
            }
        }

        public VsCommandEventArgs(DTE2 dte, AddIn addIn)
        {
            this.dte = dte;
            this.addIn = addIn;
        }
    }
}
