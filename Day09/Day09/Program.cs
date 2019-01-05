using System;

namespace Day09
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // 416 players; last marble is worth 71617 points

            int NumberOfPlayers = 416;
            int NumberOfMarbles = 71617;

            //NumberOfMarbles = 7999; // FIXME
            //NumberOfPlayers = 13; // FIXME

            int[] PlayerScores = new int[NumberOfPlayers];
            int Player = 0;

            Ring Marbles = new Ring();

            for (int Marble = 1; Marble <= NumberOfMarbles; Marble++)
            {
                if (Marble % 23 == 0)
                {
                    PlayerScores[Player] += Marble;
                    PlayerScores[Player] += Marbles.RemoveCounterClockWise();
                }
                else
                {
                    Marbles.InsertClockWise(Marble);
                }
                //Console.WriteLine(Marbles.ToString());

                Player = Player == NumberOfPlayers - 1 ? 0 : Player + 1;
            }

            // find highscore
            int HighScore = 0;
            foreach (var Score in PlayerScores)
            {
                if (Score > HighScore)
                {
                    HighScore = Score;
                }
            }

            Console.WriteLine("Highscore: {0}", HighScore); // Part1: 436720
        }
    }
}
