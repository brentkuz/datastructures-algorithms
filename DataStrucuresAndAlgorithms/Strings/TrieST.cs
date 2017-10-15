//Trie implementation with common operations

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class TrieST
    {
        private const int R = 256;
        private Dictionary<string, int> words;
        private string[] keys;
        private int count = 0;
        private TrieNode root;


        public TrieST(string filePath) : this (File.ReadAllLines(filePath))
        {            
        }

        public TrieST(string[] lines)
        {
            words = new Dictionary<string, int>();
            
            foreach(var l in lines)
            {
                if(!words.Keys.Contains(l))
                    words.Add(l, count++);
            }

            keys = new string[count];
            int i = 0;
            foreach(var k in words.Keys)
            {
                keys[i++] = k;
            }


            //build trie
            root = new TrieNode();
            foreach(var k in words.Keys)
            {
                AddWord(root, k, 0);
            }

        }
        
        public void Delete(string word)
        {
            if (word == string.Empty || word == null)
                return;
            Delete(root, word, 0);
            var val = words[word];
            keys[val] = null;
            words.Remove(word);
        }
        private TrieNode Delete(TrieNode n, string s, int d)
        {
            if (n == null) return null;
            if(d == s.Length)
            {
                if (n.Value != null) count--;
                n.Value = null;
            }
            else
            {
                char c = s[d];
                n.Children[c] = Delete(n.Children[c], s, d + 1);
            }
            if (n.Value != null) return n;
            for (int c = 0; c < R; c++)
                if (n.Children[c] != null)
                    return n;
            return null;
        }

        public List<string> WordsWithPrefix(string prefix)
        {
            if (prefix == string.Empty || prefix == null) return null;

            var hasPrefix = new List<string>();
            Search(root, hasPrefix, prefix, 0);
            return hasPrefix;
        }
        private void Search(TrieNode n, List<string> has, string pre, int idx)
        {
            if (n == null) return;
            if (idx < pre.Length)
                Search(n.Children[pre[idx]], has, pre, idx + 1);
            else
            {
                if (n.Value != null)
                {
                    has.Add(pre);

                }
                for(var i = 0; i < R; i++)
                {
                    var c = n.Children[i];
                    if(c != null)
                        Search(c, has, pre + (char)i, idx + 1);
                }
            }
        }

        private TrieNode AddWord(TrieNode x, string key, int d)
        {
            if (x == null) x = new TrieNode();
            if (d == key.Length)
            {
                if (x.Value == null) count++;
                x.Value = count;
                return x;
            }
            char c = key[d];
            x.Children[c] = AddWord(x.Children[c], key, d + 1);
            return x;
        }


        public class TrieNode
        {
            public TrieNode()
            {
                Children = new TrieNode[R];
            }
         
            public int? Value { get; set; }
            public TrieNode[] Children { get; set; }
        }
    }


}
