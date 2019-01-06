using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day10
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Part1: PHLGRNFK
            // Part2: 10407

            string[] Input = File.ReadAllLines("../../input.txt");

            // parse input
            int[][] Points = new int[Input.Length][];
            int X;
            int Y;
            int VX;
            int VY;
            Regex Expression = new Regex(@"-?\d+");
            MatchCollection Matches;
            for (int i = 0, n = Input.Length; i < n; i++)
            {
                Matches = Expression.Matches(Input[i]);
                X = Int32.Parse(Matches[0].Value);
                Y = Int32.Parse(Matches[1].Value);
                VX = Int32.Parse(Matches[2].Value);
                VY = Int32.Parse(Matches[3].Value);
                Points[i] = new int[] { X, Y, VX, VY };
            }

            // calculate min total expansion of the points
            int MinExpansion = Int32.MaxValue;
            int MinExpansionIndex = -1;

            for (int j = 0; j < 10407; j++)
            {
                // move points
                for (int i = 0, n = Points.Length; i < n; i++)
                {
                    Points[i][0] += Points[i][2];
                    Points[i][1] += Points[i][3];
                }

                // get max min
                int MaxX = Int32.MinValue;
                int MinX = Int32.MaxValue;
                int MaxY = Int32.MinValue;
                int MinY = Int32.MaxValue;
                foreach (var Point in Points)
                {
                    MaxX = Math.Max(MaxX, Point[0]);
                    MinX = Math.Min(MinX, Point[0]);
                    MaxY = Math.Max(MaxY, Point[1]);
                    MinY = Math.Min(MinY, Point[1]);
                }

                if (Math.Abs(MaxX - MinX) + Math.Abs(MaxY - MinY) < MinExpansion)
                {
                    MinExpansion = Math.Abs(MaxX - MinX) + Math.Abs(MaxY - MinY);
                    MinExpansionIndex = j;
                }
            }

            Console.WriteLine("MinExpansion at {0}: {1}", MinExpansionIndex, MinExpansion);

            // get max min
            int MaxXFinal = Int32.MinValue;
            int MinXFinal = Int32.MaxValue;
            int MaxYFinal = Int32.MinValue;
            int MinYFinal = Int32.MaxValue;
            foreach (var Point in Points)
            {
                MaxXFinal = Math.Max(MaxXFinal, Point[0]);
                MinXFinal = Math.Min(MinXFinal, Point[0]);
                MaxYFinal = Math.Max(MaxYFinal, Point[1]);
                MinYFinal = Math.Min(MinYFinal, Point[1]);
            }
            // print
            for (int y = MinYFinal; y <= MaxYFinal; y++)
            {
                for (int x = MinXFinal; x <= MaxXFinal; x++)
                {
                    bool Value = false;
                    foreach (var Point in Points)
                    {
                        if (Point[0] == x && Point[1] == y)
                        {
                            Value = true;
                            break;
                        }
                    }
                    Console.Write(Value ? "#" : ".");
                }
                Console.WriteLine();
            }
        }
    }
}
