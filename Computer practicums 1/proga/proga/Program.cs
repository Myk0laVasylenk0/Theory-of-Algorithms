using System;
using System.Diagnostics;


var watch = Stopwatch.StartNew();


int[] numbers = { 2, 4, 5, 7, 0, 4, 6, 6, 1, 4 };





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


FindMinElement();  

watch.Stop();
Console.WriteLine(
          $"The Execution time of the program is {watch.ElapsedMilliseconds}ms");

Console.ReadKey();

