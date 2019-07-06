using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using EnvDTE;

namespace Lusonixs.Mocks
{
    internal class MockedCodeVariable2 : MockedCodeType, CodeVariable2
    {

        public vsCMConstKind ConstKind
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

        public object InitExpression
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

        public bool IsConstant
        {
            get
            {
                return false;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool IsGeneric
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

        public MockedCodeVariable2(string name, vsCMAccess access)
            : base(name, vsCMElement.vsCMElementVariable, access)
        {

        }
    }
}
