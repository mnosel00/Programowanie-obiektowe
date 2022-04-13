using System.Collections.Generic;
using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main()
        {



            string[] arr = { "dd", "aa", "cc", "ss", "aa", "dd", "r", "aa" };
            Console.WriteLine("oblicz liczbe wystapien kazdego z lancuchów"); 
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var item in arr)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.WriteLine();
            Console.WriteLine("wyznacz czesc wspolna obu tablic");
            int[] set1 = { 2, 33, 6, 6, 1, 7, 8, 9, 10 };
            int[] set2 = { 3, 6, 8, 9, 11, 2, 1, 78 };
            //wyznacz czesc wspolna obu tablic
            var intersect = set1.Intersect(set2);

            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
        }

    }
}