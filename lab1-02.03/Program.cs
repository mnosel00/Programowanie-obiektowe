using System;

namespace lab1_02._03
{
    class Program
    {
        static void Main(string[] args)
        {
            CarProperties carProperties = CarProperties.of("BMWE");



            Console.WriteLine(carProperties.BrandName);
        }
    }

    

    public class CarProperties
    {
        

        private string _brandName2;

        private CarProperties(string firstName)
        {
            _brandName2 = firstName;
        }

        public static CarProperties of(string firstName)
        {
            if (firstName.Length <=2)
            {
                return new CarProperties(firstName);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Nazwa jest za krotka");
            }
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

    public class Money
    {
        private readonly decimal _value;
        private readonly Currency _currency;

        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency; 
        }
        public static Money Of(decimal value, Currency currency)
        {
                return value < 0 ? null : new Money(value, currency);

        }

        public static Money? OfWhiteException(decimal value, Currency currency)
        {
            if (value < 0 )
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return  new Money(value, currency); 
            }
        }

        public static Money operator*(Money money, decimal value)
        {
            return Money.Of(money._value * value, money._currency);
        }
        public static Money operator *(decimal value, Money money)
        {
            return Money.Of(money._value * value, money._currency);
        }
    }

    
}
