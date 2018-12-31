using System;
using System.Collections.Generic;
namespace Day07
{
    public class Graph
    {
        public Graph()
        {
            this.GraphElements = new Dictionary<char, GraphElement>();
        }

        public IDictionary<char, GraphElement> GraphElements { get; set; }
    
        public List<GraphElement> GetAvailableElements()
        {
            List<GraphElement> AvailableElements = new List<GraphElement>();
            foreach (var Element in this.GraphElements)
            {
                if (Element.Value.prev.Count == 0)
                {
                    AvailableElements.Add(Element.Value);
                }
            }
            return AvailableElements;
        }
    }
}
