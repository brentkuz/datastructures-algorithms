//Graph with symbol table to store additional info about nodes.

using Searching;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class SymbolGraph
    {
        //string -> index
        private SymbolTable<string, Nullable<int>> st;
        //index -> string
        private string[] keys;
        //underlying graph
        private Graph graph;

        public SymbolGraph(string filename, char delimeter)
        {
            st = new SymbolTable<string, Nullable<int>>();

            string[] lines = File.ReadAllLines(filename);
            
            //index
            foreach(var line in lines)
            {
                string[] a = line.Split(delimeter);
                for(var i = 0; i < a.Length; i++)
                {
                    if (!st.Contains(a[i]))
                        st.Put(a[i], st.Size());
                }
            }

            //inverted index
            keys = new string[st.Size()];
            foreach(string name in st.Keys())
            {
                keys[(int)st.Get(name)] = name;
            }

            graph = new Graph(st.Size());
            //second pass on file - build graph for processing
            foreach(var line in lines)
            {
                string[] a = line.Split(delimeter);
                int v = (int)st.Get(a[0]);
                for(var i = 1; i < a.Length; i++)
                {
                    int w = (int)st.Get(a[i]);
                    graph.AddEdge(v, w);
                }
            }
        }

        public bool Contains(string s)
        {
            return st.Contains(s);
        }

        public int Index(string s)
        {
            return (int)st.Get(s);
        }

        public string Name(int v)
        {
            return keys[v];
        }

        public Graph G()
        {
            return graph;
        }



    }
}
