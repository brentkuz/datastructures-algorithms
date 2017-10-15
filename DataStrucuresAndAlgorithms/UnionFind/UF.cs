//Union Find implementations using Quick Find and Quick Union
//Simple solution to the dynamic connectivity problem

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public abstract class UF
    {
        protected int[] id;
        protected int count;

        public UF(int n)
        {
            count = n;
            id = new int[n];
            for (var i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
        }
        public int Count
        {
            get { return count; }
        }
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }
        public abstract int Find(int p);
        public abstract void Union(int p, int q);
    }

    //UF Quick Find 
    public class QuickFind : UF
    {
        public QuickFind(int n) : base(n) { }

        //O(1)
        public override int Find(int p)
        {
            return id[p];
        }
        //O(n)
        public override void Union(int p, int q)
        {
            var pId = Find(p);
            var qId = Find(q);

            if (pId == qId)
                return;

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pId)
                    id[i] = qId;
            }
            count--;
        }
    }

    //UF Quick Union
    public class UnionFind : UF
    {
        public UnionFind(int n) : base(n) { }

        //O(n)
        public override int Find(int p)
        {
            while (id[p] != p) p = id[p];
            return p;
        }

        //O(1)
        public override void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i == j) return;
            id[i] = j;
            count--;
        }
    }

    public class WeightedQuickUnion : UF
    {
        private int[] sz;

        public WeightedQuickUnion(int n) : base(n)
        {
            sz = new int[n];
            for (var i = 0; i < n; i++)
                sz[i] = 1;
        }

        public override int Find(int p)
        {
            while (id[p] != p) p = id[p];
            return p;
        }

        public override void Union(int p, int q)
        {
            var i = Find(p);
            var j = Find(q);

            if(sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }
            count--;
        }
    }
}
