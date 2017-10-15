using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class FirstCommonAncestor
    {
        private BinaryNode<int> ancestor = null;
        public FirstCommonAncestor(BinaryNode<int> root, BinaryNode<int> n1, BinaryNode<int> n2)
        {
            if (root == null || n1 == null || n2 == null)
                throw new ArgumentNullException();
            if (!Covers(root, n1) || !Covers(root, n2))
                throw new ArgumentException("Node is not in tree");
             ancestor = DFS(root, n1, n2);
        }

        public BinaryNode<int> CommonAncestor { get { return ancestor; } }

        private BinaryNode<int> DFS(BinaryNode<int> n, BinaryNode<int> n1, BinaryNode<int> n2)
        {
            if (n == null || n == n1 || n == n2)
                return n;

            bool n1OnLeft = Covers(n.Left, n1);
            bool n2OnLeft = Covers(n.Left, n2);
            if (n1OnLeft != n2OnLeft)
                return n;

            var childSide = n1OnLeft ? n.Left : n.Right;
            return DFS(childSide, n1, n2);
            
        }
        private bool Covers(BinaryNode<int> root, BinaryNode<int> n)
        {
            if (root == null) return false;
            if (n == root) return true;
            return Covers(root.Left, n) || Covers(root.Right, n);

        }


    }
}
