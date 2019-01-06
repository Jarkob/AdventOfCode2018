using System;

namespace Day11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int Input = 1308;
            int GridLength = 300;
            int[][] FuelCells = new int[GridLength][];

            int RackID;
            int PowerLevel;
            for (int i = 0; i < GridLength; i++)
            {
                FuelCells[i] = new int[GridLength];
                for (int j = 0; j < GridLength; j++)
                {
                    RackID = j + 11;
                    PowerLevel = RackID * (i + 1);
                    PowerLevel += Input;
                    PowerLevel *= RackID;
                    PowerLevel /= 100;
                    PowerLevel %= 10;
                    PowerLevel -= 5;
                    FuelCells[i][j] = PowerLevel;
                }
            }

            int TotalPower;
            int TotalPowerMax = Int32.MinValue;
            (int, int, int) TotalPowerCoordinates = (-1, -1, -1);

            for (int h = 1; h <= GridLength; h++)
            {
                Console.WriteLine(h);
                for (int i = 0; i < GridLength - h; i++)
                {
                    for (int j = 0; j < GridLength - h; j++)
                    {
                        TotalPower = 0;
                        for (int k = i; k <= i + h; k++)
                        {
                            for (int l = j; l <= j + h; l++)
                            {
                                TotalPower += FuelCells[k][l];
                            }
                        }

                        if (TotalPower > TotalPowerMax)
                        {
                            TotalPowerMax = TotalPower;
                            TotalPowerCoordinates = (j + 1, i + 1, h + 1);
                        }
                    }
                }
            }

            Console.WriteLine(TotalPowerCoordinates.Item1 + "," + TotalPowerCoordinates.Item2 + "," + TotalPowerCoordinates.Item3); // Part1: 21,41
            // Part2: 227,199,19
        }
    }
}
