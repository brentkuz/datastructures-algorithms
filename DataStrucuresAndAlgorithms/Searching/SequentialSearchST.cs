using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.SequentialSearch
{
    public class SequentialSearchST<Key, Value>
        where Key : IComparable where Value : class
    {
        private Node<Key, Value> first;

        public Value Get(Key key)
        {
            for (var x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                    return x.value;
            }
            return null;
        }
        public void Put(Key key, Value value)
        {
            for (var x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                {
                    x.value = value;
                    break;
                }                
            }
            first = new Node<Key, Value>(key, value, first);
        }
        public void Delete(Key key)
        {
            first = Delete(first, key);
        }
        private Node<Key,Value> Delete(Node<Key,Value> x, Key key)
        {
            if (x.key.CompareTo(key) == 0)
                return x.next;
            
            x.next = Delete(x.next, key);
            return x;
        }
    }

    public class Node<Key, Value>
        where Key : IComparable where Value : class
    {
        public Key key { get; set; }
        public Value value { get; set; }
        public Node<Key, Value> next { get; set; }

        public Node(Key key, Value value, Node<Key,Value> next)
        {
            this.key = key;
            this.value = value;
            this.next = next;
        }  
    }
}
