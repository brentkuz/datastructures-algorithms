//Hash Table implementation using Separate Chaining.
//Easier to implement, but has worse reference locality,
//making it less performant.

using Searching.SequentialSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class SeparateChainingHashST<Key, Value>
        where Key : IComparable where Value : class
    {
        //m should be a large prime number
        private int m;
        private SequentialSearchST<Key, Value>[] st;


        public SeparateChainingHashST() : this(997) { }
        public SeparateChainingHashST(int m)
        {
            this.m = m;
            st = new SequentialSearchST<Key, Value>[m];
            for(var i = 0; i < m; i++)
            {
                st[i] = new SequentialSearchST<Key, Value>();
            }
        }

        //Modula hash - & 0x7fffffff will mask off sign bit
        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % m;
        }
        //O(n) - when all values collide
        public Value Get(Key key)
        {
            return st[Hash(key)].Get(key);
        }
        //O(n) - when all values collide
        public void Put(Key key, Value value)
        {
            st[Hash(key)].Put(key, value);
        }
        //O(n) - when all values collide
        public void Delete(Key key)
        {
            st[Hash(key)].Delete(key);
        }
    }
}
