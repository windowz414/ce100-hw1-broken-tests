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
            // Generate 10k random inputs
            int[] arr = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next();
            }

            // Sort the array using Lomuto's Quicksort
            int[] sortedArr = ce100_hw1_algo_lib.LomutoQuickSort(arr, 0, arr.Length - 1);

            // Check that the array is sorted
            for (int i = 0; i < sortedArr.Length - 1; i++)
            {
                Assert.IsTrue(sortedArr[i] <= sortedArr[i + 1]);
            }
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
