using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class DirectedGraph
    {    
        public DirectedGraph(int size)
        {
            V = size;
            Nodes = new GraphNode[size];            
        }

        public GraphNode[] Nodes { get; set; }
        public int V { get; set; }
        public int E { get; set; }

        public void AddNode(int v, string name)
        {
            Nodes[v] = new GraphNode(v, name);
        }
        public void AddEdge(int v, int w)
        {
            Nodes[v].Adj.Add(Nodes[w]);
            E++;
        }       
    }

    public class GraphNode
    {
        public GraphNode(int index, string name)
        {
            Index = index;
            Name = name;
            Adj = new List<GraphNode>();
            Marked = false;
        }
        public int Index { get; set; }
        public string Name { get; set; }
        public bool Marked { get; set; }
        public List<GraphNode> Adj { get; set; }
    }
}
