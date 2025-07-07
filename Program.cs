using System.Numerics;

class Program
{
    static void Main()
    {
        int num = 4;
        int[] result = new int[num +1];
        Parallel.For(1, num + 1, x => {
            result[x] = x;
        });
        int factorial = 1;
        for(int y = 1; y<= num; y++)
        {
            factorial *= result[y];
        }
        Console.WriteLine($"Factorial {num} - {factorial}");
    }
}