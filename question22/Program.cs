using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------
            // Part A: Re-write LINQ query using a lambda expression
            // Original query: where element < 5, orderby element
            // -------------------------------------------------------
            Console.WriteLine("=== Part A: Lambda re-write of LINQ query ===");

            int[] array = { 10, 7, 4, 2, 2, 7, 9, 3, 6, 1 };

            // Lambda equivalent of: where element < 5, orderby element, select element
            var partA = array.Where(e => e < 5)
                             .OrderBy(e => e);

            Console.Write("Elements less than 5 (sorted): ");
            foreach (var item in partA)
                Console.Write(item + " ");
            Console.WriteLine();

            // -------------------------------------------------------
            // Part B: Count odd numbers using Aggregate with seed = 0
            // -------------------------------------------------------
            Console.WriteLine("\n=== Part B: Count odd numbers (seed = 0) ===");

            int oddCount = array.Aggregate(0, (count, e) => e % 2 != 0 ? count + 1 : count);

            Console.WriteLine($"Number of odd elements: {oddCount}");

            // -------------------------------------------------------
            // Part C: Print List in reversed order using lambda
            // -------------------------------------------------------
            Console.WriteLine("\n=== Part C: List in reversed order ===");

            var listC = new List<int> { 10, 7, 4, 2, 2, 7, 9, 3, 6, 1 };

            // Use OrderByDescending or Reverse via lambda/arrow operator
            var reversed = listC.AsEnumerable().Reverse();

            Console.Write("Reversed list: ");
            reversed.ToList().ForEach(e => Console.Write(e + " "));
            Console.WriteLine();

            // -------------------------------------------------------
            // Part D: Print min, max, average of a List
            // -------------------------------------------------------
            Console.WriteLine("\n=== Part D: Min, Max, Average ===");

            var listD = new List<int> { 10, 7, 4, 2, 2, 7, 9, 3, 6, 1 };

            int    min     = listD.Min();
            int    max     = listD.Max();
            double average = listD.Average();

            Console.WriteLine($"Minimum : {min}");
            Console.WriteLine($"Maximum : {max}");
            Console.WriteLine($"Average : {average}");

            // -------------------------------------------------------
            // EXTRA: LINQ vs PLINQ comparison
            // -------------------------------------------------------
            Console.WriteLine("\n=== EXTRA: LINQ vs PLINQ ===");

            int[] bigArray = Enumerable.Range(1, 1_000_000).ToArray();

            // LINQ (sequential)
            var linqStart = DateTime.Now;
            var linqResult = bigArray.Where(n => n % 2 == 0).Count();
            var linqTime = (DateTime.Now - linqStart).TotalMilliseconds;

            // PLINQ (parallel) — uses all available CPU cores
            var plinqStart = DateTime.Now;
            var plinqResult = bigArray.AsParallel().Where(n => n % 2 == 0).Count();
            var plinqTime = (DateTime.Now - plinqStart).TotalMilliseconds;

            Console.WriteLine($"LINQ  result: {linqResult}  | Time: {linqTime} ms");
            Console.WriteLine($"PLINQ result: {plinqResult} | Time: {plinqTime} ms");
            Console.WriteLine("PLINQ uses AsParallel() to distribute work across CPU cores.");
            Console.WriteLine("For small datasets LINQ is faster (no thread overhead).");
            Console.WriteLine("PLINQ shines on large datasets with CPU-bound operations.");
        }
    }
}
