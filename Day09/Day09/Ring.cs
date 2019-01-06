using System;
using System.Collections.Generic;
using System.Text;

namespace Day09
{
    public class Ring
    {
        public Ring()
        {
            this.Marbles = new LinkedList<int>();
            this.Marbles.AddFirst(0);
            this.Current = this.Marbles.First;
        }

        public LinkedListNode<int> Current { get; set; }
        public LinkedList<int> Marbles { get; set; }

        public void InsertClockWise(int Marble)
        {
            this.Current = this.Current.Next ?? this.Marbles.First;
            this.Marbles.AddAfter(this.Current, Marble);
            this.Current = this.Current.Next;
        }

        public int RemoveCounterClockWise()
        {
            for (int i = 0; i < 7; i++)
            {
                this.Current = this.Current.Previous ?? this.Marbles.Last;
            }
            int Value = this.Current.Value;
            this.Current = this.Current.Next ?? this.Marbles.First;
            this.Marbles.Remove(Current.Previous ?? this.Marbles.Last);
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
