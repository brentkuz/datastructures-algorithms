using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class Successor
    {
        private BinaryNode<int> next = null;

        public Successor(BinaryNode<int> n)
        {
            if (n == null)
                throw new ArgumentNullException();
            next = FindNext(n);
        }

        public BinaryNode<int> Next
        {
            get
            {
                return next;
            }
        }

        private BinaryNode<int> FindNext(BinaryNode<int> n)
        {
            if (n.Right != null)
            {
                var down = n.Right;
                while (down.Left != null)
                    down = down.Left;
                return down;
            }
            else
            {
                var up = n.Parent;
                while (up.Key <= n.Key)
                    up = up.Parent;
                return up;
            }     
        }
    }
}
