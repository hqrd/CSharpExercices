using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CS.Impl._02_Intermediate
{
    public class Recursion
    {

        public IEnumerable<int> GetNaturalNumbers(int n)
        {
            List<int> res = new List<int>();
            if (n == 0)
            {
                return res;
            }
            else
            {
                res.Add(n);
                return GetNaturalNumbers(n - 1).Concat(res);
            }
        }

        private IEnumerable<int> GetNaturalNumbers(List<int> naturalNumbers, int current, int max)
        {
            throw new NotImplementedException();
        }

        public int SumNaturalNumbers(int n)
        {
            if (n == 1)
                return 1;
            else
                return n + SumNaturalNumbers(n - 1);
        }

        private int ComputeSum(int min, int current)
        {
            throw new NotImplementedException();
        }

        public bool IsPrime(int n)
        {
            return IsPrime(n, n / 2);
        }

        private bool IsPrime(int n, int current)
        {
            if (current == 0) return false;
            if (current == 1)
            {
                return true;
            }
            else
            {
                if (n % current == 0)
                    return false;
                else
                    return IsPrime(n, current - 1);
            }
        }

        public bool IsPalindrome(string text)
        {
            if (text.Length <= 1)
            {
                return true;
            }
            else
            {
                if (text[0] != text[text.Length - 1])
                    return false;
                else
                    return IsPalindrome(text.Substring(1, text.Length - 2));
            }
        }

        //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        public int GetSmallestDivisableByAllWithoutRemainder(int number)
        {
            var current = number * 2;
            while (true)
            {
                if (IsDivisableByAllNumbersWithoutRemainder(current, 1, number - 1))
                {
                    return current;
                }
                current += number;
            }
            //return GetSmallestDivisableByAllWithoutRemainderRecursive(number, number * 2);
        }

        public int GetSmallestDivisableByAllWithoutRemainderRecursive(int number, int current)
        {
            if (IsDivisableByAllNumbersWithoutRemainder(current, 1, number))
            {
                return current;
            }
            else
            {
                return GetSmallestDivisableByAllWithoutRemainderRecursive(number, current + number);
            }
        }

        public bool IsDivisableByAllNumbersWithoutRemainder(int number, int from, int to)
        {
            for (int i = to; i >= from; i--)
            {
                if (number % i != 0) return false;
            }
            return true;
        }
    }
}
