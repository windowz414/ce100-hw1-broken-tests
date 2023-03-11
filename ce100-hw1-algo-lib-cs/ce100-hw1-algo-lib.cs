using System;

namespace ce100_hw1_algo_lib_cs
{
    public class ce100_hw1_algo_lib
    {
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

        // MergeSort implementation
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

        // Quick Sort with Hoare's partitioning.
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

        static int HoarePartition(int[] arr, int low, int high)
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

        public static int[] LomutoQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // partition the array and get the pivot index
                int pi = LomutoPartition(arr, low, high);

                // recursively sort the left and right subarrays
                LomutoQuickSort(arr, low, pi - 1);
                LomutoQuickSort(arr, pi + 1, high);
            }

            return arr;
        }

        static int LomutoPartition(int[] arr, int low, int high)
        {
            // generate a random pivot index
            Random rand = new Random();
            int pivotIndex = rand.Next(low, high);
            int pivot = arr[pivotIndex];

            // move the pivot element to the end of the array
            int temp1 = arr[pivotIndex];
            arr[pivotIndex] = arr[high];
            arr[high] = temp1;

            // initialize the partition index
            int i = low - 1;

            // loop through the array from low to high-1
            for (int j = low; j < high; j++)
            {
                // if the current element is less than or equal
                // to the pivot, swap it with the element at the
                // partition index
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp2 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp2;
                }
            }

            // swap the pivot element back to its final position
            int temp3 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp3;

            // return the index of the pivot element
            return i + 1;
        }

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

        public static int[,] IterativeMatrixMultiplication(int[,] A, int[,] B)
        {
            // Ensure that the number of columns in A matches the
            // number of rows in B.
            if (A.GetLength(1) != B.GetLength(0))
            {
                return null;
            }

            int[,] product = new int[A.GetLength(0), B.GetLength(1)];

            // Iterate through each row of A.
            for (int i = 0; i < A.GetLength(0); i++)
            {
                // Iterate through each column of B.
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    // Iterate through each element of the current
                    // row of A and the current column of B.
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        // Multiply the corresponding elements and
                        // add to the current element of the product
                        // matrix.
                        product[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return product;
        }

        public static int[,] RecursiveMatrixMultiplication(int[,] A, int[,] B)
        {
            // Ensure that the number of columns in A matches the
            // number of rows in B
            if (A.GetLength(1) != B.GetLength(0))
            {
                return null;
            }

            int[,] product = new int[A.GetLength(0), B.GetLength(1)];

            // Base case: if A or B is a 1x1 matrix, return their product
            if (A.GetLength(0) == 1 && A.GetLength(1) == 1 && B.GetLength(0) == 1 && B.GetLength(1) == 1)
            {
                product[0, 0] = A[0, 0] * B[0, 0];
                return product;
            }

            // Split matrices A and B into four submatrices
            int[,] A11 = new int[A.GetLength(0) / 2, A.GetLength(1) / 2];
            int[,] A12 = new int[A.GetLength(0) / 2, A.GetLength(1) / 2];
            int[,] A21 = new int[A.GetLength(0) / 2, A.GetLength(1) / 2];
            int[,] A22 = new int[A.GetLength(0) / 2, A.GetLength(1) / 2];

            int[,] B11 = new int[B.GetLength(0) / 2, B.GetLength(1) / 2];
            int[,] B12 = new int[B.GetLength(0) / 2, B.GetLength(1) / 2];
            int[,] B21 = new int[B.GetLength(0) / 2, B.GetLength(1) / 2];
            int[,] B22 = new int[B.GetLength(0) / 2, B.GetLength(1) / 2];

            for (int i = 0; i < A.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < A.GetLength(1) / 2; j++)
                {
                    A11[i, j] = A[i, j];
                    A12[i, j] = A[i, j + A.GetLength(1) / 2];
                    A21[i, j] = A[i + A.GetLength(0) / 2, j];
                    A22[i, j] = A[i + A.GetLength(0) / 2, j + A.GetLength(1) / 2];

                    B11[i, j] = B[i, j];
                    B12[i, j] = B[i, j + B.GetLength(1) / 2];
                    B21[i, j] = B[i + B.GetLength(0) / 2, j];
                    B22[i, j] = B[i + B.GetLength(0) / 2, j + B.GetLength(1) / 2];
                }
            }

            // Compute the products of the submatrices recursively
            int[,] C11 = AddMatricesRecursive(RecursiveMatrixMultiplication(A11, B11), RecursiveMatrixMultiplication(A12, B21));
            int[,] C12 = AddMatricesRecursive(RecursiveMatrixMultiplication(A11, B12), RecursiveMatrixMultiplication(A12, B22));
            int[,] C21 = AddMatricesRecursive(RecursiveMatrixMultiplication(A21, B11), RecursiveMatrixMultiplication(A22, B21));
            int[,] C22 = AddMatricesRecursive(RecursiveMatrixMultiplication(A21, B12), RecursiveMatrixMultiplication(A22, B22));

            // Combine the submatrices back into the product matrix
            for (int i = 0; i < product.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < product.GetLength(1) / 2; j++)
                {
                    product[i, j] = C11[i, j];
                    product[i, j + product.GetLength(1) / 2] = C12[i, j];
                    product[i + product.GetLength(0) / 2, j] = C21[i, j];
                    product[i + product.GetLength(0) / 2, j + product.GetLength(1) / 2] = C22[i, j];
                }
            }
            return product;
        }

        static int[,] AddMatricesRecursive(int[,] A, int[,] B)
        {
            int[,] sum = new int[A.GetLength(0), A.GetLength(1)]; for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    sum[i, j] = A[i, j] + B[i, j];
                }
            }

            return sum;
        }

        public static int[,] MatrixMultiplicationStrassen(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int[,] result = new int[n, n];

            // Base case
            if (n == 1)
            {
                result[0, 0] = A[0, 0] * B[0, 0];
                return result;
            }

            // Divide matrices into quadrants
            int halfN = n / 2;
            int[,] A11 = new int[halfN, halfN];
            int[,] A12 = new int[halfN, halfN];
            int[,] A21 = new int[halfN, halfN];
            int[,] A22 = new int[halfN, halfN];

            int[,] B11 = new int[halfN, halfN];
            int[,] B12 = new int[halfN, halfN];
            int[,] B21 = new int[halfN, halfN];
            int[,] B22 = new int[halfN, halfN];

            for (int i = 0; i < halfN; i++)
            {
                for (int j = 0; j < halfN; j++)
                {
                    A11[i, j] = A[i, j];
                    A12[i, j] = A[i, j + halfN];
                    A21[i, j] = A[i + halfN, j];
                    A22[i, j] = A[i + halfN, j + halfN];

                    B11[i, j] = B[i, j];
                    B12[i, j] = B[i, j + halfN];
                    B21[i, j] = B[i + halfN, j];
                    B22[i, j] = B[i + halfN, j + halfN];
                }
            }

            // Recursive calls to calculate products
            int[,] P1 = MatrixMultiplicationStrassen(AddMatricesStrassen(A11, A22), AddMatricesStrassen(B11, B22));
            int[,] P2 = MatrixMultiplicationStrassen(AddMatricesStrassen(A21, A22), B11);
            int[,] P3 = MatrixMultiplicationStrassen(A11, SubstractMatricesStrassen(B12, B22));
            int[,] P4 = MatrixMultiplicationStrassen(A22, SubstractMatricesStrassen(B21, B11));
            int[,] P5 = MatrixMultiplicationStrassen(AddMatricesStrassen(A11, A12), B22);
            int[,] P6 = MatrixMultiplicationStrassen(SubstractMatricesStrassen(A21, A11), AddMatricesStrassen(B11, B12));
            int[,] P7 = MatrixMultiplicationStrassen(SubstractMatricesStrassen(A12, A22), AddMatricesStrassen(B21, B22));

            // Combine products into result matrix
            int[,] C11 = AddMatricesStrassen(SubstractMatricesStrassen(AddMatricesStrassen(P1, P4), P5), P7);
            int[,] C12 = AddMatricesStrassen(P3, P5);
            int[,] C21 = AddMatricesStrassen(P2, P4);
            int[,] C22 = AddMatricesStrassen(SubstractMatricesStrassen(AddMatricesStrassen(P1, P3), P2), P6);

            // Copy quadrants back into the result matrix
            for (int i = 0; i < halfN; i++)
            {
                for (int j = 0; j < halfN; j++)
                {
                    result[i, j] = C11[i, j];
                    result[i, j + halfN] = C12[i, j];
                    result[i + halfN, j] = C21[i, j];
                    result[i + halfN, j + halfN] = C22[i, j];
                }
            }
            return result;
        }

        // Helper methods for matrix addition and subtraction
        static int[,] AddMatricesStrassen(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int[,] result = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = A[i, j] + B[i, j];
                }
            }
            return result;
        }

        static int[,] SubstractMatricesStrassen(int[,] A, int[,] B)
        {
            int n = A.GetLength(0);
            int[,] result = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = A[i, j] - B[i, j];
                }
            }
            return result;
        }
    }
}
