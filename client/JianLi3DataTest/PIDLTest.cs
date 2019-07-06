using WinShell;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JianLi3DataTest
{
    
    
    /// <summary>
    ///This is a test class for PIDLTest and is intended
    ///to contain all PIDLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PIDLTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetItemID
        ///</summary>
        [TestMethod()]
        public void GetItemIDTest()
        {
            IntPtr pidl = new IntPtr();
            uint iAttribute;
            byte[] actual;

            string path = @"F:\Downloaded";

            API.SHParseDisplayName(path, IntPtr.Zero, out pidl, 0, out iAttribute);

            PIDL target = new PIDL(pidl, false); // TODO: Initialize to an appropriate value

            actual = target.GetItemID(0);

            Console.Write(actual.Length.ToString() + "  ");
            for (int i = 0; i < actual.Length; i++)
                Console.Write(actual[i].ToString()+" ");
            Console.WriteLine();


            // next
            path = @"C:\Documents and Settings\Administrator\Desktop";

            API.SHParseDisplayName(path, IntPtr.Zero, out pidl, 0, out iAttribute);

            target = new PIDL(pidl, false); // TODO: Initialize to an appropriate value

            actual = target.GetItemID(0);
            //如何判断byte[] 和null?
            Assert.Equals(actual==null,true);
        }
    }
}
