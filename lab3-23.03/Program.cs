using System;

namespace lab3_23._03
{
    internal class Program
    {
        class Stack<T> 
        {
            private T[] _arr = new T[10];
            private int last = -1;
            public void Push(T item)
            {
                _arr[++last] = item;
            }
        }

        class Person
        {

        }

        static void Main(string[] args)
        {
           Stack<int> stack = new Stack<int>();
            stack.Push(10);
            Stack<string> stack2 = new Stack<string>();
            stack2.Push("aaa");

            ValueTuple<string, decimal, int> product = ValueTuple.Create("laptop", 1200m, 2);
            (string, decimal, int) tuple = product;
            tuple = ("telefon", 1500m, 4);
            Console.WriteLine(product);
            Console.WriteLine(product.Item1);
            Console.WriteLine(tuple);

            var tuple1 = (name: "Mac", price: 1200m, quantity : 2);
            Console.WriteLine(tuple1);


            Console.WriteLine(tuple1==product);
           /* Stack<object> stack3 = new Stack<object>();
            stack3.Push(1);
            stack3.Push("aaa");*/
        }
    }
}
