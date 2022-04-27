using System;
using System.Collections.Generic;
using System.Linq;

namespace lab8___27._04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(){ "adam", "ewa", "ola", "karol", "robert" };

            Predicate<string> NamesA = s =>
            {
                Console.WriteLine("Predicate " + s);
                return s.StartsWith("a");
            };
         

            IEnumerable<string> result = from name in names where NamesA.Invoke(name) && name.Length==4
            select name;

            Console.WriteLine("Ewaluacja");
            Console.WriteLine(string.Join("\n",result));



            int[] ints = { 4, 6, 3, 6, 8, 2, 8 };

            IEnumerable<int> result2 = from integ in ints where integ%2==0 select integ;

            Console.WriteLine("zadanie 2");
            Console.WriteLine(string.Join("\n",result2));


            List<Student> students = new List<Student>()
            {
                new Student(){Name="Ewa",ETCS=45},
                new Student(){Name="Ewa1",ETCS=23},
                new Student(){Name="Ewa2",ETCS=67},
                new Student(){Name="Ewa3",ETCS=34},
                new Student(){Name="Ewa4",ETCS=15},
                
            };


            IEnumerable<string> result3 = from student in students where student.ETCS > 20 select student.Name.ToUpper();
            Console.WriteLine(string.Join(", ",result3));


            IEnumerable<(string Name, string)> egzamin = from student in students select (student.Name, student.ETCS > 20 ? "zdał" : "nie zdał");
            Console.WriteLine(string.Join(", ",egzamin));

            Console.WriteLine();

            IEnumerable<IGrouping<int, object>> groups = from s in students group s by s.ETCS;
            foreach (var item in groups)
            {
                Console.WriteLine(item.Key +" " + string.Join(", ",item));
            }

            Console.WriteLine();


            IEnumerable<IGrouping<int, int>> intGroups = from x in ints group x by x;
            foreach (var item in intGroups)
            {
                Console.WriteLine(item.Key + " " + string.Join(", ",item));
            }

            Console.WriteLine();

            IEnumerable<(int Key, int)> enumerable = from n in ints group n by n into gr select(gr.Key, gr.Count<int>());
            foreach (var item in enumerable)
            {
                Console.WriteLine(item.Key + ": " + item.Item2);
            }

            Console.WriteLine();
            Console.WriteLine("Fluent API");

            students.Where(student => student.ETCS > 20).Select(student => student.Name);

            Console.WriteLine(string.Join(", ", ints.Where(x => x % 2 == 0).Select(x => x)));

            Console.WriteLine();

            Console.WriteLine(ints.Sum());
            Console.WriteLine(ints.Average());
            Console.WriteLine();

            Console.WriteLine("Funkcja agregująca");

            string vv = ints.Aggregate("", (accu, item) => accu + item);
            Console.WriteLine(vv);

            IEnumerable<int> from0to10 = Enumerable.Range(0, 10);
            Console.WriteLine(string.Join(", ", from0to10));
            int r = Enumerable.Range(0, 100).Where(n => n % 2 == 0).Sum();
            Random random = new Random();
            random.Next(10);

            //wygeneruj tablice 100 liczb od 0-9

           int[] randomints = Enumerable.Range(0, 100).Select(n => random.Next(10)).ToArray();
            Console.WriteLine(string.Join(", ",randomints));

        }
        class Student
        {
            public string Name { get; set; }
            public int ETCS { get; set; }
        }
    }

  
}
