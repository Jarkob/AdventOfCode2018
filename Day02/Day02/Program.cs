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
            Part2(Input); // agimdjvlhedpsyoqfzuknpjwt
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
                        if (Id[i] == Id[j])
                        {
                            Amounts[j]++;
                            break;
                        }
                    }
                }


                bool Two = false;
                bool Three = false;
                foreach (var element in Amounts)
                {
                    if (element == 2)
                    {
                        Two = true;
                    }
                    else if (element == 3)
                    {
                        Three = true;
                    }
                }

                if (Two) { Twos++; }
                if (Three) { Threes++; }
            }

            int Checksum = Twos * Threes;

            Console.WriteLine(Checksum);
        }

        private static void Part2(string[] Input)
        {
            for (int i = 0, n = Input.Length; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // check for inequality
                    bool Inequal = false;
                    bool Wrong = false;
                    for (int k = 0; k < Input[i].Length; k++)
                    {
                        if (Input[i][k] != Input[j][k])
                        {
                            if (Inequal)
                            {
                                Wrong = true;
                                break;
                            }
                            else
                            {
                                Inequal = true;
                            }
                        }
                    }
                    if (!Wrong)
                    {
                        // format
                        string Result = "";
                        for (int l = 0; l < Input[i].Length; l++)
                        {
                            if (Input[i][l] == Input[j][l])
                            {
                                Result += Input[i][l];
                            }
                        }
                        Console.WriteLine(Result);
                    }
                }
            }
        }
    }
}
