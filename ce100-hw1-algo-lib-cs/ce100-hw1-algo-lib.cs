using System;

namespace ce100_hw1_algo_lib_cs
{
    public class ce100_hw1_algo_lib
    {
        /**
         * This function sorts an array of integers using selection sort method.
         *
         * @param arr An array of integers to sort.
         * @return An array of integers containing the sorted elements.
         */
        public static int[] SelectionSort(int[] arr)
        {
            // Set length of the received
            // array into an integer for
            // counting.
            int n = arr.Length;

            // One by one move boundary of 
            // unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element 
                // in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                // Swap the found minimum 
                // element with the first 
                // element 
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }

            // Lastly return the modified
            // array.
            return arr;
        }

        /**
         * This function sorts an array of integers using recursive merge sort method.
         *
         * @param data An array of integers to sort.
         * @param left The index of the leftmost element to sort.
         * @param right The index of the rightmost element to sort.
         * @return An array of integers containing the sorted elements.
         */
        public static int[] MergeSortRecursive(ref int[] data, int left, int right)
        {
            if (left < right)
            {
                // Make a temporary variable
                // named "m" and let it be the
                // value it needs to be.
                int m = left + (right - left) / 2;

                // Call itself twice with one
                // having left, and the other
                // having right half thrown at it.
                MergeSortRecursive(ref data, left, m);
                MergeSortRecursive(ref data, m + 1, right);

                // Conquer and merge.
                Merge(ref data, left, m, right);
            }

            // Lastly, return the data.
            return data;
        }

        // Helper function for MergeSortRecursive. This MUST NOT be documented!
        private static void Merge(ref int[] data, int left, int mid, int right)
        {
            int i, j, k;
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];

            for (i = 0; i < n1; i++)
                L[i] = data[left + i];

            for (j = 0; j < n2; j++)
                R[j] = data[mid + 1 + j];

            i = 0;
            j = 0;
            k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    data[k] = L[i];
                    i++;
                }
                else
                {
                    data[k] = R[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                data[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                data[k] = R[j];
                j++;
                k++;
            }
        }

        /**
         * This function sorts an array of integers using Hoare partition scheme and Quick Sort algorithm.
         *
         * @param arr An array of integers to sort.
         * @param low The index of the leftmost element to sort.
         * @param high The index of the rightmost element to sort.
         * @return An array of integers containing the sorted elements.
         */
        public static int[] HoareQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Partition the array and
                // get the pivot index.
                int pi = HoarePartition(arr, low, high);

                // Recursively sort the left
                // and right subarrays.
                HoareQuickSort(arr, low, pi);
                HoareQuickSort(arr, pi + 1, high);
            }

            return arr;
        }

        // Helper function for HoareQuickSort. This MUST NOT be documented!
        private static int HoarePartition(int[] arr, int low, int high)
        {
            // Generate a random pivot index.
            Random rand = new Random();
            int pivotIndex = rand.Next(low, high);
            int pivot = arr[pivotIndex];

            // Initialize two pointers i and j.
            int i = low - 1;
            int j = high + 1;

            // Loop until i and j cross each other.
            while (true)
            {
                // Find the index of the first
                // element from the left that
                // is greater than or equal to the
                // pivot.
                do
                {
                    i++;
                } while (arr[i] < pivot);

                // Find the index of the first
                // element from the right that is
                // less than or equal to the pivot.
                do
                {
                    j--;
                } while (arr[j] > pivot);

                // If i and j have crossed each other,
                // return j as the new pivot index.
                if (i >= j)
                {
                    return j;
                }

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        /**
         * This function sorts an array of integers using Lomuto partition scheme and Quick Sort algorithm.
         *
         * @param arr An array of integers to sort.
         * @param low The index of the leftmost element to sort.
         * @param high The index of the rightmost element to sort.
         * @return An array of integers containing the sorted elements.
         */
        public static int[] LomutoQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Partition the array and get the pivot
                // index.
                int pi = LomutoPartition(arr, low, high);

                // Recursively sort the left and right
                // subarrays.
                LomutoQuickSort(arr, low, pi - 1);
                LomutoQuickSort(arr, pi + 1, high);
            }

            return arr;
        }

        // This is a helper function for LomutoQuickSort function. This MUST NOT be documented!
        private static int LomutoPartition(int[] arr, int low, int high)
        {
            // Generate a random pivot index.
            Random rand = new Random();
            int pivotIndex = rand.Next(low, high);
            int pivot = arr[pivotIndex];

            // Move the pivot element to the end of the array.
            int temp1 = arr[pivotIndex];
            arr[pivotIndex] = arr[high];
            arr[high] = temp1;

            // Initialize the partition index.
            int i = low - 1;

            // Loop through the array from low to high-1.
            for (int j = low; j < high; j++)
            {
                // If the current element is less than or equal
                // to the pivot, swap it with the element at the
                // partition index.
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp2 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp2;
                }
            }

            // Swap the pivot element back to its final position.
            int temp3 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp3;

            // Return the index of the pivot element.
            return i + 1;
        }

        /**
         * Performs a binary search on a sorted array using an iterative approach.
         *
         * @param inputArray The sorted array to search.
         * @param key The value to search for in the array.
         * @return The index of the matching element in the array, or the string "Nil" if no match is found.
         */
        public static object BinarySearchIterative(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "Nil";
        }

        /**
         * Performs a binary search on a sorted array using a recursive approach.
         *
         * @param inputArray The sorted array to search.
         * @param key The value to search for in the array.
         * @param min The minimum index of the range to search.
         * @param max The maximum index of the range to search.
         * @return The index of the matching element in the array, or the string "Nil" if no match is found.
         */
        public static object BinarySearchRecursive(int[] inputArray, int key, int min, int max)
        {
            if (min > max)
            {
                return "Nil";
            }
            else
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    return BinarySearchRecursive(inputArray, key, min, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(inputArray, key, mid + 1, max);
                }
            }
        }
    }
}
