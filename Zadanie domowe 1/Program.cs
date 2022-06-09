using System;

namespace Zadanie_domowe_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Aggregate aggregate = new ArrayIntAggregate();
            for (var iterator = aggregate.CreateIterator(); iterator.HasNext();)
            {
             
                Console.WriteLine(iterator.GetNext());
                
            }
        }
    }
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    public abstract class Iterator
    {
        public abstract double GetNext();
        public abstract bool HasNext();
      

    }

    public class ArrayIntAggregate : Aggregate
    {
       // internal int[] array = { 1, 2, 3, 4, 5 };

        internal double[,] array = new double[2, 3] { { 1, 2, 3 }, 
                                                      { 4, 5, 6 } 
        };

        public override Iterator CreateIterator()
        {
            return new ArrayIntIterator(this);


        }
    }
    public sealed class ArrayIntIterator : Iterator
    {
        private int _index = 0;
        private int _index2 = 0;
        private ArrayIntAggregate _aggregate;
        public ArrayIntIterator(ArrayIntAggregate aggregate)
        {
            _aggregate = aggregate;

            _index = _aggregate.array.GetLength(0) - 1;
            _index2 = _aggregate.array.GetLength(1) - 1;

        }
        

        public override double GetNext()
        {
            return _aggregate.array[_index, _index2--];
        }

     
        public override bool HasNext()
        {

            int b = _aggregate.array.GetLength(1);
            if (_index2<b && _index2>=0)
            {
                return true;
            }
            else if (_index2==-1)
            {
                if (_index< _aggregate.array.GetLength(0) && _index>0)
                {
                    _index--;
                    _index2 = _aggregate.array.GetLength(1) - 1;
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                
                return false;
            }
        }



    }
}
