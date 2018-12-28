﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day04
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // sort input
            string[] Input = File.ReadAllLines("../../input.txt");
            DateTime[] Times = new DateTime[Input.Length];
            Tuple<DateTime, string>[] SortedInput = new Tuple<DateTime, string>[Input.Length];
            Regex Expression = new Regex(@"\[(.*?)\]");
            for (int i = 0, n = Input.Length; i < n; i++)
            {
                Times[i] = DateTime.Parse(Expression.Match(Input[i]).Value.Substring(1, 16));
                Input[i] = Input[i].Substring(19);
                SortedInput[i] = new Tuple<DateTime, string>(Times[i], Input[i]);
            }
            Array.Sort(SortedInput, new TupleComparer());

            // calculate guards sleeping time
            IDictionary<int, int> Guards = new Dictionary<int, int>();
            List<Tuple<int, int>> SleepMinutes = new List<Tuple<int, int>>();
            for (int j = 0, n = SortedInput.Length; j < n; j++)
            {
                if (SortedInput[j].Item2[0] == 'G')
                {
                    // get guard key
                    int GuardId = Convert.ToInt32(SortedInput[j].Item2.Split(' ')[1].Substring(1));
                    // add guard if not exists already
                    if (!Guards.ContainsKey(GuardId))
                    {
                        Guards.Add(GuardId, 0);
                    }

                    while (j + 1 < n && SortedInput[j + 1].Item2[0] != 'G')
                    {
                        j++;

                        if (SortedInput[j].Item2[0] == 'f')
                        {
                            TimeSpan SleepTime = SortedInput[j + 1].Item1 - SortedInput[j].Item1;
                            Guards[GuardId] += SleepTime.Minutes;

                            // add minutes
                            for (int k = SortedInput[j].Item1.Minute; k < SortedInput[j + 1].Item1.Minute; k++)
                            {
                                SleepMinutes.Add(new Tuple<int, int>(GuardId, k));
                            }

                            j++;
                        }
                        else
                        {
                            throw new Exception("ERROR");
                        }
                    }
                }
            }

            // find laziest guard
            KeyValuePair<int, int> LazyGuard = new KeyValuePair<int, int>(-1, 0);
            foreach (var Element in Guards)
            {
                if (Element.Value > LazyGuard.Value)
                {
                    LazyGuard = Element;
                }
            }

            // find most frequent minutes
            List<int> Minutes = new List<int>();
            foreach (var Element in SleepMinutes)
            {
                if (Element.Item1 == LazyGuard.Key)
                {
                    Minutes.Add(Element.Item2);
                }
            }
            int LaziestMinute = (from Minute in Minutes
                        group Minute by Minute into Group
                        orderby Group.Count() descending
                        select Group.Key).First();

            Console.WriteLine(LazyGuard.Key * LaziestMinute); // Part1: 119835

            // find most frequent SleepMinute
            var MostFrequentMinute = (from Pair in SleepMinutes
                                      group Pair by new { Pair.Item1, Pair.Item2 } into Group
                                      orderby Group.Count() descending
                                      select Group.Key).First();

            Console.WriteLine(MostFrequentMinute.Item1 * MostFrequentMinute.Item2); // Part2: 12725
        }
    }
}
