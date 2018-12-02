using System;
using System.IO;

namespace Day02
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../input.txt");

            Part1(Input); // 5434
        }

        private static void Part1(string[] Input)
        {
            int Twos = 0;
            int Threes = 0;

            foreach (var Id in Input)
            {
                int[] Amounts = new int[Id.Length];

                for (int i = 0, n = Amounts.Length; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if(Id[i] == Id[j]) {
                            Amounts[j]++;
                            break;
                        }
                    }
                }


                bool Two = false;
                bool Three = false;
                foreach(var element in Amounts)
                {
                    if(element == 2) {
                        Two = true;
                    } else if (element == 3) {
                        Three = true;
                    }
                }

                if (Two) { Twos++; }
                if (Three) { Threes++; }
            }

            int Checksum = Twos * Threes;

            Console.WriteLine(Checksum);
        }
    }
}
