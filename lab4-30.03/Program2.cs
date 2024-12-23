﻿using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;

class App : Exercise4
{
    public static void Main(string[] args)
    {
        /* Console.WriteLine("Cwiczenie 1");
         (int, int) point1 = (0, 0);
         (int, int) scren = (4, 4);
         Direction4 dir = Direction4.UP;
         var point2 = NextPoint(dir, point1,scren);
         Console.WriteLine(point2);
         Console.WriteLine();

         Console.WriteLine("Cwiczenie 3");*/

        /* Car[] _cars = new Car[]
         {
             new Car(),
             new Car(Model: "Fiat", true),
             new Car(),
             new Car(Power: 100),
             new Car(Model: "Fiat", true),
             new Car(Power: 125),
             new Car()
         };
        Console.WriteLine(CarCounter(_cars)); */


        /*Student[] students = {
          new Student("Kowal","Adam", 'A'),
          new Student("Nowak","Ewa", 'A'),
          new Student("Nowak","Ewa", 'A'),
          new Student("Nowak","Ewa", 'A'),
          new Student("Nowak","Ewa", 'A'),
          new Student("Nowak","Ewa", 'A'),
          new Student("Nowak","Ewa", 'A'),
          new Student("Nowak","Ewa", 'A'),
          new Student("Nowak","Ewa", 'A'),
          new Student("Nowak","Ewa", 'A'),
            new Student("Nowak","Ewa", 'A')
        };
         AssignStudentId(students);*/


    }
}

enum Direction8
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    UP_LEFT,
    DOWN_LEFT,
    UP_RIGHT,
    DOWN_RIGHT
}

enum Direction4
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

//Cwiczenie 1
//Zdefiniuj metodę NextPoint, która powinna zwracać krotkę ze współrzędnymi piksela przesuniętego jednostkowo w danym kierunku względem piksela point.
//Krotka screenSize zawiera rozmiary ekranu (width, height)
//Przyjmij, że początek układu współrzednych (0,0) jest w lewym górnym rogu ekranu, a prawy dolny ma współrzęne (witdh, height) 
//Pzzykład
//dla danych wejściowych 
//(int, int) point1 = (2, 4);
//Direction dir = Direction.UP;
//var point2 = NextPoint(dir, point1);
//w point2 powinny być wartości (2, 3);
//Jeśli nowe położenie jest poza ekranem to metoda powinna zwrócić krotkę z point
class Exercise1
{
    public static (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
    {

        var tuple = point;
        int a = tuple.Item1;
        int b = tuple.Item2;
        if (direction == Direction4.UP && b == 0)
        {
            return tuple;

        }
        else if (direction == Direction4.LEFT && a == 0)
        {
            return tuple;
        }
        else
        {
            return direction switch
            {

                Direction4.UP => point = (a, b - 1),
                Direction4.DOWN => point = (a, b + 1),
                Direction4.LEFT => point = (a - 1, b),
                Direction4.RIGHT => point = (a + 1, b)

            };
        }
        //point(2,4)





    }
}
//Cwiczenie 2
//Zdefiniuj metodę DirectionTo, która zwraca kierunek do piksela o wartości value z punktu point. W tablicy screen są wartości
//pikseli. Początek układu współrzędnych (0,0) to lewy górny róg, więc punkt o współrzęnych (1,1) jest powyżej punktu (1,2) 
//Przykład
// Dla danych weejsciowych
// static int[,] screen =
// {
//    {1, 0, 0},
//    {0, 0, 0},
//    {0, 0, 0}
// };
// (int, int) point = (1, 1);
// po wywołaniu - Direction8 direction = DirectionTo(screen, point, 1);
// w direction powinna znaleźć się stała UP_LEFT
class Exercise2
{
    static int[,] screen =
    {
        {1, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };

    private static (int, int) point = (1, 1);

    private Direction8 direction = DirectionTo(screen, point, 1);

    public static Direction8 DirectionTo(int[,] screen, (int, int) point, int value)
    {
        throw new NotImplementedException();
    }
}

//Cwiczenie 3
//Zdefiniuj metodę obliczającą liczbę najczęściej występujących aut w tablicy cars
//Przykład
//dla danych wejściowych
// Car[] _cars = new Car[]
// {
//     new Car(),
//     new Car(Model: "Fiat", true),
//     new Car(),
//     new Car(Power: 100),
//     new Car(Model: "Fiat", true),
//     new Car(Power: 125),
//     new Car()
// };
//wywołanie CarCounter(Car[] cars) powinno zwrócić 3
record Car(string Model = "Audi", bool HasPlateNumber = false, int Power = 100);

class Exercise3
{
    public static int CarCounter(Car[] cars)
    {
        int count = 0;
        string[] array = new string[cars.Length];


        var dic = new Dictionary<object, int>();
        foreach (var item in cars)
        {
            if (dic.ContainsKey(item))
            {
                dic[item]++;

            }
            else
            {
                dic[item] = 1;
            }
        }

        return dic.Values.Max();
    }
}

record Student(string LastName, string FirstName, char Group, string StudentId = "");
//Cwiczenie 4
//Zdefiniuj metodę AssignStudentId, która każdemu studentowi nadaje pole StudentId wg wzoru znak_grupy-trzycyfrowy-numer.
//Przykład
//dla danych wejściowych
//Student[] students = {
//  new Student("Kowal","Adam", 'A'),
//  new Student("Nowak","Ewa", 'A')
//};
//po wywołaniu metody AssignStudentId(students);
//w tablicy students otrzymamy:
// Kowal Adam 'A' - 'A001'
// Nowal Ewa 'A'  - 'A002'
//Należy przyjąc, że są tylko trzy możliwe grupy: A, B i C
class Exercise4
{
    public static void AssignStudentId(Student[] students)
    {
        int count = 0;
        int countB = 0;
        int countC = 0;


        foreach (var item in students)
        {
           string grupa = item.Group.ToString();
            if (grupa == "A")
            {
                count++;
                
                if (count<=9)
                {
                    Console.WriteLine($"{item.LastName} {item.FirstName} '{item.Group}' - '{item.Group}00{count}'");
                }else if(count>=10&&count<=99)
                {
                    Console.WriteLine($"{item.LastName} {item.FirstName} '{item.Group}' - '{item.Group}0{count}'");
                }
                else
                {
                    Console.WriteLine($"{item.LastName} {item.FirstName} '{item.Group}' - '{item.Group}{count}'");
                }
            }
            else if (grupa == "B")
            {
                countB++;

                if (countB <= 9)
                {
                    Console.WriteLine($"{item.LastName} {item.FirstName} '{item.Group}' - '{item.Group}00{countB}'");
                }
                else if (countB >= 10 && countB <= 99)
                {
                    Console.WriteLine($"{item.LastName} {item.FirstName} '{item.Group}' - '{item.Group}0{countB}'");
                }
                else
                {
                    Console.WriteLine($"{item.LastName} {item.FirstName} '{item.Group}' - '{item.Group}{countB}'");
                }
            }
            else
            {
                countC++;

                if (countC <= 9)
                {
                    Console.WriteLine($"{item.LastName} {item.FirstName} '{item.Group}' - '{item.Group}00{countC}'");
                }
                else if (countC >= 10 && countC <= 99)
                {
                    Console.WriteLine($"{item.LastName} {item.FirstName} '{item.Group}' - '{item.Group}0{countC}'");
                }
                else
                {
                    Console.WriteLine($"{item.LastName} {item.FirstName} '{item.Group}' - '{item.Group}{countC}'");
                }
            }
        }
    }
}