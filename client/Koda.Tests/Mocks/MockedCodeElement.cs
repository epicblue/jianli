using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;
using EnvDTE80;

namespace Lusonixs.Mocks
{
    internal class MockedCodeElement : CodeElement, CodeElement2
    {
        private string name;
        private vsCMElement kind;

        public CodeElements Children
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public CodeElements Collection
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public DTE DTE
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public TextPoint EndPoint
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string ExtenderCATID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object ExtenderNames
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string FullName
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public TextPoint GetEndPoint(vsCMPart Part)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public TextPoint GetStartPoint(vsCMPart Part)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public vsCMInfoLocation InfoLocation
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool IsCodeType
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public vsCMElement Kind
        {
            get
            {
                return this.kind;
            }
        }

        public string Language
        {
            get { throw new Exception("The method or operation is not implemented."); }
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

        public ProjectItem ProjectItem
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public TextPoint StartPoint
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RenameSymbol(string name)
        {
            throw new NotImplementedException();
        }

        public string ElementID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MockedCodeElement(string name)
            : this(name, vsCMElement.vsCMElementOther)
        {

        }

        public MockedCodeElement(string name, vsCMElement kind)
        {
            this.name = name;
            this.kind = kind;
        }
    }
}
