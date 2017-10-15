//Binary search tree implemented as symbol table

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class BinarySearchST<Key,Value>
        where Key : IComparable where Value : class
    {
        private Key[] keys;
        private Value[] vals;
        private int N = 0;

        public BinarySearchST(int capacity)
        {
            keys = new Key[capacity];
            vals = new Value[capacity];            
        }

        public int Size()
        {
            return N;
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public Value Get(Key key)
        {
            if (IsEmpty())
                return null;

            var i = Rank(key, 0, N);

            if (i < N && keys[i].CompareTo(key) == 0)
                return vals[i];
            else
                return null;
        }

        public void Put(Key key, Value val)
        {
            var i = Rank(key, 0, N-1);

            if(i < N && keys[i].CompareTo(key) == 0)
            {
                vals[i] = val;
            }
            else
            {
                if (N == keys.Length)
                    Resize(keys.Length * 2);
                for(var j = N; j > i; j--)
                {
                    keys[j] = keys[j - 1];
                    vals[j] = vals[j - 1];
                }
                keys[i] = key;
                vals[i] = val;
                N++;
            }
        }

        //Binary Search happens here!!!
        //O(n) - worst case when values Put in ascending/descending order. 
        private int Rank(Key key)
        {
            int lo = 0, 
                hi = N - 1;
            while(lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(keys[mid]);
                if (cmp < 0)
                    hi = mid - 1;
                else if (cmp > 0)
                    lo = mid + 1;
                else
                    return mid;
            }

            return lo;
        }
        private int Rank(Key key, int lo, int hi)
        {
            if (hi < lo)
                return lo;
            int mid = lo + (hi - lo) / 2;
            int cmp = key.CompareTo(keys[mid]);
            if (cmp < 0)
                return Rank(key, lo, mid - 1);
            else if (cmp > 0)
                return Rank(key, mid + 1, hi);
            else return mid;
        }
        private void Resize(int capacity)
        {
            if(capacity > N)
            {
                var tk = new Key[capacity];
                var tv = new Value[capacity];
                for(var i = 0; i < N; i++)
                {
                    tk[i] = keys[i];
                    tv[i] = vals[i];
                }
                keys = tk;
                vals = tv;
            }
        }

    }

}
