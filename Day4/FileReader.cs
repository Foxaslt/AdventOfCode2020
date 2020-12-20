using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day4
{
    class FileReader
    {
        public IEnumerable<string> ReadFile(string fileName)
        {
            IEnumerable<string> data = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string passport = string.Empty;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {

                    }
                }
            }
            return data;
        }
    }
}
