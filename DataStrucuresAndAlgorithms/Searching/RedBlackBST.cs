//Balanced search tree implementation using Red-Black tree
//O(log(n)) - all operations

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.RBTree
{

    public class RedBlackBST<Key, Value> where Key : IComparable where Value : class
    {
        internal static readonly bool RED = true;
        internal static readonly bool BLACK = false;

        private Node<Key, Value> root;
        public int Size()
        {
            return Size(root);
        }
        private int Size(Node<Key, Value> x)
        {
            if (x == null)
                return 0;
            return x.N;
        }
        private bool IsRed(Node<Key,Value> x)
        {
            if (x == null)
                return false;
            return x.Color == RED;
        }
        private Node<Key,Value> RotateLeft(Node<Key,Value> h)
        {
            Node<Key, Value> x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = RED;
            x.N = h.N;
            h.N = Size(h.Left) + Size(h.Right) + 1;
            return x;
        }
        private Node<Key,Value> RotateRight(Node<Key,Value> h)
        {
            Node<Key, Value> x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = RED;
            x.N = h.N;
            h.N = Size(h.Left) + Size(h.Right) + 1;
            return x;
        }
        private void FlipColors(Node<Key,Value> h)
        {
            h.Color = !h.Color;
            h.Left.Color = !h.Left.Color;
            h.Right.Color = !h.Right.Color;
        }

        public void Put(Key key, Value val)
        {            
            root = Put(root, key, val);
            root.Color = BLACK;
        }
        private Node<Key,Value> Put(Node<Key,Value> h, Key key, Value val)
        {
            if (h == null)
                return new Node<Key, Value>(key, val, RED, 1);

            int cmp = key.CompareTo(h.key);
            if (cmp < 0)
                h.Left = Put(h.Left, key, val);
            else if (cmp > 0)
                h.Right = Put(h.Right, key, val);
            else
                h.value = val;

            //rebalance the tree
            if (IsRed(h.Right) && !IsRed(h.Left))
                h = RotateLeft(h);
            if (IsRed(h.Left) && IsRed(h.Left.Left))
                h = RotateRight(h);
            if (IsRed(h.Left) && IsRed(h.Right))
                FlipColors(h);
            h.N = Size(h.Left) + Size(h.Right) + 1;

            return h; 
        }
        public void Delete(Key key)
        {
            if (!IsRed(root.Left) && !IsRed(root.Right))
                root.Color = RED;
            root = Delete(root, key);
            if (!IsEmpty())
                root.Color = BLACK;

        }
        private Node<Key,Value> Delete(Node<Key,Value> h, Key key)
        {
            if(key.CompareTo(h.key) < 0)//left
            {
                if (!IsRed(h.Left) && !IsRed(h.Left.Left))
                    h = MoveRedLeft(h);
                h.Left = Delete(h.Left, key);
            }
            else
            {
                if (IsRed(h.Left))
                    h = RotateRight(h);
                if (key.CompareTo(h.key) == 0 && (h.Right == null))
                    return null;
                if (!IsRed(h.Right) && !IsRed(h.Right.Left))
                    h = MoveRedRight(h);
                if (key.CompareTo(h.key) == 0)
                {
                    Node<Key, Value> x = Min(h.Right);
                    h.key = x.key;
                    h.value = x.value;
                    h.Right = DeleteMin(h.Right);
                }
                else
                    h.Right = Delete(h.Right, key);
            }
            return Balance(h);

        }
        public bool IsEmpty()
        {
            return root == null;
        }
        private Node<Key,Value> MoveRedLeft(Node<Key,Value> h)
        {
            FlipColors(h);
            if(IsRed(h.Right.Left))
            {
                h.Right = RotateRight(h.Right);
                h = RotateLeft(h);
                FlipColors(h);
            }
            return h;
        }
        private Node<Key,Value> MoveRedRight(Node<Key,Value> h)
        {
            FlipColors(h);
            if(IsRed(h.Left.Left))
            {
                h = RotateRight(h);
                FlipColors(h);
            }
            return h;
        }
        private Node<Key,Value> Min(Node<Key,Value> x)
        {
            if (x.Left == null)
                return x;
            else
                return Min(x.Left);
        }
        private Node<Key,Value> DeleteMin(Node<Key,Value> h)
        {
            if (h.Left == null)
                return h;
            if (!IsRed(h.Left) && !IsRed(h.Left.Left))
                h = MoveRedLeft(h);
            h.Left = DeleteMin(h.Left);
            return Balance(h);
        }
        private Node<Key,Value> Balance(Node<Key,Value> h)
        {
            if (IsRed(h.Right))
                h = RotateLeft(h);
            if (IsRed(h.Left) && IsRed(h.Left.Left))
                h = RotateRight(h);
            if (IsRed(h.Left) && IsRed(h.Right))
                FlipColors(h);
            h.N = Size(h.Left) + Size(h.Right) + 1;
            return h;
        }


    }


    internal class Node<Key, Value> where Key : IComparable where Value : class
    {
        public Key key { get; set; }
        public Value value { get; set; }
        public Node<Key, Value> Left { get; set; }
        public Node<Key, Value> Right { get; set; }
        public bool Color { get; set; }
        public int N { get; set; }

        public Node(Key key, Value val, bool color, int n)
        {
            this.key = key;
            this.value = val;
            this.Color = color;
            N = n;
        }

        

        private int Size(Node<Key, Value> x)
        {
            if (x == null)
                return 0;
            return x.N;
        }
    }
}
