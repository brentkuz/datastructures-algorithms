//Undirected Graph implementation

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph
    {
        protected readonly int v;
        protected int e;
        protected Bag<int>[] adj;

        public Graph(int v)
        {
            this.v = v;
            this.e = 0;
            adj = new Bag<int>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new Bag<int>();
            }
        }

        public int E
        {
            get { return this.e; }
        }
        public int V
        {
            get { return this.v; }
        }

        public virtual void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
            e++;
        }

        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }

        public virtual int Degree(int v)
        {
            return adj[v].Count();
        }
    }
}
