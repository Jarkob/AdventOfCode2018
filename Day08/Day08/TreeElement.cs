using System;
using System.Collections.Generic;
namespace Day08
{
    public class TreeElement
    {
        public TreeElement()
        {
            this.next = new List<TreeElement>();
            this.MetaData = new List<int>();
        }

        public List<TreeElement> next { get; set; }
        public TreeElement prev { get; set; }
        public List<int> MetaData { get; set; }

        public int GetSum()
        {
            int Sum = 0;
            foreach (var Element in this.next)
            {
                Sum += Element.GetSum();
            }

            foreach (var MetaDataEntry in this.MetaData)
            {
                Sum += MetaDataEntry;
            }

            return Sum;
        }

        public int GetValue()
        {
            if (this.next.Count == 0)
            {
                return this.GetSum();
            }
            else
            {
                int Value = 0;
                foreach (var MetaDataEntry in this.MetaData)
                {
                    if (this.next.Count >= MetaDataEntry)
                    {
                        Value += this.next[MetaDataEntry - 1].GetValue();
                    }
                }
                return Value;
            }
        }
    }
}
