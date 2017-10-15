using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{


    public class BinaryNode<T> where T : IComparable
    {
        public BinaryNode(T key)
        {
            Key = key;
            Value = key;
        }
        public BinaryNode(T key, object value)
        {
            Key = key;
            Value = value;
        }
        public BinaryNode(T key, object value, BinaryNode<T> left, BinaryNode<T> right)
        {
            Key = key;
            Value = value;
            Left = left;
            Right = right;
        }

        public T Key { get; set; }
        public object Value { get; set; }
        public BinaryNode<T> Parent { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }

        public void AddLeft(BinaryNode<T> left)
        {
            Left = left;
            Left.Parent = this;
        }
        public void AddRight(BinaryNode<T> right)
        {
            Right = right;
            Right.Parent = this;
        }
    }
}
