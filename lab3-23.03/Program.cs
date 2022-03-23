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
           /* Stack<object> stack3 = new Stack<object>();
            stack3.Push(1);
            stack3.Push("aaa");*/
        }
    }
}
