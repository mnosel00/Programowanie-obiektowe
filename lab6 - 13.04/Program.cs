using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6___13._04
{
    class Program : KsiazkaAdresowa
    {
        static void Main(string[] args)
        {
            //ZAD 1 STUDENCI

            /*List<Student> students = new List<Student>
            {
                new Student{ Name = "A", Surname = "a", Grade = 3 },
                new Student{ Name = "H", Surname = "h", Grade = 4 },
                new Student{ Name = "B", Surname = "b", Grade = 4 },
                new Student{ Name = "F", Surname = "f", Grade = 2 },
                new Student{ Name = "C", Surname = "c", Grade = 5 },
                new Student{ Name = "D", Surname = "d", Grade = 6 },
                new Student{ Name = "E", Surname = "e", Grade = 1 },
                new Student{ Name = "I", Surname = "i", Grade = 5 },
                new Student{ Name = "G", Surname = "g", Grade = 3 },
                new Student{ Name = "J", Surname = "j", Grade = 6 },
                new Student { Name = "L", Surname = "l", Grade = 1 },
                new Student { Name = "test", Surname = "test", Grade = 1 },
            };

            if (CzyPelna(students))
            {
                Console.WriteLine($"Grupa Jest zapełniona. Znajduje się w niej {students.Count} studentów");
                while (students.Count > 10)
                {
                    int a = students.Count-1;
                    Console.WriteLine($"Usuwanie ostatnio dodanego studenta ({students[a].Name} {students[a].Surname}) ");
                    students.RemoveAt(students.Count - 1);
                }
                Console.WriteLine("Lista studentów zapisanych do grupy");
                foreach (var item in students)
                {
                    Console.Write($"({item.Name} {item.Surname})");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Grupa Liczy {students.Count}, można zapisywać");
                Console.WriteLine("Lista Zapisanych studentów");
                foreach (var item in students)
                {
                    Console.Write($"({item.Name} {item.Surname})");
                }
                Console.WriteLine();

            }
            Console.WriteLine();
            Console.WriteLine("Zwraca listę: ");
            Console.WriteLine();
            Console.WriteLine("W kolejności ich dodawania");
            GetLista(students);
            Console.WriteLine();
            Console.WriteLine("Posortowaną po imionach");
            GetListaByName(students);
            Console.WriteLine();
            Console.WriteLine("Posortowaną po ocenach malejąco");
            GetListaByGradeDesc(students);
            Console.WriteLine();
            Console.WriteLine("Bez ocen posortowaną alfabetycznie");
            GetListaByNameNoGrade(students);*/


            //ZAD 2 KSIAZKA ADRESOWA

            Dictionary<User, int> book = new Dictionary<User, int>();
            //                            KEY                      Value
            book.Add(new User { Name = "A", PhoneNumber = "111" }, 1);
            book.Add(new User { Name = "B", PhoneNumber = "222" }, 2);
            book.Add(new User { Name = "C", PhoneNumber = "333" }, 3);
            book.Add(new User { Name = "D", PhoneNumber = "444" }, 4);
            book.Add(new User { Name = "E", PhoneNumber = "555" }, 5);
            book.Add(new User { Name = "A", PhoneNumber = "112" }, 6);
            book.Add(new User { Name = "A", PhoneNumber = "113" }, 7);
            book.Add(new User { Name = "E", PhoneNumber = "556" }, 8);

            Console.WriteLine("Podaj nazwę użytkownika, którego telefon chcesz odszukać");
            string name = Console.ReadLine();
            GetUsersPhoneNumber(book, name);
        }

    }
    class User
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    class KsiazkaAdresowa
    {   
        public static void GetUsersPhoneNumber(Dictionary<User,int> book, string name)
        {
            List<string> numery = new List<string>();
            foreach (var item in book)
            {
                if (item.Key.Name == name)
                {
                    numery.Add(item.Key.PhoneNumber);
                    
                }
            }
            Console.WriteLine($"Numer/y użytkownika {name}");
            foreach (var item in numery)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Grade { get; set; }

    }

    class StudentGroup
    {

        public static void GetLista(List<Student> students)
        {
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Name} {item.Surname} {item.Grade}");
            }
        }

        public static void GetListaByName(List<Student> students)
        {
            List<Student> SortedStudentByName = students.OrderBy(x => x.Name).ToList();

            foreach (var item in SortedStudentByName)
            {
                Console.WriteLine($"{item.Name} {item.Surname} {item.Grade}");
            }
        }

        public static void GetListaByGradeDesc(List<Student> students)
        {
            List<Student> SortedStudentByGradeDesc = students.OrderByDescending(x => x.Grade).ToList();

            foreach (var item in SortedStudentByGradeDesc)
            {
                Console.WriteLine($"{item.Name} {item.Surname} {item.Grade}");
            }
        }


        public static void GetListaByNameNoGrade(List<Student> students)
        {
            List<Student> vs = new List<Student>();

            foreach (var item in students)
            {
                vs.Add(new Student() { Name=item.Name, Surname=item.Surname });
            }

            vs = vs.OrderBy(x => x.Name).ToList();
            foreach (var item in vs)
            {
                Console.WriteLine($"{item.Name} {item.Surname}");
            }
        }

        public static bool CzyPelna(List<Student> students)
        {
            if (students.Count > 10)
            {
                return true;

            }
            else
            {
                return false;
            }

        }


    }

   
}
