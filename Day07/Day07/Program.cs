using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day07
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Input = File.ReadAllLines("../../input.txt");

            Console.WriteLine(Part1(Input)); // Part1 GRTAHKLQVYWXMUBCZPIJFEDNSO
            Console.WriteLine(Part2(Input)); // Part2 1115
        }

        private static string Part1(string[] Input)
        {
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

                Graph.GraphElements[Result].Prev.Add(Graph.GraphElements[Condition]);
                Graph.GraphElements[Condition].Next.Add(Graph.GraphElements[Result]);
            }

            List<GraphElement> AvailableElements = Graph.GetAvailableElements();
            StringBuilder stringBuilder = new StringBuilder();
            while (AvailableElements.Count != 0)
            {
                AvailableElements.Sort();
                // make element unavailable and next available
                AvailableElements[0].Prev.Add(new GraphElement('-'));

                for (int i = 0, n = AvailableElements[0].Next.Count; i < n; i++)
                {
                    AvailableElements[0].Next[i].Prev.Remove(AvailableElements[0]);
                }

                stringBuilder.Append(AvailableElements[0].ID);
                AvailableElements = Graph.GetAvailableElements();
            }
            return stringBuilder.ToString();
        }

        private static int Part2(string[] Input)
        {
            // get graph
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

                Graph.GraphElements[Result].Prev.Add(Graph.GraphElements[Condition]);
                Graph.GraphElements[Condition].Next.Add(Graph.GraphElements[Result]);
            }

            StringBuilder stringBuilder = new StringBuilder();

            Worker[] Workers = { new Worker(), new Worker(), new Worker(), new Worker(), new Worker() };
            List<GraphElement> AvailableElements = Graph.GetAvailableElements();
            List<Worker> AvailableWorkers = Worker.GetAvailableWorkers(Workers);
            int Index = 0;
            while (AvailableElements.Count != 0)
            {
                AvailableElements.Sort();

                // remove taken elements
                for (int i = 0; i < AvailableElements.Count; i++)
                {
                    if (AvailableElements[i].Worker != null)
                    {
                        AvailableElements.RemoveAt(i);
                        i--;
                    }
                }

                // assign elements to workers
                for (int i = 0, n = Math.Min(AvailableElements.Count, AvailableWorkers.Count); i < n; i++)
                {
                    AvailableWorkers[i].Element = AvailableElements[i];
                    AvailableElements[i].Worker = AvailableWorkers[i];
                }

                // debug
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}",
                Index, Workers[0].Element != null ? Workers[0].Element.ID : '.', Workers[1].Element != null ? Workers[1].Element.ID : '.', Workers[2].Element != null ? Workers[2].Element.ID : '.',
                    Workers[3].Element != null ? Workers[3].Element.ID : '.', Workers[4].Element != null ? Workers[4].Element.ID : '.', stringBuilder.ToString());

                // work
                for (int i = 0, n = Workers.Length; i < n; i++)
                {
                    if (Workers[i].Element != null)
                    {
                        Workers[i].Element.Workload--;

                        // debug
                        if (Workers[i].Element.Workload < 0)
                        {
                            throw new Exception(Workers[i].Element.Workload.ToString());
                        }

                        if (Workers[i].Element.Workload == 0)
                        {
                            stringBuilder.Append(Workers[i].Element.ID);

                            // set next elements to null
                            for (int j = 0; j < Graph.GraphElements[Workers[i].Element.ID].Next.Count; j++)
                            {
                                Graph.GraphElements[Workers[i].Element.ID].Next[j].Prev.Remove(Graph.GraphElements[Workers[i].Element.ID]);
                            }

                            Workers[i].Element = null;
                        }
                    }
                }

                // calc new availables
                AvailableElements = Graph.GetAvailableElements();
                AvailableWorkers = Worker.GetAvailableWorkers(Workers);

                Index++;
            }

            Console.WriteLine();
            return Index;
        }
    }
}
