using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class Trie
    {
        private static int R = 256;
        private TrieNode root;
        private int n = 0;

        public Trie() { }
        public Trie(Dictionary<string, int> words)
        {
            //build trie from words
            foreach(var w in words)
            {
                Put(w.Key, w.Value);
            }

        }

        public int? Get(string key)
        {
            if (key == null)
                throw new ArgumentException("Null key");
            var n = Get(root, key, 0);
            if (n.Value == null)
                return null;
            else
                return (int)n.Value;

        }
        private TrieNode Get(TrieNode x, string key, int d)
        {
            if (x == null)
                return null;
            if (d == key.Length)
                return x;
            var c = key[d];
            return Get(x.Next[c], key, d + 1);
        }

        public void Put(String key, int val)
        {
            if (key == null)
                throw new ArgumentException("Null key");

            root = Put(root, key, val, 0);
        }
        private TrieNode Put(TrieNode x, string key, int val, int d)
        {
            if (x == null)
                x = new TrieNode();
            if(d == key.Length)
            {
                if (x.Value == null)
                    n++;
                x.Value = val;
                return x;
            }
            var c = key[d];
            x.Next[c] = Put(x.Next[c], key, val, d + 1);
            return x;
        }

        public IEnumerable<string> KeysWithPrefix(string prefix)
        {
            
            Queue<string> results = new Queue<string>();
            var x = Get(root, prefix, 0);
            Collect(x, prefix, results);
            return results;

        }

        private void Collect(TrieNode x, string prefix, Queue<string> results)
        {
            if (x == null)
                return;
            if (x.Value != null)
                results.Enqueue(prefix);
            for(var c = 0; c < R; c++)
            {
                prefix += Convert.ToChar(c);
                Collect(x.Next[c], prefix, results);
                prefix = prefix.Substring(0, prefix.Length - 1);
            }
        }

        public class TrieNode
        {
            public TrieNode()
            {
                Next = new TrieNode[R];
            }
            public TrieNode(int? value)
            {
                Value = value;
                Next = new TrieNode[R];
            }
            public object Value { get; set; }
            public TrieNode[] Next { get; set; }
        }
    }

    
}
