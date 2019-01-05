using System;
using System.Collections.Generic;
using System.Text;

namespace Day09
{
    public class Ring
    {
        public Ring()
        {
            this.Marbles = new List<int>();
            this.Index = 0;
            this.Marbles.Add(0);
        }

        public int Index;
        public List<int> Marbles { get; set; }

        public void InsertClockWise(int Marble)
        {
            if (this.Index == this.Marbles.Count - 1)
            {
                this.Marbles.Insert(1, Marble);
                this.Index = 1;
            }
            else if (this.Index == this.Marbles.Count - 2)
            {
                this.Marbles.Add(Marble);
                this.Index = this.Marbles.Count - 1;
            }
            else
            {
                Index += 2;
                this.Marbles.Insert(Index, Marble);
            }
        }

        public int RemoveCounterClockWise()
        {
            Index -= 7;
            int Value = -1;
            if (Index < 0)
            {
                Index = this.Marbles.Count + Index;
            }
            Value = this.Marbles[Index];
            this.Marbles.RemoveAt(Index);
            return Value;
        }

        public override string ToString()
        {
            StringBuilder Builder = new StringBuilder();
            foreach (var Element in this.Marbles)
            {
                Builder.Append(string.Format("{0,4}", Element));
            }
            return Builder.ToString();
        }
    }
}
