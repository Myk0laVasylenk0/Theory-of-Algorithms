using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgs
{
    public class MergeSortAlgorithm
    {
        public void MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return;

            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);

            MergeSort(left);
            MergeSort(right);

            Merge(arr, left, right);
        }

        public void Merge(int[] arr, int[] left, int[] right)
        {
            int leftIdx = 0, rightIdx = 0, mergeIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] <= right[rightIdx])
                {
                    arr[mergeIdx] = left[leftIdx];
                    leftIdx++;
                }
                else
                {
                    arr[mergeIdx] = right[rightIdx];
                    rightIdx++;
                }
                mergeIdx++;
            }

            while (leftIdx < left.Length)
            {
                arr[mergeIdx] = left[leftIdx];
                leftIdx++;
                mergeIdx++;
            }

            while (rightIdx < right.Length)
            {
                arr[mergeIdx] = right[rightIdx];
                rightIdx++;
                mergeIdx++;
            }
        }

        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

    }
}
