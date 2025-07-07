using System.Numerics;

class Program
{
    static void Main()
    {
        int num = 4;
        int[] result = new int[num + 1];
        Parallel.For(1, num + 1, x => {
            result[x] = x;
        });
        int factorial = 1;
        for (int y = 1; y <= num; y++)
        {
            factorial *= result[y];
        }
        Console.WriteLine($"Factorial {num} - {factorial}");


        Task<int> Count = Task.Run(() =>
            {
                int a = factorial.ToString().Length;
                return a;
            });

        Task<int> Summa = Task.Run(() =>
        {
            int b = factorial.ToString().ToCharArray().Sum(i=>i-'0');
            return b;
        });

        Task.WaitAll(Count, Summa);


        Console.WriteLine($"The number of digits in the number - {Count.Result}");
        Console.WriteLine($"Sum of all digits - {Summa.Result}");
    }
}