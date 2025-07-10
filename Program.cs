using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int start = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int end = int.Parse(Console.ReadLine());

        string filePath = "task4.txt";

        StringBuilder sb = new StringBuilder();
        object new_object = new object();

        Parallel.For(start, end + 1, i =>
        {
            StringBuilder localBuilder = new StringBuilder();
            for (int j = 1; j <= 10; j++)
            {
                localBuilder.AppendLine($"{i} * {j} = {i * j}");
            }

            lock (new_object)
            {
                sb.AppendLine(localBuilder.ToString());
            }
        });

        File.WriteAllText(filePath, sb.ToString());
    }
}
