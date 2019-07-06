using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;

namespace Lusonixs.Mocks
{
    internal class MockedCodeElements : CodeElements
    {
        private CodeElement[] codeElements;

        public int Count
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool CreateUniqueID(string Prefix, ref string NewName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DTE DTE
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return this.codeElements.GetEnumerator();
        }

        public CodeElement Item(object index)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object Parent
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Reserved1(object Element)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MockedCodeElements(CodeElement[] codeElements)
        {
            this.codeElements = codeElements;
        }
    }
}
