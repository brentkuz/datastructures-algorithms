using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class UnorderedGraph
    {
        private List<int>[] adj;       

        public UnorderedGraph(int v)
        {
            adj = new List<int>[v];
            for(var i = 0; i < v; i++)
            {
                adj[i] = new List<int>();
            }
        }
        
        public int V { get; set; }
        public int E { get; set; }


        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
            E++;
        }
        public List<int> Adj(int v)
        {
            return adj[v];
        }
    }
}
