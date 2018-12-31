using System;
using System.Collections.Generic;
using System.IO;

namespace Day07
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../input.txt");
            Graph Graph = new Graph();

            char Condition;
            char Result;
            foreach (var Command in Input)
            {
                Condition = Command[5];
                Result = Command[36];

                if (!Graph.GraphElements.ContainsKey(Result))
                {
                    Graph.GraphElements.Add(Result, new GraphElement(Result));
                }
                if (!Graph.GraphElements.ContainsKey(Condition))
                {
                    Graph.GraphElements.Add(Condition, new GraphElement(Condition));
                }

                Graph.GraphElements[Result].prev.Add(Graph.GraphElements[Condition]);
                Graph.GraphElements[Condition].next.Add(Graph.GraphElements[Result]);
            }

            List<GraphElement> AvailableElements = Graph.GetAvailableElements();
            while (AvailableElements.Count != 0)
            {
                AvailableElements.Sort();
                // make element unavailable and next available
                AvailableElements[0].prev.Add(new GraphElement('-'));

                for (int i = 0, n = AvailableElements[0].next.Count; i < n; i++)
                {
                    AvailableElements[0].next[i].prev.Remove(AvailableElements[0]);
                }

                Console.Write(AvailableElements[0].ID);
                AvailableElements = Graph.GetAvailableElements();
            }
            Console.WriteLine(); // Part1 GRTAHKLQVYWXMUBCZPIJFEDNSO
        }
    }
}
