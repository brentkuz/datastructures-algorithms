//Binary search tree implementation using Node class 
//with many common supporting methods.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.BST
{
    public class BinarySearchTree<Key, Value> where Key : IComparable where Value : class
    {
        private Node<Key, Value> root = null;

        public void Print(bool ascending)
        {
            if (ascending)
                PrintAsc(root);
            else
                PrintDesc(root);
        }
        public int Size()
        {
            return Size(root);
        }
        public Value Get(Key key)
        {
            if (key == null)
                throw new Exception("Key cannot be null.");
            return Get(root, key);
        }

        public void Put(Key key, Value val)
        {
            if (key == null)
                throw new Exception("Called Put() with a null key");
            if (val == null)
            {
                Delete(key);
                return;
            }
            root = Put(root, key, val);
        } 
        public bool IsEmpty()
        {
            return Size() == 0;
        }
        public void DeleteMax()
        {
            if (IsEmpty()) throw new Exception("Symbol table underflow");
            root = DeleteMax(root);
        }
        public void DeleteMin()
        {
            if (IsEmpty()) throw new Exception("Symbol table underflow");
            root = DeleteMin(root);
        }
        public Key Min()
        {
            if (IsEmpty()) throw new Exception("called min() with empty symbol table");
            return Min(root).key;
        }
        public Key Max()
        {
            if (IsEmpty())
                throw new Exception("Empty");
            return Max(root).key;
        }
        public void Delete(Key key)
        {
            if (key == null) throw new Exception("called delete() with a null key");
            root = Delete(root, key);
        }
        public Key Floor(Key key)
        {
            Node<Key, Value> x = Floor(root, key);
            if (x == null)
                return default(Key);
            return x.key;
        }
        public Key Select(int k)
        {
            return Select(root, k).key;
        }
        public IEnumerable Keys()
        {
            return Keys(Min(), Max());
        }
        public IEnumerable Keys(Key lo, Key hi)
        {
            Queue<Key> queue = new Queue<Key>();
            Keys(root, queue, lo, hi);
            return queue;
        }


        private void PrintAsc(Node<Key,Value> x)
        {
            if (x == null)
                return;
            PrintAsc(x.Left);
            Console.WriteLine(x.key);
            PrintAsc(x.Right);
        }
        private void PrintDesc(Node<Key,Value> x)
        {
            if (x == null)
                return;
            PrintDesc(x.Right);
            Console.WriteLine(x.key);
            PrintDesc(x.Left);
        }
        private int Size(Node<Key,Value> x)
        {
            if (x == null)
                return 0;
            return x.N;
        }
        private Value Get(Node<Key,Value> x, Key key)
        {
            if (key == null)
                throw new Exception("Called Get() in null key");
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.key);

            if (cmp < 0)
                return Get(x.Left, key);
            else if (cmp > 0)
                return Get(x.Right, key);
            else
                return x.value;
        }
        private Node<Key,Value> Put(Node<Key,Value> x, Key key, Value val)
        {
            if (x == null)
                return new Node<Key, Value>(key, val, 1);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
                x.Left = Put(x.Left, key, val);
            else if (cmp > 0)
                x.Right = Put(x.Right, key, val);
            else
                x.value = val;

            x.N = 1 + Size(x.Left) + Size(x.Right);
            return x;
        }
        private Node<Key,Value> DeleteMax(Node<Key,Value> x)
        {
            if (x.Right == null) return x.Left;
            x.Right = DeleteMax(x.Right);
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }
        private Node<Key,Value> DeleteMin(Node<Key,Value> x)
        {
            if (x.Left == null) return x.Right;
            x.Left = DeleteMin(x.Left);
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }
        private Node<Key, Value> Delete(Node<Key, Value> x, Key key)
        {
            if (x == null)
                return null;

            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.Left = Delete(x.Left, key);
            else if (cmp > 0) x.Right = Delete(x.Right, key);
            else
            {
                if (x.Right == null) return x.Left;
                if (x.Left == null) return x.Right;
                Node<Key,Value> t = x;
                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }
        private Node<Key,Value> Min(Node<Key,Value> x)
        {
            if (x.Left == null) return x;
            else return Min(x.Left);
        }

        private Node<Key,Value> Max(Node<Key,Value> x)
        {
            if (x.Right == null) return x;
            else return Max(x.Right);
        }
        private Node<Key,Value> Floor(Node<Key,Value> x, Key key)
        {
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0)
                return x;
            if (cmp < 0)
                return Floor(x.Left, key);
            Node<Key, Value> t = Floor(x.Right, key);
            if (t != null)
                return t;
            else
                return x;
        }
        private Node<Key,Value> Select(Node<Key,Value> x, int k)
        {
            if (x == null)
                return null;
            int t = Size(x.Left);
            if (t > k)
                return Select(x.Left, k);
            else if (t < k)
                return Select(x.Right, k-t-1);
            else
                return x;
        }
        private void Keys(Node<Key,Value> x, Queue<Key> queue, Key lo, Key hi)
        {
            if (x == null)
                return;
            int cmplo = lo.CompareTo(x.key);
            int cmphi = hi.CompareTo(x.key);
            if (cmplo < 0)
                Keys(x.Left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0)
                queue.Enqueue(x.key);
            if (cmphi > 0)
                Keys(x.Right, queue, lo, hi);

        }

        public class Node<K, V> where K : IComparable where V : class
        {
            public K key { get; set; }
            public V value { get; set; }
            public Node<K, V> Left { get; set; }
            public Node<K, V> Right { get; set; }
            public int N { get; set; }

            public Node(K key, V val, int n)
            {
                this.key = key;
                this.value = val;
                N = n;
            }
        }
    }


}
