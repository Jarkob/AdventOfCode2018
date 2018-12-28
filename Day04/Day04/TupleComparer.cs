using System;
using System.Collections.Generic;

namespace Day04
{
    public class TupleComparer : IComparer<Tuple<DateTime, string>>
    {
        public int Compare(Tuple<DateTime, string> tuple1, Tuple<DateTime, string> tuple2)
        {
            return tuple1.Item1.CompareTo(tuple2.Item1);
        }
    }
}
