using System;
using System.Collections.Generic;
using System.IO;

namespace Day06
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../input.txt");
            Console.WriteLine(Part1(Input)); // 5532
            Console.WriteLine(Part2(Input)); // 36216
        }

        private static int Part1(string[] Input)
        {
            List<Tuple<int, int>> Coordinates = new List<Tuple<int, int>>();
            string[] Parts;
            foreach (string Line in Input)
            {
                Parts = Line.Split(',');
                Coordinates.Add(new Tuple<int, int>(Int32.Parse(Parts[0]), Int32.Parse(Parts[1].Trim())));
            }

            // search min, max, vertically, horizontally
            int MaxHorizontally = Int32.MinValue;
            int MinHorizontally = Int32.MaxValue;
            int MaxVertically = Int32.MinValue;
            int MinVertically = Int32.MaxValue;
            for (int i = 0, n = Coordinates.Count; i < n; i++)
            {
                if (Coordinates[i].Item1 > MaxHorizontally)
                {
                    MaxHorizontally = Coordinates[i].Item1;
                }
                if (Coordinates[i].Item2 > MaxVertically)
                {
                    MaxVertically = Coordinates[i].Item2;
                }
                if (Coordinates[i].Item1 < MinHorizontally)
                {
                    MinHorizontally = Coordinates[i].Item1;
                }
                if (Coordinates[i].Item2 < MinVertically)
                {
                    MinVertically = Coordinates[i].Item2;
                }
            }

            int WidthHeight = 400; // TODO: auf 100 aufrunden
            WidthHeight = Math.Max(MaxVertically, MaxHorizontally);

            int[][][] Grid = new int[WidthHeight][][];
            for (int i = 0, n = Grid.Length; i < n; i++)
            {
                Grid[i] = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    Grid[i][j] = new int[] { -1, Int32.MaxValue };
                }
            }

            int Distance;
            for (int i = 0, n = Coordinates.Count; i < n; i++)
            {
                for (int j = 0, m = Grid.Length; j < m; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        Distance = Math.Abs(Coordinates[i].Item1 - k) + Math.Abs(Coordinates[i].Item2 - j);

                        if (Grid[j][k][1] > Distance)
                        {
                            Grid[j][k] = new int[] { i, Distance };
                        }
                        else if (Grid[j][k][1] == Distance)
                        {
                            Grid[j][k] = new int[] { -1, Distance };
                        }
                    }
                }
            }
            //Print(Grid);

            // filter out infinite areas
            List<int> InfiniteAreaIndices = new List<int>();
            for (int i = 0, n = Grid.Length; i < n - 1; i++)
            {
                if (!InfiniteAreaIndices.Contains(Grid[0][i][0]) && Grid[0][i][0] == Grid[0][i + 1][0])
                {
                    InfiniteAreaIndices.Add(Grid[0][i][0]);
                }
            }
            for (int i = 0, n = Grid.Length; i < n - 1; i++)
            {
                if (!InfiniteAreaIndices.Contains(Grid[i][0][0]) && Grid[i][0][0] == Grid[i + 1][0][0])
                {
                    InfiniteAreaIndices.Add(Grid[i][0][0]);
                }
            }
            for (int i = 0, n = Grid.Length; i < n - 1; i++)
            {
                if (!InfiniteAreaIndices.Contains(Grid[n - 1][i][0]) && Grid[n - 1][i][0] == Grid[n - 1][i + 1][0])
                {
                    InfiniteAreaIndices.Add(Grid[n - 1][i][0]);
                }
            }
            for (int i = 0, n = Grid.Length; i < n - 1; i++)
            {
                if (!InfiniteAreaIndices.Contains(Grid[i][n - 1][0]) && Grid[i][n - 1][0] == Grid[i + 1][n - 1][0])
                {
                    InfiniteAreaIndices.Add(Grid[i][n - 1][0]);
                }
            }

            InfiniteAreaIndices.Remove(-1);

            // find biggest area
            int[] Sizes = new int[Coordinates.Count - InfiniteAreaIndices.Count];
            int Index = 0;
            int Size;
            for (int i = 0; i < Coordinates.Count; i++)
            {
                if (!InfiniteAreaIndices.Contains(i))
                {
                    // calculate size
                    Size = 0;
                    foreach (var Row in Grid)
                    {
                        foreach (var Cell in Row)
                        {
                            if (Cell[0] == i)
                            {
                                Size++;
                            }
                        }
                    }
                    Sizes[Index] = Size;
                    Index++;
                }
            }

            // find biggest in sizes
            int Maximum = Int32.MinValue;
            foreach (var Element in Sizes)
            {
                if (Element > Maximum)
                {
                    Maximum = Element;
                }
            }

            return Maximum;
        }

        private static int Part2(string[] Input)
        {
            List<Tuple<int, int>> Coordinates = new List<Tuple<int, int>>();
            string[] Parts;
            foreach (string Line in Input)
            {
                Parts = Line.Split(',');
                Coordinates.Add(new Tuple<int, int>(Int32.Parse(Parts[0]), Int32.Parse(Parts[1].Trim())));
            }

            // search min, max, vertically, horizontally
            int MaxHorizontally = Int32.MinValue;
            int MinHorizontally = Int32.MaxValue;
            int MaxVertically = Int32.MinValue;
            int MinVertically = Int32.MaxValue;
            for (int i = 0, n = Coordinates.Count; i < n; i++)
            {
                if (Coordinates[i].Item1 > MaxHorizontally)
                {
                    MaxHorizontally = Coordinates[i].Item1;
                }
                if (Coordinates[i].Item2 > MaxVertically)
                {
                    MaxVertically = Coordinates[i].Item2;
                }
                if (Coordinates[i].Item1 < MinHorizontally)
                {
                    MinHorizontally = Coordinates[i].Item1;
                }
                if (Coordinates[i].Item2 < MinVertically)
                {
                    MinVertically = Coordinates[i].Item2;
                }
            }
            int WidthHeight = 400; // TODO: adjust manually

            int[][][] Grid = new int[WidthHeight][][];
            for (int i = 0, n = Grid.Length; i < n; i++)
            {
                Grid[i] = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    Grid[i][j] = new int[] { 0, 0 };
                }
            }

            int Distance;
            for (int i = 0, n = Coordinates.Count; i < n; i++)
            {
                for (int j = 0, m = Grid.Length; j < m; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        Distance = Math.Abs(Coordinates[i].Item1 - k) + Math.Abs(Coordinates[i].Item2 - j);

                        Grid[j][k][1] += Distance;
                    }
                }
            }

            int Count = 0;
            foreach (var Row in Grid)
            {
                foreach (var Cell in Row)
                {
                    if (Cell[1] < 10000) // TODO: adjust manually
                    {
                        Count++;
                    }
                }
            }

            return Count;
        }

        private static void Print(int[][][] Grid)
        {
            foreach (var Row in Grid)
            {
                foreach (var Cell in Row)
                {
                    Console.Write(Cell[0] == -1 ? "  ." : string.Format("{0,3}", Cell[0]));
                }
                Console.WriteLine();
            }
        }
    }
}
