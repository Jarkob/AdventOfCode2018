using System;
using System.Collections.Generic;
using System.IO;

namespace Day03
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../input.txt");

            //Input = null;
            //Input = new string[] {"#1 @ 1,3: 4x4",
            //    "#2 @ 3,1: 4x4",
            //    "#3 @ 5,5: 2x2"
            //};

            Part1(Input); // 110383
        }

        private static void Part1(string[] Input)
        {
            // format input
            Claim[] Claims = new Claim[Input.Length];
            for (int i = 0, n = Input.Length; i < n; i++)
            {
                string[] Parts = Input[i].Split(' ');
                int Id = Convert.ToInt32(Parts[0].Substring(1));
                int PaddingLeft = Convert.ToInt32(Parts[2].Split(',')[0]);
                int PaddingTop = Convert.ToInt32(Parts[2].Split(',')[1].Split(':')[0]);
                int Width = Convert.ToInt32(Parts[3].Split('x')[0]);
                int Height = Convert.ToInt32(Parts[3].Split('x')[1]);

                Claims[i] = new Claim(Id, PaddingLeft, PaddingTop, Width, Height);
            }

            // initialize grid
            int[][] Grid = new int[1000][];
            for (int i = 0, n = Grid.Length; i < n; i++)
            {
                Grid[i] = new int[1000];
            }

            // distribute claims
            foreach (var Claim in Claims)
            {
                for (int i = Claim.PaddingLeft; i < Claim.PaddingLeft + Claim.Width; i++)
                {
                    for (int j = Claim.PaddingTop; j < Claim.PaddingTop + Claim.Height; j++)
                    {
                        Grid[i][j]++;
                    }
                }
            }

            // count overlaps
            int Overlaps = 0;
            foreach (var Row in Grid)
            {
                foreach (var Element in Row)
                {
                    if (Element > 1)
                    {
                        Overlaps++;
                    }
                }
            }

            Console.WriteLine(Overlaps);
        }
    }
}
