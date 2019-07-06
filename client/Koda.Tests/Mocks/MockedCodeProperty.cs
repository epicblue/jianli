using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;

namespace Lusonixs.Mocks
{
    internal class MockedCodeProperty : MockedCodeType, CodeProperty
    {

        public CodeFunction Getter
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

        public new CodeClass Parent
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public CodeFunction Setter
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

        public MockedCodeProperty(string name, vsCMAccess access)
            : base(name, vsCMElement.vsCMElementProperty, access)
        {

        }
    }
}
