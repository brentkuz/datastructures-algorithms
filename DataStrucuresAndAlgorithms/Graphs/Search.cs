//Search implementations used as the base
//of other algs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    //O(V+E) - V = vertices; E = edges
    public class DepthFirstSearch
    {
        protected bool[] marked;
        protected int count;

        public DepthFirstSearch(Graph g, int s)
        {
            marked = new bool[g.V];
            DFS(g, s);
        }

        protected virtual void DFS(Graph g, int v)
        {            
            marked[v] = true;
            count++;
            foreach(var w in g.Adj(v))
            {
                if (!marked[w])
                    DFS(g, w);
            }
        }

        public bool Marked(int w)
        {
            return marked[w];
        }

        public int Count()
        {
            return count;
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }
        
    }

    //DFS that tracks paths
    public class DepthFirstPaths
    {
        protected bool[] marked;
        protected int count;
        private int[] edgeTo;
        private readonly int s;

        public DepthFirstPaths(Graph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            this.s = s;
            DFS(g, s);
        }

        protected void DFS(Graph g, int v)
        {
            marked[v] = true;
            count++;
            foreach (var w in g.Adj(v))
            {
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    DFS(g, w);
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }
        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
                return null;
            Stack<int> path = new Stack<int>();
            for (var x = v; x != s; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(s);
            return path;
        }
    }

    //O(V+E) - V = vertices; E = edges
    //Will find the shortest paths
    public class BreadthFirstSearch
    {
        private bool[] marked;
        private int[] edgeTo;
        private readonly int s;

        public BreadthFirstSearch(Graph g, int s)
        {
            marked = new bool[g.V];
            edgeTo = new int[g.V];
            this.s = s;
            BFS(g, s);
        }

        private void BFS(Graph g, int s)
        {
            Queue<int> queue = new Queue<int>();
            marked[s] = true;
            queue.Enqueue(s);
            while(queue.Count != 0)
            {
                int v = queue.Dequeue();
                foreach(var w in g.Adj(v))
                {
                    if(!marked[w])
                    {
                        edgeTo[w] = v;
                        marked[w] = true;
                        queue.Enqueue(w);
                    }
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
                return null;
            Stack<int> path = new Stack<int>();
            for (var x = v; x != s; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(s);
            return path;
        }
    }





}
