using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class MinHeightBST
    {
        public MinHeightBST() { }
        public MinHeightBST(int[] vals)
        {
            Root = Build(vals, 0, vals.Length - 1);
        }
        public BinaryNode<int> Root { get; set; }

        public void AddNode(int key, int val)
        {
            Root = AddNode(Root, key, val);
        }
        private BinaryNode<int> AddNode(BinaryNode<int> n, int key, int val)
        {
            if (n == null)
                return new BinaryNode<int>(key, val);

            if (key < n.Key)
                n.Left = AddNode(n.Left, key, val);
            else if (key > n.Key)
                n.Right = AddNode(n.Right, key, val);
            else
                n.Value = val;
            return n;
        }

        private BinaryNode<int> Build(int[] vals, int lo, int hi)
        {
            if (lo > hi)
                return null;
            var mid = lo + (hi - lo) / 2;

            var x = new BinaryNode<int>(vals[mid], vals[mid]);
            x.Left = Build(vals, lo, mid - 1);
            x.Right = Build(vals, mid + 1, hi);
            return x;
        }

        public void Delete(int key)
        {
            Root = Delete(Root, key);
        }
        private BinaryNode<int> Delete(BinaryNode<int> n, int key)
        {
            if (n.Left == null)
                return null;

            if (key < n.Key)
                n.Left = Delete(n.Left, key);
            else if (key > n.Key)
                n.Right = Delete(n.Right, key);
            else
            {
                if (n.Right == null)
                    return n.Left;
                if (n.Left == null)
                    return n.Right;
                var t = n;
                n = Min(t.Right);
                n.Right = DeleteMin(t.Right);
                n.Left = t.Left;
            }
            return n;
        }

        public int Min()
        {
            return (int)Min(Root).Key;
        }
        private BinaryNode<int> Min(BinaryNode<int> n)
        {
            if (n.Left == null)
                return n;
            return Min(n.Left);
        }
        private BinaryNode<int> DeleteMin(BinaryNode<int> n)
        {
            if (n.Left == null)
                return n.Right;
            n.Left = DeleteMin(n.Left);
            return n;
        }

    }
}
