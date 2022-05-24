using System;
using System.Collections.Generic;
using System.Linq;

namespace lab8___27._04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int funF(int n)
            {
                n = 3;
                if (n<2)
                {
                    return n;
                }
                else
                {
                    return n - funG(n);
                }
            }

            int funG(int n)
            {
               
                if (n < 2)
                {
                    return n;
                }
                else
                {
                    return n - funF(n-1);
                }
            }
        }

    }
}
