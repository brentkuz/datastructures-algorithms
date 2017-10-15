//Directed Graph implementation

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Digraph : Graph
    {        
        public Digraph(int v) : base(v) { }

        public override void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            e++;
        }

        public Digraph Reverse()
        {
            Digraph r = new Digraph(v);
            for(int v = 0; v < V; v++)
            {
                foreach (var w in adj[v])
                    r.AddEdge(w, v);
            }
            return r;
        }

        public override int Degree(int v)
        {
            throw new NotImplementedException();
        }
    }

}
