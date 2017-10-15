using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class RouteBetweenNodes
    {
        public RouteBetweenNodes( GraphNode source)
        {
            if (source == null)
                throw new ArgumentException("Invalid arguments");
            BFS(source);
        }

        private void DFS(GraphNode n)
        {
            if (n == null)
                return;
            n.Marked = true;
            foreach(var w in n.Adj)
            {
                if (!w.Marked)
                    DFS(w);
            }
        }

        private void BFS(GraphNode n)
        {
            var q = new Queue<GraphNode>();
            q.Enqueue(n);

            while (q.Count > 0)
            {
                var x = q.Dequeue();
                x.Marked = true;
                foreach (var w in x.Adj)
                {
                    if (!w.Marked)
                        q.Enqueue(w);
                }
            }
        }

        public bool RouteExists(GraphNode v)
        {
            return v.Marked;
        }
    }
}
