using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrucuresAndAlgorithms.LeetCode
{
    public static class LeetCodeProblems
    {
        public static string countAndSay(int A)
        {
            var ans = new List<int>();
            ans.Add(1);

            for (int i = 1; i < A; i++)
            {
                int count = 0;
                int num = ans[0];
                var sub = new List<int>();
                for (int j = 0; j < ans.Count; j++)
                {
                    if (num == ans[j])
                    {
                        count++;
                    }
                    else
                    {
                        sub.Add(count);
                        sub.Add(num);
                        num = ans[j];
                        count = 1;
                    }
                }
                sub.Add(count);
                sub.Add(num);
                ans = sub;
            }
            var sb = new StringBuilder();
            for (int i = 0; i < ans.Count; i++)
                sb.Append(ans[i]);

            return sb.ToString();
        }
        public static string longestCommonPrefix(List<string> A)
        {
            var t = new Trie();
            foreach (var str in A)
                t.Put(str);

            if (A.Count > 0)
                return t.LongestPrefix();
            return "";

        }
        public static int LengthOfLongestSubstring(string s)
        {
            var map = new Dictionary<char, int>();
            var max = 0;
            for (int i = 0, j = 0; i < s.Length; i++)
            {
                if (map.Keys.Contains(s[i]))
                {
                    j = Math.Max(j, map[s[i]] + 1);
                    map[s[i]] = i;
                }
                else
                    map.Add(s[i], i);

                max = Math.Max(max, i - j + 1);
            }

            return max;
        }
        public static int findRank(string A)
        {
            int[] charCount = new int[256]; // count of characters in A. 
            for (int i = 0; i < A.Length; i++) charCount[A[i]]++;

            List<int> fact = new List<int>(); // fact[i] will contain i! % MOD
            initializeFactorials(A.Length + 1, fact);

            long rank = 1;
            for (int i = 0; i < A.Length; i++)
            {
                // find number of characters smaller than A[i] still left. 
                int less = 0;
                for (int ch = 0; ch < A[i]; ch++)
                {
                    less += charCount[ch];
                }
                rank = (rank + ((long)fact[A.Length - i - 1] * less)) % 1000003;
                // remove the current character from the set. 
                charCount[A[i]]--;
            }
            return (int)rank;
        }
        static void initializeFactorials(int totalLen, List<int> fact)
        {
            long factorial = 1;
            fact.Add(1); // 0!= 1
            for (int curIndex = 1; curIndex < totalLen; curIndex++)
            {
                factorial = (factorial * curIndex) % 1000003;
                fact.Add((int)factorial);
            }
            return;
        }
        public static int maxSubArray(List<int> A)
        {

            int max = -1000000000;
            int sum = 0;


            for (int i = 0; i < A.Count; i++)
            {
                sum += A[i];

                if (sum > max)
                {
                    max = sum;
                }

                if (sum <= 0)
                {
                    sum = 0;
                }
            }

            return max;

        }
        private static void Max(List<int> A, int idx, int? sum, int[] max)
        {

            if (sum > max[0])
                max[0] = (int)sum;

            if (idx == A.Count())
                return;
            if (sum == null)
                sum = 0;

            Max(A, idx + 1, sum + A[idx], max);
        }
        public static List<int> plusOne(List<int> A)
        {
            int carry = -1;
            int pos = A.Count() - 1;

            while (carry != 0)
            {
                if (pos < 0) break;
                int sum;
                if (pos == A.Count() - 1)
                    sum = A[pos] + 1;
                else
                    sum = A[pos] + carry;
                A[pos] = sum % 10;
                carry = sum / 10;
                pos--;
            }

            if (carry != 0)
            {
                var t = new List<int>() { carry };
                t.AddRange(A);
                A = t;
            }

            var idx = 0;
            if (A[0] == 0)
            {
                while (A[idx] == 0)
                    idx++;
            }

            return A.GetRange(idx, A.Count() - idx);
        }
        public static int trailingZeroes(int A)
        {
            int cnt = 0;
            int pow = 1;
            while (Math.Pow(5, pow) <= A)
            {
                var facts = A / Math.Pow(5, pow);
                cnt += (int)facts;
                pow++;
            }
            return cnt;
        }
        private static Int64 Factorial(int n)
        {
            if (n == 1)
                return 1;
            return n * Factorial(n - 1);

        }
        public static int gcd(int A, int B)
        {
            if (A == 0)
                return B;
            if (B == 0)
                return A;

            var small = A < B ? A : B;
            for (var i = small; i > 0; i--)
            {
                if (A % i == 0 && B % i == 0)
                    return i;
            }
            return 1;
        }
        public static int isPalindrome(int A)
        {
            var chars = A.ToString();
            int lo = 0, hi = chars.Count() - 1;
            while (lo < hi)
            {
                if (chars[lo++] != chars[hi--])
                    return 0;
            }
            return 1;
        }
        public static int reverse(int A)
        {
            var chars = A.ToString();
            string res = "";
            if (A < 0)
                res += "-";
            for (var i = chars.Count() - 1; i >= 0; i--)
                if (chars[i] != '-')
                    res += chars[i];


            Int32 r;
            Int32.TryParse(res, out r);
            return r;
        }
        public static int titleToNumber(string A)
        {
            var col = 0;
            var pos = 0;
            for (var i = A.Count() - 1; i >= 0; i--)
            {
                var val = ((int)A[i] - 64);
                val *= (int)Math.Pow(26, pos);
                col += val;
                pos++;

            }
            return col;
        }
        public static string convertToTitle(int A)
        {
            string title = "";

            while (A > 0)
            {
                var val = (A - 1) % 26 + 'A';
                title = ((char)val).ToString() + title;
                A = (A - 1) / 26;
            }

            return title;
        }
        private static List<int> Sieve(int a)
        {
            List<int> primes = new List<int>();
            bool[] isPrime = new bool[a + 1];
            for (int i = 0; i < a; i++)
                isPrime[i] = true;

            for (var p = 2; p * p <= a; p++)
            {
                if (isPrime[p])
                {
                    for (var i = p * 2; i <= a; i += p)
                        isPrime[i] = false;
                }
            }

            for (var i = 2; i <= a; i++)
                if (isPrime[i])
                    primes.Add(i);

            return primes;
        }
        public static bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return left == right;
            if (left.val != right.val)
                return false;
            return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
        }
    }

    public class TreeNode
    {
        public Nullable<int> val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(Nullable<int> x) { val = x; }
    }


    public class Trie
    {
        protected const int R = 256;
        private TrieNode root;
        private int shortDepth = int.MaxValue;

        public Trie()
        {
            root = new TrieNode(null);
        }

        public TrieNode Root { get; }

        public string LongestPrefix()
        {
            return LongestPrefix(root, "", 0);
        }
        private string LongestPrefix(TrieNode n, string pref, int d)
        {
            var next = OneChild(n);
            if (n == null || next < 0 || d >= shortDepth)
                return pref + n.Key;

            return LongestPrefix(n.Next[next], pref + n.Key, d + 1);

        }

        public static int OneChild(TrieNode node)
        {
            int cnt = 0;
            int idx = -1;
            for (var i = 0; i < node.Next.Length; i++)
            {
                var c = node.Next[i];
                if (c != null)
                {
                    cnt++;
                    idx = i;
                }
            }
            if (cnt == 1)
                return idx;
            return -1;
        }

        public void Put(string word)
        {
            if (word == null)
                return;
            Put(root, word, 0);
        }
        private void Put(TrieNode n, string word, int d)
        {
            if (d == word.Length)
            {
                if (d < shortDepth)
                    shortDepth = d;
                return;
            }
            TrieNode next;

            if (n.Next[word[d]] == null)
            {
                next = new TrieNode(word[d]);
                n.Next[word[d]] = next;
            }
            else
                next = n.Next[word[d]];

            if (d == word.Length - 1)
                next.IsWord = true;

            Put(next, word, d + 1);
        }

        public class TrieNode
        {
            public TrieNode(char? key)
            {
                Key = key;
                Next = new TrieNode[R];
            }
            public char? Key { get; set; }
            public bool IsWord { get; set; }
            public TrieNode[] Next { get; set; }
        }
    }

}
}
