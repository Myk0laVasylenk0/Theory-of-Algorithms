using System;
using System.Diagnostics;

int Min = 0;
int Max = 1000;

int ArrayLen = 1000; // change this several

// this declares an integer array 
// and initializes all of them to their default value
// which is zero
int[] numbers = new int[ArrayLen];

// filling array with random integers
Random randNum = new Random();
for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = randNum.Next(Min, Max);
}



void FindMinElement()
{
    int num_elements, index_min, min_element, i;

    num_elements = numbers.GetLength(0);
    i = 0;
    index_min = 0;
    min_element = numbers[0];


    while (i < num_elements)
    {
        if (min_element > numbers[i])
        {
            min_element = numbers[i];
            index_min = i;
            i++;
        }
        else 
        {
            i++;
        }
    }
    string message = $"minimal element in array: {min_element} with index: {index_min}";

    Console.WriteLine(message);
    
}

var watch = Stopwatch.StartNew();

FindMinElement();  

watch.Stop();
Console.WriteLine(
          $"The Execution time of the program is {watch.ElapsedMilliseconds}ms");

Console.ReadKey();

