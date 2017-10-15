using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Searching
{
    public class SymbolTable<Key, Value> : IEnumerable where Key : IComparable where Value : class
    {
        private Dictionary<Key, Value> st;

        public SymbolTable()
        {
            st = new Dictionary<Key, Value>();            
        }

        public Value Get(Key key)
        {
            if (key == null)
                throw new ArgumentNullException("Key cannot be null.");
            return st[key];
        }

        public void Put(Key key, Value value)
        {
            if (key == null)
                throw new ArgumentNullException("Value cannot be null.");
            if (value == null)
                st.Remove(key);
            else
            {
                if (st.Keys.Contains(key))
                    st[key] = value;
                else
                    st.Add(key, value);
            }
        }

        public void Delete(Key key)
        {
            if (key == null)
                throw new ArgumentNullException("Key cannot be null");
            st.Remove(key);
        }

        public bool Contains(Key key)
        {
            if (key == null)
                throw new ArgumentNullException("Key cannot be null");
            return st.Keys.Contains(key) && st[key] != null;
        }

        public int Size()
        {
            return st.Count();
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }


        public Key Min()
        {
            return st.FirstOrDefault().Key;
        }
        
        public Key Max()
        {
            return st.LastOrDefault().Key;
        }

        public IEnumerator GetEnumerator()
        {
            return st.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
