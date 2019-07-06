using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;
using EnvDTE80;

namespace Lusonixs.Mocks
{
    internal class MockedCodeFunction : MockedCodeElement, CodeFunction, CodeFunction2
    {
        private vsCMFunction functionKind;
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

        public CodeParameter AddParameter(string Name, object Type, object Position)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CodeElements Attributes
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool CanOverride
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

        public vsCMFunction FunctionKind
        {
            get 
            {
                return functionKind;
            }
        }

        public bool IsOverloaded
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool IsShared
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

        public bool MustImplement
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

        public CodeElements Overloads
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public CodeElements Parameters
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object Parent
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void RemoveParameter(object Element)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CodeTypeRef Type
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

        public string get_Prototype(int Flags)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MockedCodeFunction(string name)
            : this(name, vsCMFunction.vsCMFunctionFunction)
        {

        }

        public MockedCodeFunction(string name, vsCMFunction functionKind)
            : this(name, functionKind, vsCMAccess.vsCMAccessPublic)
        {

        }

        public MockedCodeFunction(string name, vsCMFunction functionKind, vsCMAccess access)
            : base(name, vsCMElement.vsCMElementFunction)
        {
            this.functionKind = functionKind;
            this.access = access;
        }


        public bool IsGeneric
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public vsCMOverrideKind OverrideKind
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
    }
}
