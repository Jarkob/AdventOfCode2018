using System;
using System.Collections.Generic;
using System.IO;

namespace Day01
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("./../../input.txt");

            Part1(Input); // 437
            Part2(Input); // 655
        }

        private static void Part1(string[] Input)
        {
            int Frequency = 0;
            foreach (var element in Input)
            {
                Frequency += Convert.ToInt32(element);
            }

            Console.WriteLine(Frequency);
        }

        private static void Part2(String[] Input)
        {
            List<int> Frequencies = new List<int>();
            int Frequency = 0;
            Frequencies.Add(Frequency);

            int i = 0;
            while (true)
            {
                Frequency += Convert.ToInt32(Input[i]);

                for (int j = 0, n = Frequencies.Count; j < n; j++)
                {
                    if (Frequencies[j] == Frequency)
                    {
                        Console.WriteLine(Frequency);
                        return;
                    }
                }

                Frequencies.Add(Frequency);

                i++;

                if (i == Input.Length)
                {
                    i = 0;
                }
            }
        }
    }
}
