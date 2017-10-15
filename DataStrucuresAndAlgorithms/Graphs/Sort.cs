//Various graph sort implementations

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DepthFirstOrder
    {
        private bool[] marked;
        private Queue<int> pre;
        private Queue<int> post;
        //aka Topological sort
        private Stack<int> reversePost;

        public DepthFirstOrder(Digraph g)
        {
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();

            marked = new bool[g.V];

            for (int v = 0; v < g.V; v++)
            {
                if (!marked[v])
                    DFS(g, v);
            }
               
        }

        private void DFS(Digraph g, int v)
        {
            pre.Enqueue(v);
            marked[v] = true;
            foreach(var i in g.Adj(v))
            {
                if (!marked[i])
                    DFS(g, i);
            }
            post.Enqueue(v);
            reversePost.Push(v);
        }

        public IEnumerable<int> Preorder()
        {
            return pre;
        }
        public IEnumerable<int> Postorder()
        {
            return post;
        }
        public IEnumerable<int> ReversePostorder()
        {
            return reversePost;
        }

    }
}
