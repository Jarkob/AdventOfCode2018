using System;
using System.Collections.Generic;

namespace Day12
{
    public class TwoSideList
    {
        public TwoSideList()
        {
            this.PositiveList = new List<int>();
            this.NegativeList = new List<int>();
        }

        private List<int> PositiveList;
        private List<int> NegativeList;

        public int Get(int Index)
        {
            return Index >= 0 ? this.PositiveList[Index] : this.NegativeList[Index + 1];
        }

        public int GetLength()
        {
            return this.PositiveList.Count + this.NegativeList.Count;
        }
    }
}
