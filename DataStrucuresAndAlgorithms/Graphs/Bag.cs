using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Bag<T> : IEnumerable<T> where T : struct
    {
        private Node<T> first;
        private int n = 0;

        public int Count() { return n; }
        public bool IsEmpty()
        {
            return n == 0;
        }
        public void Add(T item)
        {
            if (IsEmpty())
            {
                first = new Node<T>() { Item = item, Next = null };
            }
            else
            {
                var newFirst = new Node<T>() { Item = item, Next = first };
                first = newFirst;
            }
            n++;
        }


        public bool Find(T key)
        {
            //return searchRecurse(first, key);
            return searchIterate(key);
        }
        private bool searchRecurse(Node<T> curr, T key)
        {
            if (curr.Item.Equals(key))
                return true;
            if (curr.Next == null)
                return false;

            return searchRecurse(curr.Next, key);
        }
        private bool searchIterate(T key)
        {
            var curr = first;
            while (curr != null)
            {
                if (curr.Item.Equals(key))
                    return true;
                curr = curr.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var item = first;

            while (item != null)
            {
                yield return item.Item;
                item = item.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


    }
}
