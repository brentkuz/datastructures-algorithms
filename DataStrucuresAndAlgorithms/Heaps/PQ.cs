//Priority Queue implementations.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{

    public class PQBase
    {
        protected int n = 0;
        protected IComparable[] pq;

        public PQBase()
        {
            pq = new IComparable[2];
        }
        public IComparable[] PQ
        {
            get { return pq; }
        }
        
        protected void Double()
        {            
            IComparable[] tmp = new IComparable[pq.Length*2];
            for (var i = 1; i < pq.Length; i++)
                tmp[i] = pq[i];
            pq = tmp;
        }
        protected void Half()
        {
            IComparable[] tmp = new IComparable[pq.Length / 2];
            for (var i = 1; i <= n; i++)
                tmp[i] = pq[i];
            pq = tmp;
        }
        protected bool Less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }
        protected void Exch(int i, int j)
        {
            var tmp = pq[i];
            pq[i] = pq[j];
            pq[j] = tmp;
        }
        protected void Exch(IComparable[] a, int i, int j)
        {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
  
    //Root node is max
    public class MaxPQ : PQBase
    {      
        public MaxPQ()
        {            
        }

        public bool IsEmpty()
        {
            return n == 0;
        }
        public int Size()
        {
            return n;
        }
        public void Insert(IComparable v)
        {
            if (n == pq.Length - 1)
                Double();
            pq[++n] = v;
            Swim(n);
        }
        public IComparable DelMax()
        {
            if (n + 1 < pq.Length / 2)
                Half();
            var max = pq[1];
            Exch(1, n--);
            pq[n + 1] = null;
            Sink(1);
            return max;
        }

        protected void Swim(int k)
        {
            while(k > 1 && Less(k/2, k))
            {
                Exch(k / 2, k);
                k = k / 2;
            }
        }
        protected void Sink(int k)
        {
            while (2 * k <= n) 
            {
                int j = 2 * k;
                if (j < n && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }
        protected void Sink(IComparable[] a, int k, int n)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && (a[j].CompareTo(a[j + 1]) < 0)) j++;
                if (!(a[k].CompareTo(a[j]) < 0)) break;
                Exch(k, j);
                k = j;
            }
        }
        
    }

    //Root node is min
    public class MinPQ : PQBase
    {
        public MinPQ()
        {
        }

        public bool IsEmpty()
        {
            return n == 0;
        }
        public int Size()
        {
            return n;
        }
        public void Insert(IComparable v)
        {
            if (n == pq.Length - 1)
                Double();
            pq[++n] = v;
            Swim(n);
        }
        public IComparable DelMin()
        {
            if (n + 1 < pq.Length / 2)
                Half();
            var max = pq[1];
            Exch(1, n--);
            pq[n + 1] = null;
            Sink(1);
            return max;
        }


        protected void Swim(int k)
        {
            while (k > 1 && Less(k, k / 2))
            {
                Exch(k, k / 2);
                k = k / 2;
            }
        }
        protected void Sink(int k)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && Less(j + 1, j)) j++;
                if (!Less(j, k)) break;
                Exch(k, j);
                k = j;
            }
        }
    }


    //O(nlog(n))
    public class HeapSort : MaxPQ
    {
        public void Sort(IComparable[] a)
        {
            int n = a.Length;
            for(int k = n/2; k >= 1; k--)
            {
                Sink(a, k, n);
            }
            while (n > 1)
            {
                Exch(a, 1, n--);
                Sink(a, 1, n);
            }
        }
    }
}
