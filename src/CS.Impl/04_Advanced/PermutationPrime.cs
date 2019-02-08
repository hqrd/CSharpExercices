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
                List<string> permutations = WordPermutation("", number.ToString());
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


        List<string> WordPermutation(string prefix, string word)
        {
            List<string> perms = new List<string>();
            int n = word.Length;
            if (n == 0)
            {
                perms.Add(prefix);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    perms.AddRange(WordPermutation(prefix + word[i], word.Substring(0, i) + word.Substring(i + 1, n - (i + 1))));
                }
            }
            return perms;
        }

    }
}
