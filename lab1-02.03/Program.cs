using System;

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



    public class Money
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

        public static Money operator*(Money money, decimal value)
        {
            return Money.Of(money.Value * value, money.Currency);
        }
        public static Money operator *(decimal value, Money money)
        {
            return Money.Of(money._value * value, money._currency);
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
                return Money.Of(parsedValue,currency);
            }
            else
            {
                throw new ArgumentException("wrong argumnet");
            }
            
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

            Console.WriteLine(carProperties.BrandName);
        }
    }


}
