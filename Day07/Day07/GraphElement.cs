using System;
using System.Collections.Generic;
namespace Day07
{
    public class GraphElement : IComparable
    {
        public GraphElement(char ID)
        {
            this.ID = ID;
            this.prev = new List<GraphElement>();
            this.next = new List<GraphElement>();
        }

        public char ID { get; set; }
        public List<GraphElement> prev { get; set; }
        public List<GraphElement> next { get; set; }

        public int CompareTo(object obj)
        {
            GraphElement Element = (GraphElement) obj;
            return this.ID.CompareTo(Element.ID);
        }
    }
}
