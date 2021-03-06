using System;
using System.Collections.Generic;
using System.Linq;

// given a string that contains only a and b 
// in how many ways can you split the string to contain 3 parts with the same number of "a" in every substring 
namespace ConsoleApp3
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(test("bbbbb"));
        //}

        static int test(string S)
        {
            var nrOfA = S.Count(r => r == 'a');
            if(nrOfA % 3 != 0)
            {
                return 0;
            }
            var primul = "";
            var second = "";
            var third = "";
            int max = 0;
            
            // split the initial string in 3 strings with the same number of a
            // Improvement use a string builder
            for(int i = 0; i < S.Length; i++)
            {
                // finished in a
                if(primul.Count(a=>a == 'a') != nrOfA / 3)
                {
                    primul += S[i];
                    continue;
                }
                // finished in a
                if (second.Count(a => a == 'a') != nrOfA / 3)
                {
                    second += S[i];
                    continue;
                }
                // cannnot be split more than that
                if (third.Count(a => a == 'a') != nrOfA / 3)
                {
                    third += S[i];
                    continue;
                }
            }


            // if the number of a is 0 then we have combinations of strings length - 1 taken in groups of 2, 
            // the formula is  nCr = n! / r! * (n - r)!
            // improvement move it at the beginning
            if (nrOfA == 0)
            {
                return nCr(S.Length-1, 2);
            }


            int x = 1;
            for(int i = 0; i < second.Length; i++)
            {
                if(second[i] != 'a')
                {
                    x++;
                }
                else
                {
                    break;
                }
            }

            int y = 1;
            for (int i = 0; i < third.Length; i++)
            {
                if (third[i] != 'a')
                {
                    y++;
                }
                else
                {
                    break;
                }
            }

            return x*y;
        }

        public static int nCr(int n, int r)
        {
            // naive: return Factorial(n) / (Factorial(r) * Factorial(n - r));
            return nPr(n, r) / Factorial(r);
        }

        public static int nPr(int n, int r)
        {
            // naive: return Factorial(n) / Factorial(n - r);
            return FactorialDivision(n, n - r);
        }

        private static int FactorialDivision(int topFactorial, int divisorFactorial)
        {
            int result = 1;
            for (int i = topFactorial; i > divisorFactorial; i--)
                result *= i;
            return result;
        }

        private static int Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }

    }
}
