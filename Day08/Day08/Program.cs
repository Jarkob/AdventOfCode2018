using System;
using System.Collections.Generic;
using System.IO;

namespace Day08
{
    /// <summary>
    /// @author Jakob Bussas
    /// @author ValdasTheUnique
    /// </summary>
    class MainClass
    {
        public static void Main(string[] args)
        {
            string Input = File.ReadAllText("../../input.txt");
            int[] Numbers = Array.ConvertAll(Input.Split(' '), int.Parse);
            int Index = 0;
            TreeElement Root = GetTree(Numbers, ref Index);
            Console.WriteLine(Root.GetSum()); // Part1: 45750
            Console.WriteLine(Root.GetValue()); // Part2: 23266
        }

        private static TreeElement GetTree(int[] Numbers, ref int Index)
        {
            TreeElement Element = new TreeElement();
            int ChildNodes = Numbers[Index++];
            int MetaDataEntries = Numbers[Index++];
            for (int i = 0; i < ChildNodes; i++)
            {
                Element.next.Add(GetTree(Numbers, ref Index));
            }
            for (int i = 0; i < MetaDataEntries; i++)
            {
                Element.MetaData.Add(Numbers[Index++]);
            }
            return Element;
        }
    }
}
