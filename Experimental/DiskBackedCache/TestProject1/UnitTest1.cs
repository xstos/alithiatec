///
/// Memory Allocator Unit Tests
/// Jeff Tanner, jeff_tanner@earthlink.net
/// Seattle
///
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DiskBackedCache;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MemoryAllocatorUnitTest
    {
        public MemoryAllocator ma { get; private set; }
        public int MaxMemoryPool { get; private set; }
        public MemoryAllocatorUnitTest()
        {
            this.MaxMemoryPool = 100;
            this.ma = new MemoryAllocator(this.MaxMemoryPool);
        }
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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMemoryAllocatorInitialized()
        {
            Assert.AreEqual(1, this.ma.MemoryPool.Keys.Count());
            Assert.AreEqual(this.MaxMemoryPool, this.ma.MemoryPool.Keys.First());
            KeyValuePair<int, List<int>> kvp = this.ma.MemoryPool.First();
            Assert.AreEqual(this.MaxMemoryPool, kvp.Key);
            Assert.AreEqual(1, kvp.Value.Count());
            Assert.AreEqual(0, kvp.Value.First());
        }

        [TestMethod]
        public void TestMemoryAllocatorFirst()
        {
            try
            {
                const int iMemoryBlockAllocate = 10;
                Assert.AreEqual(1, this.ma.MemoryPool.Keys.Count());
                MemoryBlock mb = this.ma.Allocate(iMemoryBlockAllocate);
                Assert.AreEqual(0, mb.BlockAddress);
                Assert.AreEqual(iMemoryBlockAllocate, mb.BlockSize);
                Assert.AreEqual(1, this.ma.MemoryPool.Keys.Count());
                KeyValuePair<int, List<int>> kvp = this.ma.MemoryPool.First();
                Assert.AreEqual(this.MaxMemoryPool - iMemoryBlockAllocate, kvp.Key);
                Assert.AreEqual(1, kvp.Value.Count());
                Assert.AreEqual(iMemoryBlockAllocate, kvp.Value.First());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestMemoryAllocatorMultiple()
        {
            try
            {
                const int iMemoryBlockAllocate = 10;
                Assert.AreEqual(1, this.ma.MemoryPool.Keys.Count());
                MemoryBlock mb1 = ma.Allocate(iMemoryBlockAllocate);
                MemoryBlock mb2 = ma.Allocate(iMemoryBlockAllocate);
                MemoryBlock mb3 = ma.Allocate(iMemoryBlockAllocate);
                MemoryBlock mb4 = ma.Allocate(iMemoryBlockAllocate);
                MemoryBlock mb5 = ma.Allocate(iMemoryBlockAllocate);
                MemoryBlock mb6 = ma.Allocate(iMemoryBlockAllocate);
                MemoryBlock mb7 = ma.Allocate(iMemoryBlockAllocate);
                MemoryBlock mb8 = ma.Allocate(iMemoryBlockAllocate);
                MemoryBlock mb9 = ma.Allocate(iMemoryBlockAllocate);
                Assert.AreEqual(1, this.ma.MemoryPool.Keys.Count());
                KeyValuePair<int, List<int>> kvp9 = this.ma.MemoryPool.First();
                Assert.AreEqual(10, kvp9.Key);
                Assert.AreEqual(1, kvp9.Value.Count());
                Assert.AreEqual(90, kvp9.Value.First());
                MemoryBlock mb10 = ma.Allocate(iMemoryBlockAllocate);
                Assert.AreEqual(90, mb10.BlockAddress);
                Assert.AreEqual(10, mb10.BlockSize);
                Assert.IsFalse(mb10.IsNull());
                Assert.AreEqual(0, this.ma.MemoryPool.Keys.Count());
                MemoryBlock mb11 = ma.Allocate(iMemoryBlockAllocate);
                Assert.IsTrue(mb11.IsNull());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestMemoryAllocatorVariousSizes()
        {
            try
            {
                Assert.AreEqual(1, this.ma.MemoryPool.Keys.Count());
                MemoryBlock mb1 = ma.Allocate(10);
                Assert.IsFalse(mb1.IsNull());
                MemoryBlock mb2 = ma.Allocate(20);
                Assert.IsFalse(mb2.IsNull());
                MemoryBlock mb3 = ma.Allocate(30);
                Assert.IsFalse(mb3.IsNull());
                MemoryBlock mb4 = ma.Allocate(40);
                Assert.IsFalse(mb4.IsNull());
                MemoryBlock mb5 = ma.Allocate(50);
                Assert.IsTrue(mb5.IsNull());
                ma.Free(mb3);
                MemoryBlock mb6 = ma.Allocate(50);
                Assert.IsTrue(mb6.IsNull());
                ma.Free(mb1);
                MemoryBlock mb7 = ma.Allocate(50);
                Assert.IsTrue(mb7.IsNull());
                MemoryBlock mb8 = ma.Allocate(20);
                Assert.IsFalse(mb8.IsNull());
                ma.Free(mb4);
                MemoryBlock mb9 = ma.Allocate(50);
                Assert.IsFalse(mb9.IsNull());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
