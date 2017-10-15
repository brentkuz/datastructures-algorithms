using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class BuildOrder
    {
        private const int SIZE = 256;
        private DirectedGraph g;
        private Dictionary<char, int> idx;  
        private int[] indegree;
      

        public BuildOrder()
        {
            g = new DirectedGraph(SIZE);
            idx = new Dictionary<char, int>();
            indegree = new int[SIZE];
        }
        public void AddNode(char proj)
        {
            g.AddNode((int)proj, proj.ToString());
        }
        public void AddDependency(char proj, char dependent)
        {
            var d = (int)dependent;
            indegree[d]++;
            g.AddEdge((int)proj, d);
        }

        public IEnumerable<string> Order()
        {
            Queue<string> q = new Queue<string>();
            //get 0 indegree nodes
            for(var i = 0; i < SIZE; i++)
            {
                if (indegree[i] == 0 && g.Nodes[i] != null)
                {                    
                    Traverse(q, i);
                }
            }
            return q;
        }

        private void Traverse(Queue<string> q, int v)
        {
            Queue<int> next = new Queue<int>();
            bool[] marked = new bool[SIZE];
            bool[] processed = new bool[SIZE];
            next.Enqueue(v);
            marked[v] = true;

            while (next.Count > 0)
            {
                var n = next.Dequeue();
                processed[n] = true;
                var x = g.Nodes[n];
                q.Enqueue(x.Name);

                foreach (var w in x.Adj)
                {
                    if (!marked[w.Index])
                    {                        
                        marked[w.Index] = true;
                        next.Enqueue(w.Index);
                    }
                    else if (processed[w.Index])
                        throw new Exception("Circular Dependency");

                }
            }
        }


    }
}
