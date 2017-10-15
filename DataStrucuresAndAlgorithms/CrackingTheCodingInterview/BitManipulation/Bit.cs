using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrucuresAndAlgorithms.CrackingTheCodingInterview.BitManipulation
{
    public static class Bit
    {
        public static int singleNumber(List<int> A)
        {
            int Xor = A[0];
            for (int i = 1; i < A.Count; i++)
            {
                Xor ^= A[i];
            }
            return Xor;

        }

        public static int? findMinXor(List<int> A)
        {
            int minXOR = int.MaxValue;
            A.Sort();
            for (int i = 1; i < A.Count; i++)
            {
                minXOR = Math.Min(minXOR, A[i - 1] ^ A[i]);
            }
            return minXOR;

        }
    }
}
