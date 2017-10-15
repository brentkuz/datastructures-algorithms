//Hash Table using Linear Probing implementation.
//Generally more performant that Separate Chaining due to 
//reference locality of array (contiguous memory).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class LinearProbingHashST<Key, Value>
        where Key : class where Value : class
    {
        private static readonly int capacity = 4;

        private int n;
        private int m;
        private Key[] keys;
        private Value[] vals;

        public LinearProbingHashST() : this(capacity) { }
        public LinearProbingHashST(int capacity)
        {
            m = capacity;
            n = 0;
            keys = new Key[m];
            vals = new Value[m];
        }

        //O(n) - when all values collide
        public void Put(Key key, Value val)
        {
            if (val == null)
            {
                Delete(key);
                return;
            }
            
            if (n >= m / 2)
                Resize(2 * m);

            int i;
            for(i = Hash(key); keys[i] != null; i = (i + 1) % m)
            {
                if(keys[i].Equals(key))
                {
                    vals[i] = val;
                    return;
                }                
            }
            keys[i] = key;
            vals[i] = val;
            n++;
        }
        //O(n) - when all values collide
        public Value Get(Key key)
        {
            for(var i = Hash(key); keys[i] != null; i = (i + 1) % m)
            {
                if (keys[i].Equals(key))
                    return vals[i];
            }
            return null;
        }
        //O(n) - when all values collide
        public void Delete(Key key)
        {
            if (!Contains(key))
                return;

            var i = Hash(key);
            while(!key.Equals(keys[i]))
            {
                i = (i + 1) % m;
            }
            keys[i] = null;
            vals[i] = null;

            i = (i + 1) % m;
            while(keys[i] != null)
            {
                var keyToRehash = keys[i];
                var valToRehash = vals[i];
                keys[i] = null;
                vals[i] = null;
                n--;
                Put(keyToRehash, valToRehash);
                i = (i + 1) % m;
            }

            n--;

            if (n > 0 && n <= m / 8)
                Resize(m / 2);
        }
        public bool Contains(Key key)
        {
            return Get(key) != null;
        }
        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % m;
        }
        private void Resize(int capacity)
        {
            var temp = new LinearProbingHashST<Key, Value>(capacity);
            for(var i = 0; i < m; i++)
            {
                if (keys[i] != null)
                    temp.Put(keys[i], vals[i]);
            }
            keys = temp.keys;
            vals = temp.vals;
            m = temp.m;
        }

    }
}
