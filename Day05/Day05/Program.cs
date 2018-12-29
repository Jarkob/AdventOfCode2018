using System;
using System.Collections.Generic;
using System.IO;

namespace Day05
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string Input = File.ReadAllText("../../input.txt");
            List<char> Letters = new List<char>(Input.ToCharArray());
            for (int i = 0, n = Letters.Count; i < n - 1; i++)
            {
                if (Letters[i] == Letters[i + 1] + 32 || Letters[i] == Letters[i + 1] - 32)
                {
                    Letters.RemoveAt(i + 1);
                    Letters.RemoveAt(i);
                    n = n < 2 ? 0 : n - 2;
                    i = i == 0 ? -1 : i - 2;
                }
            }
            string Result = new string(Letters.ToArray());
            Console.WriteLine(Result.Length); // Part1: 9808
        }
    }
}
