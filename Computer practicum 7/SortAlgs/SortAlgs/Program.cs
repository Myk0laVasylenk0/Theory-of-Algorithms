
using System;
using System.Diagnostics;
using System.Linq;
using SortAlgs;

class Program
{
    static void Main()
    {

        int[] unsorted_arr = Enumerable.Range(1, 1000000).ToArray();

        Random rng = new Random();

        for (int i = unsorted_arr.Length - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            int temp = unsorted_arr[i];
            unsorted_arr[i] = unsorted_arr[j];
            unsorted_arr[j] = temp;
        }

        int[] partially_sorted_arr = new int[1000000];

        for (int i = 0; i < 500000; i++)
        {
            partially_sorted_arr[i] = i + 1;
        }

        int[] secondHalf = Enumerable.Range(500001, 500000).ToArray();


        for (int i = secondHalf.Length - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            int temp = secondHalf[i];
            secondHalf[i] = secondHalf[j];
            secondHalf[j] = temp;
        }


        Array.Copy(secondHalf, 0, partially_sorted_arr, 500000, 500000);

        int[] repeated_arr = new int[1000000];

        for (int i = 0; i < repeated_arr.Length; i++)
        {
            repeated_arr[i] = rng.Next(1, 10001);
        }


        HeapSort heapSort = new HeapSort();
        MergeSortAlgorithm mergeSortAlgorithm = new MergeSortAlgorithm();
        QuickSort quickSort = new QuickSort();

        Console.WriteLine("Start (incorect time):");
        Console.WriteLine("------------------------------");

        var watch1 = new Stopwatch();
        watch1.Start();
        mergeSortAlgorithm.MergeSort(repeated_arr);
        watch1.Stop();
        Console.WriteLine("Elapsed time (miroseconds): " + watch1.Elapsed.Microseconds);
        Console.WriteLine("");



        Console.WriteLine("Testing Results:");
        Console.WriteLine("------------------------------");

        Console.WriteLine("MergeSort:");
        var watch2 = new Stopwatch();
        watch2.Start();
        mergeSortAlgorithm.MergeSort(unsorted_arr);
        watch2.Stop();
        Console.WriteLine("Elapsed time (miroseconds): " + watch2.Elapsed.Microseconds);
        Console.WriteLine("");

        Console.WriteLine("HeapSort:");
        var watch3 = new Stopwatch();
        watch3.Start();
        heapSort.sort(unsorted_arr);
        watch3.Stop();
        Console.WriteLine("Elapsed time (miroseconds): " + watch3.Elapsed.Microseconds);
        Console.WriteLine("");

        Console.WriteLine("QuickSort:");
        int N = unsorted_arr.Length;
        var watch4 = new Stopwatch();
        watch4.Start();
        quickSort.quickSort(unsorted_arr, 0, N - 1);
        watch4.Stop();
        Console.WriteLine("Elapsed time (miroseconds): " + watch4.Elapsed.Microseconds);
        Console.WriteLine("");



        Console.WriteLine("Finish (incorect time):");
        Console.WriteLine("------------------------------");

        var watch5 = new Stopwatch();
        watch5.Start();
        mergeSortAlgorithm.MergeSort(repeated_arr);
        watch5.Stop();
        Console.WriteLine("Elapsed time (miroseconds): " + watch5.Elapsed.Microseconds);
        Console.WriteLine("");

    }
}