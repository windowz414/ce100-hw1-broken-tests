namespace ce100_hw1_broken_tests
{
    public class ce100_hw1_algo_lib
    {
        static int[] SelectionSort(int[] arr)
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
    }
}
