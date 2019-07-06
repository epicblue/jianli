using System;
using System.Collections.Generic;
using System.Text;
using Lusonixs.Search;
using Lusonixs.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvDTE80;

namespace Lusonixs.Search.Finders
{
    [TestClass]
    public class VsFinderBaseTest
    {

        [TestMethod()]
        public void Search_VerifyNoMatch()
        {
            IVsItemFinder mockedSearchEngine = new MockedSearchEngine();

            Assert.AreEqual(0, mockedSearchEngine.Search("x"));
        }

        [TestMethod()]
        public void Search_UpperCase()
        {
            IVsItemFinder mockedSearchEngine = new MockedSearchEngine();

            Assert.AreEqual(3, mockedSearchEngine.Search("T"));
        }

        [TestMethod()]
        public void Search_LowerCase()
        {
            IVsItemFinder mockedSearchEngine = new MockedSearchEngine();

            Assert.AreEqual(3, mockedSearchEngine.Search("t"));
        }


        [TestMethod()]
        public void Search_MixedCase()
        {
            IVsItemFinder mockedSearchEngine = new MockedSearchEngine();

            Assert.AreEqual(3, mockedSearchEngine.Search("TeSt"));
        }

        [TestMethod()]
        public void Search_VerifyAsterixInMiddleOfWord()
        {
            IVsItemFinder mockedSearchEngine = new MockedSearchEngine();

            Assert.AreEqual(3, mockedSearchEngine.Search("T*s"));
        }

        [TestMethod()]
        public void Search_VerifyAsterixAtBeginningOfWord()
        {
            IVsItemFinder mockedSearchEngine = new MockedSearchEngine();

            Assert.AreEqual(2, mockedSearchEngine.Search("*m"));
        }

        [TestMethod()]
        public void Search_VerifyAsterixAtEndOfWord()
        {
            IVsItemFinder mockedSearchEngine = new MockedSearchEngine();

            Assert.AreEqual(2, mockedSearchEngine.Search("mockedi*"));
        }

        [TestMethod()]
        public void Search_VerifyCapitalLettersAreTreatedAsAbbreviation()
        {
            IVsItemFinder mockedSearchEngine = new MockedSearchEngine();

            Assert.AreEqual(2, mockedSearchEngine.Search("MI"));
        }
    }   
}