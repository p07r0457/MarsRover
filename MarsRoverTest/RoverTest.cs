using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace MarsRoverTest
{
    
    
    /// <summary>
    ///This is a test class for RoverTest and is intended
    ///to contain all RoverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RoverTest
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
        ///A test for Rover Constructor
        ///</summary>
        [TestMethod()]
        public void RoverConstructorTest()
        {
            // Test a "crash landing"
            Surface MySurface = new Surface(new Size(5, 5));
            Rover Rover1 = new Rover(MySurface, new Point(0, 0), PhysicalObject.Heading.North);
           
            Assert.AreEqual(new Point(0, 0), MySurface.GetPosition(Rover1));
        }

        /// <summary>
        ///A test for Move
        ///</summary>
        [TestMethod()]
        public void MoveTest()
        {
            Surface MySurface = new Surface(new Size(5, 5));
            Rover Rover1 = new Rover(MySurface, new Point(0, 0), PhysicalObject.Heading.North);
            Rover1.Move();
            Assert.AreEqual(new Point(0, 1), MySurface.GetPosition(Rover1));
        }

        /// <summary>
        ///A test for Rotate
        ///</summary>
        [TestMethod()]
        public void RotateTest()
        {
            Surface MySurface = new Surface(new Size(5, 5));
            Rover Rover1 = new Rover(MySurface, new Point(0, 0), PhysicalObject.Heading.North);
            Rover1.Move();
            Assert.AreEqual(new Point(0, 1), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Right);
            Rover1.Move();
            Assert.AreEqual(new Point(1, 1), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Right);
            Rover1.Move();
            Assert.AreEqual(new Point(1, 0), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Right);
            Rover1.Move();
            Assert.AreEqual(new Point(0, 0), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Right);
            Rover1.Move();
            Assert.AreEqual(new Point(0, 1), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Right);
            Rover1.Move();
            Assert.AreEqual(new Point(1, 1), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Left);
            Rover1.Move();
            Assert.AreEqual(new Point(1, 2), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Left);
            Rover1.Move();
            Assert.AreEqual(new Point(0, 2), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Left);
            Rover1.Move();
            Assert.AreEqual(new Point(0, 1), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Left);
            Rover1.Move();
            Assert.AreEqual(new Point(1, 1), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Left);
            Rover1.Move();
            Assert.AreEqual(new Point(1, 2), MySurface.GetPosition(Rover1));
            Rover1.Rotate(PhysicalObject.Rotation.Left);
            Rover1.Move();
            Assert.AreEqual(new Point(0, 2), MySurface.GetPosition(Rover1));
        }

        /// <summary>
        ///A test for CrashLanded
        ///</summary>
        [TestMethod()]
        public void CrashLandedTest()
        {
            Surface MySurface = new Surface(new Size(5, 5));
            Rover Rover1 = new Rover(MySurface, new Point(0, 0), PhysicalObject.Heading.North);
            Rover Rover2 = new Rover(MySurface, new Point(0, 0), PhysicalObject.Heading.East);

            Assert.AreEqual(true, Rover2.CrashLanded);
        }

        /// <summary>
        ///A test for Move
        ///</summary>
        [TestMethod()]
        public void PlexisChallenge()
        {
            Surface MySurface = new Surface(new Size(5, 5));

            Rover Spirit = new Rover(MySurface, new Point(1, 2), PhysicalObject.Heading.North);
            Spirit.Rotate(PhysicalObject.Rotation.Left);
            Spirit.Move();
            Spirit.Rotate(PhysicalObject.Rotation.Left);
            Spirit.Move();
            Spirit.Rotate(PhysicalObject.Rotation.Left);
            Spirit.Move();
            Spirit.Rotate(PhysicalObject.Rotation.Left);
            Spirit.Move();
            Spirit.Move();
            Assert.AreEqual(new Point(1, 3), MySurface.GetPosition(Spirit));
            Assert.AreEqual(PhysicalObject.Heading.North, Spirit.Direction);

            Rover Opportunity = new Rover(MySurface, new Point(3, 3), PhysicalObject.Heading.East);
            Opportunity.Move();
            Opportunity.Move();
            Opportunity.Rotate(PhysicalObject.Rotation.Right);
            Opportunity.Move();
            Opportunity.Move();
            Opportunity.Rotate(PhysicalObject.Rotation.Right);
            Opportunity.Move();
            Opportunity.Rotate(PhysicalObject.Rotation.Right);
            Opportunity.Rotate(PhysicalObject.Rotation.Right);
            Opportunity.Move();
            Assert.AreEqual(new Point(5, 1), MySurface.GetPosition(Opportunity));
            Assert.AreEqual(PhysicalObject.Heading.East, Opportunity.Direction);
        }
    }
}
