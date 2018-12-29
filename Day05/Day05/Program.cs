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
            Console.WriteLine(Part1(Input)); // Part1: 9808
            Console.WriteLine(Part2(Input));
        }

        private static int Part1(string Input)
        {
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
            return Result.Length;
        }

        private static int Part2(string Input)
        {
            int[] Lengths = new int[26];
            List<char> Letters = new List<char>(Input.ToCharArray());
            List<char> FilteredLetters;
            for (int i = 65; i < 91; i++)
            {
                FilteredLetters = new List<char>();
                foreach (var Element in Letters)
                {
                    if (Element != i && Element != i + 32)
                    {
                        FilteredLetters.Add(Element);
                    }
                }
                Lengths[i - 65] = Part1(new string(FilteredLetters.ToArray()));
            }

            int MinLength = Int32.MaxValue;
            foreach (var Element in Lengths)
            {
                if (Element < MinLength)
                {
                    MinLength = Element;
                }
            }
            return MinLength; // 9462 too high
        }
    }
}
