using CS.Impl._02_Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.Impl._04_Advanced
{
    public class PermutationPrime
    {
        public int[] GetPermutationPrimes(int upperBound)
        {
            int[] res = new int[] { };
            Recursion recursion = new Recursion();

            foreach (var number in Enumerable.Range(1, upperBound))
            {
                char[] _chars = number.ToString().ToCharArray();
                IEnumerable<IEnumerable<char>> permutations = GetPermutations(_chars, _chars.Length);
                permutations = permutations.Append(_chars);
                var allPrime = true;
                foreach (var value in permutations)
                {
                    int intValue = int.Parse(string.Join("", value));
                    if (!recursion.IsPrime(intValue))
                    {
                        allPrime = false;
                    }
                }
                if (allPrime)
                    res = res.Append(number).ToArray();
            }
            return res;
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }


    }
}
