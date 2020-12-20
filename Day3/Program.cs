using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] slopes = { new[] { 1, 1 }, new[] {3, 1}, new[] { 5, 1 }, new[] { 7, 1 }, new[] { 1, 2 } };
            string[] rawData = File.ReadAllLines("RawData.txt");

            int lineCount = rawData.Length;
            int lineLen = rawData.First().Length;

            long total = 1;
            for (int i = 0; i < slopes.Length; i++)
            {
                decimal divider = Math.Round((decimal)lineLen / (decimal)slopes[i][0] * (decimal)slopes[i][1]);
                decimal paddingCount = Math.Round((decimal)lineCount / divider, MidpointRounding.ToPositiveInfinity);
                List<string> list = rawData.ToList();
                IEnumerable<string> enrichedData = list.Select(s => string.Concat(Enumerable.Repeat(s, (int)paddingCount)));
                int count = Calculate(enrichedData, 0, 0, slopes[i][0], slopes[i][1]);
                total = total * count;
                Console.WriteLine($"Count: {count}"); 
            }
            Console.WriteLine($"Total: {total}");
            Console.ReadKey();
        }

        private static int Calculate(IEnumerable<string> enrichedData, int x, int y, int stepX, int stepY)
        {
            if (InRange(enrichedData, x, y))
            {
                return IsTree(enrichedData, x, y) + Calculate(enrichedData, x + stepX, y + stepY, stepX, stepY);
            }

            return 0;
        }

        private static bool InRange(IEnumerable<string> enrichedData, int x, int y)
        {
            return x < enrichedData.First().Length && y < enrichedData.Count();
        }

        private static int IsTree(IEnumerable<string> full, int x, int y)
        {
            return full.ElementAt(y)[x] == '#' ? 1 : 0;
        }
    }
}
