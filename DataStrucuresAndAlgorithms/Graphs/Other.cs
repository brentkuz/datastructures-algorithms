//Other graph algs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    //Depth first search to find connected components
    public class CC
    {
        protected bool[] marked;
        protected int count;
        private int[] id;

        public CC(Graph g)
        {
            marked = new bool[g.V];
            id = new int[g.V];
            for (int s = 0; s < g.V; s++)
            {
                if (!marked[s])
                {
                    DFS(g, s);
                    count++;
                }
            }
        }

        protected virtual void DFS(Graph g, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (var w in g.Adj(v))
            {
                if (!marked[w])
                    DFS(g, w);
            }
        }

        public bool Connected(int v, int w)
        {
            return id[v] == id[w];
        }

        public int Id(int v)
        {
            return id[v];
        }

        public int Count()
        {
            return count;
        }
    }

    //Find a cycle in an undirected graph
    public class Cycle
    {
        protected bool[] marked;
        private bool hasCycle;

        public Cycle(Graph g)
        {
            marked = new bool[g.V];
            for (int s = 0; s < g.V; s++)
            {
                if (hasCycle)
                    break;
                if (!marked[s])
                {
                    DFS(g, s, s);
                }
            }
        }

        protected virtual void DFS(Graph g, int v, int u)
        {
            if (hasCycle)
                return;
            marked[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (!marked[w])
                    DFS(g, w, v);
                else if (w != u)
                    hasCycle = true;

            }

        }

        public bool HasCycle()
        {
            return hasCycle;
        }
    }


    /*Directed Graphs*/
    public class DirectedDFS
    {
        private bool[] marked;

        public DirectedDFS(Digraph g, int s)
        {
            marked = new bool[g.V];
            DFS(g, s);
        }

        public DirectedDFS(Digraph g, IEnumerable<int> sources)
        {
            marked = new bool[g.V];
            foreach (var s in sources)
                if (!marked[s])
                    DFS(g, s);
        }

        public void DFS(Digraph g, int v)
        {
            marked[v] = true;
            foreach (var i in g.Adj(v))
            {
                if (!marked[i])
                    DFS(g, i);
            }

        }

        public bool Marked(int v)
        {
            return marked[v];
        }
    }

    //Find cycle in directed graph
    public class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> cycle;
        private bool[] onStack;

        public DirectedCycle(Digraph g)
        {
            onStack = new bool[g.V];
            edgeTo = new int[g.V];
            marked = new bool[g.V];

            for (var i = 0; i < g.V; i++)
                if (!marked[i])
                    DFS(g, i);
        }

        private void DFS(Digraph g, int v)
        {
            onStack[v] = true;
            marked[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (HasCycle())
                    return;
                else if (!marked[w])
                {
                    edgeTo[w] = v;
                    DFS(g, w);
                }
                else if (onStack[w])
                {
                    cycle = new Stack<int>();
                    for (int x = v; x != w; x = edgeTo[x])
                        cycle.Push(x);
                    cycle.Push(w);
                    cycle.Push(v);
                }
                onStack[v] = false;

            }
        }

        public bool HasCycle()
        {
            return cycle != null;
        }

        public IEnumerable<int> Cycle()
        {
            return cycle;
        }
    }

    //Find strong-connected component - every node is reachable from every other node
    public class KosarajuSharirSCC
    {
        protected bool[] marked;
        protected int count;
        private int[] id;

        public KosarajuSharirSCC(Graph g)
        {
            marked = new bool[g.V];
            id = new int[g.V];
            var order = new DepthFirstOrder(g);
            foreach (var v in order.ReversePostorder())
            {
                if (!marked[v])
                {
                    DFS(g, v);
                    count++;
                }
            }
        }

        protected virtual void DFS(Graph g, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (var w in g.Adj(v))
            {
                if (!marked[w])
                    DFS(g, w);
            }
        }

        public bool StronglyConnected(int v, int w)
        {
            return id[v] == id[w];
        }

        public int Id(int v)
        {
            return id[v];
        }

        public int Count()
        {
            return count;
        }
    }
}
