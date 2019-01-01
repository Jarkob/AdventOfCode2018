using System;
using System.Collections.Generic;
namespace Day07
{
    public class Worker
    {
        public Worker()
        {
        }

        public GraphElement Element { get; set; }

        public static List<Worker> GetAvailableWorkers(Worker[] Workers)
        {
            List<Worker> AvailableWorkers = new List<Worker>();
            foreach (var Element in Workers)
            {
                if (Element.Element == null)
                {
                    AvailableWorkers.Add(Element);
                }
            }
            return AvailableWorkers;
        }
    }
}
