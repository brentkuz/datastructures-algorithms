using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrucuresAndAlgorithms.CrackingTheCodingInterview.ArraysAndStrings
{
    public static class AS
    {
        public static int KthSmallest(int[] a, int k)
        {
            if (a == null || k < 0 || k > a.Length)
                return -1;

            return FindKthSmallest(a, 0, a.Length - 1, k);

        }
        private static int FindKthSmallest(int[] a, int lo, int hi, int k)
        {
            if (hi < lo)
                return -1;
            int p = Partition(a, lo, hi);
            if (k == p) return a[p];
            else
            {
                if (k < p)
                    return FindKthSmallest(a, lo, p - 1, k);
                else
                    return FindKthSmallest(a, p + 1, hi, k);
            }
        }
        private static int Partition(int[] a, int lo, int hi)
        {
            int i = lo,
                j = hi + 1,
                v = a[lo];
            while (true)
            {
                while (a[++i] < v)
                    if (i == hi) break;
                while (a[--j] > v)
                    if (j == lo) break;
                if (i >= j) break;
                Exch(a, i, j);
            }
            Exch(a, lo, j);

            return j;
        }
        private static void Exch(int[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        //swap numbers in place
        public static void Swap(int i1, int i2)
        {
            i1 = i1 + i2;
            i2 = i1 - i2;
            i1 = i1 - i2;
        }

        //determine if all characters in a string are unique
        public static bool IsUnique(string s)
        {
            if (s.Length > 128)
                return false;
            bool[] marked = new bool[128];
            for (var i = 0; i < s.Length; i++)
            {
                int val = s[i];
                if (marked[val])
                    return false;
                marked[val] = true;
            }
            return true;
        }

        //check if one word is a permutation of the other
        public static bool IsPermutation(string w1, string w2)
        {
            var a1 = w1.ToArray();
            Array.Sort(a1);
            var a2 = w2.ToArray();
            Array.Sort(a2);
            if (a1.SequenceEqual(a2))
                return true;
            return false;

        }

        //replace all spaces with '%20'
        public static void MakeValidUrl(char[] s, int length)
        {
            if (!s.Contains(' '))
                return;
            int spaces = 0;
            foreach (var c in s)
            {
                if (c == ' ')
                    spaces++;
            }
            int trueLength = length + (spaces * 2);
            var index = length - 1;
            for (var i = trueLength - 1; i >= 0; i--)
            {
                if (s[index] == ' ')
                {
                    s[i] = '0';
                    s[--i] = '2';
                    s[--i] = '%';
                }
                else
                    s[i] = s[index];
                index--;
            }
        }

        //check if string is a permutation of a palendrome
        public static bool IsPermutationOfParlendrome(string s)
        {
            s = s.Replace(" ", "");
            int[] cnt = new int[128];
            for (var i = 0; i < s.Length; i++)
            {
                int val = s[i];
                cnt[val]++;
            }
            bool isOdd = (s.Length % 2) != 0;
            var oddCnt = 0;
            var perm = true;
            for (var i = 0; i < cnt.Length; i++)
            {
                if ((!isOdd && cnt[i] == 1))
                {
                    perm = false;
                    break;
                }
                else if (isOdd && cnt[i] == 1 && oddCnt++ > 0)
                {
                    perm = false;
                    break;
                }

            }
            return perm;
        }

        //check if 2 strings are only one edit (insert, remove, replace) away for each other
        public static bool IsOneEditAway(string first, string second)
        {
            string s1 = first.Length < second.Length ? first : second;
            string s2 = first.Length < second.Length ? second : first;
            int i1 = 0, i2 = 0;
            bool foundDif = false;
            while (i1 < s1.Length && i2 < s2.Length)
            {
                if (s1[i1] != s2[i1])
                {
                    if (foundDif)
                        return false;
                    foundDif = true;
                    if (s1.Length == s2.Length)
                        i1++;
                }
                else
                    i1++;
                i2++;
            }


            return true;
        }

        //compress string
        public static string Compress(string s)
        {
            char[] c = new char[s.Length];
            char last = s[0];
            int cnt = 1;
            int idx = 0;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == last)
                    cnt++;
                else
                {
                    c[idx++] = last;
                    c[idx++] = Convert.ToChar(cnt.ToString());
                    last = s[i];
                    cnt = 1;
                }
            }
            c[idx++] = last;
            c[idx++] = Convert.ToChar(cnt.ToString());
            return new String(c);
        }

        //rotate matrix 90 degrees
        public static int[,] RotateNinety(int[,] m)
        {
            int[,] t = new int[m.GetLength(0), m.GetLength(1)];
            int r = 0, c = m.GetLength(1) - 1;

            while (c >= 0)
            {
                for (var i = 0; i < m.GetLength(0); i++)
                {
                    t[i, c] = m[r, i];
                }
                r++;
                c--;
            }
            return t;
        }

        //check if string is rotation of another
        public static bool IsStringRotation(string s1, string s2)
        {
            if (s1.CompareTo(s2) == 0)
                return true;
            string t;
            for (var piv = 1; piv < s1.Length; piv++)
            {
                if (s1.CompareTo(s2.Substring(piv, (s2.Length) - piv) + s2.Substring(0, piv)) == 0)
                    return true;
            }
            return false;
        }
    }

}
}
