using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rawData = File.ReadAllLines("RawData.txt");

            IEnumerable<CompanyPassword> passwords = ConvertData(rawData);
            int count = passwords.Count(password => password.IsValid());
            Console.WriteLine($"Count: {count}");
            Console.ReadKey();
        }

        private static IEnumerable<CompanyPassword> ConvertData(string[] rawData)
        {
            return rawData.ToList().Select(s =>
            {
                string[] separatedPassword = SplitString(':', s);
                string password = separatedPassword[1];
                string[] separatedPolicy = SplitString(' ', separatedPassword[0]);
                char character = separatedPolicy[1][0];
                string[] occurence = SplitString('-', separatedPolicy[0]);
                int min = int.Parse(occurence[0]);
                int max = int.Parse(occurence[1]);
                return new CompanyPassword { Character = character, MinCharCount = min, MaxCharCount = max, Password = password};
            });
        }

        private static string[] SplitString(char separator, string item)
        {
            string[] separatedString = item.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] list = separatedString.Select(s => s.Trim(' ')).ToArray();
            return list;
        }
    }

    internal class CompanyPassword
    {
        public char Character { get; set; }
        public int MinCharCount { get; set; }
        public int MaxCharCount { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            char[] chars = Password.AsEnumerable().ToArray();
            return chars[MinCharCount - 1].Equals(Character) ^ chars[MaxCharCount - 1].Equals(Character);
        }
    }
}
