using System;
using System.Collections.Generic;
using System.IO;

namespace Day12
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../input.txt");
            string InitialState = Input[0].Split(' ')[2];
            // FIXME debug
            //InitialState = "#..#.#..##......###...###";

            //Input = null;
            //Input = new string[]
            //{
            //    "...## => #",
            //    "..#.. => #",
            //    ".#... => #",
            //    ".#.#. => #",
            //    ".#.## => #",
            //    ".##.. => #",
            //    ".#### => #",
            //    "#.#.# => #",
            //    "#.### => #",
            //    "##.#. => #",
            //    "##.## => #",
            //    "###.. => #",
            //    "###.# => #",
            //    "####. => #"
            //};

            bool[] Pots = new bool[InitialState.Length + 250];
            // 200 is the new 0
            for (int i = 200, n = Pots.Length - 50; i < n; i++)
            {
                Pots[i] = InitialState[i - 200] == '#';
            }

            IDictionary<Tuple<bool, bool, bool, bool, bool>, bool> Rules = new Dictionary<Tuple<bool, bool, bool, bool, bool>, bool>();
            for (int j = 2; j < Input.Length; j++)
            {
                Rules.Add(new KeyValuePair<Tuple<bool, bool, bool, bool, bool>, bool>(new Tuple<bool, bool, bool, bool, bool>(
                Input[j][0] == '#',
                Input[j][1] == '#',
                Input[j][2] == '#',
                Input[j][3] == '#',
                Input[j][4] == '#'
                ), Input[j][9] == '#'));
            }

            for (int k = 0; k < 20; k++)
            {
                // FIXME debug
                // print
                for (int i = 190; i < 240; i++)
                {
                    Console.Write(Pots[i] ? '#' : '.');
                }
                Console.WriteLine();


                // save old pots
                bool[] NewPots = new bool[Pots.Length];
                for (int i = 0; i < Pots.Length; i++)
                {
                    NewPots[i] = Pots[i];
                }

                // execute rules
                for (int l = 2, n = Pots.Length - 2; l < n; l++)
                {
                    if (Rules.ContainsKey(
                    new Tuple<bool, bool, bool, bool, bool>(Pots[l - 2], Pots[l - 1], Pots[l], Pots[l + 1], Pots[l + 2])))
                    {
                        NewPots[l] = Rules[new Tuple<bool, bool, bool, bool, bool>(Pots[l - 2], Pots[l - 1], Pots[l], Pots[l + 1], Pots[l + 2])];
                    }
                }

                Pots = null;
                Pots = NewPots;
            }

            // get sum
            int Sum = 0;
            for (int m = 0, n = Pots.Length; m < n; m++)
            {
                if (Pots[m])
                {
                    Sum += m - 200;
                }
            }
            Console.WriteLine(Sum); // Part1: 3494
        }
    }
}
