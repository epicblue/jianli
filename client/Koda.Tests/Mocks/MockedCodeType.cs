using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;

namespace Lusonixs.Mocks
{
    internal class MockedCodeType : MockedCodeElement, CodeType
    {
        private vsCMAccess access;

        public vsCMAccess Access
        {
            get
            {
                return this.access;
            }
            set
            {
                this.access = value;
            }
        }

        public CodeAttribute AddAttribute(string Name, string Value, object Position)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CodeElement AddBase(object Base, object Position)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CodeElements Attributes
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public CodeElements Bases
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Comment
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public CodeElements DerivedTypes
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string DocComment
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public CodeElements Members
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public CodeNamespace Namespace
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object Parent
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void RemoveBase(object Element)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RemoveMember(object Element)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool get_IsDerivedFrom(string FullName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MockedCodeType(string name, vsCMElement kind, vsCMAccess access)
            : base(name, kind)
        {
            this.access = access;
        }
    }
}
