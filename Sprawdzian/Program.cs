using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Length a = new Length() {Unit = LengthUnit.Millimeter, Value = 1000.0m};
        Length b = new Length() {Unit = LengthUnit.Meter, Value = 1.0m};
        Length c = new Length() {Unit = LengthUnit.Kilometer, Value = 0.001m};
        decimal factor = 2.0m;
        decimal points = 0;
        if ((a * factor).Value == 2000m && (b * factor).Unit == LengthUnit.Meter && (b * factor).Value == 2 && 
            (new Length() {Unit = LengthUnit.Millimeter, Value = 6} * 1m).Value == 6)
        {
            Console.WriteLine($"Zadanie 1-1: 0.5 punkt");
            points += 0.5m;
        }
        else
        {
            Console.WriteLine($"Zadanie 1-1: 0 punktów");
        }
        try
        {
            Length length = a * -6;
            Console.WriteLine("Zadanie 1-2: 0 punktów");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Zadanie 1-2: 0.5 punkt");
            points += 0.5m;
        }

        Length d = new Length() {Unit = LengthUnit.Meter, Value = 2.0m};
        if (a < d && c < d && b < d)
        {
            Console.WriteLine(("Zadanie 2: 1 punkt"));
            points++;
        }
        else
        {
            Console.WriteLine(("Zadanie 2: 0 punkt"));
        }

        if (a.Equals(b) && b.Equals(c) && c.Equals(a) && !d.Equals(a))
        {
            Console.WriteLine(("Zadanie 3: 1 punkt"));
            points++;
        }
        else
        {
            Console.WriteLine(("Zadanie 3: 0 punkt"));
        }

        List<Length> list = new List<Length>()
        {
            c, a, b, d,
            new Length() {Unit = LengthUnit.Millimeter, Value = 10.0m},
            new Length() {Unit = LengthUnit.Kilometer, Value = 2.0m}
        };
        Task4(list);
        if (list[0].Unit == LengthUnit.Millimeter && list[0].Value == 10 && list[1].Unit == LengthUnit.Millimeter && list[1].Value == 1000 &&
            list[5].Unit == LengthUnit.Kilometer && list[5].Value == 2)
        {
            Console.WriteLine(("Zadanie 4: 1 punkt"));
            points++;
        }
        else
        {
            Console.WriteLine(("Zadanie 4: 0 punkt"));
        }

        List<Student> students = new List<Student>()
        {
            new Student() {StudyYear = 1, Height = new Length() {Unit = LengthUnit.Millimeter, Value = 1600.0m}},
            new Student() {StudyYear = 1, Height = new Length() {Unit = LengthUnit.Millimeter, Value = 1700.0m}},
            new Student() {StudyYear = 3, Height = new Length() {Unit = LengthUnit.Meter, Value = 1.76m}},
            new Student() {StudyYear = 1, Height = new Length() {Unit = LengthUnit.Millimeter, Value = 1670.0m}},
            new Student() {StudyYear = 2, Height = new Length() {Unit = LengthUnit.Kilometer, Value = 0.00197m}},
            new Student() {StudyYear = 1, Height = new Length() {Unit = LengthUnit.Meter, Value = 1.770m}},
            new Student() {StudyYear = 2, Height = new Length() {Unit = LengthUnit.Millimeter, Value = 1820.0m}}
        };
        List<Student> st = new List<Student>()
        {
            new Student() {StudyYear = 1, Height = new Length() {Unit = LengthUnit.Millimeter, Value = 1600.0m}},
            new Student() {StudyYear = 1, Height = new Length() {Unit = LengthUnit.Meter, Value = 1.6000m}},
            new Student() {StudyYear = 1, Height = new Length() {Unit = LengthUnit.Kilometer, Value = 0.0016m}},
            new Student() {StudyYear = 2, Height = new Length() {Unit = LengthUnit.Millimeter, Value = 1670.0m}},
            new Student() {StudyYear = 2, Height = new Length() {Unit = LengthUnit.Kilometer, Value = 0.00197m}},
            new Student() {StudyYear = 3, Height = new Length() {Unit = LengthUnit.Meter, Value = 1.770m}},
            new Student() {StudyYear = 2, Height = new Length() {Unit = LengthUnit.Millimeter, Value = 1820.0m}}
        };
       /* if (Task5(students).Unit == LengthUnit.Meter && Task5(students).Value == 1.685m && Task5(st).Unit == LengthUnit.Meter && Task5(st).Value == 1.6m)
        {
            Console.WriteLine(("Zadanie 5: 1 punkt"));
            points++;
        }
        else
        {
            Console.WriteLine(("Zadanie 5: 0 punkt"));
        }*/

        Console.WriteLine($"Suma punktów: {points}/5");
    }

    internal enum LengthUnit
    {
        Millimeter = 1,
        Meter = 1000,
        Kilometer = 1000_000
    }

    internal class Length
    {
        public LengthUnit Unit { get; set; }
        public decimal Value { get; set; }

        //Zadanie 1
        //zdefiniuj operator mnożenia długości przez liczbę decimal, aly tylko dodatnią. Dla liczby ujemnej zgłoś wyjątek ArgumentException()
        //Przykład
        //Lenght result = new Lenght(){Unit = LenghtUnit.Meter, Value = 2} * 2d;
        //Console.WriteLine(result.Value);        // 4

        /* public static Length Of(decimal x)
         {
             if (x<0)
             {
                 throw new ArgumentException();
             }
             else
             {
                 return new Length(x);
             }
         }*/
        public static Length operator *(Length ln, decimal dm)
        {
            if (dm < 0) throw new ArgumentException();
            var newLn = new Length()
            {
                Unit = ln.Unit,
                Value = ln.Value * dm,
            };
            return newLn;
        }

        public static Length operator *(decimal dm, Length ln)
        {
            if (dm < 0) throw new ArgumentException();
            var newLn = new Length()
            {
                Unit = ln.Unit,
                Value = dm * ln.Value,
            };
            return newLn;
        }

        //Zadanie 2
        //Zdefiniuj relacji < i > dla klasy Lenght. Liczba większa to taka, która ma większość wartość po przeliczeniu na milimetry.
        //Przykłady
        //bool IsLower = new Lenght(){Unit = LenghtUnit.Meter, Value = 2} < new Lenght(){Unit = LenghtUnit.Millmetre, Value = 4_000}; //true
        //bool IsGreater = new Lenght(){Unit = LenghtUnit.Meter, Value = 2} > new Lenght(){Unit = LenghtUnit.Millmeter, Value = 400}; //true

        public static bool operator <(Length ln1, Length ln2)
        {
            ToMilimeters(ln1, ln2, out var value1, out var value2);

            if (value1 < value2)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool operator >(Length ln1, Length ln2)
        {
            ToMilimeters(ln1, ln2, out var value1, out var value2);

            if (value1 > value2)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        private static void ToMilimeters(Length ln1, Length ln2, out decimal value1, out decimal value2)
        {
            value1 = default(decimal);
            value2 = default(decimal);
            if (ln1.Unit != LengthUnit.Millimeter)
            {
                switch (ln1.Unit)
                {
                    case LengthUnit.Meter:
                        value1 = ln1.Value * (decimal)LengthUnit.Meter;
                        break;
                    case LengthUnit.Kilometer:
                        value1 = ln1.Value * (decimal)LengthUnit.Kilometer;
                        break;
                }
            }
            else value1 = ln1.Value;
            if (ln2.Unit != LengthUnit.Millimeter)
            {
                switch (ln2.Unit)
                {
                    case LengthUnit.Meter:
                        value2 = ln2.Value * (decimal)LengthUnit.Meter;
                        break;
                    case LengthUnit.Kilometer:
                        value2 = ln2.Value * (decimal)LengthUnit.Kilometer;
                        break;
                }
            }
            else value2 = ln2.Value;
        }

        //Zadanie 3
        //Zdefiniuj metodę ToString(), GetHashCode i Equals. Dwie długości są sobie równe jeśli  po przeliczeniu na milimetry są identyczne
        //Przykład
        //Console.Write(new Lenght(){Unit = LenghtUnit.Meter, Value = 2}); //{Unit = LenghtUnit.Meter, Value = 2}
        //new Lenght(){Unit = LenghtUnit.Meter, Value = 200}.Equals(new Lenght(){Unit = LenghtUnit.Kilometer, Value = 0.2});  //true

        public override string ToString()
        {
           return $"{{Unit = {LengthUnit.Meter}, Value = {Value}}}";
        }
        public override int GetHashCode()
        {
            return Unit.GetHashCode() ^ Value.GetHashCode();
        }

        public bool Equals(Length ln)
        {
            if (ReferenceEquals(null,ln))
            {
                return false;
            }
            else if(ReferenceEquals(this,ln))
            {
                return true;
            }
            else
            {
                return Value.Equals(ln.Value) && Unit.Equals(ln.Unit);
            }
        }
    }

    //Zadanie 4
    //Zaimplementuj metodę, aby sortowała listę długości w porządku rosnącym, a dla identycznych długości (czyli takich, które po przeliczeniu na milimetry są identyczne)
    //wg rosnacych jednostek w typie enum 
    static void Task4(List<Length> list)
    {
        list.Sort((x,y) => x.Value.CompareTo(y.Value));
    }

    internal class Student
    {
        public Length Height { set; get; }
        public int StudyYear { set; get; }
    }

    //Zadanie 5
    //Zaimplementuj metodę za pomoca LINQ, aby wyznaczyła średnią wzrostu studentów pierwszego roku w postaci obiektu klasy
    //Lenght z jednostką wysokość Meter. Studenci mogą mieć zapisaną wzrost w różnych jednostkach.
    /*static Length Task5(IEnumerable<Student> list)
    {
        IEnumerable<Length> enumerable = list.Select(x => x.Height);
        decimal res;
        return enu
    }*/
}