using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ce100_hw1_algo_lib_cs;

namespace ce100_hw1_algo_test_cs
{
    [TestClass]
    public class ce100_hw1_algo_test
    {
        [TestMethod]
        public void TestSelectionSort()
        {
            // Arrange
            int[] arr = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next();
            }

            // Act
            int[] sortedArr = ce100_hw1_algo_lib.SelectionSort(arr);

            // Assert
            for (int i = 0; i < sortedArr.Length - 1; i++)
            {
                Assert.IsTrue(sortedArr[i] <= sortedArr[i + 1]);
            }
        }

        [TestMethod]
        public void TestMergeSortRecursive()
        {
            // Arrange
            int[] arr = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next();
            }

            // Act
            ce100_hw1_algo_lib.MergeSortRecursive(ref arr, 0, arr.Length - 1);

            // Assert
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Assert.IsTrue(arr[i] <= arr[i + 1]);
            }
        }

        [TestMethod]
        public void TestHoareQuickSort()
        {
            // Arrange
            int[] arr = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 10000);
            }

            // Act
            int[] sortedArr = ce100_hw1_algo_lib.HoareQuickSort(arr, 0, arr.Length - 1);

            // Assert
            for (int i = 1; i < sortedArr.Length; i++)
            {
                Assert.IsTrue(sortedArr[i] >= sortedArr[i - 1]);
            }
        }

        [TestMethod]
        public void TestLomutoQuickSort()
        {
            // Arrange
            int[] arr = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next();
            }

            // Act
            int[] sortedArr = ce100_hw1_algo_lib.LomutoQuickSort(arr, 0, arr.Length - 1);

            // Assert
            for (int i = 0; i < sortedArr.Length - 1; i++)
            {
                Assert.IsTrue(sortedArr[i] <= sortedArr[i + 1]);
            }
        }

        [TestMethod]
        public void TestBinarySearchIterative()
        {
            // Arrange
            int[] arr = Enumerable.Range(1, 10000).ToArray();
            int key = 9000;

            // Act
            var result = ce100_hw1_algo_lib.BinarySearchIterative(arr, key);

            // Assert
            Assert.AreEqual(9000, result);
        }

        [TestMethod]
        public void TestBinarySearchRecursive()
        {
            // Arrange
            int[] arr = Enumerable.Range(1, 10000).OrderBy(x => Guid.NewGuid()).ToArray();
            Array.Sort(arr);

            // Act
            for (int i = 0; i < arr.Length; i++)
            {
                int key = arr[i];
                int expectedIndex = i + 1;
                int actualIndex = (int)ce100_hw1_algo_lib.BinarySearchRecursive(arr, key, 0, arr.Length - 1);
                // Assert
                Assert.AreEqual(expectedIndex, actualIndex);
            }
        }
    }
}
