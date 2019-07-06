using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using EnvDTE;

namespace Lusonixs.Mocks
{
    internal class MockedCodeClass2 : CodeClass2
    {
        private MockedCodeElements mockedCodeElements;

        public EnvDTE.vsCMAccess Access
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

        public EnvDTE.CodeAttribute AddAttribute(string Name, string Value, object Position)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeElement AddBase(object Base, object Position)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeClass AddClass(string Name, object Position, object Bases, object ImplementedInterfaces, EnvDTE.vsCMAccess Access)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeDelegate AddDelegate(string Name, object Type, object Position, EnvDTE.vsCMAccess Access)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeEnum AddEnum(string Name, object Position, object Bases, EnvDTE.vsCMAccess Access)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public CodeEvent AddEvent(string Name, string FullDelegateName, bool CreatePropertyStyleEvent, object Location, EnvDTE.vsCMAccess Access)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeFunction AddFunction(string Name, EnvDTE.vsCMFunction Kind, object Type, object Position, EnvDTE.vsCMAccess Access, object Location)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeInterface AddImplementedInterface(object Base, object Position)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeProperty AddProperty(string GetterName, string PutterName, object Type, object Position, EnvDTE.vsCMAccess Access, object Location)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeStruct AddStruct(string Name, object Position, object Bases, object ImplementedInterfaces, EnvDTE.vsCMAccess Access)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeVariable AddVariable(string Name, object Type, object Position, EnvDTE.vsCMAccess Access, object Location)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeElements Attributes
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.CodeElements Bases
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.CodeElements Children
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public vsCMClassKind ClassKind
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

        public EnvDTE.CodeElements Collection
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

        public EnvDTE.DTE DTE
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public vsCMDataTypeKind DataTypeKind
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

        public EnvDTE.CodeElements DerivedTypes
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

        public EnvDTE.TextPoint EndPoint
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

        public EnvDTE.TextPoint GetEndPoint(EnvDTE.vsCMPart Part)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.TextPoint GetStartPoint(EnvDTE.vsCMPart Part)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.CodeElements ImplementedInterfaces
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.vsCMInfoLocation InfoLocation
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public vsCMInheritanceKind InheritanceKind
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

        public bool IsAbstract
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

        public bool IsCodeType
        {
            get { throw new Exception("The method or operation is not implemented."); }
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

        public EnvDTE.vsCMElement Kind
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Language
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.CodeElements Members
        {
            get 
            {
                return this.mockedCodeElements;
            }
        }

        public string Name
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

        public EnvDTE.CodeNamespace Namespace
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object Parent
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.CodeElements PartialClasses
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.CodeElements Parts
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public EnvDTE.ProjectItem ProjectItem
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void RemoveBase(object Element)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RemoveInterface(object Element)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void RemoveMember(object Element)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public EnvDTE.TextPoint StartPoint
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object get_Extender(string ExtenderName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool get_IsDerivedFrom(string FullName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MockedCodeClass2(CodeElement[] codeElements)
        {
            this.mockedCodeElements = new MockedCodeElements(codeElements);
        }
    }
}
