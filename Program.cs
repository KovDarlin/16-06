using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string filePath = "task5.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllLines(filePath, new[] { "90", "1", "6", "17" });
        }

        List<int> numbers = new List<int>();
        foreach (string line in File.ReadLines(filePath))
        {
            if (int.TryParse(line, out int number))
            {
                numbers.Add(number);
            }
        }

        Parallel.ForEach(numbers, number =>
        {
            BigInteger factorial = 1;
            for (int i = 2; i <= number; i++)
                factorial *= i;

            Console.WriteLine($"Factorial {number} = {factorial}");
        });

    }
}
