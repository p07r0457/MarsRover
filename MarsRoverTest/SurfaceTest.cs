using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace MarsRoverTest
{
    
    
    /// <summary>
    ///This is a test class for SurfaceTest and is intended
    ///to contain all SurfaceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SurfaceTest
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
        ///A test for LocationAvailable
        ///</summary>
        [TestMethod()]
        public void LocationAvailableTest()
        {
            Surface MySurface = new Surface(new Size(5, 5));
            Assert.AreEqual(true, MySurface.LocationAvailable(new Point(0, 0)));
            Assert.AreEqual(true, MySurface.LocationAvailable(new Point(5, 5)));
            Assert.AreEqual(false, MySurface.LocationAvailable(new Point(-1, 0)));
            Assert.AreEqual(false, MySurface.LocationAvailable(new Point(0, -1)));
            Assert.AreEqual(false, MySurface.LocationAvailable(new Point(6, 0)));
            Assert.AreEqual(false, MySurface.LocationAvailable(new Point(0, 6)));
        }

        /// <summary>
        ///A test for Dimensions
        ///</summary>
        [TestMethod()]
        public void DimensionsTest()
        {
            Surface MySurface = new Surface(new Size(5, 5));
            Assert.AreEqual(new Size(5, 5), MySurface.Dimensions);
        }
    }
}
