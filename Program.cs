using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int[] array = { 8,9,5,2,4,5,6,7,6,7,4,3,2,1,7,9 };
        int goal = 1;

        Task<int[]> removeDub = Task.Run(() =>
        {
            Console.WriteLine("Deleted dublicate...");
            return array.Distinct().ToArray();
        });

        Task<int[]> sortTask = removeDub.ContinueWith(prevTask =>
        {
            Console.WriteLine("Sorted array...");
            var sorted = prevTask.Result.OrderBy(x => x).ToArray();
            Console.WriteLine("Updated masiv: " + string.Join(", ", sorted));
            return sorted;
        });

        Task binarySearch = sortTask.ContinueWith(prevTask =>
        {
            Console.WriteLine("Binary search...");
            int index = Array.BinarySearch(prevTask.Result, goal);
            Console.WriteLine(index >= 0
                ? $"Element {goal} found in position {index}."
                : $"Element {goal} not found.");
        });

        binarySearch.Wait();
    }
}
