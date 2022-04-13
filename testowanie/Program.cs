using System.Collections.Generic;
using System;

namespace test
{
    class Program
    {
        static void Main()
        {
            ICollection<string> names = new List<string>();
            names.Add("ewa");
            names.Add("Karol");
            names.Add("Robert");
            foreach (var item in names)
            {
                System.Console.WriteLine(item);
            }

            Console.WriteLine(names.Contains("ewa"));

            ICollection<Student> students = new List<Student>();
            students.Add(new Student() { Name="Ewa",ETCS=10});
            students.Add(new Student() { Name="Karol",ETCS=20});
            students.Add(new Student() { Name="Maciek",ETCS=30});

            Console.WriteLine(students.Contains(new Student() { Name="Ewa",ETCS=10}));
            Console.WriteLine();


            IList<Student> list = (IList<Student>)students;
           // Console.WriteLine(list[0]);

            list.Insert(0, new Student() { Name="Robert",ETCS=16});


            ISet<string> nameSet = new HashSet<string>();
            ISet<Student> StudentGroup = new HashSet<Student>();
            StudentGroup.Add(new Student() { Name="Ewa",ETCS = 16});
            StudentGroup.Add(new Student() { Name="Ewa",ETCS = 16});
            StudentGroup.Add(new Student() { Name="Ewa",ETCS = 16});
            Console.WriteLine(StudentGroup);
            Console.WriteLine(StudentGroup.Contains(new Student() { Name = "Ewa", ETCS = 15 })); 
        }
        class Student
        {
            public string Name { get; set; }
            public int ETCS { get; set; }

            public override bool Equals(object obj)
            {
                Console.WriteLine("Eq");
                return obj is Student student &&
                       Name == student.Name &&
                       ETCS == student.ETCS;
            }

            public override int GetHashCode()
            {
                Console.WriteLine("Hash");
                return HashCode.Combine(Name, ETCS);
            }
        }
    }
}