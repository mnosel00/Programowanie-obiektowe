using System;
using System.Linq;

namespace lab1_02._03
{

    public class CarProperties
    {


        private string _brandName2;

        private CarProperties(string firstName)
        {
            _brandName2 = firstName;
        }

        public static CarProperties of(string firstName)
        {

            return new CarProperties(firstName);


        }

        public string BrandName
        {
            get
            {
                return _brandName2;
            }
            set
            {
                if (value.Length >= 3)
                {
                    _brandName2 = value;
                }
            }
        }
    }


    public enum Currency
    {
        PLN = 1,
        USD = 2,
        Euro = 3,
    }



    public class Money : IEquatable<Money>
    {
        private readonly decimal _value;
        private readonly Currency _currency;

        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }
        public decimal Value
        {
            get { return _value; }
        }
        public Currency Currency
        {
            get { return _currency; }
        }

        public static Money Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);

        }

        public static Money operator *(Money money, decimal value)
        {
            return Money.Of(money.Value * value, money.Currency);
        }
        public static Money operator *(decimal value, Money money)
        {
            return Money.Of(money.Value * value, money.Currency);
        }

        public static Money operator +(Money moneya, Money moneyb)
        {
            if (moneya.Currency != moneyb.Currency)
            {
                throw new ArgumentException("Nie można dodwać róznych wartości");
            }
            else
            {
                return Money.Of(moneya.Value + moneyb.Value, moneya.Currency);
            }

        }

        public static Money? OfWhiteException(decimal value, Currency currency)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return new Money(value, currency);
            }
        }
        public static Money? ParseValue(string valueStr, Currency currency)
        {
            decimal parsedValue;
            bool done = decimal.TryParse(valueStr, out parsedValue);
            if (done)
            {
                //return new Money(parsedValue, currency);
                return Money.Of(parsedValue, currency);
            }
            else
            {
                throw new ArgumentException("wrong argumnet");
            }

        }
        public static bool operator >(Money moneya, Money moneyb)
        {
            if (moneya.Currency != moneyb.Currency)
            {
                throw new ArgumentException("różne waluty");
            }
            else
            {
                return moneya.Value > moneyb.Value;
            }

        }
        public static bool operator <(Money moneya, Money moneyb)
        {
            if (moneya.Currency != moneyb.Currency)
            {
                throw new ArgumentException("różne waluty");
            }
            else
            {
                return moneya.Value < moneyb.Value;
            }
        }

        public static explicit operator float(Money money)
        {
            return (float)money.Value;
        }

        public class Tank
        {
            public readonly int Capacity;
            private int _level;
            public Tank(int capacity)
            {
                Capacity = capacity;
            }
            public int Level
            {
                get
                {
                    return _level;
                }
                private set
                {
                    if (value < 0 || value > Capacity)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    _level = value;
                }
            }
            public bool refuel(int amount)
            {
                if (amount < 0)
                {
                    return false;
                }
                if (_level + amount > Capacity)
                {
                    return false;
                }
                _level += amount;
                return true;
            }

            public bool consume(int amount)
            {
                if (amount < 0)
                {
                    return false;
                }
                if (amount > _level)
                {
                    return false;
                }
                _level = _level - amount;
                return true;
            }
            public bool refuel(Tank sourceTank, int amount)
            {
                if (_level + amount > Capacity)
                {
                    return false;
                }
                if (sourceTank.consume(amount))
                {
                    this.refuel(amount);
                    return true;
                }
                return false;
            }
        }
        public override string ToString()
        {
            return $"{_value} {_currency}";
        }

        public bool Equals(Money other)
        {
            throw new NotImplementedException();
        }
    }

    class Student : IComparable<Student>
    {


        public string Name { get; set; }
        public string Surname { get; set; }
        public double Srednia { get; set; }
        public int CompareTo(Student other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var studentsCompare = Name.CompareTo(other.Name);
            if (studentsCompare != 0) return studentsCompare;
            return Name.CompareTo(other.Srednia);
        }
    }
    static class StringExt
    {
        public static String Double(this String instance)
        {
            return instance + instance;
        }
    }

  public static class MoneyExtension
    {
        public static Money ToCurency(this Money money,Currency currency,decimal kurs)
        {
            if (currency==money.Currency)
            {
                new ArgumentException("Nie można konwertowac tej samej waluty");

            }

            return Money.Of(money.Value * kurs,money.Currency);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CarProperties carProperties = CarProperties.of("BMWEE");


            Money money = Money.ParseValue("13,45", Currency.PLN);
            Money money1 = Money.Of(100m, Currency.PLN);
            var res = money1 * 0.25m;
            Console.WriteLine(res.Value.ToString(), money1.Currency);
            Money money2 = Money.Of(45.67m, Currency.USD);
            Console.WriteLine($"{money2}");

            Console.WriteLine(carProperties.BrandName);


            Student[] students =
            {

                new Student(){Name="Mateusz",Surname="Nosel", Srednia=5.0},
                 new Student(){Name="Kacper",Surname="Puzio", Srednia=4.0},
                  new Student(){Name="Maciek",Surname="Misiak", Srednia=3.2},
                  new Student(){Name="Jurand",Surname="Juri", Srednia=5.0},



            };
            Array.Sort(students);
            Console.WriteLine();
            Console.WriteLine("Sortowanie po Name: ");
            Console.WriteLine();
            foreach (var item in students)
            {
                Console.WriteLine(item.Name + " " + item.Surname + " " + item.Srednia);
            }
            Console.WriteLine();
            Console.WriteLine("abcd".Double());
            Console.WriteLine();

            money = Money.Of(100, Currency.PLN);
            var res2 = money.ToCurency(Currency.USD, 4.1m);
            Console.WriteLine(res2);


            money = Money.Of(50, Currency.PLN);
            var res3 = money.ToCurency(Currency.PLN, 4.1m);
            Console.WriteLine(res3);
        }
    }


}
