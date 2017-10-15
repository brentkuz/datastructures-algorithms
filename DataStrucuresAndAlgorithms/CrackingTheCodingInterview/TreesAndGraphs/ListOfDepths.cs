using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class ListOfDepths
    {
        private Dictionary<int, LinkedList<BinaryNode<int>>> lls = new Dictionary<int, LinkedList<BinaryNode<int>>>();      

        public ListOfDepths(BinaryNode<int> root)
        {
            int d = 0;
            TraverseDepthsDFS(root, d);
        }
        public IEnumerable<LinkedList<BinaryNode<int>>> LLs
        {
            get
            {
                var depths = new LinkedList<BinaryNode<int>>[lls.Keys.Count];
                foreach(var i in lls)
                {
                    depths[i.Key] = i.Value;
                }
                return depths;
            }
        }
        private void TraverseDepthsDFS(BinaryNode<int> n, int d)
        {
            if (n == null)
                return;
            AddNodeToLL(n, d);
            TraverseDepthsDFS(n.Left, d + 1);
            TraverseDepthsDFS(n.Right, d + 1);
        }
       

        private void AddNodeToLL(BinaryNode<int> n, int d)
        {
            if (!lls.Keys.Contains(d))
                lls.Add(d, new LinkedList<BinaryNode<int>>());
            lls[d].AddLast(n);
        }



    }
}
