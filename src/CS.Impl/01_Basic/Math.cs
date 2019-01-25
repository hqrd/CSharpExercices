using System;
using System.Collections.Generic;
using System.Linq;

namespace CS.Impl._01_Basic
{
    public class Math
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }

        public int SumTable(IEnumerable<int> integersTable)
        {
            return integersTable.Sum(x => x);
        }
    }
}