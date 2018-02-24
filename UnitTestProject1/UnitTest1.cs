using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DavidHeaps;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MinHeapConstructorTest()
        {
            MinHeap<int> example = new MinHeap<int>();
            Assert.AreEqual(10, example.Capacity);
        }

        [TestMethod]
        public void minHeapInsertTest()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            Random rng = new Random();
            int value = 100;
            for (int i = 0; i < value; i++)
            {
                int randnum = rng.Next(0, 100);
                minHeap.HeapifyUp(randnum);
            }
            for (int i = 1; i < value; i++)
            {
                var parent = minHeap.Array[(i - 1) / 2];
                var currentNode = minHeap.Array[i];
                Assert.IsTrue(parent.CompareTo(currentNode) <= 0);
            }
        }

        [TestMethod]
        public void maxHeapInsertTest()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            Random rng = new Random();
            int value = 100;
            for (int i = 0; i < value; i++)
            {
                int randnum = rng.Next(0, 100);
                maxHeap.HeapifyUp(randnum);
            }
            for (int i = 1; i < value; i++)
            {
                var parent = maxHeap.Array[(i - 1) / 2];
                var currentNode = maxHeap.Array[i];
                Assert.IsTrue(parent.CompareTo(currentNode) >= 0);
            }
        }

        [TestMethod]
        public void minHeapDeleteTest()
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            Random rng = new Random();
            int value = 1000;
            for (int i = 0; i < value; i++)
            {
                int randnum = rng.Next(0, 10000);
                minHeap.HeapifyUp(randnum);
            }
            for (int i = 0; i < value; i++)
            {
                minHeap.HeapifyDown();
                for (int ii = 1; ii < minHeap.Count; ii++)
                {
                    var parent = minHeap.Array[(ii - 1) / 2];
                    var currentNode = minHeap.Array[ii];
                    Assert.IsTrue(parent.CompareTo(currentNode) <= 0);
                }
            }
        }
        
        [TestMethod]
        public void maxHeapDeleteTest()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();
            Random rng = new Random();
            int value = 1000;
            for (int i = 0; i < value; i++)
            {
                int randnum = rng.Next(0, 10000);
                maxHeap.HeapifyUp(randnum);
            }
            for (int i = 0; i < value; i++)
            {
                maxHeap.HeapifyDown();
                for (int ii = 1; ii < maxHeap.Count; ii++)
                {
                    var parent = maxHeap.Array[(ii - 1) / 2];
                    var currentNode = maxHeap.Array[ii];
                    Assert.IsTrue(parent.CompareTo(currentNode) >= 0);
                }
            }
        }

    }
}
