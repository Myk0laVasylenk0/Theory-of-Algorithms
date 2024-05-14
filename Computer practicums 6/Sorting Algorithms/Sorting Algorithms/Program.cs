using System;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;


class SortAlgs
{
    static int[] BubleSort(int[] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 1; j < array.GetLength(0); j++)
            {
                if (array[j - 1] > array[j])
                {
                    int temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                }
            }
        }

        return array;
    }
    static int[] InsertionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = array[i];
            int j = i - 1;

            // Переміщаю елементи [0..i-1],
            // які більші за ключ, на одну позицію вправо
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
        return array;
    }


    static int[] CountSort(int[] inputArray)
    {
        int N = inputArray.Length;
        // Finding the maximum element of the array inputArray[].
        int M = 0;
        for (int i = 0; i < N; i++)
            M = Math.Max(M, inputArray[i]);
        // Initializing countArray[] with 0
        int[] countArray = new int[M + 1];
        // Mapping each element of inputArray[] as an index
        // of countArray[] array
        for (int i = 0; i < N; i++)
            countArray[inputArray[i]]++;
        // Calculating prefix sum at every index
        // of array countArray[]
        for (int i = 1; i <= M; i++)
            countArray[i] += countArray[i - 1];
        // Creating outputArray[] from the countArray[] array
        int[] outputArray = new int[N];
        for (int i = N - 1; i >= 0; i--)
        {
            outputArray[countArray[inputArray[i]] - 1] = inputArray[i];
            countArray[inputArray[i]]--;
        }
        return outputArray;
    }

    // Here starts the code of QuickSort algorithm

    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, high);
        return (i + 1);
    }

    private static void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            Sort(arr, low, pi - 1);
            Sort(arr, pi + 1, high);
        }
    }

    public static int[] QuickSort(int[] arr)
    {
        Sort(arr, 0, arr.Length - 1);
        return arr;
    }

    static void Print(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");

        Console.Write("\n");
    }

    public static void Main()
    {
        int[] array_30_unsorted = new int[] { 34, 7, 23, 32, 5, 62, 78, 4, 90, 1, 9, 29, 56, 45, 77, 12, 30, 11, 20, 25, 33, 2, 8, 17, 15, 60, 99, 88, 41 };
        int[] array_30_partly_sorted = new int[] { 1, 4, 5, 7, 9, 23, 29, 32, 34, 56, 62, 78, 90, 45, 77, 12, 30, 11, 20, 25, 33, 2, 8, 17, 15, 60, 99, 88, 41 };
        int[] array_30_repeats = new int[] { 34, 7, 23, 34, 5, 7, 78, 4, 90, 1, 9, 29, 5, 45, 7, 12, 30, 11, 20, 23, 33, 2, 8, 17, 7, 60, 99, 88, 45 };

        int[] array100_unsorted = { 7, 5, 79, 80, 20, 62, 82, 68, 89, 70, 84, 74, 50, 86, 73, 14, 100, 35, 63, 46, 99, 54, 33, 95, 51, 77, 76, 85, 19, 30, 18, 1, 90, 17, 39, 21, 92, 25, 42, 91, 29, 9, 27, 43, 8, 10, 78, 31, 13, 3, 52, 24, 2, 57, 4, 55, 96, 83, 75, 59, 66, 93, 40, 16, 67, 56, 81, 44, 41, 49, 6, 69, 48, 65, 11, 94, 12, 28, 47, 36, 32, 61, 64, 34, 22, 71, 88, 45, 26, 23, 15, 72, 60, 53, 87, 37, 38, 97, 98, 58 };
        int[] array100_partly_sorted = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 60, 56, 89, 59, 54, 82, 70, 61, 65, 99, 66, 74, 91, 73, 93, 78, 88, 72, 62, 67, 94, 85, 100, 76, 83, 57, 92, 96, 77, 68, 90, 52, 69, 51, 97, 81, 53, 63, 84, 55, 95, 71, 86, 64, 98, 75, 58, 79, 87, 80 };
        int[] array100_repeats = { 16, 46, 46, 46, 44, 7, 45, 10, 43, 39, 50, 33, 43, 33, 18, 28, 45, 35, 10, 33, 7, 18, 12, 49, 18, 6, 9, 40, 3, 40, 35, 9, 23, 44, 18, 50, 49, 39, 40, 50, 23, 16, 18, 35, 15, 9, 35, 3, 9, 35, 46, 16, 25, 35, 50, 22, 18, 45, 35, 16, 46, 50, 50, 18, 50, 15, 3, 44, 50, 45, 33, 42, 25, 3, 45, 35, 44, 3, 42, 35, 44, 39, 10, 35, 43, 18, 12, 9, 35, 50, 50, 44, 39, 3, 44, 46, 15, 46, 9, 18 };

        int[] array500_unsorted = { 230, 481, 339, 48, 447, 107, 485, 55, 262, 236, 244, 325, 433, 221, 293, 321, 465, 317, 332, 354, 498, 18, 146, 192, 84, 462, 467, 92, 210, 124, 322, 180, 400, 457, 142, 301, 405, 158, 342, 126, 431, 52, 135, 316, 384, 296, 91, 207, 14, 446, 494, 398, 240, 330, 484, 61, 173, 272, 458, 133, 356, 396, 153, 79, 361, 145, 418, 381, 358, 274, 318, 284, 482, 282, 260, 136, 348, 212, 248, 152, 96, 197, 255, 256, 28, 360, 401, 328, 128, 399, 148, 190, 127, 383, 487, 184, 363, 164, 251, 327, 436, 297, 205, 111, 391, 134, 346, 362, 101, 202, 73, 219, 188, 264, 291, 4, 64, 435, 259, 341, 163, 56, 289, 345, 343, 434, 40, 37, 350, 141, 36, 169, 80, 268, 237, 409, 269, 215, 222, 308, 116, 172, 239, 337, 410, 3, 340, 117, 324, 364, 422, 170, 406, 300, 460, 386, 238, 143, 470, 99, 473, 444, 477, 469, 334, 394, 449, 97, 478, 483, 159, 276, 183, 118, 120, 82, 45, 57, 35, 132, 438, 242, 252, 139, 5, 500, 226, 451, 440, 65, 223, 387, 492, 271, 26, 123, 312, 213, 351, 114, 310, 53, 33, 51, 7, 189, 393, 290, 160, 58, 267, 72, 98, 220, 201, 174, 426, 419, 104, 443, 69, 265, 309, 365, 167, 209, 459, 176, 108, 151, 298, 439, 495, 372, 461, 233, 450, 110, 121, 338, 243, 171, 198, 430, 425, 441, 214, 85, 347, 140, 453, 247, 314, 199, 353, 429, 472, 161, 466, 182, 144, 270, 195, 166, 421, 254, 486, 305, 225, 285, 374, 194, 302, 149, 266, 471, 74, 186, 428, 241, 357, 185, 335, 313, 44, 283, 77, 474, 326, 423, 455, 138, 281, 249, 179, 373, 228, 211, 491, 367, 137, 15, 413, 31, 273, 103, 488, 19, 16, 34, 9, 245, 224, 489, 175, 216, 402, 191, 389, 8, 412, 234, 311, 464, 385, 499, 496, 90, 320, 278, 150, 115, 129, 375, 331, 408, 206, 6, 452, 382, 253, 196, 106, 411, 156, 294, 303, 404, 379, 369, 417, 200, 30, 50, 456, 304, 67, 13, 22, 11, 181, 204, 89, 476, 10, 292, 420, 390, 370, 490, 112, 315, 102, 395, 403, 366, 480, 78, 60, 41, 193, 1, 250, 277, 445, 388, 288, 295, 218, 442, 246, 100, 147, 299, 42, 203, 306, 323, 177, 287, 125, 70, 427, 359, 275, 336, 414, 39, 380, 333, 122, 229, 59, 157, 407, 397, 54, 286, 165, 448, 105, 235, 371, 24, 475, 208, 113, 46, 75, 432, 231, 279, 280, 76, 63, 187, 20, 29, 12, 27, 468, 162, 43, 463, 88, 307, 86, 21, 130, 232, 47, 154, 257, 378, 377, 17, 119, 49, 71, 32, 81, 258, 62, 454, 349, 66, 68, 2, 344, 319, 424, 352, 355, 392, 109, 94, 493, 95, 329, 217, 415, 168, 437, 93, 25, 87, 497, 23, 178, 83, 261, 155, 38, 368, 416, 376, 263, 131, 479, 227 };
        int[] array500_partly_sorted = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 300, 424, 295, 341, 269, 254, 461, 274, 356, 397, 438, 268, 485, 256, 368, 440, 489, 495, 480, 360, 449, 448, 339, 411, 294, 383, 431, 416, 473, 271, 403, 418, 387, 352, 459, 400, 457, 428, 427, 353, 326, 291, 351, 481, 312, 344, 402, 258, 305, 479, 374, 321, 289, 366, 484, 476, 499, 470, 357, 343, 394, 264, 493, 334, 354, 446, 488, 462, 434, 282, 437, 381, 255, 265, 500, 395, 308, 408, 318, 322, 377, 455, 454, 314, 266, 491, 338, 277, 267, 465, 450, 328, 251, 335, 309, 391, 486, 276, 345, 409, 380, 272, 463, 396, 388, 406, 494, 433, 324, 460, 415, 337, 379, 472, 278, 373, 469, 439, 349, 390, 369, 407, 384, 261, 327, 293, 359, 297, 358, 311, 284, 414, 423, 386, 401, 298, 361, 420, 483, 444, 452, 443, 371, 376, 283, 399, 417, 355, 441, 270, 275, 257, 281, 490, 260, 478, 292, 336, 306, 477, 413, 425, 429, 471, 498, 467, 290, 347, 421, 372, 445, 331, 466, 432, 430, 447, 342, 301, 398, 307, 315, 496, 287, 405, 393, 279, 263, 475, 436, 319, 375, 348, 456, 299, 464, 468, 317, 286, 252, 453, 325, 330, 273, 487, 435, 346, 378, 285, 350, 367, 422, 304, 426, 497, 253, 365, 392, 329, 340, 362, 385, 288, 303, 364, 370, 474, 333, 404, 262, 302, 323, 410, 332, 389, 313, 316, 320, 412, 419, 382, 280, 451, 310, 363, 259, 296, 458, 492, 482, 442 };
        int[] array500_repeats = { 45, 8, 3, 35, 11, 37, 20, 44, 30, 19, 9, 40, 3, 28, 49, 31, 24, 46, 19, 14, 45, 19, 1, 38, 11, 11, 24, 28, 35, 25, 46, 34, 20, 7, 12, 8, 20, 50, 49, 50, 3, 40, 8, 32, 9, 13, 28, 43, 34, 40, 7, 31, 16, 43, 14, 6, 47, 35, 44, 41, 36, 14, 23, 14, 32, 41, 2, 32, 9, 13, 50, 39, 18, 26, 30, 31, 36, 45, 44, 9, 12, 40, 40, 23, 26, 44, 25, 12, 27, 33, 21, 12, 49, 50, 16, 14, 47, 26, 31, 31, 2, 50, 34, 20, 45, 24, 40, 49, 43, 19, 38, 25, 40, 16, 6, 31, 9, 11, 2, 24, 12, 20, 12, 18, 17, 6, 6, 7, 10, 40, 13, 46, 14, 16, 14, 31, 31, 1, 45, 47, 43, 16, 14, 49, 37, 34, 35, 28, 16, 47, 44, 32, 20, 16, 47, 18, 32, 31, 43, 32, 38, 41, 28, 35, 5, 24, 41, 19, 14, 18, 10, 43, 3, 31, 41, 2, 43, 25, 28, 28, 50, 31, 7, 2, 45, 44, 9, 8, 43, 14, 44, 47, 26, 40, 13, 18, 19, 35, 47, 26, 14, 26, 32, 31, 24, 31, 44, 36, 44, 44, 16, 13, 34, 15, 39, 41, 41, 39, 18, 11, 14, 5, 34, 22, 31, 50, 28, 14, 29, 22, 11, 36, 4, 3, 25, 31, 7, 32, 43, 43, 32, 45, 40, 25, 46, 31, 50, 3, 24, 43, 8, 10, 35, 35, 44, 10, 31, 12, 34, 22, 30, 49, 28, 2, 19, 11, 39, 3, 43, 25, 46, 15, 31, 35, 25, 49, 14, 28, 43, 4, 6, 31, 11, 3, 40, 20, 21, 44, 40, 40, 1, 30, 16, 39, 2, 43, 46, 43, 8, 24, 12, 16, 7, 50, 2, 19, 26, 43, 18, 50, 41, 3, 22, 37, 28, 16, 44, 20, 13, 44, 36, 32, 35, 19, 14, 35, 32, 31, 41, 44, 9, 30, 24, 14, 46, 4, 29, 49, 44, 14, 32, 3, 40, 37, 24, 5, 38, 43, 27, 3, 20, 16, 16, 20, 20, 13, 8, 27, 8, 29, 14, 50, 30, 6, 37, 37, 32, 48, 44, 3, 24, 18, 44, 13, 36, 14, 22, 25, 32, 6, 35, 14, 44, 8, 20, 12, 49, 27, 26, 20, 30, 29, 6, 39, 43, 28, 50, 34, 9, 18, 33, 6, 43, 43, 46, 41, 31, 41, 49, 14, 22, 35, 16, 32, 16, 35, 32, 28, 41, 14, 3, 1, 10, 8, 7, 15, 50, 35, 22, 14, 4, 18, 28, 49, 28, 20, 36, 44, 16, 43, 5, 49, 43, 3, 46, 2, 33, 39, 27, 14, 48, 43, 7, 34, 8, 10, 7, 28, 30, 14, 8, 43, 31, 37, 43, 4, 28, 22, 40, 13, 45, 39, 7, 4, 36, 20, 39, 47, 20, 30, 20, 33, 16, 37, 50, 17, 32, 39, 16, 44, 22, 18, 10, 15, 5, 44, 36, 31, 23, 5 };



        //Console.WriteLine("repeats:");
        //Console.WriteLine("------------------------------");


        //int[][] unsorted_arrays = { array_30_repeats,  array_30_repeats,  array100_repeats,  array500_repeats,  array500_repeats };

        //foreach (int[] array in unsorted_arrays)
        //{

        //    var watch = new Stopwatch();
        //    watch.Start();
        //    var arrayResult =  QuickSort(array);
        //    watch.Stop();
        //    Print(arrayResult);
        //    Console.WriteLine("Elapsed time (miroseconds): " + watch.Elapsed.Microseconds);
        //    Console.WriteLine("");
        //}















        Console.WriteLine("UNSORTED:");
        Console.WriteLine("------------------------------");

        Console.WriteLine("");
        Console.WriteLine("Bubble Sort:");
        Console.WriteLine("");

        Console.WriteLine("Bubble30:");
        var watch = new Stopwatch();
        watch.Start();
        var arrayResult = BubleSort(array_30_unsorted);
        watch.Stop();
        Print(arrayResult);
        Console.WriteLine("Elapsed time (miroseconds): " + watch.Elapsed.Microseconds);
        Console.WriteLine("");

        //Console.WriteLine("");

        //Console.WriteLine("Bubble100:");
        //var watch1 = new Stopwatch();
        //watch.Start();
        //var arrayResult1 = BubleSort(array100_unsorted);
        //watch.Stop();
        //Print(arrayResult1);
        //Console.WriteLine("Elapsed time (miroseconds): " + watch1.Elapsed.Microseconds);
        //Console.WriteLine("");

        //Console.WriteLine("");

        //Console.WriteLine("Bubble500:");
        //var watch2 = new Stopwatch();
        //watch.Start();
        //var arrayResult2 = BubleSort(array500_unsorted);
        //watch.Stop();
        //Print(arrayResult2);
        //Console.WriteLine("Elapsed time (miroseconds): " + watch2.Elapsed.Microseconds);
        //Console.WriteLine("");


        ////////////////////////////////////

        //Console.WriteLine("");
        //Console.WriteLine("Insertion Sort:");
        //Console.WriteLine("");

        //Console.WriteLine("Bubble30:");
        //var watch3 = new Stopwatch();
        //watch.Start();
        //var arrayResult3 = InsertionSort(array_30_unsorted);
        //watch.Stop();
        //Print(arrayResult3);
        //Console.WriteLine("Elapsed time (miroseconds): " + watch3.Elapsed.Microseconds);
        //Console.WriteLine("");

        //Console.WriteLine("");

        //Console.WriteLine("Bubble100:");
        //var watch4 = new Stopwatch();
        //watch.Start();
        //var arrayResult4 = InsertionSort(array100_unsorted);
        //watch.Stop();
        //Print(arrayResult4);
        //Console.WriteLine("Elapsed time (miroseconds): " + watch4.Elapsed.Microseconds);
        //Console.WriteLine("");

        //Console.WriteLine("");

        //Console.WriteLine("Bubble500:");
        //var watch5 = new Stopwatch();
        //watch.Start();
        //var arrayResult5 = BubleSort(array100_unsorted);
        //watch.Stop();
        //Print(arrayResult5);
        //Console.WriteLine("Elapsed time (miroseconds): " + watch5.Elapsed.Microseconds);
        //Console.WriteLine("");


        ////////////////////////////////////

        //Console.WriteLine("");
        //Console.WriteLine("Counting Sort:");
        //Console.WriteLine("");

        //Console.WriteLine("Bubble30:");
        //var watch6 = new Stopwatch();
        //watch.Start();
        //var arrayResult6 = BubleSort(array_30_unsorted);
        //watch.Stop();
        //Print(arrayResult6);
        //Console.WriteLine("Elapsed time (miroseconds): " + watch.Elapsed.Microseconds);
        //Console.WriteLine("");

        //Console.WriteLine("");

        //Console.WriteLine("Bubble100:");
        //var watch7 = new Stopwatch();
        //watch.Start();
        //var arrayResult7 = BubleSort(array100_unsorted);
        //watch.Stop();
        //Print(arrayResult7);
        //Console.WriteLine("Elapsed time (miroseconds): " + watch.Elapsed.Microseconds);
        //Console.WriteLine("");

        //Console.WriteLine("");

        //Console.WriteLine("Bubble500:");
        //var watch8 = new Stopwatch();
        //watch.Start();
        //var arrayResult8 = BubleSort(array100_unsorted);
        //watch.Stop();
        //Print(arrayResult5);
        //Console.WriteLine("Elapsed time (miroseconds): " + watch.Elapsed.Microseconds);
        //Console.WriteLine("");


    }
}
