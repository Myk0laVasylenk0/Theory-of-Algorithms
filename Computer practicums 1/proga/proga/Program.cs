using System;
using System.Diagnostics;
using System.Text;

//var numList = new List<int> { };
string confirmation;

do
{

    try
    {
        // Вводимо шлях до файлу з консолі та записуєму у змінну

        Console.Write("Enter file path: ");
        string path = Console.ReadLine();

        // Відкриваємо файл та перетворюємо його зміст на масив цілих чисел (якщо це можливо)
        var numList = new List<int> { };

        using (var fileStream = File.OpenRead(path))
    
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
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

        // Функція для пошуку мінімального елемента та його індекса з масиву цілих чисел
        // та вивід на консоль відповідного повідомлення (основний алгоритм)

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

        // Відстежуємо час роботи основного алгоритму та вивидимо результат.

        var watch = Stopwatch.StartNew();

        FindMinElement();

        watch.Stop();
        Console.WriteLine(
                  $"The Execution time of the program is {watch.ElapsedMilliseconds}ms");

        Console.ReadKey();
    }

    // Ловимо помилки в роботі програми 

    catch (FileNotFoundException) // На некоректність введеного шляху до фвйлу
    {
        Console.WriteLine("please, enter the valid path to file");
    }
    catch (FormatException) // На некоректність даних у самому файлі
    {
        Console.WriteLine("invalid data in file");
    }

    // Запит користувача на вихід з програми

    Console.Write("exit the program? [y]/n" + "\n"); 
    confirmation = Console.ReadLine();

}
while (confirmation != "y");



