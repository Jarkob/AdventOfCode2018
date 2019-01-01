using System;
using System.Collections.Generic;
namespace Day07
{
    public class GraphElement : IComparable
    {
        public GraphElement(char ID)
        {
            this.ID = ID;
            this.Prev = new List<GraphElement>();
            this.Next = new List<GraphElement>();
            this.Workload = this.ID - 64 + 60;
        }

        public char ID { get; set; }
        public List<GraphElement> Prev { get; set; }
        public List<GraphElement> Next { get; set; }
        public int Workload { get; set; }
        public Worker Worker { get; set; }

        public int CompareTo(object obj)
        {
            GraphElement Element = (GraphElement) obj;
            return this.ID.CompareTo(Element.ID);
        }
    }
}
