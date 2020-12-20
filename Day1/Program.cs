using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int total = 2020;
            string[] rawData = File.ReadAllLines("RawData.txt");

            int[] data = Array.ConvertAll(rawData, int.Parse);
            bool found = false;
            for (var i = 0; i < data.Length; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    int number1 = data[i];
                    int number2 = data[j];
                    int remainder = total - number1 - number2;
                    if (data.Contains(remainder))
                    {
                        found = true;
                        int multiply = number1 * number2 * remainder;
                        Console.WriteLine($"{number1} + {number2} + {remainder} = {total}; {number1} * {number2} * {remainder} = {multiply}");
                        break;
                    }

                    if (found)
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
