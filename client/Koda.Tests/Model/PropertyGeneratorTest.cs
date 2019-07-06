using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lusonixs.Mocks;
using NMock2;
using EnvDTE80;
using EnvDTE;

namespace Lusonixs.Model
{
    [TestClass]
    public class PropertyGeneratorTest
    {
        [TestMethod()]
        public void VerfiyInitializationOfPropertyGenerator()
        {
            CodeElement[] codeElements = new CodeElement[] 
                { 
                    new MockedCodeVariable2("variable2", vsCMAccess.vsCMAccessPrivate),
                    new MockedCodeElement("testElement"),
                    new MockedCodeVariable2("variable1", vsCMAccess.vsCMAccessPrivate),
                    new MockedCodeVariable2("_variable3", vsCMAccess.vsCMAccessPrivate),
                    new MockedCodeVariable2("m_aprefixedvariable", vsCMAccess.vsCMAccessPrivate),
                };

            MockedCodeClass2 mockedCodeClass = new MockedCodeClass2(codeElements);
            PropertyGenerator propertyGenerator = new PropertyGenerator(mockedCodeClass);
            
            Assert.IsFalse(propertyGenerator.GenerateComments);
            Assert.AreSame(mockedCodeClass, propertyGenerator.CodeClass);
            Assert.AreEqual(4, propertyGenerator.Properties.Length);
            Assert.AreEqual("Aprefixedvariable", propertyGenerator.Properties[0].Name);
            Assert.AreEqual("Variable1", propertyGenerator.Properties[1].Name);
            Assert.AreEqual("Variable2", propertyGenerator.Properties[2].Name);
            Assert.AreEqual("Variable3", propertyGenerator.Properties[3].Name);
        }

    }
}
