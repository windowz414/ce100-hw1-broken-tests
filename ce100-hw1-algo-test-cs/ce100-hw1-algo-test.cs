using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        }

        [TestMethod]
        public void TestHoareQuickSort()
        {
        }

        [TestMethod]
        public void TestLomutoQuickSort()
        {
        }

        [TestMethod]
        public void TestBinarySearchIterative()
        {
        }

        [TestMethod]
        public void TestBinarySearchRecursive()
        {
        }

        [TestMethod]
        public void TestIterativeMatricMultiplication()
        {
        }

        [TestMethod]
        public void TestRecursiveMatrixMultiplication()
        {
        }

        [TestMethod]
        public void TestMatrixMultiplicationStrassen()
        {
        }
    }
}
