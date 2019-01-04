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
    }
}
