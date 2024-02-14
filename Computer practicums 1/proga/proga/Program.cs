using System;
using System.Diagnostics;
using System.Text;


Console.Write("Enter file path: ");
string path = Console.ReadLine();

//string path = @"C:\Users\Nicolay\Desktop\KPI\Theory of Algorithms\Computer practicums 1\300000_int.txt";


var numList = new List<int> { };

//string filepath1 = @"C:\Users\Nicolay\Desktop\KPI\Theory of Algorithms\Computer practicums 1\10_int.txt";
//string filepath2 = @"C:\Users\Nicolay\Desktop\KPI\Theory of Algorithms\Computer practicums 1\100_int.txt";
//string filepath3 = @"C:\Users\Nicolay\Desktop\KPI\Theory of Algorithms\Computer practicums 1\10000_int.txt";


const Int32 BufferSize = 128;
using (var fileStream = File.OpenRead(path))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
{
    String line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string trimmed_line = line.Trim();
        string[] parts = trimmed_line.Split(",");


        foreach (string part in parts)
        {
            if (part == "")
            {
                break;
            }
            else
            {
                numList.Add(int.Parse(part));
            }
        }
    }
}




void FindMinElement()
{
    int n, idx, min, i;

    int[] arr = numList.ToArray();

    n = arr.GetLength(0);
    i = 0;
    idx = 0;
    min = arr[0];


    while (i < n)
    {
        if (min > arr[i])
        {
            min = arr[i];
            idx = i;
            i++;
        }
        else
        {
            i++;
        }
    }
    string message = $"minimal element in array: {min} with index: {idx}";

    Console.WriteLine(message);

}

var watch = Stopwatch.StartNew();

FindMinElement();

watch.Stop();
Console.WriteLine(
          $"The Execution time of the program is {watch.ElapsedMilliseconds}ms");

Console.ReadKey();









// this declares an integer array 
// and initializes all of them to their default value
// which is zero
//int[] numbers = new int[ArrayLen];

// filling array with random integers
//Random randNum = new Random();
//for (int i = 0; i < numbers.Length; i++)
//{
//    numbers[i] = randNum.Next(Min, Max);
//}